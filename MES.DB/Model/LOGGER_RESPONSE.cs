using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.DB.Model
{
    [Table("LOGGER_RESPONSE")]
    public class LOGGER_RESPONSE
    {
        [Key]
        public int ID { get; set; }
        public int REQUEST_ID { get; set; }

        [StringLength(50)]
        public string CONTROLLER { get; set; }
        [StringLength(50)]
        public string PATH { get; set; }
        [StringLength(50)]
        public string METHOD { get; set; }
        public int USER_ID { get; set; }
        public DateTime DATE { get; set; }
        public string JSONDATA { get; set; }
        
    }
}
