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
    public class PresentationApiController : ControllerBase
    {
        private readonly IPresentationManager _presentationManager;
        private readonly IValidator<PresentationCreateDto> _presentationCreateDtoValidator;
        private readonly IValidator<PresentationUpdateDto> _presentationUpdateDtoValidator;
        private readonly IMapper _mapper;

        public PresentationApiController(IPresentationManager presentationManager, IValidator<PresentationCreateDto> presentationCreateDtoValidator, IValidator<PresentationUpdateDto> presentationUpdateDtoValidator, IMapper mapper)
        {
            _presentationManager = presentationManager;
            _presentationCreateDtoValidator = presentationCreateDtoValidator;
            _presentationUpdateDtoValidator = presentationUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PresentationListDto>> GetAll()
        {
            var response = await _presentationManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<PresentationCreateDto> Create(PresentationCreateDto model)
        {
            var result = _presentationCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _presentationManager.CreateAsync(model);
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
