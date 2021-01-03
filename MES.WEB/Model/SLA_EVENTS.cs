using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("SLA_EVENTS")]
    public partial class SLA_EVENTS : BASE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int SLA_ID { get; set; }
        [Required]
        public int EVENT_ID { get; set; }
        [Required]
        public int STATUS_ID { get; set; }

        [ForeignKey("SLA_ID")]
        public virtual SLA SLA_MODEL { get; set; }
        [ForeignKey("STATUS_ID")]
        public virtual PARAMETER STATUS_MODEL { get; set; }



    }
}
