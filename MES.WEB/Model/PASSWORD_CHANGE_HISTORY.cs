using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("PASSWORD_CHANGE_HISTORY")]
    public partial class PASSWORD_CHANGE_HISTORY:BASE
    {
        [Key]
        public int ID { get; set; }
        public Guid UNIQUE_IDENTIFIER { get; set; }
        public DateTime? CHANGE_DATE { get; set; }
        public int USER_ID { get; set; }

        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; }
    }
}
