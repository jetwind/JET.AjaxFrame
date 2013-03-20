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
        /// 加载程序集并调用处理方法
        /// </summary>
        /// <param name="context">Http当前对象</param>
        /// <param name="type">程序集</param>
        /// <param name="MethodName">方法名</param>
        public static void ProcessRequest(HttpContext context,Type type,string MethodName) {
            //获取方法名
            MethodInfo methodInfo = type.GetMethod(MethodName);
            //获取方法的委托
            FastInvokeHandler handler = InvokeHandler.GetMethodInvoker(methodInfo);
            //执行方法
            object Result = handler(type, null);
            //设置文本类型
            context.Response.ContentType = HttpMIME.Text.ToString();
            if (context.Response.IsRequestBeingRedirected)
            {
                context.Response.Write(Result);
            }
            else 
            {
                string Redirecturl = "";// HttpContextHelper.GetRequireRedirectedUrl();
                context.Server.Transfer(Redirecturl, true);
            }
        }
    }
}
