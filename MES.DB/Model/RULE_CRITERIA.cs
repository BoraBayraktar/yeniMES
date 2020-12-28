using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("RULE_CRITERIA")]
    public partial class RULE_CRITERIA
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        public string CODE { get; set; }
        [StringLength(100)]
        public string DESCRIPTION { get; set; }
        public bool IS_FOREIGN { get; set; }
        [StringLength(50)]
        public string FOREIGN_TABLE_NAME { get; set; }
        [StringLength(50)]
        public string FOREIGN_KEY { get; set; }
        [StringLength(50)]
        public string FOREIGN_VALUE { get; set; }
        [StringLength(100)]
        public string FOREIGN_WHERE_CLAUSE { get; set; }
    }
}
