namespace Bookkeeping.UI
{
    partial class FrmTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioExpense = new System.Windows.Forms.RadioButton();
            this.radioIncome = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(170, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "记一笔新账";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.Location = new System.Drawing.Point(60, 160);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 24);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "日期：";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpTransactionDate.Location = new System.Drawing.Point(140, 155);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(320, 31);
            this.dtpTransactionDate.TabIndex = 4;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAmount.Location = new System.Drawing.Point(60, 210);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(64, 24);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "金额：";
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numAmount.Location = new System.Drawing.Point(140, 208);
            this.numAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(320, 31);
            this.numAmount.TabIndex = 6;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccount.Location = new System.Drawing.Point(60, 260);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(64, 24);
            this.lblAccount.TabIndex = 7;
            this.lblAccount.Text = "账户：";
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(140, 257);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(320, 32);
            this.cmbAccount.TabIndex = 8;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCategory.Location = new System.Drawing.Point(60, 310);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(64, 24);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "分类：";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(140, 307);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(320, 32);
            this.cmbCategory.TabIndex = 10;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDescription.Location = new System.Drawing.Point(60, 360);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 24);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "备注：";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDescription.Location = new System.Drawing.Point(140, 357);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(320, 80);
            this.txtDescription.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(310, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 45);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.radioExpense);
            this.groupBoxType.Controls.Add(this.radioIncome);
            this.groupBoxType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxType.Location = new System.Drawing.Point(64, 75);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(396, 65);
            this.groupBoxType.TabIndex = 1;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "类型";
            // 
            // radioExpense
            // 
            this.radioExpense.AutoSize = true;
            this.radioExpense.Checked = true;
            this.radioExpense.Location = new System.Drawing.Point(220, 25);
            this.radioExpense.Name = "radioExpense";
            this.radioExpense.Size = new System.Drawing.Size(70, 28);
            this.radioExpense.TabIndex = 1;
            this.radioExpense.TabStop = true;
            this.radioExpense.Text = "支出";
            this.radioExpense.UseVisualStyleBackColor = true;
            // 
            // radioIncome
            // 
            this.radioIncome.AutoSize = true;
            this.radioIncome.Location = new System.Drawing.Point(80, 25);
            this.radioIncome.Name = "radioIncome";
            this.radioIncome.Size = new System.Drawing.Size(70, 28);
            this.radioIncome.TabIndex = 0;
            this.radioIncome.Text = "收入";
            this.radioIncome.UseVisualStyleBackColor = true;
            this.radioIncome.CheckedChanged += new System.EventHandler(this.radioType_CheckedChanged);
            // 
            // FrmTransaction
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(532, 533);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.dtpTransactionDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "记一笔";
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioExpense;
        private System.Windows.Forms.RadioButton radioIncome;
    }
}