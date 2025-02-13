using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

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

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now; 
    }
}