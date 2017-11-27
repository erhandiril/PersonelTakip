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
  public class LaborLog    //çalışma logu
    {
        public DateTime StartShift { get; set; } = DateTime.Now; //insert ettiğim an girmişimdir
        public DateTime? EndShift { get; set; }

        [Required]
        public string UserId { get; set; }  //applicationuser da string UserId

        [ForeignKey("UserId")]
        public virtual AplicationUser User { get; set; }
    }
}
