using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
	public static class StringHelper
	{
		/// <summary>
		/// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
		/// <summary>
		/// 指示指定的字符串是 null、空还是仅由空白字符组成。
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}

		/// <summary>
		/// 去除字符串前后空格，并且如果中间有多个相邻空格，只保留一个
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string GetRemoveExcessSpaceStr(this string str)
		{
			return Regex.Replace(str.Trim(), @"\s+", " ");
		}
	}
}
