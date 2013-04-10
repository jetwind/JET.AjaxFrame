using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class UcExectued
    {

        public static event AscxInterceptorHandler AscxInterceptor;

        /// <summary>
        /// 主页面用来加载control
        /// </summary>
        static Page MasterPage;


        /// <summary>
        /// 根据路径执行ascx控件
        /// </summary>
        /// <param name="controlPath">控件的虚拟路径</param>
        /// <returns></returns>
        public static string ExecutorAscx(string controlPath,string requestQueryString)
        {
            MasterPage = new Page();
            StringWriter outStream = new StringWriter();
            Control ctl = MasterPage.LoadControl(controlPath);
            if (AjaxCallChecker.isAllowExecAscx(HttpContext.Current, ctl, AscxInterceptor))
            {
                MasterPage.Controls.Add(ctl);
                HttpContext.Current.Server.Execute(MasterPage, outStream, true);
                return outStream.ToString();
            }
            return "Deny!";
        }
    }
}
