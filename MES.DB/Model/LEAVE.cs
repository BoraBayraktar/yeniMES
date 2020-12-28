using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("LEAVE")]
    public partial class LEAVE : BASE
    {
        [Key]
        public int LEAVE_ID { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        [StringLength(100)]
        public string DESCRIPTION { get; set; }
        public int LEAVE_TYPE_ID { get; set; }
        public int TOTAL_DAY { get; set; }

        public int USER_ID { get; set; }


        [ForeignKey("LEAVE_TYPE_ID")]
        public virtual LEAVE_TYPE LEAVE_TYPE { get; set; }

        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; }
    }
}
