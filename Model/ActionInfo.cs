using System;
namespace BookShop.Model
{
	/// <summary>
	/// ActionInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ActionInfo
	{
		public ActionInfo()
		{}
		#region Model
		private int _id;
		private string _actioninfoname;
		private string _url;
		private int _httpmethod;
		private string _remark;
		private int _delfalg;
		private DateTime _subtime;
		private bool _ismenu;
		private int _r_userinfo_actioninfoid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActionInfoName
		{
			set{ _actioninfoname=value;}
			get{return _actioninfoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int HttpMethod
		{
			set{ _httpmethod=value;}
			get{return _httpmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DelFalg
		{
			set{ _delfalg=value;}
			get{return _delfalg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SubTime
		{
			set{ _subtime=value;}
			get{return _subtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMenu
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int R_UserInfo_ActionInfoID
		{
			set{ _r_userinfo_actioninfoid=value;}
			get{return _r_userinfo_actioninfoid;}
		}
		#endregion Model

	}
}

