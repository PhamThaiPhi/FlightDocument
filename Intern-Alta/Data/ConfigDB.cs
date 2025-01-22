using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Configuration")]
    public class ConfigDB
    {
        [Key]
        public int ConfigID { get; set; }

        [Required]
        [StringLength(100)]
        public string ConfigName { get; set; }

        public string ConfigValue { get; set; }
        public int DocumentTypeID { get; set; }
        [ForeignKey("DocumentTypeID")]
        public DocumentType DocumentType { get; set; }

        public int PermissionID { get; set; }
        [ForeignKey("PermissionID")]
        public Permission Permission { get; set; }
    }
}