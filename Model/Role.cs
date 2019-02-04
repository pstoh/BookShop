using System;
namespace BookShop.Model
{
	/// <summary>
	/// Role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Role
	{
		public Role()
		{}
		#region Model
		private int _id;
		private string _rolename;
		private int _delflag;
		private int _roletype;
		private DateTime _subtime;
		private string _remark;
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
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DelFlag
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RoleType
		{
			set{ _roletype=value;}
			get{return _roletype;}
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
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

