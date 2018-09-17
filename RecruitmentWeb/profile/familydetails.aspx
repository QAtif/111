<%@ Page Title="Family Details" Language="C#" MasterPageFile="~/ProfileMaster.master"
    AutoEventWireup="true" CodeFile="familydetails.aspx.cs" Inherits="profile_familydetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="xboxRight">
        <img src="/Area/assets/img/banners/Family-Banner.jpg" alt="">
        <div class="suggestmore timeline" id="profeExpList" runat="server">
            <div class="LoadingImage">
                <img src="/Area/assets/img/ajax-loader.gif" alt="" />
            </div>
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="listView_itemCommand"
                OnItemEditing="ListView1_ItemEditing" OnItemDeleting="ListView1_ItemDeleting"
                OnItemDataBound="ListView1_OnItemDataBound">
                <LayoutTemplate>
                    <ul class="jcarousel-list jcarousel-list-horizontal" style="overflow: hidden; position: relative;
                        top: 0px; margin: 0px; padding: 0px; left: -1128.5377831952721px; width: 1892px;">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li id="li" runat="server" style="margin-left: 10px; float: left; list-style: none;"
                        class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal"
                        jcarouselindex="1">
                        <div class="fadeit" id="DivFade" runat="server">
                        </div>
                        <%-- <a href="javascript:;"   class="editicon loadExp" title="123" runat="server"></a>--%>
                        <asp:LinkButton ID="lnkEdit" CssClass="editicon loadExp" runat="server" CommandArgument='<%#Eval("CandidateFamilyMember_Code") %>'
                            CommandName="Edit"></asp:LinkButton>
                        <a href="#xRemoveDetails<%#Eval("CandidateFamilyMember_Code") %>" title="" data-toggle="modal"
                            class="closeicon"></a>
                        <img src='<%#Eval("LogoPath") %>' height="50px" width="50px" alt="" onerror="this.src='/Area/assets/img/noImage.jpg';" />
                        <%#Eval("MemberRelation")%><br>
                        <%#Eval("HeadText")%>
                        <br>
                        <%#Eval("MemberDOB")%>
                        <span class="vtip"></span>
                        <asp:HiddenField ID="hfFamilyMemberCode" runat="server" Value=' <%#Eval("CandidateFamilyMember_Code") %>' />
                        <div id="xRemoveDetails<%#Eval("CandidateFamilyMember_Code") %>" class="modal hide theModals"
                            tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    x</button>
                                <h3>
                                    Remove Member</h3>
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
                                        <asp:Button class="xBook-button-normal" ID="LinkButton1" runat="server" CommandArgument='<%#Eval("CandidateFamilyMember_Code") %>'
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
            <asp:HiddenField ID="hfFamilyMemberCode" runat="server" Value=' <%#Eval("CandidateFamilyMember_Code") %>' />
        </div>
        <div class="xBoxInner">
            <asp:HiddenField ID="hfCandidateFamilyMemberCode" runat="server" />
            <div class="row-fluid">
                <div class="span12">
                    <h6>
                        Please provide us details of your family members</h6>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <h4>
                        <span>Family Details</span><span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                            data-original-title="Basic details of all of your immediate family members, including your parents, siblings, spouse and children.">
                            (?)</span>
                    </h4>
                    <div class="xBoxInner">
                        <div class="row-fluid">
                            <div class="span4">
                                Relation
                            </div>
                            <div class="span8">
                                <asp:DropDownList ID="ddlRelation" runat="server" CssClass="jqtranformdone">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Name
                            </div>
                            <div class="span8">
                                <asp:TextBox ID="txtName" runat="server" CssClass="jqtranformdone" onkeydown="javascript:return (event.keyCode!=13);"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4 ">
                                Date of Birth
                            </div>
                            <div class="span2  ">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="jqtranformdone month">
                                    <asp:ListItem Selected="True" Value="">Month</asp:ListItem>
                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span2">
                                <asp:DropDownList ID="ddlDay" runat="server" CssClass="jqtranformdone day">
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
                            </div>
                            <div class="span2  ">
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="jqtranformdone year">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Status
                            </div>
                            <div class="span8">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="jqtranformdone">
                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Married" Value="2"></asp:ListItem>                                    
                                    <asp:ListItem Text="Divorced" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Widow" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Late" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Widower" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Qualification
                            </div>
                            <div class="span8">
                                <asp:TextBox ID="txtQualification" runat="server" MaxLength="100" CssClass="jqtranformdone"
                                    onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Occupation
                            </div>
                            <div class="span8">
                                <asp:DropDownList ID="ddlOccupation" runat="server" CssClass="jqtranformdone">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Designation
                            </div>
                            <div class="span8">
                                <asp:TextBox ID="txtDesignation" runat="server" MaxLength="100" CssClass="jqtranformdone"
                                    onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Company/Institute
                            </div>
                            <div class="span8">
                                <asp:TextBox ID="txtOrganization" runat="server" MaxLength="100" CssClass="jqtranformdone"
                                    onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Monthly Income
                            </div>
                            <div class="span8">
                                <asp:TextBox ID="txtMemberIncome" runat="server" onkeydown="return isNumberKey(this);"
                                    MaxLength="7" CssClass="jqtranformdone"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                Picture
                            </div>
                            <div class="span8">
                                <a runat="server" target="_blank" id="lnkPic" style="display:none">View Picture</a>
                                &nbsp;&nbsp;<a runat="server" href="javascript:;" onclick="ShowHide();" id="lnkEdit" style="display:none">(Edit)</a>
                                <asp:FileUpload ID="fuDocument"  runat="server" Width="251px" />
                                <%--<br />
                                <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" 
                                        ErrorMessage="Only png, gif or jpg files are allowed!" 
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.mp3|.JPG|.jpeg|.gif|.png|.jpg)$" 
                                    ControlToValidate="fuDocument" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="xboxFooter">
            <div class="row-fluid">
                <div class="span8">
                    <span class="errormsg red"></span>
                </div>
                <div class="span4">
                    <asp:Button ID="btnProceed" runat="server" Text="Save &amp; Add more" OnClientClick="javascript:return validateForm();"
                        CssClass="btn btn-small pull-right" OnClick="btnProceed_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="xboxRight">
        <div class="xBoxInner">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button ID="btnContinue" runat="server" CssClass="xBook-button-normal button pull-right"
                        Text="Save &amp; Continue" OnClick="btnContinue_Click" OnClientClick="javascript:return validateFamilyMember();" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function validateFamilyMember() {
            if ($('#<%=ddlRelation.ClientID%>').val() == "") {
                return true;
            }
            else {
                return validateForm();
            }

        }


        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var isnumeric = false;
            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 110)
                isnumeric = true;
            if (charCode == 190)
                isnumeric = true;
            if (charCode >= 37 && charCode <= 40)
                isnumeric = true;
            if (charCode >= 96 && charCode <= 105)
                isnumeric = true;

            return isnumeric;

        }
        function validateForm() {
            var IsRelation = false;
            var IsName = false;
            var IsQualification = false;
            var IsOccupation = false;
            var IsDesignation = false;
            var isMonth = false;
            var isDay = false;
            var isYear = false;
            var IsCompany = false;
            var IsMonthlyIncome = false;
            var IsMaritalStatus = false;


            if ($('#<%=ddlRelation.ClientID%>').val() == "") {
                $('#<%=ddlRelation.ClientID%>').addClass('error');
            } else {
                $('#<%=ddlRelation.ClientID%>').removeClass('error');
                IsRelation = true;
            }

            if ($('#<%=ddlMonth.ClientID%>').val() == "") {
                $('#<%=ddlMonth.ClientID%>').addClass('error');
            } else {
                $('#<%=ddlMonth.ClientID%>').removeClass('error');
                isMonth = true;
            }


            if ($('#<%=ddlDay.ClientID%>').val() == "") {
                $('#<%=ddlDay.ClientID%>').addClass('error');
            } else {
                $('#<%=ddlDay.ClientID%>').removeClass('error');
                isDay = true;
            }

            if ($('#<%=ddlYear.ClientID%>').val() == "") {
                $('#<%=ddlYear.ClientID%>').addClass('error');
            } else {
                $('#<%=ddlYear.ClientID%>').removeClass('error');
                isYear = true;
            }

            if ($('#<%=ddlStatus.ClientID%>').val() == "-1") {
                $('#<%=ddlStatus.ClientID%>').addClass('error');
            } else {
                $('#<%=ddlStatus.ClientID%>').removeClass('error');
                IsMaritalStatus = true;
            }


            if ($('#<%=txtName.ClientID%>').val() == "") {
                $('#<%=txtName.ClientID%>').addClass('error');
            } else {
                $('#<%=txtName.ClientID%>').removeClass('error');
                IsName = true;
            }

            if ($('#<%=txtQualification.ClientID%>').val() == "") {
                $('#<%=txtQualification.ClientID%>').addClass('error');
            } else {
                $('#<%=txtQualification.ClientID%>').removeClass('error');
                IsQualification = true;
            }


            if ($('#<%=ddlOccupation.ClientID%>').val() == "") {
                $('#<%=ddlOccupation.ClientID%>').addClass('error');
            } else {

                if ($('#<%=ddlOccupation.ClientID%>').val() == '1' || $('#<%=ddlOccupation.ClientID%>').val() == '2') {

                    if ($('#<%=txtDesignation.ClientID%>').val() == "") {
                        $('#<%=txtDesignation.ClientID%>').addClass('error');
                    } else {
                        $('#<%=txtDesignation.ClientID%>').removeClass('error');
                        IsDesignation = true;
                    }

                    if ($('#<%=txtOrganization.ClientID%>').val() == "") {
                        $('#<%=txtOrganization.ClientID%>').addClass('error');
                    } else {
                        $('#<%=txtOrganization.ClientID%>').removeClass('error');
                        IsCompany = true;
                    }

                    if ($('#<%=txtMemberIncome.ClientID%>').val() == "") {
                        $('#<%=txtMemberIncome.ClientID%>').addClass('error');
                    } else {

                        var phoneRegex = new RegExp(/^[0-9.]+$/);
                        if (phoneRegex.test($('#<%=txtMemberIncome.ClientID%>').val())) {
                            $('#<%=txtMemberIncome.ClientID%>').removeClass('error');
                            IsMonthlyIncome = true;
                        }
                        else {
                            $('#<%=txtMemberIncome.ClientID%>').addClass('error');

                        }
                    }
                }
                else {

                    $('#<%=txtDesignation.ClientID%>').removeClass('error');
                    $('#<%=txtOrganization.ClientID%>').removeClass('error');
                    $('#<%=txtMemberIncome.ClientID%>').removeClass('error');


                    if ($('#<%=txtMemberIncome.ClientID%>').val() != '') {
                        var phoneRegex = new RegExp(/^[0-9.]+$/);
                        if (phoneRegex.test($('#<%=txtMemberIncome.ClientID%>').val())) {
                            $('#<%=txtMemberIncome.ClientID%>').removeClass('error');
                            IsMonthlyIncome = true;
                        }
                        else {
                            $('#<%=txtMemberIncome.ClientID%>').addClass('error');

                        }
                    }
                    else {
                        IsMonthlyIncome = true;
                    }



                    $('#<%=txtOrganization.ClientID%>').removeClass('error');
                    IsCompany = true;

                    $('#<%=txtDesignation.ClientID%>').removeClass('error');
                    IsDesignation = true;
                }

                $('#<%=ddlOccupation.ClientID%>').removeClass('error');
                IsOccupation = true;

            }


            if (IsRelation & IsMaritalStatus & IsName & IsQualification & IsOccupation & isMonth & isDay & isYear & IsMonthlyIncome & IsCompany & IsDesignation) {
                $(".errormsg").text("");

                if ($("#ContentContainer_ddlMonth").val() == 4 || $("#ContentContainer_ddlMonth").val() == 6 || $("#ContentContainer_ddlMonth").val() == 9 || $("#ContentContainer_ddlMonth").val() == 11) {
                    max_days = 30;
                }
                else if ($("#ContentContainer_ddlMonth").val() == 2) {		// February                
                    max_days = 28;
                }
                else {
                    max_days = 31;
                }

                if ($("#ContentContainer_ddlDay").val() > max_days) {
                    $(".errormsg").text("Please select valid date");
                    $('.day').addClass('error');
                    $('.month').addClass('error');
                    $('.year').addClass('error');
                    return false;
                }
                else {
                    return true;
                }

            }
            else {

                $(".errormsg").text("Please provide complete & valid information");
                return false;
            }
        }

        function confirmDelete() {
            var agree = confirm("Are you sure you want to delete?");
            if (agree)
                return true;
            else
                return false;
        }

        function ShowHide() {
            document.getElementById('ContentContainer_fuDocument').style.display = '';
            document.getElementById('ContentContainer_lnkPic').style.display = 'none';
            document.getElementById('ContentContainer_lnkEdit').style.display = 'none';
        }
    </script>

</asp:Content>


