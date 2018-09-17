<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateCertificate.aspx.cs"
    Inherits="CandidateCertificate" %>

%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Certificate</title>
    <!--#include virtual="/assets/inc-Signup/scripts.html" -->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
    <script type="text/jscript">
        function ValidateInstitute(source, args) {

            if (document.getElementById('hfInstitute').value.toString() != "")
                args.IsValid = true;
            else
                args.IsValid = false;
        }
        function ValidateCertificate(source, args) {

            if (document.getElementById('hfCertificate').value.toString() != "")
                args.IsValid = true;
            else
                args.IsValid = false;
        }
        function ValidateField(source, args) {

            if (document.getElementById('hfField').value.toString() != "")
                args.IsValid = true;
            else
                args.IsValid = false;
        }
        function selectValue() {
            if (document.getElementById("rblPosition_0").checked == true) {
                $("#txtPosition").show(500);
                ValidatorEnable(document.getElementById('<%=RegularExpressionValidator12.ClientID %>'), true);
                ValidatorEnable(document.getElementById('<%=RequiredFieldValidator7.ClientID %>'), true);
                $("#Label6").show(500);
            }
            if (document.getElementById("rblPosition_1").checked == true) {
                $("#txtPosition").hide(500);
                ValidatorEnable(document.getElementById('<%=RegularExpressionValidator12.ClientID %>'), false);
                ValidatorEnable(document.getElementById('<%=RequiredFieldValidator7.ClientID %>'), false);
                $("#Label6").hide(500);
            }
        }
        function TenureValidation(source, args) {
            args.IsValid = false;
            var a = new Date();
            var b = new Date();
            a = document.getElementById("txtFromDate");
            b = document.getElementById("txtToDate");
            if (a < b) {
                args.IsValid = true;
                //alert('ok');
            }
            else {
                args.IsValid = false;
                //alert('wrong');
            }
        }
    </script>
    <script type="text/javascript">

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
            if (document.getElementById('chkStudy').checked) {
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
    <link title="win2k-cold-1" media="all" href="/assets/inc-Signup/calendar/calendar-win2k-cold-1.css"
        type="text/css" rel="stylesheet" />
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
            background: transparent url(Images/WarningHeader.gif) no-repeat 12px 30px;
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
</head>
<body>
    <div>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      
        <div>
            <div class="career-service fullwidth">
                <h3 class="popup-hd-top" style="width: 91.3%;">
                    Add/Edit Certificate(s)
                </h3>
               
                <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#ffffff">
                    <tr>                        
                        <td valign="top">
                            <div class="governscr formarea">
                                <h2 class="innerhdtop">
                                    Certificate</h2>
                                <table id="tblMain" cellpadding="0" cellspacing="0" runat="server" width="100%">
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
                                                                Institute
                                                            </td>
                                                            <td align="center" bgcolor="#dedede">
                                                                Certificate
                                                            </td>
                                                            <td align="center" bgcolor="#dedede">
                                                                Field
                                                            </td>
                                                            <td align="center" bgcolor="#dedede">
                                                                From
                                                            </td>
                                                            <td align="center" bgcolor="#dedede">
                                                                To
                                                            </td>
                                                            <td align="center" bgcolor="#dedede">
                                                                Grade
                                                            </td>
                                                            <td align="center" bgcolor="#dedede">
                                                                Action
                                                            </td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td bgcolor="#ffffff" align="center">
                                                            <%# Container.ItemIndex+1%>
                                                            <asp:Label ID="lblQualificationCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                                                Visible="false"></asp:Label>
                                                        </td>
                                                        <td bgcolor="#ffffff">
                                                            <%# DataBinder.Eval(Container.DataItem, "Institute")%>
                                                        </td>
                                                        <td bgcolor="#ffffff">
                                                            <%# DataBinder.Eval(Container.DataItem, "CandidateCertificate")%>
                                                        </td>
                                                        <td bgcolor="#ffffff">
                                                            <%# DataBinder.Eval(Container.DataItem, "Field")%>
                                                        </td>
                                                        <td bgcolor="#ffffff">
                                                            <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                                                        </td>
                                                        <td bgcolor="#ffffff">
                                                            <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                        </td>
                                                        <td bgcolor="#ffffff">
                                                            <%# DataBinder.Eval(Container.DataItem, "Grade")%>
                                                        </td>
                                                        <td bgcolor="#ffffff" align="center">
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/assets/images/edit.png"
                                                                CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                                                CausesValidation="false" />
                                                            <asp:ImageButton ID="imgDel" runat="server" ImageUrl="/assets/images/0.gif" OnClientClick="javascript:return confirm('Are you sure you want to delete the selected Certificate?');"
                                                                CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                                                CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <asp:HiddenField ID="hfCertificateCode" runat="server" Value="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:ValidationSummary ID="vsValidators" HeaderText="<div class='validationheader'>&nbsp;Important:</div>"
                                                DisplayMode="BulletList" EnableClientScript="true" runat="server" ValidationGroup="Check"
                                                CssClass="validationsummary" />
                                            <span id="jserr"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="140" align="left" valign="middle">
                                                        Institute
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <script type="text/javascript">
                                                            $(function () {
                                                                $("#txtInstitute").autocomplete({
                                                                    source: function (request, response) {
                                                                        $.ajax({
                                                                            url: "../AutoComplete.asmx/FetchInstituteList",
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
                                                                        $('#hfInstitute').val(ui.item.itemid);
                                                                    },
                                                                    change: function (event, ui) {
                                                                        if (ui.item == null) {
                                                                            $('#hfInstitute').val("0");
                                                                        }
                                                                    }
                                                                });
                                                            });
                                                        </script>
                                                        <div class="ui-widget">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                                                ControlToValidate="txtInstitute" ErrorMessage="Please Select Institute" Font-Bold="True"
                                                                ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Institute is required!' />"
                                                                InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="txtInstitute" runat="server" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"
                                                                onkeypress="javascript:ResetInstitute();" MaxLength="100"></asp:TextBox>
                                                            <asp:HiddenField ID="hfInstitute" runat="server" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        Certificate
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <script type="text/javascript">
                                                            $(function () {
                                                                $("#txtCertificate").autocomplete({
                                                                    source: function (request, response) {
                                                                        $.ajax({
                                                                            url: "../AutoComplete.asmx/FetchCertificateList",
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
                                                                        $('#hfCertificate').val(ui.item.itemid);
                                                                    },
                                                                    change: function (event, ui) {
                                                                        if (ui.item == null) {
                                                                            $('#hfCertificate').val("0");
                                                                        }
                                                                    }
                                                                });

                                                            });
                                                        </script>
                                                        <div class="ui-widget">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                                                ControlToValidate="txtCertificate" ErrorMessage="Please Select Certificate" Font-Bold="True"
                                                                ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Certificate is required!' />"
                                                                InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="txtCertificate" runat="server" MaxLength="100" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"
                                                                onkeypress="javascript:ResetCertificate();"></asp:TextBox>
                                                            <asp:HiddenField ID="hfCertificate" runat="server" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        Field
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <script type="text/javascript">
                                                            $(function () {
                                                                $("#txtField").autocomplete({
                                                                    source: function (request, response) {
                                                                        $.ajax({
                                                                            url: "../AutoComplete.asmx/FetchFieldList",
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
                                                                        $('#hfField').val(ui.item.itemid);
                                                                    },
                                                                    change: function (event, ui) {
                                                                        if (ui.item == null) {
                                                                            $('#hfField').val("0");
                                                                        }
                                                                    }
                                                                });
                                                            });
                                                        </script>
                                                        <div class="ui-widget">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtField" ErrorMessage="Please Select Field" Font-Bold="True"
                                                                ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Field is required!' />"
                                                                InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="txtField" runat="server" MaxLength="100" CssClass="full" onkeydown="javascript:return (event.keyCode!=13);"
                                                                onkeypress="javascript:ResetField();"></asp:TextBox>
                                                            <asp:HiddenField ID="hfField" runat="server" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        Date
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <table id="tbl" runat="server" cellpadding="0" cellspacing="0" width="100%" class="nopadtbl">
                                                            <tr>
                                                                <td>
                                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="To Date Must be greater then from Date"
                                                                        ControlToValidate="ddlFromMonth" ValidationGroup="Check" OnServerValidate="ValidateTenure"
                                                                        Text="<img src='/assets/Images/Exclamation.gif' title='To Date Must be greater then from Date!' />"></asp:CustomValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ControlToValidate="ddlFromMonth"
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
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic" ControlToValidate="ddlFromYear"
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
                                                                    <input id="chkStudy" runat="server" type="checkbox" onclick="javascript:ShowHideDateTo();" />
                                                                    <label for="chkStudy">
                                                                        Studying</label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        Score
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <table cellpadding="0" cellspacing="0" runat="server" id="fs" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="This is not a Valid Score"
                                                                        ValidationGroup="Check" ValidationExpression="^[a-zA-Z0-9.+]*$" ControlToValidate="txtGrade"
                                                                        Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='This is not a Valid Score' />"
                                                                        InitialValue="" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                    --%><asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtGrade" ErrorMessage="Please Specify Sore" Font-Bold="True"
                                                                        ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Sore is required!' />"
                                                                        InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                                    <asp:TextBox ID="txtGrade" runat="server" MaxLength="5" CssClass="medium" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                                                </td>
                                                                <td class="rdofix">
                                                                    <asp:RadioButtonList ID="rblGradingSystem" runat="server" RepeatDirection="Horizontal"
                                                                        onkeydown="javascript:return (event.keyCode!=13);">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        Position
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtPosition" ErrorMessage="Please enter Position in Correct Format"
                                                                        Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Position in Correct Format is required!' />"
                                                                        ValidationExpression="^[1-99]*$" ValidationGroup="Check"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtPosition" ErrorMessage="Please Specify Position" Font-Bold="True"
                                                                        ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Position is required!' />"
                                                                        InitialValue="" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblPosition" runat="server" onclick="javascript:return selectValue();"
                                                                        CausesValidation="false" RepeatDirection="Horizontal" onkeydown="javascript:return (event.keyCode!=13);">
                                                                        <asp:ListItem Selected="False" Text="Yes" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Selected="True" Text="No" Value="2"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPosition" runat="server" MaxLength="2" class="medium" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        Activities &amp; Societies
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtActivities" runat="server" TextMode="MultiLine" CssClass="full"
                                                            Height="80px" MaxLength="1000"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="right">
                                            <br />
                                            <br />
                                            <asp:ImageButton ToolTip="" ID="btnAddMore" runat="server" Text="Add More" ImageUrl="/assets2/images/crops/btn-add.png"
                                                Width="14" CausesValidation="false" Height="15" alt="" align="absmiddle" OnClick="btnAddMore_Click"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <div class="spera">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table id="tblbtn" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="save btn"
                                                            ValidationGroup="Check" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" colspan="2" style="padding-right: 25px;">
                                          
                                           
                                        </td>
                                    </tr>
                                </table>
                               
                            </div>
                        </td>
                    </tr>
                </table>
           
            </div>
        </div>
        </form>
    </div>
</body>
</html>
