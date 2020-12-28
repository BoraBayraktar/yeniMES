using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    [Table("USER_TYPE")]
    public partial class USER_TYPE : BASE
    {
        public USER_TYPE()
        {
            this.USERTYPE_MENUS = new HashSet<USERTYPE_MENU>();
        }
        [Key]
        public int USER_TYPE_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }

        public virtual ICollection<USERTYPE_MENU> USERTYPE_MENUS { get; set; }
    }
}
