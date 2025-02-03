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

        // Lấy tất cả quyền
        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }

        // Lấy thông tin quyền theo ID
        public Permission GetPermissionById(int id)
        {
            return _context.Permissions.FirstOrDefault(p => p.PermissionID == id);
        }

        // Tạo mới một quyền
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

        // Cập nhật quyền theo ID
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

        // Xóa quyền theo ID
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