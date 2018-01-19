using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace System
{
	/// <summary>
	/// 对象帮助类
	/// </summary>
	public static class ObjectHelper
	{
		/// <summary>
		/// 对象深拷贝（利用Json序列化与反序列化实现）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(this T obj) where T : class
		{
			return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
		}

		#region Json序列化与反序列化
		/// <summary>
		/// Json序列化为字符串
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonObj"></param>
		/// <returns></returns>
		public static string JsonSerialize<T>(this T jsonObj) where T : class
		{
			return JsonConvert.SerializeObject(jsonObj);
		}

		/// <summary>
		/// Json反序列化为对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonStr"></param>
		/// <returns></returns>
		public static T JsonDeserialize<T>(this string jsonStr)
		{
			return JsonConvert.DeserializeObject<T>(jsonStr);
		}
		#endregion

		#region Xml序列化与反序列化
		/// <summary>
		/// Xml序列化为字符串
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlObj"></param>
		/// <returns></returns>
		public static string XmlSerialize<T>(this T xmlObj)
		{
			using (var memory = new MemoryStream())
			{
				var serial = new XmlSerializer(xmlObj.GetType());
				var setting = new XmlWriterSettings()
				{
					Indent = false,
					OmitXmlDeclaration = true,
					Encoding = Encoding.UTF8
				};
				var writer = XmlWriter.Create(memory, setting);
				var space = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) });
				serial.Serialize(writer, xmlObj, space);
				memory.Position = 0;
				using (var reader = new StreamReader(memory))
				{
					return reader.ReadToEnd();
				}
			}
		}
		/// <summary>
		/// Xml反序列化为对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static T XmlDeserialize<T>(this Stream stream) where T : class
		{
			return new XmlSerializer(typeof(T)).Deserialize(stream) as T;
		}
		#endregion

		public static Dictionary<string, string> GetKeyValueDict<T>(this T obj, bool isToDesc = false) where T : class
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
