using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("LEAVE_TYPE")]
    public partial class LEAVE_TYPE : BASE
    {
        [Key]
        public int LEAVE_TYPE_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
    }
}
