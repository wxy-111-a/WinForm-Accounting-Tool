using System;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 在状态栏显示当前登录的用户名
            if (Session.CurrentUser != null)
            {
                statusLabelCurrentUser.Text = string.Format("当前用户：{0}", Session.CurrentUser.UserName);
            }
            else
            {
                // 如果没有用户信息，理论上应该退回到登录界面
                MessageBox.Show("未检测到登录信息，应用程序即将退出。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // 退出系统
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 主窗口关闭时，确认是否退出整个应用程序
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "确认退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; // 取消关闭事件
            }
            else
            {
                Application.ExitThread(); // 确保所有线程都退出
            }
        }

        // 封装一个打开子窗体的通用方法，避免重复打开同一个窗体
        private void ShowChildForm(Form childForm)
        {
            // 检查是否已经打开了同类型的窗体
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == childForm.GetType())
                {
                    form.Activate(); // 如果已打开，则激活它
                    return;
                }
            }
            
            // 如果没打开，则设置为MDI子窗体并显示
            childForm.MdiParent = this;
            childForm.Show();
        }

        // 菜单项："记一笔"
        private void menuItemNewTransaction_Click(object sender, EventArgs e)
        {
            FrmTransaction frm = new FrmTransaction();
            // 使用 ShowDialog() 以模态方式打开，确保用户完成或取消操作
            frm.ShowDialog();
        }

        // 菜单项："收支明细"
        private void menuItemViewTransactions_Click(object sender, EventArgs e)
        {
            ShowChildForm(new FrmTransactionView());
        }

        // 菜单项："账户管理"
        private void menuItemAccountMgt_Click(object sender, EventArgs e)
        {
            ShowChildForm(new FrmAccounts());
        }

        // 菜单项："分类管理"
        private void menuItemCategoryMgt_Click(object sender, EventArgs e)
        {
            ShowChildForm(new FrmCategories());
        }

        // 菜单项："支出分类统计"
        private void menuItemExpenseReport_Click(object sender, EventArgs e)
        {
            ShowChildForm(new FrmReport());
        }
    }
}