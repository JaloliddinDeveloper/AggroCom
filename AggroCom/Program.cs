// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using Microsoft.AspNetCore.HttpOverrides;
using AggroCom.Brokers.Storages;
using AggroCom.Services.Foundations.ProductOnes;
using AggroCom.Services.Foundations.TableOnes;
using AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AggroCom.Services.Processings.ProductOnes;
using AggroCom.Services.Foundations.ProductTwos;
using AggroCom.Services.Foundations.TableTwos;
using AggroCom.Services.Orchestrations.ProductTwoTableTwoOrchestrations;
using AggroCom.Services.Processings.ProductTwos;
using Microsoft.AspNetCore.Http.Features;
using AggroCom.Services.Foundations.News;
using AggroCom.Services.Foundations.Photos;
using AggroCom.Services.Foundations.Contacts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using AggroCom.Services.Foundations.Katalogs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Limits.MaxRequestBodySize = 524288000; 
        });

        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 52428800;
        });

        builder.Services.AddControllers();

        builder.Services.AddTransient<IStorageBroker, StorageBroker>();//0
        builder.Services.AddTransient<IProductOneService, ProductOneService>();//1
        builder.Services.AddTransient<IProductTwoService, ProductTwoService>();//2
        builder.Services.AddTransient<ITableOneService, TableOneService>();//1
        builder.Services.AddTransient<ITableTwoService, TableTwoService>();//2
        builder.Services.AddTransient<INewsService, NewsService>();
        builder.Services.AddTransient<IPhotoService, PhotoService>();
        builder.Services.AddTransient<IContactService, ContactService>();
        builder.Services.AddTransient<IKatalogService, KatalogService>();


        builder.Services.AddTransient<IProductOneTableOneOrchestrationService,
            ProductOneTableOneOrchestrationService>(); 
        
        builder.Services.AddTransient<IProductTwoTableTwoOrchestrationService,
            ProductTwoTableTwoOrchestrationService>();

        builder.Services.AddTransient<IProductOneProcessingService,
            ProductOneProcessingService>();
        
        builder.Services.AddTransient<IProductTwoProcessingService,
            ProductTwoProcessingService>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {

            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        app.UseStaticFiles();

        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
            RequestPath = "/files"
        });

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
