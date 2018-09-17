<%@ Page Title="" Language="C#" AutoEventWireup="true"
    CodeFile="Test.aspx.cs" Inherits="Test" %>

<html>
<head>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <br />
            <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click">Download LinkButton</asp:LinkButton>
            <br />
            <a id="ADL" runat="server">Download Anchor</a><br />
        </div>
    </form>
</body>
</html>
