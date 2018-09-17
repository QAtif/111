<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatusSummaryReport.aspx.cs" Inherits="Candidate_StatusSummaryReport" %>

<%@ Register Src="~/UserControl/Menu.ascx" TagName="TopMenu1" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Status Summary Report</title>
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
        <br />
        <br />
        <asp:Repeater ID="rptSubDomain" runat="server" OnItemDataBound="rptSubDomain_OnItemDataBound">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" >
            </HeaderTemplate>
            <ItemTemplate>
                <tr  style="background-color:Black;color:White;">
                    <td style="text-align: left; font-weight: bold" colspan="2" >
                        <%# Eval("SubDomain_Name")%>
                        <asp:Label ID="lblSubDomainCode" runat="server" Text='<%# Eval("SubDomain_Code")%>'
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:290px;height:20px;padding-right:205px;" align="left" >
                        Status
                    </td>
                    <td>
                        <asp:Repeater ID="rptStatus" runat="server">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" border="1px" width="100%">
                                    <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td style="width:250px;height:20px;" >
                                    <%# Eval("Status_Name")%>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Repeater ID="rptCandidateCount" runat="server">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%" border="1px">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width:250px;height:80px;" align="left" valign="middle">
                                        <%# Eval("Category_Name")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s1")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s2")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s3")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s4")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s5")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s6")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s7")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s8")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s9")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s10")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s11")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s12")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s13")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s14")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s15")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s16")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s17")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s18")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s19")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s20")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s21")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s22")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s23")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s24")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s25")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s26")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s27")%>
                                    </td>
                                    <td style="width:80px;height:80px;" align="center" valign="middle">
                                        <%# Eval("s28")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
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
