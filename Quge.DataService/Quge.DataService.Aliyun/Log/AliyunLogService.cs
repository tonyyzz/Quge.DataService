﻿using Aliyun.Api.LOG;
using Aliyun.Api.LOG.Data;
using Aliyun.Api.LOG.Request;
using Aliyun.Api.LOG.Response;
using Quge.DataService.Common;
using Quge.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Aliyun.Log
{
	public class AliyunLogService
	{
		public static void WriteLog(Dictionary<string, string> dict)
		{
			LogClient client = new LogClient(AliyunConfig.endpoint, AliyunConfig.accessKeyId, AliyunConfig.accessKeySecret);
			List<LogItem> logs = new List<LogItem>();
			LogItem item = new LogItem();
			item.Time = Const.TimeUInt;
			foreach (var dictItem in dict)
			{
				item.PushBack(dictItem.Key, dictItem.Value);
			}
			logs.Add(item);
			String topic = String.Empty;
			String source = "localhost";

			PutLogsResponse res4 = client.PutLogs(new PutLogsRequest(AliyunConfig.project,
				AliyunConfig.logstore, topic, source, logs));
		}
		public static List<Dictionary<string, string>> ReadLog(DateTime fromTime, DateTime toTime
			, string where = "", int lines = int.MaxValue, int offset = 0)
		{
			List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
			LogClient client = new LogClient(AliyunConfig.endpoint, AliyunConfig.accessKeyId, AliyunConfig.accessKeySecret);
			//查询日志数据
			GetLogsResponse res3 = null;
			do
			{
				res3 = client.GetLogs(new GetLogsRequest(AliyunConfig.project
					, AliyunConfig.logstore
					, DateHelper.GetUtcUIntFromTime(fromTime)
					, DateHelper.GetUtcUIntFromTime(toTime)
					, String.Empty, where, lines, offset, false));
			} while ((res3 != null) && (!res3.IsCompleted()));
			foreach (QueriedLog log in res3.Logs)
			{
				Dictionary<string, string> dict = new Dictionary<string, string>();
				//Console.WriteLine("----{0}, {1}---", log.Time, log.Source);
				for (int i = 0; i < log.Contents.Count; i++)
				{
					//Console.WriteLine("{0} --> {1}", log.Contents[i].Key, log.Contents[i].Value);
					dict.Add(log.Contents[i].Key, log.Contents[i].Value);
				}
				dict.Add("time", log.Time.ToString());
				//LogData logData = dict.SerializeObject().DeserializeObject<LogData>();
				//switch (logData.logType)
				//{
				//	case DataLogTypeEnum.Login:
				//		{
				//			logData.dataLogin = dict.SerializeObject().DeserializeObject<DataLogin>();
				//		}
				//		break;
				//	case DataLogTypeEnum.Pay:
				//		{
				//			logData.dataPay = dict.SerializeObject().DeserializeObject<DataPay>();
				//		}
				//		break;
				//	default:
				//		break;
				//}
				//list.Add(logData);
				list.Add(dict);
			}
			return list;
		}
	}
}
