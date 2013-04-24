using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 对自定义的请求是否可用
    /// </summary>
    /// <param name="e">ajax检查器基类</param>
    public delegate void AjaxCallCheckHandler(AjaxCallEventArgs e);

    /// <summary>
    /// ascx 拦截器委托
    /// </summary>
    /// <param name="e">ascx拦截器数据基类</param>
    public delegate void AscxInterceptorHandler(AscxInterceptorEventArgs e);


    /// <summary>
    /// 方法 拦截器委托
    /// </summary>
    /// <param name="e">方法拦截器数据基类</param>
    public delegate void MethodInterceptorHandler(MethodInterceptorEventArgs e);
}
