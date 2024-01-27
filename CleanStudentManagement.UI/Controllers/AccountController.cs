using CleanStudentManagement.BLL.Services;
using CleanStudentManagement.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc; 
using System.Text.Json;
using System.Security.Claims;

namespace CleanStudentManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountservice;

        public AccountController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                LoginViewModel vm = _accountservice.Login(model);
                if (vm != null)
                {
                    string sessionObj = JsonSerializer.Serialize(vm);
                    HttpContext.Session.SetString("loginDetails", sessionObj);

                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,model.UserName)
                };
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                        , new ClaimsPrincipal(claimsIdentity));

                    return RedirectToUser(vm);
                }
            }
            
            return View(model);
        }

        private IActionResult RedirectToUser(LoginViewModel vm)
        {
            if (vm.Role == (int)EnumRoles.Admin)
                return RedirectToAction("Index", "Users");
            else if (vm.Role == (int)EnumRoles.Teacher)
                return RedirectToAction("Index", "Exam");
            else
                return RedirectToAction("Profile", "Student");
        }
    }
}
