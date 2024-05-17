using Api.Extensions;
using Api.GlobalException;
using Application.Models.Configurations;
using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.DependencyInjection;
using Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructureServices()
    .AddPersistenceRepositories();


builder.Services.AddAuthenticationAndAuthorization(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
var cosmos = new CosmosConfiguration();
builder.Configuration.GetSection("Cosmos").Bind(cosmos);
builder.Services.Configure<BlobStorageConfiguration>(builder.Configuration.GetSection("BlobStorage"));
builder.Services.AddDbContext<AppDbContext>(op => op.UseCosmos(cosmos.Uri, cosmos.Key, cosmos.DatabaseName));

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/Applicationlog-txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler("/err");

app.UseAuthorization();

app.MapControllers();

app.Run();
