using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BookShop.Common
{
	public static class MD5Helper
	{
		/// <summary>
		/// 
		/// 获取字符串的md5值
		/// </summary>
		/// <param name="text">要获取md5的字符串</param>
		/// <returns>md5值</returns>
		public static string GetMD5ByString(String text)
		{
			using (MD5 md5=MD5.Create())
			{
				byte[] bytes = Encoding.Default.GetBytes(text);
				StringBuilder stringBuilder = new StringBuilder();
				bytes = md5.ComputeHash(bytes);
				for (int i = 0; i < bytes.Length; i++)
				{
					stringBuilder.Append(bytes[i].ToString("X2"));
				}
				return stringBuilder.ToString();
			}
		}
		/// <summary>
		/// 
		/// 获取文件的md5值
		/// </summary>
		/// <param name="path">要计算md5值的文件的路径</param>
		/// <returns>md5值</returns>
		public static string GetMD5ByFile(string path)
		{
			using (MD5 md5=MD5.Create())
			{
				byte[] bytes = md5.ComputeHash(File.OpenRead(path));
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("X2"));
				}
				return builder.ToString();
			}
		}
	}
}