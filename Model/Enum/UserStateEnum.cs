using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Model.Enum
{
	public enum UserStateEnum
	{
		/// <summary>
		/// 用户锁定
		/// </summary>
		UserLock = 3,
		/// <summary>
		/// 
		/// 无效
		/// </summary>
		UserNone=2,
		/// <summary>
		/// 正常
		/// </summary>
		UserNormarl = 1,
	}
}
