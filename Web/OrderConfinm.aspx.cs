﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
	public partial class OrderConfinm : CheckUserState.CheckUserSession
	{
		public Model.Users CurrentUser { get; set; }
		public string StrHtml { get; set; }
		public decimal TotalMoney { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			CurrentUser = (Model.Users)Session["userInfo"];
			if (!IsPostBack)
			{
				BindCartList();
			}
		}

		private void BindCartList()
		{
			List<Model.Cart> cartList = new BLL.Cart().GetModelList(CurrentUser.Id);
			if (cartList.Count < 1)
			{
				Response.Redirect("/BookList.aspx");
				return;
			}

			StringBuilder sb = new StringBuilder();
			decimal totalMoney = 0;
			foreach (Model.Cart cartModel in cartList)
			{
				sb.Append("<tr class=\"align_Center\">");
				sb.Append("<td style=\"PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 5px\">" + cartModel.Book.Id + "</td>");
				sb.Append("<td class=align_Left><a onmouseover=\"\" onmouseout=\"\" onclick=\"\" href='#' target=\"_blank\" >" + cartModel.Book.Title + "</a></td>");

				sb.Append("<td><span class=\"price\">￥" + cartModel.Book.UnitPrice.ToString("0.00") + "</span></td>");
				sb.Append("<td>" + cartModel.Count + "</td></tr>");
				totalMoney = totalMoney + (cartModel.Count * cartModel.Book.UnitPrice);
			}
			StrHtml = sb.ToString();
			TotalMoney = totalMoney;
		}
	}
}