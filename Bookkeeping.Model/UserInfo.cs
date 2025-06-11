namespace Bookkeeping.Model
{
    /// <summary>
    /// 用户信息实体类
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户ID (主键)
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码 (按要求明文存储)
        /// </summary>
        public string Password { get; set; }
    }
}