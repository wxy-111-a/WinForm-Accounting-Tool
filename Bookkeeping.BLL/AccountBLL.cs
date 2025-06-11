using Bookkeeping.DAL;
using Bookkeeping.Model;
using System.Collections.Generic;

namespace Bookkeeping.BLL
{
    /// <summary>
    /// 资金账户业务逻辑类
    /// </summary>
    public class AccountBLL
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();

        /// <summary>
        /// 获取所有账户
        /// </summary>
        public List<Account> GetAllAccounts()
        {
            return _accountDAL.GetAllAccounts();
        }

        /// <summary>
        /// 添加新账户
        /// </summary>
        public bool AddAccount(Account account)
        {
            // 业务逻辑检查：账户名不能为空，初始余额不能为负
            if (string.IsNullOrWhiteSpace(account.AccountName) || account.Balance < 0)
            {
                return false;
            }
            return _accountDAL.AddAccount(account) > 0;
        }

        /// <summary>
        /// 更新账户信息
        /// </summary>
        public bool UpdateAccount(Account account)
        {
            // 业务逻辑检查：账户名不能为空
            if (string.IsNullOrWhiteSpace(account.AccountName))
            {
                return false;
            }
            return _accountDAL.UpdateAccount(account) > 0;
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        public bool DeleteAccount(int accountId)
        {
            // 可以在此添加业务逻辑，例如检查账户余额是否为0，或是否有交易记录
            return _accountDAL.DeleteAccount(accountId) > 0;
        }
    }
}