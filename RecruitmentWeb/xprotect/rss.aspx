<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rss.aspx.cs" Inherits="xprotect_rss" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="XmlDataSource1">
            <ItemTemplate>
                Title: <a href="<%# XPath("link") %>">
                    <%# XPath("title") %></a><br />
                Pulish Date:
                <%# XPath("pubDate") %><br />
                Description:
                <%# XPath("description") %>
                <hr />
            </ItemTemplate>
        </asp:DataList>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="http://z.about.com/6/g/electrical/b/rss2.xml"
            XPath="rss/channel/item"></asp:XmlDataSource>
    </div>
    </form>
</body>
</html>
