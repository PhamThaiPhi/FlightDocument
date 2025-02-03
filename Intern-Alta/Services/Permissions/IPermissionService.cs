using Intern_Alta.Data;
using Intern_Alta.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intern_Alta.Services.Permissions
{
    public interface IPermissionService
    {
        // Lấy tất cả quyền
        List<Permission> GetAllPermissions();

        // Lấy thông tin quyền theo ID
        Permission GetPermissionById(int id);

        // Tạo mới một quyền
        Permission CreatePermission(PerModel model);

        // Cập nhật quyền theo ID
        Permission UpdatePermission(int id, PerModel permission);

        // Xóa quyền theo ID
        bool DeletePermission(int id);
    }
}