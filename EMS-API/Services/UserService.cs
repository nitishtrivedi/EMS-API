using EMS_API.Models;
using EMS_API.Repositories;

namespace EMS_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<UserModel> AddUser(UserModel user) => await _userRepository.AddAsync(user);

        public async Task<bool> DeleteUser(int id) => await _userRepository.DeleteAsync(id);

        public async Task<bool> EditUser(UserModel user, int id) => await _userRepository.EditAsync(user, id);

        public async Task<IEnumerable<UserModel>> GetAllUsers() => await _userRepository.GetAllAsync();

        public async Task<UserModel> GetUserById(int id) => await _userRepository.GetByIdAsync(id);
    }
}
