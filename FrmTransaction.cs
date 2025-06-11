using Bookkeeping.BLL;
using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    public partial class FrmTransaction : Form
    {
        private readonly AccountBLL _accountBLL = new AccountBLL();
        private readonly CategoryBLL _categoryBLL = new CategoryBLL();
        private readonly TransactionBLL _transactionBLL = new TransactionBLL();

        // 用于存储从数据库加载的完整分类列表
        private List<Category> _allCategories;

        public FrmTransaction()
        {
            InitializeComponent();
        }

        // 窗体加载事件
        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            LoadAllCategories();
            // 默认加载支出分类
            FilterCategories();
        }

        // 加载所有账户到 ComboBox
        private void LoadAccounts()
        {
            var accounts = _accountBLL.GetAllAccounts();
            cmbAccount.DataSource = accounts;
            cmbAccount.DisplayMember = "AccountName"; // 显示账户名
            cmbAccount.ValueMember = "AccountID";     // 内部值为账户ID
        }

        // 从数据库加载一次所有分类
        private void LoadAllCategories()
        {
            _allCategories = _categoryBLL.GetAllCategories();
        }

        // 根据选择的类型（收入/支出）筛选并显示分类
        private void FilterCategories()
        {
            string type = radioIncome.Checked ? "收入" : "支出";

            var filteredCategories = _allCategories.Where(c => c.Type == type).ToList();

            cmbCategory.DataSource = filteredCategories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
        }

        // 当“收入”或“支出”单选按钮变化时，重新筛选分类
        private void radioType_CheckedChanged(object sender, EventArgs e)
        {
            FilterCategories();
        }

        // "取消" 按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 关闭当前窗口
        }

        // "保存" 按钮点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 数据验证
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("金额必须大于0！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbAccount.SelectedValue == null)
            {
                MessageBox.Show("请选择一个账户！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("请选择一个分类！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("发生错误：无法获取当前用户信息！请重新登录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. 封装 Transaction 对象
            var transaction = new Transaction
            {
                TransactionDate = dtpTransactionDate.Value,
                Amount = numAmount.Value,
                AccountID = (int)cmbAccount.SelectedValue,
                CategoryID = (int)cmbCategory.SelectedValue,
                Description = txtDescription.Text.Trim(),
                UserID = Session.CurrentUser.UserID // 从 Session 获取当前登录用户的ID
            };

            // 3. 调用 BLL 进行保存
            bool success = _transactionBLL.AddTransaction(transaction);

            // 4. 显示结果
            if (success)
            {
                MessageBox.Show("记账成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // 设置对话框结果，方便父窗体刷新
                this.Close();
            }
            else
            {
                MessageBox.Show("记账失败，请稍后重试。", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}