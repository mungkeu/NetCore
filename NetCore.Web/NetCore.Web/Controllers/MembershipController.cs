using Microsoft.AspNetCore.Mvc;
using NetCore.Web.Models;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/{controller}/Login")]
        [ValidateAntiForgeryToken] // 위조방지토큰을 통해 View로 부터 받은 Post data가 유효한지 검증한다.
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;

            if(ModelState.IsValid) // ID나 PWD를 입력했다면.
            {
                string userId = "123456";
                string password = "123456";

                if(login.UserId.Equals(userId) && login.Password.Equals(password))
                {
                    TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";
                    return RedirectToAction("Index", "Membership");
                }
                else
                {
                    message = "로그인되지 않았습니다.";
                }
            }
            else
            {
                message = "로그인정보를 올바르게 입력하세요.";
            }
            ModelState.AddModelError(string.Empty, message);
            return View("Login",login);
        }
    }
}
