<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="CandidateScreening.aspx.cs" Inherits="Candidate_CandidateScreening" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate Calling History</title>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                // parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);

                parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    </script>
    <style>
        .BtnSave {
            background: #4b8efc !important;
            linear-gradient(to bottom, #4b8efc 0%, #4787ee 100%) !important;
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important;
            border: 1px solid #3079ed !important;
            color: #fff;
            padding: 4px 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Candidate Screening History"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <div style="padding-bottom:50px">
                <table>
                    <tr>
                        <td>Comments</td>
                        <td>
                            <asp:TextBox ID="txtCallComments" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" CssClass="BtnSave" />
                            <asp:Button ID="btnNoreponse" runat="server" OnClick="btnNoreponse_Click" Text="No Reponse" CssClass="BtnSave" />
                        </td>
                    </tr>
                </table>

            </div>
            <asp:HiddenField ID="hdnCandidateCode" runat="server" Value="0" />

            <asp:Repeater ID="rptCalls" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td align="center">
                                <strong>SNo.</strong>
                            </td>
                            <td align="center">
                                <strong>Caller Name</strong>
                            </td>
                            <td align="center">
                                <strong>Date</strong>
                            </td>
                            <td align="center">
                                <strong>Comments</strong>
                            </td>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblSno" runat="server"> <%# Container.ItemIndex + 1 %></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblRequisitionName" Text='<%# Eval("name")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblProfileName" Text='<%# Eval("Created_Date")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label1" Text='<%# Eval("Comments")%>' runat="server"></asp:Label>
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
