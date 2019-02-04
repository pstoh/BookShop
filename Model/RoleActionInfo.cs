using System;
namespace BookShop.Model
{
	/// <summary>
	/// RoleActionInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleActionInfo
	{
		public RoleActionInfo()
		{}
		#region Model
		private int _role_id;
		private int _actioninfo_id;
		/// <summary>
		/// 
		/// </summary>
		public int Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActionInfo_ID
		{
			set{ _actioninfo_id=value;}
			get{return _actioninfo_id;}
		}
		#endregion Model

	}
}

