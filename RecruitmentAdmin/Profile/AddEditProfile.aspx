<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditProfile.aspx.cs" Inherits="Profile_AddEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Profile</title>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                //   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Add New Profile"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnProfileCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <asp:HiddenField ID="counter" runat="server" />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        Profile Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtProfileName" runat="server" Width="200px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtProfileName"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="Profile name can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Profile Description:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesc" runat="server" Width="200px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                            ControlToValidate="txtDesc" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Profile description can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr class="simple">
                    <td>
                        Profile Prefix:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrefix" runat="server" Width="200px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="txtPrefix" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Profile prefix can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            
            </table>
            <br />
            <br />
            <asp:Repeater ID="rptParameter" runat="server" OnItemDataBound="rptParameter_ItemDataBound"
                OnItemCommand="rptParameter_ItemCommand">
                <HeaderTemplate>
                    <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
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
                            <asp:HiddenField ID="hdnCount" runat="server" Value='<%# Eval("count")%>' />
                            <asp:HiddenField ID="addCount" runat="server" />
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
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div align="right" style="width: 100%; float: left; padding: 10px 0px;">
                <asp:LinkButton ID="lbtnAddNew" runat="server" OnClick="lbtnAddNew_Click" CssClass="addsimple">Add Parameter </asp:LinkButton>
            </div>
            <br />
            <br />
            <div style="text-align: center">
                <asp:Button ID="btnAdd" runat="server" Text="Add Profile" CssClass="btn-ora nl" ValidationGroup="valida"
                    OnClick="btnAdd_Click" />
                <br />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
