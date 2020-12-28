using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("INCIDENT_TYPE")]

    public partial class INCIDENT_TYPE
    {
        [Key]
        public int INCIDENT_TYPE_ID { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }

        [StringLength(100)]
        public string DESCRIPTION { get; set; }

    }
}
