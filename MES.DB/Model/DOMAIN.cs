using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("DOMAIN")]
    public partial class DOMAIN : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string NAME { get; set; }
    }
}
