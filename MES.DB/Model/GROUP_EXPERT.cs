using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.DB.Model
{
    [Table("GROUP_EXPERT")]
    public partial class GROUP_EXPERT : BASE
    {
        [Key]
        public int ID { get; set; }
        public int GROUP_ID { get; set; }
        public string EXPERT_NAME { get; set; }
        public int EXPERT_NAME_ID { get; set; }
        public string EXPERT_EMAIL { get; set; }
        [ForeignKey("GROUP_ID")]
        public virtual GROUP GROUP { get; set; }
    }
}
