<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Venue.aspx.cs" Inherits="Venue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Venue Setup</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            <div style="width: 50%; float: right;" align="right">
                &nbsp;<a href="AddEditVenue.aspx" class="openframe btn-ora" style="float: right;"><img
                    src="/assets/images/add-icon.png" alt="Add" title="Add" align="absmiddle" />&nbsp;&nbsp;Add
                    New Venue</a></div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="10" cellspacing="0">
                        <thead>
                            <tr>
                                <th>
                                    S.No.
                                </th>
                                <th align="left">
                                    Venue
                                </th>
                                <th align="left">
                                    Test Type Medium
                                </th>
                                <th align="left">
                                    No. Of Seats
                                </th>
                                <th align="left">
                                    Time Allocated
                                </th>
                                <th align="left">
                                    Min. Slot Duration
                                </th>
                                <th align="left"  style="width: 15%">
                                    Slot Start Time
                                </th>
                                <th align="left"  style="width: 15%">
                                    Slot End Time
                                </th>
                                 <th align="left">
                                   Venue Prefix
                                </th>
                                <th style="width: 10%">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptVenue" runat="server" OnItemCommand="rptVenue_ItemCommand"
                                OnItemDataBound="rptVenue_ItemDataBound">
                                <ItemTemplate>
                                    <tr class="simple">
                                        <td style="text-align: center">
                                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("VenueName")%>
                                            <asp:HiddenField ID="hfVenueCode" Value='<%# Eval("VenueCode") %>' runat="server" />
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TestTypeMediumName")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("NoOfSeats")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TimeDuration")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("MinDurationOfSlot")%>
                                        </td>
                                        <td style="text-align: left;width: 15%">
                                            <%# Eval("StartTime")%>
                                        </td>
                                        <td style="text-align: left;width: 15%">
                                            <%# Eval("EndTime")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("VenuePrefix")%>
                                        </td>
                                        <td style="text-align: center">
                                            <a runat="server" id="btnEdit" class="openframe">
                                                <img src="/assets/images/icons/edit.png" /></a>
                                            <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                                AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("VenueCode") %>'
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
                                            <%# Eval("VenueName")%>
                                            <asp:HiddenField ID="hfVenueCode" Value='<%# Eval("VenueCode") %>' runat="server" />
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TestTypeMediumName")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("NoOfSeats")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TimeDuration")%>
                                        </td>
                                         <td style="text-align: left">
                                            <%# Eval("MinDurationOfSlot")%>
                                        </td>
                                         <td style="text-align: left;width: 15%">
                                            <%# Eval("StartTime")%>
                                        </td>
                                        <td style="text-align: left;width: 15%">
                                            <%# Eval("EndTime")%>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("VenuePrefix")%>
                                        </td>
                                        <td style="text-align: center">
                                            <a runat="server" id="btnEdit" class="openframe">
                                                <img src="/assets/images/icons/edit.png" /></a>
                                            <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                                AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("VenueCode") %>'
                                                runat="server" />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
