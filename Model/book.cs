using System;
namespace BookShop.Model
{
	/// <summary>
	/// book:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class book
	{
		public book()
		{}
		#region Model
		private string _bid;
		private string _bname;
		private decimal? _price;
		private string _author;
		private string _image;
		private string _cid;
		/// <summary>
		/// 
		/// </summary>
		public string bid
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bname
		{
			set{ _bname=value;}
			get{return _bname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string image
		{
			set{ _image=value;}
			get{return _image;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		#endregion Model

	}
}

