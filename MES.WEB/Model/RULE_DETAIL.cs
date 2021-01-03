using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("RULE_DETAIL")]
    public partial class RULE_DETAIL : BASE
    {
        [Key]
        public int RULE_DETAIL_ID { get; set; }

        [StringLength(50)]
        public string CRITERIA { get; set; }
        [StringLength(50)]
        public string VALUE { get; set; }
        [StringLength(50)]
        public string REQUIREMENT { get; set; }
        [StringLength(50)]
        public string CONDITION { get; set; }

        public int RULE_ID { get; set; }

        [ForeignKey("RULE_ID")]
        public virtual RULE RULE { get; set; }

    }
}
