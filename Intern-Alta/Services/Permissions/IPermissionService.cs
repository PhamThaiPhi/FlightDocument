using Intern_Alta.Data;
using Intern_Alta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intern_Alta.Services.Permissions
{
    public interface IPermissionService
    {

        List<Permission> GetAllPermissions();


        Permission GetPermissionById(int id);


        Permission CreatePermission(PerModel model);


        Permission UpdatePermission(int id, PerModel permission);


        bool DeletePermission(int id);
    }
}