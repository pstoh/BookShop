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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace BookShop.Web.keyWordsRank
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Guid Id;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id= Request.Params["id0"];
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
		this.txtSearchTimes.Text=model.SearchTimes.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSearchTimes.Text))
			{
				strErr+="SearchTimes格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			Guid Id= new Guid(this.lblId.Text);
			string KeyWords=this.lblKeyWords.Text;
			int SearchTimes=int.Parse(this.txtSearchTimes.Text);


			BookShop.Model.keyWordsRank model=new BookShop.Model.keyWordsRank();
			model.Id=Id;
			model.KeyWords=KeyWords;
			model.SearchTimes=SearchTimes;

			BookShop.BLL.keyWordsRank bll=new BookShop.BLL.keyWordsRank();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
