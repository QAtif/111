<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="xprotectdownloadreport.aspx.cs" Inherits="Leads_xprotectdownloadreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>XProtect Download Report</title>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>XProtect Download Report </span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    <strong>Search Criteria </strong>
                </th>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Name:
                </td>
                <td align="center">
                    <asp:TextBox ID="txtName" runat="server" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 15%" align="center">
                    Email:
                </td>
                <td align="center">
                    <asp:TextBox ID="txtEmail" runat="server" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    From Date:
                </td>
                <td align="center">
                    <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 260px"
                        clientidmode="Static" />
                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img5" /><strong>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedFromDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img5",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </strong>
                </td>
                <td style="width: 15%" align="center">
                    To Date:
                </td>
                <td align="center">
                    <input runat="server" width="50px" type="text" id="postedToDate" style="width: 260px"
                        clientidmode="Static" />
                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img6" /><strong>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedToDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img6",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Country:
                </td>
                <td align="center">
                    <asp:TextBox ID="txtCountry" runat="server" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 15%" align="center">
                    &nbsp;
                </td>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                        ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                    </asp:LinkButton>
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblTotalCount" Font-Bold="true" runat="server"></asp:Label>
                <table width="80%" border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="8">
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
                        <tr class="simple">
                            <th style="width: 2%" rowspan="3">
                                <strong>S.No.</strong>
                            </th>
                            <th align="center" style="width: 15%" rowspan="3">
                                <strong>Name</strong>
                            </th>
                            <th align="center" style="width: 15%" rowspan="3">
                                <strong>Email</strong>
                            </th>
                            <th align="center" style="width: 13%" rowspan="3">
                                <strong>Date Of Birth</strong>
                            </th>
                            <th align="center" style="width: 15%" rowspan="3">
                                <strong>Gender</strong>
                            </th>
                            <th align="center" style="width: 14%" rowspan="3">
                                <strong>Country</strong>
                            </th>
                            <th align="center" style="width: 14%" rowspan="3">
                                <strong>Download Count</strong>
                            </th>
                            <th align="center" style="width: 14%" rowspan="3">
                                <strong>Last Date</strong>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptData" runat="server">
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server" Text='<%# Eval("SNo")%>'></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Email")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("DOB")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Gender")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Country")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("DownloadCount")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("LastDate2")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server" Text='<%# Eval("SNo")%>'></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Email")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("DOB")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Gender")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Country")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("DownloadCount")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("LastDate2")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                        <div style="text-align: center">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="No Data"></asp:Label>
                            <br />
                        </div>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
