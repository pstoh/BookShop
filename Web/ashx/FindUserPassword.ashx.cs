using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// FindUserPassword 的摘要说明
	/// </summary>
	public class FindUserPassword : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			String mail = context.Request["mail"];
			BLL.Users UserService = new BLL.Users();
			if (UserService.GetModelByMail(mail) != null)
			{
				UserService.SendMail(mail);
				context.Response.Write("OK");
			}
			else
			{
				context.Response.Write("No");
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