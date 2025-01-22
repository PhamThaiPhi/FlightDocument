using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        public int DocumentID { get; set; } 

        [Required]
        [StringLength(255)]
        public string   Title { get; set; } 

        public DateTime? UploadedAt { get; set; } = DateTime.Now;
        public int? UserID { get; set; } 

        public int DocumentTypeID { get; set; }
        

        [ForeignKey("DocumentTypeID")]
        public DocumentType DocumentType { get; set; }
       
    }
}