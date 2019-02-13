using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Common
{
	public abstract class PageBarHelper
	{
		public static string GetPageBar(int pageIndex, int pageCount)
		{
			if (pageCount == 1)
			{
				return string.Empty;
			}
			//要求页面上要显示10个数字页码。
			int start = pageIndex - 5;//计算起始位置
			if (start < 1)
			{
				start = 1;
			}
			int end = start + 9;//计算终止位置.
			if (end > pageCount)
			{
				end = pageCount;
				start = end - 9 < 1 ? 1 : end - 9;
			}
			StringBuilder sb = new StringBuilder();
			if (pageIndex > 1)
			{
				sb.Append(string.Format("<a href='?pageIndex={0}' class='pageBarIndex'>上一页</a>", pageIndex - 1));
			}
			for (int i = start; i <= end; i++)
			{
				if (i == pageIndex)
				{
					sb.Append(i);
				}
				else
				{
					sb.Append(string.Format("<a href='?pageIndex={0}' class='pageBarIndex'>{0}</a>", i));
				}
			}
			if (pageIndex < pageCount)
			{
				sb.Append(string.Format("<a href='?pageIndex={0}' class='pageBarIndex'>下一页</a>", pageIndex + 1));
			}

			return sb.ToString();
		}
	}
}
