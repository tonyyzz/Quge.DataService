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
				//var list = AliyunLogService.ReadLog(timeLeft, timeRight, "projName == test and logType == 3");

				List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

				//GetLog(ref list, timeLeft, timeRight, "test", DataLogTypeEnum.Register);

				HSSFWorkbook hssfworkbook = new HSSFWorkbook();
				HSSFSheet sheet = hssfworkbook.CreateSheet("moreData") as HSSFSheet;
			});


		}

		///// <summary>
		///// 递归获取指定日志区间内的日志信息
		///// </summary>
		///// <param name="list"></param>
		///// <param name="timeLeft"></param>
		///// <param name="timeRight"></param>
		///// <param name="projName"></param>
		///// <param name="logTypeEnum"></param>
		///// <param name="where"></param>
		//private void GetLog(ref List<Dictionary<string, string>> list,
		//	DateTime timeLeft, DateTime timeRight,
		//	string projName, DataLogTypeEnum logTypeEnum)
		//{
		//	int singleMexCount = 100;
		//	list = AliyunLogService.ReadLog(timeLeft, timeRight,
		//		$"projName == {projName} and logType == {(int)logTypeEnum}");

		//	string str = "";
		//	foreach (var dict in list)
		//	{
		//		str += dict["time"] + Environment.NewLine;
		//	}

		//}
	}
}
