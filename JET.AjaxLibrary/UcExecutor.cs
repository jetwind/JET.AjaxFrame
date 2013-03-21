using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;

namespace JET.AjaxLibrary
{
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

    }
}
