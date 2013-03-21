using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace AjaxLibWebTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //Assembly ass = Assembly.LoadFrom("AjaxLibWebTest.dll");

                JET.AjaxLibrary.UcExecutor<UControls.OrderList> uc = new JET.AjaxLibrary.UcExecutor<UControls.OrderList>();
                Response.Write(uc.ExecutorPage(uc.LoadControl("/Ucontrols/orderList.ascx")));
            }
        }
    }
}