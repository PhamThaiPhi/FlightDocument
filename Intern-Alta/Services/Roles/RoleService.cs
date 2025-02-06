using Intern_Alta.Data;
using Intern_Alta.Models;

namespace Intern_Alta.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly MyDbContext _context;

        public RoleService(MyDbContext context)
        {
            _context = context;
        }
        public List<Role> GetRoles() 
        {
            return _context.Roles
                .Select(d => new Role
                {
                    RoleID = d.RoleID,
                    RoleName = d.RoleName,
                })
                .ToList();
        }
        public Role GetRoleByID(int id)
        {
            return _context.Roles.FirstOrDefault(u => u.RoleID == id);
        }

        public Role CreateRole(RoleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            var newRole = new Role
            {
                RoleName = model.RoleName,
                

            };

            _context.Roles.Add(newRole);
            _context.SaveChanges();

            return newRole;
        }

        public Role UpdateRole(int id, RoleModel role)
        {
            var existingUser = _context.Roles.Find(id);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.RoleName = role.RoleName;
           


            _context.SaveChanges();

            return existingUser;
        }

        public bool DeleteRole(int id)
        {
            var userToDelete = _context.Roles.Find(id);

            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }

            _context.Roles.Remove(userToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}
