using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 提供对用户控件的直接执行,模拟page生命周期,采用了老赵的解决方案!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UcExecutor<T> where T:UserControl
    {
        /// <summary>
        /// 主页面用来加载control
        /// </summary>
        static Page MasterPage;

        /// <summary>
        /// 加载控件
        /// </summary>
        /// <returns></returns>
        public T LoadControl(string controlPath) {
            MasterPage = new Page();
            return (T)MasterPage.LoadControl(controlPath);
        }

        /// <summary>
        /// 执行页面
        /// </summary>
        public string ExecutorPage(T control) {
            StringWriter outStream = new StringWriter();
            MasterPage.Controls.Add(control);
            HttpContext.Current.Server.Execute(MasterPage, outStream, false);
            return outStream.ToString();

        }
        


        /// <summary>
        /// 根据路径执行用户控件,返回控件运行完毕后的输出流
        /// </summary>
        /// <param name="controlPath">控件路径,相对路径</param>
        /// <returns>return the control</returns>
        public static string ExecutorAscx(string controlPath) {
            MasterPage = new Page();
            StringWriter outStream = new StringWriter();
            MasterPage.Controls.Add(MasterPage.LoadControl(controlPath));
            HttpContext.Current.Server.Execute(MasterPage, outStream, false);
            return outStream.ToString();
        }

    }
}
