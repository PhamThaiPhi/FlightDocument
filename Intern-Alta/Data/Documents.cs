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
        public int DocumentID { get; set; } // Khóa chính cho tài liệu

        [Required]
        [StringLength(255)]
        public string   Title { get; set; } // Tiêu đề tài liệu

        public DateTime UploadedAt { get; set; } = DateTime.Now; // Ngày tải lên

        public int? UserID { get; set; } // Khóa ngoại đến bảng Users (có thể null)

        public int DocumentTypeID { get; set; } // Thuộc tính lưu khóa ngoại 

        [ForeignKey("DocumentTypeID")]
        public DocumentType DocumentType { get; set; } // Khóa ngoại liên kết đến bảng DocumentTypes
    }
}