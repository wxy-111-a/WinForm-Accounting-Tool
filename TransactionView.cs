// Bookkeeping.Model/TransactionView.cs
using System;

namespace Bookkeeping.Model
{
    /// <summary>
    /// 用于在UI层显示交易明细的视图模型
    /// </summary>
    public class TransactionView
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; } // '收入' 或 '支出'
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }

        // 隐藏原始ID，方便更新和删除
        public int CategoryID { get; set; }
        public int AccountID { get; set; }
    }
}