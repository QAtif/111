<%@ Page Title="Certification" Language="C#" MasterPageFile="~/ProfileMaster.master"
    AutoEventWireup="true" CodeFile="certificate.aspx.cs" Inherits="profile_certificate" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <!--#include virtual="/Area/includes/scripts.html" -->
    <script type="text/javascript">

        function ResetInstitute() {
            if ((event.keyCode != 13))
                $('#ContentContainer_hfInstitute').val("0");
        }
        function ResetCertificate() {
            if ((event.keyCode != 13))
                $('#ContentContainer_hfCertificate').val("0");
        }
        function ResetField() {
            if ((event.keyCode != 13))
                $('#ContentContainer_hfField').val("0");
        }

        function ShowHideCertificate(value) {
            if (value == 1) {
                $('#ContentContainer_profeCer').removeClass('hidden');
                $('#ContentContainer_footerCer').removeClass('hidden');
            }
            else {
                $('#ContentContainer_profeCer').addClass('hidden');
                $('#ContentContainer_footerCer').addClass('hidden');
            }
        }
    </script>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
    <script type="text/javascript">
        function ShowHideDateTo() {
            if (document.getElementById('chkEducationStatus').checked) {
                $('#ddlToYear').attr('disabled', '');
                $('#ddlToMonth').attr('disabled', '');
                $('#ContentContainer_PaperCount').removeClass('hidden');
            }
            else {
                $('#ContentContainer_PaperCount').addClass('hidden');
                $('#ddlToYear').removeAttr('disabled');
                $('#ddlToMonth').removeAttr('disabled');
            }
        }

        function hascertificate() {

            if ($("#ContentContainer_profeCerList").is(':visible')) {
                if ($('.institute').val() == "")
                    return true;
                else {
                    return validateForm();
                }
            }
            else {
                if ($("#ContentContainer_profeCer").is(':visible')) {
                    if ($('.institute').val() == "") {
                        $(".errormsg").text("Atleast one certificate is required");
                        return false;
                    }
                    else {
                        return validateForm();
                    }
                }
                else
                    return true;
            }
            /*
            if ($("#ContentContainer_profeCerList").is(':visible')) {
            return true;
            }
            else {
            $(".errormsg").text("Atleast one certificate is required");
            return false;
            }
            */

        }
        //        function hascertificate() {
        //            if ($("#profeCerList").is(':visible'))
        //                return true;
        //            else {
        //                if ($("#ContentContainer_profeCer").is(':visible')) {
        //                    $(".errormsg").text("Atleast one certificate is required");
        //                    return false;
        //                }
        //                else
        //                    return true;
        //            }
        //        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function validateForm() {
            var isTotalpapers = false, isClearedpapers = false, isInstitute = false, isCertificateTitle = false;
            var isfield = false, isfromMonth = false, isfromYear = false, istoMonth = false, istoYear = false;
            var CorrectDate = true, InProgress = false;

            if ($('.FromMonth').val() == "")
                $('.FromMonth').addClass('error');
            else {
                $('.FromMonth').removeClass('error');
                isfromMonth = true;
            }
            if ($('.FromYear').val() == "")
                $('.FromYear').addClass('error');
            else {
                $('.FromYear').removeClass('error');
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
            if ($('#chkEducationStatus').is(':checked')) {
                $('.ToMonth').removeClass('error');
                $('.ToYear').removeClass('error');
                istoYear = true; InProgress = true; istoMonth = true;
            }
            var currDate = new Date(), currentYear = (new Date).getFullYear();

            if (isfromMonth & isfromYear & istoMonth & istoYear & !InProgress) {
                var fromDate = (new Date).getFullYear();
                var toDate = (new Date).getFullYear();
                fromDate = '1/' + $('.FromMonth').val() + '/' + $('.FromYear').val();
                toDate = '1/' + $('.ToMonth').val() + '/' + $('.ToYear').val();
                currDate = '1/' + parseInt(currDate.getMonth() + 1) + '/' + currentYear;
                if ((new Date(fromDate) > new Date(toDate)) || (new Date(toDate) > new Date(currDate))
                || (new Date(fromDate) > new Date(currDate))) {
                    $('.FromMonth').addClass('error');
                    $('.FromYear').addClass('error');
                    $('.ToMonth').addClass('error');
                    $('.ToYear').addClass('error');

                    istoMonth = false; istoYear = false; isfromMonth = false; isfromYear = false;
                    CorrectDate = false;
                }
            }
            if ($('#ContentContainer_PaperCount').is(':visible')) {
                if ($('.totalpapers').val() == "")
                    $('.totalpapers').addClass('error');
                else {
                    $('.totalpapers').removeClass('error');
                    isTotalpapers = true;
                }

                if ($('.clearedpapers').val() == "")
                    $('.clearedpapers').addClass('error');
                else {
                    $('.clearedpapers').removeClass('error');
                    isClearedpapers = true;
                }
            } else {
                $('.clearedpapers').removeClass('error');
                $('.totalpapers').removeClass('error');
                isTotalpapers = true; isClearedpapers = true;
            }
            if ($('.institute').val() == "")
                $('.institute').addClass('error');
            else {
                $('.institute').removeClass('error');
                isInstitute = true;
            }
            if ($('.CertificateTitle').val() == "")
                $('.CertificateTitle').addClass('error');
            else {
                $('.CertificateTitle').removeClass('error');
                isCertificateTitle = true;
            }
            if ($('.Field').val() == "")
                $('.Field').addClass('error');
            else {
                $('.Field').removeClass('error');
                isfield = true;
            }
            if (isTotalpapers & isClearedpapers & isInstitute & isCertificateTitle & isfield & isfromMonth & isfromYear & istoMonth & istoYear) {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="xboxRight">
        <img src="/Area/assets/img/banners/certification.jpg" alt="" />
        <div class="suggestmore timeline" id="profeCerList"  runat="server">
            <div class="LoadingImage">
                <img src="/Area/assets/img/ajax-loader.gif" alt="" />
            </div>
            <asp:ListView ID="lvCertificate" runat="server" OnItemCommand="lvCertificate_OnItemCommand"
                OnItemEditing="lvCertificate_ItemEditing" OnItemDeleting="lvCertificate_OnItemDeleting"
                OnItemDataBound="lvCertificate_OnDataBound">
                <LayoutTemplate>
                    <ul class="jcarousel-list jcarousel-list-horizontal" style="overflow: hidden; position: relative;
                        top: 0px; margin: 0px; padding: 0px; left: -1128.5377831952721px; width: 1892px;">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblQualificationCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                        Visible="false"></asp:Label>
                    <li runat="server" id="li1" style="margin-left: 10px; float: left; list-style: none;"
                        class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal"
                        jcarouselindex="1">
                        <div class="fadeit" id="DivFade" runat="server">
                        </div>
                        <asp:LinkButton ID="lbedit" runat="server" class="editicon loadCer" CommandName="Edit"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                            CausesValidation="false"></asp:LinkButton>
                        <a href="#xRemoveDetails<%#Eval("CandidateQualificationCode") %>" title="" data-toggle="modal"
                            class="closeicon"></a>
                        <asp:Image ID="Image1" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "logopath")%>' height="50px" width="50px" runat="server" onError="this.onerror=null;this.src='/Area/assets/img/noImage.jpg';"/><%# DataBinder.Eval(Container.DataItem, "Institute")%><br>
                        <%# DataBinder.Eval(Container.DataItem, "CandidateCertificate")%><br />
                        <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                        -
                        <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                        <div id="xRemoveDetails<%#Eval("CandidateQualificationCode") %>" class="modal hide theModals"
                            tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h3>
                                    Remove Certificate</h3>
                            </div>
                            <div class="modal-body">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <p>
                                            Do you wish to remove <%# DataBinder.Eval(Container.DataItem, "fullname")%> ?</p>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="row-fluid">
                                    <div class="span6">
                                    </div>
                                    <div class="span6">
                                        <asp:Button ID="LinkButton1" runat="server" class="xBook-button-normal" Style="text-align: center;"
                                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                            OnClientClick="javascript:return true;" Text="Remove"></asp:Button>
                                        <button data-dismiss="modal" data-toggle="modal" class="xBook-button-back" data-original-title=""
                                            title="">
                                            Cancel</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>
                        Nothing here.</p>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:HiddenField ID="hfCertificateCode" runat="server" Value="0" />
        </div>
              <div class="xBoxInner">
            <div class="row-fluid" runat="server" id="tblHasCertificate">
                <div class="span12">
                    <h6>
                        Please provide us details of your certification</h6>
                    <div class="row-fluid">
                        <div class="span5">
                            Do you have any certifications?</div>
                        <div class="span7">
                            <asp:RadioButtonList ID="rblHasCertificate" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Text="Yes" Value="1" onclick="javascript:return ShowHideCertificate('1');"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="No" Value="2" onclick="javascript:return ShowHideCertificate('2');"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
            </div>
            <div id="profeCer" runat="server">
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            <span>Certification Details </span>
                        </h4>
                        <div class="xBoxInner">
                            <div class="row-fluid">
                                <div class="span4">
                                    Institute Name</div>
                                <div class="span8">
                                    <script type="text/javascript">
                                        $(function () {
                                            $("#ContentContainer_txtInstitute").autocomplete({
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
                                                    $('#ContentContainer_hfInstitute').val(ui.item.itemid);
                                                },
                                                change: function (event, ui) {
                                                    if (ui.item == null) {
                                                        $('#ContentContainer_hfInstitute').val("0");
                                                    }
                                                }
                                            });
                                        });
                                    </script>
                                    <div class="ui-widget">
                                        <asp:TextBox ID="txtInstitute" runat="server" class="jqtranformdone institute" onkeydown="javascript:return (event.keyCode!=13);"
                                            onkeypress="javascript:ResetInstitute();" MaxLength="100"></asp:TextBox>
                                        <asp:HiddenField ID="hfInstitute" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Certification Title <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="The name of certification you have completed. For example, Project Management Professional (PMP), Microsoft Certified Programmer (MCP) etc.">
                                        (?)</span></div>
                                <div class="span8">
                                    <script type="text/javascript">
                                        $(function () {
                                            $("#ContentContainer_txtCertificate").autocomplete({
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
                                                    $('#ContentContainer_hfCertificate').val(ui.item.itemid);
                                                },
                                                change: function (event, ui) {
                                                    if (ui.item == null) {
                                                        $('#ContentContainer_hfCertificate').val("0");
                                                    }
                                                }
                                            });

                                        });
                                    </script>
                                    <div class="ui-widget">
                                        <asp:TextBox ID="txtCertificate" runat="server" MaxLength="100" class="jqtranformdone CertificateTitle"
                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetCertificate();"></asp:TextBox>
                                        <asp:HiddenField ID="hfCertificate" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Field of Study <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="The specific field in which you have completed your certification. For example, Project Management, Software Development, Network Management etc.">
                                        (?)</span></div>
                                <div class="span8">
                                    <script type="text/javascript">
                                        $(function () {
                                            $("#ContentContainer_txtField").autocomplete({
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
                                                    $('#ContentContainer_hfField').val(ui.item.itemid);
                                                },
                                                change: function (event, ui) {
                                                    if (ui.item == null) {
                                                        $('#ContentContainer_hfField').val("0");
                                                    }
                                                }
                                            });
                                        });
                                    </script>
                                    <div class="ui-widget">
                                        <asp:TextBox ID="txtField" class="jqtranformdone Field" runat="server" MaxLength="100"
                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetField();"></asp:TextBox>
                                        <asp:HiddenField ID="hfField" runat="server" />
                                    </div>
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
                            <div class="row-fluid">
                                <div class="span2 offset4">
                                    <asp:DropDownList ID="ddlFromMonth" runat="server" Width="80px" class="FromMonth"
                                        ClientIDMode="Static">
                                        <asp:ListItem Selected="True" Value="" Text="Month"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Sept"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="span2">
                                    <asp:DropDownList ID="ddlFromYear" runat="server" Width="80px" class="FromYear" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                                <div id="divtomonth" class="span2 xSetDisable" runat="server">
                                    <asp:DropDownList ID="ddlToMonth" runat="server" Width="80px" class="ToMonth" ClientIDMode="Static">
                                        <asp:ListItem Selected="True" Value="" Text="Month"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Sept"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="divtoYear" class="span2 xSetDisable" runat="server">
                                    <asp:DropDownList ID="ddlToYear" runat="server" Width="80px" class="ToYear" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 pull-right">
                                    <asp:CheckBox ID="chkEducationStatus" runat="server" class="xCheckEduCurrent" ClientIDMode="Static"
                                        Text="In progress" OnClick="ShowHideDateTo();" />
                                </div>
                            </div>
                            <div class="row-fluid xSetDisableCer2" id="PaperCount" runat="server">
                                <div class="span4">
                                    Papers/Courses</div>
                                <div class="span2">
                                    Total
                                    <br />
                                    <asp:TextBox ID="txtTotalPapers" runat="server" CssClass="jqtranformdone totalpapers"
                                        onkeypress="return isNumberKey(event);" MaxLength="2"></asp:TextBox>
                                </div>
                                <div class="span2">
                                    Cleared
                                    <br />
                                    <asp:TextBox ID="txtClearedPapers" runat="server" CssClass="jqtranformdone clearedpapers"
                                        onkeypress="return isNumberKey(event);" MaxLength="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         
            <div  id="footerCer" runat="server">
            <div class="xboxFooter" >
                <div class="row-fluid">
                    <div class="span8">
                        <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                    </div>
                    <div class="span4">
                        <asp:Button ID="Button1" class="btn btn-small pull-right" Text="Save &amp; Add more" runat="server"
                            OnClick="btnSave_Click" OnClientClick="javascript:return validateForm();" />
                        <input type="button" clientidmode="Static" style="display: none" id="btnVDate" runat="server"
                            onclick="return validateForm();" />
                    </div>
                </div>
                </div>
            </div>
         
    </div>
    <div class="xboxRight">
        <div class="xBoxInner">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button ID="btnContinue" class="xBook-button-normal button pull-right" Text="Save &amp; Continue"
                        runat="server" OnClick="btnContinue_Click" OnClientClick="javascript:return hascertificate();" />
                    <a href="../profile/diploma.aspx" class="xBook-button-back fa13 pull-right"  onclick="return confirm('Are you sure you want to go back?');" style="text-decoration: none;
                        color: rgb(242, 246, 248);">Back</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

