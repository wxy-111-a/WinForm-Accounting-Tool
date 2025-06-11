using Bookkeeping.BLL;
using Bookkeeping.Model;
using System;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    public partial class FrmLogin : Form
    {
        private readonly UserInfoBLL _userInfoBLL = new UserInfoBLL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        // "退出" 按钮点击事件
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // "登录" 按钮点击事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 基本的输入验证
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // 调用 BLL 进行登录验证
            UserInfo currentUser = _userInfoBLL.Login(userName, password);
            if (currentUser != null)
            {
                // 登录成功 - 使用 string.Format 代替字符串插值
                MessageBox.Show(string.Format("欢迎您，{0}！", currentUser.UserName), "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 为了在其他窗口使用当前用户信息，可以将其存储在一个静态类中
                Session.CurrentUser = currentUser;

                // 打开主窗口
                // FrmMain frmMain = new FrmMain();
                // frmMain.Show();

                // 隐藏当前登录窗口
                this.Hide();
                // 此处应有打开主窗体的代码，因为我们没有主窗体，暂时注释掉
                // 如果直接关闭登录窗体，整个应用程序会退出
            }
            else
            {
                // 登录失败
                MessageBox.Show("用户名或密码错误，请重试！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }

    /// <summary>
    /// 创建一个静态类来模拟 Session，存储全局用户信息
    /// </summary>
    public static class Session
    {
        public static UserInfo CurrentUser { get; set; }
    }
}