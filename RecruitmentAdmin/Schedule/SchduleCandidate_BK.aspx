<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true" CodeFile="SchduleCandidate_BK.aspx.cs" Inherits="Schedule_SchduleCandidate_BK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <title>Reserve Slots</title>
    <script type="text/javascript">
        function refreshParent() {
            window.parent.location.href = "../Profile/ViewProfileCandidate.aspx";
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divPage" runat="server">
        <div class="headbar">
        <br /><br />
            <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                <ProgressTemplate>
                    <div id="progress" style="position: absolute; visibility: visible; border: none;
                        vertical-align: middle; text-align: center; z-index: 100; width: 960px; height: 100%;
                        background: #999; filter: alpha(opacity=80); -moz-opacity: .8; opacity: .8;">
                        <img id="Img2" alt="" src="/assets/images/loading2.gif" runat="server" width="400"
                            height="300" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h2>
                <span>Slot </span>Reservation for <asp:Label ID="lblReqType" runat="server" Font-Bold="false"></asp:Label></h2>
        </div>
        <div id="container" class="contentarea">
            <div align="left">
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="grey" style="color: Red" colspan="4">
                            <asp:Label runat="server" Font-Bold="true" ID="lblMsg" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr class="grey bold center">
                        <td style="text-align: left; width: 15%">
                            Select From Date :
                        </td>
                        <td style="text-align: left; width: 35%">
                            <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 120px"
                                clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                    height="16" id="img5" />
                        </td>
                        <td style="text-align: left; width: 15%">
                            Select To Date :
                        </td>
                        <td style="text-align: left; width: 35%">
                            <input runat="server" width="50px" type="text" id="postedToDate" style="width: 120px"
                                clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                    height="16" id="img1" />
                            <script type="text/javascript">
                                Calendar.setup({
                                    inputField: "postedToDate",      // id of the input field
                                    ifFormat: "M dd, y",       // format of the input field
                                    //ifFormat       :    "y-M-dd",       // format of the input field
                                    //ifFormat       :    "M-dd-y",       // format of the input field
                                    button: "img1",   // trigger for the calendar (button ID)
                                    singleClick: true            // double-click mode
                                });
                            </script>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                            <tr class="bold center">
                                <td style="text-align: left; width: 15%">
                                    Venue:
                                </td>
                                <td style="text-align: left; width: 35%">
                                    <asp:DropDownList ID="ddlVenue" AutoPostBack="true" runat="server" Style="width: 170px"
                                        OnSelectedIndexChanged="ddlVenue_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: left; width: 15%">
                                    Profile:
                                </td>
                                <td style="text-align: left; width: 35%">
                                    <asp:Label ID="lblProfileName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="margin: 0 0 0 0; padding: 0 0 0 0; border: 0">
                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                        <tr class="bold center">
                                            <td style="text-align: left; width: 15%">
                                                Total Seats:
                                            </td>
                                            <td style="text-align: left; width: 35%">
                                                <asp:Label runat="server" ID="lblTotalSeat"></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 15%">
                                                Available Time:
                                            </td>
                                            <td style="text-align: left; width: 35%">
                                                <asp:Label runat="server" ID="lblAvailabletime"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="bold center">
                                            <td style="text-align: left; width: 15%">
                                                Minimum Slot Period:
                                            </td>
                                            <td style="text-align: left; width: 35%">
                                                <asp:Label runat="server" ID="lblMinimumTime"></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 15%">
                                                Test Duration:
                                            </td>
                                            <td style="text-align: left; width: 35%">
                                                <asp:Label runat="server" ID="lblProfileHour"></asp:Label>
                                                Hours
                                            </td>
                                        </tr>
                                         <tr class="bold center">
                                            <td style="text-align: left; width: 15%">
                                                Candidate Name
                                            </td>
                                            <td style="text-align: left; width: 35%">
                                                <asp:Label runat="server" ID="lblCandidateName"></asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 15%">
                                                Reference No.
                                            </td>
                                            <td style="text-align: left; width: 35%">
                                                <asp:Label runat="server" ID="lblCandidateReference"></asp:Label>
                                                                                           </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="bold center">
                                <td style="text-align: center" colspan="4">
                                    <%--<asp:Button ID="btnSearch" CssClass="btn-ora nl" runat="server" Text="Search" OnClick="btnSearch_Onclick" />--%>
                                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="btnSearch_Onclick">
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
                        <table border="0" cellpadding="10" cellspacing="0">
                           
                            <asp:Repeater ID="rptSlot" runat="server" OnItemCommand="rptSlot_ItemCommand">
                                <HeaderTemplate>
                                    <tr style="background-color: #dddddd">
                                        <th style="text-align: center">
                                            S/No.
                                        </th>
                                        <th>
                                            Date
                                        </th>
                                        <th style="text-align: left">
                                            Start Time
                                        </th>
                                        <th style="text-align: left">
                                            End Time
                                        </th>
                                        <th style="text-align: left">
                                            Seat No.
                                        </th>
                                        <th style="text-align: center;">
                                            Action
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="simple">
                                        <td style="text-align: center">
                                            <%# Container.ItemIndex + 1%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# DataBinder.Eval(Container.DataItem, "SlotDate", "{0:dd MMM, yyyy}")%>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblStartTime" runat="server"><%# Eval("SlotStartTime")%></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblEndTime" runat="server"><%# Eval("SlotEndTime")%></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("VenuePrefix")%>
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:LinkButton runat="server" ID="btnReserve" CommandName="Reserve" CommandArgument='<%# Eval("CandidateSlotCode")%>'>Reserve</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="grey">
                                        <td style="text-align: center">
                                            <%# Container.ItemIndex + 1%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# DataBinder.Eval(Container.DataItem, "SlotDate", "{0:dd MMM, yyyy}")%>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblStartTime" runat="server"><%# Eval("SlotStartTime")%></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblEndTime" runat="server"><%# Eval("SlotEndTime")%></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("VenuePrefix")%>
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:LinkButton runat="server" ID="btnReserve" CommandName="Reserve" CommandArgument='<%# Eval("CandidateSlotCode")%>'>Reserve</asp:LinkButton>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div style="text-align: center">
                            <asp:Label ID="lblemptyMsg" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlVenue" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="DivError" runat="server" visible="false">
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
