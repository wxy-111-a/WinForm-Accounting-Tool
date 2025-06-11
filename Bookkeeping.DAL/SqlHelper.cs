using System.Configuration;
using System.Data.SqlClient;

namespace Bookkeeping.DAL
{
    /// <summary>
    /// SQL 数据库操作帮助类
    /// </summary>
    public static class SqlHelper
    {
        // 从 App.config 文件中读取连接字符串
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

        /// <summary>
        /// 获取一个数据库连接对象
        /// </summary>
        /// <returns>SqlConnection 对象</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}