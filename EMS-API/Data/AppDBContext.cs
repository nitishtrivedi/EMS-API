using EMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_API.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }
    }

}
