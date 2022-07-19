using MedfeesSolution.Models;
using MedfeesSolution.Repository;
using MedfeesSolution.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;


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
builder.Services.AddTransient<UsersInterface, UsersRepository>();

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

//public static class CustomExtensionMethods
//{
//    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
//    {
//        services.AddEntityFrameworkNpgsql()
//            .AddDbContext<messages_dbContext>(options =>
//            {
//                options.UseNpgsql("Name=MessagesDB",
//                                     npgsqlOptionsAction: sqlOptions =>
//                                     {
//                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
//                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), null);
//                                     });
//            });
//        return services;
//    }

// }
