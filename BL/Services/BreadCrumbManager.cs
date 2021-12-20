using AutoMapper;
using BL.IServices;
using Common;
using DAL.UnitOfWork;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BreadCrumbManager : Service<BreadCrumbCreateDto, BreadCrumbUpdateDto, BreadCrumbListDto, ObjBreadCrumb>, IBreadCrumbManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IValidator<BreadCrumbCreateDto> _createDtoValidator;
        public BreadCrumbManager(IMapper mapper, IValidator<BreadCrumbCreateDto> createDtoValidator, IValidator<BreadCrumbUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IWebHostEnvironment env) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<List<BreadCrumbListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjBreadCrumb>().GetAllAsync(x => x.Status, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<BreadCrumbListDto>>(data);
            return new Response<List<BreadCrumbListDto>>(ResponseType.Success, dto);
        }

    }


}
