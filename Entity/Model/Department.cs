using Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    [Table("Department")]
   public class Department:BaseModel
    {
        [Required]    //nul girilebiliyor o yüzden yazdık
        [StringLength(55,ErrorMessage ="Bu alan zorunludur", MinimumLength =5)]
        [Index(IsUnique =true)]

        public string DepartmentName { get; set; }

        public virtual List<AplicationUser> Users { get; set; } = new List<AplicationUser>();
    }
}
