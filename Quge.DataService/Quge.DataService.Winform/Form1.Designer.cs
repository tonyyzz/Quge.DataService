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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpRegisterLeft = new System.Windows.Forms.DateTimePicker();
			this.dtpRegisterRight = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.btnExpoertMore = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxUserId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpAuctionLeft = new System.Windows.Forms.DateTimePicker();
			this.dtpAuctionRight = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.btnExpoertLess = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblStateMore = new System.Windows.Forms.Label();
			this.lblStateLess = new System.Windows.Forms.Label();
			this.saveFileDialogMore = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialogLess = new System.Windows.Forms.SaveFileDialog();
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
			this.groupBox1.Location = new System.Drawing.Point(24, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 103);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据集1（所有用户的详细信息）";
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
			this.groupBox2.Controls.Add(this.tbxUserId);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(24, 169);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(424, 126);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据集2（单用户的简略信息）";
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
			// dtpRegisterLeft
			// 
			this.dtpRegisterLeft.Location = new System.Drawing.Point(111, 28);
			this.dtpRegisterLeft.Name = "dtpRegisterLeft";
			this.dtpRegisterLeft.Size = new System.Drawing.Size(138, 21);
			this.dtpRegisterLeft.TabIndex = 1;
			// 
			// dtpRegisterRight
			// 
			this.dtpRegisterRight.Location = new System.Drawing.Point(273, 27);
			this.dtpRegisterRight.Name = "dtpRegisterRight";
			this.dtpRegisterRight.Size = new System.Drawing.Size(138, 21);
			this.dtpRegisterRight.TabIndex = 2;
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "用户Id：";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// tbxUserId
			// 
			this.tbxUserId.Location = new System.Drawing.Point(111, 18);
			this.tbxUserId.Name = "tbxUserId";
			this.tbxUserId.Size = new System.Drawing.Size(138, 21);
			this.tbxUserId.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 12);
			this.label4.TabIndex = 2;
			this.label4.Text = "商品竞拍时间：";
			// 
			// dtpAuctionLeft
			// 
			this.dtpAuctionLeft.Location = new System.Drawing.Point(111, 48);
			this.dtpAuctionLeft.Name = "dtpAuctionLeft";
			this.dtpAuctionLeft.Size = new System.Drawing.Size(138, 21);
			this.dtpAuctionLeft.TabIndex = 5;
			// 
			// dtpAuctionRight
			// 
			this.dtpAuctionRight.Location = new System.Drawing.Point(273, 48);
			this.dtpAuctionRight.Name = "dtpAuctionRight";
			this.dtpAuctionRight.Size = new System.Drawing.Size(138, 21);
			this.dtpAuctionRight.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(255, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "-";
			// 
			// btnExpoertLess
			// 
			this.btnExpoertLess.Location = new System.Drawing.Point(336, 96);
			this.btnExpoertLess.Name = "btnExpoertLess";
			this.btnExpoertLess.Size = new System.Drawing.Size(75, 23);
			this.btnExpoertLess.TabIndex = 5;
			this.btnExpoertLess.Text = "导出并保存";
			this.btnExpoertLess.UseVisualStyleBackColor = true;
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
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(28, 107);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "导出状态：";
			// 
			// lblStateMore
			// 
			this.lblStateMore.AutoSize = true;
			this.lblStateMore.Location = new System.Drawing.Point(109, 88);
			this.lblStateMore.Name = "lblStateMore";
			this.lblStateMore.Size = new System.Drawing.Size(41, 12);
			this.lblStateMore.TabIndex = 6;
			this.lblStateMore.Text = "label8";
			// 
			// lblStateLess
			// 
			this.lblStateLess.AutoSize = true;
			this.lblStateLess.Location = new System.Drawing.Point(109, 107);
			this.lblStateLess.Name = "lblStateLess";
			this.lblStateLess.Size = new System.Drawing.Size(41, 12);
			this.lblStateLess.TabIndex = 7;
			this.lblStateLess.Text = "label9";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(469, 322);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "quge竞拍项目数据分析";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.TextBox tbxUserId;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnExpoertLess;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblStateMore;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblStateLess;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.SaveFileDialog saveFileDialogMore;
		private System.Windows.Forms.SaveFileDialog saveFileDialogLess;
	}
}

