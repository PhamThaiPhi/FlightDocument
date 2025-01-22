using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class ConfigModel
    {
        [Required]
        [StringLength(100)]
        public string ConfigName { get; set; }

        public string ConfigValue { get; set; }
        public int DocumentTypeID { get; set; }

        public int PermissionID { get; set; }
    }
}
