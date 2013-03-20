using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace JET.AjaxLibrary
{
    public class AjaxExceptionHelper
    {
        internal static void ExceptionProcess(HttpContext context, Exception ex)
        {
            WriteExceptionToResponse(context,ex);
        }

        /// <summary>
        /// 写入异常到屏幕
        /// </summary>
        static void WriteExceptionToResponse(HttpContext context,Exception ex) {
            if (context == null) {
                throw new ArgumentNullException("HttpContext");
            }
            context.Response.Write(ex.Message);

        }
    }
}
