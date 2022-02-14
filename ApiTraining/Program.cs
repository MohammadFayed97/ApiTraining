using Abstractions;
using ApiTraining.Extensions;
using NLog;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.RegisterRepositoryManger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureApplicationMiddlewares(builder.Environment, builder.Services.BuildServiceProvider().GetService<ILoggerManager>());

app.Run();
