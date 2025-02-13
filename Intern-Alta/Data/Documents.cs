using Intern_Alta.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Document
{
    [Key]
    public int DocumentID { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    public DateTime? UploadedAt { get; set; } = DateTime.Now;
    public int? UserID { get; set; }

    public int FlightsID { get; set; }

    [ForeignKey("FlightsID")]
    public virtual Flight Flight { get; set; }

    public int DocumentTypeID { get; set; }

    [ForeignKey("DocumentTypeID")]
    public DocumentType DocumentType { get; set; }
}
