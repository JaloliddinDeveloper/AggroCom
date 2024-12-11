using AggroCom.Brokers.Storages;
using AggroCom.Services.Foundations.ProductOnes;
using AggroCom.Services.Foundations.TableOnes;
using AggroCom.Services.Orchestrations.ProductOneTableOneOrchestrationServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        RegisterServices(builder.Services);
        var app = builder.Build();
        ConfigureApp(app);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IStorageBroker, StorageBroker>();
        services.AddTransient<IProductOneService, ProductOneService>();
        services.AddTransient<ITableOneService, TableOneService>();
        services.AddTransient<IProductOneTableOneOrchestrationService, ProductOneTableOneOrchestrationService>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
