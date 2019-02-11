using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// CheckUserName 的摘要说明
	/// </summary>
	public class CheckUserName : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			String userName = context.Request["userName"];
			if (String.IsNullOrEmpty(userName))
			{
				context.Response.Write("no");
				return;
			}

			if (new BLL.Users().GetModel(userName) == null)
			{
				context.Response.Write("yes");
			}
			else
			{
				context.Response.Write("no");
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