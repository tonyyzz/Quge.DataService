using Quge.DataService.Aliyun.Log;
using Quge.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Console
{
	class Program
	{

		private static string projName = "test";
		private static int dataCount = 100;

		static void Main(string[] args)
		{
			#region 写入日志
			//string projName = "yTest";
			//string pId = "100001";
			//int typeInt = 1;
			//int platformInt = 1;
			//string dataStr = @"{state:1}";

			//for (int i = 0; i < 100; i++)
			//{
			//	pId = $"10000{(i + 1).ToString().PadLeft(4, '0')}";
			//	typeInt = 2;
			//	platformInt = i % 2 + 1;
			//	//dataStr = $"{{state:{i % 2 + 1}}}";
			//	dataStr = $"{{fee:{i * 100}}}";

			//	DataRequest dataRequest = new DataRequest()
			//	{
			//		projName = projName,
			//		pId = pId,
			//		typeInt = typeInt,
			//		platformInt = platformInt,
			//		dataStr = dataStr
			//	};

			//	//记录日志
			//	LogData logData = new LogData();
			//	logData.SetData(dataRequest);

			//	var dict = logData.GetDictByType((DataLogTypeEnum)typeInt);

			//	AliyunLogService.WriteLog(dict);
			//}
			//System.Console.WriteLine("写入成功");
			//System.Console.ReadKey();
			#endregion

			#region 读取日志
			//List<LogData> logList = AliyunLogService.ReadLog(DateTime.Now.AddHours(-10), DateTime.Now
			//	, Int32.MaxValue, "fee");

			//DataExport.ToExcel(logList);


			#endregion
			//日志模拟


			#region 日志模拟

			//注册
			//for (int i = 0; i < dataCount; i++)
			//{
			//	var dict = GetInitDict(DataLogTypeEnum.Register);
			//	dict.Add("pid", $"10000{(i + 1).ToString().PadLeft(5, '0')}");
			//	dict.Add("channel", i % 3 == 0 ? "小米" : i % 3 == 1 ? "华为" : "vivo");
			//	AliyunLogService.WriteLog(dict);
			//}

			//登录
			//for (int i = 0; i < dataCount; i++)
			//{
			//	var dict = GetInitDict(DataLogTypeEnum.Login);
			//	dict.Add("pid", $"10000{(i + 1).ToString().PadLeft(5, '0')}");
			//	AliyunLogService.WriteLog(dict);
			//}

			//支付
			//for (int i = 0; i < dataCount; i++)
			//{
			//	var dict = GetInitDict(DataLogTypeEnum.Pay);
			//	dict.Add("pid", $"10000{(i + 1).ToString().PadLeft(5, '0')}");
			//	dict.Add("fee", (50 + i % 5).ToString());
			//	AliyunLogService.WriteLog(dict);
			//}

			//竞拍
			for (int i = 0; i < dataCount; i++)
			{
				var dict = GetInitDict(DataLogTypeEnum.Auction);
				dict.Add("pid", $"10000{(i + 1).ToString().PadLeft(5, '0')}");
				dict.Add("termIndex", ((i % 10) + 1).ToString());
				dict.Add("auctionName", $"Goods{i.ToString().PadLeft(5, '0')}");
				dict.Add("isWinPrize", i % 3 == 0 ? "1" : "0");
				AliyunLogService.WriteLog(dict);
			}

			#endregion
			System.Console.WriteLine("模拟成功！");
			System.Console.ReadKey();


			
		}
		private static Dictionary<string, string> GetInitDict(DataLogTypeEnum logType)
		{
			var dict = new Dictionary<string, string>();
			dict.Add("projName", projName);
			dict.Add("logType", ((int)logType).ToString());
			return dict;
		}
	}
}
