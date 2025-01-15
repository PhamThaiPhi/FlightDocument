using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Configuration")]
    public class Configuration
    {
        [Key]
        public int ConfigID { get; set; } // Khóa chính cho cấu hình

        [Required]
        [StringLength(100)]
        public string ConfigName { get; set; } // Tên cấu hình

        public string ConfigValue { get; set; } // Giá trị của cấu hình

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày tạo
    }
}