using Intern_Alta.Data;
using Intern_Alta.Models;
using System.Collections.Generic;

namespace Intern_Alta.Services.Users
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        User CreateUser(UserModel model);

        User UpdateUser(int id, UserModel user);

        bool DeleteUser(int id);
    }
}