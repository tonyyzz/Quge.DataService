using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.DataService.Model.Export
{
	public class DataAuctModel
	{
		/// <summary>
		/// 用户Id
		/// </summary>
		public string pid { get; set; }
		/// <summary>
		/// 该期出拍商品名称
		/// </summary>
		public string ActionName { get; set; }
		/// <summary>
		/// 该商品的期数
		/// </summary>
		public int TermIndex { get; set; }
		/// <summary>
		/// 该期该商品第一次出拍时间
		/// </summary>
		public DateTime FirstActionTime { get; set; }
		/// <summary>
		/// 用户在该期该商品总共出拍的次数
		/// </summary>
		public int AuctionCountOfThisTerm { get; set; }
		/// <summary>
		/// 用户在该期该商品最终是否中奖
		/// </summary>
		public bool IsFinalWinPrize { get; set; }
	}
}
