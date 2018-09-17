<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="ViewProfileParameter.aspx.cs" Inherits="Profile_ViewProfileParameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>View Profile Parameter</title>
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
            <asp:Label runat="server" ID="lblHead" Text="View Profile Parameter"></asp:Label>
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
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr>
                    <th width="10%" style="font-weight: bold">
                        Profile Name
                    </th>
                    <th>
                        &nbsp;
                    </th>
                </tr>
                <tr class="simple">
                    <td align="center" valign="top">
                        <asp:Repeater ID="rptProfile" runat="server" OnItemDataBound="rptProfile_ItemDataBound">
                            <ItemTemplate>
                                <%# Eval("Profile_Name")%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>
                        <asp:GridView runat="server" ID="gvTotalLeads" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvTotalLeads_RowDataBound"
                            ShowFooter="True" BorderWidth="1px" BorderStyle="Solid" Width="100%" >
                            <Columns>
                            </Columns>
                        </asp:GridView>
                        <%--      <asp:GridView ID="gvParameter" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <td>
                                            <%# Eval("Parameter_Name")%> 
                                        </td>
                                    </HeaderTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>--%>
                        <%--<asp:Repeater ID="rptParameter" runat="server" OnItemDataBound="rptParameter_ItemDataBound">
                            <HeaderTemplate>
                                <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                                    <tr>
                                        <td>
                                            Test
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td align="center">
                                        <%# Eval("Parameter_Name")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>--%>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
