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
    public interface IPresentationManager : IService<PresentationCreateDto, PresentationUpdateDto, PresentationListDto, ObjPresentation>
    {
        Task<IResponse<List<PresentationListDto>>> GetActiveAsync();
        string UploadVideo(IFormFile formFile);
        string DeleteVideo(string filename);
    }
}
