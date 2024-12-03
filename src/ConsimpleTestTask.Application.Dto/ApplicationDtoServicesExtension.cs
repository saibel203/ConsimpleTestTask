using ConsimpleTestTask.Application.Dto.MapsterConfigurations;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace ConsimpleTestTask.Application.Dto;

public static class ApplicationDtoServicesExtension
{
    public static void AddApplicationDtoServices(this IServiceCollection services)
    {
        services.AddMapster();
        BaseMapsterConfig.Configure();
    }
}