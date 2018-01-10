using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model
{
	public enum DataPlatformEnum
	{
		[Description("安卓")]
		Android = 1,
		[Description("苹果")]
		IOS,
	}
}
