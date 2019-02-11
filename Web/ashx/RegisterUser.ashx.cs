using BookShop.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// RegisterUser 的摘要说明
	/// </summary>
	public class RegisterUser : IHttpHandler,System.Web.SessionState.IReadOnlySessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//1.校验验证码
			if (Common.ValidateCode.CheckValidateCode() == false)
			{
				context.Response.Write("no:验证码错误!");
				return;
			}


			//2.注册
			String msg;
			if (UserRegister(context, out msg))
			{
				context.Response.Write("yes:" + msg);
			}
			else
			{
				context.Response.Write("no:" + msg);
			}
		}
		/// <summary>
		/// 
		/// 用户注册
		/// </summary>
		/// <param name="context"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		private bool UserRegister(HttpContext context, out string msg)
		{
			String userName = context.Request["txtName"];
			String userRealName = context.Request["txtRealName"];
			String email = context.Request["txtMail"];
			String pwd = context.Request["txtPwd"];
			String confirmPwd = context.Request["txtConfirmPwd"];
			String address = context.Request["txtAddress"];
			String phone = context.Request["txtPhone"];
			if (Regex.IsMatch(userName, "^(\\w+)$") == false)
			{
				msg = "用户名格式错误!";
				return false;
			}

			if (Regex.IsMatch(email, "\\w+@\\w+(\\.\\w+)+") == false)
			{
				msg = "邮箱格式错误!";
				return false;
			}

			if (String.IsNullOrEmpty(pwd))
			{
				msg = "密码不能为空!";
				return false;
			}

			if (pwd != confirmPwd)
			{
				msg = "密码不一致!";
				return false;
			}

			var model = new Model.Users()
			{
				Name = userRealName,
				LoginId = userName,
				Address = address,
				LoginPwd = Common.MD5Helper.GetMD5ByString(Common.MD5Helper.GetMD5ByString(pwd)),
				Mail = email,
				Phone = phone,
			};
			model.State.Id = Convert.ToInt32(UserStateEnum.UserNormarl);
			new BLL.Users().Add(model);
			msg = "OK";
			return true;
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