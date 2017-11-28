using Entity.IdentityModel;
using Entity.ViewModel;
using Microsoft.AspNet.Identity;
using PT.BL.AccountRepository;
using PT.BL.Settings;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PT.WEB.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //kayıt olmadan önce kontrol ediliyor
            if (!ModelState.IsValid)
                return View(model);
            var userManager = MemberShipTools.NewUserManager();
            var checkUser = userManager.FindByName(model.Username);
            if (checkUser!=null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı zaten kayıtlı");
                return View(model);

           
            }
            //register işlemi yapılır
            var activationCode = Guid.NewGuid().ToString();
            AplicationUser user = new AplicationUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                ActivationCode = activationCode
            };

            var response = userManager.Create(user, model.Password);
            if (response.Succeeded)
            {
                string siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);   //evladiyelik her yerde kullanabilirsin

                if (userManager.Users.Count()==1)  //ilk kullanıcıyı kaydettik
                {
                    userManager.AddToRole(user.Id, "Admin");
                   await SiteSettings.SendMail(new MailModel
                   {
                       To=user.Email,
                       Subject="Hoşgeldin Sahip",
                       Message="Sitemizi yöneteceğin için çok mutluyuz ^^"
                   });
                }
                else
                {
                    userManager.AddToRole(user.Id, "Passive");
                    await SiteSettings.SendMail(new MailModel
                    {
                        To = user.Email,
                        Subject = "Personel Yönetimi-Aktivasyon",
                        Message = $"Merhaba{user.Name}{user.Surname}<br/>Sistemi kullanabilmeniz için <a href='{siteUrl}/Account/Activation?code={activationCode}'>Aktivasyon Kodu</a>"  //dolar işareti koyunca süslü parantez gibi yazabiliriz. siteUrl yi yukarıda genel tanımladık
                    });
                }
                return RedirectToAction("Login", "Account");
               
            }
            else   //yukarıdaki if succeed in else i
            {
                ModelState.AddModelError(string.Empty, "Kayıt işleminde bir hata oluştu");
                return View(model);
            }

            
        }
    }
}