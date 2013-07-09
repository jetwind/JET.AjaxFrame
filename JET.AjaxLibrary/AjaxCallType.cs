using System;﻿
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// ajax请求的类型
    /// The ajax call the type of request(ajax请求的类型:类方法,)
    /// </summary>
    public enum AjaxCallType
    {
        ///// <summary>
        ///// 用户自定义后缀请求
        ///// </summary>
        //HttpUserDefHandle,

        /// <summary>
        /// ascx控件请求
        /// The ajax call the type of request,like:Order.Add.cs (用户自定义后缀的请求,如直接请求cs类中的方法)
        /// </summary>
        HttpUserDefHandle,

        /// <summary>
        /// Request user control (请求用户控件,Order.ascx)
        /// </summary>
        HttpUcHandle
    }
}
