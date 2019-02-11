using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.CheckUserState
{
	public class CheckUserSession:System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			if (Request.Cookies["cp1"]==null)
			{
				Response.Redirect("/account/Login.aspx?returnurl=");
				return;
			}
			String name = Request.Cookies["cp1"].Value;
			//String pwd = Request.Cookies["cp2"].Value;
			Model.Users model=new BLL.Users().GetModel(name);
			if (model==null||!Common.WebHelper.CheckCookie(model))
			{
				Response.Redirect("/account/Login.aspx?returnurl=");
			}


		}
	}
}