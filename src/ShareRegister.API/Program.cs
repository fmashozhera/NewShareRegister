using Microsoft.EntityFrameworkCore;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Data;
using ShareRegister.Data.Common;
using ShareRegister.Domain.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShareRegister"));
});
builder.Services.AddScoped<IRepository<Company>, Repository<Company>>();
builder.Services.AddScoped<IRepository<Address>, Repository<Address>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWOrk>();
builder.Services.AddMediatR((config) => {
    config.RegisterServicesFromAssembly(typeof(ICommand).Assembly);
});

void action(MediatRServiceConfiguration obj)
{
    throw new NotImplementedException();
}

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
