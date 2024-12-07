using Data.Entities;
using Data.Repository;
using Services.DTOs;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        private readonly List<User> _users = new();

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(UserDTO userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Mail = userDto.Mail,
                Password = userDto.Password
            };
            _users.Add(user);
        }

        public User? GetUserByMail(string mail) => _users.FirstOrDefault(u => u.Mail == mail);

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public User? AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        //public User? AuthenticateUser(string username, string password)
        //{
        //    var user = _userRepository.GetUserByUsername(username);
        //    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        //    {
        //        return user;
        //    }
        //    return null;
        //}
    }

}
