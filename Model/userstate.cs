using System;
namespace BookShop.Model
{
	/// <summary>
	/// userstate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class userstate
	{
		public userstate()
		{}
		#region Model
		private int _sid;
		private string _name;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

