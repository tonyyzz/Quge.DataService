using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model
{
	public  class DataRequest
	{
		public string projName { get; set; }
		public string pId { get; set; }
		public int typeInt { get; set; }
		public int platformInt { get; set; }
		public string dataStr { get; set; }
	}
}
