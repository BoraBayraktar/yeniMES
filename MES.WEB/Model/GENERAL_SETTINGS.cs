using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("GENERAL_SETTINGS")]
    public class GENERAL_SETTINGS
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        public string LOGIN_PAGE_BACKGROUND { get; set; }
        [StringLength(100)]
        public string LOGIN_PAGE_TEXT { get; set; }
        [StringLength(100)]
        public string LOGO { get; set; }
    }
}
