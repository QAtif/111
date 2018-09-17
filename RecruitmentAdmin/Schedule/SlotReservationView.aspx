<%@ Page Title="Slots Status" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SlotReservationView.aspx.cs" Inherits="SlotReservationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <title>Slots Status</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%-- <script language="javascript" type="text/javascript">

        function HideCandidate(obj) {

            document.getElementById(obj).style.display = 'none';

        }
        function ShowCandidate(obj) {

            document.getElementById(obj).style.display = 'inline';

        }

    </script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Slot </span>Status</h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="grey" style="color: Red" colspan="2">
                        <asp:Label runat="server" Font-Bold="true" ID="lblMsg" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="text-align: left">Select Date :
                    </td>
                    <td style="text-align: left">
                        <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 120px"
                            clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                height="16" id="img5" />
                    </td>
                </tr>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <tr class="bold center">
                            <td style="text-align: left">Venue:
                            </td>
                            <td style="text-align: left" colspan="2">
                                <asp:DropDownList ID="ddlVenue" runat="server" Style="width: auto">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <tr class="bold center">
                    <td style="text-align: center" colspan="2">
                        <%--<asp:Button ID="btnSearch" CssClass="btn-ora nl" runat="server" Text="Search" OnClick="btnSearch_Onclick" />--%>
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
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
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table border="1" width="500px">
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Literal ID="litRowStart" runat="server"></asp:Literal>
                    <td style="vertical-align: top;" class="greyborder">
                        <span style="color: Grey; font-weight: bold">Seat # :</span>
                        <asp:Label ID="lblVenueprefix" CssClass="yellowtxt" Font-Bold="true" Text='<%# Eval("VenuePrefix")%>' runat="server"></asp:Label>
                        <br />
                        <table border="1" width="500px">
                            <asp:Repeater ID="rptChild" runat="server">
                                <HeaderTemplate>
                                    <tr class="grey">
                                        <td>Candidate Name
                                        </td>
                                        <td>Start Time
                                        </td>
                                        <td>End Time
                                        </td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("CandidateFullName")%>
                                        </td>
                                        <td>
                                            <%# Eval("SlotStartTime")%>
                                        </td>
                                        <td>
                                            <%# Eval("SlotEndTime")%>
                                        </td>
                                    </tr>
                                    <asp:Literal ID="litRowEnd" runat="server"></asp:Literal>
                                </ItemTemplate>

                            </asp:Repeater>
                            <div style="text-align: center">
                                <asp:Label ID="lblemtyMsg" runat="server" ForeColor="Red"></asp:Label>
                                <br />
                            </div>
                        </table>
                    </td>
                    <asp:Literal ID="litRowEnd" runat="server"></asp:Literal>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <div style="text-align: center">
                <asp:Label ID="lblemtyMsgAll" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
