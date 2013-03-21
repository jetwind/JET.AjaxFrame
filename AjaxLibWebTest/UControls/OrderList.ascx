<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderList.ascx.cs" Inherits="AjaxLibWebTest.UControls.OrderList" %>
<%=UserName %>
<asp:Repeater runat="server" ID="rptComments">
    <ItemTemplate>
        时间：<%# (Container.DataItem as AjaxLibWebTest.UControls.Comment).CreateTime.ToString() %><br />
        内容：<%# (Container.DataItem as AjaxLibWebTest.UControls.Comment).Content %> 
    </ItemTemplate>
    <SeparatorTemplate>
        <hr />
    </SeparatorTemplate>
    <FooterTemplate>
        <hr />
    </FooterTemplate>
</asp:Repeater>