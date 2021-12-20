using AutoMapper;
using BL.IServices;
using Common;
using DAL.UnitOfWork;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AdvertisementManager : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, ObjAdvertisement>, IAdvertisementManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IValidator<AdvertisementCreateDto> _createDtoValidator;
        public AdvertisementManager(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IWebHostEnvironment env) : 
            base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync()
        {

            var data = await _unitOfWork.GetRepository<ObjAdvertisement>().GetAllAsync(x => x.Status, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
        }

        public string UploadImage(IFormFile formFile)
        {
            if (formFile != null)
            {

                string path = Path.Combine(this._env.WebRootPath, "img\\upload");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(formFile.FileName);
                string[] filenamedot = fileName.Split('.');
                string fileename = filenamedot[0];
                fileename = DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + fileename + "." + filenamedot[filenamedot.Length - 1].ToString();
                using (FileStream stream = new(Path.Combine(path, fileename), FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                //string host = _httpContextAccessor.HttpContext.Request.Host.Value;
                //string FileNameFinal = Path.Combine(this._hostEnvironment.WebRootPath, "img", fileename);
                string fileNameFinal = "img/upload/" + fileename;
                return fileNameFinal;
            }
            else
            {
                return "img/team/profile-picture-1.jpg";
            }

        }

        public string DeleteImage(string filename)
        {
            try
            {
                string s = "";
                string wwwPath = this._env.WebRootPath;

                if (File.Exists(Path.Combine(wwwPath, filename)))
                {
                    File.Delete(Path.Combine(wwwPath, filename));
                    s = "Fotoğraf silme başarılı";
                }
                return s;
            }
            catch (Exception)
            {
                return "Fotoğraf silinirken bir sorun oluştu. Lütfen daha sonra tekrar deneyiniz.";
            }
        }
    }
}
