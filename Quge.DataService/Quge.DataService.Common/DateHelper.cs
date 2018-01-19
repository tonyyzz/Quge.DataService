using Quge.DataService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class DateHelper
	{
		public static int GetTotalSecondsInt()
		{
			return Convert.ToInt32((DateTime.Now - new DateTime(DateTime.Now.Year, 1, 1)).TotalSeconds);
		}

		/// <summary>
		/// 转化成特定格式的时间字符串（yyyy-MM-dd HH:mm:ss）
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public static string ToStr(this DateTime time)
		{
			return time.ToString("yyyy-MM-dd HH:mm:ss");
		}
		/// 获取时间戳
		/// </summary>
		/// <returns></returns>
		public static string GetTimeStamp(this System.DateTime time)
		{
			long ts = ConvertDateTimeToInt(time);
			return ts.ToString();
		}
		/// <summary>  
		/// 将c# DateTime时间格式转换为Unix时间戳格式  
		/// </summary>  
		/// <param name="time">时间</param>  
		/// <returns>long</returns>  
		public static long ConvertDateTimeToInt(System.DateTime time)
		{
			System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
			long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
			return t;
		}

		public static DateTime GetTimeFromUtcUInt(uint timeUint)
		{
			return Const.unixTimestampZeroPoint.Add(TimeSpan.FromSeconds(timeUint)).AddHours(8);
		}

		public static uint GetUtcUIntFromTime(DateTime time)
		{
			return (uint)((time.AddHours(-8) - Const.unixTimestampZeroPoint).TotalSeconds);
		}
	}
}
