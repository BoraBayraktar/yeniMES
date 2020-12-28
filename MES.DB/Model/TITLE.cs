using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.DB.Model
{
    [Table("TITLE")]
    public partial class TITLE : BASE
    {
        [Key]
        public int TITLE_ID { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string DESCRIPTION { get; set; }
    }
}
