using Quge.DataService.Aliyun.Log;
using Quge.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Console
{
	public static class DataFactory
	{
		public static void SetData(this LogData logData
			, DataRequest dataRequest)
		{
			switch ((DataLogTypeEnum)dataRequest.typeInt)
			{
				case DataLogTypeEnum.Login:
					{
						logData.dataLogin = dataRequest.dataStr.JsonDeserialize<DataLogin>();
					}
					break;
				case DataLogTypeEnum.Pay:
					{
						logData.dataPay = dataRequest.dataStr.JsonDeserialize<DataPay>();
					}
					break;
				default:
					break;
			}
			logData.projName = dataRequest.projName;
			logData.pId = dataRequest.pId;
			logData.logType = (DataLogTypeEnum)dataRequest.typeInt;
			logData.platform = (DataPlatformEnum)dataRequest.platformInt;
		}

		public static Dictionary<string, string> GetDictByType(this LogData logData
			, DataLogTypeEnum logDataTypeEnum)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			switch (logDataTypeEnum)
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
			dict.Add("projName", logData.projName);
			dict.Add("pId", logData.pId);
			dict.Add("logType", ((int)logData.logType).ToString());
			dict.Add("platform", ((int)logData.platform).ToString());
			return dict;
		}
	}
}
