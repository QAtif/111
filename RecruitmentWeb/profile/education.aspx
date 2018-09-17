<%@ Page Title="Education" Language="C#" MasterPageFile="~/ProfileMaster.master"
    AutoEventWireup="true" CodeFile="education.aspx.cs" Inherits="profile_education" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <title>Education Details</title>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <!--#include virtual="/Area/includes/scripts.html" -->
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div id="xEduForm">
        <div class="tab-pane" id="Xstep2">
            <div class="xboxRight">
                <img src="/Area/assets/img/banners/education.jpg" alt="">
                <div class="suggestmore timeline" id="profeCerList" runat="server">
                    <div class="LoadingImage">
                        <img src="/Area/assets/img/ajax-loader.gif" alt="">
                    </div>
                    <asp:ListView ID="lvEducation" runat="server" OnItemCommand="lvEducation_OnItemCommand"
                        OnItemEditing="lvEducation_ItemEditing" OnItemDeleting="lvEducation_ItemDeleting"
                        OnItemDataBound="lvEducation_ItemDataBound">
                        <LayoutTemplate>
                            <ul id="Ul" runat="server" class="jcarousel-list jcarousel-list-horizontal active"
                                style="overflow: hidden; position: relative; top: 0px; margin: 0px; padding: 0px;
                                left: -1128.5377831952721px; width: 1892px;">
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
                                <asp:HiddenField ID="hdnISComplete" runat="server" Value='<%# Eval("Verified")%>' />
                                <asp:HiddenField ID="qualificationCode" runat="server" Value='<%# Eval("CandidateQualificationCode")%>' />
                                <asp:LinkButton ID="lbedit" runat="server" class="editicon loadCer" CommandName="Edit"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                                    CausesValidation="false"></asp:LinkButton>
                                <a href="#xRemoveDetails<%#Eval("CandidateQualificationCode") %>" title="" data-toggle="modal"
                                    class="closeicon"></a>
                                <img src='<%#Eval("LogoPath") %>' height="50px" width="50px" alt="" onerror="this.src='/Area/assets/img/noeducation.png';" />
                                <%# DataBinder.Eval(Container.DataItem, "Institute")%><br>
                                <%# DataBinder.Eval(Container.DataItem, "CandidateEducation")%><br>
                                <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                                -
                                <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                                <div id="xRemoveDetails<%#Eval("CandidateQualificationCode") %>" class="modal hide theModals"
                                    tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            ×</button>
                                        <h3>
                                            Remove Education</h3>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <p>
                                                    Do you wish to remove
                                                    <%#Eval("fullname")%>
                                                    ?</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="row-fluid">
                                            <div class="span6">
                                            </div>
                                            <div class="span6">
                                                <asp:Button class="xBook-button-normal" ID="lnkDelete" runat="server" CommandArgument='<%#Eval("CandidateQualificationCode") %>'
                                                    CommandName="Delete" OnClientClick="javascript:return true;" Text="Remove"></asp:Button>
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
                <div class="notification-bar">
                    You need to provide us complete information from your lowest to highest level of
                    Education.<br>
                    (e.g. Matric to Masters) <a href="javascript:;" title="" class="xclose"></a>
                </div>
                <div class="xBoxInner" id="profeEdu">
                    <div class="row-fluid">
                        <div class="span12">
                            <h4>
                                <span>Education Details</span></h4>
                            <div class="xBoxInner">
                                <div class="row-fluid">
                                    <div class="span4">
                                        Institute Name
                                    </div>
                                    <div class="span8">
                                        <asp:TextBox ID="txtInstitute" runat="server" CssClass="jqtranformdone institute"
                                            onkeydown="javascript:return (event.keyCode!=13);" onkeypress="javascript:ResetInstitute();"
                                            ClientIDMode="Static" MaxLength="100"></asp:TextBox>
                                        <asp:HiddenField ID="hfInstitute" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4">
                                        Level of Education <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                            data-original-title="The education level you are going to add like Matric, Intermediate, Bachelors or Masters.">
                                            (?)</span>
                                    </div>
                                    <div class="span8">
                                        <asp:DropDownList runat="server" Width="368px" CssClass="jqtranformdone levelofeducation"
                                            ID="ddllevelofEducation" onChange="ShowHide();" ClientIDMode="static" AppendDataBoundItems="true">
                                            <asp:ListItem Selected="True" Value="" Text="Select Education Level"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row-fluid" id="dvBoard" clientidmode="Static" runat="server" style="display: none">
                                    <div class="span4">
                                        Board Name</div>
                                    <div class="span8">
                                        <asp:DropDownList ID="ddlBoard" Height="26px" Width="368px" CssClass="board" ClientIDMode="Static"
                                            runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Selected="True" Value="" Text="Select Board"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4">
                                        Field of Study <span id="spnfos" class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                            data-original-title="The specific field in which you have completed your education level. For example, Bachelors in Computer Science, Bachelors in Commerce or Masters in Business Administration etc.">
                                            (?)</span>
                                    </div>
                                    <div class="span8">
                                        <asp:TextBox ID="txtDegree" runat="server" CssClass="jqtranformdone degree" ClientIDMode="Static"
                                            onkeydown="javascript:return (event.keyCode!=13);" ValidationGroup="Bachelor"
                                            onkeypress="javascript:ResetDegree();" MaxLength="100"></asp:TextBox>
                                        <asp:HiddenField ID="hfDegree" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4">
                                        Majors <span id="spnmajors" class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                            data-original-title="The major courses you studied in this education level. For example, Marketing, Finance, Networking, Project Management etc.">
                                            (?)</span>
                                    </div>
                                    <div class="span8">
                                        <asp:TextBox ID="txtField" runat="server" CssClass="jqtranformdone major" ClientIDMode="Static"
                                            MaxLength="100" onkeypress="javascript:ResetField(event);"></asp:TextBox>
                                        <asp:HiddenField ID="hfField" ClientIDMode="Static" runat="server" />
                                        <asp:HiddenField ID="hdnSkillName" runat="server" ClientIDMode="Static" />
                                        <asp:Button ID="btnAddSkill" CssClass="hidden" ClientIDMode="Static" runat="server"
                                            Text="Add" OnClick="btnAddSkill_Click" Style="display: none;" />
                                    </div>
                                </div>
                                <div class="row-fluid" style="min-height: 0px !important; padding-bottom: 5px;">
                                    <div class="span8 offset4" id="skillsetArea" style="min-height: 0px !important;">
                                        <asp:HiddenField ID="hdnSkillList" runat="server" ClientIDMode="Static" />
                                        <asp:HiddenField ID="hdnSkillListName" runat="server" ClientIDMode="Static" />
                                        <%=skillsListHTML%>
                                    </div>
                                </div>
                                <div class="row-fluid xCurrentWork">
                                    <div class="span4">
                                        Duration
                                    </div>
                                    <div class="span2 ">
                                        From<br>
                                        <asp:DropDownList ID="ddlFromMonth" ClientIDMode="Static" runat="server" Width="70px"
                                            CssClass="FromMonth">
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
                                        <br>
                                        <asp:DropDownList ID="ddlFromYear" ClientIDMode="Static" runat="server" Width="70px"
                                            class="FromYear">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="span2 xSetDisable" id="dvTo" clientidmode="Static" runat="server">
                                        To<br>
                                        <asp:DropDownList ID="ddlToMonth" ClientIDMode="Static" runat="server" Width="70px"
                                            CssClass="ToMonth">
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
                                    <div class="span2 xSetDisable" id="dvTo1" clientidmode="Static" runat="server">
                                        <br>
                                        <asp:DropDownList ID="ddlToYear" ClientIDMode="Static" runat="server" Width="70px"
                                            class="ToYear">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4 pull-right">
                                        <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkEducationStatus" onClick="ShowHideDate();"
                                            CssClass="xCheckEduCurrent" Text="In progress" />
                                    </div>
                                </div>
                                <div class="row-fluid" clientidmode="Static" id="dvAlevel" runat="server">
                                    <div class="span4">
                                        Marks Scored <span id="spnmarks" class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                            data-original-title="The marks you scored in form of Percentage or GPA. Please mention the Grade as well.">
                                            (?)</span>
                                    </div>
                                    <div class="span2">
                                        Percentage
                                    </div>
                                    <div class="span2" id="dvGrade" clientidmode="Static" runat="server" style="display: none">
                                        GPA
                                    </div>
                                    <div class="span4">
                                        Grade
                                    </div>
                                </div>
                                <div class="row-fluid" clientidmode="Static" id="dvAlevel1" runat="server">
                                    <div class="span2 offset4 blabla">
                                        <asp:TextBox ID="txtPercentage" MaxLength="5" runat="server" onkeydown="return isNumberKey(event);"
                                            CssClass="jqtranformdone percentage" Style="text-align: right; padding: 4px 20% !important;
                                            width: 60% !important;" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="span2" id="dvGrade1" onkeydown="return isNumberKey(event);" runat="server"
                                        clientidmode="Static" style="display: none">
                                        <asp:TextBox ID="txtGPA" runat="server" MaxLength="4" CssClass="jqtranformdone gpa"
                                            ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="span2">
                                        <%--<asp:TextBox ID="txtGrade" runat="server" onkeydown="return isAlphabetKey(event);"
                                            MaxLength="4" CssClass="jqtranformdone" ClientIDMode="Static"></asp:TextBox>--%>
                                             <asp:DropDownList ID="ddlGrade" runat="server" Height="26px" ClientIDMode="Static">
                                              <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="A+" Text="A+"></asp:ListItem>
                                            <asp:ListItem Value="A" Text="A"></asp:ListItem>
                                            <asp:ListItem Value="A-" Text="A-"></asp:ListItem>
                                            <asp:ListItem Value="B+" Text="B+"></asp:ListItem>
                                            <asp:ListItem Value="B" Text="B"></asp:ListItem>
                                            <asp:ListItem Value="B-" Text="B-"></asp:ListItem>
                                            <asp:ListItem Value="C+" Text="C+"></asp:ListItem>
                                            <asp:ListItem Value="C" Text="C"></asp:ListItem>
                                            <asp:ListItem Value="C-" Text="C-"></asp:ListItem>                                            
                                            <asp:ListItem Value="D" Text="D"></asp:ListItem>
                                            <asp:ListItem Value="E" Text="E"></asp:ListItem>
                                            <asp:ListItem Value="F" Text="F"></asp:ListItem>

                                             </asp:DropDownList>
                                    </div>
                                    <div class="span2">
                                    </div>
                                </div>
                                <div class="row-fluid" runat="server" id="dvGradeCount" clientidmode="Static" style="display: none">
                                    <div class="span4">
                                        Select Grades <span id="spngrades" class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                            data-original-title="The marks you scored in form of top Grades like 2 A's, 3 B's etc.">
                                            (?)</span>
                                    </div>
                                    <div class="span2">
                                        A
                                    </div>
                                    <div class="span2">
                                        B
                                    </div>
                                    <div class="span2">
                                        C
                                    </div>
                                    <div class="span2">
                                    </div>
                                </div>
                                <div class="row-fluid" runat="server" id="dvGradeCount1" clientidmode="Static" style="display: none">
                                    <div class="span4">
                                    </div>
                                    <div class="span2">
                                        <asp:DropDownList ID="ddlAs" runat="server" Height="26px">
                                            <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="span2">
                                        <asp:DropDownList ID="ddlBs" runat="server" Height="26px">
                                            <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="span2">
                                        <asp:DropDownList ID="ddlCs" runat="server" Height="26px">
                                            <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4">
                                        Position <span class="xCustomTip" data-placement="top" data-toggle="tooltip" data-original-title="If you have got any top position in this education level like 1st, 2nd or 3rd, select Yes.">
                                            (?)</span>
                                    </div>
                                    <div class="span4">
                                        <asp:RadioButtonList ID="rblPosition" runat="server" RepeatDirection="Horizontal"
                                            CellPadding="8" RepeatLayout="Flow">
                                            <asp:ListItem Enabled="true" Selected="False" Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Selected="True" Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="span1">
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4">
                                        Extra Curricular Activities</div>
                                    <div class="span8">
                                        <asp:TextBox placeholder="Sports and other activities" runat="server" CssClass="jqtransformdone"
                                            ID="txtActivities" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="xboxFooter">
                    <div class="row-fluid">
                        <div class="span8">
                            <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                        </div>
                        <div class="span4">
                            <asp:Button CssClass="btn btn-small jqtranformdone" Text="Cancel" runat="server"
                                ID="btnCancel" Visible="false" ClientIDMode="Static" OnClick="btnCancel_Click" />
                            <asp:Button CssClass="btn btn-small pull-right jqtranformdone" Text="Save & Add more"
                                runat="server" ID="btnSave" ClientIDMode="Static" OnClick="btnSave_Click" OnClientClick="javascript:return validateForm();" />
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
                            <asp:Button ID="btnContinue" CssClass="xBook-button-normal button pull-right" Text="Save &amp; Continue"
                                runat="server" OnClick="btnContinue_Click" OnClientClick="javascript:return validateEducation();" />
                            <a href="../profile/experience.aspx" onclick="return confirm('Are you sure you want to go back?');"
                                class="xBook-button-back fa13 pull-right" style="text-decoration: none; color: rgb(242, 246, 248);">
                                Back</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">



        function validateForm() {

            $(".errormsg").text("");
            var isInstitute = false;
            var isLevelofEducation = false;
            var isdegree = false;
            var ismajor = false;
            var isfromMonth = false;
            var isfromYear = false;
            var istoMonth = false;
            var istoYear = false;
            var isBoard = false;
            var isPercentage = false;
            var isGPA = false;
            var isPosition = false;
            var CorrectDate = true;
            var InProgress = false;
            var ValidatePercentage = false;
            if ($('.institute').val() == "") {
                $('.institute').addClass('error');
            } else {
                $('.institute').removeClass('error');
                isInstitute = true;
            }


            if ($('.levelofeducation').val() == "") {
                $('.levelofeducation').addClass('error');
            } else {
                $('.levelofeducation').removeClass('error');
                isLevelofEducation = true;
            }

            if ($('.degree').val() == "") {
                $('.degree').addClass('error');
            } else {
                $('.degree').removeClass('error');
                isdegree = true;
            }

            /*
            if ($("#rptMajor").is(':visible')) {
            $('.major').removeClass('error');
            ismajor = true;
            }
            else {
            $('.major').addClass('error');
            }

            */


            if ($("#hdnSkillList").val() == "") {
                $('.major').addClass('error');
            } else {
                $('.major').removeClass('error');
                ismajor = true;
            }


            if ($("#dvBoard").is(':visible')) {
                if ($('.board').val() == "") {
                    $('.board').addClass('error');
                } else {
                    $('.board').removeClass('error');
                    isBoard = true;
                }
            }
            else {
                isBoard = true;
            }


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

            if (isfromMonth & isfromYear & istoMonth & istoYear & InProgress) {
                var fromDate = (new Date).getFullYear();
                var toDate = (new Date).getFullYear();
                fromDate = '1/' + $('.FromMonth').val() + '/' + $('.FromYear').val();
                toDate = '1/' + $('.ToMonth').val() + '/' + $('.ToYear').val();
                currDate = '1/' + parseInt(currDate.getMonth() + 1) + '/' + currentYear;


                //                alert(fromDate);
                //                alert(toDate);
                //                alert(currDate);

                if ((new Date(fromDate) > new Date(currDate))) {
                    $('.FromMonth').addClass('error');
                    $('.FromYear').addClass('error');
                    $('.ToMonth').addClass('error');
                    $('.ToYear').addClass('error');

                    istoMonth = false; istoYear = false; isfromMonth = false; isfromYear = false;
                    CorrectDate = false;
                }
            }

            /*
            if ($("#txtPercentage").is(':visible')) {
            if ($('.percentage').val() == "") {
            $('.percentage').addClass('error');
            } else {
            $('.percentage').removeClass('error');
            isPercentage = true;
            }
            }
            else {
            isPercentage = true;
            }

            if ($("#txtGPA").is(':visible')) {
            if ($('.gpa').val() == "") {
            $('.gpa').addClass('error');
            } else {
            $('.gpa').removeClass('error');
            isGPA = true;
            }
            }
            else {
            isGPA = true;
            }
            */



            //            alert($("#txtPercentage").is(':visible'));
            //            alert($("#txtGPA").is(':visible'));
            //debugger;
            if (!InProgress) {
                if ($("#txtPercentage").is(':visible') && $("#txtGPA").is(':visible')) {
                    if (($('.percentage').val() == "" || $('.percentage').val() == "%" || $('.percentage').val() == "0" || $('.percentage').val() == "0.00") && ($('.gpa').val() == "" || $('.gpa').val() == "0" || $('.gpa').val() == "0.00")) {
                        $('.gpa').addClass('error');
                        $('.percentage').addClass('error');

                    }
                    else {
                        if (parseInt($("#txtPercentage").val()) <= 100) {
                            ValidatePercentage = true;
                            $('.percentage').removeClass('error');
                        }
                        else {

                            $('.percentage').addClass('error');
                        }
                        isPercentage = true;

                        $('.gpa').removeClass('error');
                        isGPA = true;

                    }
                }

                else if ($("#txtPercentage").is(':visible')) {
                    if ($('.percentage').val() == "%" || $('.percentage').val() == "" || $('.percentage').val() == "0" || $('.percentage').val() == "0.00") {
                        $('.percentage').addClass('error');
                    } else {
                        if (parseInt($("#txtPercentage").val()) <= 100) {

                            ValidatePercentage = true;
                            $('.percentage').removeClass('error');
                            isPercentage = true;
                        }
                        else {
                            $('.percentage').addClass('error');
                        }


                        $('.txtPercentage').removeClass('error');
                        isPercentage = true;
                    }
                }

                if ($("#txtGPA").is(':visible')) {

                    if ($('.gpa').val() == "" || $('.gpa').val() == "0" || $('.gpa').val() == "0.00" && ($('.percentage').val() == "%" || $('.percentage').val() == "" || $('.percentage').val() == "0" || $('.percentage').val() == "0.00")) {
                        $('.gpa').addClass('error');


                    } else {
                        $('.gpa').removeClass('error');
                        isGPA = true;
                        $('.percentage').removeClass('error');
                        isPercentage = true;


                    }
                }

                else {
                    //alert(3);
                    $('.gpa').removeClass('error');
                    isGPA = true;


                }

                if (isPercentage == true || isGPA == true) {
                    $('.gpa').removeClass('error');
                    isGPA = true;
                    $('.percentage').removeClass('error');
                    if (isPercentage == false && !$("#txtGPA").is(':visible')) {

                        $('.percentage').addClass('error');
                        isPercentage = false;
                    }
                    else {
                        isPercentage = true;
                        if ($('.percentage').val() == "")
                            ValidatePercentage = true;
                    }

                }
                if (isPercentage == false && isGPA == false) {
                    $('.gpa').addClass('error');
                    isGPA = false;
                    $('.percentage').addClass('error');
                    isPercentage = false;
                }

            }
            else {
                ValidatePercentage = true;
                isPercentage = true;
                isGPA = true;
                
            }

            if ($("#dvGradeCount1").is(':visible')) {
                ValidatePercentage = true;
                isPercentage = true;
                isGPA = true;
            }


            if ($("#txtPosition").is(':visible')) {
                if ($('.position').val() == "") {
                    $('.position').addClass('error');
                } else {
                    $('.position').removeClass('error');
                    isPosition = true;
                }
            }
            else {
                isPosition = true;
            }

            if (isInstitute & isLevelofEducation & isdegree & ismajor & isBoard & isPercentage & isGPA & isPosition & isfromMonth & isfromYear & istoMonth & istoYear) {

                if (!ValidatePercentage) {

                    $(".errormsg").text("Percentage can only be less than or equal to 100%");
                    return false;
                }
                else {
                    $(".errormsg").text("");
                    return true;
                }
            }
            else {
                $(".errormsg").text("Please provide complete information");
                if (!isfromMonth & !isfromYear & !istoMonth & !istoYear) {
                    if ((!CorrectDate) & isInstitute & isLevelofEducation & isdegree & ismajor & isBoard & isPercentage & isGPA & isPosition) 
                    {
                        //alert($(".errormsg").text());
//                        if($(".errormsg").text()!="")
//                            $(".errormsg").text($(".errormsg").text() + ". \n To date should be greater than from date and less then current Date");
                        //                        else                        
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
        function validateEducation() {
            //alert(document.getElementById("ContentContainer_profeCerList").style.display);
            if (document.getElementById("ContentContainer_profeCerList").style.display == 'none') {
                if ($('.institute').val() == "") {
                    $(".errormsg").text("Please provide atleast one Education");
                    return false;
                }
                else {
                    return validateForm();
                }
            }
            else {

                if ($('.institute').val() == "") {
                    return true;
                }
                else {
                    return validateForm();
                }
            }
        }
        function ResetInstitute() {
            if (event.keyCode != 13) {
                $('#hfInstitute').val("0");
            }
        }
        function ResetDegree() {
            if (event.keyCode != 13) {
                $('#hfDegree').val("0");
            }
        }
        function ResetField(event) {

            if (event.keyCode == 13 || event.keyCode == 9) {

                //event.preventDefault(event);
                //event.preventDefault();
                if (event.keyCode == 13) {
                    event.preventDefault ? event.preventDefault() : event.returnValue = false;
                }
                if (checkArrayName($('#txtField').val())) {
                    var oldValue = $('#hdnSkillList').val();
                    oldValue = oldValue + '|0';

                    var oldValueName = $('#hdnSkillListName').val();
                    oldValueName = oldValueName + '|' + $('#txtField').val();

                    $('#hdnSkillList').val(oldValue);
                    $('#hdnSkillListName').val(oldValueName);

                    var skillvalue = $('#txtField').val();
                    var skillcode = 0;
                    var newSkillValue = "'" + skillvalue + "'";
                    $('#skillsetArea').append('<span class="taglinks" runat="server"><span>' + skillvalue + '</span><a id="lnkEdit" style="cusror: pointer;" onclick="RemoveSkill(this, ' + skillcode + ', ' + newSkillValue + ');"></a></span>');

                    $('#txtField').val("");


                    return false;
                }
            }
        }

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
        function isAlphabetKey(event) {

            var charCode = (event.which) ? event.which : event.keyCode
            var isAlphabet = false;
            //alert(charCode);
            if (charCode >= 65 && charCode <= 90)
                isAlphabet = true;
            if (charCode >= 97 && charCode <= 122)
                isAlphabet = true;
            if (charCode == 8)
                isAlphabet = true;
            if (charCode == 9)
                isAlphabet = true;
            if (charCode == 43)
                isAlphabet = true;
            if (charCode == 45)
                isAlphabet = true;

            //            if (charCode >= 96 && charCode <= 105)
            //                isnumeric = false;

            //            if (charCode == 187)
            //                isAlphabet = true;
            //            if (charCode == 189)
            //                isAlphabet = true;

            return isAlphabet;

        }


        function ShowHideDate() {

            if (document.getElementById('chkEducationStatus').checked) {
                $('#ddlToYear').attr('disabled', '');
                $('#ddlToMonth').attr('disabled', '');
                document.getElementById("txtPercentage").disabled = true;
                document.getElementById("txtGPA").disabled = true;
                //document.getElementById("txtGrade").disabled = true;

                document.getElementById("ddlGrade").disabled = true;
            }
            else {
                $('#ddlToYear').removeAttr('disabled');
                $('#ddlToMonth').removeAttr('disabled');
                document.getElementById("txtPercentage").disabled = false;
                document.getElementById("txtGPA").disabled = false;
                //document.getElementById("txtGrade").disabled = false;
                document.getElementById("ddlGrade").disabled = false;
            }

        }


        function ShowHide() {
            //alert(document.getElementById('ddllevelofEducation'));
            if ($('#ddllevelofEducation').val() == '4' || $('#ddllevelofEducation').val() == '5') {
                $('#dvGrade').hide();
                $('#dvGrade1').hide();
                $('#dvBoard').show();

            }
            else {
                $('#dvGrade').show();
                $('#dvGrade1').show();
                $('#dvBoard').hide();
            }



            if ($('#ddllevelofEducation').val() == '8' || $('#ddllevelofEducation').val() == '9') {
                $('#dvGradeCount').show();
                $('#dvGradeCount1').show();
                $('#dvAlevel').hide();
                $('#dvAlevel1').hide();
            }
            else {

                $('#dvGradeCount').hide();
                $('#dvGradeCount1').hide();
                $('#dvAlevel').show();
                $('#dvAlevel1').show();
            }

            //tooltip            
            if ($('#ddllevelofEducation').val() == '1' || $('#ddllevelofEducation').val() == '2' || $('#ddllevelofEducation').val() == '3') {
                $('#spnfos').attr('data-original-title', 'The specific field in which you have completed your education level. For example, Bachelors in Computer Science, Bachelors in Commerce or Masters in Business Administration etc.');

                $('#spnmajors').attr('data-original-title', 'The major courses you studied in this education level. For example, Marketing, Finance, Networking, Project Management etc.');


            }

            if ($('#ddllevelofEducation').val() == '4' || $('#ddllevelofEducation').val() == '5' || $('#ddllevelofEducation').val() == '8' || $('#ddllevelofEducation').val() == '9') {
                $('#spnfos').attr('data-original-title', 'The specific field in which you have completed your education level. For example, Science, Commerce, Pre-Engineering, Pre-Medical etc.');

                $('#spnmajors').attr('data-original-title', 'The major courses you studied in this education level. For example, Mathematics, Physics, Chemistry, Biology, Accounting etc.');
            }



            if ($('#ddllevelofEducation').val() == '1' || $('#ddllevelofEducation').val() == '2' || $('#ddllevelofEducation').val() == '3') {
                $('#spnmarks').attr('data-original-title', 'The marks you scored in form of Percentage or GPA. Please mention the Grade as well.');

            }
            if ($('#ddllevelofEducation').val() == '4' || $('#ddllevelofEducation').val() == '5') {
                $('#spnmarks').attr('data-original-title', 'The marks you scored in form of Percentage and Grade.');

            }

        }
        function selectValue() {
            if (document.getElementById("rbtnYes").checked == true) {
                $("#txtPosition").show(500);
            }
            if (document.getElementById("rbtnNo").checked == true) {
                $("#txtPosition").hide(500);
            }
        }


        function ShowHidePosition(value) {
            if (value == 1) {
                $("#txtPosition").show(500);
            }
            else {
                $("#txtPosition").hide(500);
            }
        }
    </script>
    <script type="text/javascript">

        function checkArray(thisValue) {
            var output = true;
            var oldValue = $('#hdnSkillList').val();
            var arr = oldValue.split('|');
            $.each(arr, function (key, line) {
                if (line == thisValue)
                    output = false;
            });
            return output;
        }

        function checkArrayName(thisValue) {
            var output = true;
            var oldValue = $('#hdnSkillListName').val();
            var arr = oldValue.split('|');
            $.each(arr, function (key, line) {
                if (line == thisValue)
                    output = false;
            });
            return output;
        }
        function AddSkillsAsync(skillcode, skillvalue) {
            if (checkArray(skillcode)) {
                var oldValue = $('#hdnSkillList').val();
                oldValue = oldValue + '|' + skillcode;
                $('#hdnSkillList').val(oldValue);

                var oldValueName = $('#hdnSkillListName').val();
                oldValueName = oldValueName + '|' + skillvalue;
                $('#hdnSkillListName').val(oldValueName);

                var newSkillValue = "'" + skillvalue + "'";
                $('#skillsetArea').append('<span class="taglinks" runat="server"><span>' + skillvalue + '</span><a id="lnkEdit" style="cusror: pointer;" onclick="RemoveSkill(this, ' + skillcode + ', ' + newSkillValue + ');"></a></span>');

            }
        }

        function RemoveSkill(controlID, code, name) {

            $(controlID).parent().hide();
            var str = '|' + code;
            var oldValue = $('#hdnSkillList').val();
            oldValue = oldValue.replace(str, '');
            $('#hdnSkillList').val(oldValue);

            //alert($('#hdnSkillList'));


            var strName = '|' + name;
            var oldValueName = $('#hdnSkillListName').val();
            oldValueName = oldValueName.replace(strName, '');
            $('#hdnSkillListName').val(oldValueName);



        }

        function ValidatePlaceHolder(obj) {

            var value = $('#' + obj.id).val(); // value = 9.61 use $("#text").text() if you are not on select box...

            value = value.replace("%", "");


            $('#' + obj.id).val(value);
            var num = $('#' + obj.id);


            if (num.val().indexOf("%") > -1)
                $('#' + obj.id).val(test1);
            else
                $('#' + obj.id).val($('#' + obj.id).val() + '%');
        }


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
                    $('#hdnSkillName').val(ui.item.value);
                    AddSkillsAsync(ui.item.itemid, ui.item.value);
                    $(this).val("");
                    return false;

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
    <script type="text/javascript">
        $(function () {
            $("#txtDegree").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete.asmx/FetchListProgramWise",
                        data: "{ 'prefixText': '" + request.term + "%" + $('#ddllevelofEducation').val() + "' }",
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
                    $('#hfDegree').val(ui.item.itemid);
                },
                change: function (event, ui) {
                    if (ui.item == null) {
                        $('#hfDegree').val("0");
                    }
                }
            });

        });
    </script>
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
</asp:Content>
