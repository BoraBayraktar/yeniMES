using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("TIME_MANAGEMENT_OFFDAYS")]
    public partial class TIME_MANAGEMENT_OFFDAYS : BASE
    {
        [Key]
        public int ID { get; set; }
        public int YEAR { get; set; }
        [StringLength(100)]
        public string DESCRIPTION { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public int OFF_DAY { get; set; }

        public int TIME_MANAGEMENT_ID { get; set; }

        [ForeignKey("TIME_MANAGEMENT_ID")]
        public virtual TIME_MANAGEMENT TIME_MANAGEMENT { get; set; }
    }
}
