using BookShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.BLL
{
	public partial class Settings
	{
		public Model.Settings GetModel(String key)
		{
			//return dal.GetModel(key);
			Object obj = CacheHelper.Get("Settings_" + key);
			Model.Settings setting = null;

			if (obj == null)
			{
				setting = dal.GetModel(key);
				CacheHelper.Set("Settings_" + key, setting);
			}
			else
			{
				setting = obj as Model.Settings;
			}
			return setting;
		}
	}
}
