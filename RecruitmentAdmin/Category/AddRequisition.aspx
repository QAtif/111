<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddRequisition.aspx.cs" Inherits="AddRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Raise Requisition</title>
    <script type="text/javascript">
        

        function isNumberKey(event) {

            var charCode = (event.which) ? event.which : event.keyCode
            var isnumeric = false;

            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 110)
                isnumeric = true;
            if (charCode == 9)
                isnumeric = true;
            if (charCode == 190)
                isnumeric = true;
            if (charCode >= 37 && charCode <= 40)
                isnumeric = true;
            if (charCode >= 96 && charCode <= 105)
                isnumeric = true;

            return isnumeric;

        }
        function refreshParent(obj) {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
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
            <asp:HiddenField runat="server" ID="hdnUserTypeCode" /><br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        No. Of Candidates:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoOfCandidate" runat="server" Width="50px" MaxLength="4" onkeydown="javascript:return isNumberKey(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server"
                            ControlToValidate="txtNoOfCandidate" Text="*" ValidationGroup="valida" InitialValue=""
                            ErrorMessage="Enter number of candidates"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        City:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcity" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="ddlcity" Display="Dynamic"
                            InitialValue="-1" ValidationGroup="valida" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td colspan="4" align="center">
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
