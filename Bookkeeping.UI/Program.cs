// Bookkeeping.UI/Program.cs
using System;
using System.Windows.Forms;

namespace Bookkeeping.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. 创建并显示登录窗体
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog(); // 使用 ShowDialog()，程序会在此处暂停，直到登录窗体关闭

            // 2. 检查登录是否成功 (通过 Session 中的用户信息判断)
            if (Session.CurrentUser != null)
            {
                // 3. 如果登录成功，则启动主窗体
                Application.Run(new FrmMain());
            }
            // 如果 Session.CurrentUser 为 null (表示登录失败或直接关闭了登录窗口)，程序会自动结束。
        }
    }
}