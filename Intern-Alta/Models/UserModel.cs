using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class UserModel
    {
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
    }
}
