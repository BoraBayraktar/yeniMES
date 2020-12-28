using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("RULE")]
    public partial class RULE : BASE
    {
        [Key]
        public int RULE_ID { get; set; }
        [StringLength(100)]
        public string RULE_NAME { get; set; }
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string RULE_DESCRIPTION { get; set; }
        public int MAIN_PROCESS_ID { get; set; }
        public int RULE_ACTION_TYPE { get; set; } //1-Form Oluşturulduğunda,2-Form Güncellendiğinde
        public string RULE_ACTION { get; set; }
        public string RULE_ACTION_DATA { get; set; }
    }
}
