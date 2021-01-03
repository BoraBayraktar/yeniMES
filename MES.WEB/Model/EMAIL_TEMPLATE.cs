using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("EMAIL_TEMPLATE")]
    public partial class EMAIL_TEMPLATE : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }
        [StringLength(100)]
        public string SUBJECT { get; set; }
        public string BODY { get; set; }
        public bool? TO_CREATED_USER { get; set; }
        public bool? TO_ASSIGNED_USER { get; set; }
        public bool? TO_ASSIGNED_GROUP_USER { get; set; }

        [StringLength(150)]
        public string TO_USERS { get; set; }
        [StringLength(150)]
        public string TO_GROUPS { get; set; }

        [NotMapped]
        public string Recipients { get; set; }

        [NotMapped]
        public string MAIN_PROCESS_STATUS { get; set; }


        public int MAIN_PROCESS_ID { get; set; }
        public int MAIN_PROCESS_STATUS_ID { get; set; }

        [ForeignKey("MAIN_PROCESS_ID")]
        public virtual MAIN_PROCESS MAIN_PROCESS { get; set; }
    }
}
