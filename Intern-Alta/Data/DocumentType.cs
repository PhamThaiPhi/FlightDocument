using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("DocumentTypes")]
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; } // Khóa chính cho loại tài liệu

        [Required]
        [StringLength(100)]
        public string TypeName { get; set; } // Tên loại tài liệu

        

        public virtual ICollection<Document>? Documents { get; set; }

    }
}