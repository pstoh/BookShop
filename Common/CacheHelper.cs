using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookShop.Common
{
	public abstract class CacheHelper
	{
		/// <summary>
		/// 
		/// 根据key向缓存中取值
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static object Get(String key)
		{
			System.Web.Caching.Cache cache = HttpRuntime.Cache;
			return cache[key];
		}
		/// <summary>
		/// 
		/// 向缓存中添加值
		/// </summary>
		/// <param name="key"></param>
		/// <param name="o"></param>
		public static void Set(String key, object o)
		{
			System.Web.HttpRuntime.Cache[key] = o;
		}
	}
}
