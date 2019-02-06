using System;
namespace BookShop.Model
{
	/// <summary>
	/// orderitem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class orderitem
	{
		public orderitem()
		{}
		#region Model
		private string _iid;
		private int? _count;
		private decimal? _subtotal;
		private string _oid;
		private string _bid;
		/// <summary>
		/// 
		/// </summary>
		public string iid
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? subtotal
		{
			set{ _subtotal=value;}
			get{return _subtotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bid
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		#endregion Model

	}
}

