using Quge.DataService.Aliyun.Log;
using Quge.DataService.Common;
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
		static void Main(string[] args)
		{
			#region 写入日志
			//string projName = "auction";
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
			List<LogData> logList = AliyunLogService.ReadLog(DateTime.Now.AddHours(-10), DateTime.Now
				, Int32.MaxValue, "fee");

			DataExport.ToExcel(logList);
			#endregion
		}
	}
}
