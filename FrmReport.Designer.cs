namespace Bookkeeping.UI
{
    partial class FrmReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chartExpense = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.btnGenerate);
            this.pnlTop.Controls.Add(this.dtpEnd);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.dtpStart);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(982, 70);
            this.pnlTop.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(622, 20);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 35);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "生成报表";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnd.Location = new System.Drawing.Point(384, 24);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 27);
            this.dtpEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(344, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "到";
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStart.Location = new System.Drawing.Point(127, 24);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 27);
            this.dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "统计日期：";
            // 
            // chartExpense
            // 
            chartArea1.Name = "ChartArea1";
            this.chartExpense.ChartAreas.Add(chartArea1);
            this.chartExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartExpense.Legends.Add(legend1);
            this.chartExpense.Location = new System.Drawing.Point(0, 70);
            this.chartExpense.Name = "chartExpense";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VALX (#PERCENT)";
            series1.Legend = "Legend1";
            series1.LegendText = "#VALX";
            series1.Name = "ExpenseSeries";
            this.chartExpense.Series.Add(series1);
            this.chartExpense.Size = new System.Drawing.Size(982, 483);
            this.chartExpense.TabIndex = 2;
            this.chartExpense.Text = "chart1";
            title1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            title1.Name = "Title1";
            title1.Text = "支出分类统计";
            this.chartExpense.Titles.Add(title1);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.chartExpense);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmReport";
            this.Text = "统计报表";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpense;
    }
}