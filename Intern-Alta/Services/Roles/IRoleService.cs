using Intern_Alta.Data;
using Intern_Alta.Models;

namespace Intern_Alta.Services.Roles
{
    public interface IRoleService
    {
        List<Role> GetRoles();

        Role GetRoleByID (int id);

        Role CreateRole (RoleModel model);
        Role UpdateRole (int id, RoleModel role);
        bool DeleteRole(int id);
    }
}
