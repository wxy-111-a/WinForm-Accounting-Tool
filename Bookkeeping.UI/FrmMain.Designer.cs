namespace Bookkeeping.UI
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAccountMgt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCategoryMgt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExpenseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusLabelCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTransaction,
            this.menuManagement,
            this.menuReport,
            this.menuSystem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1082, 31);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // menuTransaction
            // 
            this.menuTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewTransaction,
            this.menuItemViewTransactions});
            this.menuTransaction.Name = "menuTransaction";
            this.menuTransaction.Size = new System.Drawing.Size(116, 27);
            this.menuTransaction.Text = "收支管理(&T)";
            // 
            // menuItemNewTransaction
            // 
            this.menuItemNewTransaction.Name = "menuItemNewTransaction";
            this.menuItemNewTransaction.Size = new System.Drawing.Size(182, 28);
            this.menuItemNewTransaction.Text = "记一笔(&N)";
            this.menuItemNewTransaction.Click += new System.EventHandler(this.menuItemNewTransaction_Click);
            // 
            // menuItemViewTransactions
            // 
            this.menuItemViewTransactions.Name = "menuItemViewTransactions";
            this.menuItemViewTransactions.Size = new System.Drawing.Size(182, 28);
            this.menuItemViewTransactions.Text = "收支明细(&V)";
            this.menuItemViewTransactions.Click += new System.EventHandler(this.menuItemViewTransactions_Click);
            // 
            // menuManagement
            // 
            this.menuManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAccountMgt,
            this.menuItemCategoryMgt});
            this.menuManagement.Name = "menuManagement";
            this.menuManagement.Size = new System.Drawing.Size(121, 27);
            this.menuManagement.Text = "信息管理(&M)";
            // 
            // menuItemAccountMgt
            // 
            this.menuItemAccountMgt.Name = "menuItemAccountMgt";
            this.menuItemAccountMgt.Size = new System.Drawing.Size(185, 28);
            this.menuItemAccountMgt.Text = "账户管理(&A)";
            this.menuItemAccountMgt.Click += new System.EventHandler(this.menuItemAccountMgt_Click);
            // 
            // menuItemCategoryMgt
            // 
            this.menuItemCategoryMgt.Name = "menuItemCategoryMgt";
            this.menuItemCategoryMgt.Size = new System.Drawing.Size(185, 28);
            this.menuItemCategoryMgt.Text = "分类管理(&C)";
            this.menuItemCategoryMgt.Click += new System.EventHandler(this.menuItemCategoryMgt_Click);
            // 
            // menuReport
            // 
            this.menuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExpenseReport});
            this.menuReport.Name = "menuReport";
            this.menuReport.Size = new System.Drawing.Size(117, 27);
            this.menuReport.Text = "统计报表(&R)";
            // 
            // menuItemExpenseReport
            // 
            this.menuItemExpenseReport.Name = "menuItemExpenseReport";
            this.menuItemExpenseReport.Size = new System.Drawing.Size(204, 28);
            this.menuItemExpenseReport.Text = "支出分类统计(&E)";
            this.menuItemExpenseReport.Click += new System.EventHandler(this.menuItemExpenseReport_Click);
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(85, 27);
            this.menuSystem.Text = "系统(&S)";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(147, 28);
            this.menuItemExit.Text = "退出(&X)";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelCurrentUser});
            this.statusStripMain.Location = new System.Drawing.Point(0, 527);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1082, 26);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // statusLabelCurrentUser
            // 
            this.statusLabelCurrentUser.Name = "statusLabelCurrentUser";
            this.statusLabelCurrentUser.Size = new System.Drawing.Size(129, 20);
            this.statusLabelCurrentUser.Text = "当前用户：Admin";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FrmMain";
            this.Text = "个人记账系统主页";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuTransaction;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewTransaction;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewTransactions;
        private System.Windows.Forms.ToolStripMenuItem menuManagement;
        private System.Windows.Forms.ToolStripMenuItem menuItemAccountMgt;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategoryMgt;
        private System.Windows.Forms.ToolStripMenuItem menuReport;
        private System.Windows.Forms.ToolStripMenuItem menuItemExpenseReport;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelCurrentUser;
    }
}