using AutoMapper;
using BL.IServices;
using Common.Enums;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AccountController(IValidator<UserCreateModel> userCreateModelValidator, IAppUserManager appUserManager, IMapper mapper)
        {
            _userCreateModelValidator = userCreateModelValidator;
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var response = await _appUserManager.GetAllAsync();
            return this.ResponseView(response);
        }
        public IActionResult SignUp()
        {
            var model = new UserCreateModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserManager.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserManager.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                var roleResult = await _appUserManager.GetRolesByUserIdAsync(result.Data.Id);
                //ilgili kullanıcının rollerini çekeceksin burada.
                var claims = new List<Claim>();

                if (roleResult.ResponseType == Common.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
                }


                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Admin", "Home");
            }
            ModelState.AddModelError("", result.Message);
            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }
    }
}
