using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ConsimpleTestTask.Api;

public static class BaseServicesExtension
{
    public static void AddBaseServices(this IServiceCollection services)
    {
        // Add API controllers
        services.AddControllers()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
        
        // Swagger settings
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(GetSwaggerGenOptions);
    }

    private static void GetSwaggerGenOptions(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Consimple API",
            Description = "Consimple APIs"
        });
        
        string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string presentationXmlFile = "ConsimpleTestTask.Presentation.xml";
        string applicationDtoXmlFile = "ConsimpleTestTask.Application.Dto.xml";
        
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, presentationXmlFile));
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, applicationDtoXmlFile));
    }
}