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

        /// <summary>
        /// 主页面用来加载control
        /// </summary>
        static Page MasterPage;


        /// <summary>
        /// 根据路径执行ascx控件
        /// </summary>
        /// <param name="controlPath"></param>
        /// <returns></returns>
        public static string ExecutorAscx(string controlPath)
        {
            MasterPage = new Page();
            StringWriter outStream = new StringWriter();
            MasterPage.Controls.Add(MasterPage.LoadControl(controlPath));
            HttpContext.Current.Server.Execute(MasterPage, outStream, false);
            return outStream.ToString();
        }
    }
}
