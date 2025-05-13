using EMS_API.Models;

namespace EMS_API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<bool> EditUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
