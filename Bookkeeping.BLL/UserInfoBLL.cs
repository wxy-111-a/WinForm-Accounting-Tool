using Bookkeeping.DAL;
using Bookkeeping.Model;

namespace Bookkeeping.BLL
{
    /// <summary>
    /// 用户信息业务逻辑类
    /// </summary>
    public class UserInfoBLL
    {
        private readonly UserInfoDAL _userInfoDAL = new UserInfoDAL();

        /// <summary>
        /// 用户登录逻辑
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>成功则返回 UserInfo 对象，失败则返回 null</returns>
        public UserInfo Login(string userName, string password)
        {
            // 业务逻辑检查：用户名和密码不能为空
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            // 调用 DAL 层进行数据验证
            return _userInfoDAL.GetUserByLogin(userName, password);
        }
    }
}