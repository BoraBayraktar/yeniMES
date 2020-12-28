using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("INCIDENT_FILES")]
    public partial class INCIDENT_FILES
    {
        [Key]
        public int ID { get; set; }
        [StringLength(150)]
        public string FILE_PATH { get; set; }

        public int INCIDENT_ID { get; set; }

        [ForeignKey("INCIDENT_ID")]
        public virtual INCIDENT INCIDENT { get; set; }
    }
}
