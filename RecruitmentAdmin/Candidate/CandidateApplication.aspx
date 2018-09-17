<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="CandidateApplication.aspx.cs" Inherits="Candidate_CandidateApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate Detail</title>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Candidate Application"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnCandidateCode" runat="server" Value="0" />
            <asp:Repeater ID="rptApplication" runat="server" OnItemCommand="rptApplication_ItemCommand"
                OnItemDataBound="rptApplication_ItemDataBound">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td align="center">
                                <strong>SNo.</strong>
                            </td>
                            <td align="center">
                                <strong>Requisition Name</strong>
                            </td>
                            <td align="center">
                                <strong>Profile Name</strong>
                            </td>
                            <td align="center">
                                <strong>Category Name</strong>
                            </td>
                            <td align="center">
                                <strong>City</strong>
                            </td>
                            <td align="center">
                                <strong>Domain</strong>
                            </td>
                            <td align="center">
                                <strong>Sub Domain</strong>
                            </td>
                            <td align="center">
                                <strong>Action</strong>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblRequisitionName" Text='<%# Eval("Requisition_Name")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblProfileName" Text='<%# Eval("Profile_Name")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label1" Text='<%# Eval("Category_Name")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label2" Text='<%# Eval("City")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label3" Text='<%# Eval("Domain_Name")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label4" Text='<%# Eval("SubDomain_Name")%>' runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblStatusActive" runat="server"></asp:Label>
                            <%--  <asp:LinkButton ID="lnkbtnStatusActive" CommandName="Active" runat="server" CommandArgument='<%# Eval("Application_Code")%>'></asp:LinkButton>--%>
                            <asp:LinkButton ID="lnkbtnStatusInActive" CommandName="InActive" OnClientClick='return confirm("Are you sure you want to Active?");'
                                runat="server" CommandArgument='<%# Eval("Application_Code")%>'></asp:LinkButton>
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
