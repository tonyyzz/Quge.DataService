using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model.Export
{
	public class AuctionModel
	{
		public string projName { get; set; }
		public string logType { get; set; }
		public string pid { get; set; }
		public string auctionName { get; set; }
		public string termIndex { get; set; }
		public string isWinPrize { get; set; }

		public bool IsWinPrize
		{
			get
			{
				if (isWinPrize == "1")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public int TermIndexInt
		{
			get
			{
				return Convert.ToInt32(termIndex);
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
