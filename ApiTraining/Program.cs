using ApiTraining.Extensions;
using NLog;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureDbContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureApplicationMiddlewares(builder.Environment);

app.Run();
