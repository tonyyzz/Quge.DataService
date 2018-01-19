using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model.Export
{
	public class RegisterModel
	{
		public string projName { get; set; }
		public string logType { get; set; }
		public string pid { get; set; }
		public string channel { get; set; }


		public string time { get; set; }

		public DateTime Time
		{
			get
			{
				return DateTimeHelper.GetTimeFromUtcUInt(Convert.ToUInt32(time));
			}
		}
	}
}
