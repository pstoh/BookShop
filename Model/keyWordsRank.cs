using System;
namespace BookShop.Model
{
	/// <summary>
	/// keyWordsRank:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class keyWordsRank
	{
		public keyWordsRank()
		{}
		#region Model
		private Guid _id;
		private string _keywords;
		private int? _searchtimes;
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
		public int? SearchTimes
		{
			set{ _searchtimes=value;}
			get{return _searchtimes;}
		}
		#endregion Model

	}
}

