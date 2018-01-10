using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Common
{
	public class Const
	{
		public static DateTime unixTimestampZeroPoint = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc);
		public static uint TimeUInt = (uint)((DateTime.UtcNow - unixTimestampZeroPoint).TotalSeconds);
	}
}
