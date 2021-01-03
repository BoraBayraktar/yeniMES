using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("DEPARTMENT")]
    public partial class DEPARTMENT : BASE
    {
        [Key]
        public int DEPARTMENT_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string DESCRIPTION { get; set; }
        public int COMPANY_ID { get; set; }


        [ForeignKey("COMPANY_ID")]
        public virtual COMPANY COMPANY { get; set; }
    }
}
