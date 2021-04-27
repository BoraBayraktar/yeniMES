using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("KNOWLEDGE_MANAGEMENT")]
    public partial class KNOWLEDGE_MANAGEMENT : BASE
    {
        [Key]
        public int ID { get; set; }
        public string KNOWLEDGE_NO { get; set; }
        public bool IS_ACTIVE { get; set; }
        public bool KNOWLEDGE_ISACTIVE { get; set; }
        [Required]
        [StringLength(200)]
        public string SUBJECT { get; set; }
        [Required]
        public int KNOWLEDGE_SERVICE_ID { get; set; }
        [Required]
        public int KNOWLEDGE_CATEGORY_ID { get; set; }
        [Required]
        public int KNOWLEDGE_STATUS_ID { get; set; }
        [DataType(DataType.MultilineText)]
        public string KNOWLEDGE_DESCRIPTION { get; set; }
        public int? CREATED_USER_ID { get; set; }

        public int? UPDATED_USER_ID { get; set; }



        [ForeignKey("KNOWLEDGE_SERVICE_ID")]
        public virtual SERVICECATALOG SERVICE_MODEL { get; set; }

        [ForeignKey("KNOWLEDGE_STATUS_ID")]
        public virtual PARAMETER STATUS_MODEL { get; set; }

        [ForeignKey("KNOWLEDGE_CATEGORY_ID")]
        public virtual PARAMETER CATEGORY_MODEL { get; set; }

        [ForeignKey("CREATED_USER_ID")]
        public virtual USER CREATED_USER { get; set; }

        [ForeignKey("UPDATED_USER_ID")]
        public USER UPDATED_USER { get; set; }
    }
}
