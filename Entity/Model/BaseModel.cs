using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
   public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
