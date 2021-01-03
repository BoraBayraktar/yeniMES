using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("PARAMETER_TYPE")]
    public partial class PARAMETER_TYPE : BASE
    {
        [Key]
        public int PARAMETER_TYPE_ID { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }

        [StringLength(50)]
        public string TYPE_NAME { get; set; }

        public int? MAIN_PROCESS_ID { get; set; }


        [ForeignKey("MAIN_PROCESS_ID")]
        public virtual MAIN_PROCESS MAIN_PROCESS { get; set; }
    }
}
