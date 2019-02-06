using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// ValidateCode 的摘要说明
	/// </summary>
	public class ValidateCode : IHttpHandler, IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			Common.ValidateCode vc=new Common.ValidateCode();
			string code = vc.CreateValidateCode(4);
			vc.CreateValidateGraphic(code, context);
			HttpContext.Current.Session.Add("ValidateCode", code);
			Console.WriteLine(code);
			
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