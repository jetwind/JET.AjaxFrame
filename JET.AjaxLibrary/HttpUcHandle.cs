using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// Get the UcControl
    /// </summary>
    public class HttpUcHandle:IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// 处理进程
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            string FilePath = context.Request.CurrentExecutionFilePath;
            string url = UrlHelper.GetPhyscialUrl(FilePath);
            if (!File.Exists(url)) {
                AjaxExceptionHelper.ExceptionProcess(context, new Exception(string.Format(Tip.URLNotFound, url)));
            }
            context.Response.Write(UcExectued.ExecutorAscx(FilePath));
            context.Response.End();
        }
    }
}
