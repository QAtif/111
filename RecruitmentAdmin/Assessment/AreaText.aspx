<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AreaText.aspx.cs" Inherits="Venue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Manage Status</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Status Setup</span>
        </h2>
       
    </div>
    <div id="container" class="contentarea">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr>
                            <th>
                                S.No.
                            </th>
                            <th align="left">
                                Status Code
                            </th>
                            <th align="left">
                                Status Name
                            </th>
                            <th align="left">
                                Area Status
                            </th>
                            <th align="left">
                                Area Text
                            </th>
                            <th style="width: 10%">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptStatus" runat="server" OnItemCommand="rptStatus_ItemCommand"
                            OnItemDataBound="rptStatus_ItemDataBound">
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Code")%>
                                        <asp:HiddenField ID="hfStatusCode" Value='<%# Eval("Status_Code") %>' runat="server" />
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Name")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Display_Text")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Display_LongText")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a runat="server" id="btnEdit" class="openframelarge">
                                            <img src="/assets/images/icons/edit.png" /></a>
                                        <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                            AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("Status_Code") %>'
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
                                        <%# Eval("Status_Code")%>
                                        <asp:HiddenField ID="hfStatusCode" Value='<%# Eval("Status_Code") %>' runat="server" />
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Name")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Display_Text")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Status_Display_LongText")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a runat="server" id="btnEdit" class="openframelarge">
                                            <img src="/assets/images/icons/edit.png" /></a>
                                        <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                            AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("Status_Code") %>'
                                            runat="server" />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
