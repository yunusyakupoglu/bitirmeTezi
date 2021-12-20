using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class PresentationController : Controller
    {
        private readonly IPresentationManager _presentationManager;
        private readonly IValidator<PresentationCreateDto> _presentationCreateDtoValidator;
        private readonly IValidator<PresentationUpdateDto> _presentationUpdateDtoValidator;
        private readonly IMapper _mapper;

        public PresentationController(IPresentationManager presentationManager, IValidator<PresentationCreateDto> presentationCreateDtoValidator, IValidator<PresentationUpdateDto> presentationUpdateDtoValidator, IMapper mapper)
        {
            _presentationManager = presentationManager;
            _presentationCreateDtoValidator = presentationCreateDtoValidator;
            _presentationUpdateDtoValidator = presentationUpdateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _presentationManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new PresentationCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PresentationCreateDto model)
        {
            var result = _presentationCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<PresentationCreateDto>(model);
                dto.VideoPath = _presentationManager.UploadVideo(dto.FileDoc);
                var createResponse = await _presentationManager.CreateAsync(dto);
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
            var response = await _presentationManager.GetByIdAsync<PresentationUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PresentationUpdateDto dto)
        {
            var result = _presentationUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                if (dto.FileDoc != null)
                {
                    _presentationManager.DeleteVideo(dto.VideoPath);
                    dto.VideoPath = _presentationManager.UploadVideo(dto.FileDoc);
                    var createResponse = await _presentationManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }
                else
                {
                    var createResponse = await _presentationManager.UpdateAsync(dto);
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
            var response = await _presentationManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}
