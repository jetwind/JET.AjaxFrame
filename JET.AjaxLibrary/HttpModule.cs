using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 自定义HttpModule， IHttpModule是属于大小通吃类型,无论客户端请求的是什么文件,都会调用到它;例如aspx,rar,html的请求
    /// </summary>
    public class HttpModule:IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 初始化模块，并使其为处理请求做好准备。
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            //throw new NotImplementedException();
            context.AuthorizeRequest += context_AuthorizeRequest;
        }

        /// <summary>
        /// 当安全模块已验证用户授权时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_AuthorizeRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //HttpApplication application = (HttpApplication)(sender);
            ////if (application.Request.HttpMethod == "POST") { 
                
            ////}
            //application.Context.Response.Write("--Boot--");
        }
    }
}
