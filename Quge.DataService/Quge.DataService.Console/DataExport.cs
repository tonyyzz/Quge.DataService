using NPOI.HSSF.UserModel;
using Quge.DataService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Console
{
	public class DataExport
	{
		/// <summary>
		/// 数据导出
		/// </summary>
		/// <param name="list"></param>
		public static void ToExcel(List<LogData> list)
		{
			HSSFWorkbook hssfworkbook = new HSSFWorkbook();
			HSSFSheet moreSheet = hssfworkbook.CreateSheet("data") as HSSFSheet;
			CreateMoreDataTableHeader(hssfworkbook, moreSheet, list.FirstOrDefault());
			MoreDataHandle(list, hssfworkbook, moreSheet);
			string fileName = DateTime.Now.ToString($"{Guid.NewGuid().ToString("N")}");
			fileName += ".xls";
			WriteXlsToFile(hssfworkbook, $"D:\\{fileName}");
		}

		/// <summary>
		/// MoreData导出
		/// </summary>
		private static void MoreDataHandle(List<LogData> list,
			HSSFWorkbook hssfworkbook, HSSFSheet sheet)
		{
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle celStyle = getCellStyle(hssfworkbook);

			for (int i = 0; i < list.Count(); i++)
			{
				var logData = list[i];
				row = sheet.CreateRow(i + 1) as HSSFRow;

				cell = row.CreateCell(0) as HSSFCell;
				cell.CellStyle = celStyle;
				cell.SetCellValue(logData.projName);

				cell = row.CreateCell(1) as HSSFCell;
				cell.CellStyle = celStyle;
				cell.SetCellValue(logData.pId);

				cell = row.CreateCell(2) as HSSFCell;
				cell.CellStyle = celStyle;
				cell.SetCellValue(logData.logType.GetDescription());

				cell = row.CreateCell(3) as HSSFCell;
				cell.CellStyle = celStyle;
				cell.SetCellValue(logData.platform.GetDescription());

				int readyCol = 4;

				Dictionary<string, string> dict = new Dictionary<string, string>();
				switch (logData.logType)
				{
					case DataLogTypeEnum.Login:
						{
							 dict = logData.dataLogin.GetKeyValueDict();
							
						}
						break;
					case DataLogTypeEnum.Pay:
						{
							dict = logData.dataPay.GetKeyValueDict();
						}
						break;
					default:
						break;
				}
				for (int j = 0; j < dict.Count(); j++)
				{
					cell = row.CreateCell(readyCol + j) as HSSFCell;
					cell.CellStyle = celStyle;
					cell.SetCellValue(dict.Values.ToList()[j]);
				}
			}
		}

		/// <summary>
		/// 创建moreData的表头数据
		/// </summary>
		/// <param name="sheet"></param>
		private static void CreateMoreDataTableHeader(HSSFWorkbook hssfworkbook
			, HSSFSheet sheet, LogData logData)
		{
			HSSFCellStyle celStyle = getCellStyle(hssfworkbook);
			HSSFRow row = sheet.CreateRow(0) as HSSFRow;
			var cell = row.CreateCell(0);

			sheet.SetColumnWidth(0, 20 * 256);
			cell = row.CreateCell(0);
			cell.SetCellValue("项目名称");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(1, 20 * 256);
			cell = row.CreateCell(1);
			cell.SetCellValue("用户id");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(2, 20 * 256);
			cell = row.CreateCell(2);
			cell.SetCellValue("日志记录类型");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(3, 20 * 256);
			cell = row.CreateCell(3);
			cell.SetCellValue("平台来源");
			cell.CellStyle = celStyle;

			int readyCol = 4;
			Dictionary<string, string> dict = new Dictionary<string, string>();
			switch (logData.logType)
			{
				case DataLogTypeEnum.Login:
					{
						 dict = logData.dataLogin.GetKeyValueDict(true);
						
					}
					break;
				case DataLogTypeEnum.Pay:
					{
						dict = logData.dataPay.GetKeyValueDict(true);
					}
					break;
				default:
					break;
			}
			for (int i = 0; i < dict.Count(); i++)
			{
				sheet.SetColumnWidth(readyCol + i, 20 * 256);
				cell = row.CreateCell(readyCol + i);
				cell.SetCellValue(dict.Keys.ToList()[i]);
				cell.CellStyle = celStyle;
			}
		}

		/// <summary>
		/// 写入文件
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <param name="path"></param>
		private static void WriteXlsToFile(HSSFWorkbook hssfworkbook, string path)
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
		private static HSSFCellStyle getCellStyle(HSSFWorkbook hssfworkbook)
		{
			HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
			cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
			return cellStyle;
		}

	}
}
