using NPOI.HSSF.UserModel;
using Quge.DataService.Aliyun.Log;
using Quge.DataService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quge.DataService.Winform
{
	public partial class Form1 : Form
	{

		private static string projName = "test";
		public Form1()
		{
			InitializeComponent();
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void btnExpoertMore_Click(object sender, EventArgs e)
		{

			DateTime timeLeft = dtpRegisterLeft.Value.Date;
			DateTime timeRight = dtpRegisterRight.Value;
			if ((timeRight - timeLeft).TotalSeconds < 0)
			{
				MessageBox.Show("请选择正确的时间段！");
				return;
			}

			//string path = "";
			//saveFileDialogMore.InitialDirectory = @"D:\";
			//saveFileDialogMore.FileName = DateTime.Now.ToString($"所有用户的详细信息_{DateTime.Now.Ticks}");
			//saveFileDialogMore.DefaultExt = "xls";
			//if (saveFileDialogMore.ShowDialog() == DialogResult.OK)
			//{
			//	path = saveFileDialogMore.FileName;
			//}
			//if (string.IsNullOrWhiteSpace(path))
			//{
			//	return;
			//}


			ThreadPool.QueueUserWorkItem(o =>
			{
				BeginInvoke(new Action(() =>
				{
					lblStateMore.Text = "导出中...";
					btnExpoertMore.Enabled = false;
					dtpRegisterLeft.Enabled = false;
					dtpRegisterRight.Enabled = false;
				}));

				//获取该时间段的所有数据并进行分析

				List<Dictionary<string, string>> registerList = new List<Dictionary<string, string>>();
				GetLog(ref registerList, timeLeft, timeRight, projName, DataLogTypeEnum.Register, 1);

				List<Dictionary<string, string>> loginList = new List<Dictionary<string, string>>();
				GetLog(ref loginList, timeLeft, timeRight, projName, DataLogTypeEnum.Login, 1);

				List<Dictionary<string, string>> payList = new List<Dictionary<string, string>>();
				GetLog(ref payList, timeLeft, timeRight, projName, DataLogTypeEnum.Pay, 1);

				List<Dictionary<string, string>> auctionList = new List<Dictionary<string, string>>();
				GetLog(ref auctionList, timeLeft, timeRight, projName, DataLogTypeEnum.Auction, 1);



				HSSFWorkbook hssfworkbook = new HSSFWorkbook();
				HSSFSheet sheet = hssfworkbook.CreateSheet("moreData") as HSSFSheet;

				BeginInvoke(new Action(() =>
				{
					lblStateMore.Text = "导出成功！";
					btnExpoertMore.Enabled = true;
					dtpRegisterLeft.Enabled = true;
					dtpRegisterRight.Enabled = true;
					MessageBox.Show("导出成功！");
				}));
			});


		}

		/// <summary>
		/// 递归获取指定日志区间内的日志信息
		/// </summary>
		/// <param name="list"></param>
		/// <param name="timeLeft"></param>
		/// <param name="timeRight"></param>
		/// <param name="projName"></param>
		/// <param name="logTypeEnum"></param>
		/// <param name="pageIndex">分页的页码，从1开始</param>
		private void GetLog(ref List<Dictionary<string, string>> list,
			DateTime timeLeft, DateTime timeRight,
			string projName, DataLogTypeEnum logTypeEnum, int pageIndex)
		{
			int singleMexCount = 100;
			var result = AliyunLogService.ReadLog(timeLeft, timeRight,
				$"projName == {projName} and logType == {(int)logTypeEnum}", offset: (pageIndex - 1) * singleMexCount);
			if (result.Any())
			{
				list.AddRange(result);
				GetLog(ref list, timeLeft, timeRight, projName, logTypeEnum, pageIndex + 1);
			}

		}
	}
}
