using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("INCIDENT_HISTORY")]

    public partial class INCIDENT_HISTORY : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(100)]
        public string SUBJECT { get; set; }
        [StringLength(250)]
        public string DESCRIPTION { get; set; }
        public int? REPORTING_USER_ID { get; set; }

        public int? INCIDENT_PRIORITY_ID { get; set; }

        public int? INCIDENT_STATUS_ID { get; set; }


        public int? SERVICE_CATALOG_ID { get; set; }
        public int? CATEGORY_ID { get; set; }
        public int? SUB_CATEGORY_ID { get; set; }
        public int? INCIDENT_URGENCY_ID { get; set; }
        public int? INCIDENT_IMPACT_ID { get; set; }
        public int? INCIDENT_TYPE_ID { get; set; }
        public int? INCIDENT_SOURCE_ID { get; set; }
        public int? ASSIGNED_GROUP_ID { get; set; }
        public int? ASSIGNED_USER_ID { get; set; }

        public int INCIDENT_ID { get; set; }

        public bool VISIBLE_TO_USER { get; set; }
        public bool VISIBLE_TO_OPERATOR { get; set; }


        public int? EFFORT_DAY { get; set; }
        public int? EFFORT_HOUR { get; set; }
        public int? EFFORT_MINUTE { get; set; }

        public int? CREATED_USER_ID { get; set; }
        public int? UPDATED_USER_ID { get; set; }




        [ForeignKey("INCIDENT_ID")]
        public INCIDENT INCIDENT { get; set; }


        [ForeignKey("SERVICE_CATALOG_ID")]
        public SERVICECATALOG SERVICE_CATALOG { get; set; }
        [ForeignKey("CATEGORY_ID")]
        public PARAMETER CATEGORY { get; set; }
        [ForeignKey("SUB_CATEGORY_ID")]
        public PARAMETER SUB_CATEGORY { get; set; }
        [ForeignKey("INCIDENT_URGENCY_ID")]
        public PARAMETER INCIDENT_URGENCY { get; set; }
        [ForeignKey("INCIDENT_IMPACT_ID")]
        public PARAMETER INCIDENT_IMPACT { get; set; }
        [ForeignKey("INCIDENT_TYPE_ID")]
        public PARAMETER INCIDENT_TYPE { get; set; }
        [ForeignKey("INCIDENT_SOURCE_ID")]
        public PARAMETER INCIDENT_SOURCE { get; set; }
        [ForeignKey("ASSIGNED_GROUP_ID")]
        public GROUP ASSIGNED_GROUP { get; set; }
        [ForeignKey("ASSIGNED_USER_ID")]
        public USER ASSIGNED_USER { get; set; }




        [ForeignKey("INCIDENT_PRIORITY_ID")]
        public PARAMETER INCIDENT_PRIORITY { get; set; }

        [ForeignKey("REPORTING_USER_ID")]
        public USER REPORTING_USER { get; set; }

        [ForeignKey("INCIDENT_STATUS_ID")]
        public PARAMETER INCIDENT_STATUS { get; set; }

        [ForeignKey("CREATED_USER_ID")]
        public USER CREATED_USER { get; set; }
        [ForeignKey("UPDATED_USER_ID")]
        public USER UPDATED_USER { get; set; }
    }
}
