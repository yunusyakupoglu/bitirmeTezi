using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class AdvertisementApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdvertisementApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<AdvertisementListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/advertisementapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AdvertisementListDto>>(respbody);
            }
            return new List<AdvertisementListDto>();
        }

        public async Task<AdvertisementCreateDto> CreateAsync(AdvertisementCreateDtoBlazor advertisementCreateDto)
        {
            AdvertisementCreateDto dto = new AdvertisementCreateDto() { Title = advertisementCreateDto.Title, Status = advertisementCreateDto.Status, ImagePath = advertisementCreateDto.ImagePath };


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/advertisementapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AdvertisementCreateDto>(respbody);
            }
            return new AdvertisementCreateDto();
        }
    }
}
