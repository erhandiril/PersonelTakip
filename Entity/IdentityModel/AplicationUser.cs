using Entity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdentityModel
{
    public class AplicationUser : IdentityUser
    {
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(35)]
        public string Surname { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }

        public string ActivationCode { get; set; }   //mail göndermek için

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual List<LaborLog> LaborLogs { get; set; } = new List<LaborLog>();  //bir kullanıcının birden fazla girişi olabilir ya da girişi olmayabilir

        public virtual List<SalaryLog> SalaryLogs { get; set; } = new List<SalaryLog>();  //constraction açmamak için burada newlewdik.  5 tane list yazdığında 5 tane constraction yazmak zorundaydık bu şekilde değiliz
    }
}
