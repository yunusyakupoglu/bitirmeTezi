using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class PresentationApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PresentationApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<PresentationListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/presentationapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PresentationListDto>>(respbody);
            }
            return new List<PresentationListDto>();
        }

        public async Task<PresentationCreateDto> CreateAsync(PresentationCreateDtoBlazor presentationCreateDto)
        {
            PresentationCreateDto dto = new PresentationCreateDto() { Title = presentationCreateDto.Title, Status = presentationCreateDto.Status, VideoPath = presentationCreateDto.VideoPath };


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/presentationapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PresentationCreateDto>(respbody);
            }
            return new PresentationCreateDto();
        }
    }
}
