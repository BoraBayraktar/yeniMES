using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("INCIDENT_PRIORITY")]
    public partial class INCIDENT_PRIORITY
    {
        [Key]
        public int PRIORITY_ID { get; set; }
        [StringLength(100)]
        public string DESCRIPTION { get; set; }
    }
}
