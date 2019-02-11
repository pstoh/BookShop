using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookShop.DAL
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

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from users ");
			strSql.Append(" where LoginID=@LoginID");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.VarChar)
			};
			parameters[0].Value = userName
				;

			BookShop.Model.Users model = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		public Model.Users GetModel(String userName,String pwd)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from users ");
			strSql.Append(" where LoginID=@LoginID AND loginpwd=@pwd");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.VarChar),
					new SqlParameter("@pwd", SqlDbType.VarChar)
			};
			parameters[0].Value = userName;
			parameters[1].Value=pwd;

			BookShop.Model.Users model = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		public Model.Users GetModelByMail(String mail)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from users ");
			strSql.Append(" where mail=@mail");
			SqlParameter[] parameters = {
					new SqlParameter("@mail", SqlDbType.VarChar)
			};
			parameters[0].Value = mail;


			BookShop.Model.Users model = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
