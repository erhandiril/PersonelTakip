using Entity.IdentityModel;
using Microsoft.AspNet.Identity;
using PT.BL.AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;

namespace PT.WEB.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()   //formun ilk yüklendiği yer


        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var roleManager = MemberShipTools.NewRoleManager();

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Admin",
                    Description = "System yöneticisi"
                });
            }

            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "User",
                    Description = "System kullanıcı"
                });
            }
            if (!roleManager.RoleExists("Passive"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Passive",
                    Description = "E-mail aktivasyon gerekli"
                });
            }
        }
    }
}


