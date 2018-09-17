<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Profile/ProfileMaster.master" AutoEventWireup="true" CodeFile="diploma.aspx.cs" Inherits="Candidate_Profile_diploma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <script type="text/javascript">
        function ResetInstitute() {
            if ((event.keyCode != 13))
                $('#ctl00_ContentContainer_hfInstitute').val("0");
        }
        function ResetDiploma() {
            if ((event.keyCode != 13))
                $('#ctl00_ContentContainer_hfDiploma').val("0");
        }
        function ResetField() {
            if ((event.keyCode != 13))
                $('#ctl00_ContentContainer_hfField').val("0");
        }
        function ShowHideDiploma(value) {
            if (value == 1) {
                $('#ctl00_ContentContainer_profeDip').removeClass('hidden');
                $('#ctl00_ContentContainer_footerDip').removeClass('hidden');
            }
            else {
                $('#ctl00_ContentContainer_profeDip').addClass('hidden');
                $('#ctl00_ContentContainer_footerDip').addClass('hidden');
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
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <!--#include virtual="/Candidate/Profile/Area/includes/scripts.html" -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div id="xEduForm">
        <div class="tab-pane" id="Xstep2">
            <div class="xboxRight">
                <%--<img src="/Area/assets/img/banners/diploma.jpg" alt="">--%>
                <div class="suggestmore timeline" id="profeDipList" title="Drag to See more" runat="server">
                    <div class="LoadingImage">
                        <img src="/Area/assets/img/ajax-loader.gif" alt="">
                    </div>
                    <asp:ListView ID="lvDiploma" runat="server" OnItemCommand="lvDiploma_OnItemCommand"
                        OnItemEditing="lvDiploma_ItemEditing" OnItemDeleting="lvDiploma_OnItemDeleting">
                        <LayoutTemplate>
                            <ul class="jcarousel-list jcarousel-list-horizontal" style="overflow: hidden; position: relative;
                                top: 0px; margin: 0px; padding: 0px; left: -1128.5377831952721px; width: 1892px;">
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                Visible="false"></asp:Label>
                            <li style="margin-left: 10px; float: left; list-style: none;" class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal"
                                jcarouselindex="1">
                                <div class="fadeit">
                                </div>
                                <asp:LinkButton ID="lbedit" runat="server" class="editicon loadCer" CommandName="Edit"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                    CausesValidation="false"></asp:LinkButton>
                                <a href="#xRemoveDetails<%#Eval("CandidateQualificationCode") %>" title="" data-toggle="modal"
                                    class="closeicon"></a>
                                <asp:Image ID="Image1" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "logopath")%>'
                                    runat="server" /><%# DataBinder.Eval(Container.DataItem, "Institute")%><br>
                                <%# DataBinder.Eval(Container.DataItem, "Diploma")%><br>
                                <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                                -
                                <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                                <div id="xRemoveDetails<%#Eval("CandidateQualificationCode") %>" class="modal hide theModals"
                                    tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            ×</button>
                                        <h3>
                                            Remove Diploma</h3>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <p>
                                                    Do you wish to remove this?</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="row-fluid">
                                            <div class="span6">
                                            </div>
                                            <div class="span6">
                                                <asp:LinkButton ID="lbdel" runat="server" class="xBook-button-normal" Style="text-align: center"
                                                    CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                                    OnClientClick="javascript:return true;">Remove</asp:LinkButton>
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
                    <asp:HiddenField ID="hfDiplomaCode" runat="server" Value="0" />
                </div>
                <div class="xBoxInner">
                    <div class="row-fluid" runat="server" id="tblHasDiploma">
                        <div class="span12">
                            <h6>
                                <strong>Please provide us details of your diplomas</strong></h6>
                            <div class="row-fluid">
                                <div class="span5">
                                    Do you have any diplomas?</div>
                                <div class="span7">
                                    <asp:RadioButtonList ID="rblHasDiploma" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Enabled="true" Selected="True" Text="Yes" Value="1" onclick="javascript:return ShowHideDiploma('1');"></asp:ListItem>
                                        <asp:ListItem Enabled="true" Selected="False" Text="No" Value="2" onclick="javascript:return ShowHideDiploma('2');"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="profeDip" runat="server">
                        <div class="row-fluid">
                            <div class="span12">
                                <h4>
                                    <span>Diploma Details</span></h4>
                                <div class="xBoxInner">
                                    <div class="row-fluid">
                                        <div class="span4">
                                            Institute Name</div>
                                        <div class="span8">
                                            <script type="text/javascript">
                                                $(function () {
                                                    $("#ctl00_ContentContainer_txtInstitute").autocomplete({
                                                        source: function (request, response) {
                                                            $.ajax({
                                                                url: "../../AutoComplete.asmx/FetchInstituteList",
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
                                                            $('#ctl00_ContentContainer_hfInstitute').val(ui.item.itemid);
                                                        },
                                                        change: function (event, ui) {
                                                            if (ui.item == null) {
                                                                $('#ctl00_ContentContainer_hfInstitute').val("0");
                                                            }
                                                        }
                                                    });

                                                });
                                            </script>
                                            <div class="ui-widget">
                                                <asp:TextBox ID="txtInstitute" runat="server" class="jqtranformdone Institute" onkeydown="javascript:return (event.keyCode!=13);"
                                                    onkeypress="javascript:ResetInstitute();" MaxLength="100"></asp:TextBox>
                                                <asp:HiddenField ID="hfInstitute" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span4">
                                            Diploma Title <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                                data-original-title="The name of diploma you have completed. For example, Diploma in IT, Post-Graduate Diploma in Accounting etc.">
                                                (?)</span></div>
                                        <div class="span8">
                                            <script type="text/javascript">
                                                $(function () {
                                                    $("#ContentContainer_txtDiploma").autocomplete({
                                                        source: function (request, response) {
                                                            $.ajax({
                                                                url: "../../AutoComplete.asmx/FetchDiplomaList",
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
                                                            $('#ctl00_ContentContainer_hfDiploma').val(ui.item.itemid);
                                                        },
                                                        change: function (event, ui) {
                                                            if (ui.item == null) {
                                                                $('#ctl00_ContentContainer_hfDiploma').val("0");
                                                            }
                                                        }
                                                    });

                                                });
                                            </script>
                                            <div class="ui-widget">
                                                <asp:TextBox ID="txtDiploma" runat="server" class="jqtranformdone Diploma" onkeydown="javascript:return (event.keyCode!=13);"
                                                    onkeypress="javascript:ResetDiploma();" MaxLength="100"></asp:TextBox>
                                                <asp:HiddenField ID="hfDiploma" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span4">
                                            Field of Study <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                                data-original-title="The specific field in which you have completed your diploma. For example, IT, Engineering, Accounting or Advertising etc.">
                                                (?)</span></div>
                                        <div class="span8">
                                            <script type="text/javascript">
                                                $(function () {
                                                    $("#ctl00_ContentContainer_txtField").autocomplete({
                                                        source: function (request, response) {
                                                            $.ajax({
                                                                url: "../../AutoComplete.asmx/FetchFieldList",
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
                                                            $('#ctl00_ContentContainer_hfField').val(ui.item.itemid);
                                                        },
                                                        change: function (event, ui) {
                                                            if (ui.item == null) {
                                                                $('#ctl00_ContentContainer_hfField').val("0");
                                                            }
                                                        }
                                                    });

                                                });
                                            </script>
                                            <div class="ui-widget">
                                                <asp:TextBox ID="txtField" runat="server" class="jqtranformdone Field" onkeydown="javascript:return (event.keyCode!=13);"
                                                    onkeypress="javascript:ResetField();" MaxLength="100"></asp:TextBox>
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
                                        <div id="divTo" class="span4" runat="server" clientidmode="Static">
                                            <label id="lblTo" type="label" runat="server">
                                                To</label>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span2 offset4">
                                            <asp:DropDownList ID="ddlFromMonth" runat="server" Width="70px" class="FromMonth">
                                                <asp:ListItem Selected="True" Value="" Text="Month"></asp:ListItem>
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
                                            <asp:DropDownList ID="ddlFromYear" runat="server" Width="80px" class="FromYear">
                                            </asp:DropDownList>
                                        </div>
                                        <div id="divtomonth" class="span2 xSetDisable" runat="server" clientidmode="Static">
                                            <asp:DropDownList ID="ddlToMonth" runat="server" Width="80px" class="ToMonth" ClientIDMode="Static">
                                                <asp:ListItem Selected="True" Value="" Text="Month"></asp:ListItem>
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
                                        <div id="divtoYear" class="span2 xSetDisable" runat="server" clientidmode="Static">
                                            <asp:DropDownList ID="ddlToYear" runat="server" Width="80px" class="ToYear" ClientIDMode="Static">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span4 pull-right">
                                            <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkEducationStatus" onClick="ShowHideDateTo();"
                                                CssClass="xCheckEduCurrent" Text="In progress" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="xBoxInner">
                    <div class="xboxFooter" id="footerDip" runat="server">
                        <div class="row-fluid">
                            <div class="span8">
                                <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                            </div>
                            <div class="span4">
                                <asp:Button ID="Button1" class="btn btn-small pull-right" Text="Save &amp; Add more"
                                    runat="server" OnClick="btnSave_Click" OnClientClick="javascript:return validateForm();" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="xboxRight">
            <div class="xBoxInner">
                <div class="row-fluid">
                    <div class="span12">
                        <asp:Button ID="btnSaveAndContinue" class="xBook-button-normal button pull-right"
                            Text="Save &amp; Continue" runat="server" OnClick="btnSaveAndContinue_Click"
                            OnClientClick="javascript:return hasdiploma();" />
                        <a href="../profile/education.aspx" class="xBook-button-back fa13 pull-right" style="text-decoration: none;
                            color: rgb(242, 246, 248);">Back</a>
                    </div>
                </div>
            </div>
        </div>--%>
        </div>
    </div>
    <script type="text/javascript">
        function ShowHideDateTo() {
            if (document.getElementById('chkEducationStatus').checked) {
                $('#ctl00_ContentContainer_ddlToYear').attr('disabled', '');
                $('#ctl00_ContentContainer_ddlToMonth').attr('disabled', '');
            }
            else {
                $('#ctl00_ContentContainer_ddlToYear').removeAttr('disabled');
                $('#ctl00_ContentContainer_ddlToMonth').removeAttr('disabled');
            }
        }
        function hasdiploma() {
            if ($("#ctl00_ContentContainer_profeDipList").is(':visible')) {
                return true;
            }
            else {
                if ($("#ctl00_ContentContainer_profeDip").is(':visible')) {
                    $(".errormsg").text("Atleast one diploma is required");
                    return false;
                }
                else
                    return true;
            }
        }

        function validateForm() {
            var isinstitute = false, isdiplomaTitle = false, isfield = false, isfromMonth = false, isfromYear = false;
            var istoMonth = false, istoYear = false, CorrectDate = true, InProgress = false;

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
                else {
                    $('.FromMonth').removeClass('error');
                    $('.FromYear').removeClass('error');
                    $('.ToMonth').removeClass('error');
                    $('.ToYear').removeClass('error');
                    istoMonth = true; istoYear = true; isfromMonth = true; isfromYear = true;
                }
            }
            if ($('.Institute').val() == "") {
                $('.Institute').addClass('error');
            } else {
                $('.Institute').removeClass('error');
                isinstitute = true;
            }
            if ($('.Diploma').val() == "") {
                $('.Diploma').addClass('error');
            } else {
                $('.Diploma').removeClass('error');
                isdiplomaTitle = true;
            }
            if ($('.Field').val() == "") {
                $('.Field').addClass('error');
            } else {
                $('.Field').removeClass('error');
                isfield = true;
            }
            if (isinstitute & isdiplomaTitle & isfield & isfromMonth & isfromYear & istoMonth & istoYear) {
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
    <!--#include virtual="/Candidate/Profile/Area/includes/footer-scripts.html"-->
</asp:Content>
