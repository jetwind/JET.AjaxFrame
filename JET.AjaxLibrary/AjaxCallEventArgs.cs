using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.UI;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 定义ajax检查器事件基类
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

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="context">HTTP对象</param>
        /// <param name="ajaxCallType"></param>
        public AjaxCallEventArgs(HttpContext context, AjaxCallType ajaxCallType)
        {
            this.context = context;
            this.ajaxCallType = ajaxCallType;
        }

    }

    /// <summary>
    /// ascx拦截器事件数据
    /// </summary>
    public class AscxInterceptorEventArgs : EventArgs
    {
        /// <summary>
        /// 当前控件对象
        /// </summary>
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
        /// 构造函数初始化
        /// </summary>
        /// <param name="ctl"></param>
        public AscxInterceptorEventArgs(HttpContext context, Control ctl)
        {
            this.context = context;
            this.control = ctl;
        }
    }

}
