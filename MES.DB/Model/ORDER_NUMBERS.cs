using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.DB.Model
{
    [Table("ORDER_NUMBERS")]
    public partial class ORDER_NUMBERS : BASE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MAIN_PROCESS_ID { get; set; }
        [Required]
        public string SYSTEM_CODE { get; set; }
        [Required]
        [StringLength(4)]
        public string CODE { get; set; }
        [Required]
        public int LAST_COUNTER { get; set; }
        public string LAST_ORDER_NUMBER { get; set; }
        [Required]
        [StringLength(7)]
        public string ID_FORMAT_CODE { get; set; }
        public bool IS_ACTIVE { get; set; }
        [ForeignKey("MAIN_PROCESS_ID")]
        public virtual MAIN_PROCESS MAINPROCESS_MODEL { get; set; }
    }
}
