using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkManager _linkManager;
        private readonly IValidator<LinkCreateDto> _linkCreateDtoValidator;
        private readonly IMapper _mapper;

        public LinkController(ILinkManager linkManager, IValidator<LinkCreateDto> linkCreateDtoValidator, IMapper mapper)
        {
            _linkManager = linkManager;
            _linkCreateDtoValidator = linkCreateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _linkManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new LinkCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LinkCreateDto model)
        {
            var result = _linkCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<LinkCreateDto>(model);
                var createResponse = await _linkManager.CreateAsync(dto);
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
            var response = await _linkManager.GetByIdAsync<LinkUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LinkUpdateDto dto)
        {
            var response = await _linkManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _linkManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}
