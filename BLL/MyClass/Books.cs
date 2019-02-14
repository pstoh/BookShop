using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BookShop.BLL
{
	public partial class Books
	{
		public List<Model.Books> GetListByPage(int pageIndex, int PageSize)
		{
			return dal.GetListByPage(pageIndex, PageSize);
		}
		/// <summary>
		/// 
		/// 根据图书id创建图书静态页
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool CreateHtml(int id)
		{
			Model.Books bookModel = dal.GetModel(id);
			if (bookModel == null)
			{
				return false;
			}

			string filePath = HttpContext.Current.Request.MapPath("/Template/BookTemplate.html");
			string fileContent = File.ReadAllText(filePath);
			fileContent = fileContent.Replace("$author", bookModel.Author).Replace("$title", bookModel.Title).Replace("$wordCount", bookModel.WordsCount.ToString()).Replace("$publishDate", bookModel.PublishDate.ToShortDateString()).Replace("$isbn", bookModel.ISBN).Replace("$unitPrice", bookModel.UnitPrice.ToString("0.00")).Replace("$toc", bookModel.TOC).Replace("$content", bookModel.ContentDescription).Replace("$authorDesc", bookModel.AurhorDescription).Replace("$bookId", bookModel.Id.ToString());
			string dir = "/BookDetails/" + bookModel.PublishDate.Year + "/" + bookModel.PublishDate.Month + "/" + bookModel.PublishDate.Day + "/";
			Directory.CreateDirectory(Path.GetDirectoryName(HttpContext.Current.Request.MapPath(dir)));
			string fullDir = dir + bookModel.Id + ".html";
			File.WriteAllText(HttpContext.Current.Request.MapPath(fullDir), fileContent, System.Text.Encoding.UTF8);
			return true;
		}
	}
}
