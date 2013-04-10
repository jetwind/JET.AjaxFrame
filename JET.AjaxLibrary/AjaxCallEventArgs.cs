using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.UI;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 定义ajax数据类基类
    /// </summary>
    public class AjaxCallEventArgs:EventArgs
    {
        /// <summary>
        /// 请求类型
        /// </summary>
        public AjaxLibrary.AjaxCallType ajaxCallType;

        /// <summary>
        /// 当前handle对象
        /// </summary>
        public HttpContext context;

        /// <summary>
        /// 是否容许执行
        /// </summary>
        public bool isAllow;

        /// <summary>
        /// 信息提示
        /// </summary>
        public string DenyInfoMsg;

        public AjaxCallEventArgs(HttpContext context, AjaxCallType ajaxCallType)
        {
            this.context = context;
            this.ajaxCallType = ajaxCallType;
        }

    }


    public class AscxInterceptorEventArgs : EventArgs
    {

        public Control control;
        /// <summary>
        /// 是否容许执行
        /// </summary>
        public bool isAllow;

        /// <summary>
        /// 信息提示
        /// </summary>
        public string DenyInfoMsg;

        /// <summary>
        /// 当前handle对象
        /// </summary>
        public HttpContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public AscxInterceptorEventArgs(HttpContext context, Control ctl)
        {
            this.context = context;
            this.control = ctl;
        }
    }

}
