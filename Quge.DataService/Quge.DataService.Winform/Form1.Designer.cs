namespace Quge.DataService.Winform
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblStateMore = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnExpoertMore = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpRegisterRight = new System.Windows.Forms.DateTimePicker();
			this.dtpRegisterLeft = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblStateLess = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnExpoertLess = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpAuctionRight = new System.Windows.Forms.DateTimePicker();
			this.dtpAuctionLeft = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.saveFileDialogMore = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialogLess = new System.Windows.Forms.SaveFileDialog();
			this.cbBoxProjType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbxUserIds = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblStateMore);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btnExpoertMore);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dtpRegisterRight);
			this.groupBox1.Controls.Add(this.dtpRegisterLeft);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(19, 61);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(565, 129);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据集1（所有用户的详细信息）";
			// 
			// lblStateMore
			// 
			this.lblStateMore.AutoSize = true;
			this.lblStateMore.ForeColor = System.Drawing.Color.Green;
			this.lblStateMore.Location = new System.Drawing.Point(145, 110);
			this.lblStateMore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStateMore.Name = "lblStateMore";
			this.lblStateMore.Size = new System.Drawing.Size(55, 15);
			this.lblStateMore.TabIndex = 6;
			this.lblStateMore.Text = "label8";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(37, 110);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 15);
			this.label6.TabIndex = 5;
			this.label6.Text = "导出状态：";
			// 
			// btnExpoertMore
			// 
			this.btnExpoertMore.Location = new System.Drawing.Point(448, 92);
			this.btnExpoertMore.Margin = new System.Windows.Forms.Padding(4);
			this.btnExpoertMore.Name = "btnExpoertMore";
			this.btnExpoertMore.Size = new System.Drawing.Size(100, 29);
			this.btnExpoertMore.TabIndex = 4;
			this.btnExpoertMore.Text = "导出并保存";
			this.btnExpoertMore.UseVisualStyleBackColor = true;
			this.btnExpoertMore.Click += new System.EventHandler(this.btnExpoertMore_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(341, 41);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(15, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "-";
			// 
			// dtpRegisterRight
			// 
			this.dtpRegisterRight.Location = new System.Drawing.Point(364, 34);
			this.dtpRegisterRight.Margin = new System.Windows.Forms.Padding(4);
			this.dtpRegisterRight.Name = "dtpRegisterRight";
			this.dtpRegisterRight.Size = new System.Drawing.Size(183, 25);
			this.dtpRegisterRight.TabIndex = 2;
			// 
			// dtpRegisterLeft
			// 
			this.dtpRegisterLeft.Location = new System.Drawing.Point(148, 35);
			this.dtpRegisterLeft.Margin = new System.Windows.Forms.Padding(4);
			this.dtpRegisterLeft.Name = "dtpRegisterLeft";
			this.dtpRegisterLeft.Size = new System.Drawing.Size(183, 25);
			this.dtpRegisterLeft.TabIndex = 1;
			this.dtpRegisterLeft.Value = new System.DateTime(2018, 1, 25, 19, 26, 54, 0);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 41);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "注册时间：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbxUserIds);
			this.groupBox2.Controls.Add(this.lblStateLess);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.btnExpoertLess);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.dtpAuctionRight);
			this.groupBox2.Controls.Add(this.dtpAuctionLeft);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(19, 212);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(565, 288);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据集2（所有用户的竞拍信息）";
			// 
			// lblStateLess
			// 
			this.lblStateLess.AutoSize = true;
			this.lblStateLess.ForeColor = System.Drawing.Color.Green;
			this.lblStateLess.Location = new System.Drawing.Point(148, 251);
			this.lblStateLess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStateLess.Name = "lblStateLess";
			this.lblStateLess.Size = new System.Drawing.Size(55, 15);
			this.lblStateLess.TabIndex = 7;
			this.lblStateLess.Text = "label9";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(40, 251);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(82, 15);
			this.label7.TabIndex = 7;
			this.label7.Text = "导出状态：";
			// 
			// btnExpoertLess
			// 
			this.btnExpoertLess.Location = new System.Drawing.Point(451, 237);
			this.btnExpoertLess.Margin = new System.Windows.Forms.Padding(4);
			this.btnExpoertLess.Name = "btnExpoertLess";
			this.btnExpoertLess.Size = new System.Drawing.Size(100, 29);
			this.btnExpoertLess.TabIndex = 5;
			this.btnExpoertLess.Text = "导出并保存";
			this.btnExpoertLess.UseVisualStyleBackColor = true;
			this.btnExpoertLess.Click += new System.EventHandler(this.btnExpoertLess_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(343, 185);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 15);
			this.label5.TabIndex = 5;
			this.label5.Text = "-";
			// 
			// dtpAuctionRight
			// 
			this.dtpAuctionRight.Location = new System.Drawing.Point(367, 177);
			this.dtpAuctionRight.Margin = new System.Windows.Forms.Padding(4);
			this.dtpAuctionRight.Name = "dtpAuctionRight";
			this.dtpAuctionRight.Size = new System.Drawing.Size(183, 25);
			this.dtpAuctionRight.TabIndex = 6;
			// 
			// dtpAuctionLeft
			// 
			this.dtpAuctionLeft.Location = new System.Drawing.Point(151, 177);
			this.dtpAuctionLeft.Margin = new System.Windows.Forms.Padding(4);
			this.dtpAuctionLeft.Name = "dtpAuctionLeft";
			this.dtpAuctionLeft.Size = new System.Drawing.Size(183, 25);
			this.dtpAuctionLeft.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 177);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "商品竞拍时间：";
			// 
			// cbBoxProjType
			// 
			this.cbBoxProjType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBoxProjType.FormattingEnabled = true;
			this.cbBoxProjType.Items.AddRange(new object[] {
            "test",
            "auction"});
			this.cbBoxProjType.Location = new System.Drawing.Point(161, 15);
			this.cbBoxProjType.Margin = new System.Windows.Forms.Padding(4);
			this.cbBoxProjType.Name = "cbBoxProjType";
			this.cbBoxProjType.Size = new System.Drawing.Size(160, 23);
			this.cbBoxProjType.TabIndex = 2;
			this.cbBoxProjType.SelectedIndexChanged += new System.EventHandler(this.cbBoxProjType_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 19);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(127, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "请选择项目类型：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(256, 15);
			this.label8.TabIndex = 4;
			this.label8.Text = "要查询的用户Id集合（用“|”分割）";
			// 
			// tbxUserIds
			// 
			this.tbxUserIds.Location = new System.Drawing.Point(11, 62);
			this.tbxUserIds.Multiline = true;
			this.tbxUserIds.Name = "tbxUserIds";
			this.tbxUserIds.Size = new System.Drawing.Size(540, 93);
			this.tbxUserIds.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(600, 521);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbBoxProjType);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "quge竞拍项目数据分析（v8.0）";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnExpoertMore;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpRegisterRight;
		private System.Windows.Forms.DateTimePicker dtpRegisterLeft;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker dtpAuctionRight;
		private System.Windows.Forms.DateTimePicker dtpAuctionLeft;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnExpoertLess;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblStateMore;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblStateLess;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.SaveFileDialog saveFileDialogMore;
		private System.Windows.Forms.SaveFileDialog saveFileDialogLess;
		private System.Windows.Forms.ComboBox cbBoxProjType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbxUserIds;
	}
}

