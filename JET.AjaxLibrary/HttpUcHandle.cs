
/********************************************************************  
创建时间:       2013/03/10 11:09 
文件名称:       HttpUcHandle.cs 
文件作者:       zhangyu  
===================================================================== 
功能说明:       直接执行访问ascx控件  
---------------------------------------------------------------------  
其他说明:         
===================================================================== 
更新时间:      2013-04-10
更新作者:      zhangyu  
更新内容:      新增了继承会话状态接口
*********************************************************************/ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.SessionState;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// Get the UcControl
    /// </summary>
    public class HttpUcHandle:IHttpHandler,IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public static event AjaxCallCheckHandler OnAjaxCall;


        /// <summary>
        /// 处理进程
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            if (AjaxCallChecker.isAllow(context, OnAjaxCall, AjaxCallType.HttpUcHandle))
            {
                //HttpHelper.VerifyIsAjaxRequest(context);
                string FilePath = context.Request.CurrentExecutionFilePath;
                string url = UrlHelper.GetPhyscialUrl(FilePath);
                string QueryString = context.Request.QueryString.ToString();
                if (!File.Exists(url))
                {
                    //如果路径不存在,异常处理
                    AjaxExceptionHelper.ExceptionProcess(context, new Exception(string.Format(Tip.ControlNotFound, url)));
                }
                context.Response.Write(UcExectued.ExecutorAscx(FilePath, QueryString));
                context.Response.End();
            }
        }
    }
}
