using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("WORKING_DAYS")]
    public partial class WORKING_DAYS : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }

    }
}
