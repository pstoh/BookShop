using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// CheckMail 的摘要说明
	/// </summary>
	public class CheckMail : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			String mail = context.Request["mail"];
			if (new BLL.Users().GetModelByMail(mail) == null)
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