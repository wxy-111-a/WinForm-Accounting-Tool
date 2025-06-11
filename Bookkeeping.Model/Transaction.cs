using System;

namespace Bookkeeping.Model
{
    /// <summary>
    /// 交易记录实体类
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// 交易ID (主键)
        /// </summary>
        public int TransactionID { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 分类ID (外键)
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 账户ID (外键)
        /// </summary>
        public int AccountID { get; set; }

        /// <summary>
        /// 用户ID (外键)
        /// </summary>
        public int UserID { get; set; }
    }
}