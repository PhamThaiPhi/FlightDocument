using Intern_Alta.Data;
using Intern_Alta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intern_Alta.Services.Users
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                .Select(d => new User
                {
                    UserID = d.UserID,
                    Username = d.Username,
                    Password = d.Password,
                    Email = d.Email,
                    RoleID = d.RoleID,
                    Role = d.Role 
                })
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }

        public User CreateUser(UserModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                RoleID = model.RoleID,
               
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public User UpdateUser(int id, UserModel user)
        {
            var existingUser = _context.Users.Find(id);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
           

            _context.SaveChanges();

            return existingUser;
        }

        public bool DeleteUser(int id)
        {
            var userToDelete = _context.Users.Find(id);

            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}