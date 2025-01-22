using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; } 

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } 
        
    }
}