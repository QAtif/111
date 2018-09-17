<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateFamilyMembers.aspx.cs"
    Inherits="CandidateFamilyMembers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <link title="win2k-cold-1" media="all" href="/Includes/calendar/calendar-win2k-cold-1.css"
        type="text/css" rel="stylesheet" />
    <script src="/Includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/Includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/Includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
        function ChangeNIC() {
            $("#ImgbtnNIC").hide(500);
            $("#btnChangeNIC").hide(500);
            $("#fuNIC").show(500);
        }
        function ChangePIC() {
            $("#ImgbtnPicture").hide(500);
            $("#btnChangePicture").hide(500);
            $("#fuPicture").show(500);
        }
        function ValidateSibling(oSrc, args) {
            args.IsValid = false;
            var ddlCandidateSiblingPosition = document.getElementById('ddlCandidateSiblingPosition').value;
            var ddlSiblingCount = document.getElementById('ddlSiblingCount').value;

            if (ddlCandidateSiblingPosition == (parseInt(ddlSiblingCount) + 1) || ddlCandidateSiblingPosition < (parseInt(ddlSiblingCount) + 1)) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
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
    <style type="text/css">
        .completionListElement
        {
            visibility: hidden;
            margin: 0px !important;
            background-color: inherit;
            color: black;
            border: solid 1px gray;
            cursor: pointer;
            text-align: left;
            list-style-type: none;
            font-family: Verdana;
            font-size: 14px;
            padding: 0;
        }
        .listItem
        {
            background-color: Silver;
            padding: 1px;
        }
        .highlightedListItem
        {
            background-color: Orange;
            padding: 1px;
        }
    </style>
    <title>CandidateFamilyMembers</title>
   
</head>
<body>
    <div>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="joyride-modal-bg" style="display: none;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: #fff;">
            <tr>
                <td valign="top" align="left">
                    <div class="governscr formarea">
                        <h2 style="padding: 10px 0 0 10px;">
                            Family Details</h2>
                        <table width="100%" id="tblMain" cellpadding="0" cellspacing="0" runat="server">
                            <tr>
                                <td colspan="3">
                                    Provide your family details in this section:
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" valign="middle" width="100">
                                                No. of Siblings:
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                                    ControlToValidate="ddlSiblingCount" ErrorMessage="Please select Sibling Count"
                                                    Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Sibling Count is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlSiblingCount" runat="server" CssClass="full">
                                                    <asp:ListItem Value="">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="0">Zero</asp:ListItem>
                                                    <asp:ListItem Value="1">One</asp:ListItem>
                                                    <asp:ListItem Value="2">Two</asp:ListItem>
                                                    <asp:ListItem Value="3">Three</asp:ListItem>
                                                    <asp:ListItem Value="4">Four</asp:ListItem>
                                                    <asp:ListItem Value="5">Five</asp:ListItem>
                                                    <asp:ListItem Value="6">Six</asp:ListItem>
                                                    <asp:ListItem Value="7">Seven</asp:ListItem>
                                                    <asp:ListItem Value="8">Eight</asp:ListItem>
                                                    <asp:ListItem Value="9">Nine</asp:ListItem>
                                                    <asp:ListItem Value="10">Ten</asp:ListItem>
                                                    <asp:ListItem Value="11">Eleven</asp:ListItem>
                                                    <asp:ListItem Value="12">Twelve</asp:ListItem>
                                                    <asp:ListItem Value="13">Thirteen</asp:ListItem>
                                                    <asp:ListItem Value="14">Fourteen</asp:ListItem>
                                                    <asp:ListItem Value="15">Fifteen</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" valign="middle" width="100">
                                                Your No. In Siblings:
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:CustomValidator Font-Bold="True" ForeColor="Red" runat="server" ID="cvSibling"
                                                    ControlToValidate="ddlCandidateSiblingPosition" ClientValidationFunction="ValidateSibling"
                                                    EnableClientScript="true" Display="Dynamic" Text="<img src='/assets/Images/Exclamation.gif' title='Your Sibling Position is not valid.' />"
                                                    ErrorMessage="Your Sibling Position is not valid." ValidationGroup="Check"></asp:CustomValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                                    ControlToValidate="ddlCandidateSiblingPosition" ErrorMessage="Please select your position in Sibling"
                                                    Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Your position in Sibling is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlCandidateSiblingPosition" runat="server" CssClass="full">
                                                    <asp:ListItem Value="">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">First</asp:ListItem>
                                                    <asp:ListItem Value="2">Second</asp:ListItem>
                                                    <asp:ListItem Value="3">Third</asp:ListItem>
                                                    <asp:ListItem Value="4">Fourth</asp:ListItem>
                                                    <asp:ListItem Value="5">Fifth</asp:ListItem>
                                                    <asp:ListItem Value="6">Sixth</asp:ListItem>
                                                    <asp:ListItem Value="7">Seventh</asp:ListItem>
                                                    <asp:ListItem Value="8">Eighth</asp:ListItem>
                                                    <asp:ListItem Value="9">Ninth</asp:ListItem>
                                                    <asp:ListItem Value="10">Tenth</asp:ListItem>
                                                    <asp:ListItem Value="11">Eleventh</asp:ListItem>
                                                    <asp:ListItem Value="12">Twelfth</asp:ListItem>
                                                    <asp:ListItem Value="13">Thirteenth</asp:ListItem>
                                                    <asp:ListItem Value="14">Fourteenth</asp:ListItem>
                                                    <asp:ListItem Value="15">Fifteenth</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Repeater ID="rptCandidateMember" runat="server" OnItemCommand="rptCandidateMember_OnItemCommand">
                                        <HeaderTemplate>
                                            <table id="tblCandidateMemberHeader" cellpadding="5" cellspacing="1" width="100%"
                                                bgcolor="#666666">
                                                <tr>
                                                    <td align="center" bgcolor="#dedede">
                                                        S.No
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Relation
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Name
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Qualification
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Ocupation
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Company/Institute
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Monthly Income
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Age
                                                    </td>
                                                    <td align="center" bgcolor="#dedede">
                                                        Action
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td bgcolor="#FFFFFF" align="center">
                                                    <%# Container.ItemIndex+1%>
                                                    <asp:Label ID="lblFamilyMemberCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateFamilyMember_Code")%>'
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberRelation")%>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberName")%>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberQualification")%>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberOcupation")%>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberOrganization")%>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberIncome").ToString().Split('.')[0].ToString()%>
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    <%# DataBinder.Eval(Container.DataItem, "MemberAge")%>
                                                </td>
                                                <td bgcolor="#FFFFFF" align="center">
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/assets/images/edit.png"
                                                        CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateFamilyMember_Code")%>'
                                                        CausesValidation="false" />
                                                    <asp:ImageButton ID="imgDel" runat="server" ImageUrl="/assets/images/0.gif" OnClientClick="javascript:return confirm('Are you sure you want to delted the selected Member?');"
                                                        CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateFamilyMember_Code")%>'
                                                        CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="error">
                                    <asp:ValidationSummary ID="vsValidators" HeaderText="<div class='validationheader'>&nbsp;Important:</div>"
                                        DisplayMode="BulletList" EnableClientScript="true" runat="server" ValidationGroup="Check"
                                        CssClass="validationsummary" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="nopad">
                                    <asp:HiddenField ID="hfCandidateFamilyMemberCode" runat="server" Value="0" />
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left" valign="middle" width="100">
                                                Relation
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                                                    ControlToValidate="ddlRelation" ErrorMessage="Please select Relation" Font-Bold="True"
                                                    ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Relation is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlRelation" runat="server" CssClass="full">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Name
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server"
                                                    ControlToValidate="txtName" ErrorMessage="Please enter Name" Font-Bold="True"
                                                    ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Name is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="full" ValidationGroup="Check"
                                                    onkeydown="javascript:return (event.keyCode!=13);" MaxLength="100"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Qualification
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server"
                                                    ControlToValidate="txtQualification" ErrorMessage="Please enter Qualification"
                                                    Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Qualification is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtQualification" runat="server" MaxLength="100" CssClass="full"
                                                    ValidationGroup="Check" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Ocupation
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server"
                                                    ControlToValidate="txtOcupation" ErrorMessage="Please enter Ocupation" Font-Bold="True"
                                                    ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Ocupation is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtOcupation" runat="server" MaxLength="100" CssClass="full" ValidationGroup="Check"
                                                    onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Designation
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server"
                                                    ControlToValidate="txtDesignation" ErrorMessage="Please enter Designation" Font-Bold="True"
                                                    ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Designation is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtDesignation" runat="server" MaxLength="100" CssClass="full" ValidationGroup="Check"
                                                    onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Date Of Birth
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:CustomValidator Font-Bold="True" ForeColor="Red" runat="server" ID="asdasd"
                                                    ControlToValidate="ddlMonth" ClientValidationFunction="ValidateFields" EnableClientScript="true"
                                                    Display="Dynamic" Text="<img src='/assets/Images/Exclamation.gif' title='Please Select Valid Date Of Birth.!' />"
                                                    ErrorMessage="Please Select Valid Date Of Birth." ValidationGroup="Check"></asp:CustomValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="<img src='/assets/Images/Exclamation.gif' title='Month Of Birth is required!' />"
                                                    ErrorMessage="Please Select Month" runat="server" ControlToValidate="ddlMonth"
                                                    Display="Dynamic" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Text="<img src='/assets/Images/Exclamation.gif' title='Day Of Birth is required!' />"
                                                    ErrorMessage="Please Select Day" runat="server" ControlToValidate="ddlDay" Display="Dynamic"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="<img src='/assets/Images/Exclamation.gif' title='Year Of Birth is required!' />"
                                                    runat="server" ErrorMessage="Please Select Year" ControlToValidate="ddlYear"
                                                    Display="Dynamic" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
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
                                        <tr>
                                            <td align="left" valign="middle">
                                                Company/Institute
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server"
                                                    ControlToValidate="txtOrganization" ErrorMessage="Please enter Company/Institute"
                                                    Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Company/Institute is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtOrganization" runat="server" MaxLength="100" CssClass="full"
                                                    ValidationGroup="Check" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Monthly Income
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtMemberIncome" ErrorMessage="Please enter Monthly Income in Correct Format"
                                                    Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Monthly Income in Correct Format is required!' />"
                                                    ValidationExpression="\d+\.?\d*" ValidationGroup="Check"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server"
                                                    ControlToValidate="txtMemberIncome" ErrorMessage="Please enter Monthly Income"
                                                    Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Monthly Income is required!' />"
                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtMemberIncome" runat="server" MaxLength="7" CssClass="full" ValidationGroup="Check"
                                                    onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                NIC
                                            </td>
                                            <td align="left" valign="middle" class="nopad">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" class="nopad">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:RegularExpressionValidator ID="revNIC" runat="server" ErrorMessage="Please Select the Correct Format(.jpeg,.jpg,png,bmp)"
                                                                            ValidationExpression="^.+(.jpeg|.JPEG|.jpg|JPG|.png|.PNG|.bmp|.BMP)$" Display="Dynamic"
                                                                            ControlToValidate="fuNIC" ValidationGroup="NIC" Text="<img src='/assets/Images/Exclamation.gif' title='Format(.jpeg,.jpg,png,bmp) is required!' />"
                                                                            Font-Bold="True" ForeColor="Red"> </asp:RegularExpressionValidator>
                                                                        <asp:FileUpload ID="fuNIC" runat="server" CssClass="full" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="ImgbtnNIC" runat="server" ImageUrl="/assets-final/images/document-save.png"
                                                                            Height="50px" Width="50px" CausesValidation="false" OnClick="ImgbtnNIC_Click"
                                                                            Visible="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnChangeNIC" runat="server" Text="Change" CssClass="save btn" CausesValidation="false"
                                                                            OnClientClick="ChangeNIC(); return false;" Style="display: none;" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                Picture
                                            </td>
                                            <td align="left" valign="middle" class="nopad">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="nopad">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:RegularExpressionValidator ID="revPicture" runat="server" ErrorMessage="Please Select the Correct Format(.jpeg,.jpg,png,bmp)"
                                                                            ValidationExpression="^.+(.jpeg|.JPEG|.jpg|JPG|.png|.PNG|.bmp|.BMP)$" Display="Dynamic"
                                                                            ControlToValidate="fuPicture" ValidationGroup="Picture" Text="<img src='/assets/Images/Exclamation.gif' title='Format(.jpeg,.jpg,png,bmp) is required!' />"
                                                                            Font-Bold="True" ForeColor="Red"> </asp:RegularExpressionValidator>
                                                                        <asp:FileUpload ID="fuPicture" runat="server" CssClass="full" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="ImgbtnPicture" runat="server" CommandName="View" ImageUrl="/assets-final/images/document-save.png"
                                                                            Height="50px" Width="50px" CausesValidation="false" OnClick="ImgbtnPicture_Click"
                                                                            Visible="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnChangePicture" runat="server" Text="Change" CssClass="save btn"
                                                                            OnClientClick="ChangePIC();return false;" Style="display: none;" CausesValidation="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right">
                                    <asp:ImageButton ToolTip="" ID="btnAddMore" runat="server" Text="Add More" ImageUrl="/assets2/images/crops/btn-add.png"
                                        Width="14" CausesValidation="false" Height="15" alt="" align="absmiddle" OnClick="btnAddMore_Click"
                                        Visible="false" />
                                    <div class="spera">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="save btn"
                                        ValidationGroup="Check" />
                                </td>
                               
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>
