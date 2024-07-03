using Microsoft.EntityFrameworkCore;
using Serilog;
using ShareRegister.API.AppConfigurationExtensions;
using ShareRegister.Data;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
Serilog.Log.Logger = logger;
logger.Information("Starting Share Register API...");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShareRegister"));
});

builder.Services.AddMediator();
builder.Services.AddDependencyInjectionModules();
builder.Services.AddAutoMapperConfigs();    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

logger.Information("Share Register API started!");
