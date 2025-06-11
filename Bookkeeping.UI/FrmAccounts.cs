using Bookkeeping.BLL;
using Bookkeeping.Model;
using System;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    public partial class FrmAccounts : Form
    {
        private readonly AccountBLL _accountBLL = new AccountBLL();

        public FrmAccounts()
        {
            InitializeComponent();
        }

        private void FrmAccounts_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            dgvAccounts.DataSource = _accountBLL.GetAllAccounts();
            // 美化列头
            dgvAccounts.Columns["AccountID"].HeaderText = "ID";
            dgvAccounts.Columns["AccountName"].HeaderText = "账户名称";
            dgvAccounts.Columns["Balance"].HeaderText = "当前余额";
            dgvAccounts.Columns["Balance"].DefaultCellStyle.Format = "C2"; // 货币格式
        }

        // 切换到“新建”模式
        private void SetNewMode()
        {
            lblAccountId.Text = string.Empty;
            txtAccountName.Clear();
            numBalance.Value = 0;
            numBalance.Enabled = true; // 新建时可以设置初始余额

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            dgvAccounts.ClearSelection();
            txtAccountName.Focus();
        }

        // 切换到“编辑”模式
        private void SetEditMode()
        {
            numBalance.Enabled = false; // 不允许直接在管理界面修改余额，余额应由交易产生
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetNewMode();
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
                lblAccountId.Text = row.Cells["AccountID"].Value.ToString();
                txtAccountName.Text = row.Cells["AccountName"].Value.ToString();
                numBalance.Value = (decimal)row.Cells["Balance"].Value;

                SetEditMode();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show("账户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newAccount = new Account
            {
                AccountName = txtAccountName.Text.Trim(),
                Balance = numBalance.Value
            };

            if (_accountBLL.AddAccount(newAccount))
            {
                MessageBox.Show("添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
                SetNewMode();
            }
            else
            {
                MessageBox.Show("添加失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text) || string.IsNullOrEmpty(lblAccountId.Text))
            {
                MessageBox.Show("请先选择一个要更新的账户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updatedAccount = new Account
            {
                AccountID = int.Parse(lblAccountId.Text),
                AccountName = txtAccountName.Text.Trim(),
                Balance = numBalance.Value // 注意：我们禁用了numBalance，所以这里是原值
            };

            if (_accountBLL.UpdateAccount(updatedAccount))
            {
                MessageBox.Show("更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
                SetNewMode();
            }
            else
            {
                MessageBox.Show("更新失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblAccountId.Text))
            {
                MessageBox.Show("请先选择一个要删除的账户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 重要：实际项目中需要检查该账户下是否有交易记录，如果有则禁止删除
            if (MessageBox.Show("确定要删除这个账户吗？此操作不可恢复！", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int accountId = int.Parse(lblAccountId.Text);
                if (_accountBLL.DeleteAccount(accountId))
                {
                    MessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                    SetNewMode();
                }
                else
                {
                    MessageBox.Show("删除失败！请检查该账户下是否还有交易记录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}