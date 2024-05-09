using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;
using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.EntryTransactionRelationDtos;

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

        public async void AddFavoritesEntry(string userId,string entryId)
        {
            var values = await _httpClientServiceAction.InvokeAsync<ResultEntryTransactionRelationDto>($"EntryTransactionRelation/GetEntryTransactionRelationByFilter?userId={userId}&entryId={entryId}");

            if(values != null)
            {

            }
            else
            {
                CreateEntryTransactionRelationDto createEntryTransactionRelationDto = new();
                createEntryTransactionRelationDto.UserId = userId;
                createEntryTransactionRelationDto.EntryId = Guid.Parse(entryId);
                createEntryTransactionRelationDto.IsLiked = false;
                createEntryTransactionRelationDto.LikedDate = DateTime.MinValue;
                createEntryTransactionRelationDto.IsDisliked = false;
                createEntryTransactionRelationDto.DisikedDate = DateTime.MinValue;

                createEntryTransactionRelationDto.IsFavorited = true;
                createEntryTransactionRelationDto.FavoritedDate = DateTime.Now;

                await _httpClientServiceAction.CreateAsync<CreateEntryTransactionRelationDto>("EntryTransactionRelation/CreateEntryTransactionRelation", createEntryTransactionRelationDto);
            }
        }
    }
}
