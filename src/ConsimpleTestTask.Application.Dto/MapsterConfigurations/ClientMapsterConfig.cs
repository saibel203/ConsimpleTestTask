using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Domain.Model.Entities;
using Mapster;

namespace ConsimpleTestTask.Application.Dto.MapsterConfigurations;

public static class ClientMapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Client, ClientDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FullName, src => $"{src.LastName} {src.FirstName} {src.FatherName}");
    }
}