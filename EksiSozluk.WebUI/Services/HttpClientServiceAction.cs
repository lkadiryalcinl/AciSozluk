using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EksiSozluk.WebUI.Services
{
    public class HttpClientServiceAction
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpClientServiceAction(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5088/api/");
        }

        public async Task<TDto> InvokeAsync<TDto>(string path)
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

        public async Task<bool> CreateAsync<TDto>(string path, TDto CreateDto)
        {
            var jsonData = JsonConvert.SerializeObject(CreateDto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(path, content);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> CreateAsyncVal<TDto>(string path, TDto CreateDto)
        {
            var jsonData = JsonConvert.SerializeObject(CreateDto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(path, content);

            return responseMessage;
        }

        public async Task<bool> RemoveAsync(string path)
        {
            var responseMessage = await _httpClient.DeleteAsync(path);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync<TDto>(string path, TDto updateDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateDto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync(path, content);
             
            return responseMessage.IsSuccessStatusCode;
        }

    }
}
