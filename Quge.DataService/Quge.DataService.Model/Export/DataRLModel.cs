using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model.Export
{
	public class DataRLModel
	{
		public int pid { get; set; }
		public string channel { get; set; }
		public DateTime RegisterTime { get; set; }
		public double TotalFeeYuan { get; set; }
		public DateTime FirstPayTime { get; set; }
		public int PayCount { get; set; }
		public DateTime LastLoginTime { get; set; }
	}
}
