using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("SURVEY_QUESTION_ANSWER")]

    public class SURVEY_QUESTION_ANSWER : BASE
    {
        [Key]
        public int ID { get; set; }

        public int SURVEY_QUESTION_ID { get; set; }

        public int SURVEY_HISTORY_ID { get; set; }

        [StringLength(50)]
        public string ANSWER { get; set; }


        [ForeignKey("SURVEY_QUESTION_ID")]
        public virtual SURVEY_QUESTION SURVEY_QUESTION { get; set; }

        [ForeignKey("SURVEY_HISTORY_ID")]
        public virtual SURVEY_HISTORY SURVEY_HISTORY { get; set; }

    }
}
