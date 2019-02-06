using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:orderitem
	/// </summary>
	public partial class orderitem
	{
		public orderitem()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string iid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from orderitem");
			strSql.Append(" where iid=@iid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = iid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.orderitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into orderitem(");
			strSql.Append("iid,count,subtotal,oid,bid)");
			strSql.Append(" values (");
			strSql.Append("@iid,@count,@subtotal,@oid,@bid)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iid", MySqlDbType.VarChar,32),
					new MySqlParameter("@count", MySqlDbType.Int32,11),
					new MySqlParameter("@subtotal", MySqlDbType.Decimal,10),
					new MySqlParameter("@oid", MySqlDbType.VarChar,32),
					new MySqlParameter("@bid", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.iid;
			parameters[1].Value = model.count;
			parameters[2].Value = model.subtotal;
			parameters[3].Value = model.oid;
			parameters[4].Value = model.bid;

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
		public bool Update(BookShop.Model.orderitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update orderitem set ");
			strSql.Append("count=@count,");
			strSql.Append("subtotal=@subtotal,");
			strSql.Append("oid=@oid,");
			strSql.Append("bid=@bid");
			strSql.Append(" where iid=@iid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@count", MySqlDbType.Int32,11),
					new MySqlParameter("@subtotal", MySqlDbType.Decimal,10),
					new MySqlParameter("@oid", MySqlDbType.VarChar,32),
					new MySqlParameter("@bid", MySqlDbType.VarChar,32),
					new MySqlParameter("@iid", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.count;
			parameters[1].Value = model.subtotal;
			parameters[2].Value = model.oid;
			parameters[3].Value = model.bid;
			parameters[4].Value = model.iid;

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
		public bool Delete(string iid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from orderitem ");
			strSql.Append(" where iid=@iid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = iid;

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
		public bool DeleteList(string iidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from orderitem ");
			strSql.Append(" where iid in ("+iidlist + ")  ");
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
		public BookShop.Model.orderitem GetModel(string iid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iid,count,subtotal,oid,bid from orderitem ");
			strSql.Append(" where iid=@iid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = iid;

			BookShop.Model.orderitem model=new BookShop.Model.orderitem();
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
		public BookShop.Model.orderitem DataRowToModel(DataRow row)
		{
			BookShop.Model.orderitem model=new BookShop.Model.orderitem();
			if (row != null)
			{
				if(row["iid"]!=null)
				{
					model.iid=row["iid"].ToString();
				}
				if(row["count"]!=null && row["count"].ToString()!="")
				{
					model.count=int.Parse(row["count"].ToString());
				}
				if(row["subtotal"]!=null && row["subtotal"].ToString()!="")
				{
					model.subtotal=decimal.Parse(row["subtotal"].ToString());
				}
				if(row["oid"]!=null)
				{
					model.oid=row["oid"].ToString();
				}
				if(row["bid"]!=null)
				{
					model.bid=row["bid"].ToString();
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
			strSql.Append("select iid,count,subtotal,oid,bid ");
			strSql.Append(" FROM orderitem ");
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
			strSql.Append("select count(1) FROM orderitem ");
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
				strSql.Append("order by T.iid desc");
			}
			strSql.Append(")AS Row, T.*  from orderitem T ");
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
			parameters[0].Value = "orderitem";
			parameters[1].Value = "iid";
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

