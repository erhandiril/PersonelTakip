using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(PT.WEB.MVC.App_Start.Startup1))]

namespace PT.WEB.MVC.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",   //
                LoginPath = new PathString("/Account/Login") ///eğer bunu yapmazsak hata sayfası çıkar site çalışmaz
            });
        }
    }
}
