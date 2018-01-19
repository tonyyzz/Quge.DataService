using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	/// <summary>
	/// 对象帮助类
	/// </summary>
	public static class ObjectHelper
	{
		/// <summary>
		/// 对象深拷贝
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(this T obj) where T : class
		{
			return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
		}

		public static string SerializeObject<T>(this T obj) where T : class
		{
			return JsonConvert.SerializeObject(obj);
		}

		public static T DeserializeObject<T>(this string str)
		{
			return JsonConvert.DeserializeObject<T>(str);
		}

		public static Dictionary<string, string> GetKeyValueDict<T>(this T obj,bool isToDesc = false) where T : class
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			var allProoKeys = obj.GetAllPropKeys();
			foreach (var propKeyName in allProoKeys)
			{
				Type type = obj.GetType(); //获取类型
				Reflection.PropertyInfo propertyInfo = type.GetProperty(propKeyName); //获取指定名称的属性
				var value = propertyInfo.GetValue(obj, null).ToString(); //获取属性值

				string desc = "";

				if (isToDesc)
				{
					object[] objs = typeof(T).GetProperty(propKeyName).GetCustomAttributes(typeof(DescriptionAttribute), true);
					if (objs.Length > 0)
					{
						desc = ((DescriptionAttribute)objs[0]).Description;
					}
					else
					{
						desc = propKeyName;
					}
				}
				else
				{
					desc = propKeyName;
				}

				dict.Add(desc, value);
			}
			return dict;
		}
	}
}
