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
    public class DocumentaryApiController : ControllerBase
    {
        private readonly IDocumentaryManager _documentaryManager;
        private readonly IValidator<DocumentaryCreateDto> _documentaryCreateDtoValidator;
        private readonly IValidator<DocumentaryUpdateDto> _documentaryUpdateDtoValidator;
        private readonly IMapper _mapper;

        public DocumentaryApiController(IDocumentaryManager documentaryManager, IValidator<DocumentaryCreateDto> documentaryCreateDtoValidator, IValidator<DocumentaryUpdateDto> documentaryUpdateDtoValidator, IMapper mapper)
        {
            _documentaryManager = documentaryManager;
            _documentaryCreateDtoValidator = documentaryCreateDtoValidator;
            _documentaryUpdateDtoValidator = documentaryUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<DocumentaryListDto>> GetAll()
        {
            var response = await _documentaryManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<DocumentaryCreateDto> Create(DocumentaryCreateDto model)
        {
            var result = _documentaryCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _documentaryManager.CreateAsync(model);
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
