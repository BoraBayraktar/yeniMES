using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("EMAIL_TEMPLATE_PARAMETERS")]
    public partial class EMAIL_TEMPLATE_PARAMETERS
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string PARAMETER { get; set; }

        public int MAIN_PROCESS_ID { get; set; }
        [ForeignKey("MAIN_PROCESS_ID")]
        public virtual MAIN_PROCESS MAIN_PROCESS { get; set; }
    }
}
