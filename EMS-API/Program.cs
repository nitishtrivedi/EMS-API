using EMS_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("GLEmsDB");
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});



var app = builder.Build();





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
