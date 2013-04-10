using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.UI;

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
    }
}
