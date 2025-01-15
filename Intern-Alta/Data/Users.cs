using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; } // Khóa chính cho người dùng

        [Required]
        [StringLength(255)]
        public string Username { get; set; } // Tên đăng nhập

        [Required]
        [StringLength(255)]
        public string Password { get; set; } // Mật khẩu

        [Required]
        [StringLength(255)]
        public string Email { get; set; } // Địa chỉ email

        public int? RoleID { get; set; } // Khóa ngoại đến bảng Roles (có thể null)

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } // Tham chiếu đến bảng Roles

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}