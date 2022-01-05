using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoApiController : ControllerBase
    {
        private readonly IVideoManager _videoManager;
        private readonly IValidator<VideoCreateDto> _videoCreateDtoValidator;
        private readonly IValidator<VideoUpdateDto> _videoUpdateDtoValidator;
        private readonly IMapper _mapper;

        public VideoApiController(IVideoManager videoManager, IValidator<VideoCreateDto> videoCreateDtoValidator, IMapper mapper, IValidator<VideoUpdateDto> videoUpdateDtoValidator)
        {
            _videoManager = videoManager;
            _videoCreateDtoValidator = videoCreateDtoValidator;
            _videoUpdateDtoValidator = videoUpdateDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<VideoListDto>> GetAll()
        {
            var response = await _videoManager.GetAllAsync();
            return response.Data;
        }

        [HttpPost]
        public async Task<VideoCreateDto> Create(VideoCreateDto model)
        {
            var result = _videoCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var createResponse = await _videoManager.CreateAsync(model);
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
