using System;
namespace BookShop.Model
{
	/// <summary>
	/// SearchDetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SearchDetails
	{
		public SearchDetails()
		{}
		#region Model
		private Guid _id;
		private string _keywords;
		private DateTime? _searchdatetime;
		/// <summary>
		/// 
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyWords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SearchDateTime
		{
			set{ _searchdatetime=value;}
			get{return _searchdatetime;}
		}
		#endregion Model

	}
}

