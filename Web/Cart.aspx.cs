using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
	public partial class Cart : CheckUserState.CheckUserSession
	{
		public List<Model.Cart> CartList { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			int userId = ((Model.Users)Session["userInfo"]).Id;
			CartList = new BLL.Cart().GetModelList( userId);
			
		}
	}
}