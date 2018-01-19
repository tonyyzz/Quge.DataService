using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
	public class IPAddressHelper
	{
		private static string url = "http://1212.ip138.com/ic.asp";
		/// <summary>
		/// 获取外网Ip地址
		/// </summary>
		/// <returns></returns>
		public static string GetOuterNetIP()
		{
			//重复获取n次
			int index = 1;
			string ipStr = "";
			while (index <= 10)
			{
				try
				{
					Uri uri = new Uri(url);
					HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
					req.Method = "get";
					using (Stream s = req.GetResponse().GetResponseStream())
					{
						using (StreamReader reader = new StreamReader(s))
						{
							string str = reader.ReadToEnd();
							Match m = Regex.Match(str, @"\[(?<IP>[0-9\.]*)\]");
							ipStr = m.Groups[1].Value;
							break;
						}
					}
				}
				catch (Exception)
				{
					index += 1;
				}
			}
			return ipStr;
		}
	}
}
