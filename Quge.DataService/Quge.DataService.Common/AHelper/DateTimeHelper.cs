using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class DateTimeHelper
	{
		/// <summary>
		/// 输出默认格式的日期字符串（yyyy-MM-dd HH:mm:ss）
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public static string ToStr(this DateTime time)
		{
			return time.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static DateTime GetTimeFromUtcUInt(uint timeUint)
		{
			return DateTimeConst.unixTimestampZeroPoint.Add(TimeSpan.FromSeconds(timeUint)).AddHours(8);
		}

		public static uint GetUtcUIntFromTime(DateTime time)
		{
			return (uint)((time.AddHours(-8) - DateTimeConst.unixTimestampZeroPoint).TotalSeconds);
		}

		public static int GetTotalSecondsInt()
		{
			return Convert.ToInt32((DateTime.Now - new DateTime(DateTime.Now.Year, 1, 1)).TotalSeconds);
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

		public class DateTimeConst
		{
			public static DateTime unixTimestampZeroPoint = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc);
			public static uint TimeUInt = (uint)((DateTime.UtcNow - unixTimestampZeroPoint).TotalSeconds);
		}

		public static DateTime GetDeaultTime()
		{
			return new DateTime(1900, 1, 1);
		}
	}
}
