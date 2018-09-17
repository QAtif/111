<%@ Page Title="" Language="C#" MasterPageFile="~/A2/A2Popup.master" AutoEventWireup="true"
    CodeFile="UpdateCandidateProfileInfo.aspx.cs" Inherits="A2_Candidate_UpdateCandidateProfileInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate Detail</title>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~")%>A2/assets/css/style.css" />
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
            <asp:Label runat="server" ID="lblHead" Text="Update Profile"></asp:Label>
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
                <tr>
                    <td>
                        Joining Date:
                    </td>
                    <td>
                        <input name="JoiningDate" id="JoiningDate" type="text" runat="server" clientidmode="Static"
                            readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Grade
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGrade" Width="170px" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlGrade"
                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Grade is required!' />"
                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Designation
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDesignation" Width="170px" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlDesignation"
                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Designation is required!' />"
                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Shift
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlShift" Width="170px" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlShift"
                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Shift is required!' />"
                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Reporting Authority
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRA" runat="server" Width="170px">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRA"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='RA is required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="AcceptCheckRA"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Group Leader:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGL" runat="server" Width="170px" CssClass="select">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlGL" runat="server"
                                        ValidationGroup="AcceptCheckRA" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Team Leader:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTL" runat="server" Width="170px" CssClass="select">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlTL" runat="server"
                                        ValidationGroup="shift" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Team
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlJD" Width="170px" runat="server">
                        </asp:DropDownList>
                        <%-- <asp:TextBox runat="server" ID="txtTeamMapping"></asp:TextBox>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlJD"
                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Team is Required!' />"
                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        B.U
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBU" Width="170px" runat="server">
                        </asp:DropDownList>
                        <%-- <asp:TextBox runat="server" ID="txtTeamMapping"></asp:TextBox>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlBU"
                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='BU is Required!' />"
                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Update" CssClass="btn-ora nl" ValidationGroup="valida"
                            OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#JoiningDate").datepicker({
                changeMonth: true,
                changeYear: true,
                //  buttonImage: '/assets/images/edit.png',
                // buttonImageOnly: true,
                dateFormat: "M dd, yy"
                // showOn: 'button',

            });
        });
    </script>
</asp:Content>
