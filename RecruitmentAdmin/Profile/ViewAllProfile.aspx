<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewAllProfile.aspx.cs" Inherits="Profile_ViewAllProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Manage Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
<asp:ScriptManager id="ScriptManafer1" runat="server"></asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>List of Profiles</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <span id="divAction31" runat="server" visible="false" clientidmode="Static"><a href="AddEditProfile.aspx"
                class="openframe">Add New Profile</a> | </span><a href="ViewProfileCandidate.aspx">View
                    Mapped/Shortlisted Candidates</a> | <a href="ViewUnMappedCandidate.aspx">View UnMapped
                        Candidates</a> | <a href="EditProfilePriority.aspx" target="_blank">Update Priority</a>
        </div>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="5">
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
                    <th style="width: 2%">
                        S.No.
                    </th>
                    <th align="center" style="width: 20%">
                        Profile Name
                    </th>
                    <th align="center" style="width: 20%">
                        Profile Description
                    </th>
                       <th align="center" style="width: 10%">
                        Profile Prefix
                    </th>
                    <th align="center" style="width: 10%">
                        Action
                    </th>
                 
                   <%-- <th style="width: 18%">
                        &nbsp;
                    </th>--%>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptProfileLists" runat="server" OnItemDataBound="rptProfileLists_ItemDataBound"
                    OnItemCommand="rptProfileLists_ItemCommand">
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Profile_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_Desc")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("prefix")%>
                            </td>
                            <td style="text-align: center">
                                <span id="divAction32" clientidmode="Static" runat="server" visible="false"><a id="aEdit" runat="server"
                                    class="openframe">
                                    <img src="/assetsprocurement/images/edit.png" title="Edit" />
                                </a>| </span><span id="divAction33" clientidmode="Static" runat="server" visible="false">
                                    <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                        CommandName="DeleteProfile" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                        CommandArgument='<%# Eval("Profile_Code")%>' />
                               | </span> <span id="divAction34" clientidmode="Static" runat="server" visible="false"><a id="aViewParameter"
                                    runat="server" class="openframelarge">
                                    <img src="/assetsprocurement/images/icons/view-icon-new.jpg" title="View" />
                                </a></span>
                            </td>
                           <%-- <td style="text-align: center">
                                <span id="divAction35" clientidmode="Static" runat="server" visible="false"><a id="aUpdateScore" runat="server"
                                    class="openframe">Update Parameter Rank </a></span>
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Profile_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_Desc")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("prefix")%>
                            </td>
                            <td style="text-align: center">
                                <span id="divAction32" runat="server" visible="false" clientidmode="Static"><a id="aEdit" runat="server"
                                    class="openframe">
                                    <img src="/assetsprocurement/images/edit.png" title="Edit" />
                                </a>| </span><span id="divAction33" clientidmode="Static" runat="server" visible="false">
                                    <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                        CommandName="DeleteProfile" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                        CommandArgument='<%# Eval("Profile_Code")%>' />
                               | </span>  <span id="divAction34" clientidmode="Static" runat="server" visible="false"><a id="aViewParameter"
                                    runat="server" class="openframelarge">
                                    <img src="/assetsprocurement/images/icons/view-icon-new.jpg" title="View" />
                                </a></span>
                            </td>
                            <%--<td style="text-align: center">
                                <span id="divAction35" runat="server" clientidmode="Static" visible="false"><a id="aUpdateScore" runat="server"
                                    class="openframe">Update Parameter Rank </a></span>
                            </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
