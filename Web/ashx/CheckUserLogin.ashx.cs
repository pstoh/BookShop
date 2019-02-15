using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// CheckUserLogin 的摘要说明
	/// </summary>
	public class CheckUserLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello orld");
			if (context.Request["cp1"]==null){
				context.Response.Write("no:用户未登录");
				return;
			}

			Model.Users  model = new BLL.Users().GetModel(context.Request.Cookies["cp1"].Value);
			if (Common.WebHelper.CheckCookie(model))
			{
				context.Response.Write("OK:欢迎" + model.LoginId);
			}
			else
			{
				context.Response.Write("no:用户未登录");
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}