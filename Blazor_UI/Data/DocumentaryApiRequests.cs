using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class DocumentaryApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DocumentaryApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<DocumentaryListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/documentaryapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DocumentaryListDto>>(respbody);
            }
            return new List<DocumentaryListDto>();
        }

        public async Task<DocumentaryCreateDto> CreateAsync(DocumentaryCreateDtoBlazor documentaryCreateDto)
        {
            DocumentaryCreateDto dto = new DocumentaryCreateDto() { Title = documentaryCreateDto.Title, Status = documentaryCreateDto.Status, VideoPath = documentaryCreateDto.VideoPath };


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/documentaryapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DocumentaryCreateDto>(respbody);
            }
            return new DocumentaryCreateDto();
        }
    }
}
