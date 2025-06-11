using System;

namespace Bookkeeping.Model
{
    /// <summary>
    /// 资金账户实体类
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 账户ID (主键)
        /// </summary>
        public int AccountID { get; set; }

        /// <summary>
        /// 账户名称 (例如: 现金, 支付宝)
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balance { get; set; }
    }
}