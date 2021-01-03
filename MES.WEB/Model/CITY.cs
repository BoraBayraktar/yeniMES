using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("CITY")]
    public partial class CITY : BASE
    {
        [Key]
        public int CITY_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        public int REGION_ID { get; set; }

        [ForeignKey("REGION_ID")]
        public virtual REGION REGION { get; set; }
    }
}
