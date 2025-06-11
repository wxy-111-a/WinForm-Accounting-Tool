using Bookkeeping.DAL;
using Bookkeeping.Model;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Bookkeeping.BLL
{
    /// <summary>
    /// 交易记录业务逻辑类
    /// </summary>
    public class TransactionBLL
    {
        private readonly TransactionDAL _transactionDAL = new TransactionDAL();
        private readonly CategoryDAL _categoryDAL = new CategoryDAL(); // 需要用到CategoryDAL来获取分类类型

        /// <summary>
        /// 添加一笔新的交易
        /// </summary>
        /// <param name="transaction">交易实体</param>
        /// <returns>操作是否成功</returns>
        public bool AddTransaction(Transaction transaction)
        {
            // 业务逻辑检查：金额必须大于0
            if (transaction.Amount <= 0)
            {
                return false;
            }
            // 业务逻辑：根据 CategoryID 查找分类类型（收入/支出）
            var allCategories = _categoryDAL.GetAllCategories();
            var category = allCategories.FirstOrDefault(c => c.CategoryID == transaction.CategoryID);
            if (category == null)
            {
                // 如果找不到分类，则操作失败
                return false;
            }
            // 调用 DAL 层，并传入分类类型用于处理账户余额
            return _transactionDAL.AddTransaction(transaction, category.Type);
        }

        /// <summary>
        /// 获取交易视图列表
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="userId">用户ID</param>
        /// <returns>交易视图列表</returns>
        public List<TransactionView> GetTransactionViews(System.DateTime startDate, System.DateTime endDate, int userId)
        {
            return _transactionDAL.GetTransactionViews(startDate, endDate, userId);
        }

        /// <summary>
        /// 删除交易
        /// </summary>
        /// <param name="transactionId">交易ID</param>
        /// <returns>操作是否成功</returns>
        public bool DeleteTransaction(int transactionId)
        {
            // 这里可以添加更多业务逻辑，比如权限检查等
            return _transactionDAL.DeleteTransaction(transactionId);
        }

        // 此处可以添加更多业务方法，如
        // public List<TransactionView> GetTransactionDetails(...) { ... }
        // public bool UpdateTransaction(Transaction transaction) { ... }
    }
}