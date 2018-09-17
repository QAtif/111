<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatusSummaryReport.aspx.cs"
    Inherits="RecruitmentAdmin_Candidate_StatusSummaryReport" %>

<%@ Register Src="~/UserControl/Menu.ascx" TagName="TopMenu1" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Status Summary Report</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--#include virtual="/assets/includes/scripts.asp"-->
    <script type="text/javascript">
        $(document).ready(function () {
            $("td:empty").html("&nbsp;");
        });
        function Collaps(obj) {

            if (document.getElementById(obj).style.display == 'none')
                document.getElementById(obj).style.display = '';
            else
                document.getElementById(obj).style.display = 'none';

        }
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
        <table width="1120" cellpadding="0" cellspacing="0" style="padding-left:20px">
            <tr style="background-color:#575757 ; font-family:Sans-Serif; volume:silent; text-decoration:none; color:#fff">
                <th style="width: 200px; border:1px solid #000" align="left">
                    Status Name
                </th>
                <th>
                    <asp:Repeater ID="rptStatus" runat="server">
                        <HeaderTemplate>
                            <table  cellspacing="0" cellpadding="0" border="1px solid #000" width="100%">
                                <tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td style="width: 100px;" align="center">
                                <%# Eval("Status_Name")%>
                            </td>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tr> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </th>
                <th  style="width:20px">&nbsp;</th>
            </tr>
           
           
            
            <tr style="font-family:Sans-Serif; volume:silent; text-decoration:none;">
                <td colspan="3">
                 <asp:Panel ID="pnl" runat="server" Height="600px" style="overflow:scroll">
                    <asp:Repeater ID="rptSubDomain" runat="server" OnItemDataBound="rptSubDomain_OnItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #BABABA; color: #000000; text-decoration:none;" onclick='<%# "Collaps(" +Eval("SubDomain_Code") + " );" %>'>
                                <td style="text-align: left; font-weight: bold; width: 100px;  border:1px solid #000" colspan="2">
                                    <%# Eval("SubDomain_Name")%>
                                    <asp:Label ID="lblSubDomainCode" runat="server" Text='<%# Eval("SubDomain_Code")%>'
                                        Visible="false"></asp:Label>
                                       <%-- <div style="float:right"><a style="color: White; font-size:small" id="aClick" href="javascript:;" onclick='<%# "Collaps(" +Eval("SubDomain_Code") + " );" %>' runat="server">Show/Hide</a></div>--%>
                                </td>
                            </tr>
                            <%--<tr style="display: none">
                                <td style="width: 200px;" align="left">
                                    Status
                                </td>
                                <td>
                                    <asp:Repeater ID="rptStatus" runat="server">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0" border="1px" width="100%">
                                                <tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td style="width: 200px; height: 20px;">
                                                <%# Eval("Status_Name")%>
                                            </td>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tr> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>--%>
                            <tr id= '<%# Eval("SubDomain_Code")%>' >
                                <td colspan="2">
                                    <asp:Repeater ID="rptCandidateCount" runat="server">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0" width="100%" border="1px">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="width: 200px; height: 30px;" align="left" valign="middle">
                                                    <%# Eval("Category_Name")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s1")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s2")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s3")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s4")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s5")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s6")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s7")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s8")%>
                                                </td>
                                                <td style="width: 100px;" align="center" valign="middle">
                                                    <%# Eval("s10")%>
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
                       </asp:Panel>
                </td>
            </tr>
         
         
        </table>
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
