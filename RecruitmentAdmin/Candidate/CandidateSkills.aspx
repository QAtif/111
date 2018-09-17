<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateSkills.aspx.cs"
    Inherits="CandidateSkills" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Skills</title>
    <!--#include virtual="/assets/inc-Signup/scripts.html" -->
    <script type="text/javascript">
        //        window.onload = function () {
        //            parent.location.reload(true);
        //        }
        //        var temp_f;
        //        if (window.on) {
        //            temp_f = window.onunload;
        //        }

        //        window.onunload = function () {
        //            if (temp_f) {
        //                temp_f();
        //            }
        //            parent.location.reload(true);
        //        }
        //  window.onunload = parent.location.reload(true);// window.parent.location.href = "../Candidate/CandidateDetails.aspx?CID=" + '<%= CID %>';
        function ValidateChkList(source, args) {
            //debugger;
            var chkListModules = document.getElementById('<%= chkSkills.ClientID %>');
            var txtacSkill = document.getElementById('<%= txtacSkill.ClientID %>').value;


            if (chkListModules == null && txtacSkill.length <= 1) {
                args.IsValid = false;
                return;
            }
            else if (txtacSkill.length > 1) {
                if (chkListModules == null) {
                    args.IsValid = true;
                    return;
                }
                else {
                    var chkListinputs = chkListModules.getElementsByTagName("input");
                    for (var i = 0; i < chkListinputs.length; i++) {
                        if (chkListinputs[i].checked) {
                            args.IsValid = true;
                            return;
                        }
                    }
                }
            }
            else if (txtacSkill.length <= 1) {
                if (chkListModules != null) {
                    var chkListinputs = chkListModules.getElementsByTagName("input");
                    for (var i = 0; i < chkListinputs.length; i++) {
                        if (chkListinputs[i].checked) {
                            args.IsValid = true;
                            return;
                        }
                    }
                }
            }
            args.IsValid = false;
        }
        function CloseHighSlideWithParentRefresh() {
            alert('Saved Sucessfully');
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                // parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }



    </script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
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
        <div class="career-service fullwidth">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td valign="top">
                        <div class="governscr formarea">
                            <h2 class="innerhdtop">
                                Skill Set</h2>
                            <table width="100%" cellpadding="0" cellspacing="0" id="tbl" runat="server">
                                <tr>
                                    <td>
                                        Enter your Skill or Expertise<span>(?)</span>
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
                                                        $('#hfSkillCode').val(ui.item.itemid);
                                                        $('#hfSkillName').val(ui.item.value);
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
                                            <asp:TextBox ID="txtacSkill" runat="server" Width="600px" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                                            <asp:HiddenField ID="hfSkillCode" runat="server" />
                                            <asp:HiddenField ID="hfSkillName" runat="server" />
                                            <asp:Button ID="btnAddSkill" runat="server" Text="Add" OnClick="btnAddSkill_Click"
                                                Style="display: none;" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkSkills" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                        <asp:CustomValidator runat="server" ID="cvSkilllist" ClientValidationFunction="ValidateChkList"
                                            ErrorMessage="Please Select Atleast one Skill."></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="spera">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3">
                                        <table id="tblbtn" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="save btn" />
                                                </td>
                                                <td align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
