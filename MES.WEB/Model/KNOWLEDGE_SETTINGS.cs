using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("KNOWLEDGE_SETTINGS")]
    public partial class KNOWLEDGE_SETTINGS : BASE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int WHICH_STATUS_IN_VISIBLE { get; set; }
        [ForeignKey("WHICH_STATUS_IN_VISIBLE")]
        public virtual PARAMETER STATUS_MODEL { get; set; }


    }
}
