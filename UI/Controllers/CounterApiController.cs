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
    public class CounterApiController : ControllerBase
    {
        private readonly ICounterManager _counterManager;
        private readonly IValidator<CounterCreateDto> _counterCreateDtoValidator;
        private readonly IValidator<CounterUpdateDto> _counterUpdateDtoValidator;
        private readonly IMapper _mapper;

        public CounterApiController(ICounterManager counterManager, IValidator<CounterCreateDto> counterCreateDtoValidator, IValidator<CounterUpdateDto> counterUpdateDtoValidator, IMapper mapper)
        {
            _counterManager = counterManager;
            _counterCreateDtoValidator = counterCreateDtoValidator;
            _counterUpdateDtoValidator = counterUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CounterListDto>> GetAll()
        {
            var response = await _counterManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<CounterCreateDto> Create(CounterCreateDto model)
        {
            var result = _counterCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _counterManager.CreateAsync(model);
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
