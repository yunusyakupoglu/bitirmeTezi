using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterManager _counterManager;
        private readonly IValidator<CounterCreateDto> _counterCreateDtoValidator;
        private readonly IMapper _mapper;

        public CounterController(ICounterManager counterManager, IValidator<CounterCreateDto> counterCreateDtoValidator, IMapper mapper)
        {
            _counterManager = counterManager;
            _counterCreateDtoValidator = counterCreateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _counterManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new CounterCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CounterCreateDto model)
        {
            var result = _counterCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<CounterCreateDto>(model);
                var createResponse = await _counterManager.CreateAsync(dto);
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
            var response = await _counterManager.GetByIdAsync<CounterUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CounterUpdateDto dto)
        {
            var response = await _counterManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _counterManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}
