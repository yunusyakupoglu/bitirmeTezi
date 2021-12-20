using AutoMapper;
using BL.IServices;
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
    public class AppRoleManager : Service<AppRoleCreateDto, AppRoleUpdateDto, AppRoleListDto, ObjAppRole>, IAppRoleManager
    {
        public AppRoleManager(IMapper mapper, IValidator<AppRoleCreateDto> createDtoValidator, IValidator<AppRoleUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) :
            base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
        }
    }
}
