using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
	public partial class BookList : System.Web.UI.Page
	{
		public List<Model.Books> ProductList { get; set; }
		public int PageIndex { get; set; }
		public int PageCount { get; set; }
        
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.HttpMethod.ToLower() == "get")
			{
				this.BindBookData();
			}

		}

		private void BindBookData()
		{
			this.PageIndex = int.Parse(Request["pageIndex"] ?? "1");
			int pageSize = 10;
			BLL.Books bookServer = new BLL.Books();
			this.ProductList = bookServer.GetListByPage(PageIndex, pageSize);
			int total = bookServer.GetRecordCount("");
			this.PageCount = Math.Max((total + pageSize - 1) / pageSize, 1);
		}

		public String CutString(String text, int cutLength)
		{
			if (text.Length <= cutLength)
			{
				return text;
			}

			return text.Substring(0, cutLength);
		}
	}
}