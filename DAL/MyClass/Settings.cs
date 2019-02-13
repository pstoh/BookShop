using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookShop.DAL
{
	public partial class Settings
	{

		public Model.Settings GetModel(String key)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 Id,Name,Value from Settings ");
			strSql.Append(" where name=@key");
			SqlParameter[] parameters = {
					new SqlParameter("@key", SqlDbType.NVarChar)
			};
			parameters[0].Value = key;

			BookShop.Model.Settings model = new BookShop.Model.Settings();
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
