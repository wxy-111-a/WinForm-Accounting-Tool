using Bookkeeping.BLL;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.UI
{
    public partial class FrmReport : Form
    {
        private readonly TransactionBLL _transactionBLL = new TransactionBLL();

        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            // 设置默认日期为本月第一天到今天
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;

            // 自动加载数据
            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("无法获取用户信息，请重新登录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. 获取指定日期范围内的数据
            var transactions = _transactionBLL.GetTransactionViews(dtpStart.Value, dtpEnd.Value, Session.CurrentUser.UserID);

            // 2. 筛选出所有支出，并按分类进行分组求和
            var expenseData = transactions
                .Where(t => t.Type == "支出")
                .GroupBy(t => t.CategoryName)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalAmount = g.Sum(t => t.Amount)
                })
                .ToList();

            // 3. 绑定数据到图表
            Series expenseSeries = chartExpense.Series["ExpenseSeries"];
            expenseSeries.Points.Clear(); // 清除旧数据

            if (expenseData.Any())
            {
                // 将处理后的数据绑定到饼图
                expenseSeries.XValueMember = "Category";
                expenseSeries.YValueMembers = "TotalAmount";
                chartExpense.DataSource = expenseData;
                chartExpense.DataBind();
            }
            else
            {
                MessageBox.Show("该日期范围内没有支出数据。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 更新标题
            chartExpense.Titles[0].Text = string.Format("{0:yyyy-MM-dd} 至 {1:yyyy-MM-dd} 支出分类统计", dtpStart.Value, dtpEnd.Value);
        }
    }
}