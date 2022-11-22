using AutoStore.WebUI.Infrastructure.Abstract;
using AutoStore.WebUI.Models;
using System.Web.Mvc;

namespace AutoStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider provider)
        {
            authProvider = provider;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Login or password is not correct");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}