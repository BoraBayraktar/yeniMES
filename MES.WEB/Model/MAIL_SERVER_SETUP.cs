using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("MAIL_SERVER_SETUP")]
    public partial class MAIL_SERVER_SETUP : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string SMTP_HOST { get; set; }
        public int SMTP_PORT { get; set; }
        [StringLength(50)]
        public string USERNAME { get; set; }
        [StringLength(50)]
        public string PASSWORD { get; set; }
        [StringLength(50)]
        public string DEFAULT_ADDRESS { get; set; }
        [StringLength(50)]
        public string DEFAULT_NAME { get; set; }
        public int TRY_COUNT { get; set; }

    }
}
