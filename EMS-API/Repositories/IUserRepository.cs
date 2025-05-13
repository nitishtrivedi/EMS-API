using EMS_API.Models;

namespace EMS_API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> AddAsync(UserModel user);
        Task<bool> EditAsync(UserModel user, int id);
        Task<bool> DeleteAsync(int id);
    }
}
