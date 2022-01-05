using AutoMapper;
using BL.Helpers;
using BL.IServices;
using BL.Mappings.AutoMapper;
using BL.Services;
using BL.ValidationRules;
using Blazor_UI.Data;
using DAL;
using DAL.UnitOfWork;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using UI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<VideoApiRequests>();
builder.Services.AddScoped<PresentationApiRequests>();
builder.Services.AddScoped<LinkApiRequests>();
builder.Services.AddScoped<DocumentaryApiRequests>();
builder.Services.AddScoped<CounterApiRequests>();
builder.Services.AddScoped<BreadCrumbApiRequests>();
builder.Services.AddScoped<AdvertisementApiRequests>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
