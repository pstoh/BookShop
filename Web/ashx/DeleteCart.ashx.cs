using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// DeleteCart 的摘要说明
	/// </summary>
	public class DeleteCart : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			int cartId = Convert.ToInt32(context.Request["cartId"]);
			new BLL.Cart().Delete(cartId);
			context.Response.Write("OK");
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