using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("SLA")]
    public partial class SLA : BASE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string NAME { get; set; }
        [Required]
        public string TYPE { get; set; }
        [Required]
        public int MAIN_PROCESS_ID { get; set; }
        [Required]
        public int IMPORTANCE_LEVEL_ID { get; set; }
        [Required]
        public int WORKING_SCHEDULE_ID { get; set; }        
        public int EFFORT_MINUTE { get; set; }
        public int EFFORT_HOUR { get; set; }
        public int EFFORT_DAY { get; set; }
        //[Required]
        //public int STARTED_STATUS_ID { get; set; }
        //[Required]
        //public int STOPED_STATUS_ID { get; set; }
        //[Required]
        //public int FINISHED_STATUS_ID { get; set; }

        [ForeignKey("MAIN_PROCESS_ID")]
        public virtual MAIN_PROCESS MAIN_PROCESS_MODEL { get; set; }

        [ForeignKey("IMPORTANCE_LEVEL_ID")]
        public virtual PARAMETER IMPORTANCE_LEVEL_MODEL { get; set; }

        [ForeignKey("WORKING_SCHEDULE_ID")]
        public virtual WORKING_SCHEDULE WORKING_SCHEDULE_MODEL { get; set; }

        //[ForeignKey("STARTED_STATUS_ID")]
        //public virtual PARAMETER STARTED_STATUS_MODEL { get; set; }

        //[ForeignKey("STOPED_STATUS_ID")]
        //public virtual PARAMETER STOPED_STATUS_MODEL { get; set; }

        //[ForeignKey("FINISHED_STATUS_ID")]
        //public virtual PARAMETER FINISHED_STATUS_MODEL { get; set; }      

    }
}
