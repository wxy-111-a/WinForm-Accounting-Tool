using Bookkeeping.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    public partial class FrmTransactionView : Form
    {
        private readonly TransactionBLL _transactionBLL = new TransactionBLL();

        public FrmTransactionView()
        {
            InitializeComponent();
        }

        private void FrmTransactionView_Load(object sender, EventArgs e)
        {
            // 设置默认日期为本月第一天到今天
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;

            // 自动加载数据
            LoadTransactions();

            // 美化 DataGridView 列头
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.Columns.Clear();

            // 手动添加列，并设置HeaderText和DataPropertyName
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "日期", DataPropertyName = "TransactionDate", FillWeight = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "类型", DataPropertyName = "Type", FillWeight = 60 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "分类", DataPropertyName = "CategoryName", FillWeight = 120 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "金额", DataPropertyName = "Amount", FillWeight = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } }); // C2格式化为货币
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "账户", DataPropertyName = "AccountName", FillWeight = 120 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "备注", DataPropertyName = "Description", FillWeight = 200 });

            // 添加一个隐藏列来存储ID，以便删除时使用
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "TransactionID", Visible = false });
        }

        private void LoadTransactions()
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("无法获取用户信息，请重新登录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var transactions = _transactionBLL.GetTransactionViews(dtpStart.Value, dtpEnd.Value, Session.CurrentUser.UserID);
            dgvTransactions.DataSource = transactions;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("删除此记录会同步更新账户余额，确定要删除吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 获取选中行的隐藏ID（最后一列）
                int transactionId = (int)dgvTransactions.SelectedRows[0].Cells[dgvTransactions.Columns.Count - 1].Value;

                bool success = _transactionBLL.DeleteTransaction(transactionId);

                if (success)
                {
                    MessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactions(); // 重新加载数据
                }
                else
                {
                    MessageBox.Show("删除失败，请稍后重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 为"收入"和"支出"的金额显示不同颜色
        private void dgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 确保不是标题行
            if (e.RowIndex >= 0)
            {
                // 获取当前行绑定的数据源中的 Type 属性值
                string type = dgvTransactions.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (type == "收入")
                {
                    // 将金额列的单元格文字颜色设为绿色
                    dgvTransactions.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Green;
                }
                else if (type == "支出")
                {
                    // 将金额列的单元格文字颜色设为红色
                    dgvTransactions.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Red;
                }
            }
        }
    }
}