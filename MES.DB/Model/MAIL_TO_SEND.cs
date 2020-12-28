using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("MAIL_TO_SEND")]
    public partial class MAIL_TO_SEND : BASE
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        public string TO_ADDRESS { get; set; }
        public string MAIL_SUBJECT { get; set; }
        public string MAIL_BODY { get; set; }
        public bool IS_SENT { get; set; } = false;

        public int? MAIN_PROCESS_ID { get; set; }
        public int? PARAMETER_ID { get; set; }
        public int? PARAMETER_TYPE_ID { get; set; }

    }
}
