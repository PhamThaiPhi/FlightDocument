using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class RoleModel
    {
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
