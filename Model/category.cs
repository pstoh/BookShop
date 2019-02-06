using System;
namespace BookShop.Model
{
	/// <summary>
	/// category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class category
	{
		public category()
		{}
		#region Model
		private string _cid;
		private string _cname;
		/// <summary>
		/// 
		/// </summary>
		public string cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		#endregion Model

	}
}

