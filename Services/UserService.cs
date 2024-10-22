using VineriaAPI.Models;
using VineriaAPI.Repository;

namespace VineriaAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(user);
        }
    }

}
