using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookShop.DAL
{
	public partial class Books
	{
		public List<Model.Books> GetListByPage(int pageIndex, int PageSize)
		{
			String sql = "SELECT Top(@size) * FROM books WHERE id Not in(" +
			"SELECT top(@size*(@pageIndex-1)) id FROM books ORDER BY id) ORDER BY id";
			SqlParameter[] pms = new SqlParameter[]{
				new SqlParameter("@size",  PageSize),
				new SqlParameter("@pageIndex",pageIndex)
			};

			DataTable dt = new DataTable();
			using (SqlConnection con=new SqlConnection(Maticsoft.DBUtility.DbHelperMySQL.connectionString))
			{
				using(SqlDataAdapter adapter=new SqlDataAdapter (sql,con))
				{
				adapter.SelectCommand.Parameters.AddRange(pms);
				adapter.Fill(dt);
			}
		}


			return this.DataTableToList(dt);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Books> DataTableToList(DataTable dt)
		{
			List<Model.Books> modelList = new List<Model.Books >();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Books model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

	}
}
