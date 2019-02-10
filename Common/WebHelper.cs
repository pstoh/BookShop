using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookShop.Common
{
	public abstract class WebHelper
	{
		public static bool CheckCookie(Model.user model)
		{
			bool flag = false;
			HttpContext context = HttpContext.Current;
			String pwd = context.Request.Cookies["cp2"] == null ? null : context.Request.Cookies["cp2"].Value;
			String name = context.Request.Cookies["cp1"] == null ? null : context.Request.Cookies["cp1"].Value;
			if (pwd != null && name!=null)
			{
				if (model.LoginID == name && model.password == pwd)
				{
					context.Session["userInfo"] = model;
				flag = true;
				}
			}
			return flag;
		}
	}
}
