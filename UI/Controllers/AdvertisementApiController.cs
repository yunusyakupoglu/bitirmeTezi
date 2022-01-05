using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementApiController : ControllerBase
    {
        private readonly IAdvertisementManager _advertisementManager;
        private readonly IValidator<AdvertisementCreateDto> _advertisementCreateDtoValidator;
        private readonly IValidator<AdvertisementUpdateDto> _advertisementUpdateDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementApiController(IAdvertisementManager advertisementManager, IValidator<AdvertisementCreateDto> advertisementCreateDtoValidator, IValidator<AdvertisementUpdateDto> advertisementUpdateDtoValidator, IMapper mapper)
        {
            _advertisementManager = advertisementManager;
            _advertisementCreateDtoValidator = advertisementCreateDtoValidator;
            _advertisementUpdateDtoValidator = advertisementUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<AdvertisementListDto>> GetAll()
        {
            var response = await _advertisementManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<AdvertisementCreateDto> Create(AdvertisementCreateDto model)
        {
            var result = _advertisementCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _advertisementManager.CreateAsync(model);
                return createResponse.Data;
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return model;
        }
    }
}
