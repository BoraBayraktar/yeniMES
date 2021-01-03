using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("WORKING_SCHEDULE")]
    public partial class WORKING_SCHEDULE : BASE
    {
        [Key]
        public int WORKING_SCHEDULE_ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }
        public TimeSpan START_TIME { get; set; }
        public TimeSpan END_TIME { get; set; }
        public bool ISACTIVE { get; set; }
    }
}
