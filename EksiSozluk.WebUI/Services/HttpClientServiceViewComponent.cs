using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EksiSozluk.WebUI.Services
{
    public class HttpClientServiceViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpClientServiceViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://eksisozlukwebapi.azurewebsites.net/api/");
        }

        public async Task<IViewComponentResult> InvokeAsync<TDto>(string path)
        {
            var responseMessage = await _httpClient.GetAsync(path);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TDto>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<TDto> InvokeAsyncVal<TDto>(string path)
        {
            var responseMessage = await _httpClient.GetAsync(path);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TDto>(jsonData);
                return values;
            }
            return default(TDto);
        }
    }
}
