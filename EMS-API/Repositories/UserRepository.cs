using EMS_API.Data;
using EMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user ?? throw new Exception("User Not Found");
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> EditAsync(UserModel user, int id)
        {
            if (id != user.Id) return false;
            var existingUser = await _dbContext.Users.FindAsync(id);
            if (existingUser == null) return false;

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.Name = user.Name;
            existingUser.PhoneNumber = user.PhoneNumber;

            _dbContext.Entry(existingUser).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return false;
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
    }
}
