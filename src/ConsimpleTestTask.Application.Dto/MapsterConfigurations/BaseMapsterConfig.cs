namespace ConsimpleTestTask.Application.Dto.MapsterConfigurations;

public static class BaseMapsterConfig
{
    public static void Configure()
    {
        ClientMapsterConfig.Configure();
    }
}