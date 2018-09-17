<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditLink.aspx.cs" Inherits="LinkMgmt_AddEditLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Add Link</title>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                parent.window.location.href = mainURL; //  + "?" + window.location.search.substring(1);
                //   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Add Link"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnLinkCode" runat="server" Value="0" />
            <asp:HiddenField ID="hdnParentCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        Link Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLinkName" runat="server" Width="400px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtLinkName"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="Link name can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        URL:
                    </td>
                    <td>
                        <asp:TextBox ID="txtURL" runat="server" Width="400px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="txtURL" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="URL can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple" id="trMove" runat="server">
                    <td>
                       Move:
                    </td>
                    <td>
                       <asp:DropDownList ID="ddlMove" runat="server" Width="400px"></asp:DropDownList >
                       
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:CheckBox ID="chkMain" runat="server" Checked="true" Text="Main Page" />
                    </td>
                </tr>
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Add New Link" CssClass="btn-ora nl"
                            ValidationGroup="valida" OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
