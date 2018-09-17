<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="UpdateCandidateInfo.aspx.cs" Inherits="Candidate_UpdateCandidateInfo" %>

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
                //parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

        function CheckLimit(txt) {
            if (txt.length > 2000)
                return false;
            else
                return true;

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Update Status"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnTypeCode" runat="server" Value="0" />
            <asp:HiddenField ID="hdnCandidateCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr id="trStatus" runat="server" visible="false" class="simple">
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" Width="300px" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trProfile" runat="server" visible="false" class="simple">
                    <td>
                        Profile:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProfile" Width="300px" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trRequisition" runat="server" visible="false" class="simple">
                    <td>
                        Requisition
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRequisition" Width="300px" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Comments:
                    </td>
                    <td>
                        <asp:TextBox ID="txtComments" TextMode="MultiLine" Width="600px" onkeydown="return CheckLimit(this.value);" runat="server" Height="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Required1" runat="server" ControlToValidate="txtComments"
                            ErrorMessage="Please enter comments" ValidationGroup="valida" Text="*">                        
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Update Status" CssClass="btn-ora nl"
                            ValidationGroup="valida" OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
