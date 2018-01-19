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
		[Description("注册")]
		Register = 1,
		[Description("登录")]
		Login,
		[Description("支付")]
		Pay,
		[Description("竞拍")]
		Auction,
		[Description("竞拍中奖记录")]
		AuctionPrize,
	}
}
