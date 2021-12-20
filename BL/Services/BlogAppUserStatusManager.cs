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
    public class BlogAppUserStatusManager : Service<BlogAppUserStatusCreateDto, BlogAppUserStatusUpdateDto, BlogAppUserStatusListDto, ObjBlogAppUserStatus>, IBlogAppUserStatusManager
    {
        public BlogAppUserStatusManager(IMapper mapper, IValidator<BlogAppUserStatusCreateDto> createDtoValidator, IValidator<BlogAppUserStatusUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) :
            base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
        }
    }
}
