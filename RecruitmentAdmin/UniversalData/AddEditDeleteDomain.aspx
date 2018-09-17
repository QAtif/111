<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditDeleteDomain.aspx.cs" Inherits="UniversalData_AddEditDeleteDomain" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Domain List</title>
    <script src="../A2/assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script type="text/javascript">

        function ConfirmDelete() {
            var answer = confirm("Are you sure you want to Delete?");
            if (answer) {
                return true;
            }
            else
                return false;
        }


        function onpress() {
            $('#id_search_list').quicksearch('#test tbody tr');
            // $('#id_search_list').val('content');
        }
  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>List of Domains</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="60%" border="0" cellpadding="10" cellspacing="0" style="display:none">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 50%" align="center">
                    Domain Name:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtDomainName" Width="312"></asp:TextBox>
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
                <div align="left" style="width: 50%; float: left; padding: 10px 0px;">
                    Filter: &nbsp;
                    <input type="text" name="" value="" id="id_search_list" placeholder="Enter Keywords"
                        onkeyup="javascript:onpress();" /></div>
                <div align="right" style="width: 50%; float: left; padding: 10px 0px;">
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
                    <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lbtnAddNew_Click" CssClass="addsimple">Add Domain </asp:LinkButton>
                </div>
                <asp:Repeater ID="rptDomain" runat="server" OnItemDataBound="rptDomain_ItemDataBound"
                    OnItemCommand="rptDomain_ItemCommand">
                    <HeaderTemplate>
                        <table width="80%" border="0" cellpadding="10" cellspacing="0" id="test">
                            <thead>
                                <tr class="simple">
                                    <th style="width: 2%">
                                        S.No.
                                    </th>
                                    <th align="center" style="width: 40%">
                                        Domain Name
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Shifts
                                    </th>
                                    <th align="center" style="width: 10%">
                                        height/Weight
                                    </th>
                                    <th align="center" style="width: 40%">
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
                                <asp:HiddenField ID="hdnDomainCode" runat="server" Value='<%# Eval("Domain_Code")%>' />
                                <asp:HiddenField ID="hdnCount" runat="server" Value='<%# Eval("count")%>' />
                                <asp:Label ID="lblDomainName" runat="server" Text='<%# Eval("Domain_Name")%>'></asp:Label>
                                <asp:TextBox ID="txtDomainName" runat="server" Visible="false" Width="250px" Text='<%# Eval("Domain_Name")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Required1" runat="server" ErrorMessage="*" Display="Dynamic"
                                    Text="*" ToolTip="Enter Domain Name" ValidationGroup="valida" ControlToValidate="txtDomainName"></asp:RequiredFieldValidator>
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chkShifts" runat="server" />
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chkHW" runat="server" />
                            </td>
                            <td style="text-align: center">
                                <asp:ImageButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Domain_Code")%>'
                                    ImageUrl="/assetsprocurement/images/edit.png" />
                                <asp:LinkButton ID="lnkCancelEdit" runat="server" Visible="false" CommandName="CancelEdit"
                                    Text="Cancel Edit"></asp:LinkButton>
                                <asp:Label ID="lbl" runat="server" Text="|"></asp:Label>
                                <asp:ImageButton ID="lnkDelete" OnClientClick="return ConfirmDelete();" runat="server"
                                    CommandName="Delete" CommandArgument='<%# Eval("Domain_Code")%>' ImageUrl="/assetsprocurement/images/Delete.png" />
                                <asp:LinkButton ID="lnkSave" CommandArgument='<%# Eval("Domain_Code")%>' runat="server"
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
                                <asp:HiddenField ID="hdnDomainCode" runat="server" Value='<%# Eval("Domain_Code")%>' />
                                <asp:HiddenField ID="hdnCount" runat="server" Value='<%# Eval("count")%>' />
                                <asp:Label ID="lblDomainName" runat="server" Text='<%# Eval("Domain_Name")%>'></asp:Label>
                                <asp:TextBox ID="txtDomainName" runat="server" Width="250px" Visible="false" Text='<%# Eval("Domain_Name")%>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Required1" runat="server" ErrorMessage="*" Display="Dynamic"
                                    Text="*" ToolTip="Enter Domain Name" ValidationGroup="valida" ControlToValidate="txtDomainName"></asp:RequiredFieldValidator>
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chkShifts" runat="server" />
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chkHW" runat="server" />
                            </td>
                            <td style="text-align: center">
                                <asp:ImageButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Domain_Code")%>'
                                    ImageUrl="/assetsprocurement/images/edit.png" />
                                <asp:LinkButton ID="lnkCancelEdit" runat="server" Visible="false" CommandName="CancelEdit"
                                    Text="Cancel Edit"></asp:LinkButton>
                                <asp:Label ID="lbl" runat="server" Text="|"></asp:Label>
                                <asp:ImageButton ID="lnkDelete" OnClientClick="return ConfirmDelete();" runat="server"
                                    CommandName="Delete" CommandArgument='<%# Eval("Domain_Code")%>' ImageUrl="/assetsprocurement/images/Delete.png" />
                                <asp:LinkButton ID="lnkSave" CommandArgument='<%# Eval("Domain_Code")%>' runat="server"
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
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-ora nl" Width="80px" Text="Save"
                        OnClick="btnSave_Click" />
                </div>
                <%--         </tbody>
                </table>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">

        function MarkFeaturesOnDomain(DomainCode, IsActive, Type) {
            var IsActiveVal = false;
            if ($('#' + IsActive).attr('checked'))
                IsActiveVal = true;
            if (DomainCode != 0 && IsActive != '') {
                var Param = DomainCode + '|' + IsActiveVal + '|' + Type + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>'
                //alert(Param);
                $.ajax({ type: "POST",
                    url: "AddEditDeleteDomain.aspx/MarkFeaturesOnDomain",
                    data: JSON.stringify({ items: Param }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                    },
                    error: function (msg) {
                        alert("error");
                    }
                });
            }

        }
    </script>
</asp:Content>
