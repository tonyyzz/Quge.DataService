using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model
{
	public class DataPay// : DataBase
	{
		/// <summary>
		/// 充值费用（单位：分）
		/// </summary>
		[Description("充值费用")]
		public int fee { get; set; }
	}
}
