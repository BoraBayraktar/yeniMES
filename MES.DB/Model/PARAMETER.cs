using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("PARAMETER")]
    public partial class PARAMETER : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string MAIN_DATA_NAME { get; set; }

        [StringLength(50)]
        public string DESCRIPTION { get; set; }

        public int? PRIORITY_ORDER { get; set; }

        public bool IS_ACTIVE { get; set; }

        public int PARAMETER_TYPE_ID { get; set; }
        public int MAIN_PROCESS_ID { get; set; }

        public int? PARENT_PARAMETER_ID { get; set; }


        [ForeignKey("PARAMETER_TYPE_ID")]
        public virtual PARAMETER_TYPE PARAMETER_TYPE { get; set; }
        [ForeignKey("MAIN_PROCESS_ID")]
        public virtual MAIN_PROCESS MAIN_PROCESS { get; set; }

        [ForeignKey("PARENT_PARAMETER_ID")]
        public virtual PARAMETER PARENT_PARAMETER { get; set; }
    }
}
