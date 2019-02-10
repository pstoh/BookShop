using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:user
	/// </summary>
	public partial class user
	{
		public user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "tb_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user(");
			strSql.Append("username,LoginID,password,email,Address,Phone,code,state)");
			strSql.Append(" values (");
			strSql.Append("@username,@LoginID,@password,@email,@Address,@Phone,@code,@state)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar,50),
					new MySqlParameter("@LoginID", MySqlDbType.VarChar,50),
					new MySqlParameter("@password", MySqlDbType.VarChar,50),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@Address", MySqlDbType.VarChar,150),
					new MySqlParameter("@Phone", MySqlDbType.VarChar,11),
					new MySqlParameter("@code", MySqlDbType.VarChar,64),
					new MySqlParameter("@state", MySqlDbType.Int32,11)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.LoginID;
			parameters[2].Value = model.password;
			parameters[3].Value = model.email;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.code;
			parameters[7].Value = model.State.sid;

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
		public bool Update(BookShop.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user set ");
			strSql.Append("username=@username,");
			strSql.Append("LoginID=@LoginID,");
			strSql.Append("password=@password,");
			strSql.Append("email=@email,");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("code=@code,");
			strSql.Append("state=@state");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar,50),
					new MySqlParameter("@LoginID", MySqlDbType.VarChar,50),
					new MySqlParameter("@password", MySqlDbType.VarChar,50),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@Address", MySqlDbType.VarChar,150),
					new MySqlParameter("@Phone", MySqlDbType.VarChar,11),
					new MySqlParameter("@code", MySqlDbType.VarChar,64),
					new MySqlParameter("@state", MySqlDbType.Int32,11),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.LoginID;
			parameters[2].Value = model.password;
			parameters[3].Value = model.email;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.code;
			parameters[7].Value = model.State.sid;
			parameters[8].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public BookShop.Model.user GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,username,LoginID,password,email,Address,Phone,code,state from tb_user ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			BookShop.Model.user model=new BookShop.Model.user();
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
		public BookShop.Model.user DataRowToModel(DataRow row)
		{
			BookShop.Model.user model=new BookShop.Model.user();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["LoginID"]!=null)
				{
					model.LoginID=row["LoginID"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.State.sid=int.Parse(row["state"].ToString());
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
			strSql.Append("select id,username,LoginID,password,email,Address,Phone,code,state ");
			strSql.Append(" FROM tb_user ");
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
			strSql.Append("select count(1) FROM tb_user ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_user T ");
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
			parameters[0].Value = "tb_user";
			parameters[1].Value = "id";
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

