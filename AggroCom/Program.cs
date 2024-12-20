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

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddTransient<IStorageBroker, StorageBroker>();//0
        builder.Services.AddTransient<IProductOneService, ProductOneService>();//1
        builder.Services.AddTransient<IProductTwoService, ProductTwoService>();//2
        builder.Services.AddTransient<ITableOneService, TableOneService>();//1
        builder.Services.AddTransient<ITableTwoService, TableTwoService>();//2

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
