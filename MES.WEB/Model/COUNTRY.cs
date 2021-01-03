using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("COUNTRY")]
    public partial class COUNTRY : BASE
    {
        [Key]
        public int COUNTRY_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
    }
}
