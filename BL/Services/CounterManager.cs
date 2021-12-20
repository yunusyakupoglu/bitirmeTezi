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
    public class CounterManager : Service<CounterCreateDto, CounterUpdateDto, CounterListDto, ObjCounter>, ICounterManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IValidator<CounterCreateDto> _createDtoValidator;
        public CounterManager(IMapper mapper, IValidator<CounterCreateDto> createDtoValidator, IValidator<CounterUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IWebHostEnvironment env) :
            base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<List<CounterListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjCounter>().GetAllAsync(x => x.Status, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<CounterListDto>>(data);
            return new Response<List<CounterListDto>>(ResponseType.Success, dto);
        }

    }
}
