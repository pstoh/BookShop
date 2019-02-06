using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:book
	/// </summary>
	public partial class book
	{
		public book()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string bid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from book");
			strSql.Append(" where bid=@bid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = bid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.book model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into book(");
			strSql.Append("bid,bname,price,author,image,cid)");
			strSql.Append(" values (");
			strSql.Append("@bid,@bname,@price,@author,@image,@cid)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid", MySqlDbType.VarChar,32),
					new MySqlParameter("@bname", MySqlDbType.VarChar,100),
					new MySqlParameter("@price", MySqlDbType.Decimal,5),
					new MySqlParameter("@author", MySqlDbType.VarChar,20),
					new MySqlParameter("@image", MySqlDbType.VarChar,200),
					new MySqlParameter("@cid", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.bid;
			parameters[1].Value = model.bname;
			parameters[2].Value = model.price;
			parameters[3].Value = model.author;
			parameters[4].Value = model.image;
			parameters[5].Value = model.cid;

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
		public bool Update(BookShop.Model.book model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update book set ");
			strSql.Append("bname=@bname,");
			strSql.Append("price=@price,");
			strSql.Append("author=@author,");
			strSql.Append("image=@image,");
			strSql.Append("cid=@cid");
			strSql.Append(" where bid=@bid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bname", MySqlDbType.VarChar,100),
					new MySqlParameter("@price", MySqlDbType.Decimal,5),
					new MySqlParameter("@author", MySqlDbType.VarChar,20),
					new MySqlParameter("@image", MySqlDbType.VarChar,200),
					new MySqlParameter("@cid", MySqlDbType.VarChar,32),
					new MySqlParameter("@bid", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.bname;
			parameters[1].Value = model.price;
			parameters[2].Value = model.author;
			parameters[3].Value = model.image;
			parameters[4].Value = model.cid;
			parameters[5].Value = model.bid;

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
		public bool Delete(string bid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from book ");
			strSql.Append(" where bid=@bid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = bid;

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
		public bool DeleteList(string bidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from book ");
			strSql.Append(" where bid in ("+bidlist + ")  ");
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
		public BookShop.Model.book GetModel(string bid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select bid,bname,price,author,image,cid from book ");
			strSql.Append(" where bid=@bid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@bid", MySqlDbType.VarChar,32)			};
			parameters[0].Value = bid;

			BookShop.Model.book model=new BookShop.Model.book();
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
		public BookShop.Model.book DataRowToModel(DataRow row)
		{
			BookShop.Model.book model=new BookShop.Model.book();
			if (row != null)
			{
				if(row["bid"]!=null)
				{
					model.bid=row["bid"].ToString();
				}
				if(row["bname"]!=null)
				{
					model.bname=row["bname"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["author"]!=null)
				{
					model.author=row["author"].ToString();
				}
				if(row["image"]!=null)
				{
					model.image=row["image"].ToString();
				}
				if(row["cid"]!=null)
				{
					model.cid=row["cid"].ToString();
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
			strSql.Append("select bid,bname,price,author,image,cid ");
			strSql.Append(" FROM book ");
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
			strSql.Append("select count(1) FROM book ");
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
				strSql.Append("order by T.bid desc");
			}
			strSql.Append(")AS Row, T.*  from book T ");
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
			parameters[0].Value = "book";
			parameters[1].Value = "bid";
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

