using AutoMapper;
using BL.Extensions;
using BL.IServices;
using Common;
using DAL.UnitOfWork;
using DTOs;
using FluentValidation;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AppUserManager : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, ObjAppUser>, IAppUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IValidator<AppUserLoginDto> loginDtoValidator) :
            base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<ObjAppUser>(dto);
                await _unitOfWork.GetRepository<ObjAppUser>().CreateAsync(user);
                await _unitOfWork.GetRepository<ObjAppUserRole>().CreateAsync(new ObjAppUserRole
                {
                    AppRoleId = roleId,
                    ObjAppUser = user
                });

                await _unitOfWork.SaveChangesAsync();

                return new Response<AppUserCreateDto>(ResponseType.Success, dto);

            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _unitOfWork.GetRepository<ObjAppUser>().GetByFilterAsync(x => x.UserName == dto.UserName && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>("Kullanıcı adı veya parola hatalı", ResponseType.NotFound);
            }
            return new Response<AppUserListDto>("Kullanıcı adı veya şifre boş olamaz", ResponseType.ValidationError);
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _unitOfWork.GetRepository<ObjAppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>("Kullanıcıya ait ilgili rol bulunamadı.", ResponseType.NotFound);
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }

}
