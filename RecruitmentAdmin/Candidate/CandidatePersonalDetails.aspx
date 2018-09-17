<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidatePersonalDetails.aspx.cs"
    Inherits="CandidatePersonalDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Personal Details</title>
    <!--#include virtual="/assets/inc-Signup/scripts.html" -->
    <style type="text/css">
        .validationsummary
        {
            border: 1px solid #b08b34;
            background: transparent url(/Images/WarningHeader.gif) no-repeat 12px 30px;
            padding: 0px 0px 13px 0px;
            font-size: 12px;
            width: 99%;
        }
        .validationheader
        {
            left: 0px;
            position: relative;
            font-size: 11px;
            background-color: #e5d9bd;
            color: #56300a;
            height: 14px;
            font-weight: bold;
            border-bottom: 1px solid #b08b34;
            padding-top: 3px;
        }
        .validationsummary ul
        {
            padding-top: 5px;
            padding-left: 45px;
            list-style: none;
            font-size: 11px;
            color: #982b12;
            font-style: italic;
        }
        .validationsummary ul li
        {
            padding: 2px 0px 0px 15px;
            background-image: url(/Images/Warning.gif);
            background-position: 0px 3px;
            background-repeat: no-repeat;
        }
    </style>
    <link title="win2k-cold-1" media="all" href="/assets/inc-Signup/calendar/calendar-win2k-cold-1.css"
        type="text/css" rel="stylesheet" />
    <script src="/assets/inc-Signup/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/inc-Signup/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/inc-Signup/calendar/calendar-setup.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://j.maxmind.com/app/geoip.js"></script>
    <script type="text/javascript" language="javascript">

        function rblNationality_OnClick() {
            if (document.getElementById("rblNationality_0").checked == true) {
                $("#trPassport").hide(0);
                $("#trNIC").show(0);
                ValidatorEnable(document.getElementById('<%=rfvNIC.ClientID %>'), true);
                ValidatorEnable(document.getElementById('<%=revNIC.ClientID %>'), true);
                ValidatorEnable(document.getElementById('<%=rfvPassport.ClientID %>'), false);
            }
            else {
                $("#trNIC").hide(0);
                $("#trPassport").show(0);
                ValidatorEnable(document.getElementById('<%=rfvNIC.ClientID %>'), false);
                ValidatorEnable(document.getElementById('<%=revNIC.ClientID %>'), false);
                ValidatorEnable(document.getElementById('<%=rfvPassport.ClientID %>'), true);
            }
        }

        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                // parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                alert('Saved Sucessfuly...');
                parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }
        var isChanged = false;
        $(document).ready(function () {

           
            if ($('#isChanged').val() == '1') {
                isChanged = true;

            }

            $('.validatechange input, .validatechange select').live('change', function () {

                isChanged = true;
                $('#isChanged').val('1');
            });

            $('.validatechange input[type="radio"]').live('click', function () {

                isChanged = true;
                $('#isChanged').val('1');
            });

            $('[id*="btnSave"]').live('click', function () {
                if (isChanged) {
                    $('#isChanged').val('0');
                } return isChanged;
            });
        });

        function getOnloadData() {
            $("#ddlCountry").each(function () {
                $('option', this).each(function () {
                    if ($(this).text().toLowerCase() == geoip_country_name().toLowerCase()) {
                        $(this).attr('selected', 'selected')
                    };
                });
            });
        }
        function ValidateFields(source, args) {
            var val = chkValidDate(document.getElementById('ddlMonth').value, document.getElementById('ddlDay').value);
            if (val == false) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function chkValidDate(mm, dd) {
            if (mm == 4 || mm == 6 || mm == 9 || mm == 11) {
                max_days = 30;
            }
            else if (mm == 2) {		// February                
                max_days = 28;
            }
            else {
                max_days = 31;
            }

            if (dd > max_days)
                return false;
            else
                return true;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function checkLen(x, y) {
            if (y.length == x.maxLength) {
                var next = x.tabIndex;
                if (next < document.getElementById("form1").length) {
                    document.getElementById("form1").elements[next].focus();
                }
            }
        }
    </script>
</head>
<body class="personaldetails-page" onload="getOnloadData();">
    <div>
        
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="joyride-modal-bg" style="display: none;">
        </div>
        <div class="career-service fullwidth">
            <asp:HiddenField ID="isChanged" runat="server" ClientIDMode="Static" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#ffffff">
                <tr>                    
                    <td valign="top">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Personal Details</h2>
                            <table id="tblMain" cellpadding="0" cellspacing="0" runat="server" class="validatechange">
                                <tr>
                                    <td colspan="2" class="error">
                                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="vsValidators" HeaderText="<div class='validationheader'>&nbsp;Important:</div>"
                                            CssClass="validationsummary" DisplayMode="BulletList" EnableClientScript="true"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="140">
                                        Name <span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                            Display="Dynamic" ErrorMessage="Please enter your Name" Font-Bold="True" ForeColor="Red"
                                            InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='Name is required!' />" />
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="100" CssClass="full"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email Address <span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Please enter valid Email Address" Font-Bold="True" ForeColor="Red"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="<img src='/assets/Images/Exclamation.gif' title='Valid Email Address is required!' />"
                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="Please enter Email Address" Font-Bold="True"
                                            ForeColor="Red" InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='Email is required!' />" />
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Phone #
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile"
                                            ErrorMessage="Please enter Phone Number" Font-Bold="True" ForeColor="Red" InitialValue=""
                                            Text="<img src='/assets/Images/Exclamation.gif' title='Phone # is required!' />" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobile"
                                            ErrorMessage="Please enter valid Phone Number" Font-Bold="True" Display="Dynamic"
                                            ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Valid Phone # is required!' />"
                                            ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="11" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mobile #
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="11" Enabled="false" ReadOnly="true"
                                            CssClass="full" Style="background: Silver;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Date of Birth <span>(?)</span>
                                    </td>
                                    <td class="nopad">
                                        <table id="tblDOB" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="style2 padleft" style="background-color: White;">
                                                    <asp:CustomValidator Font-Bold="True" ForeColor="Red" runat="server" ID="asdasd"
                                                        ControlToValidate="ddlMonth" ClientValidationFunction="ValidateFields" EnableClientScript="true"
                                                        Display="Dynamic" Text="<img src='/assets/Images/Exclamation.gif' title='Please Select Valid Date Of Birth.!' />"
                                                        ErrorMessage="Please Select Valid Date Of Birth."></asp:CustomValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="<img src='/assets/Images/Exclamation.gif' title='Month Of Birth is required!' />"
                                                        ErrorMessage="Please Select Month" runat="server" ControlToValidate="ddlMonth"
                                                        Display="Dynamic" InitialValue=""></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="<img src='/assets/Images/Exclamation.gif' title='Day Of Birth is required!' />"
                                                        ErrorMessage="Please Select Day" runat="server" ControlToValidate="ddlDay" Display="Dynamic"
                                                        InitialValue=""></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="<img src='/assets/Images/Exclamation.gif' title='Year Of Birth is required!' />"
                                                        runat="server" ErrorMessage="Please Select Year" ControlToValidate="ddlYear"
                                                        Display="Dynamic" InitialValue=""></asp:RequiredFieldValidator>
                                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="f11" Width="123px">
                                                        <asp:ListItem Selected="True" Value="">Month</asp:ListItem>
                                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                                        <asp:ListItem Value="3">March</asp:ListItem>
                                                        <asp:ListItem Value="4">April</asp:ListItem>
                                                        <asp:ListItem Value="5">May</asp:ListItem>
                                                        <asp:ListItem Value="6">June</asp:ListItem>
                                                        <asp:ListItem Value="7">July</asp:ListItem>
                                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                                        <asp:ListItem Value="9">Sept</asp:ListItem>
                                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlDay" runat="server" CssClass="f11" Width="123px">
                                                        <asp:ListItem Selected="True" Value="">Day</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                        <asp:ListItem Value="21">21</asp:ListItem>
                                                        <asp:ListItem Value="22">22</asp:ListItem>
                                                        <asp:ListItem Value="23">23</asp:ListItem>
                                                        <asp:ListItem Value="24">24</asp:ListItem>
                                                        <asp:ListItem Value="25">25</asp:ListItem>
                                                        <asp:ListItem Value="26">26</asp:ListItem>
                                                        <asp:ListItem Value="27">27</asp:ListItem>
                                                        <asp:ListItem Value="28">28</asp:ListItem>
                                                        <asp:ListItem Value="29">29</asp:ListItem>
                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                        <asp:ListItem Value="31">31</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="f11" Width="123px">
                                                        <asp:ListItem Selected="True" Value="">Year</asp:ListItem>
                                                        <asp:ListItem Value="1996">1996</asp:ListItem>
                                                        <asp:ListItem Value="1995">1995</asp:ListItem>
                                                        <asp:ListItem Value="1994">1994</asp:ListItem>
                                                        <asp:ListItem Value="1993">1993</asp:ListItem>
                                                        <asp:ListItem Value="1992">1992</asp:ListItem>
                                                        <asp:ListItem Value="1991">1991</asp:ListItem>
                                                        <asp:ListItem Value="1990">1990</asp:ListItem>
                                                        <asp:ListItem Value="1989">1989</asp:ListItem>
                                                        <asp:ListItem Value="1988">1988</asp:ListItem>
                                                        <asp:ListItem Value="1987">1987</asp:ListItem>
                                                        <asp:ListItem Value="1986">1986</asp:ListItem>
                                                        <asp:ListItem Value="1985">1985</asp:ListItem>
                                                        <asp:ListItem Value="1984">1984</asp:ListItem>
                                                        <asp:ListItem Value="1983">1983</asp:ListItem>
                                                        <asp:ListItem Value="1982">1982</asp:ListItem>
                                                        <asp:ListItem Value="1981">1981</asp:ListItem>
                                                        <asp:ListItem Value="1980">1980</asp:ListItem>
                                                        <asp:ListItem Value="1979">1979</asp:ListItem>
                                                        <asp:ListItem Value="1978">1978</asp:ListItem>
                                                        <asp:ListItem Value="1977">1977</asp:ListItem>
                                                        <asp:ListItem Value="1976">1976</asp:ListItem>
                                                        <asp:ListItem Value="1975">1975</asp:ListItem>
                                                        <asp:ListItem Value="1974">1974</asp:ListItem>
                                                        <asp:ListItem Value="1973">1973</asp:ListItem>
                                                        <asp:ListItem Value="1972">1972</asp:ListItem>
                                                        <asp:ListItem Value="1971">1971</asp:ListItem>
                                                        <asp:ListItem Value="1970">1970</asp:ListItem>
                                                        <asp:ListItem Value="1969">1969</asp:ListItem>
                                                        <asp:ListItem Value="1968">1968</asp:ListItem>
                                                        <asp:ListItem Value="1967">1967</asp:ListItem>
                                                        <asp:ListItem Value="1966">1966</asp:ListItem>
                                                        <asp:ListItem Value="1965">1965</asp:ListItem>
                                                        <asp:ListItem Value="1964">1964</asp:ListItem>
                                                        <asp:ListItem Value="1963">1963</asp:ListItem>
                                                        <asp:ListItem Value="1962">1962</asp:ListItem>
                                                        <asp:ListItem Value="1961">1961</asp:ListItem>
                                                        <asp:ListItem Value="1960">1960</asp:ListItem>
                                                        <asp:ListItem Value="1959">1959</asp:ListItem>
                                                        <asp:ListItem Value="1958">1958</asp:ListItem>
                                                        <asp:ListItem Value="1957">1957</asp:ListItem>
                                                        <asp:ListItem Value="1956">1956</asp:ListItem>
                                                        <asp:ListItem Value="1955">1955</asp:ListItem>
                                                        <asp:ListItem Value="1954">1954</asp:ListItem>
                                                        <asp:ListItem Value="1953">1953</asp:ListItem>
                                                        <asp:ListItem Value="1952">1952</asp:ListItem>
                                                        <asp:ListItem Value="1951">1951</asp:ListItem>
                                                        <asp:ListItem Value="1950">1950</asp:ListItem>
                                                        <asp:ListItem Value="1949">1949</asp:ListItem>
                                                        <asp:ListItem Value="1948">1948</asp:ListItem>
                                                        <asp:ListItem Value="1947">1947</asp:ListItem>
                                                        <asp:ListItem Value="1946">1946</asp:ListItem>
                                                        <asp:ListItem Value="1945">1945</asp:ListItem>
                                                        <asp:ListItem Value="1944">1944</asp:ListItem>
                                                        <asp:ListItem Value="1943">1943</asp:ListItem>
                                                        <asp:ListItem Value="1942">1942</asp:ListItem>
                                                        <asp:ListItem Value="1941">1941</asp:ListItem>
                                                        <asp:ListItem Value="1940">1940</asp:ListItem>
                                                        <asp:ListItem Value="1939">1939</asp:ListItem>
                                                        <asp:ListItem Value="1938">1938</asp:ListItem>
                                                        <asp:ListItem Value="1937">1937</asp:ListItem>
                                                        <asp:ListItem Value="1936">1936</asp:ListItem>
                                                        <asp:ListItem Value="1935">1935</asp:ListItem>
                                                        <asp:ListItem Value="1934">1934</asp:ListItem>
                                                        <asp:ListItem Value="1933">1933</asp:ListItem>
                                                        <asp:ListItem Value="1932">1932</asp:ListItem>
                                                        <asp:ListItem Value="1931">1931</asp:ListItem>
                                                        <asp:ListItem Value="1930">1930</asp:ListItem>
                                                        <asp:ListItem Value="1929">1929</asp:ListItem>
                                                        <asp:ListItem Value="1928">1928</asp:ListItem>
                                                        <asp:ListItem Value="1927">1927</asp:ListItem>
                                                        <asp:ListItem Value="1926">1926</asp:ListItem>
                                                        <asp:ListItem Value="1925">1925</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Gender <span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator13" runat="server"
                                            ControlToValidate="ddlGender" ErrorMessage="Please Select Gender" Font-Bold="True"
                                            ForeColor="Red" InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='Gender is required!' />" />
                                        <asp:DropDownList ID="ddlGender" runat="server" Width="378px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Marital Status <span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                            ControlToValidate="ddlMaritalStatus" ErrorMessage="Please Select Marital Status"
                                            Font-Bold="True" ForeColor="Red" InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='Marital Status is required!' />" />
                                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="378px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Religon <span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator11" runat="server"
                                            ControlToValidate="ddlReligon" ErrorMessage="Please Select Religion" Font-Bold="True"
                                            ForeColor="Red" InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='Religion is required!' />" />
                                        <asp:DropDownList ID="ddlReligon" runat="server" Width="378px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Country <span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator12" runat="server"
                                            ControlToValidate="ddlCountry" ErrorMessage="Please Select Country" Font-Bold="True"
                                            ForeColor="Red" InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='Country is required!' />" />
                                        <asp:DropDownList ID="ddlCountry" runat="server" Width="378px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        House/Street No. <span>(?)</span>
                                    </td>
                                    <td valign="middle">
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server"
                                            ControlToValidate="txtHouseNo" ErrorMessage="Please enter House/Street Number"
                                            Font-Bold="True" ForeColor="Red" InitialValue="" Text="<img src='/assets/Images/Exclamation.gif' title='House/Street Number is required!' />" />
                                        <asp:TextBox ID="txtHouseNo" runat="server" MaxLength="180" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Block <span>(?)</span>
                                    </td>
                                    <td valign="middle">
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtBlock"
                                            ErrorMessage="Please enter Block" Font-Bold="True" ForeColor="Red" InitialValue=""
                                            Text="<img src='/assets/Images/Exclamation.gif' title='Block is required!' />" />
                                        <asp:TextBox ID="txtBlock" runat="server" MaxLength="8" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Area<span>(?)</span>
                                    </td>
                                    <td valign="middle">
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtBlock"
                                            ErrorMessage="Please enter Area" Font-Bold="True" ForeColor="Red" InitialValue=""
                                            Text="<img src='/assets/Images/Exclamation.gif' title='area is required!' />" />
                                        <asp:TextBox ID="txtArea" runat="server" MaxLength="40" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        City<span>(?)</span>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="ddlCity"
                                            ErrorMessage="Please Select City" Font-Bold="True" ForeColor="Red" InitialValue=""
                                            Text="<img src='/assets/Images/Exclamation.gif' title='City is required!' />" />
                                        <asp:DropDownList ID="ddlCity" runat="server" Width="378px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nationality <span>(?)</span>
                                    </td>
                                    <td class="rdofix" valign="middle">
                                        <asp:RadioButtonList ID="rblNationality" runat="server" RepeatDirection="Horizontal"
                                            CssClass="full" onclick="javascript:return rblNationality_OnClick();">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                 <tr runat="server" id="trNIC">
                                    <td>
                                        NIC #
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvNIC" Display="Dynamic" runat="server" ControlToValidate="txtNIC"
                                            ErrorMessage="NIC is required" Font-Bold="True" ForeColor="Red" InitialValue=""
                                            Text="<img src='/assets/Images/Exclamation.gif' title='NIC # is required' />" />
                                        <asp:RegularExpressionValidator ID="revNIC" runat="server" ControlToValidate="txtNIC"
                                            ErrorMessage="This is not a  valid NIC Number" Font-Bold="True" Display="Dynamic"
                                            ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='This is not a  valid NIC Number' />"
                                            ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtNIC" runat="server" MaxLength="13" CssClass="medium" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                        (e.g 9999999999999)
                                    </td>
                                </tr>
                                <tr runat="server" id="trPassport" style="display: none;">
                                    <td>
                                        Passport #
                                    </td>
                                    <td>
                                        <%--<asp:RegularExpressionValidator runat="server" ControlToValidate="txtPassport" ErrorMessage="This is not a valid passport Number"
                                            Font-Bold="True" Display="Dynamic" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='This is not a valid passport Number' />"
                                            ValidationExpression="^[a-zA-Z0-9_]*$"></asp:RegularExpressionValidator>
                                        --%><asp:RequiredFieldValidator ID="rfvPassport" runat="server" ControlToValidate="txtPassport"
                                            ErrorMessage="Passport is required" Font-Bold="True" Display="Dynamic" ForeColor="Red"
                                            InitialValue="" Enabled="false" Text="<img src='/assets/Images/Exclamation.gif' title='Passport is required' />" />
                                        <asp:TextBox ID="txtPassport" runat="server" MaxLength="200" CssClass="medium" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                        (e.g 1236789AC127)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="save btn" />
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
          
        </div>
        </form>
    </div>
</body>
</html>
