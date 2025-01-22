using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; } 

        [Required]
        [StringLength(100)]
        public string PermissionName { get; set; } 

        public int? RoleID { get; set; } 

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } 

        public virtual ICollection<ConfigDB>? Configurations { get; set; }
    }
}