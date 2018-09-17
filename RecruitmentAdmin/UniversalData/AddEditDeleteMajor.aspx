<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AddEditDeleteMajor.aspx.cs" Inherits="UniversalData_AddEditDeleteMajor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Major List</title>
    <script type="text/javascript">

        function ConfirmDelete() {
            var answer = confirm("Are you sure you want to Delete?");

            if (answer) {
                return true;
            }
            else
                return false;

        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>List of Majors</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 50%" align="center">
                    Major Name:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtMajorName" Width="312"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                    </asp:LinkButton>
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="counter" runat="server" />
                <br />
                <table width="80%" border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="6">
                                <table border="0" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <th height="25" align="center">
                                            <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                                ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                            &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                                Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                                Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                            &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="Label" Visible="False" Font-Bold="true"
                                                ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton ID="lnkbtnNextPage"
                                                    runat="server" Font-Bold="True" Font-Underline="False" ToolTip="Next Page" OnClick="lnkbtnNextPage_Click"
                                                    Visible="False">&gt;&gt;</asp:LinkButton>&nbsp; &nbsp;<asp:LinkButton ID="lnkbtnLastPage"
                                                        runat="server" Font-Bold="True" Font-Underline="False" ToolTip="Last Page" OnClick="lnkbtnLastPage_Click"
                                                        Visible="False">&gt;</asp:LinkButton>
                                        </th>
                                    </tr>
                                </table>
                            </th>
                        </tr>
                    </thead>
                </table>
                <br />
                <div align="right" style="width: 100%; float: left; padding: 10px 0px;">
                    <asp:DropDownList ID="ddlNo" runat="server" Width="40px">
                        <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="3"></asp:ListItem>
                        <asp:ListItem Value="4"></asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                        <asp:ListItem Value="6"></asp:ListItem>
                        <asp:ListItem Value="7"></asp:ListItem>
                        <asp:ListItem Value="8"></asp:ListItem>
                        <asp:ListItem Value="9"></asp:ListItem>
                        <asp:ListItem Value="10"></asp:ListItem>
                        <asp:ListItem Value="11"></asp:ListItem>
                        <asp:ListItem Value="12"></asp:ListItem>
                        <asp:ListItem Value="13"></asp:ListItem>
                        <asp:ListItem Value="14"></asp:ListItem>
                        <asp:ListItem Value="15"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lbtnAddNew_Click" CssClass="addsimple">Add Major </asp:LinkButton>
                </div>
                <asp:Repeater ID="rptMajor" runat="server" OnItemDataBound="rptMajor_ItemDataBound"
                    OnItemCommand="rptMajor_ItemCommand">
                    <HeaderTemplate>
                        <table width="80%" border="0" cellpadding="10" cellspacing="0">
                            <thead>
                                <tr class="simple">
                                    <th style="width: 2%">
                                        S.No.
                                    </th>
                                    <th align="center" style="width: 20%">
                                        Major Name
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnMajorCode" runat="server" Value='<%# Eval("Major_Code")%>' />
                                <asp:HiddenField ID="hdnCount" runat="server" Value='<%# Eval("count")%>' />
                                <asp:Label ID="lblMajorName" runat="server" Text='<%# Eval("Major_Name")%>'></asp:Label>
                                <asp:TextBox ID="txtMajorName" runat="server" Visible="false" Width="250px" Text='<%# Eval("Major_Name")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Required1" runat="server" ErrorMessage="*" Display="Dynamic"
                                    Text="*" ToolTip="Enter Major Name" ValidationGroup="valida" ControlToValidate="txtMajorName"></asp:RequiredFieldValidator>
                            </td>
                            <td style="text-align: center">
                                <asp:ImageButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Major_Code")%>'
                                    ImageUrl="/assetsprocurement/images/edit.png" />
                                <asp:LinkButton ID="lnkCancelEdit" runat="server" Visible="false" CommandName="CancelEdit"
                                    Text="Cancel Edit"></asp:LinkButton>
                                <asp:Label ID="lbl" runat="server" Text="|"></asp:Label>
                                <asp:ImageButton ID="lnkDelete" OnClientClick="return ConfirmDelete();" runat="server"
                                    CommandName="Delete" CommandArgument='<%# Eval("Major_Code")%>' ImageUrl="/assetsprocurement/images/Delete.png" />
                                <asp:LinkButton ID="lnkSave" CommandArgument='<%# Eval("Major_Code")%>' runat="server"
                                    Visible="false" CommandName="Save" ValidationGroup="valida" Text="Save"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnMajorCode" runat="server" Value='<%# Eval("Major_Code")%>' />
                                <asp:HiddenField ID="hdnCount" runat="server" Value='<%# Eval("count")%>' />
                                <asp:Label ID="lblMajorName" runat="server" Text='<%# Eval("Major_Name")%>'></asp:Label>
                                <asp:TextBox ID="txtMajorName" runat="server" Width="250px" Visible="false" Text='<%# Eval("Major_Name")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Required1" runat="server" ErrorMessage="*" Display="Dynamic"
                                    Text="*" ToolTip="Enter Major Name" ValidationGroup="valida" ControlToValidate="txtMajorName"></asp:RequiredFieldValidator>
                            </td>
                            <td style="text-align: center">
                                <asp:ImageButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Major_Code")%>'
                                    ImageUrl="/assetsprocurement/images/edit.png" />
                                <asp:LinkButton ID="lnkCancelEdit" runat="server" Visible="false" CommandName="CancelEdit"
                                    Text="Cancel Edit"></asp:LinkButton>
                                <asp:Label ID="lbl" runat="server" Text="|"></asp:Label>
                                <asp:ImageButton ID="lnkDelete" OnClientClick="return ConfirmDelete();" runat="server"
                                    CommandName="Delete" CommandArgument='<%# Eval("Major_Code")%>' ImageUrl="/assetsprocurement/images/Delete.png" />
                                <asp:LinkButton ID="lnkSave" CommandArgument='<%# Eval("Major_Code")%>' runat="server"
                                    Visible="false" CommandName="Save" ValidationGroup="valida" Text="Save"></asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <div style="text-align: center;">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-ora nl" Width="80px" Text="Save" OnClick="btnSave_Click" />
                </div>
                <%--         </tbody>
                </table>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
