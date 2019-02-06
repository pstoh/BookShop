using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// CheckValidateCode 的摘要说明
	/// </summary>
	public class CheckValidateCode : IHttpHandler, IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			//String userCode = context.Request["ValidateCode"];
			//String sessionCode = context.Session["ValidateCode"] as String;
			if ( Common.ValidateCode.CheckValidateCode())
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