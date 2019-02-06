using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BookShop.DAL
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

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,username,LoginID,password,email,Address,Phone,code,state from tb_user ");
			strSql.Append(" where LoginID=@LoginID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@LoginID", MySqlDbType.VarChar)
			};
			parameters[0].Value = userName
				;

			BookShop.Model.user model = null;
			DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		public Model.user GetModelByMail(String mail)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,username,LoginID,password,email,Address,Phone,code,state from tb_user ");
			strSql.Append(" where email=@mail");
			MySqlParameter[] parameters = {
					new MySqlParameter("@mail", MySqlDbType.VarChar)
			};
			parameters[0].Value = mail;


			BookShop.Model.user model = null;
			DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
	}
}
