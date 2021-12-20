using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class BreadCrumbController : Controller
    {
        private readonly IBreadCrumbManager _breadCrumbManager;
        private readonly IValidator<BreadCrumbCreateDto> _breadCrumbCreateDtoValidator;
        private readonly IMapper _mapper;

        public BreadCrumbController(IBreadCrumbManager breadCrumbManager, IValidator<BreadCrumbCreateDto> breadCrumbCreateDtoValidator, IMapper mapper)
        {
            _breadCrumbManager = breadCrumbManager;
            _breadCrumbCreateDtoValidator = breadCrumbCreateDtoValidator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _breadCrumbManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new BreadCrumbCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BreadCrumbCreateDto model)
        {
            var result = _breadCrumbCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<BreadCrumbCreateDto>(model);
                var createResponse = await _breadCrumbManager.CreateAsync(dto);
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
            var response = await _breadCrumbManager.GetByIdAsync<BreadCrumbUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BreadCrumbUpdateDto dto)
        {
            var response = await _breadCrumbManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _breadCrumbManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}
