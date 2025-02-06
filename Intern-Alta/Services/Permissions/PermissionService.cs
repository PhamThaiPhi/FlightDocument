using Intern_Alta.Data;
using Intern_Alta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intern_Alta.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly MyDbContext _context;

        public PermissionService(MyDbContext context)
        {
            _context = context;
        }

    
        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }


        public Permission GetPermissionById(int id)
        {
            return _context.Permissions.FirstOrDefault(p => p.PermissionID == id);
        }

   
        public Permission CreatePermission(PerModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            var newPermission = new Permission
            {
                PermissionName = model.PermissionName,
                RoleID = model.RoleID
            };

            _context.Permissions.Add(newPermission);
            _context.SaveChanges();

            return newPermission;
        }


        public Permission UpdatePermission(int id, PerModel permission)
        {
            var existingPermission = _context.Permissions.Find(id);

            if (existingPermission == null)
            {
                throw new Exception("Permission not found");
            }

            existingPermission.PermissionName = permission.PermissionName;
            existingPermission.RoleID = permission.RoleID;

            _context.SaveChanges();

            return existingPermission;
        }

  
        public bool DeletePermission(int id)
        {
            var permissionToDelete = _context.Permissions.Find(id);

            if (permissionToDelete == null)
            {
                throw new Exception("Permission not found");
            }

            _context.Permissions.Remove(permissionToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}