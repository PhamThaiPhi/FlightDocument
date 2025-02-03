using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class PerModel
    {
        [Required]
        [StringLength(100)]
        public string PermissionName { get; set; }

        public int? RoleID { get; set; }
    }
}
