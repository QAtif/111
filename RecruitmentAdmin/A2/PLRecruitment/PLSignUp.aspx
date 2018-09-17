<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="PLSignUp.aspx.cs" Inherits="A2_PLRecruitment_PLSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <style type="text/css">
        .error
        {
            border: 1px solid #CC0000 !important;
        }
        .ButtonsSave11
        {
            cursor: pointer;
            background: linear-gradient(to bottom, #4B8EFC 0%, #4787EE 100%) !important;
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important;
            border: 1px solid #3079ED !important;
            color: #FFF;
            padding: 4px 27px;
        }
        .center
        {
            margin-left: auto;
            margin-right: auto;
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="width: 100%">
        <div style="background-color: White; padding: 5px 0px 5px 0px; margin-top: 5px;"
            class="center">
            <h2>
                &nbsp;&nbsp;&nbsp; PL Sign Up</h2>
        </div>
        <div class="box-ScheduledActivities center" style="background-color: White; margin-top: -26px;">
            <table style="margin-left: auto; margin-right: auto; width: 54%">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="20%">
                        Name
                    </td>
                    <td width="80%" style="padding-left: 20px">
                        <asp:TextBox Width="300px" ID="txtName" runat="server" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Mobile Number
                    </td>
                    <td style="padding-left: 20px">
                        <asp:DropDownList ID="ddlPhoneCodes" runat="server" Width="80px">
                        </asp:DropDownList>
                        <asp:TextBox Width="215px" Height="20px" MaxLength="7" ID="txtPhoneNumber" runat="server"
                            onkeydown="return isNumberKey(event);"></asp:TextBox>
                    </td>
                </tr>               
                <tr>
                    <td align="left">
                        Email Address
                    </td>
                    <td style="padding-left: 20px">
                        <asp:TextBox Width="300px" ID="txtEmail" runat="server" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="left">
                        Referred By:
                    </td>
                    <td style="padding-left: 20px">
                        <asp:DropDownList ID="ddlRefferredBy" runat="server" width="311px">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
             
                <tr>
                    <td colspan="2" align="center">
                        <div id="divAction139" runat="server" clientidmode="Static" visible="false">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="ButtonsSave11"
                                OnClientClick="javascript: return Validate();" />
                       </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        function ResetJobTitle() {
            if (event.keyCode != 13)
                $('#hfJobTitle').val("0");
        }

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

        function Validate() {
            var Validate = true;
            if ($('#ctl00_BodyContent_txtName').val().trim() == "") {
                $('#ctl00_BodyContent_txtName').addClass('error');
                Validate = false;
            }
            else
                $('#ctl00_BodyContent_txtName').removeClass('error');

            if ($('#ctl00_BodyContent_txtPhoneNumber').val().trim() == "") {
                $('#ctl00_BodyContent_txtPhoneNumber').addClass('error');
                Validate = false;
            }
            else
                $('#ctl00_BodyContent_txtPhoneNumber').removeClass('error');

            //            if ($('#ctl00_BodyContent_txtMobile').val().trim() == "") {
            //                $('#ctl00_BodyContent_txtMobile').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#ctl00_BodyContent_txtMobile').removeClass('error');

            //            if ($('#ctl00_BodyContent_txtEmail').val().trim() == "") {
            //                $('#ctl00_BodyContent_txtEmail').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#ctl00_BodyContent_txtEmail').removeClass('error');

            //            if ($('#txtLastExp').val().trim() == "") {
            //                $('#txtLastExp').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#txtLastExp').removeClass('error');

            //            if ($('#txtDesignation').val().trim() == "") {
            //                $('#txtDesignation').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#txtDesignation').removeClass('error');

            //            if ($('#ctl00_BodyContent_txtCategory').val().trim() == "") {
            //                $('#ctl00_BodyContent_txtCategory').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#ctl00_BodyContent_txtCategory').removeClass('error');

            //            if ($('#ctl00_BodyContent_txtDepartment').val().trim() == "") {
            //                $('#ctl00_BodyContent_txtDepartment').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#ctl00_BodyContent_txtDepartment').removeClass('error');
            //            return Validate;

            //            if ($('#ctl00_BodyContent_ddlQualification').val().trim() != "") {
            //                $('#ctl00_BodyContent_ddlQualification').addClass('error');
            //                Validate = false;
            //            }
            //            else
            //                $('#ctl00_BodyContent_ddlQualification').removeClass('error');

            return Validate;



        }
    </script>
</asp:Content>
