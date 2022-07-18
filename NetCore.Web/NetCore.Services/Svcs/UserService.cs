using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Svcs는 서비스 클래스들의 모음 약자.
namespace NetCore.Services.Svcs
{
    #region private methods
    public class UserService : IUser
    {
        private IEnumerable<User> GetUserInfos()
        {
            return new List<User>()
            {
                new User()
                {
                    UserId   = "rlaudtjstn",
                    UserName = "손기명",
                    UserEmail = "rlaudtjstn@gmail.com",
                    Password = "123456"
                }
            };
        }

        private bool checkTheUserInfo(string userId, string password)
        {
            return GetUserInfos().Where(u => u.UserId.Equals(userId) && u.Password.Equals(password)).Any(); // Any() 메서드: 리스트 데이터 유무체크
        }
        #endregion

        // 인터페이스에 묶여있으므로 접근제한자 사용 불가능.
        bool IUser.MathTheUserInfo(LoginInfo login)
        {
            return checkTheUserInfo(login.UserId, login.Password);
        }
    }
    
}
