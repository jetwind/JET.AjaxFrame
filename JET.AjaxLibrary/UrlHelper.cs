using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// URL帮助类
    /// </summary>
    public  class UrlHelper
    {
        /// <summary>
        /// 根据请求的URL获取物理路径
        /// </summary>
        /// <param name="HttpRequestUrl"></param>
        /// <returns></returns>
        public static string GetPhyscialUrl(string HttpRequestUrl) {
            return System.Web.HttpContext.Current.Server.MapPath(HttpRequestUrl);
        }
    }
}
