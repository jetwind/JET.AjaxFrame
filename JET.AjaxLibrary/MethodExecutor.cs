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

        public static event MethodInterceptorHandler methodInterceptor;

        /// <summary>
        /// 加载程序集并调用处理方法
        /// </summary>
        /// <param name="context">Http当前对象</param>
        /// <param name="type">程序集</param>
        /// <param name="MethodName">方法名</param>
        public static void ProcessRequest(HttpContext context, Type type, string MethodName)
        {
            //获取方法名
            MethodInfo methodInfo = type.GetMethod(MethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            if (methodInfo == null)
            {
                AjaxExceptionHelper.ExceptionProcess(context, new Exception((string.Format(Tip.MethodNotFound, MethodName, type.Assembly.FullName))));
            }
            //调用方法拦截器,是否容许执行方法
            if (AjaxCallChecker.isAllowExecMethod(context, methodInfo, methodInterceptor))
            {
                object Obj = null;
                //如果方法是非静态,创建对象实例
                if (!methodInfo.IsStatic)
                {
                    Obj = Activator.CreateInstance(type);
                }
                //获取方法的委托
                FastInvokeHandler handler = InvokeHandler.GetMethodInvoker(methodInfo);
                //执行方法
                object Result = handler(Obj, null);
                context.Response.Write(Result);
                string Redirecturl = "";// HttpContextHelper.GetRequireRedirectedUrl();
                //设置文本类型
                //context.Response.ContentType = HttpMIME.Text.ToString();
                if (context.Response.IsRequestBeingRedirected)
                {
                    context.Response.End();
                }
                else if (Redirecturl.Length > 0)
                {

                    context.Server.Transfer(Redirecturl, true);
                }
            }
            else
            {

            }
        }
    }
}
