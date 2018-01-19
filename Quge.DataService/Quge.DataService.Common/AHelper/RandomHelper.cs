using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class RandomHelper
	{
		/// <summary>
		/// 产生n个不相等的随机数
		/// </summary>
		/// <param name="randomList">随机数的返回集合</param>
		/// <param name="minVal">生成的随机数可以包含该数字</param>
		/// <param name="maxVal">生成的随机数不包含该数字</param>
		/// <param name="num">产生随机数的个数，num的值要小于等于（maxVal-minVal）</param>
		/// <param name="seedInt">作为产生随机数的种子使用，但不全是作为种子，内部会累加</param>
		/// <returns></returns>
		public static List<int> GetRandomNotEqualList(ref List<int> randomList, int minVal, int maxVal, int num, ref int seedInt)
		{
			if (maxVal <= minVal || num > maxVal - minVal)
			{
				throw new Exception(" RandomHelper.GetRandomNotEqualList() 参数不合法！");
			}
			seedInt++;
			if (seedInt >= int.MaxValue - 2)
			{
				seedInt = 0;
			}
			Random r = new Random(DateTimeHelper.GetTotalSecondsInt() + seedInt);
			randomList.Add(r.Next(minVal, maxVal));
			randomList = randomList.Distinct().ToList();
			if (randomList.Count() < num)
			{
				randomList = GetRandomNotEqualList(ref randomList, minVal, maxVal, num, ref seedInt);
			}
			return randomList;
		}
	}
}
