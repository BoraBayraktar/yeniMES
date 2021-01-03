using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("SURVEY_HISTORY")]

    public class SURVEY_HISTORY : BASE
    {
        [Key]
        public int ID { get; set; }
        public int SURVEY_ID { get; set; }
        public Guid UNIQUE_ID { get; set; }
        public int USER_ID { get; set; }
    }
}
