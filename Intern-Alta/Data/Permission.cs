using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; } // Khóa chính cho quyền

        [Required]
        [StringLength(100)]
        public string PermissionName { get; set; } // Tên quyền

        public int? RoleID { get; set; } // Khóa ngoại đến bảng Roles (có thể null)

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } // Tham chiếu đến bảng Roles
    }
}