<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatusSummaryDetail.aspx.cs" Inherits="Candidate_StatusSummaryDetail" %>

<%@ Register Src="~/UserControl/Menu.ascx" TagName="TopMenu1" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Status Summary Detail</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--#include virtual="/assets/includes/scripts.asp"-->
    <script type="text/javascript">
        $(document).ready(function () {
            $("td:empty").html("&nbsp;");
        });
    </script>
    <style type="text/css">
        .menu
        {
            position: absolute;
            text-align: right;
            width: 60%;
            float: right;
            z-index: 1000;
            padding-left: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="topbarbg">
            <div class="topbar">
                <div class="logo">
                    <img src="/assets/images/logo.gif" alt="logo" width="69" height="30" align="left" />
                    <div class="toptext" style="width: 70%;">
                        <span class="yellowtxt" style="position: absolute;">RECRUITMENT </span>
                        <div class="menu">
                            <uc1:TopMenu1 ID="TopMenu1" runat="server" />
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="topnavigation" style="width: 100%; text-align: right">
                </div>
            </div>
        </div>
        <h3 class="popup-hd-top">
            <asp:Label ID="AlertHead" runat="server" Text=""></asp:Label>
        </h3>
        <div class="clear">
        </div>
        <div class="read-hd">
            <strong style="position: absolute; right: 36px; top: 15px;">
                <asp:Label ID="lblCurrentPage" runat="server"></asp:Label></strong>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:LinkButton ID="btnPrev" runat="server" OnClick="btnPrev_Click"><< View Previous</asp:LinkButton>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="btnNext" runat="server" OnClick="btnNext_Click">View Next >></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="rptCandidateLists" runat="server">
            <HeaderTemplate>
                <table cellpadding="3" cellspacing="0" width="100%" border="1px">
                    <tr style="background-color: Black; color: White;">
                        <th align="center" style="width: 5%; padding: 8px 8px 8px 8px;">
                            S.No.
                        </th>
                        <th align="center" style="width: 20%; padding: 8px 8px 8px 8px;">
                            Full Name
                        </th>
                        <th align="center" style="width: 15%; padding: 8px 8px 8px 8px;">
                            Email Address
                        </th>
                        <th align="center" style="width: 10%; padding: 8px 8px 8px 8px;">
                            Gender
                        </th>
                        <th align="center" style="width: 20%; padding: 8px 8px 8px 8px;">
                            Phone Number
                        </th>
                        <th align="center" style="width: 15%; padding: 8px 8px 8px 8px;">
                            Current Status
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="simple">
                    <td style="text-align: center; padding: 8px 8px 8px 8px;">
                        <%# Container.ItemIndex+1%>
                    </td>
                    <td style="text-align: left; padding: 8px 8px 8px 8px;">
                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                        <a id="aCandidateLink" runat="server" target="_blank">
                            <%# Eval("Full_Name")%></a>
                    </td>
                    <td style="text-align: left; padding: 8px 8px 8px 8px;">
                        <%# Eval("Email_Address")%>
                    </td>
                    <td style="text-align: left; padding: 8px 8px 8px 8px;">
                        <%# Eval("Gender")%>
                    </td>
                    <td style="text-align: left; padding: 8px 8px 8px 8px;">
                        <%# Eval("Phone_Number")%>
                    </td>
                    <td style="text-align: left; font-weight: bold; padding: 8px 8px 8px 8px;">
                        <%# Eval("Status_Name")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
        <div class="greyfooterbarbg" style="width: 100%">
            <div class="greyfooterbar">
                <div class="screen">
                </div>
                <div class="help">
                    <a id="MasterHelp" class="openframe" href="javascript:">Help</a></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
