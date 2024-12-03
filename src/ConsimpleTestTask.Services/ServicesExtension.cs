using ConsimpleTestTask.Contracts.ServiceAbstractions;
using ConsimpleTestTask.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsimpleTestTask.Services;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<IPurchaseService, PurchaseService>();
    }
}