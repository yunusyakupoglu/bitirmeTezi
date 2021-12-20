using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementManager _advertisementManager;
        private readonly IValidator<AdvertisementCreateDto> _advertisementCreateDtoValidator;
        private readonly IValidator<AdvertisementUpdateDto> _advertisementUpdateDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementController(IAdvertisementManager advertisementManager, IValidator<AdvertisementCreateDto> advertisementCreateDtoValidator, IValidator<AdvertisementUpdateDto> advertisementUpdateDtoValidator, IMapper mapper)
        {
            _advertisementManager = advertisementManager;
            _advertisementCreateDtoValidator = advertisementCreateDtoValidator;
            _advertisementUpdateDtoValidator = advertisementUpdateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _advertisementManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new AdvertisementCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDto model)
        {
            var result = _advertisementCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AdvertisementCreateDto>(model);
                dto.ImagePath = _advertisementManager.UploadImage(dto.FileDoc);
                var createResponse = await _advertisementManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _advertisementManager.GetByIdAsync<AdvertisementUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdvertisementUpdateDto dto)
        {
            var result = _advertisementUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                if (dto.FileDoc != null)
                {
                    _advertisementManager.DeleteImage(dto.ImagePath);
                    dto.ImagePath = _advertisementManager.UploadImage(dto.FileDoc);
                    var createResponse = await _advertisementManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }
                else
                {
                    var createResponse = await _advertisementManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(dto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _advertisementManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}
