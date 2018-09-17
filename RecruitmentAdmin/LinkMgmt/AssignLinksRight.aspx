<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AssignLinksRight.aspx.cs" Inherits="LinkMgmt_AssignLinksRight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Assign Right(s)</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Link Management</span>
        </h2>
        <script type="text/javascript">
            $(".openframeCand").fancybox({
                fitToView: false,
                width: '93%',
                height: '93%',
                autoSize: false,
                openEffect: 'none',
                closeEffect: 'none',
                type: 'iframe'
            });

            function toggleSelection(source, targetID) {

                var target = source.parentNode.parentNode.parentNode.parentNode;
                // Find all checkboxes

                var inputs = target.getElementsByTagName('input');

                //Check all   
                if (source.checked)
                    for (var i = 0; i < inputs.length; i++) {
                        if (inputs[i].type == "checkbox") {
                            if (inputs[i].id.indexOf(targetID) >= 0) {
                                inputs[i].checked = true;
                            }
                        }
                    }
                // Uncheck all   
                else
                    for (var i = 0; i < inputs.length; i++) {
                        if (inputs[i].type == "checkbox") {
                            if (inputs[i].id.indexOf(targetID) >= 0) {
                                inputs[i].checked = false;
                            }
                        }

                    }
                }


            function ParentsCheck(source, targetID) {
                debugger;
                var conC = document.getElementById(targetID);
                var conP = document.getElementById(source);
                var target = conP.parentNode.parentNode.parentNode.parentNode;
                var inputs = target.getElementsByTagName('input');
                var IsAnyChecked = true;

                        for (var i = 0; i < inputs.length; i++) {
                            if (inputs[i].type == "checkbox") {
                                if (inputs[i].id.indexOf(targetID) >= 0) {
                                    if (inputs[i].checked) {                                        
                                        IsAnyChecked = false;
                                    }
                                }
                            }
                        }

                    if (IsAnyChecked)
                        conP.checked =false ;
                    else
                        conP.checked = true;
            }

        </script>
    </div>
    <div id="container" class="contentarea">
        <asp:HiddenField ID="hdfUserID" runat="server" />
        <asp:HiddenField ID="hfd_UserID" runat="server" />
        <asp:HiddenField ID="hfd_UserTypeID" runat="server" />
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th width="21%" align="left" valign="top">
                    &nbsp;<strong>Search: </strong>
                </th>
                <th colspan="1" align="left" valign="top">
                    <strong>User Information</strong>
                </th>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <table width="80%" border="0" cellpadding="10" cellspacing="0">
                        <tr class="simple" id="trDept" runat="server">
                            <td width="23%">
                                Department:
                            </td>
                            <td width="77%">
                                <asp:DropDownList ID="ddl_Department" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Department_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="simple" id="truser" runat="server">
                            <td>
                                Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txt_UserName" runat="server" Width="250"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="simple" id="trRole" visible="false" runat="server">
                            <td width="30%">
                                User Type:
                            </td>
                            <td width="70%">
                                <asp:DropDownList ID="ddlTeamUserType" runat="server" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="simple">
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtnUser" GroupName="rbtn" Checked="true" runat="server" Text="Search User"
                                    AutoPostBack="True" OnCheckedChanged="rbtnUser_CheckedChanged" />
                                &nbsp;
                                <asp:RadioButton ID="rbtnUserType" GroupName="rbtn" runat="server" Text="Search UserType"
                                    AutoPostBack="True" OnCheckedChanged="rbtnUserType_CheckedChanged" />
                            </td>
                        </tr>
                        <tr class="simple" style="height: 20px">
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="61%" align="left" valign="top" bgcolor="#F5F5F5">
                    <table width="80%" border="0" cellpadding="0" cellspacing="0">
                        <tr class="simple" id="trUser2" runat="server">
                            <td width="75%" align="left" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="27%">
                                            <strong>Name:</strong>
                                        </td>
                                        <td width="73%">
                                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Designation:</strong>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <strong>Department:</strong>
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%" align="center">
                                <img id="imgUser" runat="server" src="/assets/images/Face10.jpg" style="border: 1px solid #000"
                                    width="120" />
                            </td>
                        </tr>
                        <tr class="simple" id="trRole2" runat="server" visible="false">
                            <td width="75%" align="left" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="27%">
                                            <strong>UserType Name:</strong>
                                        </td>
                                        <td width="73%">
                                            <asp:Label ID="lblUserTypeName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--     <tr>
                                        <td>
                                            <strong>UserType Description:</strong>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbUserTypeDescription" runat="server"></asp:Label>
                                        </td>
                                    </tr--%>
                                </table>
                            </td>
                            <td width="25%" align="center">
                                <img id="img1" runat="server" src="/assets/images/Face10.jpg" style="border: 1px solid #000"
                                    width="120" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:Repeater ID="rptUser" runat="server" OnItemCommand="rptUser_ItemCommand">
                        <HeaderTemplate>
                            <table width="98%" cellpadding="0" cellspacing="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="simple">
                                <td>
                                    <img src="/assets/images/bullet.gif" />&nbsp;
                                    <asp:LinkButton ID="lnk_UserName" runat="server" Text='<%#Eval("fullname") %>' CommandName="BindUser"
                                        CommandArgument='<%#Eval("userid") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td colspan="1" align="left" valign="top">
                    <div style="text-align: center">
                        <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" Visible="false"></asp:Label></div>
                    <table width="80%" border="0" cellspacing="0" cellpadding="0">
                        <tr id="tr1" runat="server" visible="false" class="simple">
                            <td bgcolor="#F7F7F7" style="font-weight: bold">
                                User Type: &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddluserType" Width="300px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="required1" runat="server" ControlToValidate="ddluserType"
                                    ErrorMessage="*" Text="*" ToolTip="select usertype" ValidationGroup="valida"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr3" runat="server" visible="false" class="simple">
                            <td bgcolor="#F7F7F7">
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <th>
                                            <b>Domain</b>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="chblistDomain" BorderStyle="None" runat="server" CellPadding="2"
                                                CellSpacing="4" RepeatDirection="Horizontal" RepeatColumns="4">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="tr2" runat="server" visible="false" class="simple">
                            <td bgcolor="#F7F7F7">
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <th>
                                            <b>Links</b>
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rptCategory" runat="server" OnItemDataBound="rptCategory_ItemDataBound">
                                        <ItemTemplate>
                                            <tr id="trView1" runat="server" class="simple">
                                                <th>
                                                    <asp:CheckBox ID="rbLinkCat" runat="server" Text='<%#Eval("MenuLinkName") %>' />
                                                    <asp:HiddenField ID="hdnMenuLinkID" runat="server" Value='<%#Eval("MenuLinkID") %>' />
                                                </th>
                                            </tr>
                                            <tr id="trView2" runat="server">
                                                <td>
                                                    <asp:CheckBoxList ID="chblLinks" BorderStyle="None" runat="server" CellPadding="2"
                                                        CellSpacing="4" RepeatDirection="Horizontal" RepeatColumns="4">
                                                    </asp:CheckBoxList>
                                                    <%--      <asp:Repeater ID="rptLink" runat="server" OnItemDataBound="rptLink_ItemDataBound">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="rbLink" Style="margin-left: 10px" runat="server" Text='<%#Eval("MenuLinkName") %>' />
                                                            <asp:HiddenField ID="hdnMenuLinkID" runat="server" Value='<%#Eval("MenuLinkID") %>' />
                                                        </ItemTemplate>
                                                    </asp:Repeater>--%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <%--    <tr>
                                        <th>
                                            <b>Roles</b>
                                        </th>
                                    </tr>
                                 <asp:Repeater ID="rptRole" runat="server" OnItemDataBound="rptRole_ItemDataBound">
                                        <ItemTemplate>
                                            <tr id="trView1" runat="server" class="simple">
                                                <td>
                                                    <asp:CheckBox ID="rbRole" runat="server" Text='<%#Eval("RoleName") %>' />
                                                    <asp:HiddenField ID="hdnRoleID" runat="server" Value='<%#Eval("RoleID") %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>--%>
                                    <tr class="simple" align="center">
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="valida" CssClass="btn-ora nl"
                                                Width="80px" OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--  <tr id="trRoleLinks" runat="server" visible="false" class="simple">
                            <td bgcolor="#F7F7F7">
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <th>
                                            <b>Links</b>
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rptRoleLink" runat="server" OnItemDataBound="rptRoleLink_ItemDataBound">
                                        <ItemTemplate>
                                            <tr id="trView1" runat="server" class="simple">
                                                <th>
                                                    <asp:CheckBox ID="rbLinkCat" runat="server" Text='<%#Eval("MenuLinkName") %>' />
                                                    <asp:HiddenField ID="hdnMenuLinkID" runat="server" Value='<%#Eval("MenuLinkID") %>' />
                                                </th>
                                            </tr>
                                            <tr id="trView2" runat="server">
                                                <td>
                                                    <asp:Repeater ID="rptRoleChildLink" runat="server" OnItemDataBound="rptRoleChildLink_ItemDataBound">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="rbLink" Style="margin-left: 10px" runat="server" Text='<%#Eval("MenuLinkName") %>' />
                                                            <asp:HiddenField ID="hdnMenuLinkID" runat="server" Value='<%#Eval("MenuLinkID") %>' />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr class="simple" align="center">
                                        <td>
                                            <asp:Button ID="btnSaveRole" runat="server" Text="Save" CssClass="btn-ora nl" Width="80px"
                                                OnClick="btnSaveRole_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr id="trRoleLinks" runat="server" visible="false" class="simple">
                            <td bgcolor="#F7F7F7" style="text-align: center">
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <th>
                                            <b>Links</b>
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rptRoleLink" runat="server" OnItemDataBound="rptRoleLink_ItemDataBound">
                                        <ItemTemplate>
                                            <tr id="trView1" runat="server" class="simple">
                                                <th>
                                                    <asp:CheckBox ID="rbLinkCat" runat="server" Text='<%#Eval("MenuLinkName") %>' />
                                                    <asp:HiddenField ID="hdnMenuLinkID" runat="server" Value='<%#Eval("MenuLinkID") %>' />
                                                </th>
                                            </tr>
                                            <tr id="trView2" runat="server">
                                                <td>
                                                    <asp:CheckBoxList ID="chblChildLink" runat="server" BorderStyle="None" runat="server"
                                                        CellPadding="2" CellSpacing="4" RepeatDirection="Horizontal" RepeatColumns="4">
                                                    </asp:CheckBoxList>
                                                    <%--    <asp:Repeater ID="rptRoleChildLink" runat="server" OnItemDataBound="rptRoleChildLink_ItemDataBound">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="rbLink" Style="margin-left: 10px" runat="server" Text='<%#Eval("MenuLinkName") %>' />
                                                            <asp:HiddenField ID="hdnMenuLinkID" runat="server" Value='<%#Eval("MenuLinkID") %>' />
                                                        </ItemTemplate>
                                                    </asp:Repeater>--%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr class="simple" align="center">
                                        <td>
                                            <asp:Button ID="btnSaveRole" runat="server" Text="Save" CssClass="btn-ora nl" Width="80px"
                                                OnClick="btnSaveRole_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

