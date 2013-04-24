using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Reflection;

namespace JET.AjaxLibrary
{
    public class AjaxCallChecker
    {
        /// <summary>
        /// 是否容许调用自定义Handle
        /// </summary>
        /// <param name="context"></param>
        /// <param name="handler"></param>
        /// <param name="ajaxCallType"></param>
        /// <returns></returns>
        public static bool isAllow(HttpContext context, AjaxCallCheckHandler handler, AjaxCallType ajaxCallType)
        {
            if (handler == null)
            {
                return true;
            }
            AjaxCallEventArgs e = new AjaxCallEventArgs(context, ajaxCallType);
            handler(e);
            if (!e.isAllow)
            {
                HttpHelper.WriteSimpleMessage(context,e.DenyInfoMsg);
            }
            return e.isAllow;
        }

        /// <summary>
        /// 是否允许执行当前ascx请求
        /// </summary>
        /// <param name="context">当前http对象</param>
        /// <param name="ctl">当前用户控件</param>
        /// <param name="handler">ascx拦截器委托</param>
        /// <returns>返回是否允许执行,true:允许,false:禁止</returns>
        public static bool isAllowExecAscx(HttpContext context, Control ctl, AscxInterceptorHandler handler)
        {
            if (handler == null)
            {
                return true;
            }
            AscxInterceptorEventArgs e = new AscxInterceptorEventArgs(context,ctl);
            handler(e);
            if (!e.isAllow)
            {
                HttpHelper.WriteSimpleMessage(context, e.DenyInfoMsg);
            }
            return e.isAllow;
        }

        /// <summary>
        /// 是否允许执行当前方法
        /// </summary>
        /// <param name="context">当前http对象</param>
        /// <param name="methodInfo">当前方法信息</param>
        /// <param name="handler">方法委托拦截器</param>
        /// <returns></returns>
        public static bool isAllowExecMethod(HttpContext context, MethodInfo methodInfo, MethodInterceptorHandler handler)
        {
            if (handler == null)
            {
                return true;
            }
            MethodInterceptorEventArgs e = new MethodInterceptorEventArgs(context, methodInfo);
            handler(e);
            if (!e.isAllow)
            {
                HttpHelper.WriteSimpleMessage(context, e.DenyInfoMsg);
            }
            return e.isAllow;
        }
    }
}
