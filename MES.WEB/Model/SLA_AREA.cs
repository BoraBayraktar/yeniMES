using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("SLA_AREA")]
    public partial class SLA_AREA : BASE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int SLA_ID { get; set; }
        [Required]
        public int SLA_AREA_TYPE_ID { get; set; }
        [StringLength(150)]
        public string CUSTOMER_ID { get; set; }
        [StringLength(150)]
        public string SERVICE_ID { get; set; }
        [StringLength(150)]
        public string ASSET_ID { get; set; }

        [ForeignKey("SLA_ID")]
        public virtual SLA SLA_MODEL { get; set; }
    }
}
