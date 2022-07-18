using Microsoft.AspNetCore.Mvc;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NetCore.Web.Models;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        // Interface에서 Service를 사용하기 위해 Service class 인스턴스를 받아온다.
        // private IUser _user = new UserService();
        
        // 의존성 주입 방식으로 전환, 닷넷코어에서 기본적으로 제공하는 의존성 주입 방식인
        // 생성자 주입방식
        private IUser _user;

        /// <summary>
        /// 생성자 주입방식은 생성자의 파라미터를 통해 인터페이스를 지정하여 서비스클래스 인스턴스를 받아온다.
        /// </summary>
        public MembershipController(IUser user)
        {
            _user = user;
        }
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
        // Data => Services => Web
        // Data => Services
        // Data => Web 이로 인해서 Data의 경우 따로 참조추가 하지않고 사용가능하다.
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;

            if(ModelState.IsValid) // ID나 PWD를 입력했다면.
            {
                // 뷰모델
                // 서비스 개념
                // Services 프로젝트 구성
                // (1) 서비스의 재사용성
                // (2) 모듈화를 통한 효율적 관리
                if(_user.MathTheUserInfo(login))
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
