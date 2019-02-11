﻿using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}
