using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("INCIDENT_RESOLUTION")]
    public partial class INCIDENT_RESOLUTION : BASE
    {
        public int ID { get; set; }
        public int RESOLVED_CODE { get; set; }
        public string RESOLVED_DESCRIPTION { get; set; }
        public bool IS_APPROVED { get; set; }
        public DateTime? RESOLVED_DATE { get; set; }
        public int INCIDENT_ID { get; set; }

        [ForeignKey("INCIDENT_ID")]
        public virtual INCIDENT INCIDENT { get; set; }

    }
}
