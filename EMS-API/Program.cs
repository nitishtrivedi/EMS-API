using EMS_API.Data;
using EMS_API.Repositories;
using EMS_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("GLEmsDB");
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
