using MedfeesSolution.Models;
using MedfeesSolution.Repository;
using MedfeesSolution.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using MedfeesSolution.MappingConfigurations;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<medfesContext>(options =>{
    options.UseNpgsql("Name=MedfesDB",
                         npgsqlOptionsAction: sqlOptions =>
                         {
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), null);
                         });
});
var automapper = new MapperConfiguration(item => item.AddProfile(new MapperConfig()));
IMapper mapper=automapper.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<UsersInterface, UsersRepository>();
builder.Services.AddTransient<LoginInterface,LoginRepository>();
builder.Services.AddTransient<CountryInterface, CountryRepository>();
builder.Services.AddTransient<StateInterface, StateRepository>();
builder.Services.AddTransient<CityInterface, CityRepository>();
builder.Services.AddTransient<HospitalInterface, HospitalRepository>();
builder.Services.AddTransient<StaffInterface, StaffRepository>();
builder.Services.AddTransient<DoctorsInterface, DoctorsRepository>();

builder.Services.AddTransient<ErrorLogRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medfes API's"));

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials()
      .SetIsOriginAllowed(origin=>true));

//app.UseForwardedHeaders();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

