using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model
{
	public class LogData
	{
		public string projName { get; set; }
		public string pId { get; set; }
		public DataLogTypeEnum logType { get; set; }
		public DataPlatformEnum platform { get; set; }
		public DataLogin dataLogin { get; set; }
		public DataPay dataPay { get; set; }
	}
}
