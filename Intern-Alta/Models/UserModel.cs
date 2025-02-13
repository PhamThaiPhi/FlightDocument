using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; } 

        [Required]
        [StringLength(255)]
        public string Password { get; set; } 

        [Required]
        [StringLength(255)]
        public string Email { get; set; } 

        public int? RoleID { get; set; } 
    }
}
