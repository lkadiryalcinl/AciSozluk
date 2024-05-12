using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;
using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.EntryTransactionRelationDtos;
using EksiSozluk.WebUI.Dto.EntryTransactionDtos;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace EksiSozluk.WebUI.Controllers
{
    public class TitleDetailController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public TitleDetailController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index(string channelName, string titleId)
        {
            ViewBag.ChannelName = channelName;
            ViewBag.TitleId = titleId;
            var values = await _httpClientServiceAction.InvokeAsync<TitleWithEntriesDto>($"Titles/GetTitleByFilterWithEntries?id={titleId}");
            return titleId.IsNullOrEmpty() ? View() : View(values);
        }

        public async Task<IActionResult> UpdateTransaction(string userId, string entryId, string actionType)
        {
            var values = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionRelationDto>($"EntryTransactionRelation/GetEntryTransactionRelationByFilter?userId={userId}&entryId={entryId}");

            if (values != null)
            {
                var value = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionDto>($"EntryTransaction/GGetEntryTransactionsByFilter?id={values.EntryTransactionId.ToString()}");
                UpdateEntryTransactionDto updateEntryTransactionDto = new()
                {
                    Id = values.EntryTransactionId,
                    EntryTransactionRelationId = values.Id,
                    IsFavorited = actionType == "favorite" ? !value.IsFavorited : value.IsFavorited,
                    FavoritedDate = actionType == "favorite" ? DateTime.Now : value.FavoritedDate,
                    IsDisliked = actionType == "dislike" ? !value.IsDisliked : value.IsDisliked,
                    DisikedDate = actionType == "dislike" ? DateTime.Now : value.DisikedDate,
                    IsLiked = actionType == "like" ? !value.IsLiked : value.IsLiked,
                    LikedDate = actionType == "like" ? DateTime.Now : value.LikedDate
                };

                await _httpClientServiceAction.UpdateAsync<UpdateEntryTransactionDto>("EntryTransaction/UpdateEntryTransaction", updateEntryTransactionDto);
                return RedirectToAction("Index", "TitleDetail");
            }
            else
            {
                CreateEntryTransactionRelationDto createEntryTransactionRelationDto = new()
                {
                    UserId = userId,
                    EntryId = Guid.Parse(entryId),
                    IsLiked = actionType == "like",
                    LikedDate = actionType == "like" ? DateTime.Now : DateTime.MinValue,
                    IsDisliked = actionType == "dislike",
                    DisikedDate = actionType == "dislike" ? DateTime.Now : DateTime.MinValue,
                    IsFavorited = actionType == "favorite",
                    FavoritedDate = actionType == "favorite" ? DateTime.Now : DateTime.MinValue
                };

                await _httpClientServiceAction.CreateAsync<CreateEntryTransactionRelationDto>("EntryTransactionRelation/CreateEntryTransactionRelation", createEntryTransactionRelationDto);
                return RedirectToAction("Index", "TitleDetail");
            }
        }
    }
}