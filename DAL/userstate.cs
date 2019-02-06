using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:userstate
	/// </summary>
	public partial class userstate
	{
		public userstate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("sid", "userstate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from userstate");
			strSql.Append(" where sid=@sid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sid", MySqlDbType.Int32)
			};
			parameters[0].Value = sid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.userstate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userstate(");
			strSql.Append("name)");
			strSql.Append(" values (");
			strSql.Append("@name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.name;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.userstate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userstate set ");
			strSql.Append("name=@name");
			strSql.Append(" where sid=@sid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,40),
					new MySqlParameter("@sid", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.sid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userstate ");
			strSql.Append(" where sid=@sid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sid", MySqlDbType.Int32)
			};
			parameters[0].Value = sid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userstate ");
			strSql.Append(" where sid in ("+sidlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.userstate GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sid,name from userstate ");
			strSql.Append(" where sid=@sid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sid", MySqlDbType.Int32)
			};
			parameters[0].Value = sid;

			BookShop.Model.userstate model=new BookShop.Model.userstate();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.userstate DataRowToModel(DataRow row)
		{
			BookShop.Model.userstate model=new BookShop.Model.userstate();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sid,name ");
			strSql.Append(" FROM userstate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM userstate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.sid desc");
			}
			strSql.Append(")AS Row, T.*  from userstate T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "userstate";
			parameters[1].Value = "sid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

