using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model
{
	public class DataLogin //: DataBase
	{
		//[Description("登录时间")]
		//public uint time { get { return Const.TimeUInt; } }
		[Description("登录状态")]
		public int state { get; set; }
	}
}
