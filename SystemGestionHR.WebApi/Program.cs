using SystemGestionHR.WebApi;
using SystemGestionHR.Data;
using Microsoft.EntityFrameworkCore;
using SystemGestionHR.Services;
using SystemGestionHR.Services.UseCases;
using SystemGestionHR.Services.Interfaces;
using SystemGestionHR.Data.Repositories;
using SystemGestionHR.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigureService.RegisterServices(builder.Services);
ConfigureService.RegisterMappers(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<EmployeDB>(
                       options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<SoumettreDemandeDeCongeUseCase>();
builder.Services.AddScoped<GererDemandeDeCongeUseCase>();
builder.Services.AddScoped<IDemandeDeCongeRepository, DemandeDeCongeRepository>();
builder.Services.AddScoped<IEmployeRepository, EmployeRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITypeCongeRepository, TypeCongeRepository>();
builder.Services.AddScoped<IDemandeDeCongeService, DemandeDeCongeService>();
builder.Services.AddScoped<IEmployeService, EmployeService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITypeCongeService, TypeCongeService>();

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

