<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateExperience.aspx.cs"
    Inherits="CandidateExperience" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Work Experience</title>
    <!--#include virtual="/assets/inc-Signup/scripts.html" -->
    <link title="win2k-cold-1" media="all" href="/assets/inc-Signup/calendar/calendar-win2k-cold-1.css"
        type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        function ResetIndustry() {
            $('#hfIndustry').val("0");
        }
        function ResetCompany() {
            $('#hfCompany').val("0");
        }
        function ResetLocation() {
            $('#hfLocation').val("0");
        }


        function ValidatePage(oSrc, args) {
            var txtFrom = document.getElementById('txtFrom').value;
            var txtTo = document.getElementById('txtTo').value;
            var now = new Date();

            var dFrom = Date.parse(txtFrom);
            var dTo = Date.parse(txtTo);

            if (dFrom < now && dTo < now) {
                if (dFrom >= dTo) {
                    args.IsValid = false;
                }
            }
            else {
                args.IsValid = false;
            }
        }

        function ShowHideDateTo() {

            if (document.getElementById('chkPresent').checked) {
                $("#ddlToMonth").hide(500);
                $("#ddlToYear").hide(500);
                $("#lblTo").hide(500);
                ValidatorEnable(document.getElementById('<%=rfvMonthTo.ClientID %>'), false);
                ValidatorEnable(document.getElementById('<%=rfvYearTo.ClientID %>'), false);
            }
            else {
                $("#ddlToMonth").show(500);
                $("#ddlToYear").show(500);
                $("#lblTo").show(500);
                ValidatorEnable(document.getElementById('<%=rfvMonthTo.ClientID %>'), true);
                ValidatorEnable(document.getElementById('<%=rfvYearTo.ClientID %>'), true);
            }
        }

    </script>
    <script src="/assets/inc-Signup/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/inc-Signup/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/inc-Signup/calendar/calendar-setup.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <style type="text/css">
        .validationsummary
        {
            border: 1px solid #b08b34;
            background: transparent url(/assets/Images/WarningHeader.gif) no-repeat 12px 30px;
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
            background-image: url(Images/Warning.gif);
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
    <script type="text/javascript" language="javascript">

        var isChanged = false;
        $(document).ready(function () {
            $('.date').each(function () {
                $(this).attr('prevval', $(this).val());
            });

            $('.validatechange input, .validatechange select').live('change', function () {

                isChanged = true;

            });
            $('.validatechange input, .validatechange select, #txtLocation').live('select', function () {
        
                isChanged = true;

            });



            $('.calendar').live('click', function () {

                $('.date').each(function () {
                    if ($(this).attr('prevval') != $(this).val()) {
                        isChanged = true;
                    }
                });

            });


            $('#txtResponsibilities').bind('input propertychange', function () {

                isChanged = true;

            });


            $('[id*="btnSave"]').live('click', function () {

                return isChanged;
            });
        });

    </script>
</head>
<body>
    <div>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: #fff;">
                <tr>
                    <td valign="top" align="left">
                        <div class="governscr formarea" style="height:100%">
                            <asp:HiddenField ID="isChanged" runat="server" ClientIDMode="Static" />
                            <h2 style="padding: 10px 0 0 10px;">
                                Professional Experience</h2>
                            <table width="100%" id="tblMain" cellpadding="0" cellspacing="0" runat="server">
                                <%--Repeater--%>
                                <tr>
                                    <td colspan="3">
                                        <asp:Repeater ID="rptExperience" runat="server" OnItemCommand="rptExperience_OnItemCommand">
                                            <HeaderTemplate>
                                                <table id="tblExperienceHeader" cellpadding="5" cellspacing="1" width="100%" bgcolor="#666666">
                                                    <tr>
                                                        <td align="center" bgcolor="#dedede">
                                                            S.No
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            Industry
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            Company
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            Title
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            Location
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            From
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            To
                                                        </td>
                                                        <td align="center" bgcolor="#dedede">
                                                            Current Salary
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
                                                        <asp:Label ID="lblExperienceCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateExperience_Code")%>'
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "Industry")%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "Company")%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "Position")%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "Location")%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF">
                                                        <%# DataBinder.Eval(Container.DataItem, "Salary").ToString().Split('.')[0].ToString()%>
                                                    </td>
                                                    <td bgcolor="#FFFFFF" align="center">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/assets/images/edit.png"
                                                            CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateExperience_Code")%>'
                                                            CausesValidation="false" />
                                                        <asp:ImageButton ID="imgDel" runat="server" ImageUrl="/assets/images/0.gif" OnClientClick="javascript:return confirm('Are you sure you want to delted the selected Experience?');"
                                                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateExperience_Code")%>'
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:HiddenField ID="hfExperienceCode" runat="server" Value="0" />
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
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="validatechange">
                                            <tr>
                                                <td align="left" valign="middle" width="100">
                                                    Industry<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle">
                                                    <script type="text/javascript">
                                                        $(function () {
                                                            $("#txtIndustry").autocomplete({
                                                                source: function (request, response) {
                                                                    $.ajax({
                                                                        url: "../AutoComplete.asmx/FetchIndustryList",
                                                                        data: "{ 'prefixText': '" + request.term + "' }",
                                                                        dataType: "json",
                                                                        type: "POST",
                                                                        contentType: "application/json",
                                                                        dataFilter: function (data) { return data; },
                                                                        success: function (data) {
                                                                            response($.map(data.d, function (item) {
                                                                                return {
                                                                                    label: item.Name,
                                                                                    value: item.Name,
                                                                                    itemid: item.Code
                                                                                }
                                                                            }))
                                                                        },
                                                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                                                            alert(textStatus);
                                                                        }
                                                                    });
                                                                },
                                                                minLength: 2,
                                                                select: function (event, ui) {
                                                                    $('#hfIndustry').val(ui.item.itemid);
                                                                },
                                                                change: function (event, ui) {
                                                                    if (ui.item == null) {
                                                                        $("#hfIndustry").val("0");
                                                                    }
                                                                }
                                                            });

                                                        });
                                                    </script>
                                                    <div class="ui-widget">
                                                       <%-- <asp:CustomValidator Font-Bold="True" ForeColor="Red" runat="server" ID="asdasd"
                                                            ControlToValidate="txtIndustry" ClientValidationFunction="ValidateIndustry" EnableClientScript="true"
                                                            Display="Dynamic" Text="Select Industry From the List" ErrorMessage="Select Industry From the List"
                                                            ValidationGroup="Check"></asp:CustomValidator>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                                            ControlToValidate="txtIndustry" ErrorMessage="Please Select Industry" Font-Bold="True"
                                                            ForeColor="Red" Text="*" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtIndustry" runat="server" CssClass="full" ValidationGroup="Check"
                                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetIndustry();"></asp:TextBox>
                                                        <asp:HiddenField ID="hfIndustry" runat="server" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    Company<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle">
                                                    <script type="text/javascript">
                                                        $(function () {
                                                            $("#txtCompany").autocomplete({
                                                                source: function (request, response) {
                                                                    $.ajax({
                                                                        url: "../AutoComplete.asmx/FetchCompanyList",
                                                                        data: "{ 'prefixText': '" + request.term + "' }",
                                                                        dataType: "json",
                                                                        type: "POST",
                                                                        contentType: "application/json",
                                                                        dataFilter: function (data) { return data; },
                                                                        success: function (data) {
                                                                            response($.map(data.d, function (item) {
                                                                                return {
                                                                                    label: item.Name,
                                                                                    value: item.Name,
                                                                                    itemid: item.Code
                                                                                }
                                                                            }))
                                                                        },
                                                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                                                            alert(textStatus);
                                                                        }
                                                                    });
                                                                },
                                                                minLength: 2,
                                                                select: function (event, ui) {
                                                                    $('#hfCompany').val(ui.item.itemid);
                                                                },
                                                                change: function (event, ui) {
                                                                    if (ui.item == null) {
                                                                        $('#hfCompany').val("0");
                                                                    }
                                                                }
                                                            });

                                                        });
                                                    </script>
                                                    <div class="ui-widget">
                                                       <%-- <asp:CustomValidator Font-Bold="True" ForeColor="Red" runat="server" ID="CustomValidator2"
                                                            ControlToValidate="txtCompany" ClientValidationFunction="ValidateCompany" EnableClientScript="true"
                                                            Display="Dynamic" Text="*" ErrorMessage="Select Company From the List" ValidationGroup="Check"></asp:CustomValidator>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                                            ControlToValidate="txtCompany" ErrorMessage="Please Select Company" Font-Bold="True"
                                                            ForeColor="Red" Text="*" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtCompany" runat="server" CssClass="full" ValidationGroup="Check"
                                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetCompany();"></asp:TextBox>
                                                        <asp:HiddenField ID="hfCompany" runat="server" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    Title<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="40" ValidationGroup="Check"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                                                        ControlToValidate="txtTitle" ErrorMessage="Please enter title" Font-Bold="True"
                                                        ForeColor="Red" Text="*" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    Location<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle">
                                                    <script type="text/javascript">
                                                        $(function () {
                                                            $("#txtLocation").autocomplete({
                                                                source: function (request, response) {
                                                                    $.ajax({
                                                                        url: "../AutoComplete.asmx/FetchLocationList",
                                                                        data: "{ 'prefixText': '" + request.term + "' }",
                                                                        dataType: "json",
                                                                        type: "POST",
                                                                        contentType: "application/json",
                                                                        dataFilter: function (data) { return data; },
                                                                        success: function (data) {
                                                                            response($.map(data.d, function (item) {
                                                                                return {
                                                                                    label: item.Name,
                                                                                    value: item.Name,
                                                                                    itemid: item.Code
                                                                                }
                                                                            }))
                                                                        },
                                                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                                                            alert(textStatus);
                                                                        }
                                                                    });
                                                                },
                                                                minLength: 2,
                                                                select: function (event, ui) {
                                                                    $('#hfLocation').val(ui.item.itemid);
                                                                },
                                                                change: function (event, ui) {
                                                                    if (ui.item == null) {
                                                                        $('#hfLocation').val("0");
                                                                    }
                                                                }
                                                            });

                                                        });
                                                    </script>
                                                    <div class="ui-widget">
                                                      <%--  <asp:CustomValidator Font-Bold="True" ForeColor="Red" runat="server" ID="CustomValidator3"
                                                            ControlToValidate="txtLocation" ClientValidationFunction="ValidateLocation" EnableClientScript="true"
                                                            Display="Dynamic" Text="Select Location From the List" ErrorMessage="Select Location From the List"
                                                            ValidationGroup="Check"></asp:CustomValidator>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                            ControlToValidate="txtLocation" ErrorMessage="Please Select Location" Font-Bold="True"
                                                            ForeColor="Red" Text="*" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtLocation" runat="server" CssClass="full" ValidationGroup="Check"
                                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetLocation();"></asp:TextBox>
                                                        <asp:HiddenField ID="hfLocation" runat="server" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    Time Period<span>(?)</span>
                                                </td>
                                               <td align="left" valign="middle">
                                                    <table id="tbl" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="To Date Must be greater then from Date"
                                                                    ControlToValidate="ddlFromMonth" ValidationGroup="Check" OnServerValidate="ValidateTenure"
                                                                    Text="<img src='/assets/Images/Exclamation.gif' title='To Date Must be greater then from Date!' />"></asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="ddlFromMonth"
                                                                    ErrorMessage="Please Select the From Month" Font-Bold="True" ForeColor="Red"
                                                                    Text="<img src='/assets/Images/Exclamation.gif' title='From Month is required!' />"
                                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                                <asp:DropDownList ID="ddlFromMonth" runat="server" Width="80px">
                                                                    <asp:ListItem Selected="True" Value="" Text="-Month-"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="1" Text="Jan"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="2" Text="Feb"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="3" Text="March"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="4" Text="April"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="5" Text="May"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="6" Text="June"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="7" Text="July"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="8" Text="Aug"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="9" Text="Sept"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="10" Text="Oct"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="11" Text="Nov"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="12" Text="Dec"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="ddlFromYear"
                                                                    ErrorMessage="Please Select the From Year" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='From Month is required!' />"
                                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                                <asp:DropDownList ID="ddlFromYear" runat="server" Width="80px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <label id="lblTo" type="label" runat="server">
                                                                    To</label>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvMonthTo" runat="server" Display="Dynamic" ControlToValidate="ddlToMonth"
                                                                    ErrorMessage="Please Select the To Month" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='To Month is required!' />"
                                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                                <asp:DropDownList ID="ddlToMonth" runat="server" Width="80px">
                                                                    <asp:ListItem Selected="True" Value="" Text="-Month-"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="1" Text="Jan"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="2" Text="Feb"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="3" Text="March"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="4" Text="April"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="5" Text="May"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="6" Text="June"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="7" Text="July"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="8" Text="Aug"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="9" Text="Sept"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="10" Text="Oct"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="11" Text="Nov"></asp:ListItem>
                                                                    <asp:ListItem Selected="False" Value="12" Text="Dec"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvYearTo" runat="server" Display="Dynamic" ControlToValidate="ddlToYear"
                                                                    ErrorMessage="Please Select the To Year" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='To Year is required!' />"
                                                                    InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                                <asp:DropDownList ID="ddlToYear" runat="server" Width="80px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <input id="chkPresent" runat="server" type="checkbox" onclick="javascript:ShowHideDateTo();"
                                                                    onkeydown="javascript:return (event.keyCode!=13);" />
                                                                <label for="chkPresent">
                                                                    Working</label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    Responsibilties<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtResponsibilities" runat="server" TextMode="MultiLine" Width="98%"
                                                        Height="80px" MaxLength="1000"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td align="left" valign="middle">
                                                    Reason of leave<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtResonforleaving" runat="server" TextMode="MultiLine" Width="98%"
                                                        Height="80px" MaxLength="1000"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    Current Salay<span>(?)</span>
                                                </td>
                                                <td align="left" valign="middle" class="nopad">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtCurrentSalary" ErrorMessage="Please enter Salary in Correct Format"
                                                                    Font-Bold="True" ForeColor="Red" Text="Salary in Correct Format is required"
                                                                    ValidationExpression="\d+\.?\d*" ValidationGroup="Check"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtCurrentSalary" ErrorMessage="Please Specify your current Salary"
                                                                    Font-Bold="True" ForeColor="Red" Text="*" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="padding: 0px;">
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCurrentSalary" runat="server" MaxLength="7" Style="width: 94%;"
                                                                                CssClass="medium" ValidationGroup="Check" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            (PKR)
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="left">
                                                                Initial salary<span>(?)</span>
                                                            </td>
                                                            <td>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtInitialSalary" ErrorMessage="Please enter Salary in Correct Format"
                                                                    Font-Bold="True" ForeColor="Red" Text="Salary in Correct Format is required"
                                                                    ValidationExpression="\d+\.?\d*" ValidationGroup="Check"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtInitialSalary" ErrorMessage="Please Specify your Initial Salary"
                                                                    Font-Bold="True" ForeColor="Red" Text="*" InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left">
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInitialSalary" runat="server" MaxLength="7" Style="width: 94%;"
                                                                                CssClass="medium" ValidationGroup="Check" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            (PKR)
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" colspan="2">
                                                    <asp:Repeater ID="rptBenefitTypes" runat="server" OnItemDataBound="rptBenefitTypes_OnItemDataBound">
                                                        <HeaderTemplate>
                                                            <table id="tblRptr" width="100%" cellpadding="0" cellspacing="0" border="0">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%# DataBinder.Eval(Container.DataItem, "Benefit_Type")%><span>(?)</span>
                                                                </td>
                                                                <td align="left" style="width: 70%">
                                                                    <asp:Repeater ID="rptBenefit" runat="server">
                                                                        <HeaderTemplate>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBenefitCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Benefit_Code")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:CheckBox ID="chkBenefitName" runat="server" />
                                                                            <asp:Label ID="lbltest" runat="server" Width="60px"><%# DataBinder.Eval(Container.DataItem, "Benefits")%></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                        </FooterTemplate>
                                                                    </asp:Repeater>
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
                                                <td align="left" valign="middle">
                                                </td>
                                                <td align="left" valign="middle">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="save btn"
                                            ValidationGroup="Check" />
                                        &nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnCancel_Click"
                                            CausesValidation="false" CssClass="cancel btn" />
                                    </td>
                                    <td align="right" valign="middle">
                                        <asp:ImageButton ToolTip="" ID="btnAddMore" runat="server" Text="Add More" ImageUrl="/assets2/images/crops/btn-add.png"
                                            Width="14" CausesValidation="false" Height="15" alt="" align="absmiddle" OnClick="btnAddMore_Click" />
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
