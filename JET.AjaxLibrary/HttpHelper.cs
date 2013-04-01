using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// http帮助类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 验证是否是ajax请求，忽略IE6以下，IE6以下使用activex控件
        /// </summary>
        public static void VerifyIsAjaxRequest(HttpContext context) {
            if (context.Request.Headers["X-Requested-With"] == null || context.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                AjaxExceptionHelper.ExceptionProcess(context, new Exception(string.Format(Tip.RequestIsUnLawFul,context.Request.Url.ToString())));
            }
        }
    }
}
