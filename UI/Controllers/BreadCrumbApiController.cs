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
    public class BreadCrumbApiController : ControllerBase
    {
        private readonly IBreadCrumbManager _breadCrumbManager;
        private readonly IValidator<BreadCrumbCreateDto> _breadCrumbCreateDtoValidator;
        private readonly IValidator<BreadCrumbUpdateDto> _breadCrumbUpdateDtoValidator;
        private readonly IMapper _mapper;

        public BreadCrumbApiController(IBreadCrumbManager breadCrumbManager, IValidator<BreadCrumbCreateDto> breadCrumbCreateDtoValidator, IValidator<BreadCrumbUpdateDto> breadCrumbUpdateDtoValidator, IMapper mapper)
        {
            _breadCrumbManager = breadCrumbManager;
            _breadCrumbCreateDtoValidator = breadCrumbCreateDtoValidator;
            _breadCrumbUpdateDtoValidator = breadCrumbUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<BreadCrumbListDto>> GetAll()
        {
            var response = await _breadCrumbManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<BreadCrumbCreateDto> Create(BreadCrumbCreateDto model)
        {
            var result = _breadCrumbCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _breadCrumbManager.CreateAsync(model);
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
