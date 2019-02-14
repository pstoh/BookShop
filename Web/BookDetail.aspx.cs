using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
	public partial class BookDetail : System.Web.UI.Page
	{
		public Model.Books Book { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			//Response.Write(Request["id"]);
			int id = Convert.ToInt32(Request["id"]);
			Book = new BLL.Books().GetModel(id);
			//new BLL.Books().CreateHtml(id);

		}
	}
}