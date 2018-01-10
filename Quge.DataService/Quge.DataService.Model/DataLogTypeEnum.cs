using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model
{
	public enum DataLogTypeEnum
	{
		[Description("登录")]
		Login = 1,
		[Description("支付")]
		Pay,
	}
}
