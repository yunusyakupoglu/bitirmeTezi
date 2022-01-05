using DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Blazor_UI.Data
{
    public class VideoApiRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VideoApiRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<VideoListDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/videoapi");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VideoListDto>>(respbody);
            }
            return new List<VideoListDto>();
        }

        public async Task<VideoCreateDto> CreateAsync(VideoCreateDtoBlazor videoCreateDto)
        {
            VideoCreateDto dto = new VideoCreateDto() { Name = videoCreateDto.Name, Status = videoCreateDto.Status,VideoPath=videoCreateDto.VideoPath };
            

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var resp = await client.PostAsync("https://localhost:5001/api/videoapi", httpContent);
            if (resp.IsSuccessStatusCode)
            {
                var respbody = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VideoCreateDto>(respbody);
            }
            return new VideoCreateDto();
        }
    }
}
