using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class CounterApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CounterApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CounterListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/counterapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CounterListDto>>(respbody);
            }
            return new List<CounterListDto>();
        }

        public async Task<CounterCreateDto> CreateAsync(CounterCreateDtoBlazor counterCreateDto)
        {
            CounterCreateDto dto = new CounterCreateDto() { Title = counterCreateDto.Title, Status = counterCreateDto.Status, Count = counterCreateDto.Count };


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/counterapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CounterCreateDto>(respbody);
            }
            return new CounterCreateDto();
        }
    }
}
