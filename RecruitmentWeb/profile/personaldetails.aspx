<%@ Page Title="Personal Details" Language="C#" MasterPageFile="~/ProfileMaster.master"
    AutoEventWireup="true" CodeFile="personaldetails.aspx.cs" Inherits="profile_personaldetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <title>Personal Details</title>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
    <script type="text/javascript" src="http://j.maxmind.com/app/geoip.js"></script>
    <script type="text/javascript">
        function getOnloadData() {
            $("#ddlCountry").each(function () {
                $('option', this).each(function () {
                    if ($(this).text().toLowerCase() == geoip_country_name().toLowerCase()) {
                        $(this).attr('selected', 'selected')
                    };

                });
            });


            $("#ddlCity").each(function () {
                $('option', this).each(function () {
                    if ($(this).text().toLowerCase() == geoip_city().toLowerCase()) {
                        $(this).attr('selected', 'selected')
                    };

                });
            });


        }
    </script>
    <script type="text/javascript">
        function AddNewRowOrHideThisRow1(ImageID) {
            var img = document.getElementById(ImageID.id);
            if (img.src.indexOf('plus').toString() == "-1") {
                $('#ContentContainer_Contact1').addClass('hidden');
            }
            else {
                $('#ContentContainer_Contact2').removeClass('hidden');
                img.src = img.src.replace("plus.png", "minus.jpg");
            }
        }
        function AddNewRowOrHideThisRow2(ImageID) {
            var img = document.getElementById(ImageID.id);
            if (img.src.indexOf('plus').toString() == "-1") {
                $('#ContentContainer_Contact2').addClass('hidden');
            }
            else {
                $('#ContentContainer_Contact3').removeClass('hidden');
                img.src = img.src.replace("plus.png", "minus.jpg");
            }
        }
        function AddNewRow() {
            if (!($('#ContentContainer_Contact2').is(':visible'))) {
                document.getElementById("ContentContainer_Contact2").style.display = "";
                $('#ContentContainer_hfContact2').val("1");
            }
            else if (!($('#ContentContainer_Contact3').is(':visible'))) {
                document.getElementById("ContentContainer_Contact3").style.display = "";
                $('#ContentContainer_hfContact3').val("1");
                document.getElementById("ContentContainer_PlusImg").style.display = "none";
            }
        }
        function DeleteSecondRow() {
            document.getElementById("ContentContainer_Contact2").style.display = "none";
            $('#ContentContainer_hfContact2').val("0");
            document.getElementById("ContentContainer_PlusImg").style.display = "";
        }

        function DeleteThirdRow() {
            document.getElementById("ContentContainer_Contact3").style.display = "none";
            $('#ContentContainer_hfContact3').val("0");
            document.getElementById("ContentContainer_PlusImg").style.display = "";
        }
    
    </script>
    <script type="text/javascript" src="/Area/assets/js/AddMoreBrowse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="tab-pane" id="Xstep7">
        <div class="xboxRight" style="overflow: visible;">
            <img src="/Area/assets/img/banners/personaldetails.jpg" alt="">
            <div class="xBoxInner">
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            <span>Personal Details</span></h4>
                        <div class="xBoxInner">
                            <div class="row-fluid">
                                <div class="span4">
                                    Your Name</div>
                                <div class="span8">
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="jqtranformdone fullname"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span2">
                                    Gender
                                </div>
                                <div class="span8 pull-right">
                                    <asp:RadioButtonList ID="rbtnlGender" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Value="1" Text="Male" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Date of Birth
                                </div>
                                <div class="span2 ">
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="month">
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
                                    <asp:DropDownList ID="ddlDay" runat="server" CssClass="day">
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
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="year">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Marital Status
                                </div>
                                <div class="span8">
                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="maritalstatus">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span2">
                                    Nationality
                                </div>
                                <div class="span8 pull-right">
                                    <asp:RadioButtonList ID="rblNationality" runat="server" onclick="javascript:return rblNationality_OnClick();"
                                        RepeatDirection="Horizontal" CssClass="nationality" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div runat="server" id="trNIC" class="row-fluid">
                                <div class="span4">
                                    CNIC</div>
                                <div class="span8">
                                    <asp:TextBox ID="txtNIC" runat="server" MaxLength="13" CssClass="jqtranformdone cnic" onkeypress="return isNumberKey(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div runat="server" id="trPassport" class="row-fluid">
                                <div class="span4">
                                    Passport</div>
                                <div class="span8">
                                    <asp:TextBox ID="txtPassport" runat="server" MaxLength="20" CssClass="jqtranformdone passport"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Religion
                                </div>
                                <div class="span8">
                                    <asp:DropDownList ID="ddlReligon" runat="server" CssClass="religon">
                                    </asp:DropDownList>                              
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Shift Availability <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="Some of the departments operate in multiple shifts, so you are required to provide us with the shifts you are available to work at.">
                                        (?)</span></div>
                                <div class="span8">
                                    <asp:CheckBoxList ID="chklShift" runat="server" RepeatColumns="1" RepeatLayout="Flow"
                                        RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Height <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="Some of the departments require Height Information.">
                                        (?)</span></div>
                                <div class="span8">
                                    <asp:TextBox ID="txtHeightFeet" runat="server" Style="width: 14%;" ClientIDMode="Static"
                                        CssClass="jqtranformdone" ValidationGroup="Check" onkeydown="return isNumberKey(event);"
                                        MaxLength="2"></asp:TextBox> feet
                                        &nbsp; <asp:TextBox ID="txtHeightInches" runat="server" Style="width: 14%;" ClientIDMode="Static"
                                        CssClass="jqtranformdone" ValidationGroup="Check" onkeydown="return isNumberKey(event);"
                                        MaxLength="2"></asp:TextBox> inches (e.g. 5 feet 7 inches)
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Weight <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                        data-original-title="Some of the departments require Weight Information.">
                                        (?)</span></div>
                                <div class="span8  ">
                                    <asp:TextBox ID="txtWeight" runat="server" Style="width: 14%;" ClientIDMode="Static"
                                        CssClass="jqtranformdone" ValidationGroup="Check" onkeydown="return isNumberKey(event);"
                                        MaxLength="3"></asp:TextBox> kg (e.g. 54 kg)
                                        
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 ">
                                    Expected Salary
                                </div>
                                <div class="span4">
                                    <asp:TextBox ID="txtExpectedSalary" runat="server" Style="width: 94%;" ClientIDMode="Static"
                                        CssClass="jqtranformdone" ValidationGroup="Check" onkeydown="return isNumberKey(event);"
                                        MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            <span>Enter Contact Details</span></h4>
                        <div class="xBoxInner">
                            <div class="row-fluid">
                                <div class="span4">
                                    Mobile Number</div>
                                <div class="span8">
                                    <asp:Label ID="lblPrimaryNumber" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hfContact2" runat="server" />
                                    <asp:HiddenField ID="hfContact3" runat="server" />
                                </div>
                            </div>
                            <div style="display: none;" runat="server" id="Contact3">
                                <div class="span4">
                                </div>
                                <div class="span3 ">
                                    <asp:DropDownList ID="ddlCode3" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="span4">
                                    <asp:TextBox ID="txtMobileNumber3" runat="server" onkeypress="return isNumberKey(event);"
                                        MaxLength="11" class="jqtranformdone" Text=""></asp:TextBox>
                                </div>
                                <div class="span1">
                                    <button title="" data-original-title="" class="btn btn-small " type="button" onclick="javascript:DeleteThirdRow();return false;">
                                        <img src="/Area/assets/img/minus.jpg" alt=""></button>
                                </div>
                                <%--<div class="span1">
                                    <asp:ImageButton ID="ImgAddMore3" runat="server" class="btn btn-small xAddMore" ImageUrl="/Area/assets/img/minus.jpg"
                                        Style="padding: 5px 10px;" OnClientClick="javascript:DeleteThirdRow();return false;" />
                                </div>--%>
                            </div>
                            <div style="display: none;" runat="server" id="Contact2">
                                <div class="span4">
                                </div>
                                <div class="span3 ">
                                    <asp:DropDownList ID="ddlCode2" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="span4">
                                    <asp:TextBox ID="txtMobileNumber2" runat="server" onkeypress="return isNumberKey(event);"
                                        MaxLength="11" class="jqtranformdone" Text=""></asp:TextBox>
                                </div>
                                <div class="span1">
                                    <button title="" data-original-title="" class="btn btn-small " type="button" onclick="javascript:DeleteSecondRow();return false;">
                                        <img src="/Area/assets/img/minus.jpg" alt="" /></button>
                                </div>
                                <%--<div class="span1">
                                    <asp:ImageButton ID="ImgAddMore2" runat="server" class="btn btn-small xAddMore" ImageUrl="/Area/assets/img/minus.jpg"
                                        Style="padding: 5px 10px;" OnClientClick="javascript:DeleteSecondRow();return false;" />
                                </div>--%>
                            </div>
                            <div runat="server" id="Contact1">
                                <div class="span4">
                                </div>
                                <div class="span3">
                                    <asp:DropDownList ID="ddlCode1" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="span4">
                                    <asp:TextBox ID="txtMobileNumber1" runat="server" onkeypress="return isNumberKey(event);"
                                        MaxLength="11" class="jqtranformdone"></asp:TextBox>
                                </div>
                                <div class="span1">
                                    <button runat="server" id="PlusImg" title="" data-original-title="" class="btn btn-small "
                                        type="button" onclick="javascript: AddNewRow();return false;" style="padding: 6px 10px;">
                                        <img src="/Area/assets/img/plus.png" alt="" /></button>
                                </div>
                                <%--<div class="span1">
                                    <asp:ImageButton ID="ImgAddMore1" runat="server" class="btn btn-small xAddMore" ImageUrl="/Area/assets/img/plus.png"
                                        Style="padding: 10px;" OnClientClick="javascript:AddNewRow();return false;" />
                                </div>--%>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Landline Number</div>
                                <div class="span3">
                                    <asp:TextBox ID="txtLandlineCode" runat="server" onkeypress="return isNumberKey(event);"
                                        MaxLength="5" CssClass="jqtranformdone landlinecode" placeholder="Area Code"></asp:TextBox>
                                </div>
                                <div class="span4">
                                    <asp:TextBox ID="txtLandLineNumber" runat="server" onkeypress="return isNumberKey(event);"
                                        MaxLength="11" CssClass="jqtranformdone landline" placeholder="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Email Address</div>
                                <div class="span8">
                                    <asp:Label ID="lblEmail" runat="server" CssClass="jqtransformdone email"></asp:Label>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4">
                                    Address</div>
                                <div class="span2">
                                    <asp:TextBox ID="txtHouse" MaxLength="50" onkeydown="javascript:return (event.keyCode!=13);"
                                        runat="server" CssClass="jqtranformdone house" placeholder="House No"></asp:TextBox>
                                </div>
                                <div class="span2">
                                    <asp:TextBox ID="txtBlock" MaxLength="50" onkeydown="javascript:return (event.keyCode!=13);"
                                        runat="server" CssClass="jqtranformdone block" placeholder="Block/Street"></asp:TextBox>
                                </div>
                                <div class="span4">
                                    <asp:TextBox ID="txtArea" MaxLength="200" onkeydown="javascript:return (event.keyCode!=13);"
                                        runat="server" CssClass="jqtranformdone area" placeholder="Area"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span4 offset4">
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="city">
                                    </asp:DropDownList>

                                     <asp:TextBox ID="txtCity" runat="server" style="display:none"
                                        CssClass="jqtranformdone othercity" placeholder="City"></asp:TextBox>
                                </div>
                                <div class="span4">
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="country" onchange="ChangeCity();">
                                    </asp:DropDownList>
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
                </div>
            </div>
        </div>
        <div class="xboxRight">
            <div class="xBoxInner">
                <div class="row-fluid">
                    <div class="span12">
                        <asp:Button ID="btnSave" runat="server" OnClientClick="return validateForm();" CssClass="xBook-button-normal button pull-right "
                            Text="Save &amp; Continue" OnClick="btnSave_Click" />
                        <a href="../profile/portfolio.aspx" class="xBook-button-back fa13 pull-right" onclick="return confirm('Are you sure you want to go back?');" style="text-decoration: none;
                            color: rgb(242, 246, 248);">Back</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ChangeCity() {
            //debugger;
            if (document.getElementById("ContentContainer_ddlCountry").value != "172") {
                document.getElementById("ContentContainer_txtCity").style.display = "";
                document.getElementById("ContentContainer_ddlCity").style.display = "none";
            }
            else {
                document.getElementById("ContentContainer_txtCity").style.display = "none";
                document.getElementById("ContentContainer_ddlCity").style.display = "";
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
        function rblNationality_OnClick() {
            if (document.getElementById("ContentContainer_rblNationality_0").checked == true) {
                $('#<%=trPassport.ClientID%>').hide(0);
                $('#<%=trNIC.ClientID%>').show(0);
            }
            else {
                $('#<%=trNIC.ClientID%>').hide(0);
                $('#<%=trPassport.ClientID%>').show(0);
            }
        }
        function validateForm() {
            var isName, isGender, isDOBday, isDOBmonth, isDOByear, isMaritalStatus = false;
            var isNationality, isRegion, isShift, islandline, isHouse, isBlock, isArea = false;
            var isCity, isCountry = false;

            if ($('.fullname').val().trim() == "")
                $('.fullname').addClass('error');
            else {
                $('.fullname').removeClass('error');
                isName = true;
            }
            if ($('.month').val() == "")
                $('.month').addClass('error');
            else {
                $('.month').removeClass('error');
                isDOBmonth = true;
            }
            if ($('.day').val() == "")
                $('.day').addClass('error');
            else {
                $('.day').removeClass('error');
                isDOBday = true;
            }
            if ($('.year').val() == "")
                $('.year').addClass('error');
            else {
                $('.year').removeClass('error');
                isDOByear = true;
            }
            if ($('.maritalstatus').val() == "")
                $('.maritalstatus').addClass('error');
            else {
                $('.maritalstatus').removeClass('error');
                isMaritalStatus = true;
            }
            if ($('.religon').val() == "")
                $('.religon').addClass('error');
            else {
                $('.religon').removeClass('error');
                isRegion = true;
            }


            if ($('.country').val() == "")
                $('.country').addClass('error');
            else {
                $('.country').removeClass('error');
                isCountry = true;
            }

            if ($('.country').val() != "172") {
                if ($('.othercity').val() == "")
                    $('.othercity').addClass('error');
                else {
                    $('.othercity').removeClass('error');
                    isCity = true;
                }

            }
            else {
                if ($('.city').val() == "")
                    $('.city').addClass('error');
                else {
                    $('.city').removeClass('error');
                    isCity = true;
                }

            }


            if ($('.house').val().trim() == "")
                $('.house').addClass('error');
            else {
                $('.house').removeClass('error');
                isHouse = true;
            }
            if ($('.block').val().trim() == "")
                $('.block').addClass('error');
            else {
                $('.block').removeClass('error');
                isBlock = true;
            }
            if ($('.area').val().trim() == "")
                $('.area').addClass('error');
            else {
                $('.area').removeClass('error');
                isArea = true;
            }

            $($('#<%=chklShift.ClientID %> input:checked').each(function () {
                isShift = true;
            }));
            if (isShift) {
                $('#<%=chklShift.ClientID %>').parent().removeClass('error');
            }
            else {
                $('#<%=chklShift.ClientID %>').parent().addClass('error');
            }
            if ($('#<%=rblNationality.ClientID %> input:checked').val() == '1') {
                if ($('.cnic').val().trim() == "") {
                    $('.cnic').addClass('error');
                }
                else {
                    $('.cnic').removeClass('error');
                    isNationality = true;
                }
            } else if ($('#<%=rblNationality.ClientID %> input:checked').val() == '2') {
                if ($('.passport').val().trim() == "") {
                    $('.passport').addClass('error');
                }
                else {
                    $('.passport').removeClass('error');
                    isNationality = true;
                }
            }
            if (isName && isDOBday && isDOBmonth && isDOByear && isMaritalStatus && isShift && isNationality && isHouse && isBlock && isArea && isCity && isCountry && isRegion) {
                $(".errormsg").text("");

                if ($("#ContentContainer_ddlMonth").val() == 4 || $("#ContentContainer_ddlMonth").val() == 6 || $("#ContentContainer_ddlMonth").val() == 9 || $("#ContentContainer_ddlMonth").val() == 11) {
                    max_days = 30;
                }
                else if ($("#ContentContainer_ddlMonth").val() == 2) {            // February                
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
                else
                    return true;
            }
            else {
                $(".errormsg").text("Please provide complete & valid information");
                return false;
            }
        }
    

    </script>
</asp:Content>
