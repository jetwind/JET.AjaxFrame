using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxLibWebTest.UControls
{
    public partial class OrderList : System.Web.UI.UserControl
    {
        public string UserName = "Welcome!";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.rptComments.DataSource = s_comments;
            this.rptComments.DataBind();
        }

        private static List<Comment> s_comments = new List<Comment>
        {
            new Comment
            {
                CreateTime = DateTime.Parse("2007-1-1"),
                Content = "今天天气不错"
            },
            new Comment
            {
                CreateTime = DateTime.Parse("2007-1-2"),
                Content = "挺风和日丽的"
            },
            new Comment
            {
                CreateTime = DateTime.Parse("2007-1-3"),
                Content = "我们下午没有课"
            },
            new Comment
            {
                CreateTime = DateTime.Parse("2007-1-1"),
                Content = "这的确挺爽的"
            }
        };
    }
}