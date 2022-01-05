using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoManager _videoManager;
        private readonly IValidator<VideoCreateDto> _videoCreateDtoValidator;
        private readonly IValidator<VideoUpdateDto> _videoUpdateDtoValidator;
        private readonly IMapper _mapper;

        public VideoController(IVideoManager videoManager, IValidator<VideoCreateDto> videoCreateDtoValidator, IMapper mapper, IValidator<VideoUpdateDto> videoUpdateDtoValidator)
        {
            _videoManager = videoManager;
            _videoCreateDtoValidator = videoCreateDtoValidator;
            _videoUpdateDtoValidator = videoUpdateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _videoManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new VideoCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoCreateDto model)
        {
            var result = _videoCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<VideoCreateDto>(model);
                dto.VideoPath = _videoManager.UploadVideo(dto.FileDoc);
                var createResponse = await _videoManager.CreateAsync(dto);
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
            var response = await _videoManager.GetByIdAsync<VideoUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VideoUpdateDto dto)
        {
            var result = _videoUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                if (dto.FileDoc != null)
                {
                    _videoManager.DeleteVideo(dto.VideoPath);
                    dto.VideoPath = _videoManager.UploadVideo(dto.FileDoc);
                    var createResponse = await _videoManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }
                else
                {
                    var createResponse = await _videoManager.UpdateAsync(dto);
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
            var response = await _videoManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}