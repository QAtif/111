<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditVenue.aspx.cs" Inherits="AddEditVenue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <script type="text/javascript">
        function refreshParent(obj) {
            window.parent.location.href = window.parent.location.href;
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            return (charCode <= 31 || charCode == 46 || (charCode >= 48 && charCode <= 57));
        }

        
        function ShowOption(ddl1) {
            var ddl = document.getElementById('MainContent_ddlFromTime');
            var ddlToTime = document.getElementById('MainContent_ddlToTime');
            count = ddl[ddl.selectedIndex].value;
            if (count < 23) {
                ddlToTime.selectedIndex = parseInt(count) + 1;
            }
        }
    

    </script>
    <div class="head">
        <h2>
            Add/Edit Venue</h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="specialtab">
            <tbody>
                <tr id="trMessage" runat="server" align="center" class="grey">
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Venue : </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtName" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="grey">
                    <td>
                        <strong>Location : </strong>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLocation">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlLocation" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Test Type Medium : </strong>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTestTypeMedium">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlTestTypeMedium" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="grey">
                    <td>
                        <strong>Time Duration : </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTimeDuration" OnKeyPress="return isNumberKey(this);" MaxLength="3"
                            runat="server"></asp:TextBox>
                        (Hours)
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTimeDuration" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>No. of Seats : </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofSeats" OnKeyPress="return isNumberKey(this);" MaxLength="3"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="txtNoofSeats" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="grey">
                    <td>
                        <strong>Min. Slot Duration : </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMinSlotDuration" OnKeyPress="return isNumberKey(this);" MaxLength="3"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                            ControlToValidate="txtMinSlotDuration" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                         <strong>From Time </strong>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlFromTime" runat="server" Style="width: auto" onChange="ShowOption(this);">
                            <asp:ListItem Text="0:00" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="13:00" Value="13"></asp:ListItem>
                            <asp:ListItem Text="14:00" Value="14"></asp:ListItem>
                            <asp:ListItem Text="15:00" Value="15"></asp:ListItem>
                            <asp:ListItem Text="16:00" Value="16"></asp:ListItem>
                            <asp:ListItem Text="17:00" Value="17"></asp:ListItem>
                            <asp:ListItem Text="18:00" Value="18"></asp:ListItem>
                            <asp:ListItem Text="19:00" Value="19"></asp:ListItem>
                            <asp:ListItem Text="20:00" Value="20"></asp:ListItem>
                            <asp:ListItem Text="21:00" Value="21"></asp:ListItem>
                            <asp:ListItem Text="22:00" Value="22"></asp:ListItem>
                            <asp:ListItem Text="23:00" Value="23"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="grey">
                <td style="text-align: left">
                         <strong>To Time </strong>
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlToTime" runat="server" Style="width: auto">
                            <asp:ListItem Text="0:00" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1:00" Selected="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="13:00" Value="13"></asp:ListItem>
                            <asp:ListItem Text="14:00" Value="14"></asp:ListItem>
                            <asp:ListItem Text="15:00" Value="15"></asp:ListItem>
                            <asp:ListItem Text="16:00" Value="16"></asp:ListItem>
                            <asp:ListItem Text="17:00" Value="17"></asp:ListItem>
                            <asp:ListItem Text="18:00" Value="18"></asp:ListItem>
                            <asp:ListItem Text="19:00" Value="19"></asp:ListItem>
                            <asp:ListItem Text="20:00" Value="20"></asp:ListItem>
                            <asp:ListItem Text="21:00" Value="21"></asp:ListItem>
                            <asp:ListItem Text="22:00" Value="22"></asp:ListItem>
                            <asp:ListItem Text="23:00" Value="23"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Venue Prefix: </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVenuePrefix" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                            ControlToValidate="txtVenuePrefix" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        <div align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
