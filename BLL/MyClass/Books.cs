using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.BLL
{
	public partial class Books
	{
		public List<Model.Books> GetListByPage(int pageIndex, int PageSize)
		{
			return dal.GetListByPage(pageIndex, PageSize);
		}
	}
}
