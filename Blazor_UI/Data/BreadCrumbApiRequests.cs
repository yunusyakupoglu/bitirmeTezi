using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class BreadCrumbApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BreadCrumbApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<BreadCrumbListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/breadcrumbapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BreadCrumbListDto>>(respbody);
            }
            return new List<BreadCrumbListDto>();
        }

        public async Task<BreadCrumbCreateDto> CreateAsync(BreadCrumbCreateDtoBlazor breadCrumbCreateDto)
        {
            BreadCrumbCreateDto dto = new BreadCrumbCreateDto() { Title = breadCrumbCreateDto.Title, MiniHeader = breadCrumbCreateDto.MiniHeader, Description = breadCrumbCreateDto.Description, Status = breadCrumbCreateDto.Status };


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/breadcrumbapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BreadCrumbCreateDto>(respbody);
            }
            return new BreadCrumbCreateDto();
        }
    }
}
