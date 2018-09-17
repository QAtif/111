<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testPage.aspx.cs" Inherits="testPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <%--<a id="lnk" href="/RecruitmentDocuments/CandidateDocuments/249706/Personal/NIC.jpg">Download File</a>--%>

        <asp:LinkButton ID="lblFileName" runat="server" onclick="lblFileName_Click">Download</asp:LinkButton>
    </div>
    </form>
</body>
</html>
