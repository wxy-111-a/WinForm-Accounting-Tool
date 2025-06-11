using Bookkeeping.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Bookkeeping.DAL
{
    /// <summary>
    /// 资金账户数据访问类
    /// </summary>
    public class AccountDAL
    {
        /// <summary>
        /// 获取所有账户信息
        /// </summary>
        public List<Account> GetAllAccounts()
        {
            List<Account> list = new List<Account>();
            string sql = "SELECT AccountID, AccountName, Balance FROM Accounts ORDER BY AccountID";

            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Account()
                        {
                            AccountID = (int)reader["AccountID"],
                            AccountName = reader["AccountName"].ToString(),
                            Balance = (decimal)reader["Balance"]
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 添加一个新账户
        /// </summary>
        public int AddAccount(Account account)
        {
            string sql = "INSERT INTO Accounts (AccountName, Balance) VALUES (@AccountName, @Balance)";
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AccountName", account.AccountName);
                cmd.Parameters.AddWithValue("@Balance", account.Balance);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新一个已有账户
        /// </summary>
        public int UpdateAccount(Account account)
        {
            string sql = "UPDATE Accounts SET AccountName = @AccountName, Balance = @Balance WHERE AccountID = @AccountID";
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AccountName", account.AccountName);
                cmd.Parameters.AddWithValue("@Balance", account.Balance);
                cmd.Parameters.AddWithValue("@AccountID", account.AccountID);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 根据ID删除一个账户
        /// </summary>
        public int DeleteAccount(int accountId)
        {
            // 注意：实际项目中需要检查该账户是否已被交易记录使用
            string sql = "DELETE FROM Accounts WHERE AccountID = @AccountID";
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AccountID", accountId);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// (重要) 更新账户余额，使用事务确保数据一致性
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="amount">变动金额 (收入为正, 支出为负)</param>
        /// <param name="transaction">外部传入的数据库事务对象</param>
        public void UpdateBalance(int accountId, decimal amount, SqlTransaction transaction)
        {
            string sql = "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountID = @AccountID";
            // 命令需要使用事务关联的连接
            SqlCommand cmd = new SqlCommand(sql, transaction.Connection, transaction);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@AccountID", accountId);
            cmd.ExecuteNonQuery();
        }
    }
}