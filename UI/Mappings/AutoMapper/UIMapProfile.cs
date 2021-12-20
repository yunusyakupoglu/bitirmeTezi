using AutoMapper;
using DTOs;
using UI.Models;

namespace UI.Mappings.AutoMapper
{
    public class UIMapProfile : Profile
    {
        public UIMapProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
