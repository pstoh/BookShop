using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// Upload 的摘要说明
	/// </summary>
	public class Upload : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");
			string action = context.Request["action"];
			if (action == "up")
			{
				//上传图片
				UploadImg(context);
			}
			else
			{
				UploadCutImg(context);
			}
		}
		//上传剪贴图片
		private void UploadCutImg(HttpContext context)
		{
			int x = Convert.ToInt32(context.Request["x"]);
		int y = Convert.ToInt32(context.Request["y"]);
			int w = Convert.ToInt32(context.Request["w"]);
			int h = Convert.ToInt32(context.Request["h"]);
			String imagePath=context.Request["imagePath"];
			String newPath = "/UploadImage/" + Guid.NewGuid().ToString() + ".jpg";

			BookShop.Common.ImageHelper.CutImage(context, x, y, w, h, imagePath, newPath);
		context.Response.Write(newPath);
		}
		
		/// <summary>
		/// 
		/// 上传图片
		/// </summary>
		/// <param name="context"></param>
		private void UploadImg(HttpContext context)
		{
			HttpPostedFile file = context.Request.Files["filedata"];
			if (file != null)
			{
				String saveDirectory = "/UploadImage/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
				if (Directory.Exists(saveDirectory) == false)
				{
					Directory.CreateDirectory(saveDirectory);
				}
				String FileName = Path.GetFileName(file.FileName);
				if (Path.GetExtension(FileName) == ".jpg")
				{
					String  filePath= saveDirectory+Guid.NewGuid().ToString()+FileName;
					String fillPath=context.Request.MapPath(filePath);
					file.SaveAs(fillPath);

					using (Image img=Image.FromFile(fillPath) )
					{
						context.Response.Write("OK:" + filePath + ":" + img.Width + ":" + img.Height);
					}
				}
			}
			context.Response.Write("no");
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}