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
    public class LinkManager : Service<LinkCreateDto, LinkUpdateDto, LinkListDto, ObjLink>, ILinkManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IValidator<LinkCreateDto> _createDtoValidator;
        public LinkManager(IMapper mapper, IValidator<LinkCreateDto> createDtoValidator, IValidator<LinkUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IWebHostEnvironment env) :
            base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<List<LinkListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjLink>().GetAllAsync(x => x.Status, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<LinkListDto>>(data);
            return new Response<List<LinkListDto>>(ResponseType.Success, dto);
        }

    }
}
