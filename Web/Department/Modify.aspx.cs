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
namespace BookShop.Web.Department
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		BookShop.BLL.Department bll=new BookShop.BLL.Department();
		BookShop.Model.Department model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtDepName.Text=model.DepName;
		this.txtRoleID.Text=model.RoleID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtDepName.Text.Trim().Length==0)
			{
				strErr+="DepName不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtRoleID.Text))
			{
				strErr+="RoleID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string DepName=this.txtDepName.Text;
			int RoleID=int.Parse(this.txtRoleID.Text);


			BookShop.Model.Department model=new BookShop.Model.Department();
			model.ID=ID;
			model.DepName=DepName;
			model.RoleID=RoleID;

			BookShop.BLL.Department bll=new BookShop.BLL.Department();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
