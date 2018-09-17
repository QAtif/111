<%@ Page Title="" Language="C#" MasterPageFile="~/popup.master" AutoEventWireup="true"
    CodeFile="AddLinkAction.aspx.cs" Inherits="UniversalData_AddLinkAction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Action List</title>
    
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
<br />
<br />
    <div class="headbar">
        <h2>
            <span>Menu Action Marking</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr class="simple">
                    <th style="width: 2%" align="left">
                    <h4>
                        <asp:Label ID="lblHead" runat="server"></asp:Label></h4>
                        <asp:HiddenField ID="hdnMenuLinkCode" runat="server" Value="0" />
                    </th>
                </tr>
            </thead>
        </table>
        <br />
        <br />
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
            <tr id="trActions" runat="server" visible="false">
                <td colspan="2" align="left">
                    <asp:CheckBoxList ID="chblAction" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="trbtn" runat="server" visible="false">
                <td colspan="2" align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="Update" class="btn-ora nl" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
        <div style="text-align: center;">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>
        <br />
        <asp:Repeater ID="rptLink" runat="server" OnItemDataBound="rptLink_ItemDataBound">
            <HeaderTemplate>
                <table width="80%" border="0" cellpadding="10" cellspacing="0">
                    <tr>
                        <%--   <td>
                            S.No
                        </td>--%>
                        <th align="center" style="font-weight: bold">
                            Menu Link Action Code
                        </th>
                        <th align="center" style="font-weight: bold">
                            Action Name
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <%--      <td>
                        <asp:Label ID="lblSNo" runat="server"></asp:Label>
                    </td>--%>
                    <td align="center">
                        <%# Eval("MenuLinkActionCode")%>
                    </td>
                    <td align="center">
                        <%# Eval("Action")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
