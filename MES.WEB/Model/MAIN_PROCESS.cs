using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("MAIN_PROCESS")]
    public partial class MAIN_PROCESS : BASE
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string SHORT_CODE { get; set; }
        public int DOMAIN_ID { get; set; }


        [ForeignKey("DOMAIN_ID")]
        public virtual DOMAIN DOMAIN { get; set; }

    }
}
