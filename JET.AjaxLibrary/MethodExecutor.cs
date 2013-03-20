using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 方法执行器
    /// </summary>
    public class MethodExecutor
    {
        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="type"></param>
        /// <param name="MethodName"></param>
        public static void ProcessRequest(HttpContext context,Type type,string MethodName) {
            MethodInfo methodInfo = type.GetMethod(MethodName);
            FastInvokeHandler handler = InvokeHandler.GetMethodInvoker(methodInfo);
            object Result = handler(type, null);
            context.Response.ContentType = HttpMIME.Text.ToString();
            if (context.Response.IsRequestBeingRedirected)
            {
                context.Response.Write(Result);
            }
            else {
                string Redirecturl = "";// HttpContextHelper.GetRequireRedirectedUrl();
                context.Response.Redirect(Redirecturl, true);
            }
        }
    }
}
