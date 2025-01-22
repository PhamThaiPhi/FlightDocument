using System.ComponentModel.DataAnnotations;

namespace Intern_Alta.Models
{
    public class DocModel
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; } 

        public DateTime? UploadedAt { get; set; } = DateTime.Now; 

        public int DocumentTypeID { get; set; } 
    }
}
