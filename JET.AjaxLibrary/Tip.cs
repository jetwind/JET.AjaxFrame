using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 错误提示信息
    /// </summary>
    public class Tip
    {
        /// <summary>
        /// 类型未找到提示
        /// </summary>
        public static readonly string TypeNotFound = "类型 [{0}] 没有找到。";

        /// <summary>
        /// 方法名未找到
        /// </summary>
        public static readonly string MethodNotFound = "方法{0}在程序集{1}中未找到！";

        /// <summary>
        /// 路径未找到
        /// </summary>
        public static readonly string ControlNotFound = "控件在该目录下未找到：{0}！";

        /// <summary>
        /// 请求不合法
        /// </summary>
        public static readonly string RequestIsUnLawFul = "非法请求，地址：{0}！";
    }
}
