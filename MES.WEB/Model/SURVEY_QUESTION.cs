using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("SURVEY_QUESTION")]

    public class SURVEY_QUESTION : BASE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(150)]
        public string QUESTION_TEXT { get; set; }
        public int SURVEY_ANSWER_TYPE_ID { get; set; } //1-Değerlendirme , 2-İkili Cevap

        [StringLength(50)]
        public string EVALUATION_1 { get; set; }
        [StringLength(50)]
        public string EVALUATION_2 { get; set; }
        [StringLength(50)]
        public string EVALUATION_3 { get; set; }
        [StringLength(50)]
        public string EVALUATION_4 { get; set; }
        [StringLength(50)]
        public string EVALUATION_5 { get; set; }
        [StringLength(50)]
        public string BINARY_OPTION_1 { get; set; }
        [StringLength(50)]
        public string BINARY_OPTION_2 { get; set; }
        public int SURVEY_ID { get; set; }

        [ForeignKey("SURVEY_ID")]
        public virtual SURVEY SURVEY { get; set; }
    }
}
