using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// ProcessCart 的摘要说明
	/// </summary>
	public class ProcessCart : IHttpHandler,System.Web.SessionState.IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			//1.判断用户是否登陆
			Model.Users userModel = new BLL.Users().GetModel(context.Request.Cookies["cp1"].Value);
			if (Common.WebHelper.CheckCookie(userModel) == false)
			{
				context.Response.Write("no");
				return;
			}

			//2.检查该商品数据库中是否存在
			int bookId = int.Parse(context.Request["bookId"] ?? "0");
			Model.Books book = new BLL.Books().GetModel(bookId);
			if (book == null)
			{
				context.Response.Write("no");
				return;
			}

			//3.将商品添加到购物车
			Model.Users user=(Model.Users)context.Session["userInfo"];
			BLL.Cart cartServer=new BLL.Cart();
			Model.Cart cart = cartServer.GetCart(user.Id, bookId);
			if (cart != null)
			{
				cart.Count++;
				cartServer.Update(cart);
			}
			else
			{
				cart = new Model.Cart();
				cart.Count = 1;
				cart.Book = book;
				cart.User = user;
				cartServer.Add(cart);
			}
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