using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("COMPANY")]
    public partial class COMPANY : BASE
    {
        [Key]
        public int COMPANY_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string DESCRIPTION { get; set; }
        public int HOLDING_ID { get; set; }


        [ForeignKey("HOLDING_ID")]
        public virtual HOLDING HOLDING { get; set; }
  
    }
}
