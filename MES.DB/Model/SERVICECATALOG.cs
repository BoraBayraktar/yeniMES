using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.DB.Model
{
    [Table("SERVICECATALOG")]
    public partial class SERVICECATALOG : BASE
    {
        [Key]
        public int SERVICE_ID { get; set; }

        [StringLength(100)]
        public string SERVICE_NAME { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string DESCRIPTION { get; set; }
       
        [Required]
        public int SERVICE_PARAMETER_ID { get; set; }

        public int SERVICE_LEVEL { get; set; }

        public int OPERATIONAL_STATUS_ID { get; set; }

        public int SERVICE_MANAGER_IT_ID { get; set; }

        public int SERVICE_MANAGER_BUSINESS_ID { get; set; }

        [ForeignKey("SERVICE_PARAMETER_ID")]
        public virtual PARAMETER PARAMETERMODEL { get; set; }

        [ForeignKey("OPERATIONAL_STATUS_ID")]
        public virtual PARAMETER PARAMETER_OPSTATUSMODEL { get; set; }

        [ForeignKey("SERVICE_MANAGER_IT_ID")]
        public virtual USER USER_MANAGERITMODEL { get; set; }

        [ForeignKey("SERVICE_MANAGER_BUSINESS_ID")]
        public virtual USER USER_MANAGERBUSINESSMODEL { get; set; }


    }
}
