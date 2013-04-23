using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 是否可用
    /// </summary>
    /// <param name="e"></param>
    public delegate void AjaxCallCheckHandler(AjaxCallEventArgs e);

    /// <summary>
    /// ascx 拦截器委托
    /// </summary>
    /// <param name="e"></param>
    public delegate void AscxInterceptorHandler(AscxInterceptorEventArgs e);
}
