using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("RULE_ACTIONS")]
    public partial class RULE_ACTIONS
    {
        [Key]
        public int ACTION_ID { get; set; }

        [StringLength(50)]
        public string ACTION_CODE { get; set; }
        [StringLength(50)]
        public string ACTION_NAME { get; set; }
    }
}
