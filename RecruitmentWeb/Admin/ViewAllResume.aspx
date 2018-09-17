<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllResume.aspx.cs" Inherits="Admin_ViewAllResume" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Calibri;
            font-size: 14px;
        }
        .rowclass
        {
        }
        .headclass
        {
            background-color: ActiveBorder;
            font-size: 16px;
            border-color: Green;
        }
        table
        {
            border-right: 1px solid #D5D5D5;
            border-top: 1px solid #D5D5D5;
            width: 100%;
        }
         table th
        {
            padding: 7px;
             background-color: #EBEBEB;
        }
        table td, table th
        {
            border-bottom: 1px solid #D5D5D5;
            border-left: 1px solid #D5D5D5;
        }
        table thead
        {
            background: url("/assetsprocurement/images/th-bg.jpg") repeat-x scroll left top rgba(0, 0, 0, 0);
            color: #666666;
            font-size: 14px;
            height: 15px;
        }
        table tbody tr.grey td
        {
            background: none repeat scroll 0 0 #F7F7F7;
            text-indent: 10px;
        }
        table tbody tr td
        {
            background: none repeat scroll 0 0 #FFFFFF;
            color: #666666;
            font-size: 14px;
            padding: 5px;
            text-indent: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="headbar">
        <h2>
            <span>Candidate Resume</span>
        </h2>
    </div>
    <div style="text-align: center">
        <table width="40%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 20%" align="center">
                    Select Domain:
                </td>
                <td style="width: 20%" align="center">
                    <asp:DropDownList ID="ddlDomain" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
                <td style="width: 20%" align="center">
                    Select SubDomain:
                </td>
                <td style="width: 20%" align="center">
                    <asp:DropDownList ID="ddlSubDomain" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 20%" align="center">
                    Select Category:
                </td>
                <td style="width: 20%" align="center">
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <asp:Button ID="btnSearch" runat="server" class="xBook-button-normal button pull-right"
                        Text="Search" OnClick="btnSearch_Click" ValidationGroup="Check" />
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" Visible="false" Text="No Data" ForeColor="Red"
            Font-Bold="true"></asp:Label>
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="3">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                        Visible="False">&lt;&lt;</asp:LinkButton>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex"
                                            runat="server" Text="Label" Visible="False" ForeColor="Black"></asp:Label>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center" style="width: 20%">
                                Domain
                            </th>
                            <th align="center" style="width: 20%">
                                SubDomain
                            </th>
                            <th align="center" style="width: 20%">
                                Category
                            </th>
                            <th align="center" style="width: 20%">
                                Resume
                            </th>
                            <th align="center" style="width: 10%">
                                Action
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Domain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Category_Name")%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnUserResumeCode" runat="server" Value='<%# Eval("UserResume_Code")%>' />
                                <a id="aREsume" runat="server" href="javascript:">
                                    <%# Eval("Resume_File_Name")%></a>
                            </td>
                            <td style="text-align: center">
                                <a href="javascript:" runat="server" id="aSignUp">Process</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Domain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Category_Name")%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnUserResumeCode" runat="server" Value='<%# Eval("UserResume_Code")%>' />
                                <a id="aREsume" runat="server" href="javascript:">
                                    <%# Eval("Resume_File_Name")%></a>
                            </td>
                            <td style="text-align: center">
                                <a href="javascript:" runat="server" id="aSignUp">Process</a>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
