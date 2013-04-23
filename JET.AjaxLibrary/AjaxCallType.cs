using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// ajax请求的类型
    /// </summary>
    public enum AjaxCallType
    {
        /// <summary>
        /// 用户自定义后缀请求
        /// </summary>
        HttpUserDefHandle,
        /// <summary>
        /// ascx控件请求
        /// </summary>
        HttpUcHandle
    }
}
