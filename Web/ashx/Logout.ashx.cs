using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// Logout 的摘要说明
	/// </summary>
	public class Logout : IHttpHandler,System.Web .SessionState.IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			if (context.Session["UserInfo"] != null)
			{
				context.Session["UserInfo"] = null;
				context.Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
				context.Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
				context.Response.Write("OK");
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