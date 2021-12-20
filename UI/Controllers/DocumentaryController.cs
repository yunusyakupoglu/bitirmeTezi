using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class DocumentaryController : Controller
    {
        private readonly IDocumentaryManager _documentaryManager;
        private readonly IValidator<DocumentaryCreateDto> _documentaryCreateDtoValidator;
        private readonly IValidator<DocumentaryUpdateDto> _documentaryUpdateDtoValidator;
        private readonly IMapper _mapper;

        public DocumentaryController(IDocumentaryManager documentaryManager, IValidator<DocumentaryCreateDto> documentaryCreateDtoValidator, IValidator<DocumentaryUpdateDto> documentaryUpdateDtoValidator, IMapper mapper)
        {
            _documentaryManager = documentaryManager;
            _documentaryCreateDtoValidator = documentaryCreateDtoValidator;
            _documentaryUpdateDtoValidator = documentaryUpdateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _documentaryManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new DocumentaryCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentaryCreateDto model)
        {
            var result = _documentaryCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<DocumentaryCreateDto>(model);
                dto.VideoPath = _documentaryManager.UploadVideo(dto.FileDoc);
                var createResponse = await _documentaryManager.CreateAsync(dto);
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
            var response = await _documentaryManager.GetByIdAsync<DocumentaryUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DocumentaryUpdateDto dto)
        {
            var result = _documentaryUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                if (dto.FileDoc != null)
                {
                    _documentaryManager.DeleteVideo(dto.VideoPath);
                    dto.VideoPath = _documentaryManager.UploadVideo(dto.FileDoc);
                    var createResponse = await _documentaryManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }
                else
                {
                    var createResponse = await _documentaryManager.UpdateAsync(dto);
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
            var response = await _documentaryManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}
