<%@ Page Title="Experience" Language="C#" MasterPageFile="~/ProfileMaster.master"
    AutoEventWireup="true" CodeFile="experience.aspx.cs" Inherits="profile_experience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>

    <!--#include virtual="/Area/includes/scripts.html" -->
    <style type="text/css">
        .chkBoxList tr
        {
            height: 24px;
        }
        .chkBoxList td
        {
            width: 120px; /* or percent value: 25% */
        }
        .chkBoxList label
        {
            width: 60px;
        }
    </style>

    <script type="text/javascript">

        function validateForm() {
            var IsCompanyName = false, ISCompanyNumber = false, isJobTitle = false, isfromMonth = false;
            var isfromYear = false, istoMonth = false, istoYear = false, isCurrentSalary = false;
            var isInitialSalary = false, isLocation = false, CorrectDate = true, InProgress = false, IsEmail = false, IsWebsite = false;

            if ($('.email').val().trim() == "N/A" || $('.email').val().trim() == "Not available" || $('.email').val().trim() == "U/C" || $('.email').val() == "") {
                $('.email').removeClass('error');
                IsEmail = true;
            }
            else {
                if ($('.email').val().trim() != "") {
                    var emailRegex = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
                    if (emailRegex.test($('.email').val().trim())) {
                        $('.email').removeClass('error');
                        IsEmail = true;
                    }
                    else {
                        $('.email').addClass('error');
                        IsEmail = false;
                    }
                }
            }


            if ($('.website').val().trim() == "N/A" || $('.website').val().trim() == "Not available" || $('.website').val().trim() == "U/C" || $('.website').val() == "") {
                $('.website').removeClass('error');
                IsWebsite = true;
            }
            else {
                if ($('.website').val().trim() != "") {
                    var websiteRegex = new RegExp(/(https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,})/i);
                    if (websiteRegex.test($('.website').val().trim())) {
                        $('.website').removeClass('error');
                        IsWebsite = true;
                    }
                    else {
                        $('.website').addClass('error');
                        IsWebsite = false;
                    }
                }
            }


            if ($('#ddlFromMonth').val() == "")
                $('#ddlFromMonth').addClass('error');
            else {
                $('#ddlFromMonth').removeClass('error');
                isfromMonth = true;
            }
            if ($('#ddlFromYear').val() == "")
                $('#ddlFromYear').addClass('error');
            else {
                $('#ddlFromYear').removeClass('error');
                isfromYear = true;
            }
            if ($('.ToMonth').val() == "")
                $('.ToMonth').addClass('error');
            else {
                $('.ToMonth').removeClass('error');
                istoMonth = true;
            }
            if ($('.ToYear').val() == "")
                $('.ToYear').addClass('error');
            else {
                $('.ToYear').removeClass('error');
                istoYear = true;
            }
            if ($('#chkPresent').is(':checked')) {
                $('.ToMonth').removeClass('error');
                $('.ToYear').removeClass('error');
                istoYear = true; InProgress = true; istoMonth = true;
            }

            var currDate = new Date(), currentYear = (new Date).getFullYear();

            if (isfromMonth & isfromYear & istoMonth & istoYear & !InProgress) {

                var fromDate = (new Date).getFullYear();
                var toDate = (new Date).getFullYear();
                fromDate = '1/' + $('#ddlFromMonth').val() + '/' + $('#ddlFromYear').val();
                toDate = '1/' + $('#ddlToMonth').val() + '/' + $('#ddlToYear').val();
                currDate = '1/' + parseInt(currDate.getMonth() + 1) + '/' + currentYear;
                if ((new Date(fromDate) > new Date(toDate)) || (new Date(toDate) > new Date(currDate))
                || (new Date(fromDate) > new Date(currDate))) {
                    $('#ddlFromMonth').addClass('error');
                    $('#ddlFromYear').addClass('error');
                    $('#ddlToMonth').addClass('error');
                    $('#ddlToYear').addClass('error');

                    istoMonth = false; istoYear = false; isfromMonth = false; isfromYear = false;
                    CorrectDate = false;
                }
            }
            if ($.trim($('#txtCompany').val()) == "")
                $('#txtCompany').addClass('error');
            else {
                $('#txtCompany').removeClass('error');
                IsCompanyName = true;
            }
            if ($.trim($('#txtNumber').val()) == "" && $('#hfCompany').val() == "0")
                $('#txtNumber').addClass('error');
            else {
                $('#txtNumber').removeClass('error');
                ISCompanyNumber = true;
            }
            if ($.trim($('#txtTitle').val()) == "")
                $('#txtTitle').addClass('error');
            else {
                $('#txtTitle').removeClass('error');
                isJobTitle = true;
            }
            if ($.trim($('#txtInitialSalary').val()) == "")
                $('#txtInitialSalary').addClass('error');
            else {
                $('#txtInitialSalary').removeClass('error');
                isInitialSalary = true;
            }
            if ($.trim($('#txtCurrentSalary').val()) == "")
                $('#txtCurrentSalary').addClass('error');
            else {
                $('#txtCurrentSalary').removeClass('error');
                isCurrentSalary = true;
            }
            if ($.trim($('#txtLocation').val()) == "")
                $('#txtLocation').addClass('error');
            else {
                $('#txtLocation').removeClass('error');
                isLocation = true;
            }
            if (IsCompanyName & ISCompanyNumber & isJobTitle & isCurrentSalary & isInitialSalary & isLocation & isfromMonth & isfromYear & istoMonth & istoYear & IsEmail & IsWebsite) {
                $(".errormsg").text("");
                return true;
            }
            else {
                if (!isfromMonth & !isfromYear & !istoMonth & !istoYear) {
                    if (!CorrectDate) {
                        $(".errormsg").text("To date should be greater than from date and less then current Date");
                        return false;
                    }
                    else {
                        $(".errormsg").text("Please provide complete information");

                        return false;
                    }
                }
                else {
                    $(".errormsg").text("Please provide complete information");

                    return false;
                }
            }
        }
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.respon').keyup(function () {
                var limit = 1000;
                var text = $(this).val();
                var chars = text.length;
                if (chars > limit) {
                    var new_text = text.substr(0, limit);
                    $(this).val(new_text);
                }
            });
        });

        function ValidatePlaceHolder(obj) {

            var value = $('#' + obj.id).val(); // value = 9.61 use $("#text").text() if you are not on select box...

            value = value.replace("R", "");
            value = value.replace("s", "");
            value = value.replace(".", "");
            value = value.replace(" ", "");

            $('#' + obj.id).val(value);
            var num = $('#' + obj.id);


            if (num.val().indexOf("Rs.") > -1)
                $('#' + obj.id).val(test1);
            else
                $('#' + obj.id).val('Rs. ' + $('#' + obj.id).val());
        }




        //        function isNumberKey(evt) {
        //            var charCode = (evt.which) ? evt.which : event.keyCode
        //            if (charCode > 31 && (charCode < 48 || charCode > 57))
        //                return false;

        //            return true;

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


        function confirmPost() {
            var agree = confirm("Are you sure you want to delete?");
            if (agree)
                return true;
            else
                return false;
        }

        function ResetCompany() {
            if (event.keyCode != 13)
                $('#hfCompany').val("0");
        }
        function ResetLocation() {
            if (event.keyCode != 13)
                $('#hfLocation').val("0");
        }

        function ResetJobTitle() {
            if (event.keyCode != 13)
                $('#hfJobTitle').val("0");
        }
        function validateExperience() {

            if (document.getElementById("ContentContainer_profeExpList").style.display == 'none' && document.getElementById("rbtnIsExperience_0").checked == true) {

                if ($('.company').val() == "") {
                    $(".errormsg").text("Please provide atleast one experience");
                    return false;
                }
                else {
                    return validateForm();
                }
            }
            else {
                if (document.getElementById("ContentContainer_profeExpList").style.display != 'none') {
                    if ($('.company').val() == "") {
                        return true;
                    }
                    else {
                        return validateForm();
                    }
                }
                else
                    return true;
            }
        }


        function ShowHideExperience(obj) {
            if (document.getElementById("rbtnIsExperience_0").checked == true) {
                $('#profeExp').removeClass('hidden');
                $('#divSavebtn').removeClass('row-fluid hidden');
                $('#divSavebtn').addClass('row-fluid');
            }
            else {
                $('#profeExp').addClass('hidden');
                $('#divSavebtn').addClass('row-fluid hidden');
            }
        }
        function ShowHideDateTo() {

            if (document.getElementById('chkPresent').checked) {

                $("#ContentContainer_divtoYear").addClass('span2 xSetDisableExp hidden');
                $("#ContentContainer_divtomonth").addClass('span2 xSetDisableExp hidden');
                // $("#ContentContainer_divTo").addClass('span4 hidden');
                document.getElementById('ContentContainer_divPresent').style.display = '';
                document.getElementById('ContentContainer_divtoYear').style.display = 'none';
                document.getElementById('ContentContainer_divtomonth').style.display = 'none';
                // document.getElementById('ContentContainer_divTo').style.display = 'none';
                $("#ContentContainer_divPresent").removeClass('span2 xSetDisableExp');
                $("#ContentContainer_divPresent").addClass('span2');

            }
            else {

                document.getElementById('ContentContainer_divtoYear').style.display = '';
                document.getElementById('ContentContainer_divtomonth').style.display = '';
                $("#ContentContainer_divtoYear").removeClass('span2 xSetDisableExp hidden');
                $("#ContentContainer_divtomonth").removeClass('span2 xSetDisableExp hidden');
                $("#ContentContainer_divtoYear").addClass('span2 xSetDisableExp');
                $("#ContentContainer_divtomonth").addClass('span2 xSetDisableExp');
                // $("#ContentContainer_divPresent").removeClass('span2');
                // $("#ContentContainer_divPresent").addClass('span2 xSetDisableExp');
                document.getElementById('ContentContainer_divPresent').style.display = 'none';
            }
        }
    </script>

    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
        .radiobuttonlist
        {
            font: 12px Verdana, sans-serif;
        }
        .radiobuttonlist input
        {
            width: 30px;
            height: 30px;
            padding-right: 15px;
        }
        .radiobuttonlist label
        {
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="xboxRight">
        <!--Referrer Model-->
        <a href="#xLinkedInImport" title="" data-toggle="modal" id="CallxLinkedInImport"
            runat="server"></a>
        <div id="xLinkedInImport" class="modal hide theModals" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3>
                    Your profile has been imported from LinkedIn</h3>
            </div>
            <div class="modal-body">
                <div class="row-fluid">
                    <div class="span12">
                        <p>
                            Your LinkedIn profile has been imported successfully; however, you are required
                            to provide some additional information to complete your application.
                        </p>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <button data-dismiss="modal" data-toggle="modal" class="xBook-button-normal" data-original-title=""
                            title="">
                            Complete Profile</button>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
            </div>
        </div>
        <!--ENd Model-->
        <img src="/Area/assets/img/banners/professional.png" alt="" />
        <div class="suggestmore timeline" id="profeExpList" runat="server">
            <div class="LoadingImage">
                <img src="/Area/assets/img/ajax-loader.gif" alt="" />
            </div>
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="listView_itemCommand"
                OnItemEditing="ListView1_ItemEditing" OnItemDeleting="ListView1_ItemDeleting"
                OnItemDataBound="listView_ItemDataBound">
                <LayoutTemplate>
                    <ul class="jcarousel-list jcarousel-list-horizontal" style="overflow: hidden; position: relative;
                        top: 0px; margin: 0px; padding: 0px; left: -1128.5377831952721px; width: 1892px;">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li runat="server" id="li" style="margin-left: 10px; float: left; list-style: none;"
                        class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal"
                        jcarouselindex="1">
                        <div class="fadeit" id="DivFade" runat="server">
                        </div>
                        <%-- <a href="javascript:;"   class="editicon loadExp" title="123" runat="server"></a>--%>
                        <asp:LinkButton ID="lnkEdit" CssClass="editicon loadExp" runat="server" CommandArgument='<%#Eval("CandidateExperience_Code") %>'
                            CommandName="Edit"></asp:LinkButton>
                        <%--  <a href="#xRemoveDetails" title="" data-toggle="modal" class="closeicon"></a>  --%>
                        <asp:HiddenField runat="server" ID="hdnISComplete" Value='<%#Eval("isComplete") %>' />
                        <a href="#xRemoveDetails<%#Eval("CandidateExperience_Code") %>" title="" data-toggle="modal"
                            class="closeicon"></a>
                        <img src='<%#Eval("LogoPath") %>' height="50px" width="50px" alt="" onerror="this.src='/Area/assets/img/noImage.jpg';" />
                        <%#Eval("Name") %><br>
                        <%#Eval("Position") %>
                        <br>
                        <%#Eval("Duration") %>
                        <span class="vtip"></span>
                        <asp:HiddenField ID="hfExperienceCode" runat="server" Value=' <%#Eval("CandidateExperience_Code") %>' />
                        <div id="xRemoveDetails<%#Eval("CandidateExperience_Code") %>" class="modal hide theModals"
                            tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h3>
                                    Remove Experience</h3>
                            </div>
                            <div class="modal-body">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <p>
                                            Do you wish to remove
                                            <%#Eval("fullname")%>
                                            ?
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="row-fluid">
                                    <div class="span6">
                                    </div>
                                    <div class="span6">
                                        <asp:Button class="xBook-button-normal" ID="lnkDelete" runat="server" CommandArgument='<%#Eval("CandidateExperience_Code") %>'
                                            CommandName="Delete" OnClientClick="javascript:return true;" Text="Remove"></asp:Button>
                                        <button data-dismiss="modal" data-toggle="modal" class="xBook-button-back" data-original-title=""
                                            title="">
                                            Cancel</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End Modal -->
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>
                        Nothing here.</p>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:HiddenField ID="hfExperienceCode" runat="server" Value='<%#Eval("CandidateExperience_Code") %>' />
        </div>
        <div class="xBoxInner">
            <div class="row-fluid" id="profeExpCheck" runat="server">
                <div class="span12">
                    <h6>
                        Please provide us details of your professional experiences</h6>
                    <div class="row-fluid">
                        <div class="span5">
                            Do you have professional experience?
                        </div>
                        <div class="span7">
                            <asp:RadioButtonList ID="rbtnIsExperience" runat="server" CssClass="radiobuttonlist"
                                RepeatDirection="Horizontal" ClientIDMode="Static" RepeatLayout="Flow" onclick="javascript:return ShowHideExperience(this.value);">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hidden" id="profeExp" runat="server" clientidmode="Static">
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            <span>Company Details</span><span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                data-original-title="Basic details of the company you worked at, including company name, website and contact details.">(?)</span></h4>
                        <div class="xBoxInner">
                            <div class="row-fluid">
                                <div class="span4">
                                    Company Name</div>
                                <div class="span8">
                                    <div class="ui-widget">
                                        <asp:TextBox ID="txtCompany" runat="server" CssClass="jqtranformdone company" ValidationGroup="Check"
                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetCompany();"
                                            MaxLength="100" ClientIDMode="Static"></asp:TextBox>
                                        <asp:HiddenField ID="hfCompany" runat="server" ClientIDMode="Static" />
                                    </div>

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
                                                                    itemid: item.Code,
                                                                    itemEmail: item.Email,
                                                                    itemWebsite: item.Website,
                                                                    itemNumber: item.Number
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
                                                    $('#txtWebsite').val(ui.item.itemWebsite);
                                                    $('#txtEmail').val(ui.item.itemEmail);
                                                    $('#txtNumber').val(ui.item.itemNumber);
                                                },
                                                change: function (event, ui) {
                                                    if (ui.item == null) {
                                                        $('#hfCompany').val("0");
                                                    }
                                                }
                                            });

                                        });
                                    </script>

                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Company Website</div>
                                <div class="span8">
                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="jqtranformdone website" ValidationGroup="Check"
                                        MaxLength="100" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Company Email</div>
                                <div class="span8">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="jqtranformdone email" ValidationGroup="Check"
                                        MaxLength="100" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Company Number</div>
                                <div class="span8">
                                    <asp:TextBox ID="txtNumber" runat="server" CssClass="jqtranformdone" ValidationGroup="Check"
                                        MaxLength="15" ClientIDMode="Static" onkeydown="return isNumberKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Company City/Country</div>
                                <div class="span8">

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
                                                                    itemid: item.Code,
                                                                    itemtype: item.type
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
                                                    $('#hfLocationType').val(ui.item.itemtype);
                                                },
                                                change: function (event, ui) {
                                                    if (ui.item == null) {
                                                        $('#hfLocation').val("0");
                                                        $('#hfLocationType').val("0")
                                                    }
                                                }
                                            });

                                        });
                                    </script>

                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="jqtranformdone" ValidationGroup="Check"
                                        onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetLocation();"
                                        MaxLength="100" ClientIDMode="Static"></asp:TextBox>
                                    <asp:HiddenField ID="hfLocation" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="hfLocationType" runat="server" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            <span>Job Details</span></h4>
                        <div class="xBoxInner">
                            <div class="row-fluid">
                                <div class="span4">
                                    Job Title</div>
                                <div class="span8">

                                    <script type="text/javascript">
                                        $(function () {
                                            $("#txtTitle").autocomplete({
                                                source: function (request, response) {
                                                    $.ajax({
                                                        url: "../AutoComplete.asmx/FetchJobTitle",
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
                                                    $('#hfJobTitle').val(ui.item.itemid);
                                                },
                                                change: function (event, ui) {
                                                    if (ui.item == null) {
                                                        $('#hfJobTitle').val("0");
                                                    }
                                                }
                                            });

                                        });
                                    </script>

                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="jqtranformdone" ValidationGroup="Check"
                                        onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetJobTitle();"
                                        MaxLength="100" ClientIDMode="Static"></asp:TextBox>
                                    <asp:HiddenField ID="hfJobTitle" runat="server" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span8 pull-right">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radiobuttonlist"
                                        RepeatDirection="Horizontal" ClientIDMode="Static" RepeatLayout="Flow">
                                        <asp:ListItem Value="1" Text="Permanent Position" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Internship"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Responsibilities &nbsp;<span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="Responsibilities should provide details of your job position, so while viewing your profile we can get a quick idea of what the position involves">(?)</span></div>
                                <div class="span8">
                                    <asp:TextBox ID="txtResponsibilities" runat="server" TextMode="MultiLine" 
                                        CssClass="jqtransformdone respon" MaxLength="1000" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                             <div class="row-fluid">
                                <div class="span4">
                                    Reson For Leaving &nbsp;<span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="Reson For Leaving">(?)</span></div>
                                <div class="span8">
                                    <asp:TextBox ID="txtReasonForLeaving" runat="server" TextMode="MultiLine" 
                                        CssClass="jqtransformdone respon" MaxLength="1000" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Duration</div>
                                <div class="span2">
                                    From
                                </div>
                                <div class="span2">
                                </div>
                                <div id="divTo" class="span4" runat="server">
                                    <label id="lblTo" type="label" runat="server">
                                        To</label>
                                </div>
                            </div>
                            <div class="row-fluid xCurrentWork">
                                <div class="span2 offset4">
                                    <asp:DropDownList ID="ddlFromMonth" runat="server" Width="80px" Height="26px" ClientIDMode="Static"
                                        class="FromMonth">
                                        <asp:ListItem Selected="True" Value="" Text=" Month "></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="1" Text="Jan"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="2" Text="Feb"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="3" Text="Mar"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="4" Text="Apr"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="5" Text="May"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="6" Text="Jun"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="7" Text="Jul"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="8" Text="Aug"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="9" Text="Sep"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="10" Text="Oct"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="11" Text="Nov"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="12" Text="Dec"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="span2">
                                    <asp:DropDownList ID="ddlFromYear" runat="server" Width="80px" Height="26px" ClientIDMode="Static"
                                        class="FromYear">
                                    </asp:DropDownList>
                                </div>
                                <div id="divtomonth" class="span2 xSetDisableExp" runat="server">
                                    <asp:DropDownList ID="ddlToMonth" runat="server" Width="80px" Height="26px" ClientIDMode="Static"
                                        class="ToMonth">
                                        <asp:ListItem Selected="True" Value="" Text=" Month "></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="1" Text="Jan"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="2" Text="Feb"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="3" Text="Mar"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="4" Text="Apr"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="5" Text="May"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="6" Text="Jun"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="7" Text="Jul"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="8" Text="Aug"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="9" Text="Sep"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="10" Text="Oct"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="11" Text="Nov"></asp:ListItem>
                                        <asp:ListItem Selected="False" Value="12" Text="Dec"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="divtoYear" class="span2 xSetDisableExp" runat="server">
                                    <asp:DropDownList ID="ddlToYear" runat="server" Width="80px" Height="26px" ClientIDMode="Static"
                                        class="ToYear">
                                    </asp:DropDownList>
                                </div>
                                <div id="divPresent" runat="server" class="span2 xSetDisableExp" style="color: #666;
                                    display: none;">
                                    Present</div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4  offset8 " style="margin-top: -07px;">
                                    <%--  <input id="chkStudy" runat="server" type="checkbox" class="xCheckEduCurrent" />
                                    <label for="chkStudy">
                                        In progress</label>--%>
                                    <asp:CheckBox ID="chkPresent" runat="server" type="checkbox" class="xCheckExpCurrent"
                                        ClientIDMode="Static" Text="Currently working here" OnClick="javascript:;ShowHideDateTo()" />
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Current Salary</div>
                                <div class="span4 marksal">
                                    <asp:TextBox ID="txtCurrentSalary" runat="server" Style="width: 94%;" ClientIDMode="Static"
                                        CssClass="jqtranformdone" ValidationGroup="Check" onkeydown="return isNumberKey(event);"
                                        MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Initial Salary</div>
                                <div class="span4 marksal">
                                    <asp:TextBox ID="txtInitialSalary" runat="server" Style="width: 94%;" ClientIDMode="Static"
                                        CssClass="jqtranformdone" ValidationGroup="Check" onkeydown="return isNumberKey(event);"
                                        MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <asp:Repeater ID="rptBenefitTypes" runat="server" OnItemDataBound="rptBenefitTypes_OnItemDataBound">
                                    <HeaderTemplate>
                                        <table id="tblRptr" width="100%" cellpadding="0" cellspacing="0" border="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="span4">
                                                <%# DataBinder.Eval(Container.DataItem, "Benefit_Type")%><br />
                                            </td>
                                            <td align="left" style="width: 60%; padding-bottom: 10px" class="span2 ">
                                                <asp:CheckBoxList ID="rptBenefit" CssClass="chkBoxList" runat="server" RepeatDirection="Horizontal"
                                                    RepeatLayout="Flow" CellPadding="30">
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="xboxFooter">
            <div class="row-fluid  hidden" id="divSavebtn" runat="server" clientidmode="Static">
                <div class="span8">
                    <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                </div>
                <div class="span4">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-small
    pull-right" Text="Save &amp; Add more" OnClientClick="javascript:return validateForm();" />
                    <input type="button" clientidmode="Static" style="display: none" id="btnVDate" runat="server"
                        onclick="return validateForm();" />
                </div>
            </div>
        </div>
    </div>
    <div class="xboxRight">
        <div class="xBoxInner">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button ID="Button1" runat="server" class="xBook-button-normal
    button pull-right" Text="Save &amp; Continue" OnClientClick="javascript:return validateExperience();"
                        OnClick="btn_Continue" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

