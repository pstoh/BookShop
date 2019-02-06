using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.BLL
{
	public partial class user
	{
		/// <summary>
		/// 
		/// 给定userName获取user实体
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public Model.user GetModel(String userName)
		{
			return dal.GetModel(userName);
		}

		public Model.user GetModelByMail(String mail)
		{
			return dal.GetModelByMail(mail);
		}
	}
}
