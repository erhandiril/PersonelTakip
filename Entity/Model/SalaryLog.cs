using Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
   public class SalaryLog:BaseModel
    {
        public decimal Salary { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AplicationUser User { get; set; }
    }
}
