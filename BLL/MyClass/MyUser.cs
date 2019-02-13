using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookShop.BLL
{
	public partial class Users
	{
		/// <summary>
		/// 
		/// 给定userName获取user实体
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public Model.Users GetModel(String userName)
		{
			return dal.GetModel(userName);
		}

		public Model.Users GetModel(String userName,String pwd)
		{
			return dal.GetModel(userName,pwd);
		}

		public Model.Users GetModelByMail(String mail)
		{
			return dal.GetModelByMail(mail);
		}

		public void SendMail(String mail)
		{
			//1.产生新密码
			//2.将新密码发给用户
			//3.更新数据库
			String newPwd = Guid.NewGuid().ToString().Substring(0, 8);
			Model.Users user = GetModelByMail(mail);
			Settings seting = new Settings();
			MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
			mailMsg.From = new MailAddress(seting.GetModel("系统邮件地址").Value);//源邮件地址 
			mailMsg.To.Add(new MailAddress(mail));//目的邮件地址。可以有多个收件人
			mailMsg.Subject = "您在xxx网站新的账户";//发送邮件的标题 
			StringBuilder sb = new StringBuilder();
			sb.Append("您在xxx网站中新的账户如下:");
			sb.Append("用户名:" + user.LoginId);
			sb.Append("密码是:" + newPwd);
			mailMsg.Body = sb.ToString();//发送邮件的内容 
			mailMsg.IsBodyHtml = true;
			//指定Smtp服务地址。(根据发件人邮箱指定对应的SMTP服务器地址)
			SmtpClient client = new SmtpClient(seting.GetModel("系统邮件SMTP").Value);//smtp.163.com，smtp.qq.com
			client.Credentials = new NetworkCredential(seting.GetModel("系统邮件用户名").Value, seting.GetModel("系统邮件密码").Value);//发件人邮箱的用户名密码
			client.Send(mailMsg);

			user.LoginPwd = Common.MD5Helper.GetMD5ByString(Common.MD5Helper.GetMD5ByString(newPwd));
			Update(user);
		}
	}
}
