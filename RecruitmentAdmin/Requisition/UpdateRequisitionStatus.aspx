<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="UpdateRequisitionStatus.aspx.cs" Inherits="Requisition_UpdateRequisitionStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Raise Requisition</title>
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
            <asp:Label runat="server" ID="lblHead" Text="Raise Requisition"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        Requisition Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequisitionName" runat="server" Width="200px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtRequisitionName"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="Requisition name can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Domain:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDomain" runat="server" Width="200px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                            ControlToValidate="ddlDomain" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select domain"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select SubDomain:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubDomain" runat="server" Width="200px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlSubDomain_SelectedIndexChanged">                         
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                            ControlToValidate="ddlSubDomain" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select subdomain"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Category:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="200px">
                            <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                            ControlToValidate="ddlCategory" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select category"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select City:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCity" runat="server" Width="200px">
                            <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server"
                            ControlToValidate="ddlCity" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select city"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        No. Of Candidates:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoOfCandidate" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server"
                            ControlToValidate="txtNoOfCandidate" Text="*" ValidationGroup="valida" InitialValue=""
                            ErrorMessage="Enter number of candidates"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                            runat="server" InitialValue="" ControlToValidate="txtNoOfCandidate" ValidationGroup="valida"
                            Text="*" ErrorMessage="Enter only numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="simple" style="display:none;">
                    <td>
                        How many candidates should be short listed?
                    </td>
                    <td>
                        <asp:TextBox ID="txtShortListCount" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server"
                            ControlToValidate="txtShortListCount" Text="*" ValidationGroup="valida" InitialValue=""
                            ErrorMessage="Enter number of shortlisted candidates"></asp:RequiredFieldValidator>--%>
                      <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                            runat="server" ControlToValidate="txtShortListCount" ValidationGroup="valida"
                            Text="*" InitialValue="" ErrorMessage="Enter only number for shortlisted candidates"
                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
                <tr class="simple" style="display:none;">
                    <td>
                        Requisition Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>              
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Requisition" CssClass="btn-ora nl"
                            ValidationGroup="valida" OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

