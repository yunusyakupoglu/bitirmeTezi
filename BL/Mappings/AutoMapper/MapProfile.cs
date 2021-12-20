using AutoMapper;
using DTOs;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mappings.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppRoleCreateDto, ObjAppRole>().ReverseMap();
            CreateMap<AppRoleListDto, ObjAppRole>().ReverseMap();
            CreateMap<AppRoleUpdateDto, ObjAppRole>().ReverseMap();

            CreateMap<AppUserCreateDto, ObjAppUser>().ReverseMap();
            CreateMap<AppUserListDto, ObjAppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, ObjAppUser>().ReverseMap();

            CreateMap<BlogAppUserStatusCreateDto, ObjBlogAppUserStatus>().ReverseMap();
            CreateMap<BlogAppUserStatusListDto, ObjBlogAppUserStatus>().ReverseMap();
            CreateMap<BlogAppUserStatusUpdateDto, ObjBlogAppUserStatus>().ReverseMap();

            CreateMap<BlogCreateDto, ObjBlog>().ReverseMap();
            CreateMap<BlogListDto, ObjBlog>().ReverseMap();
            CreateMap<BlogUpdateDto, ObjBlog>().ReverseMap();

            CreateMap<VideoCreateDto, ObjVideo>().ReverseMap();
            CreateMap<VideoListDto, ObjVideo>().ReverseMap();
            CreateMap<VideoUpdateDto, ObjVideo>().ReverseMap();

            CreateMap<AdvertisementCreateDto, ObjAdvertisement>().ReverseMap();
            CreateMap<AdvertisementListDto, ObjAdvertisement>().ReverseMap();
            CreateMap<AdvertisementUpdateDto, ObjAdvertisement>().ReverseMap();

            CreateMap<PresentationCreateDto, ObjPresentation>().ReverseMap();
            CreateMap<PresentationListDto, ObjPresentation>().ReverseMap();
            CreateMap<PresentationUpdateDto, ObjPresentation>().ReverseMap();

            CreateMap<DocumentaryCreateDto, ObjDocumentary>().ReverseMap();
            CreateMap<DocumentaryListDto, ObjDocumentary>().ReverseMap();
            CreateMap<DocumentaryUpdateDto, ObjDocumentary>().ReverseMap();

            CreateMap<BreadCrumbCreateDto, ObjBreadCrumb>().ReverseMap();
            CreateMap<BreadCrumbListDto, ObjBreadCrumb>().ReverseMap();
            CreateMap<BreadCrumbUpdateDto, ObjBreadCrumb>().ReverseMap();

            CreateMap<CounterCreateDto, ObjCounter>().ReverseMap();
            CreateMap<CounterListDto, ObjCounter>().ReverseMap();
            CreateMap<CounterUpdateDto, ObjCounter>().ReverseMap();

            CreateMap<LinkCreateDto, ObjLink>().ReverseMap();
            CreateMap<LinkListDto, ObjLink>().ReverseMap();
            CreateMap<LinkUpdateDto, ObjLink>().ReverseMap();
        }
    }
}
