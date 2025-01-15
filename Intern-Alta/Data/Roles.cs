using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; } // Khóa chính cho vai trò

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } // Tên vai trò

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}