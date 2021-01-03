using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.Web.Model
{
    [Table("USER")]
    public partial class USER : BASE
    {
        [Key]
        public int USER_ID { get; set; }

        [StringLength(50)]
        public string USERNAME { get; set; }
        [StringLength(50)]
        public string PASSWORD { get; set; }
        [StringLength(50)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string SURNAME { get; set; }
        [StringLength(50)]
        public string EMAIL { get; set; }
        [StringLength(100)]
        public string DESCRIPTION { get; set; }
		public bool? ISLDAP { get; set; }

		public int? DEPARTMENT_ID { get; set; }
        public int? TITLE_ID { get; set; }
        public int? USER_TYPE_ID { get; set; }
        public int? LOCATION_ID { get; set; }

        public int? MANAGER_ID { get; set; }

        public int? USER_GROUP_ID { get; set; }
        [StringLength(200)]
        public string IMAGE_PATH { get; set; }
        [Required]
        public bool USER_ISACTIVE { get; set; }

        [ForeignKey("DEPARTMENT_ID")]
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        [ForeignKey("TITLE_ID")]
        public virtual TITLE TITLE { get; set; }
        [ForeignKey("USER_TYPE_ID")]
        public virtual USER_TYPE USER_TYPE { get; set; }
        [ForeignKey("LOCATION_ID")]
        public virtual LOCATION LOCATION { get; set; }
        [ForeignKey("USER_GROUP_ID")]
        public virtual USER_GROUP USER_GROUP { get; set; }


        [NotMapped]
        public string USER_TYPE_NAME { 
            get 
            {
                if (USER_TYPE!= null)
                    return USER_TYPE.NAME;
                return null;
            } 
        }        
        [NotMapped]
        public string DEPARTMENT_NAME { 
            get 
            {
                if (DEPARTMENT != null)
                    return DEPARTMENT.NAME;
                return null;
            } 
        }        
        [NotMapped]
        public string TITLE_NAME { 
            get 
            {
                if (TITLE != null)
                    return TITLE.NAME;
                return null;
            } 
        }        
        [NotMapped]
        public string LOCATION_NAME { 
            get 
            {
                if (LOCATION != null)
                    return LOCATION.NAME;
                return null;
            } 
        }

    }
}
