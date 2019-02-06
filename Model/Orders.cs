using System;
namespace BookShop.Model
{
	/// <summary>
	/// orders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class orders
	{
		public orders()
		{}
		#region Model
		private string _oid;
		private DateTime? _ordertime;
		private decimal? _total;
		private int? _state;
		private int? _uid;
		private string _address;
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
		public DateTime? ordertime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		#endregion Model

	}
}

