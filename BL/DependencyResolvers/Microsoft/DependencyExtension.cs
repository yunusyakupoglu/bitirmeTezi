using AutoMapper;
using BL.IServices;
using BL.Mappings.AutoMapper;
using BL.Services;
using BL.ValidationRules;
using DAL;
using DAL.UnitOfWork;
using DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IValidator<AppRoleCreateDto>, AppRoleCreateDtoValidator>();
            services.AddTransient<IValidator<AppRoleUpdateDto>, AppRoleUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<BlogAppUserStatusCreateDto>, BlogAppUserStatusCreateDtoValidator>();
            services.AddTransient<IValidator<BlogAppUserStatusUpdateDto>, BlogAppUserStatusUpdateDtoValidator>();

            services.AddTransient<IValidator<BlogCreateDto>, BlogCreateDtoValidator>();
            services.AddTransient<IValidator<BlogUpdateDto>, BlogUpdateDtoValidator>();

            services.AddTransient<IValidator<VideoCreateDto>, VideoCreateDtoValidator>();
            services.AddTransient<IValidator<VideoUpdateDto>, VideoUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<PresentationCreateDto>, PresentationCreateDtoValidator>();
            services.AddTransient<IValidator<PresentationUpdateDto>, PresentationUpdateDtoValidator>();

            services.AddTransient<IValidator<DocumentaryCreateDto>, DocumentaryCreateDtoValidator>();
            services.AddTransient<IValidator<DocumentaryUpdateDto>, DocumentaryUpdateDtoValidator>();

            services.AddTransient<IValidator<BreadCrumbCreateDto>, BreadCrumbCreateDtoValidator>();
            services.AddTransient<IValidator<BreadCrumbUpdateDto>, BreadCrumbUpdateDtoValidator>();

            services.AddTransient<IValidator<CounterCreateDto>, CounterCreateDtoValidator>();
            services.AddTransient<IValidator<CounterUpdateDto>, CounterUpdateDtoValidator>();

            services.AddTransient<IValidator<LinkCreateDto>, LinkCreateDtoValidator>();
            services.AddTransient<IValidator<LinkUpdateDto>, LinkUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddScoped<IAppRoleManager, AppRoleManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IBlogAppUserStatusManager, BlogAppUserStatusManager>();
            services.AddScoped<IBlogManager, BlogManager>();
            services.AddScoped<IVideoManager, VideoManager>();
            services.AddScoped<IAdvertisementManager, AdvertisementManager>();
            services.AddScoped<IPresentationManager, PresentationManager>();
            services.AddScoped<IDocumentaryManager, DocumentaryManager>();
            services.AddScoped<IBreadCrumbManager, BreadCrumbManager>();
            services.AddScoped<ICounterManager, CounterManager>();
            services.AddScoped<ILinkManager, LinkManager>();
        }
    }
}
