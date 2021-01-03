using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    [Table("HOLDING")]
    public partial class HOLDING : BASE
    {
        [Key]
        public int HOLDING_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string DESCRIPTION { get; set; }

        [ForeignKey("CUSTOMER_ID")]
        public virtual AD_CUSTOMERS AD_CUSTOMERS { get; set; }
        //ad_customers
    }
}
