using BookShop.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
	/// <summary>
	/// ProcessComment 的摘要说明
	/// </summary>
	public class ProcessComment : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			String action = context.Request["action"];
			if (action == "load")
			{
				this.LoadComment(context);
			}
			else
			{
				AddComment(context);
			}
		}
		/// <summary>
		/// 
		/// 添加评论
		/// </summary>
		/// <param name="context"></param>
		private void AddComment(HttpContext context)
		{
			int bookId = Convert.ToInt32(context.Request["bookId"]);
			String msg = context.Request["msg"];
			//禁用词过滤
			BLL.Articel_Words wordsService = new BLL.Articel_Words();
			if (wordsService.CheckBannet(msg))
			{
				context.Response.Write("no:评论中含有禁用词!");
			}
			else if (wordsService.CheckMod(msg))
			{
				AddComment(context, msg);
				context.Response.Write("no:评论中含有审查此!");
			}
			else
			{
				//替换词过滤
				msg=wordsService.CheckReplace(msg);
			}
		}

		private void AddComment(HttpContext context, string msg)
		{
			int bookId = Convert.ToInt32(context.Request["bookId"]);
			new BLL.BookComment().Add(new Model.BookComment()
			{
				BookId = bookId,
				Msg = msg,
				CreateDateTime = DateTime.Now
			});
			context.Response.Write("OK:评论成功");
		}
		/// <summary>
		/// 
		/// 加载评论
		/// </summary>
		/// <param name="context"></param>
		private void LoadComment(HttpContext context)
		{
			int bookId = int.Parse(context.Request["bookId"]);
			List<Model.BookComment> commentList = new BLL.BookComment().GetModelList(" bookId=" + bookId);
			List<CommentViewModel> viewModelList = new List<CommentViewModel>();
			for (int i = 0; i < commentList.Count; i++)
			{
				CommentViewModel viewModel = new CommentViewModel();
				viewModel.Msg = Common.WebHelper.HtmlDecode(commentList[i].Msg);
				TimeSpan ts = DateTime.Now - commentList[i].CreateDateTime;
				viewModel.CreateDateTime = Common.WebHelper.GetTimeSpan(ts);
				viewModelList.Add(viewModel);
			}

			System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
			context.Response.Write(js.Serialize(viewModelList));
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