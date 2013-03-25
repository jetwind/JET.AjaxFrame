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
                CreateTime = DateTime.Parse("2013-01-01"),
                Content = "Cookie引发网民“禁止跟踪”热潮"
            },
            new Comment
            {
                CreateTime = DateTime.Parse("2007-01-02"),
                Content = "国美电器2012年净亏损5.97亿元 去年同期盈利"
            },
            new Comment
            {
                CreateTime = DateTime.Parse("2013-01-03"),
                Content = "移动视频业硝烟弥漫 欢聚时代称微信不构成威胁"
            },
            new Comment
            {
                CreateTime = DateTime.Parse("2013-01-01"),
                Content = "苹果公司内部言论闭塞 员工组建“秘密吐槽群”"
            }
            ,
            new Comment
            {
                CreateTime = DateTime.Parse("2013-01-01"),
                Content = "易会应用突破10万用户 易会网正式上线"
            }
            ,
            new Comment
            {
                CreateTime = DateTime.Parse("2013-01-01"),
                Content = "中搜第三代搜索的新掘金模式"
            }
            ,
            new Comment
            {
                CreateTime = DateTime.Parse("2013-01-01"),
                Content = "腾讯电商加速整合 QQ商城合并至QQ网购"
            }
        };
    }
}