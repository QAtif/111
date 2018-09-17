<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewAllRole.aspx.cs" Inherits="Role_ViewAllRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Role List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>List of Roles</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <a href="AddEditRole.aspx" class="openframe">Add New Role</a>
        </div>
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="5">
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
                <tr class="simple">
                    <th style="width: 2%">
                        S.No.
                    </th>
                    <th align="center" style="width: 20%">
                        Role Name
                    </th>
                    <th align="center" style="width: 20%">
                        Role Description
                    </th>
                    <th align="center" style="width: 10%">
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptRoleLists" runat="server" OnItemDataBound="rptRoleLists_ItemDataBound"
                    OnItemCommand="rptRoleLists_ItemCommand">
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRoleCode" runat="server" Value='<%# Eval("RoleID")%>' />
                                <%# Eval("RoleName")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("RoleDescription")%>
                            </td>
                            <td style="text-align: center">
                                <a id="aEdit" runat="server" class="openframe">
                                    <img src="/assetsprocurement/images/edit.png" />
                                </a>|
                                <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                    CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                    CommandArgument='<%# Eval("RoleID")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRoleCode" runat="server" Value='<%# Eval("RoleID")%>' />
                                <%# Eval("RoleName")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("RoleDescription")%>
                            </td>
                            <td style="text-align: center">
                                <a id="aEdit" runat="server" class="openframe">
                                    <img src="/assetsprocurement/images/edit.png" />
                                </a>|
                                <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                    CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                    CommandArgument='<%# Eval("RoleID")%>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div style="text-align: center; position: relative;">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
