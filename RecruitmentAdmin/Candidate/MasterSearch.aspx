<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MasterSearch.aspx.cs" Inherits="Candidate_MasterSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidates Master Search</title>

    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>

    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>

    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <style type="text/css">
        .completionListElement
        {
            visibility: hidden;
            margin: 0px !important;
            background-color: inherit;
            color: black;
            border: solid 1px;
            cursor: pointer;
            text-align: left;
            list-style-type: none;
            font-family: Verdana;
            font-size: 12px;
            padding: 0;
        }
        .listItem
        {
            background-color: White;
            padding: 1px;
        }
        .highlightedListItem
        {
            background-color: Silver;
            padding: 1px;
        }
        .floatDiv
        {
            text-align: center;
            background-color: #EBEBEB;
            border-bottom: 1px solid #D5D5D5;
            border-left: 1px solid #D5D5D5;
        }
    </style>
    <%-- <script type="text/javascript">

        $(document).ready(
        function () {

            $.widget("custom.threecolumnautocomplete2", $.ui.autocomplete, {
                _renderMenu: function (ul, items) {
                    var self = this;
                    ul.append("<div id='container' style='min-height: 20px !important;min-width:80px !important;width:280px; !important;' class='specialpointer'><table  border='0' cellpadding='0' cellspacing='none'><tbody></tbody></table></div>");
                    $.each(items, function (index, item) {
                        self._renderItem(ul.find("table tbody"), item);
                    });
                },

                _renderItem: function (table, item) {
                    return $("<tr></tr>").click(function () {
                        document.getElementById("<%=txtCandidateName.ClientID %>").value = item.value.split("|")[0];
                        document.getElementById("<%=hdnCandidateCode.ClientID %>").value = item.value.split("|")[1];
                        $('#<%=txtCandidateName.ClientID %>').threecolumnautocomplete2("close");
                    })
         .data("item.autocomplete", item)
    	.append("<td>" + item.label + " &nbsp;</td>")
    .appendTo(table);
                }
            });

            $('#<%=txtCandidateName.ClientID %>').threecolumnautocomplete2({
                //                select: function (event, ui) {
                //                    $('#hdnAssetCategoryID').val(ui.item.code);
                //                    $('#txtAssetCategory').val(ui.item.label);
                //                    return false;
                //                },
                source: function (request, response) {
                    $.ajax({

                        url: "../AutoComplete.asmx/FetchMappedCandidate",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json",
                        data: "{ 'prefixText': '" + request.term + "' }",
                        // dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {

                                    label: item.CandidateFullName + "[" + item.CandidateEmailAddress + "]",
                                    value: item.CandidateFullName + "|" + item.CandidateCode
                                    //code: item.AssetCategoryID
                                }
                            }));
                        },

                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                            alert(errorThrown);
                        }

                    });
                }, minLength: 1
            });
        });
    </script>--%>
    <style>
        #sortable
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 80%;
        }
        #sortable li
        {
            margin: 0 3px 3px 3px;
            padding: 0.4em;
            padding-left: 1.5em;
            font-family: Calibri;
            font-size: 14px;
            height: 12px;
            cursor: move;
        }
        #sortable li span
        {
            position: absolute;
            margin-left: -1.3em;
        }
        #sortableInstitute
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 80%;
        }
        #sortableInstitute li
        {
            margin: 0 3px 3px 3px;
            padding: 0.4em;
            padding-left: 1.5em;
            font-family: Calibri;
            font-size: 14px;
            height: 12px;
            cursor: move;
        }
        #sortableInstitute li span
        {
            position: absolute;
            margin-left: -1.3em;
        }
        #sortableDegree
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 80%;
        }
        #sortableDegree li
        {
            margin: 0 3px 3px 3px;
            padding: 0.4em;
            padding-left: 1.5em;
            font-family: Calibri;
            font-size: 14px;
            height: 12px;
            cursor: move;
        }
        #sortableDegree li span
        {
            position: absolute;
            margin-left: -1.3em;
        }
        #sortableMajor
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 80%;
        }
        #sortableMajor li
        {
            margin: 0 3px 3px 3px;
            padding: 0.4em;
            padding-left: 1.5em;
            font-family: Calibri;
            font-size: 14px;
            height: 12px;
            cursor: move;
        }
        #sortableMajor li span
        {
            position: absolute;
            margin-left: -1.3em;
        }
        #sortableCompany
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 80%;
        }
        #sortableCompany li
        {
            margin: 0 3px 3px 3px;
            padding: 0.4em;
            padding-left: 1.5em;
            font-family: Calibri;
            font-size: 14px;
            height: 12px;
            cursor: move;
        }
        #sortableCompany li span
        {
            position: absolute;
            margin-left: -1.3em;
        }
        #checks_container
        {
            width: 850px !important;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1.5px solid #E8E8E8;
            font-family: Verdana;
            font-size: 12px;
            overflow: auto;
            position: absolute;
            z-index: 999;
            text-align: left;
        }
        #checks_containerInstitute
        {
            width: 850px !important;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1.5px solid #E8E8E8;
            font-family: Verdana;
            font-size: 12px;
            overflow: auto;
            position: absolute;
            z-index: 999;
            text-align: left;
        }
        #checks_containerDegree
        {
            width: 850px !important;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1.5px solid #E8E8E8;
            font-family: Verdana;
            font-size: 12px;
            overflow: auto;
            position: absolute;
            z-index: 999;
            text-align: left;
            right: 300px;
        }
        #checks_containerMajor
        {
            width: 850px !important;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1.5px solid #E8E8E8;
            font-family: Verdana;
            font-size: 12px;
            overflow: auto;
            position: absolute;
            z-index: 999;
            text-align: left;
        }
        #checks_containerCompany
        {
            width: 850px !important;
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1.5px solid #E8E8E8;
            font-family: Verdana;
            font-size: 12px;
            overflow: auto;
            position: absolute;
            z-index: 999;
            text-align: left;
        }
    </style>

    <script type="text/javascript">
        function SkillItemSelected(sender, e) {
            document.getElementById('<%=hfSkillCode.ClientID %>').value = e.get_value();
            document.getElementById('<%=hfSkillName.ClientID %>').value = e.get_text();
            document.getElementById('<%=btnAddSkill.ClientID %>').click();
        }


        function ShowFreshDiv(btn) {

            $(".dvFresh").show();
            $(".dvExperience").hide();
            $(btn).addClass('btnFresh btn-ora nl');
            $(".btnExperience").removeClass('btn-ora nl');

            ResetExperience();

        }

        function ShowExperienceDiv(btn) {

            $(".dvExperience").show();
            $(".dvFresh").hide();

            $(btn).addClass('btnExperience btn-ora nl');
            $(".btnFresh").removeClass('btn-ora nl');

            ResetFresh();

        }

        function ResetExperience() {
            $(".hdnFilterType").val("1");

        }

        function ResetFresh() {
            $(".hdnFilterType").val("2");

        }
      
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Candidates Master Search</span>
        </h2>
        <div style="float: right">
            <button id="btnFresh" runat="server" name="btnFresh" class="btnFresh btn-ora nl"
                onclick="ShowFreshDiv(this);" type="button">
                Fresh
            </button>
            <%--  <asp:Button ID="btnFresh" runat="server" CssClass="btn-ora nl" Text="Fresh" OnClick="btnFresh_Click" />
            &nbsp;
            <asp:Button ID="btnExperience" runat="server" Text="Experience" OnClick="btnExperience_Click" />--%>
            <button id="btnExperience" runat="server" name="btnExperience" class="btnExperience"
                onclick="ShowExperienceDiv(this);" type="button">
                Expeirence
            </button>
        </div>
    </div>
    <div id="container" class="contentarea">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    <strong>Search Criteria </strong>
                </th>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Select Category:
                </td>
                <td align="center" id="CategoryTab">

                    <script>
                        (function($) {
                            $.fn.goTo = function() {
                                $('html, body').animate({
                                    scrollTop: $(this).offset().top + 'px'
                                }, 'fast');
                                return this; // for chaining...
                            }
                        })(jQuery);

                        function showHideCheckBoxList(checkd, isPostBack, ischk) {
                            if (checkd) {
                                document.getElementById('checks_container').style.display = 'none';
                            }
                            else
                            { document.getElementById('checks_container').style.display = ''; }

                            if (isPostBack) {

                                document.getElementById('sortable').innerHTML = '';

                                var lent = document.getElementById('checks_container').children.length;
                                for (i = 0; i < lent; i++) {
                                    if (document.getElementById('checks_container').children[i].children[0].checked) {
                                        if (document.getElementById('sortable').innerHTML.indexOf("Selected Categories") == -1)
                                        { document.getElementById('sortable').innerHTML += "<div><b>Selected Categories:</b> <i>(Drag to arrange category preference)</i></div>"; }
                                        var catName = document.getElementById('checks_container').children[i].textContent || document.getElementById('checks_container').children[i].innerText;
                                        var catCode = document.getElementById('checks_container').children[i].children[0].value;
                                        document.getElementById('sortable').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";

                                        var catcodes = $('.hdnCategory').val();

                                        $('.hdnCategory').val($('.hdnCategory').val() + catCode.toString() + ",");

                                    }
                                }


                                if (checkd && ischk) {
                                    document.getElementById('checks_container').style.display = 'none';
                                    document.getElementById('sortable').innerHTML = '';
                                    $('.hdnCategory').val("");
                                }
                            }
                            else {
                                var oldValue = $('.hdnCategory').val();
                                if (oldValue != "") {
                                    var catName;
                                    var catCode;
                                    document.getElementById('sortable').innerHTML = '';
                                    document.getElementById('sortable').innerHTML += "<div><b>Selected Categories:</b> <i>(Drag to arrange category preference)</i></div>";

                                    oldValue = oldValue.slice(0, -1); // remove comma from end
                                    var arr = oldValue.split(',');
                                    $.each(arr, function(key, line) {
                                        //alert(key);
                                        var lent = document.getElementById('checks_container').children.length;
                                        var idx = key + 1;
                                        catCode = line.replace(idx, '');
                                        for (i = 0; i < lent; i++) {
                                            if (catCode == document.getElementById('checks_container').children[i].children[0].value) {
                                                //alert(catCode + " - " + catName);
                                                catName = document.getElementById('checks_container').children[i].textContent || document.getElementById('checks_container').children[i].innerText;
                                                break;
                                            }
                                        }
                                        document.getElementById('sortable').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";
                                    });
                                }
                            }
                        }
                              
                    </script>

                    <div class="check textbox">
                        <input type="checkbox" name="chkCategory" id="chkCategory" class="chkCategory" runat="server"
                            value="-1" checked="checked" onclick="showHideCheckBoxList(this.checked, true, true);" />Show
                        All</div>
                    <div id="checks_container" style="display: none">
                        <div class="floatDiv">
                            <h5>
                                <strong>Select Category: </strong>
                            </h5>
                        </div>
                        <div class="check" style="float: right;">
                            <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxList(true, true, false);$('#CategoryTab').goTo();"></div>
                        <asp:Repeater ID="rptCategory" runat="server">
                            <ItemTemplate>
                                <div class="check" style="width: 410px; float: left">
                                    <input type="checkbox" name="chkCategory" value='<%# Eval("Category_Code")%>' />
                                    <%# Eval("Category_Name")%></div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="check" style="float: right;">
                            <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxList(true, true, false);$('#CategoryTab').goTo();"></div>
                    </div>
                </td>
                <td style="width: 15%" align="center">
                    Reference No.:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtRefNo" MaxLength="16" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Candidate Name:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtCandidateName" Width="280px"></asp:TextBox>
                    <asp:HiddenField ID="hdnCandidateCode" Value="-1" runat="server" />
                </td>
                <td style="width: 15%" align="center">
                    Lify Cycle Status :
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Candidate Email:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtEmail" Width="280px"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" Value="-1" runat="server" />
                    <br />
                    <asp:CheckBox ID="chkEmail" runat="server" Text="Exactly match Email" />
                </td>
                <td style="width: 15%" align="center">
                    Candidate Phone No:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtPhone" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Candidate NIC:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtNIC" Width="280px"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField2" Value="-1" runat="server" />
                </td>
                <td style="width: 15%" align="center">
                    Select City:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlCity" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Marital Status:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Select Gender:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlGender" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    From Date:
                </td>
                <td align="center">
                    <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 257px"
                        clientidmode="Static" />
                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img5" /><strong>

                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedFromDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img5",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>

                    </strong>
                </td>
                <td style="width: 15%" align="center">
                    To Date:
                </td>
                <td align="center">
                    <input runat="server" width="50px" type="text" id="postedToDate" style="width: 257px"
                        clientidmode="Static" />
                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img6" /><strong>

                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedToDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img6",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>

                    </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Skills/Expertise:
                </td>
                <td align="center">
                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtacSkill" runat="server" Width="280px"></asp:TextBox>
                            <ajax:autocompleteextender runat="server" id="acSkill" targetcontrolid="txtacSkill"
                                servicemethod="FetchSkillList" servicepath="~/AutoComplete.asmx" minimumprefixlength="2"
                                completioninterval="0" enablecaching="true" completionsetcount="20" completionlistcssclass="completionListElement"
                                completionlistitemcssclass="listItem" completionlisthighlighteditemcssclass="highlightedListItem"
                                firstrowselected="false" onclientitemselected="SkillItemSelected" showonlycurrentwordincompletionlistitem="true">
                    </ajax:autocompleteextender>
                            <asp:HiddenField ID="hfSkillCode" runat="server" />
                            <asp:HiddenField ID="hfSkillName" runat="server" />
                            <asp:Button ID="btnAddSkill" runat="server" Text="Add" OnClick="btnAddSkill_Click"
                                Style="display: none;" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 15%" align="center">
                    Referred By:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlReferredBy" runat="server" Width="280px">
                        <asp:ListItem Value="R" Text="Referred"></asp:ListItem>
                        <asp:ListItem Value="N" Text="Not Referred"></asp:ListItem>
                        <asp:ListItem Value="B" Text="Both" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkSkills" BorderStyle="None" RepeatLayout="Flow" CellSpacing="4"
                                runat="server" RepeatColumns="7" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="font11">
                    <ul id="sortable">
                    </ul>
                </td>
                <td colspan="2">
                </td>
            </tr>
        </table>
        <br />
        <br />
        <div id="dvFresh" runat="server" class="dvFresh">
            <table width="60%" border="0" cellpadding="10" cellspacing="0">
                <tr>
                    <th colspan="4">
                        <strong>Education </strong>
                    </th>
                </tr>
                <tr>
                    <td style="width: 15%" align="center">
                        Select Institute:
                    </td>
                    <td align="center" id="InstituteTab">

                        <script>
                            (function($) {
                                $.fn.goTo = function() {
                                    $('html, body').animate({
                                        scrollTop: $(this).offset().top + 'px'
                                    }, 'fast');
                                    return this; // for chaining...
                                }
                            })(jQuery);

                            function showHideCheckBoxListInstitute(checkd, isPostBack, ischk) {
                                if (checkd)
                                { document.getElementById('checks_containerInstitute').style.display = 'none'; }
                                else
                                { document.getElementById('checks_containerInstitute').style.display = ''; }

                                if (isPostBack) {
                                    $('.hdnInstitute').val("");
                                    document.getElementById('sortableInstitute').innerHTML = '';
                                    var lent = document.getElementById('checks_containerInstitute').children.length;
                                    for (i = 0; i < lent; i++) {
                                        if (document.getElementById('checks_containerInstitute').children[i].children[0].checked) {
                                            if (document.getElementById('sortableInstitute').innerHTML.indexOf("Selected Institute") == -1)
                                            { document.getElementById('sortableInstitute').innerHTML += "<div><b>Selected Institute:</b> <i>(Drag to arrange Institute preference)</i></div>"; }
                                            var catName = document.getElementById('checks_containerInstitute').children[i].textContent || document.getElementById('checks_containerInstitute').children[i].innerText;
                                            var catCode = document.getElementById('checks_containerInstitute').children[i].children[0].value;
                                            document.getElementById('sortableInstitute').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";

                                            var catcodes = $('.hdnInstitute').val();

                                            $('.hdnInstitute').val($('.hdnInstitute').val() + catCode.toString() + ",");

                                        }
                                    }

                                    if (checkd && ischk) {
                                        document.getElementById('checks_containerInstitute').style.display = 'none';
                                        $('.hdnInstitute').val("");
                                        document.getElementById('sortableInstitute').innerHTML = '';
                                    }
                                }
                                else {
                                    var oldValue = $('.hdnInstitute').val();
                                    if (oldValue != "") {
                                        var catName;
                                        var catCode;
                                        document.getElementById('sortableInstitute').innerHTML = '';
                                        document.getElementById('sortableInstitute').innerHTML += "<div><b>Selected Institute:</b> <i>(Drag to arrange institute preference)</i></div>";

                                        oldValue = oldValue.slice(0, -1); // remove comma from end
                                        var arr = oldValue.split(',');
                                        $.each(arr, function(key, line) {
                                            //alert(key);
                                            var lent = document.getElementById('checks_containerInstitute').children.length;
                                            var idx = key + 1;
                                            catCode = line.replace(idx, '');
                                            for (i = 0; i < lent; i++) {
                                                if (catCode == document.getElementById('checks_containerInstitute').children[i].children[0].value) {
                                                    //alert(catCode + " - " + catName);
                                                    catName = document.getElementById('checks_containerInstitute').children[i].textContent || document.getElementById('checks_containerInstitute').children[i].innerText;
                                                    break;
                                                }
                                            }
                                            document.getElementById('sortableInstitute').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";
                                        });
                                    }
                                }
                            }                                                                    
                        </script>

                        <div class="check textbox">
                            <input type="checkbox" name="chkInstitute" id="chkInstitute" runat="server" value="-1"
                                checked="checked" onclick="showHideCheckBoxListInstitute(this.checked, true, true);" />Show
                            All</div>
                        <div id="checks_containerInstitute" style="display: none">
                            <div class="floatDiv">
                                <h5>
                                    <strong>Select Institute: </strong>
                                </h5>
                            </div>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListInstitute(true, true, false);$('#InstituteTab').goTo();"></div>
                            <asp:Repeater ID="rptInstitute" runat="server">
                                <ItemTemplate>
                                    <div class="check" style="width: 410px; float: left">
                                        <input type="checkbox" name="chkCategory" value='<%# Eval("Institute_Code")%>' />
                                        <%# Eval("Institute")%></div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListInstitute(true, true, false);$('#InstituteTab').goTo();"></div>
                        </div>
                    </td>
                    <td style="width: 15%" align="center">
                        Select Degree:
                    </td>
                    <td align="center" id="DegreeTab">

                        <script>
                            (function($) {
                                $.fn.goTo = function() {
                                    $('html, body').animate({
                                        scrollTop: $(this).offset().top + 'px'
                                    }, 'fast');
                                    return this; // for chaining...
                                }
                            })(jQuery);

                            function showHideCheckBoxListDegree(checkd, isPostBack, ischk) {
                                if (checkd)
                                { document.getElementById('checks_containerDegree').style.display = 'none'; }
                                else
                                { document.getElementById('checks_containerDegree').style.display = ''; }

                                if (isPostBack) {
                                    $('.hdnDegree').val("");
                                    document.getElementById('sortableDegree').innerHTML = '';
                                    var lent = document.getElementById('checks_containerDegree').children.length;
                                    for (i = 0; i < lent; i++) {
                                        if (document.getElementById('checks_containerDegree').children[i].children[0].checked) {
                                            if (document.getElementById('sortableDegree').innerHTML.indexOf("Selected Degree") == -1)
                                            { document.getElementById('sortableDegree').innerHTML += "<div><b>Selected Degree:</b> <i>(Drag to arrange Degree preference)</i></div>"; }
                                            var catName = document.getElementById('checks_containerDegree').children[i].textContent || document.getElementById('checks_containerDegree').children[i].innerText;
                                            var catCode = document.getElementById('checks_containerDegree').children[i].children[0].value;
                                            document.getElementById('sortableDegree').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";

                                            var catcodes = $('.hdnDegree').val();

                                            $('.hdnDegree').val($('.hdnDegree').val() + catCode.toString() + ",");
                                        }
                                    }

                                    if (checkd && ischk) {
                                        document.getElementById('checks_containerDegree').style.display = 'none';
                                        $('.hdnDegree').val("");
                                        document.getElementById('sortableDegree').innerHTML = '';
                                    }

                                }
                                else {
                                    var oldValue = $('.hdnDegree').val();
                                    if (oldValue != "") {
                                        var catName;
                                        var catCode;
                                        document.getElementById('sortableDegree').innerHTML = '';
                                        document.getElementById('sortableDegree').innerHTML += "<div><b>Selected Degree:</b> <i>(Drag to arrange Degree preference)</i></div>";

                                        oldValue = oldValue.slice(0, -1); // remove comma from end
                                        var arr = oldValue.split(',');
                                        $.each(arr, function(key, line) {
                                            //alert(key);
                                            var lent = document.getElementById('checks_containerDegree').children.length;
                                            var idx = key + 1;
                                            catCode = line.replace(idx, '');
                                            for (i = 0; i < lent; i++) {
                                                if (catCode == document.getElementById('checks_containerDegree').children[i].children[0].value) {
                                                    //alert(catCode + " - " + catName);
                                                    catName = document.getElementById('checks_containerDegree').children[i].textContent || document.getElementById('checks_containerDegree').children[i].innerText;
                                                    break;
                                                }
                                            }
                                            document.getElementById('sortableDegree').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";
                                        });
                                    }
                                }
                            }                                                                    
                        </script>

                        <div class="check textbox">
                            <input type="checkbox" name="chkDegree" id="chkDegree" runat="server" value="-1"
                                checked="checked" onclick="showHideCheckBoxListDegree(this.checked, true, true);" />Show
                            All</div>
                        <div id="checks_containerDegree" style="display: none">
                            <div class="floatDiv">
                                <h5>
                                    <strong>Select Degree: </strong>
                                </h5>
                            </div>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListDegree(true, true, false);$('#InstituteTab').goTo();"></div>
                            <asp:Repeater ID="rptDegree" runat="server">
                                <ItemTemplate>
                                    <div class="check" style="width: 410px; float: left">
                                        <input type="checkbox" name="chkCategory" value='<%# Eval("Degree_Code")%>' />
                                        <%# Eval("Degree")%></div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListDegree(true, true, false);$('#InstituteTab').goTo();"></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%" align="center">
                        Select Majors:
                    </td>
                    <td align="center" style="width: 365px" id="MajorTab">

                        <script>
                            (function($) {
                                $.fn.goTo = function() {
                                    $('html, body').animate({
                                        scrollTop: $(this).offset().top + 'px'
                                    }, 'fast');
                                    return this; // for chaining...
                                }
                            })(jQuery);

                            function showHideCheckBoxListMajor(checkd, isPostBack, ischk) {
                                if (checkd)
                                { document.getElementById('checks_containerMajor').style.display = 'none'; }
                                else
                                { document.getElementById('checks_containerMajor').style.display = ''; }

                                if (isPostBack) {
                                    $('.hdnMajor').val("");
                                    document.getElementById('sortableMajor').innerHTML = '';
                                    var lent = document.getElementById('checks_containerMajor').children.length;
                                    for (i = 0; i < lent; i++) {
                                        if (document.getElementById('checks_containerMajor').children[i].children[0].checked) {
                                            if (document.getElementById('sortableMajor').innerHTML.indexOf("Selected Major") == -1)
                                            { document.getElementById('sortableMajor').innerHTML += "<div><b>Selected Major:</b> <i>(Drag to arrange Major preference)</i></div>"; }
                                            var catName = document.getElementById('checks_containerMajor').children[i].textContent || document.getElementById('checks_containerMajor').children[i].innerText;
                                            var catCode = document.getElementById('checks_containerMajor').children[i].children[0].value;
                                            document.getElementById('sortableMajor').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";

                                            var catcodes = $('.hdnMajor').val();

                                            $('.hdnMajor').val($('.hdnMajor').val() + catCode.toString() + ",");
                                        }
                                    }

                                    if (checkd && ischk) {
                                        document.getElementById('checks_containerMajor').style.display = 'none';
                                        $('.hdnMajor').val("");
                                        document.getElementById('sortableMajor').innerHTML = '';
                                    }
                                }
                                else {
                                    var oldValue = $('.hdnMajor').val();
                                    if (oldValue != "") {
                                        var catName;
                                        var catCode;
                                        document.getElementById('sortableMajor').innerHTML = '';
                                        document.getElementById('sortableMajor').innerHTML += "<div><b>Selected Major:</b> <i>(Drag to arrange Major preference)</i></div>";

                                        oldValue = oldValue.slice(0, -1); // remove comma from end
                                        var arr = oldValue.split(',');
                                        $.each(arr, function(key, line) {
                                            //alert(key);
                                            var lent = document.getElementById('checks_containerMajor').children.length;
                                            var idx = key + 1;
                                            catCode = line.replace(idx, '');
                                            for (i = 0; i < lent; i++) {
                                                if (catCode == document.getElementById('checks_containerMajor').children[i].children[0].value) {
                                                    //alert(catCode + " - " + catName);
                                                    catName = document.getElementById('checks_containerMajor').children[i].textContent || document.getElementById('checks_containerMajor').children[i].innerText;
                                                    break;
                                                }
                                            }
                                            document.getElementById('sortableMajor').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";
                                        });
                                    }
                                }
                            }                                                                    
                        </script>

                        <div class="check textbox">
                            <input type="checkbox" name="chkMajor" id="chkMajor" runat="server" value="-1" checked="checked"
                                onclick="showHideCheckBoxListMajor(this.checked, true, true);" />Show All</div>
                        <div id="checks_containerMajor" style="display: none">
                            <div class="floatDiv">
                                <h5>
                                    <strong>Select Major: </strong>
                                </h5>
                            </div>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListMajor(true, true, false);$('#MajorTab').goTo();"></div>
                            <asp:Repeater ID="rptMajor" runat="server">
                                <ItemTemplate>
                                    <div class="check" style="width: 410px; float: left">
                                        <input type="checkbox" name="chkMajor" value='<%# Eval("Major_Code")%>' />
                                        <%# Eval("Major_Name")%></div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListMajor(true, true, false);$('#MajorTab').goTo();"></div>
                        </div>
                    </td>
                    <td style="width: 15%" align="center">
                        End Year:
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="80px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="font11">
                        <ul id="sortableInstitute">
                        </ul>
                    </td>
                    <td colspan="2" class="font11">
                        <ul id="sortableDegree">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="font11">
                        <ul id="sortableMajor">
                        </ul>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
            <br />
            <table width="60%" border="0" cellpadding="10" cellspacing="0" style="display: none">
                <tr>
                    <td colspan="8" align="center">
                        <strong>Education Filter</strong>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="width: 20%">
                        <strong>Matric/O-Level</strong>
                    </th>
                    <th colspan="2" style="width: 20%">
                        <strong>Inter/A-Level</strong>
                    </th>
                    <th colspan="2" style="width: 20%">
                        <strong>Graduate</strong>
                    </th>
                    <th colspan="2" style="width: 20%">
                        <strong>Master</strong>
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        %
                    </td>
                    <td align="center">
                        A's
                    </td>
                    <td align="center">
                        %
                    </td>
                    <td align="center">
                        A's
                    </td>
                    <td align="center">
                        %
                    </td>
                    <td align="center">
                        GPA's
                    </td>
                    <td align="center">
                        %
                    </td>
                    <td align="center">
                        GPA
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DropDownList ID="ddlPercMatric" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="90" Text="90+"></asp:ListItem>
                            <asp:ListItem Value="80" Text="80+"></asp:ListItem>
                            <asp:ListItem Value="70" Text="70+"></asp:ListItem>
                            <asp:ListItem Value="60" Text="60+"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50+"></asp:ListItem>
                            <asp:ListItem Value="49" Text="Below 50"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlAMatric" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                            <asp:ListItem Value="11" Text="11+"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10+"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9+"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8+"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7+"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6+"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5+"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4+"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3+"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2+"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1+"></asp:ListItem>
                            <asp:ListItem Value="0" Text="0+"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlPercInter" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="90" Text="90+"></asp:ListItem>
                            <asp:ListItem Value="80" Text="80+"></asp:ListItem>
                            <asp:ListItem Value="70" Text="70+"></asp:ListItem>
                            <asp:ListItem Value="60" Text="60+"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50+"></asp:ListItem>
                            <asp:ListItem Value="49" Text="Below 50"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlAInter" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                            <asp:ListItem Value="11" Text="11+"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10+"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9+"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8+"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7+"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6+"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5+"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4+"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3+"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2+"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1+"></asp:ListItem>
                            <asp:ListItem Value="0" Text="0+"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlPercGraduate" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="90" Text="90+"></asp:ListItem>
                            <asp:ListItem Value="80" Text="80+"></asp:ListItem>
                            <asp:ListItem Value="70" Text="70+"></asp:ListItem>
                            <asp:ListItem Value="60" Text="60+"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50+"></asp:ListItem>
                            <asp:ListItem Value="49" Text="Below 50"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlGPAGraduate" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4.0"></asp:ListItem>
                            <asp:ListItem Value="3.5" Text="3.5+"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3.0+"></asp:ListItem>
                            <asp:ListItem Value="2.5" Text="2.5+"></asp:ListItem>
                            <asp:ListItem Value="2" Text="less than 2.5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlPercMaster" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="90" Text="90+"></asp:ListItem>
                            <asp:ListItem Value="80" Text="80+"></asp:ListItem>
                            <asp:ListItem Value="70" Text="70+"></asp:ListItem>
                            <asp:ListItem Value="60" Text="60+"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50+"></asp:ListItem>
                            <asp:ListItem Value="49" Text="Below 50"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlGPAMaster" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="Select" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4.0"></asp:ListItem>
                            <asp:ListItem Value="3.5" Text="3.5+"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3.0+"></asp:ListItem>
                            <asp:ListItem Value="2.5" Text="2.5+"></asp:ListItem>
                            <asp:ListItem Value="2" Text="less than 2.5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div id="dvExperience" runat="server" class="dvExperience" style="display: none">
            <table width="60%" border="0" cellpadding="10" cellspacing="0">
                <tr>
                    <th colspan="4">
                        <strong>Experience </strong>
                    </th>
                </tr>
                <tr>
                    <td style="width: 15%" align="center">
                        Select Company:
                    </td>
                    <td align="center">

                        <script>
                            (function($) {
                                $.fn.goTo = function() {
                                    $('html, body').animate({
                                        scrollTop: $(this).offset().top + 'px'
                                    }, 'fast');
                                    return this; // for chaining...
                                }
                            })(jQuery);

                            function showHideCheckBoxListCompany(checkd, isPostBack, ischk) {
                                if (checkd)
                                { document.getElementById('checks_containerCompany').style.display = 'none'; }
                                else
                                { document.getElementById('checks_containerCompany').style.display = ''; }

                                if (isPostBack) {
                                    $('.hdnCompany').val("");
                                    document.getElementById('sortableCompany').innerHTML = '';
                                    var lent = document.getElementById('checks_containerCompany').children.length;
                                    for (i = 0; i < lent; i++) {
                                        if (document.getElementById('checks_containerCompany').children[i].children[0].checked) {
                                            if (document.getElementById('sortableCompany').innerHTML.indexOf("Selected Company") == -1)
                                            { document.getElementById('sortableCompany').innerHTML += "<div><b>Selected Company:</b> <i>(Drag to arrange Company preference)</i></div>"; }
                                            var catName = document.getElementById('checks_containerCompany').children[i].textContent || document.getElementById('checks_containerCompany').children[i].innerText;
                                            var catCode = document.getElementById('checks_containerCompany').children[i].children[0].value;
                                            document.getElementById('sortableCompany').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";

                                            var catcodes = $('.hdnCompany').val();

                                            $('.hdnCompany').val($('.hdnCompany').val() + catCode.toString() + ",");
                                        }
                                    }

                                    if (checkd && ischk) {
                                        document.getElementById('checks_containerCompany').style.display = 'none';
                                        $('.hdnCompany').val("");
                                        document.getElementById('sortableCompany').innerHTML = '';
                                    }

                                }
                                else {
                                    var oldValue = $('.hdnCompany').val();
                                    if (oldValue != "") {
                                        var catName;
                                        var catCode;
                                        document.getElementById('sortableCompany').innerHTML = '';
                                        document.getElementById('sortableCompany').innerHTML += "<div><b>Selected Company:</b> <i>(Drag to arrange Company preference)</i></div>";

                                        oldValue = oldValue.slice(0, -1); // remove comma from end
                                        var arr = oldValue.split(',');
                                        $.each(arr, function(key, line) {
                                            //alert(key);
                                            var lent = document.getElementById('checks_containerCompany').children.length;
                                            var idx = key + 1;
                                            catCode = line.replace(idx, '');
                                            for (i = 0; i < lent; i++) {
                                                if (catCode == document.getElementById('checks_containerCompany').children[i].children[0].value) {
                                                    //alert(catCode + " - " + catName);
                                                    catName = document.getElementById('checks_containerCompany').children[i].textContent || document.getElementById('checks_containerCompany').children[i].innerText;
                                                    break;
                                                }
                                            }
                                            document.getElementById('sortableCompany').innerHTML += "<li id='" + catCode + "' class='ui-state-default'><span class='ui-icon ui-icon-arrowthick-2-n-s'></span>" + catName + "</li>";
                                        });
                                    }
                                }
                            }                                                                    
                        </script>

                        <div class="check textbox">
                            <input type="checkbox" name="chkCompany" id="chkCompany" runat="server" value="-1"
                                checked="checked" onclick="showHideCheckBoxListCompany(this.checked, true, true);" />Show
                            All</div>
                        <div id="checks_containerCompany" style="display: none">
                            <div class="floatDiv">
                                <h5>
                                    <strong>Select Company: </strong>
                                </h5>
                            </div>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListCompany(true, true, false);$('#CompanyTab').goTo();"></div>
                            <asp:Repeater ID="rptCompany" runat="server">
                                <ItemTemplate>
                                    <div class="check" style="width: 410px; float: left">
                                        <input type="checkbox" name="chkCategory" value='<%# Eval("Company_Code")%>' />
                                        <%# Eval("Company")%></div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="check" style="float: right;">
                                <img src="/assets/images/close.png" alt="" onclick="showHideCheckBoxListCompany(true, true, false);$('#CompanyTab').goTo();"></div>
                        </div>
                    </td>
                    <td style="width: 15%" align="center">
                        Salary Range:
                    </td>
                    <td align="center">
                        Between &nbsp; &nbsp;
                        <asp:DropDownList ID="ddlSalaryFrom" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="--From--"></asp:ListItem>
                            <asp:ListItem Value="0" Text="0"></asp:ListItem>
                            <asp:ListItem Value="10000" Text="10,000"></asp:ListItem>
                            <asp:ListItem Value="25000" Text="25,000"></asp:ListItem>
                            <asp:ListItem Value="50000" Text="50,000"></asp:ListItem>
                            <asp:ListItem Value="75000" Text="75,000"></asp:ListItem>
                            <asp:ListItem Value="100000" Text="100,000"></asp:ListItem>
                            <asp:ListItem Value="200000" Text="200,000"></asp:ListItem>
                            <asp:ListItem Value="300000 " Text="300,000"></asp:ListItem>
                            <asp:ListItem Value="10000" Text="10,000"></asp:ListItem>
                            <asp:ListItem Value="25000" Text="25,000"></asp:ListItem>
                            <asp:ListItem Value="50000" Text="50,000"></asp:ListItem>
                            <asp:ListItem Value="75000" Text="75,000"></asp:ListItem>
                            <asp:ListItem Value="100000" Text="100,000"></asp:ListItem>
                            <asp:ListItem Value="200000" Text="200,000"></asp:ListItem>
                            <asp:ListItem Value="300000" Text="300,000"></asp:ListItem>
                            <asp:ListItem Value="500000" Text="500,000"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp; AND &nbsp; &nbsp;
                        <asp:DropDownList ID="ddlSalaryTo" runat="server" Width="80px">
                            <asp:ListItem Value="" Text="--To--"></asp:ListItem>
                            <asp:ListItem Value="10000" Text="10,000"></asp:ListItem>
                            <asp:ListItem Value="25000" Text="25,000"></asp:ListItem>
                            <asp:ListItem Value="50000" Text="50,000"></asp:ListItem>
                            <asp:ListItem Value="75000" Text="75,000"></asp:ListItem>
                            <asp:ListItem Value="100000" Text="100,000"></asp:ListItem>
                            <asp:ListItem Value="200000" Text="200,000"></asp:ListItem>
                            <asp:ListItem Value="300000" Text="300,000"></asp:ListItem>
                            <asp:ListItem Value="500000" Text="500,000"></asp:ListItem>
                            <asp:ListItem Value="100000000" Text="100,000000"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%" align="center">
                        Select Designation:
                    </td>
                    <td align="center">
                        <asp:TextBox runat="server" ID="txtDesignation" Width="280px"></asp:TextBox>
                    </td>
                    <td style="width: 15%" align="center">
                        No. oF years
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlNoOfYear" runat="server" Width="100px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%" align="center">
                        Responsibilities:
                    </td>
                    <td align="center">
                        <asp:TextBox runat="server" ID="txtResponsibilities" Width="280px"></asp:TextBox>
                    </td>
                    <td style="width: 15%" align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="font11">
                        <ul id="sortableCompany">
                        </ul>
                    </td>
                    <td colspan="2" class="font11">
                        <ul id="Ul2">
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="text-align: center">
                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                        ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                    </asp:LinkButton>&nbsp;
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                        DisplayAfter="0">
                        <ProgressTemplate>
                            <img src="/assets/images/Loading-Text-Animation.gif" alt="" align="middle" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <br />
                <table width="80%" border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="7">
                                <table border="0" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <th style="background-color: #999999;" height="25" align="center">
                                            <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                                ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                            &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                                Font-color="white" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                                Visible="False">&lt;&lt;</asp:LinkButton>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex"
                                                    runat="server" Text="Label" Visible="False" ForeColor="White"></asp:Label>&nbsp;
                                            &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                                                ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                            &nbsp;<asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                                                ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False">&gt;</asp:LinkButton>
                                        </th>
                                    </tr>
                                </table>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptCandidateLists" runat="server" OnItemDataBound="rptCandidateLists_ItemDataBound">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th align="center" style="width: 5%">
                                        S.No.
                                    </th>
                                    <th align="center" style="width: 5%">
                                        Reference No.
                                    </th>
                                    <th align="center" style="width: 15%">
                                        Full Name
                                    </th>
                                    <th align="center" style="width: 15%">
                                        Education
                                    </th>
                                    <th align="center" style="width: 15%">
                                        Experience
                                    </th>
                                    <th align="center" style="width: 13%">
                                        Email/Phone
                                    </th>
                                    <th align="center" style="width: 7%;">
                                        Apply Date
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center;">
                                        <a id="aCandidateLink" runat="server" target="_blank">
                                            <%# Eval("Candidate_ID")%>
                                        </a>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                        <%# Eval("PersonalDetail")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Qualification")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Experience")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("ContactInfo")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Created_Date")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center;">
                                        <a id="aCandidateLink" runat="server" target="_blank">
                                            <%# Eval("Candidate_ID")%>
                                        </a>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                        <%# Eval("PersonalDetail")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Qualification")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Experience")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("ContactInfo")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Created_Date")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div style="text-align: center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkSearch" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <input type="hidden" id="hdnCategory" class="hdnCategory" runat="server" name="hdnCategory"/>
    <input type="hidden" id="hdnInstitute" class="hdnInstitute" runat="server" name="hdnInstitute"/>
    <input type="hidden" id="hdnDegree" class="hdnDegree" runat="server" name="hdnDegree"/>
    <input type="hidden" id="hdnMajor" class="hdnMajor" runat="server" name="hdnMajor"/>
    <input type="hidden" id="hdnCompany" class="hdnCompany" runat="server" name="hdnCompany"/>
    <input type="hidden" id="hdnFilterType" class="hdnFilterType" runat="server" value="1"
        name="hdnFilterType"/>
</asp:Content>
