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
    public class LinkApiController : ControllerBase
    {
        private readonly ILinkManager _linkManager;
        private readonly IValidator<LinkCreateDto> _linkCreateDtoValidator;
        private readonly IValidator<LinkUpdateDto> _linkUpdateDtoValidator;
        private readonly IMapper _mapper;

        public LinkApiController(ILinkManager linkManager, IValidator<LinkCreateDto> linkCreateDtoValidator, IValidator<LinkUpdateDto> linkUpdateDtoValidator, IMapper mapper)
        {
            _linkManager = linkManager;
            _linkCreateDtoValidator = linkCreateDtoValidator;
            _linkUpdateDtoValidator = linkUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<LinkListDto>> GetAll()
        {
            var response = await _linkManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<LinkCreateDto> Create(LinkCreateDto model)
        {
            var result = _linkCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _linkManager.CreateAsync(model);
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
