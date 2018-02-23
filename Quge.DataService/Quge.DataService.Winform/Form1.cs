using NPOI.XSSF.UserModel;
using NPOI.XSSF.UserModel;
using Quge.DataService.Aliyun.Log;
using Quge.DataService.Model;
using Quge.DataService.Model.Export;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quge.DataService.Winform
{
	public partial class Form1 : Form
	{

		private static string projName = "test";//test  auction
		public Form1()
		{
			InitializeComponent();
			lblStateMore.Text = "";
			lblStateLess.Text = "";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//动态加载项目名称
			var projNameStr = FileHelper.Read("_projName.txt", Encoding.UTF8);
			var projNameList = projNameStr.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			cbBoxProjType.Items.Clear();
			foreach (var item in projNameList)
			{
				cbBoxProjType.Items.Add(item.Trim());
			}
			cbBoxProjType.SelectedIndex = 0;
			projName = (string)cbBoxProjType.SelectedItem;
		}

		private void cbBoxProjType_SelectedIndexChanged(object sender, EventArgs e)
		{
			projName = (string)cbBoxProjType.SelectedItem;
		}

		

		private void btnExpoertMore_Click(object sender, EventArgs e)
		{

			



			DateTime timeLeft = dtpRegisterLeft.Value.Date;
			DateTime timeRight = dtpRegisterRight.Value.Date.AddDays(1).AddSeconds(-1);
			if ((timeRight - timeLeft).TotalSeconds < 0)
			{
				MessageBox.Show("请选择正确的时间段！");
				return;
			}


			string path = "";
			saveFileDialogMore.InitialDirectory = @"D:\";
			saveFileDialogMore.FileName = $"{projName}_数据集1_所有用户的详细信息_{DateTime.Now.Ticks}";
			saveFileDialogMore.DefaultExt = "xlsx";
			if (saveFileDialogMore.ShowDialog() == DialogResult.OK)
			{
				path = saveFileDialogMore.FileName;
			}
			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}


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

				List<Dictionary<string, string>> registerDictList = new List<Dictionary<string, string>>();
				List<Dictionary<string, string>> loginDictList = new List<Dictionary<string, string>>();
				List<Dictionary<string, string>> payDictList = new List<Dictionary<string, string>>();
				try
				{
					//GetLog(ref loginDictList, timeLeft, DateTime.Now, projName, DataLogTypeEnum.Login, 1);
					//GetLog(ref registerDictList, timeLeft, timeRight, projName, DataLogTypeEnum.Register, 1);
					//GetLog(ref payDictList, timeLeft, DateTime.Now, projName, DataLogTypeEnum.Pay, 1);
					var idSelectStr = "";
					loginDictList = GetLog(idSelectStr,timeLeft, DateTime.Now, projName, DataLogTypeEnum.Login);
					registerDictList = GetLog(idSelectStr, timeLeft, timeRight, projName, DataLogTypeEnum.Register);
					payDictList = GetLog(idSelectStr, timeLeft, DateTime.Now, projName, DataLogTypeEnum.Pay);
				}
				catch (Exception)
				{
					BeginInvoke(new Action(() =>
					{
						lblStateMore.Text = "网络异常，请重试！";
						btnExpoertMore.Enabled = true;
						dtpRegisterLeft.Enabled = true;
						dtpRegisterRight.Enabled = true;
						MessageBox.Show("网络异常，请重试！");
					}));
					return;
				}

				//List<Dictionary<string, string>> auctionDictList = new List<Dictionary<string, string>>();
				//GetLog(ref auctionDictList, timeLeft, DateTime.Now, projName, DataLogTypeEnum.Auction, 1);

				//TestModel testModel = new TestModel();

				//var minTime = DateTime.MinValue;

				if (!registerDictList.Any())
				{
					BeginInvoke(new Action(() =>
					{
						lblStateMore.Text = "暂无数据，无法导出！";
						btnExpoertMore.Enabled = true;
						dtpRegisterLeft.Enabled = true;
						dtpRegisterRight.Enabled = true;
						MessageBox.Show("暂无数据，无法导出");
					}));
					return;
				}


				var registerModelList = registerDictList.JsonSerialize().JsonDeserialize<List<RegisterModel>>();
				var loginModelList = loginDictList.JsonSerialize().JsonDeserialize<List<LoginModel>>();
				var payModelList = payDictList.JsonSerialize().JsonDeserialize<List<PayModel>>();

				//var auctionModelList = auctionDictList.JsonSerialize().JsonDeserialize<List<AuctionModel>>();

				List<DataRLModel> dataList = new List<DataRLModel>();


				//注册
				foreach (var item in registerModelList)
				{
					var dataItem = dataList.FirstOrDefault(m => m.pid == item.pidInt);
					if (dataItem == null)
					{
						dataList.Add(new DataRLModel()
						{
							pid = item.pidInt,
							channel = item.channel,
							RegisterTime = item.Time
						});
					}
					else
					{
						if (dataItem.RegisterTime < item.Time)
						{
							dataItem.channel = item.channel;
							dataItem.RegisterTime = item.Time;
						}
					}
				}


				for (int i = 0; i < dataList.Count(); i++)
				{
					var item = dataList[i];

					//登录
					//记录最后一次登录时间
					var loginInfo = loginModelList.Where(m => m.pidInt == item.pid).OrderByDescending(m => m.Time).FirstOrDefault();
					if (loginInfo != null)
					{
						item.LastLoginTime = loginInfo.Time;
					}
					if (item.LastLoginTime == DateTime.MinValue)
					{
						item.LastLoginTime = DateTimeHelper.GetDeaultTime();
					}
					//支付
					//记录该用户的总充值额度，第一次充值时间，充值次数
					//先获取该用户的所有支付信息
					var payInfoLi = payModelList.Where(m => m.pidInt == item.pid);
					if (payInfoLi.Any())
					{
						var totalFeeYuan = payInfoLi.Sum(m => m.FeeYuan);
						var firstPayTime = payInfoLi.OrderBy(m => m.Time).FirstOrDefault().Time;
						var payCount = payInfoLi.Count();
						item.TotalFeeYuan = totalFeeYuan;
						item.FirstPayTime = firstPayTime;
						item.PayCount = payCount;
					}
					if (item.FirstPayTime == DateTime.MinValue)
					{
						item.FirstPayTime = DateTimeHelper.GetDeaultTime();
					}
				}

				//筛选 有充值记录的注册用户
				dataList = dataList.Where(m => m.TotalFeeYuan > 0).ToList();


				XSSFWorkbook hssfworkbook = new XSSFWorkbook();
				XSSFSheet sheet = hssfworkbook.CreateSheet("RLData") as XSSFSheet;

				CreateRLDataTableHeader(hssfworkbook, sheet);
				RLDataHandle(hssfworkbook, sheet, dataList);
				WriteXlsToFile(hssfworkbook, path);

				BeginInvoke(new Action(() =>
				{
					lblStateMore.Text = "导出成功！" + DateTime.Now.ToStr();
					btnExpoertMore.Enabled = true;
					dtpRegisterLeft.Enabled = true;
					dtpRegisterRight.Enabled = true;
					var dialogResult = MessageBox.Show("导出成功，是否打开该文档？", "提示", MessageBoxButtons.OKCancel);
					if (dialogResult == DialogResult.OK)
					{
						System.Diagnostics.Process.Start(path);
					}
				}));
			});

		}

		private void btnExpoertLess_Click(object sender, EventArgs e)
		{
			var ids = tbxUserIds.Text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			if (!ids.Any())
			{
				MessageBox.Show("请填写Id");
				return;
			}

			var idSelectStr = $"({string.Join(" or ", ids)})";

			DateTime timeLeft = dtpAuctionLeft.Value.Date;
			//timeLeft = dtpAuctionLeft.Value.AddMinutes(-13);
			DateTime timeRight = dtpAuctionRight.Value.Date.AddDays(1).AddSeconds(-1);
			if ((timeRight - timeLeft).TotalSeconds < 0)
			{
				MessageBox.Show("请选择正确的时间段！");
				return;
			}


			string path = "";
			saveFileDialogLess.InitialDirectory = @"D:\";
			saveFileDialogLess.FileName = $"{projName}_数据集2_所有用户的竞拍信息_{DateTime.Now.Ticks}";
			saveFileDialogLess.DefaultExt = "xlsx";
			if (saveFileDialogLess.ShowDialog() == DialogResult.OK)
			{
				path = saveFileDialogLess.FileName;
			}
			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}

			ThreadPool.QueueUserWorkItem(o =>
			{
				BeginInvoke(new Action(() =>
				{
					lblStateLess.Text = "导出中...";
					btnExpoertLess.Enabled = false;
					dtpAuctionLeft.Enabled = false;
					dtpAuctionRight.Enabled = false;
				}));

				//获取该时间段的所有数据并进行分析
				List<Dictionary<string, string>> auctionDictList = new List<Dictionary<string, string>>();
				List<Dictionary<string, string>> auctionPrizeDictList = new List<Dictionary<string, string>>();

				//try
				//{
				//GetLog(ref auctionDictList, timeLeft, timeRight, projName, DataLogTypeEnum.Auction, 1);
				//GetLog(ref auctionPrizeDictList, timeLeft, DateTime.Now, projName, DataLogTypeEnum.AuctionPrize, 1);

				auctionDictList = GetLog(idSelectStr,timeLeft, timeRight, projName, DataLogTypeEnum.Auction);
				auctionPrizeDictList = GetLog(idSelectStr,timeLeft, DateTime.Now, projName, DataLogTypeEnum.AuctionPrize);
				//}
				//catch (Exception ex)
				//{
				//	BeginInvoke(new Action(() =>
				//	{
				//		lblStateLess.Text = "网络异常，请重试！";
				//		btnExpoertLess.Enabled = true;
				//		dtpAuctionLeft.Enabled = true;
				//		dtpAuctionRight.Enabled = true;
				//		MessageBox.Show("网络异常，请重试！" + Environment.NewLine + ex.ToString());
				//	}));
				//	return;
				//}

				var auctionModelList = auctionDictList.JsonSerialize().JsonDeserialize<List<AuctionModel>>();
				var auctionPrizeModelList = auctionPrizeDictList.JsonSerialize().JsonDeserialize<List<AuctionModel>>();


				//var appointedAuctionPrizeModelList = auctionPrizeModelList.Where(m => m.pidInt == 10008331).ToList();

				if (!auctionModelList.Any())
				{
					BeginInvoke(new Action(() =>
					{
						lblStateLess.Text = "暂无数据，无法导出！";
						btnExpoertLess.Enabled = true;
						dtpAuctionLeft.Enabled = true;
						dtpAuctionRight.Enabled = true;
						MessageBox.Show("暂无数据，无法导出！");
					}));
					return;
				}


				var dataList = auctionModelList.GroupBy(m => new
				{
					m.pidInt,
					m.auctionName,
					m.TermIndexInt
				}).Select(m => new DataAuctModel()
				{
					pid = m.Key.pidInt,
					ActionName = m.Key.auctionName,
					TermIndex = m.Key.TermIndexInt,
					FirstActionTime = m.OrderBy(n => n.Time).FirstOrDefault().Time,
					AuctionCountOfThisTerm = m.Count(),
					IsFinalWinPrize = false, // m.FirstOrDefault(n => n.IsWinPrize) != null ? true : false
				}).ToList();

				for (int i = 0; i < dataList.Count(); i++)
				{
					var item = dataList[i];

					var prizeInfo = auctionPrizeModelList.Where(m =>
						m.pidInt == item.pid
						&& m.auctionName == item.ActionName
						&& m.TermIndexInt == item.TermIndex)
					.OrderByDescending(m => m.Time)
					.FirstOrDefault(m => m.IsWinPrize);

					if (prizeInfo != null)
					{
						item.IsFinalWinPrize = true;
					}


					//var payInfoLi = payModelList.Where(m => m.pidInt == item.pid);
					//if (payInfoLi.Any())
					//{
					//	item.TotalFeeYuan = payInfoLi.Sum(m => m.FeeYuan);
					//}
				}

				XSSFWorkbook hssfworkbook = new XSSFWorkbook();
				XSSFSheet sheet = hssfworkbook.CreateSheet("AuctionData") as XSSFSheet;

				CreateAuctDataTableHeader(hssfworkbook, sheet);
				AuctDataHandle(hssfworkbook, sheet, dataList);
				WriteXlsToFile(hssfworkbook, path);

				BeginInvoke(new Action(() =>
				{
					lblStateLess.Text = "导出成功！" + DateTime.Now.ToStr();
					btnExpoertLess.Enabled = true;
					dtpAuctionLeft.Enabled = true;
					dtpAuctionRight.Enabled = true;
					var dialogResult = MessageBox.Show("导出成功，是否打开该文档？", "提示", MessageBoxButtons.OKCancel);
					if (dialogResult == DialogResult.OK)
					{
						System.Diagnostics.Process.Start(path);
					}
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
		//private void GetLog(ref List<Dictionary<string, string>> list,
		//	DateTime timeLeft, DateTime timeRight,
		//	string projName, DataLogTypeEnum logTypeEnum, int pageIndex)
		//{
		//	//Thread.Sleep(1);
		//	int singleMexCount = 100;
		//	bool isException = false;
		//	var result = AliyunLogService.ReadLog(out isException, timeLeft, timeRight,
		//		$"projName:{projName} and logType:{(int)logTypeEnum}", offset: (pageIndex - 1) * singleMexCount);

		//	if (pageIndex < Math.Pow(10, 8))
		//	{


		//		if (result.Any())
		//		{
		//			list.AddRange(result);
		//			GetLog(ref list, timeLeft, timeRight, projName, logTypeEnum, pageIndex + 1);
		//		}
		//		else
		//		{
		//			if (isException)
		//			{
		//				GetLog(ref list, timeLeft, timeRight, projName, logTypeEnum, pageIndex + 1);
		//			}
		//		}
		//	}
		//}

		//非递归
		private List<Dictionary<string, string>> GetLog(string idSelectStr,
			DateTime timeLeft, DateTime timeRight,
			string projName, DataLogTypeEnum logTypeEnum)
		{
			List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
			int singleMexCount = 100;
			for (int i = 1; i < Int32.MaxValue - 1; i++)
			{
				bool isException = false;
				var whereStr = "";
				if (string.IsNullOrWhiteSpace(idSelectStr))
				{
					whereStr = $"projName:{projName} and logType:{(int)logTypeEnum}";
				}
				else
				{
					whereStr = $"projName:{projName} and logType:{(int)logTypeEnum} and {idSelectStr}";
				}
				var result = AliyunLogService.ReadLog(out isException, timeLeft, timeRight,
					whereStr, offset: (i - 1) * singleMexCount);

				if (result.Any())
				{
					list.AddRange(result);
				}
				else
				{
					if (!isException)
					{
						break;
					}
				}

			}
			return list;
		}


		private void CreateAuctDataTableHeader(XSSFWorkbook hssfworkbook, XSSFSheet sheet)
		{
			XSSFCellStyle celStyle = getCellStyle(hssfworkbook);
			XSSFRow row = sheet.CreateRow(0) as XSSFRow;

			sheet.SetColumnWidth(0, 20 * 256);
			var cell = row.CreateCell(0);
			cell.SetCellValue("用户id");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(1, 60 * 256);
			cell = row.CreateCell(1);
			cell.SetCellValue("出拍商品名称");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(2, 20 * 256);
			cell = row.CreateCell(2);
			cell.SetCellValue("期数");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(3, 20 * 256);
			cell = row.CreateCell(3);
			cell.SetCellValue("第一次出拍时间");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(4, 20 * 256);
			cell = row.CreateCell(4);
			//cell.SetCellValue("第一次出拍时间");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(5, 20 * 256);
			cell = row.CreateCell(5);
			cell.SetCellValue("总共出拍的次数");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(6, 20 * 256);
			cell = row.CreateCell(6);
			cell.SetCellValue("是否中奖");
			cell.CellStyle = celStyle;

			//sheet.SetColumnWidth(6, 20 * 256);
			//cell = row.CreateCell(6);
			//cell.SetCellValue("充值时间");
			//cell.CellStyle = celStyle;

			//sheet.SetColumnWidth(6, 20 * 256);
			//cell = row.CreateCell(6);
			//cell.SetCellValue("充值总额度（元）");
			//cell.CellStyle = celStyle;
		}

		private void AuctDataHandle(XSSFWorkbook hssfworkbook, XSSFSheet sheet, List<DataAuctModel> list)
		{
			int dataNum = list.Count(); //数据量
			XSSFRow row;
			XSSFCell cell;
			XSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			XSSFCellStyle timeCellStyle = getTimeCellStyle(hssfworkbook);
			XSSFCellStyle totalFeeCellStyle = getTotalFeeCellStyle(hssfworkbook);
			for (int i = 0; i < dataNum; i++)
			{
				var item = list[i];
				row = sheet.CreateRow(i + 1) as XSSFRow;

				cell = row.CreateCell(0) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.pid);

				cell = row.CreateCell(1) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.ActionName);

				cell = row.CreateCell(2) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.TermIndex);

				cell = row.CreateCell(3) as XSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.FirstActionTime);

				cell = row.CreateCell(4) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue("");

				cell = row.CreateCell(5) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.AuctionCountOfThisTerm);

				cell = row.CreateCell(6) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.IsFinalWinPrize ? "√" : "×");

				//cell = row.CreateCell(6) as XSSFCell;
				//cell.CellStyle = totalFeeCellStyle;
				//cell.SetCellValue(item.TotalFeeYuan);
			}
		}
		/// <summary>
		/// 创建RLData的表头数据
		/// </summary>
		/// <param name="sheet"></param>
		private void CreateRLDataTableHeader(XSSFWorkbook hssfworkbook, XSSFSheet sheet)
		{
			XSSFCellStyle celStyle = getCellStyle(hssfworkbook);
			XSSFRow row = sheet.CreateRow(0) as XSSFRow;

			sheet.SetColumnWidth(0, 20 * 256);
			var cell = row.CreateCell(0);
			cell.SetCellValue("用户id");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(1, 20 * 256);
			cell = row.CreateCell(1);
			cell.SetCellValue("渠道");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(2, 20 * 256);
			cell = row.CreateCell(2);
			cell.SetCellValue("注册时间");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(3, 20 * 256);
			cell = row.CreateCell(3);
			cell.SetCellValue("充值额度");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(4, 20 * 256);
			cell = row.CreateCell(4);
			cell.SetCellValue("第一次充值时间");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(5, 20 * 256);
			cell = row.CreateCell(5);
			cell.SetCellValue("充值次数");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(6, 20 * 256);
			cell = row.CreateCell(6);
			cell.SetCellValue("最后一次登录时间");
			cell.CellStyle = celStyle;
		}

		/// <summary>
		/// RLData数据处理
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <param name="sheet"></param>
		/// <param name="list"></param>
		private void RLDataHandle(XSSFWorkbook hssfworkbook, XSSFSheet sheet, List<DataRLModel> list)
		{
			int dataNum = list.Count(); //数据量
			XSSFRow row;
			XSSFCell cell;
			XSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			XSSFCellStyle timeCellStyle = getTimeCellStyle(hssfworkbook);
			XSSFCellStyle totalFeeCellStyle = getTotalFeeCellStyle(hssfworkbook);
			for (int i = 0; i < dataNum; i++)
			{
				var item = list[i];
				row = sheet.CreateRow(i + 1) as XSSFRow;

				cell = row.CreateCell(0) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.pid);

				cell = row.CreateCell(1) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.channel);

				cell = row.CreateCell(2) as XSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.RegisterTime);

				cell = row.CreateCell(3) as XSSFCell;
				cell.CellStyle = totalFeeCellStyle;
				cell.SetCellValue(item.TotalFeeYuan);

				cell = row.CreateCell(4) as XSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.FirstPayTime);

				cell = row.CreateCell(5) as XSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.PayCount);

				cell = row.CreateCell(6) as XSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.LastLoginTime);
			}
		}


		/// <summary>
		/// 写入文件
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <param name="path"></param>
		private void WriteXlsToFile(XSSFWorkbook hssfworkbook, string path)
		{
			using (FileStream file = new FileStream(path, FileMode.Create))
			{
				hssfworkbook.Write(file);
			}
		}

		/// <summary>
		/// 标准样式
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <returns></returns>
		private XSSFCellStyle getCellStyle(XSSFWorkbook hssfworkbook)
		{
			XSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as XSSFCellStyle;
			cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
			return cellStyle;
		}

		/// <summary>
		/// 时间样式
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <returns></returns>
		private XSSFCellStyle getTimeCellStyle(XSSFWorkbook hssfworkbook)
		{
			XSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			XSSFDataFormat format = hssfworkbook.CreateDataFormat() as XSSFDataFormat;
			cellStyle.DataFormat = format.GetFormat("yyyy.MM.dd HH:mm:ss");
			return cellStyle;
		}
		/// <summary>
		/// 充值额度样式
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <returns></returns>
		private XSSFCellStyle getTotalFeeCellStyle(XSSFWorkbook hssfworkbook)
		{
			XSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			//cellStyle.DataFormat = new XSSFDataFormat(new NPOI.XSSF.Model.StylesTable()).GetBuiltinFormat("0.00");
			cellStyle.DataFormat = new XSSFDataFormat(new NPOI.XSSF.Model.StylesTable()).GetFormat("0.00");
			return cellStyle;
		}


	}
}
