<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SlotGeneration.aspx.cs" Inherits="SlotGeneration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <script type="text/javascript">
        function ShowOption(ddl1) {
            var ddl = document.getElementById('MainContent_ddlFromTime');
            var ddlToTime = document.getElementById('MainContent_ddlToTime');
            count = ddl[ddl.selectedIndex].value;
            if (count < 23) {
                ddlToTime.selectedIndex = parseInt(count) + 1;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Slot Generation</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tr class="grey bold center">
                    <td style="text-align: left">
                        Venue
                    </td>
                    <td style="text-align: left" colspan="3">
                        <asp:DropDownList ID="ddlVenue" runat="server" AutoPostBack="true" Style="width: auto" 
                            onselectedindexchanged="ddlVenue_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="bold center">
                    <td style="text-align: left">
                        From Time
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlFromTime" Enabled="false" runat="server" Style="width: auto" onChange="ShowOption(this);">
                            <asp:ListItem Text="0:00" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="13:00" Value="13"></asp:ListItem>
                            <asp:ListItem Text="14:00" Value="14"></asp:ListItem>
                            <asp:ListItem Text="15:00" Value="15"></asp:ListItem>
                            <asp:ListItem Text="16:00" Value="16"></asp:ListItem>
                            <asp:ListItem Text="17:00" Value="17"></asp:ListItem>
                            <asp:ListItem Text="18:00" Value="18"></asp:ListItem>
                            <asp:ListItem Text="19:00" Value="19"></asp:ListItem>
                            <asp:ListItem Text="20:00" Value="20"></asp:ListItem>
                            <asp:ListItem Text="21:00" Value="21"></asp:ListItem>
                            <asp:ListItem Text="22:00" Value="22"></asp:ListItem>
                            <asp:ListItem Text="23:00" Value="23"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        To Time
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlToTime"  Enabled="false" runat="server" Style="width: auto">
                            <asp:ListItem Text="0:00" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1:00" Selected="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="13:00" Value="13"></asp:ListItem>
                            <asp:ListItem Text="14:00" Value="14"></asp:ListItem>
                            <asp:ListItem Text="15:00" Value="15"></asp:ListItem>
                            <asp:ListItem Text="16:00" Value="16"></asp:ListItem>
                            <asp:ListItem Text="17:00" Value="17"></asp:ListItem>
                            <asp:ListItem Text="18:00" Value="18"></asp:ListItem>
                            <asp:ListItem Text="19:00" Value="19"></asp:ListItem>
                            <asp:ListItem Text="20:00" Value="20"></asp:ListItem>
                            <asp:ListItem Text="21:00" Value="21"></asp:ListItem>
                            <asp:ListItem Text="22:00" Value="22"></asp:ListItem>
                            <asp:ListItem Text="23:00" Value="23"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="text-align: left">
                        Slot Date From :
                    </td>
                    <td align="left">
                        <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 120px"
                            clientidmode="Static" />
                        <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16"
                            id="img5" /><strong>
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
                    <td style="text-align: left">
                        Slot Date To :
                    </td>
                    <td>
                        <input runat="server" width="50px" type="text" id="postedToDate" style="width: 120px"
                            clientidmode="Static" />
                        <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16"
                            id="img6" /><strong>
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
            </table>
            <br />
            <br />
            <table border="0" cellpadding="10" cellspacing="0">
                <tr class="grey">
                    <td colspan="4" align="center">
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lnkGenerateSlot" CssClass="btn-ora nl" OnClick="lnkGenerateSlot_Click">
                        Generate Slot
                        </asp:LinkButton><br />
                        <br />
                    </td>
                </tr>
               
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center" class="grey">
                <td align="center">
                    <asp:Label  runat="server" Font-Bold="true"  ID="lblMsg" Visible="false"></asp:Label><br />
                    <span style="color:Red"><asp:Literal  runat="server" ID="ltrMsg" Visible="false"></asp:Literal></span>
                </td>
            </tr>
        </table>
            <br />
            <table border="0" cellpadding="10" cellspacing="0">
                <thead>
                    <tr>
                        <th style="width: 10%">
                            S.No.
                        </th>
                        <th align="left">
                            SlotDate
                        </th>
                        <th align="left">
                            SlotStartTime
                        </th>
                        <th align="left">
                            SlotEndTime
                        </th>
                        <th align="left">
                            SlotStatus
                        </th>
                         <th align="left">
                            Seat No.
                        </th>
                        <th style="width: 10%;">
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptSlot" runat="server" OnItemCommand="rptSlot_ItemCommand" OnItemDataBound="rptSlot_ItemDataBound">
                        <ItemTemplate>
                            <tr class="simple">
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotDate")%>
                                    <asp:HiddenField ID="hfSlotCode" Value='<%# Eval("SlotCode") %>' runat="server" />
                                    <asp:HiddenField ID="hfCandidateSlotCode" Value='<%# Eval("CandidateSlotCode") %>'
                                        runat="server" />
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotStartTime")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotEndTime")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotStatus")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("VenuePrefix")%>
                                </td>
                                <td style="text-align: center;">
                                    <a runat="server" id="btnEdit" class="openframe" style="display:none">
                                        <img src="/assets/images/icons/edit.png" style="display:none" /></a>
                                    <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                        AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("CandidateSlotCode") %>'
                                        runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="grey">
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotDate")%>
                                    <asp:HiddenField ID="hfSlotCode" Value='<%# Eval("SlotCode") %>' runat="server" />
                                    <asp:HiddenField ID="hfCandidateSlotCode" Value='<%# Eval("CandidateSlotCode") %>'
                                        runat="server" />
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotStartTime")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotEndTime")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("SlotStatus")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("VenuePrefix")%>
                                </td>
                                <td style="text-align: center;">
                                    <a runat="server" id="btnEdit" class="openframe" style="display:none">
                                        <img src="/assets/images/icons/edit.png" style="display:none" /></a>
                                    <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                        AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("CandidateSlotCode") %>'
                                        runat="server" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table><br />
            <table border="0" cellpadding="5" cellspacing="0" class="none">
                <tr class="simple" id="trPagingControls" runat="server" align="center">
                    <td bgcolor="#EFEFEF" style="text-align: center;" width="100%">
                        <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False"><img src="/assets/images/icons/first.png" alt="First Page" /></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click" Visible="False"><img src="/assets/images/icons/left.png" alt="Previous Page" /></asp:LinkButton>&nbsp;
                        &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
                        &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False"><img src="/assets/images/icons/right.png" alt="Next Page" /></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False"><img src="/assets/images/icons/last.png" alt="Last Page" /></asp:LinkButton>&nbsp;
                    </td>
                </tr>
                
            </table><br />
        </div>
        
    </div>
</asp:Content>
