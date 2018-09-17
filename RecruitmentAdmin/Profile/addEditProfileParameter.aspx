<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addEditProfileParameter.aspx.cs"
    Inherits="addEditProfileParameter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Add/Edit Profile Parameter</title>
    <!--#include virtual="/assets/inc-Signup/scripts.html" -->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <style type="text/css">
        .select
        {
            -webkit-appearance: button;
            -moz-appearance: button;
            appearance: button;
            display: inline-block;
            background: #fafafa;
            background: -webkit-linear-gradient(top,  #fafafa 0%,#f4f4f4 40%,#e5e5e5 100%);
            padding: 6px 30px 6px 15px;
            border-radius: 3px;
            border: 1px solid #aaa;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
            color: #444;
        }
        
        .select:focus
        {
            outline: none;
        }
        
        .select-arrow
        {
            background-color:Black;
            display: inline-block;
            position: absolute;
            margin: .9em 0 0 -1.2em;
            border-left: 5px solid ;
            border-right: 5px solid ;
            border-top: 5px solid #777;
        }
        
        
        
        .btn-ora
        {
            background: url(/assets/images/bgs/btn.png) repeat-x top left;
            padding: 8px;
            color: #333333 !important;
            font-size: 12px;
            font-weight: bold;
            text-decoration: none;
            margin-top: 10px;
            margin-right: 5px;
            border: 0px;
        }
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
        <div class="career-service fullwidth">
            <table width="2345px" border="1px" cellspacing="5px" cellpadding="0" bgcolor="#FFFFFF"
                style="border-color: Gray">
                <tr style="background-color: #dddddd; height: 30px">
                    <th align="center" colspan="7">
                        <strong>Add/Edit Profile Parameter</strong>
                        <br />
                        <br />
                        <asp:Label runat="server" ID="lblmessage" ForeColor="#336600" Font-Bold="True"></asp:Label>
                    </th>
                </tr>
                <tr style="background-color: #dddddd; height: 30px">
                    <th align="center" style="width: 10px">
                        Select profile:
                    </th>
                    <th align="left" colspan="6">
                        <asp:DropDownList ID="ddlprofile" runat="server" AutoPostBack="true" CssClass="select"
                            OnSelectedIndexChanged="ddlProfile_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlprofile"
                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Designation is required!' />"
                            Display="Dynamic" InitialValue="-1" ValidationGroup="ddlprofile"></asp:RequiredFieldValidator>
                    </th>
                </tr>
                <%--Skill Set --%>
                <tr style="margin-bottom: 30px">
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Skill</h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="tbl" runat="server">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chk" runat="server" />Ismandatory
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#txtacSkill").autocomplete({
                                                    source: function (request, response) {
                                                        $.ajax({
                                                            url: "../AutoComplete.asmx/FetchSkillSetList",
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
                                                        $('#hdnSkillCode').val(ui.item.itemid);
                                                        $('#hdnSkillName').val(ui.item.value);
                                                        if ($('#chk').is(':checked')) {
                                                            $("#hdnSkillM").val("true");
                                                        } else {
                                                            $("#hdnSkillM").val("false");
                                                        }
                                                        $('#btnAddSkill').click();
                                                    },
                                                    change: function (event, ui) {
                                                        if (ui.item == null) {
                                                            this.value = '';
                                                            //alert('Please select a value from the list'); // or a custom message
                                                        }
                                                    }
                                                });

                                            });
                                        </script>
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacSkill" runat="server" Width="200px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnSkillCode" runat="server" />
                                            <asp:HiddenField ID="hdnSkillName" runat="server" />
                                            <asp:HiddenField ID="hdnSkillM" runat="server" />
                                            <asp:Button ID="btnAddSkill" runat="server" Text="Add" OnClick="btnAddSkill_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkSkillSave" runat="server" RepeatDirection="Horizontal" Visible="false">
                                        </asp:CheckBoxList>
                                        <table>
                                            <asp:Repeater ID="rptskill" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ckhEnable" Checked="true" />
                                                            <asp:HiddenField ID="hdnParameterValue" runat="server" Value='<%#Eval("Code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Name") %>' ID="lbl1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkMandatory" Checked='<%# ((string)Eval("Ismandatory")) == "true" ? true : false %>' />IsMandatory
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--Institute --%>
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Institute
                            </h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="Table1" runat="server">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkInstituteM" runat="server" />Ismandatory
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#txtacInstitute").autocomplete({
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
                                                        $('#hdnInstituteCode').val(ui.item.itemid);
                                                        $('#hdnInstituteName').val(ui.item.value);
                                                        if ($('#chkInstituteM').is(':checked')) {
                                                            $("#hdnInstituteM").val("true");
                                                        } else {
                                                            $("#hdnInstituteM").val("false");
                                                        }
                                                        $('#btnAddInstitute').click();
                                                    },
                                                    change: function (event, ui) {
                                                        if (ui.item == null) {
                                                            this.value = '';
                                                            //alert('Please select a value from the list'); // or a custom message
                                                        }
                                                    }
                                                });

                                            });
                                        </script>
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacInstitute" runat="server" Width="200px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnInstituteCode" runat="server" />
                                            <asp:HiddenField ID="hdnInstituteName" runat="server" />
                                            <asp:HiddenField ID="hdnInstituteM" runat="server" />
                                            <asp:Button ID="btnAddInstitute" runat="server" Text="Add" OnClick="btnAddInstitute_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkInstituteSave" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                            Visible="false">
                                        </asp:CheckBoxList>
                                        <table>
                                            <asp:Repeater ID="rptInstitute" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ckhEnable" Checked="true" />
                                                            <asp:HiddenField ID="hdnParameterValue" runat="server" Value='<%#Eval("Code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Name") %>' ID="lbl1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkMandatory" Checked='<%# ((string)Eval("Ismandatory")) == "true" ? true : false %>' />IsMandatory
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--Industry--%>
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Industry
                            </h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="Table7" runat="server">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkIndustry" runat="server" />Ismandatory
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#txtacIndustry").autocomplete({
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
                                                        $('#hdnIndustryCode').val(ui.item.itemid);
                                                        $('#hdnIndustryName').val(ui.item.value);
                                                        if ($('#chkIndustry').is(':checked')) {
                                                            $("#hdnIndustryMandatory").val("true");
                                                        } else {
                                                            $("#hdnIndustryMandatory").val("false");
                                                        }
                                                        $('#btnIndustryAdd').click();
                                                    },
                                                    change: function (event, ui) {
                                                        if (ui.item == null) {
                                                            this.value = '';
                                                            //alert('Please select a value from the list'); // or a custom message
                                                        }
                                                    }
                                                });

                                            });
                                        </script>
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacIndustry" runat="server" Width="200px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnIndustryCode" runat="server" />
                                            <asp:HiddenField ID="hdnIndustryName" runat="server" />
                                            <asp:HiddenField ID="hdnIndustryMandatory" runat="server" />
                                            <asp:Button ID="btnIndustryAdd" runat="server" Text="Add" OnClick="btnIndustryAdd_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkIndustrySave" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                            Visible="false">
                                        </asp:CheckBoxList>
                                        <table>
                                            <asp:Repeater ID="rptIndustry" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ckhEnable" Checked="true" />
                                                            <asp:HiddenField ID="hdnParameterValue" runat="server" Value='<%#Eval("Code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Name") %>' ID="lbl1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkMandatory" Checked='<%# ((string)Eval("Ismandatory")) == "true" ? true : false %>' />IsMandatory
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--Company--%>
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Company
                            </h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="Table9" runat="server">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkComapany" runat="server" />Ismandatory
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#txtacComapany").autocomplete({
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
                                                        $('#hdnComapanyCode').val(ui.item.itemid);
                                                        $('#hdnComapanyName').val(ui.item.value);
                                                        if ($('#chkComapany').is(':checked')) {
                                                            $("#hdnComapanyMandatory").val("true");
                                                        } else {
                                                            $("#hdnComapanyMandatory").val("false");
                                                        }
                                                        $('#btnComapanyAdd').click();
                                                    },
                                                    change: function (event, ui) {
                                                        if (ui.item == null) {
                                                            this.value = '';
                                                            //alert('Please select a value from the list'); // or a custom message
                                                        }
                                                    }
                                                });

                                            });
                                        </script>
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacComapany" runat="server" Width="200px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnComapanyCode" runat="server" />
                                            <asp:HiddenField ID="hdnComapanyName" runat="server" />
                                            <asp:HiddenField ID="hdnComapanyMandatory" runat="server" />
                                            <asp:Button ID="btnComapanyAdd" runat="server" Text="Add" OnClick="btnComapanyAdd_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkCompanySave" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                            Visible="false">
                                        </asp:CheckBoxList>
                                        <table>
                                            <asp:Repeater ID="rptCompany" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ckhEnable" Checked="true" />
                                                            <asp:HiddenField ID="hdnParameterValue" runat="server" Value='<%#Eval("Code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Name") %>' ID="lbl1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkMandatory" Checked='<%# ((string)Eval("Ismandatory")) == "true" ? true : false %>' />IsMandatory
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--Degree--%>
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Degree
                            </h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="Table11" runat="server">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkDegree" runat="server" />Ismandatory
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#txtacDegree").autocomplete({
                                                    source: function (request, response) {
                                                        $.ajax({
                                                            url: "../AutoComplete.asmx/FetchAllDegreeSetList",
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
                                                        $('#hdnDegreeCode').val(ui.item.itemid);
                                                        $('#hdnDegreeName').val(ui.item.value);
                                                        if ($('#chkDegree').is(':checked')) {
                                                            $("#hdnDegreeMandatory").val("true");
                                                        } else {
                                                            $("#hdnDegreeMandatory").val("false");
                                                        }
                                                        $('#btnDegreeAdd').click();
                                                    },
                                                    change: function (event, ui) {
                                                        if (ui.item == null) {
                                                            this.value = '';
                                                            //alert('Please select a value from the list'); // or a custom message
                                                        }
                                                    }
                                                });

                                            });
                                        </script>
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacDegree" runat="server" Width="200px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnDegreeCode" runat="server" />
                                            <asp:HiddenField ID="hdnDegreeName" runat="server" />
                                            <asp:HiddenField ID="hdnDegreeMandatory" runat="server" />
                                            <asp:Button ID="btnDegreeAdd" runat="server" Text="Add" OnClick="btnDegreeAdd_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkDegreeSave" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                            Visible="false">
                                        </asp:CheckBoxList>
                                        <table>
                                            <asp:Repeater ID="rptDegree" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ckhEnable" Checked="true" />
                                                            <asp:HiddenField ID="hdnParameterValue" runat="server" Value='<%#Eval("Code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Name") %>' ID="lbl1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkMandatory" Checked='<%# ((string)Eval("Ismandatory")) == "true" ? true : false %>' />IsMandatory
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--Major--%>
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Major
                            </h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="Table13" runat="server">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkMajor" runat="server" />Ismandatory
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <script type="text/javascript">
                                            $(function () {
                                                $("#txtacMajor").autocomplete({
                                                    source: function (request, response) {
                                                        $.ajax({
                                                            url: "../AutoComplete.asmx/FetchMajorSetList",
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
                                                        $('#hdnMajorCode').val(ui.item.itemid);
                                                        $('#hdnMajorName').val(ui.item.value);
                                                        if ($('#chkMajor').is(':checked')) {
                                                            $("#hdnMajorMandatory").val("true");
                                                        } else {
                                                            $("#hdnMajorMandatory").val("false");
                                                        }
                                                        $('#btnMajorAdd').click();
                                                    },
                                                    change: function (event, ui) {
                                                        if (ui.item == null) {
                                                            this.value = '';
                                                            //alert('Please select a value from the list'); // or a custom message
                                                        }
                                                    }
                                                });

                                            });
                                        </script>
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacMajor" runat="server" Width="200px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnMajorCode" runat="server" />
                                            <asp:HiddenField ID="hdnMajorName" runat="server" />
                                            <asp:HiddenField ID="hdnMajorMandatory" runat="server" />
                                            <asp:Button ID="btnMajorAdd" runat="server" Text="Add" OnClick="btnMajorAdd_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkMajorSave" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                            Visible="false">
                                        </asp:CheckBoxList>
                                        <table>
                                            <asp:Repeater ID="rptMajor" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="ckhEnable" Checked="true" />
                                                            <asp:HiddenField ID="hdnParameterValue" runat="server" Value='<%#Eval("Code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label Text='<%# Eval("Name") %>' ID="lbl1" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkMandatory" Checked='<%# ((string)Eval("Ismandatory")) == "true" ? true : false %>' />IsMandatory
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                     <%--Experience--%>
                    <td valign="top" style="width: 335px">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Experience
                            </h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="Table2" runat="server">
                                <tr>
                                    <td>
                                       <asp:DropDownList runat="server" ID="ddlExperience"></asp:DropDownList>
                                    </td>
                                </tr>
                                
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <%-- Save --%>
            <table width="2345px">
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btnSaveAll" Text="Save" OnClick="btnSaveAll_Click"
                            CssClass="btn-ora" ValidationGroup="ddlprofile" />
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</body>
</html>
