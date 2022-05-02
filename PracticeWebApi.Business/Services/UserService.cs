using PracticeWebApi.Business.Models;
using PracticeWebApi.Data.Repositories;

namespace PracticeWebApi.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public List<User> GetUsers()
        {
            var users = _userRepo.GetAllUsers();
            List<User> usersList = new List<User>();

            foreach (var user in users)
            {
                usersList.Add(new User
                {
                    UserId = user.UserId,
                    BirthDate = user.BirthDate,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }

            return usersList;
        }

        public User GetUserById(int userId)
        {
            var user = _userRepo.GetUserByUserId(userId);

            return new User
            {
                UserId=user.UserId,
                BirthDate=user.BirthDate,
                FirstName=user.FirstName,
                LastName=user.LastName
            };

        }

        public User AddNewUser(User userInfo)
        {
            var entityUser = new Data.Entities.User
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                BirthDate = userInfo.BirthDate
            };

            var newUser = _userRepo.AddUser(entityUser);

            return new User
            {
                UserId = newUser.UserId,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                BirthDate = newUser.BirthDate,
            };
        }

        public User UpdateUser(User userInfo)
        {
            var entityUser = new Data.Entities.User
            {
                UserId = userInfo.UserId,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                BirthDate = userInfo.BirthDate
            };

            var updatedUser = _userRepo.UpdateUser(entityUser);

            return new User
            {
                UserId = updatedUser.UserId,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                BirthDate = updatedUser.BirthDate,
            };
        }

        public void DeleteUser(int userId)
        {
            _userRepo.DeleteUser(userId);
        }
    }
}
