using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("USER_GROUP")]
    public partial class USER_GROUP : BASE
    {
        [Key]
        public int USER_GROUP_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
    }
}
