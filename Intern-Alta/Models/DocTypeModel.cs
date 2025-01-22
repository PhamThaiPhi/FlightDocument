using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class DocTypeModel
    {
        [Required]
        public string TypeName { get; set; }
    }
}
