﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class EnumHelper
	{
		public static string GetDescription<T>(this T en) where T : struct
		{
			Type type = en.GetType();
			MemberInfo[] memInfo = type.GetMember(en.ToString());
			if (memInfo != null && memInfo.Length > 0)
			{
				object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
				if (attrs != null && attrs.Length > 0)
					return ((DescriptionAttribute)attrs[0]).Description;
			}
			return en.ToString();
		}

	}
}
