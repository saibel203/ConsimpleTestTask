using ConsimpleTestTask.Api;
using ConsimpleTestTask.Application.Dto;
using ConsimpleTestTask.Contracts.PersistenceAbstractions;
using ConsimpleTestTask.Infrastructure;
using ConsimpleTestTask.Persistence;
using ConsimpleTestTask.Services;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddApplicationDtoServices();
builder.Services.AddServices();
builder.Services.AddBaseServices();

WebApplication app = builder.Build();
IWebHostEnvironment environment = app.Environment;

if (environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.DisplayRequestDuration(); });

    using IServiceScope scope = app.Services.CreateScope();

    IInitializeDbContext initializeDbContext =
        scope.ServiceProvider.GetRequiredService<IInitializeDbContext>();
    await initializeDbContext.InitializeDatabaseAsync();
    await initializeDbContext.SeedDatabaseAsync();
}
else
{
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

app.Run();
