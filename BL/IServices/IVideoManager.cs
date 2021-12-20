using Common;
using DTOs;
using Microsoft.AspNetCore.Http;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IServices
{
    public interface IVideoManager : IService<VideoCreateDto, VideoUpdateDto, VideoListDto, ObjVideo>
    {
        Task<IResponse<List<VideoListDto>>> GetActiveAsync();
        string UploadVideo(IFormFile formFile);
        string DeleteVideo(string filename);
    }
}
