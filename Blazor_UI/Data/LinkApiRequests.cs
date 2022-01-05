using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class LinkApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LinkApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<LinkListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/linkapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LinkListDto>>(respbody);
            }
            return new List<LinkListDto>();
        }

        public async Task<LinkCreateDto> CreateAsync(LinkCreateDtoBlazor linkCreateDto)
        {
            LinkCreateDto dto = new LinkCreateDto() { Title = linkCreateDto.Title, Status = linkCreateDto.Status, Url = linkCreateDto.Url };


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/linkapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LinkCreateDto>(respbody);
            }
            return new LinkCreateDto();
        }
    }
}
