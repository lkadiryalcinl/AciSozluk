using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;
using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.EntryTransactionRelationDtos;
using EksiSozluk.WebUI.Dto.EntryTransactionDtos;

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

        public async Task<IActionResult> AddFavoritesEntry(string userId, string entryId)
        {
            var channelName = ViewBag.ChannelName;
            var TitleId = ViewBag.TitleId;

            var values = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionRelationDto>($"EntryTransactionRelation/GetEntryTransactionRelationByFilter?userId={userId}&entryId={entryId}");

            if (values != null)
            {
                var value = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionDto>($"EntryTransaction/GetEntryTransactionsByFilter?id={values.EntryTransactionId}");

                UpdateEntryTransactionDto updateEntryTransactionDto = new()
                {
                    Id = values.EntryTransactionId,
                    EntryTransactionRelationId = values.Id,
                    IsFavorited = !value.IsFavorited,
                    FavoritedDate = DateTime.Now,
                    IsDisliked = value.IsDisliked,
                    DisikedDate = value.DisikedDate,
                    IsLiked = value.IsLiked,
                    LikedDate = value.LikedDate
                };

                await _httpClientServiceAction.UpdateAsync<UpdateEntryTransactionDto>("EntryTransaction/UpdateEntryTransaction", updateEntryTransactionDto);
                return RedirectToAction("Index", "TitleDetail", new { channelName, TitleId });
            }
            else
            {
                CreateEntryTransactionRelationDto createEntryTransactionRelationDto = new()
                {
                    UserId = userId,
                    EntryId = Guid.Parse(entryId),
                    IsLiked = false,
                    LikedDate = DateTime.MinValue,
                    IsDisliked = false,
                    DisikedDate = DateTime.MinValue,

                    IsFavorited = true,
                    FavoritedDate = DateTime.Now
                };

                await _httpClientServiceAction.CreateAsync<CreateEntryTransactionRelationDto>("EntryTransactionRelation/CreateEntryTransactionRelation", createEntryTransactionRelationDto);
                return RedirectToAction("Index", "TitleDetail", new { channelName, TitleId });
            }
        }
    }
}
