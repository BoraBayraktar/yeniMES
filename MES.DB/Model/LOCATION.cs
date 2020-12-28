using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("LOCATION")]
    public partial class LOCATION : BASE
    {
        [Key]
        public int LOCATION_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        public int CITY_ID { get; set; }

        [ForeignKey("CITY_ID")]
        public virtual CITY CITY { get; set; }
        
    }
}
