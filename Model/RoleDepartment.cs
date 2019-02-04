using System;
namespace BookShop.Model
{
	/// <summary>
	/// RoleDepartment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleDepartment
	{
		public RoleDepartment()
		{}
		#region Model
		private int _role_id;
		private int _department_id;
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
		public int Department_ID
		{
			set{ _department_id=value;}
			get{return _department_id;}
		}
		#endregion Model

	}
}

