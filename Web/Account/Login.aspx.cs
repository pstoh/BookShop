using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.Account
{
	public partial class Login : System.Web.UI.Page
	{
		public String Msg { get; set; }
		public String ReturnUrl{ get; set; }
		private BLL.Users UserService = new BLL.Users();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.HttpMethod.ToLower() == "post")
			{
				UserLogin();
				return;
			}

			if (Request["returnurl  "] != "")
			{
				this.ReturnUrl = Request["returnurl"];
			}

			if (Session["userInfo"] != null)
			{
				Response.Redirect("/UserInfoManager/UserCenter.aspx");
				return;
			}

			if (Request.Cookies["cp1"] != null)
			{
				String name = Request.Cookies["cp1"].Value;
				Model.Users model = UserService.GetModel(name);
				if (Common.WebHelper.CheckCookie(model))
				{
					Response.Redirect("/UserInfoManager/UserCenter.aspx");
				}
			}
		}
		/// <summary>
		/// 
		/// 用户登录
		/// </summary>
		private void UserLogin()
		{
			String userName = Request["userName"];
			String pwd = Request["password"];
			if (userName != "" && pwd != "")
			{
				pwd = Common.MD5Helper.GetMD5ByString(pwd);
				pwd = Common.MD5Helper.GetMD5ByString(pwd);
				Model.Users model = UserService.GetModel(userName, pwd);
				if (model == null)
				{
					Msg = "用户名密码错误!!";
					return;
				}

				Session["userInfo"] = model;
				//是否保存Cookie
				if (!String.IsNullOrEmpty(Request["chkRember"]))
				{
					Response.Cookies.Add(new HttpCookie("cp1", userName)
					{
						Expires = DateTime.Now.AddDays(7)
					});
					Response.Cookies.Add(new HttpCookie("cp2",  pwd)
					{
						Expires = DateTime.Now.AddDays(7)
					});
				}
				//跳转url
				if (Request["returnurl"] != "")
				{
					Response.Redirect(Request["returnurl"]);
					return;
				}
				Response.Redirect("/UserInfoManager/UserCenter.aspx");
				{

				}
			}
			else
			{
				Msg = "用户名密码不能为空!";
			}
		}
	}
}