using Entity.IdentityModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PT.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BL.AccountRepository
{
   public class MemberShipTools
    {
        public static UserStore<AplicationUser> NewUserStore() => new UserStore<AplicationUser>(new MyContext());

        public static UserManager<AplicationUser> NewUserManager() => new UserManager<AplicationUser>(NewUserStore());

        public static RoleStore<ApplicationRole> NewRoleStore() => new RoleStore<ApplicationRole>(new MyContext());

        public static RoleManager<ApplicationRole> NewRoleManager() => new RoleManager<ApplicationRole>(NewRoleStore());
    }
}
