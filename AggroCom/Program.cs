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
using AggroCom.Services.Foundations.News;
using AggroCom.Services.Foundations.Photos;
using AggroCom.Services.Foundations.Contacts;
using Microsoft.AspNetCore.Hosting;
using AggroCom.Services.Foundations.Katalogs;
using Microsoft.AspNetCore.Http.Features;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Max request body size for large file uploads (e.g. video, images)
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Limits.MaxRequestBodySize = 200 * 1024 * 1024; // 200MB
        });

        // Set limit for file upload in the form
        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 200 * 1024 * 1024; // 200MB
        });

        builder.Services.AddControllers();

        // Add services (Brokers, Foundations, Orchestrations)
        BrokersMethods(builder);
        FoundationsServicesMethod(builder);
        OrchestrationMethods(builder);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Enable CORS for all origins (including Netlify and others)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()  // Barcha manbalar uchun ochiq
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });

            // CORS policy for Netlify frontend specifically
            options.AddPolicy("AllowNetlify", policy =>
            {
                policy.WithOrigins("https://greensayt.netlify.app")  // Netlify frontend URL
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // Use static files for serving resources like images or CSS
        app.UseStaticFiles();

        // Use Swagger for API documentation in development and production environments
        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Forward headers if behind a reverse proxy like Nginx or load balancer
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        // Ensure all requests are redirected to HTTPS
        app.UseHttpsRedirection();

        // Apply CORS policies for API
        app.UseCors("AllowAll");  // Allow all origins
        app.UseCors("AllowNetlify");  // Allow Netlify frontend

        // Enable authorization middleware (if required)
        app.UseAuthorization();

        // Map controllers to handle API requests
        app.MapControllers();

        // Run the application
        app.Run();
    }

    // Add orchestrations services
    private static void OrchestrationMethods(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProductOneTableOneOrchestrationService,
            ProductOneTableOneOrchestrationService>();

        builder.Services.AddTransient<IProductTwoTableTwoOrchestrationService,
            ProductTwoTableTwoOrchestrationService>();

        builder.Services.AddTransient<IProductOneProcessingService,
            ProductOneProcessingService>();

        builder.Services.AddTransient<IProductTwoProcessingService,
            ProductTwoProcessingService>();
    }

    // Add foundation services
    private static void FoundationsServicesMethod(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProductOneService, ProductOneService>();
        builder.Services.AddTransient<IProductTwoService, ProductTwoService>();
        builder.Services.AddTransient<ITableOneService, TableOneService>();
        builder.Services.AddTransient<ITableTwoService, TableTwoService>();
        builder.Services.AddTransient<INewsService, NewsService>();
        builder.Services.AddTransient<IPhotoService, PhotoService>();
        builder.Services.AddTransient<IContactService, ContactService>();
        builder.Services.AddTransient<IKatalogService, KatalogService>();
    }

    // Add brokers services
    private static void BrokersMethods(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    }
}

