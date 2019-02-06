using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:orders
	/// </summary>
	public partial class orders
	{
		public orders()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string oid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from orders");
			strSql.Append(" where oid=@oid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@oid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = oid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into orders(");
			strSql.Append("oid,ordertime,total,state,uid,address)");
			strSql.Append(" values (");
			strSql.Append("@oid,@ordertime,@total,@state,@uid,@address)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@oid", MySqlDbType.VarChar,32),
					new MySqlParameter("@ordertime", MySqlDbType.DateTime),
					new MySqlParameter("@total", MySqlDbType.Decimal,10),
					new MySqlParameter("@state", MySqlDbType.Int32,1),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@address", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.oid;
			parameters[1].Value = model.ordertime;
			parameters[2].Value = model.total;
			parameters[3].Value = model.state;
			parameters[4].Value = model.uid;
			parameters[5].Value = model.address;

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
		public bool Update(BookShop.Model.orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update orders set ");
			strSql.Append("ordertime=@ordertime,");
			strSql.Append("total=@total,");
			strSql.Append("state=@state,");
			strSql.Append("uid=@uid,");
			strSql.Append("address=@address");
			strSql.Append(" where oid=@oid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ordertime", MySqlDbType.DateTime),
					new MySqlParameter("@total", MySqlDbType.Decimal,10),
					new MySqlParameter("@state", MySqlDbType.Int32
						,1),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@address", MySqlDbType.VarChar,200),
					new MySqlParameter("@oid", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.ordertime;
			parameters[1].Value = model.total;
			parameters[2].Value = model.state;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.address;
			parameters[5].Value = model.oid;

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
		public bool Delete(string oid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from orders ");
			strSql.Append(" where oid=@oid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@oid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = oid;

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
		public bool DeleteList(string oidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from orders ");
			strSql.Append(" where oid in ("+oidlist + ")  ");
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
		public BookShop.Model.orders GetModel(string oid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select oid,ordertime,total,state,uid,address from orders ");
			strSql.Append(" where oid=@oid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@oid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = oid;

			BookShop.Model.orders model=new BookShop.Model.orders();
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
		public BookShop.Model.orders DataRowToModel(DataRow row)
		{
			BookShop.Model.orders model=new BookShop.Model.orders();
			if (row != null)
			{
				if(row["oid"]!=null)
				{
					model.oid=row["oid"].ToString();
				}
				if(row["ordertime"]!=null && row["ordertime"].ToString()!="")
				{
					model.ordertime=DateTime.Parse(row["ordertime"].ToString());
				}
				if(row["total"]!=null && row["total"].ToString()!="")
				{
					model.total=decimal.Parse(row["total"].ToString());
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
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
			strSql.Append("select oid,ordertime,total,state,uid,address ");
			strSql.Append(" FROM orders ");
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
			strSql.Append("select count(1) FROM orders ");
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
				strSql.Append("order by T.oid desc");
			}
			strSql.Append(")AS Row, T.*  from orders T ");
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
			parameters[0].Value = "orders";
			parameters[1].Value = "oid";
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

