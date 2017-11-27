using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BL.Repository
{
    public class DepartmentRepo : RepositoryBase<Department, int> { }
    public class SalaryRepo : RepositoryBase<SalaryLog, int> { }
    public class LaborLogRepo : RepositoryBase<LaborLog, int> { }


}
