using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// Get the UcControl
    /// </summary>
    public class HttpUcHandle:IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            
        }
    }
}
