using Bookkeeping.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic; // 确保已引用

namespace Bookkeeping.DAL
{
    /// <summary>
    /// 交易记录数据访问类
    /// </summary>
    public class TransactionDAL
    {
        /// <summary>
        /// 添加一笔新的交易记录（包含事务处理）
        /// </summary>
        /// <param name="transaction">交易实体</param>
        /// <param name="categoryType">分类类型 ('收入' 或 '支出')</param>
        /// <returns>操作是否成功</returns>
        public bool AddTransaction(Transaction transaction, string categoryType)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                // 启动事务
                SqlTransaction sqlTrans = conn.BeginTransaction();
                try
                {
                    // 1. 插入交易记录
                    string sqlInsert = @"INSERT INTO Transactions (Amount, TransactionDate, Description, CategoryID, AccountID, UserID) 
                                         VALUES (@Amount, @TransactionDate, @Description, @CategoryID, @AccountID, @UserID)";
                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn, sqlTrans);
                    cmdInsert.Parameters.AddWithValue("@Amount", transaction.Amount);
                    cmdInsert.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                    cmdInsert.Parameters.AddWithValue("@Description", transaction.Description);
                    cmdInsert.Parameters.AddWithValue("@CategoryID", transaction.CategoryID);
                    cmdInsert.Parameters.AddWithValue("@AccountID", transaction.AccountID);
                    cmdInsert.Parameters.AddWithValue("@UserID", transaction.UserID);
                    cmdInsert.ExecuteNonQuery();

                    // 2. 更新账户余额
                    decimal amountToUpdate = categoryType == "收入" ? transaction.Amount : -transaction.Amount;
                    AccountDAL accountDAL = new AccountDAL();
                    accountDAL.UpdateBalance(transaction.AccountID, amountToUpdate, sqlTrans);

                    // 如果以上都成功，提交事务
                    sqlTrans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    // 如果任何一步出错，回滚事务
                    sqlTrans.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 根据日期范围获取交易明细视图
        /// </summary>
        public List<TransactionView> GetTransactionViews(DateTime startDate, DateTime endDate, int userId)
        {
            List<TransactionView> list = new List<TransactionView>();
            string sql = @"
        SELECT 
            t.TransactionID,
            t.TransactionDate,
            c.Type,
            c.CategoryName,
            t.Amount,
            a.AccountName,
            t.Description,
            t.CategoryID,
            t.AccountID
        FROM Transactions t
        JOIN Categories c ON t.CategoryID = c.CategoryID
        JOIN Accounts a ON t.AccountID = a.AccountID
        WHERE t.UserID = @UserID AND t.TransactionDate BETWEEN @StartDate AND @EndDate
        ORDER BY t.TransactionDate DESC, t.TransactionID DESC";

            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TransactionView()
                        {
                            TransactionID = (int)reader["TransactionID"],
                            TransactionDate = (DateTime)reader["TransactionDate"],
                            Type = reader["Type"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            Amount = (decimal)reader["Amount"],
                            AccountName = reader["AccountName"].ToString(),
                            Description = reader["Description"].ToString(),
                            CategoryID = (int)reader["CategoryID"],
                            AccountID = (int)reader["AccountID"]
                        });
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 删除一笔交易（包含事务处理，需要返还或扣除账户金额）
        /// </summary>
        public bool DeleteTransaction(int transactionId)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction sqlTrans = conn.BeginTransaction();
                try
                {
                    // 1. 先获取这笔交易的金额、账户ID和类型
                    string querySql = @"
                SELECT t.Amount, t.AccountID, c.Type 
                FROM Transactions t 
                JOIN Categories c ON t.CategoryID = c.CategoryID 
                WHERE t.TransactionID = @TransactionID";
                    SqlCommand queryCmd = new SqlCommand(querySql, conn, sqlTrans);
                    queryCmd.Parameters.AddWithValue("@TransactionID", transactionId);

                    decimal amount = 0;
                    int accountId = 0;
                    string type = "";

                    using (SqlDataReader reader = queryCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            amount = (decimal)reader["Amount"];
                            accountId = (int)reader["AccountID"];
                            type = reader["Type"].ToString();
                        }
                        else
                        {
                            // 如果找不到交易，则无法继续
                            sqlTrans.Rollback();
                            return false;
                        }
                    }

                    // 2. 更新账户余额（与记账时相反的操作）
                    decimal amountToUpdate = type == "收入" ? -amount : amount;
                    AccountDAL accountDAL = new AccountDAL();
                    accountDAL.UpdateBalance(accountId, amountToUpdate, sqlTrans);

                    // 3. 删除交易记录
                    string deleteSql = "DELETE FROM Transactions WHERE TransactionID = @TransactionID";
                    SqlCommand deleteCmd = new SqlCommand(deleteSql, conn, sqlTrans);
                    deleteCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                    deleteCmd.ExecuteNonQuery();

                    sqlTrans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    sqlTrans.Rollback();
                    return false;
                }
            }
        }


    }
}