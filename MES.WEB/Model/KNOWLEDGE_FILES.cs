using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("KNOWLEDGE_FILES")]
    public partial class KNOWLEDGE_FILES : BASE
    {
        [Key]
        public int ID { get; set; }
        [StringLength(150)]
        public string FILE_PATH { get; set; }
        public int KNOWLEDGE_ID { get; set; }
        public string FILE_NAME { get; set; }
        [ForeignKey("KNOWLEDGE_ID")]
        public virtual KNOWLEDGE_MANAGEMENT KNOWLEDGE { get; set; }        
    }
}
