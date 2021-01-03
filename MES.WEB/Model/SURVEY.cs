using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("SURVEY")]
    public partial class SURVEY : BASE
    {
        [Key]
        public int SURVEY_ID { get; set; }

        [StringLength(100)]
        public string SURVEY_NAME { get; set; }
        public int? SURVEY_SEND_TYPE_ID { get; set; } //1-Tek Seferlik, 2-Sürekli

        public int? MAIN_PROCESS_ID { get; set; }

        public int? SURVEY_PARAMETER_ID { get; set; }

        [ForeignKey("SURVEY_PARAMETER_ID")]
        public virtual PARAMETER PARAMETER { get; set; }

        public DateTime? START_DATE { get; set; }
        public DateTime? EXECUTION_DATE { get; set; }

        [StringLength(150)]
        public string TO_USERS { get; set; }
        [StringLength(150)]
        public string TO_GROUPS { get; set; }

        public bool? TO_CREATED_USER { get; set; }
        public bool? TO_ASSIGNED_USER { get; set; }
        public bool? TO_ASSIGNED_GROUP_USER { get; set; }
    }
}
