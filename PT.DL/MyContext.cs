using Entity.IdentityModel;
using Entity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DL
{
   public class MyContext:IdentityDbContext<AplicationUser>
    {
        public MyContext()
            :base("name=MyCon")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.RequireUniqueEmail = true;
        }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<LaborLog> LaborLogs { get; set; }
        public virtual DbSet<SalaryLog> SalaryLogs { get; set; }
    }
}
