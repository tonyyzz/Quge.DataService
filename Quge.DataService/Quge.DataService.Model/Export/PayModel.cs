﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model.Export
{
	public class PayModel
	{
		public string projName { get; set; }
		public string logType { get; set; }
		public string pid { get; set; }
		public string fee { get; set; }

		public double FeeYuan
		{
			get
			{
				double f = 0;
				//兼容
				if (fee.Contains("."))
				{
					f = Convert.ToDouble(fee) * 100;
				}
				else
				{
					f = Convert.ToDouble(fee);
				}
				return Convert.ToInt32(f.ToString("0")) * 1.0 / 100;
			}
		}


		public string time { get; set; }

		public DateTime Time
		{
			get
			{
				return DateTimeHelper.GetTimeFromUtcUInt(Convert.ToUInt32(time));
			}
		}
		public int pidInt
		{
			get
			{
				return Convert.ToInt32(pid);
			}
		}
	}
}
