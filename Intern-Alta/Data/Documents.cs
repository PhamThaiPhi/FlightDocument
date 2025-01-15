using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Intern_Alta.Data
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        public int DocumentID { get; set; } // Khóa chính cho tài liệu

        [Required]
        [StringLength(255)]
        public string Title { get; set; } // Tiêu đề tài liệu

        public DateTime UploadedAt { get; set; } = DateTime.Now; // Ngày tải lên

        public int? UserID { get; set; } // Khóa ngoại đến bảng Users (có thể null)

        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; } // Khóa ngoại liên kết đến bảng DocumentTypes

        public virtual DocumentType? DocumentType { get; set; } // Tham chiếu đến bảng DocumentType
    }
}