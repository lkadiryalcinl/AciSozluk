﻿using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;
using EksiSozluk.WebUI.Dto.EntryTransactionDtos;
using EksiSozluk.WebUI.Dto.EntryTransactionRelationDtos;
using EksiSozluk.Domain.Entities;
using System.Security.Claims;

namespace EksiSozluk.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public HomeController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index(string channelName)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.ChannelName = channelName;
            var values = channelName.IsNullOrEmpty() ?
                await _httpClientServiceAction.InvokeAsync<List<TitlesWithFirstEntryDto>>($"Titles/GetTitlesByFilterWithFirstEntry?id=debe&userId={userId + "a"}")
                : await _httpClientServiceAction.InvokeAsync<List<TitlesWithFirstEntryDto>>($"Titles/GetTitlesByFilterWithFirstEntry?id={channelName}&userId={userId + "a"}");
            var sortedValues = !values.IsNullOrEmpty()?values.Where(x => !x.FirstEntry.IsEntryDelete).ToList():values;
            return View(sortedValues);
        }

        public async Task<IActionResult> UpdateTransaction(UpdateTransactionParamDto updateTransactionParamDto)
        {
            //UpdateTransactionParamDto updateTransactionParamDto = new();

            var values = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionRelationDto>($"EntryTransactionRelation/GetEntryTransactionRelationByFilter?userId={updateTransactionParamDto.UserId}&entryId={updateTransactionParamDto.EntryId}");

            if (values != null)
            {
                var value = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionDto>($"EntryTransaction/GetEntryTransactionsByFilter?id={values.EntryTransactionId}");

                if (updateTransactionParamDto.ActionType == "like" && value.IsDisliked)
                {
                    value.IsDisliked = false;
                    value.DisikedDate = DateTime.MinValue;
                }
                if (updateTransactionParamDto.ActionType == "dislike" && value.IsLiked)
                {
                    value.IsLiked = false;
                    value.LikedDate = DateTime.MinValue;
                }

                UpdateEntryTransactionDto updateEntryTransactionDto = new()
                {
                    Id = values.EntryTransactionId,
                    EntryTransactionRelationId = values.Id,
                    IsFavorited = updateTransactionParamDto.ActionType == "favorite" ? !value.IsFavorited : value.IsFavorited,
                    FavoritedDate = updateTransactionParamDto.ActionType == "favorite" ? DateTime.Now : value.FavoritedDate,
                    IsDisliked = updateTransactionParamDto.ActionType == "dislike" ? !value.IsDisliked : value.IsDisliked,
                    DisikedDate = updateTransactionParamDto.ActionType == "dislike" ? DateTime.Now : value.DisikedDate,
                    IsLiked = updateTransactionParamDto.ActionType == "like" ? !value.IsLiked : value.IsLiked,
                    LikedDate = updateTransactionParamDto.ActionType == "like" ? DateTime.Now : value.LikedDate
                };

                await _httpClientServiceAction.UpdateAsync<UpdateEntryTransactionDto>("EntryTransaction/UpdateEntryTransaction", updateEntryTransactionDto);
                return RedirectToAction("Index", "Home", new { updateTransactionParamDto.ChannelName });
            }
            else
            {
                CreateEntryTransactionRelationDto createEntryTransactionRelationDto = new()
                {
                    UserId = updateTransactionParamDto.UserId,
                    EntryId = Guid.Parse(updateTransactionParamDto.EntryId),
                    IsLiked = updateTransactionParamDto.ActionType == "like",
                    LikedDate = updateTransactionParamDto.ActionType == "like" ? DateTime.Now : DateTime.MinValue,
                    IsDisliked = updateTransactionParamDto.ActionType == "dislike",
                    DisikedDate = updateTransactionParamDto.ActionType == "dislike" ? DateTime.Now : DateTime.MinValue,

                    IsFavorited = updateTransactionParamDto.ActionType == "favorite",
                    FavoritedDate = updateTransactionParamDto.ActionType == "favorite" ? DateTime.Now : DateTime.MinValue
                };

                await _httpClientServiceAction.CreateAsync<CreateEntryTransactionRelationDto>("EntryTransactionRelation/CreateEntryTransactionRelation", createEntryTransactionRelationDto);
                return RedirectToAction("Index", "Home", new { updateTransactionParamDto.ChannelName });
            }
        }
    }
}