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
    public interface IDocumentaryManager : IService<DocumentaryCreateDto, DocumentaryUpdateDto, DocumentaryListDto, ObjDocumentary>
    {
        Task<IResponse<List<DocumentaryListDto>>> GetActiveAsync();
        string UploadVideo(IFormFile formFile);
        string DeleteVideo(string filename);
    }
}
