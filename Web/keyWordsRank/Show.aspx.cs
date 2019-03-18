using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace BookShop.Web.keyWordsRank
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Guid Id ;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id=new Guid(Request.Params["id"]);
				}
				string KeyWords = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					KeyWords= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(Id,KeyWords);
			}
		}
		
	private void ShowInfo(Guid Id,string KeyWords)
	{
		BookShop.BLL.keyWordsRank bll=new BookShop.BLL.keyWordsRank();
		BookShop.Model.keyWordsRank model=bll.GetModel(Id,KeyWords);
		this.lblId.Text=model.Id.ToString();
		this.lblKeyWords.Text=model.KeyWords;
		this.lblSearchTimes.Text=model.SearchTimes.ToString();

	}


    }
}
