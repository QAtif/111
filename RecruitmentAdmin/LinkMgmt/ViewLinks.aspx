<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewLinks.aspx.cs" Inherits="LinkMgmt_ViewLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Manage Link(s)</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Menu Links</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <a href="AddEditLinkCategory.aspx"
                class="openframe">Add Link Category</a>  
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center">
                                <table border="0" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <th style="background-color: Black;" height="25" align="center">
                                            <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                                ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                            &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                                Font-color="white" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                                Visible="False">&lt;&lt;</asp:LinkButton>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex"
                                                    runat="server" Text="Label" Visible="False" ForeColor="White"></asp:Label>&nbsp;
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
                        <asp:Repeater ID="rptLink" runat="server" OnItemDataBound="rptLink_ItemDataBound"
                            OnItemCommand="rptLink_ItemCommand">
                            <ItemTemplate>
                                <tr class="simple">
                                    <th align="center" style="border-style: none">
                                        <asp:HiddenField ID="hdnLinkCode" runat="server" Value='<%# Eval("MenuLinkID")%>' />
                                        <strong>
                                            <%# Eval("MenuLinkName")%></strong>
                                    </th>
                                    <th align="right" width="5%" style="border-style: none">
                                         <a id="aAdd" runat="server"
                                            class="openframe">
                                            <img src="/assetsprocurement/images/icons/plus-ico.png" title="Add New Link" />
                                        </a>  <a id="aEdit" runat="server"
                                            class="openframe">
                                            <img src="/assetsprocurement/images/Edit.png" title="Edit Category" /></a>  
                                         
                                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                CommandName="Delete" ToolTip="Delete Category" ImageUrl="/assetsprocurement/images/Delete.png"
                                                CommandArgument='<%# Eval("MenuLinkID")%>' />
                                        
                                    </th>
                                </tr>
                                <tr id="tr" runat="server">
                                    <td colspan="3">
                                        <asp:Repeater ID="rptLinkChild" runat="server" OnItemDataBound="rptLinkChild_ItemDataBound"
                                            OnItemCommand="rptLinkChild_ItemCommand">
                                            <HeaderTemplate>
                                                <table width="100%" border="0" cellpadding="10" cellspacing="0">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="center" width="40%">
                                                        <asp:HiddenField ID="hdnLinkCode" runat="server" Value='<%# Eval("MenuLinkID")%>' />
                                                        <%# Eval("MenuLinkName")%>
                                                    </td>
                                                    <td align="center" width="40%">
                                                        <%# Eval("URL")%>
                                                    </td>
                                                    <td align="center" width="8%">
                                                         <a id="aEdit" runat="server"
                                                            class="openframe">
                                                            <img src="/assetsprocurement/images/Edit.png" title="Edit Link" />
                                                        </a>  
                                                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                                CommandName="Delete" ToolTip="Delete Link" ImageUrl="/assetsprocurement/images/Delete.png"
                                                                CommandArgument='<%# Eval("MenuLinkID")%>' />
                                                         <a id="aMarkMenuAction" runat="server" class="openframelarge">
                                                            <img src="/assetsprocurement/images/icons/view-icon-new.jpg" title="Menu Link Action" />
                                                        </a>
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
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <%-- <div align="center">
            <asp:Button ID="btnUpdate" runat="server" Text="Update All" Width="100px" OnClick="btnUpdate_Click" />
        </div>--%>
    </div>
</asp:Content>
