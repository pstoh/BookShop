using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:category
	/// </summary>
	public partial class category
	{
		public category()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from category");
			strSql.Append(" where cid=@cid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = cid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into category(");
			strSql.Append("cid,cname)");
			strSql.Append(" values (");
			strSql.Append("@cid,@cname)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cid", MySqlDbType.VarChar,32),
					new MySqlParameter("@cname", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.cid;
			parameters[1].Value = model.cname;

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
		public bool Update(BookShop.Model.category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update category set ");
			strSql.Append("cname=@cname");
			strSql.Append(" where cid=@cid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cname", MySqlDbType.VarChar,100),
					new MySqlParameter("@cid", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.cid;

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
		public bool Delete(string cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from category ");
			strSql.Append(" where cid=@cid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = cid;

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
		public bool DeleteList(string cidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from category ");
			strSql.Append(" where cid in ("+cidlist + ")  ");
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
		public BookShop.Model.category GetModel(string cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cid,cname from category ");
			strSql.Append(" where cid=@cid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = cid;

			BookShop.Model.category model=new BookShop.Model.category();
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
		public BookShop.Model.category DataRowToModel(DataRow row)
		{
			BookShop.Model.category model=new BookShop.Model.category();
			if (row != null)
			{
				if(row["cid"]!=null)
				{
					model.cid=row["cid"].ToString();
				}
				if(row["cname"]!=null)
				{
					model.cname=row["cname"].ToString();
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
			strSql.Append("select cid,cname ");
			strSql.Append(" FROM category ");
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
			strSql.Append("select count(1) FROM category ");
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
				strSql.Append("order by T.cid desc");
			}
			strSql.Append(")AS Row, T.*  from category T ");
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
			parameters[0].Value = "category";
			parameters[1].Value = "cid";
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

