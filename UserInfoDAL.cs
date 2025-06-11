using Bookkeeping.Model;
using System.Data;
using System.Data.SqlClient;

namespace Bookkeeping.DAL
{
    /// <summary>
    /// 用户信息数据访问类
    /// </summary>
    public class UserInfoDAL
    {
        /// <summary>
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>如果找到则返回 UserInfo 对象，否则返回 null</returns>
        public UserInfo GetUserByLogin(string userName, string password)
        {
            UserInfo user = null;
            string sql = "SELECT UserID, UserName, Password FROM UserInfo WHERE UserName = @UserName AND Password = @Password";

            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password); // 明文密码比对

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserInfo();
                        user.UserID = (int)reader["UserID"];
                        user.UserName = reader["UserName"].ToString();
                        user.Password = reader["Password"].ToString();
                    }
                }
            }
            return user;
        }
    }
}