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
    public interface IAdvertisementManager : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, ObjAdvertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync();
        string UploadImage(IFormFile formFile);
        string DeleteImage(string filename);
    }
}
