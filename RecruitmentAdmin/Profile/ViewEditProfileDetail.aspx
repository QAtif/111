<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewEditProfileDetail.aspx.cs" Inherits="Profile_ViewEditProfileDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Profile Parameter</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>List of Profile</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <a href="AddEditProfile.aspx" class="openframe">Add New Profile</a>
            <%--<a href="ChangePriority.aspx">Update Requisition Priority</a> --%>
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
                        <asp:Repeater ID="rptProfileLists" runat="server" OnItemDataBound="rptProfileLists_ItemDataBound"
                            OnItemCommand="rptProfileLists_ItemCommand">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
               <%--                 <tr class="simple">
                                    <th style="text-align: center; font-weight: bold" colspan="3">
                                        Profile Name
                                    </th>
                                    <th style="text-align: center; width: 15%; font-weight: bold" colspan="2">
                                        Action
                                    </th>
                                </tr>--%>
                                <tr class="simple">
                                    <th style="text-align: center; font-weight: bold" colspan="3">
                                        <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                        <asp:HiddenField ID="hdnCounter" runat="server" Value='<%# Eval("count")%>' />
                                        <asp:HiddenField ID="hdnPageCounter" runat="server" />
                                        <%# Eval("Profile_Name")%>
                                    </th>
                                    <th style="text-align: center; width: 15%" colspan="2">
                                        <a id="aEdit" class="openframe" runat="server">Edit</a> |
                                        <asp:LinkButton ID="lnkDelProfile" CommandName="DeleteProfile" CommandArgument='<%# Eval("Profile_Code")%>'
                                            runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                            Text="Delete"></asp:LinkButton>
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptParameter" runat="server" OnItemDataBound="rptParameter_ItemDataBound"
                                    OnItemCommand="rptParameter_ItemCommand">
                                    <HeaderTemplate>
                                        <%--<table width="60%" border="0" cellpadding="10" cellspacing="0">--%>
                                        <tr>
                                            <th width="10%" style="font-weight: bold">
                                                S.No.
                                            </th>
                                            <th width="40%" style="font-weight: bold">
                                                Parameter
                                            </th>
                                            <th width="35%" style="font-weight: bold">
                                                Value
                                            </th>
                                            <th width="15%" style="font-weight: bold">
                                                Mandatory
                                            </th>
                                            <th width="15%" style="font-weight: bold">
                                                Action
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="simple">
                                            <td align="center">
                                                <asp:Label ID="lblSNo" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnProfileParameterCode" runat="server" Value='<%# Eval("ProfileParameter_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlParameter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlParameter_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlValue" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="center">
                                                <asp:CheckBox ID="chkMandatory" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                    CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png" CommandArgument='<%# Eval("ProfileParameter_Code")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <%--    </table>--%>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td align="right" colspan="5">
                                        <asp:LinkButton ID="lbtnAddNew" runat="server" CommandName="AddMore" CssClass="addsimple">Add Parameter </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="5">
                                        &nbsp;
                                    </th>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div align="center">
            <asp:Button ID="btnUpdate" runat="server" Text="Update All" Width="100px" OnClick="btnUpdate_Click" />
        </div>
    </div>
</asp:Content>
