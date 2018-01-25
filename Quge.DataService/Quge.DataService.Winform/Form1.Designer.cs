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
			this.groupBox1.Location = new System.Drawing.Point(14, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 103);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据集1（所有用户的详细信息）";
			// 
			// lblStateMore
			// 
			this.lblStateMore.AutoSize = true;
			this.lblStateMore.ForeColor = System.Drawing.Color.Green;
			this.lblStateMore.Location = new System.Drawing.Point(109, 88);
			this.lblStateMore.Name = "lblStateMore";
			this.lblStateMore.Size = new System.Drawing.Size(41, 12);
			this.lblStateMore.TabIndex = 6;
			this.lblStateMore.Text = "label8";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(28, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 12);
			this.label6.TabIndex = 5;
			this.label6.Text = "导出状态：";
			// 
			// btnExpoertMore
			// 
			this.btnExpoertMore.Location = new System.Drawing.Point(336, 74);
			this.btnExpoertMore.Name = "btnExpoertMore";
			this.btnExpoertMore.Size = new System.Drawing.Size(75, 23);
			this.btnExpoertMore.TabIndex = 4;
			this.btnExpoertMore.Text = "导出并保存";
			this.btnExpoertMore.UseVisualStyleBackColor = true;
			this.btnExpoertMore.Click += new System.EventHandler(this.btnExpoertMore_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(256, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(11, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "-";
			// 
			// dtpRegisterRight
			// 
			this.dtpRegisterRight.Location = new System.Drawing.Point(273, 27);
			this.dtpRegisterRight.Name = "dtpRegisterRight";
			this.dtpRegisterRight.Size = new System.Drawing.Size(138, 21);
			this.dtpRegisterRight.TabIndex = 2;
			// 
			// dtpRegisterLeft
			// 
			this.dtpRegisterLeft.Location = new System.Drawing.Point(111, 28);
			this.dtpRegisterLeft.Name = "dtpRegisterLeft";
			this.dtpRegisterLeft.Size = new System.Drawing.Size(138, 21);
			this.dtpRegisterLeft.TabIndex = 1;
			this.dtpRegisterLeft.Value = new System.DateTime(2018, 1, 17, 16, 41, 0, 0);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "注册时间：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblStateLess);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.btnExpoertLess);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.dtpAuctionRight);
			this.groupBox2.Controls.Add(this.dtpAuctionLeft);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(14, 175);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(424, 104);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据集2（所有用户的竞拍信息）";
			// 
			// lblStateLess
			// 
			this.lblStateLess.AutoSize = true;
			this.lblStateLess.ForeColor = System.Drawing.Color.Green;
			this.lblStateLess.Location = new System.Drawing.Point(111, 88);
			this.lblStateLess.Name = "lblStateLess";
			this.lblStateLess.Size = new System.Drawing.Size(41, 12);
			this.lblStateLess.TabIndex = 7;
			this.lblStateLess.Text = "label9";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(30, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "导出状态：";
			// 
			// btnExpoertLess
			// 
			this.btnExpoertLess.Location = new System.Drawing.Point(338, 77);
			this.btnExpoertLess.Name = "btnExpoertLess";
			this.btnExpoertLess.Size = new System.Drawing.Size(75, 23);
			this.btnExpoertLess.TabIndex = 5;
			this.btnExpoertLess.Text = "导出并保存";
			this.btnExpoertLess.UseVisualStyleBackColor = true;
			this.btnExpoertLess.Click += new System.EventHandler(this.btnExpoertLess_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(257, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "-";
			// 
			// dtpAuctionRight
			// 
			this.dtpAuctionRight.Location = new System.Drawing.Point(275, 29);
			this.dtpAuctionRight.Name = "dtpAuctionRight";
			this.dtpAuctionRight.Size = new System.Drawing.Size(138, 21);
			this.dtpAuctionRight.TabIndex = 6;
			// 
			// dtpAuctionLeft
			// 
			this.dtpAuctionLeft.Location = new System.Drawing.Point(113, 29);
			this.dtpAuctionLeft.Name = "dtpAuctionLeft";
			this.dtpAuctionLeft.Size = new System.Drawing.Size(138, 21);
			this.dtpAuctionLeft.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 12);
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
			this.cbBoxProjType.Location = new System.Drawing.Point(121, 12);
			this.cbBoxProjType.Name = "cbBoxProjType";
			this.cbBoxProjType.Size = new System.Drawing.Size(121, 20);
			this.cbBoxProjType.TabIndex = 2;
			this.cbBoxProjType.SelectedIndexChanged += new System.EventHandler(this.cbBoxProjType_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "请选择项目类型：";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(458, 311);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbBoxProjType);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "quge竞拍项目数据分析（v6.0）";
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
	}
}

