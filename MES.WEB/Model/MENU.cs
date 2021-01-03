using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("MENU")]
    public class MENU
    {
        public MENU()
        {
            this.USERTYPE_MENUS = new HashSet<USERTYPE_MENU>();
        }
        [Key]
        public int MENU_ID { get; set; }
        [StringLength(100)]
        public string MENU_NAME { get; set; }
        [StringLength(50)]
        public string CONTROLLER { get; set; }
        [StringLength(50)]
        public string ACTION { get; set; }
        [StringLength(150)]
        public string MENU_LINK { get; set; }

        [StringLength(50)]
        public string MENU_ICON { get; set; }
        [StringLength(100)]
        public string PAGE_TITLE { get; set; }
        [StringLength(100)]
        public string PAGE_SUBTITLE { get; set; }
        public bool MENU_SHOW { get; set; }
        public int? MENU_SORT { get; set; }

        public int? TOPMENU_ID { get; set; }

        [ForeignKey("TOPMENU_ID")]
        public virtual MENU TOPMENU { get; set; }
        public virtual ICollection<MENU> SUBMENULIST { get; set; }
        public virtual ICollection<USERTYPE_MENU> USERTYPE_MENUS { get; set; }
    }
}
