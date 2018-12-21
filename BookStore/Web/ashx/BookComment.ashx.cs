using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace Web.ashx
{
    /// <summary>
    /// BookComment 的摘要说明
    /// </summary>
    public class BookComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            Model.BookComment bookComment= new Model.BookComment();
            bookComment.BookId = Convert.ToInt32(context.Request["bookId"]);
            bookComment.Msg = context.Request["msg"];
            bookComment.CreateDateTime=DateTime.Now;
            BLL.BookCommentManager bookCommentManager=new BookCommentManager();
            if (bookCommentManager.Add(bookComment)>0)
            {
                context.Response.Write("OK");
            }
        

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