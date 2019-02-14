using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BookShop.Common
{
	public abstract class WebHelper
	{
		public static bool CheckCookie(Model.Users model)
		{
			bool flag = false;
			HttpContext context = HttpContext.Current;
			String pwd = context.Request.Cookies["cp2"] == null ? null : context.Request.Cookies["cp2"].Value;
			String name = context.Request.Cookies["cp1"] == null ? null : context.Request.Cookies["cp1"].Value;
			if (context.Session["userInfo"] != null)
			{
				return true;
			}

			if (pwd != null && name!=null)
			{
				if (model!=null&& model.LoginId == name && model.LoginPwd == pwd)
				{
					context.Session["userInfo"] = model;
				flag = true;
				}
			}
			return flag;
		}

		/// <summary>
		/// 将UBB编码转成标准的HTML代码
		/// </summary>
		/// <param name="argString"></param>
		/// <returns></returns>
		public static string HtmlDecode(string argString)
		{
			string tString = argString;
			if (tString != "")
			{
				Regex tRegex;
				bool tState = true;
				tString = tString.Replace("&", "&amp;");
				tString = tString.Replace(">", "&gt;");
				tString = tString.Replace("<", "&lt;");
				tString = tString.Replace("\"", "&quot;");
				tString = Regex.Replace(tString, @"\[br\]", "<br />", RegexOptions.IgnoreCase);
				string[,] tRegexAry = {
          {@"\[p\]([^\[]*?)\[\/p\]", "$1<br />"},
          {@"\[b\]([^\[]*?)\[\/b\]", "<b>$1</b>"},
          {@"\[i\]([^\[]*?)\[\/i\]", "<i>$1</i>"},
          {@"\[u\]([^\[]*?)\[\/u\]", "<u>$1</u>"},
          {@"\[ol\]([^\[]*?)\[\/ol\]", "<ol>$1</ol>"},
          {@"\[ul\]([^\[]*?)\[\/ul\]", "<ul>$1</ul>"},
          {@"\[li\]([^\[]*?)\[\/li\]", "<li>$1</li>"},
          {@"\[code\]([^\[]*?)\[\/code\]", "<div class=\"ubb_code\">$1</div>"},
          {@"\[quote\]([^\[]*?)\[\/quote\]", "<div class=\"ubb_quote\">$1</div>"},
          {@"\[color=([^\]]*)\]([^\[]*?)\[\/color\]", "<font style=\"color: $1\">$2</font>"},
          {@"\[hilitecolor=([^\]]*)\]([^\[]*?)\[\/hilitecolor\]", "<font style=\"background-color: $1\">$2</font>"},
          {@"\[align=([^\]]*)\]([^\[]*?)\[\/align\]", "<div style=\"text-align: $1\">$2</div>"},
          {@"\[url=([^\]]*)\]([^\[]*?)\[\/url\]", "<a href=\"$1\">$2</a>"},
          {@"\[img\]([^\[]*?)\[\/img\]", "<img src=\"$1\" />"}
        };
				while (tState)
				{
					tState = false;
					for (int ti = 0; ti < tRegexAry.GetLength(0); ti++)
					{
						tRegex = new Regex(tRegexAry[ti, 0], RegexOptions.IgnoreCase);
						if (tRegex.Match(tString).Success)
						{
							tState = true;
							tString = Regex.Replace(tString, tRegexAry[ti, 0], tRegexAry[ti, 1], RegexOptions.IgnoreCase);
						}
					}
				}
			}
			return tString;
		}

		/// <summary>
		/// 对时间差进行处理--3天5小时40分钟---》3*24+5+40/60
		/// </summary>
		/// <param name="ts"></param>
		/// <returns></returns>
		public static string GetTimeSpan(TimeSpan ts)
		{
			if (ts.TotalDays >= 365)
			{
				return Math.Floor(ts.TotalDays / 365) + "年前";
			}
			else if (ts.TotalDays >= 30)
			{
				return Math.Floor(ts.TotalDays / 30) + "月前";
			}
			else if (ts.TotalHours >= 24)
			{
				return Math.Floor(ts.TotalDays) + "天前";
			}
			else if (ts.TotalHours >= 1)
			{
				return Math.Floor(ts.TotalHours) + "小时前";
			}
			else if (ts.TotalMinutes >= 1)
			{
				return Math.Floor(ts.TotalMinutes) + "分钟前";
			}
			else
			{
				return "刚刚";
			}
		}

	}
}
