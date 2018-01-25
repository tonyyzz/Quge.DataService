using NPOI.HSSF.UserModel;
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
			DateTime timeRight = dtpRegisterRight.Value;
			if ((timeRight - timeLeft).TotalSeconds < 0)
			{
				MessageBox.Show("请选择正确的时间段！");
				return;
			}


			string path = "";
			saveFileDialogMore.InitialDirectory = @"D:\";
			saveFileDialogMore.FileName = $"{projName}_所有用户的详细信息_{DateTime.Now.Ticks}";
			saveFileDialogMore.DefaultExt = "xls";
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
				GetLog(ref registerDictList, timeLeft, timeRight, projName, DataLogTypeEnum.Register, 1);

				List<Dictionary<string, string>> loginDictList = new List<Dictionary<string, string>>();
				GetLog(ref loginDictList, timeLeft, DateTime.Now, projName, DataLogTypeEnum.Login, 1);

				List<Dictionary<string, string>> payDictList = new List<Dictionary<string, string>>();
				GetLog(ref payDictList, timeLeft, DateTime.Now, projName, DataLogTypeEnum.Pay, 1);

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


				HSSFWorkbook hssfworkbook = new HSSFWorkbook();
				HSSFSheet sheet = hssfworkbook.CreateSheet("RLData") as HSSFSheet;

				CreateRLDataTableHeader(hssfworkbook, sheet);
				RLDataHandle(hssfworkbook, sheet, dataList);
				WriteXlsToFile(hssfworkbook, path);

				BeginInvoke(new Action(() =>
				{
					lblStateMore.Text = "导出成功！";
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
			DateTime timeLeft = dtpAuctionLeft.Value.Date;
			DateTime timeRight = dtpAuctionRight.Value;
			if ((timeRight - timeLeft).TotalSeconds < 0)
			{
				MessageBox.Show("请选择正确的时间段！");
				return;
			}


			string path = "";
			saveFileDialogLess.InitialDirectory = @"D:\";
			saveFileDialogLess.FileName = $"{projName}_所有用户的竞拍信息_{DateTime.Now.Ticks}";
			saveFileDialogLess.DefaultExt = "xls";
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
				GetLog(ref auctionDictList, timeLeft, timeRight, projName, DataLogTypeEnum.Auction, 1);

				List<Dictionary<string, string>> auctionPrizeDictList = new List<Dictionary<string, string>>();
				GetLog(ref auctionPrizeDictList, timeLeft, timeRight, projName, DataLogTypeEnum.AuctionPrize, 1);

				//List<Dictionary<string, string>> payDictList = new List<Dictionary<string, string>>();
				//GetLog(ref payDictList, timeLeft, timeRight, projName, DataLogTypeEnum.Pay, 1);

				var auctionModelList = auctionDictList.JsonSerialize().JsonDeserialize<List<AuctionModel>>();
				var auctionPrizeModelList = auctionPrizeDictList.JsonSerialize().JsonDeserialize<List<AuctionModel>>();
				//var payModelList = payDictList.JsonSerialize().JsonDeserialize<List<PayModel>>();



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

					//if (prizeInfo != null)
					//{
					//	item.IsFinalWinPrize = true;
					//}
					//var payInfoLi = payModelList.Where(m => m.pidInt == item.pid);
					//if (payInfoLi.Any())
					//{
					//	item.TotalFeeYuan = payInfoLi.Sum(m => m.FeeYuan);
					//}
				}

				HSSFWorkbook hssfworkbook = new HSSFWorkbook();
				HSSFSheet sheet = hssfworkbook.CreateSheet("AuctionData") as HSSFSheet;

				CreateAuctDataTableHeader(hssfworkbook, sheet);
				AuctDataHandle(hssfworkbook, sheet, dataList);
				WriteXlsToFile(hssfworkbook, path);

				BeginInvoke(new Action(() =>
				{
					lblStateLess.Text = "导出成功！";
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
		private void GetLog(ref List<Dictionary<string, string>> list,
			DateTime timeLeft, DateTime timeRight,
			string projName, DataLogTypeEnum logTypeEnum, int pageIndex)
		{
			int singleMexCount = 100;
			var result = AliyunLogService.ReadLog(timeLeft, timeRight,
				$"projName:{projName} and logType:{(int)logTypeEnum}", offset: (pageIndex - 1) * singleMexCount);
			if (result.Any())
			{
				list.AddRange(result);
				GetLog(ref list, timeLeft, timeRight, projName, logTypeEnum, pageIndex + 1);
			}
		}


		private void CreateAuctDataTableHeader(HSSFWorkbook hssfworkbook, HSSFSheet sheet)
		{
			HSSFCellStyle celStyle = getCellStyle(hssfworkbook);
			HSSFRow row = sheet.CreateRow(0) as HSSFRow;

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

		private void AuctDataHandle(HSSFWorkbook hssfworkbook, HSSFSheet sheet, List<DataAuctModel> list)
		{
			int dataNum = list.Count(); //数据量
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			HSSFCellStyle timeCellStyle = getTimeCellStyle(hssfworkbook);
			HSSFCellStyle totalFeeCellStyle = getTotalFeeCellStyle(hssfworkbook);
			for (int i = 0; i < dataNum; i++)
			{
				var item = list[i];
				row = sheet.CreateRow(i + 1) as HSSFRow;

				cell = row.CreateCell(0) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.pid);

				cell = row.CreateCell(1) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.ActionName);

				cell = row.CreateCell(2) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.TermIndex);

				cell = row.CreateCell(3) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.FirstActionTime);

				cell = row.CreateCell(4) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue("");

				cell = row.CreateCell(5) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.AuctionCountOfThisTerm);

				cell = row.CreateCell(6) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.IsFinalWinPrize ? "√" : "×");

				//cell = row.CreateCell(6) as HSSFCell;
				//cell.CellStyle = totalFeeCellStyle;
				//cell.SetCellValue(item.TotalFeeYuan);
			}
		}
		/// <summary>
		/// 创建RLData的表头数据
		/// </summary>
		/// <param name="sheet"></param>
		private void CreateRLDataTableHeader(HSSFWorkbook hssfworkbook, HSSFSheet sheet)
		{
			HSSFCellStyle celStyle = getCellStyle(hssfworkbook);
			HSSFRow row = sheet.CreateRow(0) as HSSFRow;

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
		private void RLDataHandle(HSSFWorkbook hssfworkbook, HSSFSheet sheet, List<DataRLModel> list)
		{
			int dataNum = list.Count(); //数据量
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			HSSFCellStyle timeCellStyle = getTimeCellStyle(hssfworkbook);
			HSSFCellStyle totalFeeCellStyle = getTotalFeeCellStyle(hssfworkbook);
			for (int i = 0; i < dataNum; i++)
			{
				var item = list[i];
				row = sheet.CreateRow(i + 1) as HSSFRow;

				cell = row.CreateCell(0) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.pid);

				cell = row.CreateCell(1) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.channel);

				cell = row.CreateCell(2) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.RegisterTime);

				cell = row.CreateCell(3) as HSSFCell;
				cell.CellStyle = totalFeeCellStyle;
				cell.SetCellValue(item.TotalFeeYuan);

				cell = row.CreateCell(4) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.FirstPayTime);

				cell = row.CreateCell(5) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.PayCount);

				cell = row.CreateCell(6) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.LastLoginTime);
			}
		}


		/// <summary>
		/// 写入文件
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <param name="path"></param>
		private void WriteXlsToFile(HSSFWorkbook hssfworkbook, string path)
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
		private HSSFCellStyle getCellStyle(HSSFWorkbook hssfworkbook)
		{
			HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
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
		private HSSFCellStyle getTimeCellStyle(HSSFWorkbook hssfworkbook)
		{
			HSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
			cellStyle.DataFormat = format.GetFormat("yyyy.MM.dd HH:mm:ss");
			return cellStyle;
		}
		/// <summary>
		/// 充值额度样式
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <returns></returns>
		private HSSFCellStyle getTotalFeeCellStyle(HSSFWorkbook hssfworkbook)
		{
			HSSFCellStyle cellStyle = getCellStyle(hssfworkbook);
			cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
			return cellStyle;
		}


	}
}
