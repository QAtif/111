<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="CountReport.aspx.cs"
    Inherits="Reports_CandidateCountReport" MasterPageFile="~/site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate Report</title>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtDateTo.ClientID%>").datepicker({ dateFormat: 'dd MM, yy' });
            $("#<%=txtDateFrom.ClientID%>").datepicker({ dateFormat: 'dd MM, yy' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Candidate Status wise</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="200px" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td width="200px">
                    <table width="60%" border="0" cellpadding="10" cellspacing="0">
                        <tr>
                            <th>
                                Search Criteria
                                <br />
                                <%=LocalIPAddress()%>
                            </th>
                        </tr>
                        <tr>
                            <td style="width: 50%" align="center">
                                <table style="width: 50%" align="center">
                                    <tr>
                                        <td style="width: 30%" align="right">
                                            Date From:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDateFrom" runat="server" Width="120px"></asp:TextBox>
                                        </td>
                                        <td style="width: 30%" align="right">
                                            Date To:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDateTo" runat="server" Width="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <br />
                                <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                                    ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                                </asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="20%" border="0" cellpadding="10" cellspacing="0">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" RowStyle-CssClass="simple"
                                                AlternatingRowStyle-CssClass="grey" Width="500px">
                                                <Columns>
                                                    <asp:BoundField DataField="Status" HtmlEncode="false" HeaderText="Status" ItemStyle-HorizontalAlign="Left"
                                                        ItemStyle-Width="130px" HeaderStyle-Font-Bold="true" />
                                                    <asp:BoundField DataField="Candidate Count" HtmlEncode="false" HeaderText="Candidate Count"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" HeaderStyle-Font-Bold="true" />
                                                </Columns>
                                            </asp:GridView>
                                            <div style="text-align: center">
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                <br />
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>
