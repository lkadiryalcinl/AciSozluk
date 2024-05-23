using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;
using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.EntryTransactionRelationDtos;
using EksiSozluk.WebUI.Dto.EntryTransactionDtos;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using EksiSozluk.WebUI.Dto.EntryDtos;
using EksiSozluk.WebUI.Dto.ProfileDtos;

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
            values.EntryList = values.EntryList.Where(x => !x.IsEntryDelete).ToList();
            values.ChannelName = channelName ?? String.Empty;
            return titleId.IsNullOrEmpty() ? View() : View(values);
        }

        public async Task<IActionResult> UpdateTransaction(UpdateTransactionParamDto updateTransactionParamDto)
        {
            var values = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionRelationDto>($"EntryTransactionRelation/GetEntryTransactionRelationByFilter?userId={updateTransactionParamDto.UserId}&entryId={updateTransactionParamDto.EntryId}");

            if (values != null)
            {
                var value = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionDto>($"EntryTransaction/GetEntryTransactionsByFilter?id={values.EntryTransactionId}");

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
                return RedirectToAction("Index", "TitleDetail", new { updateTransactionParamDto.ChannelName, updateTransactionParamDto.TitleId });
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
                return RedirectToAction("Index", "TitleDetail", new { updateTransactionParamDto.ChannelName, updateTransactionParamDto.TitleId });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(CreateEntryDto createEntryDto)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            createEntryDto.UserId = userId;
            await _httpClientServiceAction.CreateAsync<CreateEntryDto>("Entry/CreateEntry", createEntryDto);
            return RedirectToAction("Index", "TitleDetail", new { channelName = createEntryDto.ChannelName, titleId = createEntryDto.TitleId });

        }

        [HttpGet("UpdateEntry")]
        public async Task<IActionResult> UpdateEntry(string entryId)
        {
            var value = await _httpClientServiceAction.InvokeAsync<TitleWithEntrySingleDto>($"Entry/GetEntryByFilter?id={entryId}");
            return View(value);
        }


        [HttpPost("UpdateEntry")]
        public async Task<IActionResult> UpdateEntry(UpdateEntryDto updateEntryDto)
        {
            var username = HttpContext.User.Identity.Name;
            await _httpClientServiceAction.UpdateAsync<UpdateEntryDto>("Entry/UpdateProfileEntry", updateEntryDto);
            return RedirectToAction("Index", "Profile", new { username });
        }

    }
}