using HasanDemirtasBitirmeProjesi.Admin.Models;
using HasanDemirtasBitirmeProjesi.Business.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace HasanDemirtasBitirmeProjesi.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly AdminManager _adminManager;

        public LoginController()
        {
            _adminManager = new AdminManager();
        }
        public IActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            bool result = _adminManager.Login(model.Email, model.Password);
            if (result)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("LoginPage", "Login");
            }
           
        }
    }
}
