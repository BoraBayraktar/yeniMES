using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("TIME_MANAGEMENT")]
    public partial class TIME_MANAGEMENT : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string CALENDAR_NAME { get; set; }
        [StringLength(150)]
        public string CALENDAR_DAYS { get; set; }
        [StringLength(150)]
        public string BUSINESS_HOURS { get; set; }

        public int? TIMEZONE_ID { get; set; }

        public bool ISACTIVE { get; set; }

        [ForeignKey("TIMEZONE_ID")]
        public virtual TIMEZONE TIMEZONE { get; set; }

    }
}
