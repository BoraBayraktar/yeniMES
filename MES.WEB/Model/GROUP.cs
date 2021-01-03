using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("GROUP")]
    public partial class GROUP : BASE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string GROUP_NAME { get; set; }
        [Required]
        public int GROUP_MANAGER_ID { get; set; }
        [Required]
        public int GROUP_TYPE_ID { get; set; }
        [Required]
        [StringLength(150)]
        public string BUSINESS_HOURS { get; set; }
        [Required]
        public int GROUP_ASSIGNTYPE_ID { get; set; } // 1 Sıralı Atama, 2 İş Yüküne Göre Atama, 3 Atama Yok
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string GROUP_DESCRIPTION { get; set; }
        [Required]
        public bool GROUP_ISACTIVE { get; set; }
        [ForeignKey("GROUP_MANAGER_ID")]
        public virtual USER GROUP_USERMANAGERMODEL { get; set; }
        [ForeignKey("GROUP_TYPE_ID")]
        public virtual GROUP_TYPE GROUP_GROUPTYPEMODEL { get; set; }
    }
}