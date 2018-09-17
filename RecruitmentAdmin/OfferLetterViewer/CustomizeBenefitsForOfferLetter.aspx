<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master"  Debug="true" AutoEventWireup="true" CodeFile="CustomizeBenefitsForOfferLetter.aspx.cs" Inherits="XRecruitmentAdmin.OfferLetterViewer.CustomizeBenefitsForOfferLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
<script src="<%=Page.ResolveUrl("~")%>A2/assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~")%>A2/assets/css/style.css" />
	 <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/xlib.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/function.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../assets/js/MultipleItemSelection/jQuery.Tokeninput.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="../assets/js/toastr.min.js"></script>
    <link rel="stylesheet" href="../assets/css/toastr.min.css" />

  <style type="text/css">
        .user-detail, .p-padding {
            width: 100% !important;
        }

        .bor {
            border-right: 1px solid #D9D9D9;
        }

        .bob {
            border-bottom: 1px solid #D9D9D9;
        }

        .bot {
            border-top: 1px solid #D9D9D9;
        }

        .bol {
            border-left: 1px solid #D9D9D9;
        }

        table th {
            font-size: 16px;
        }

        table tr {
            height: 45px !important;
        }

        table td {
            font-size: 15px;
            text-align: left !important;
        }

        .user-profile-warpper {
            height: auto !important;
        }

        h4 {
            background: url(../assets/images/bg-h4.jpg) repeat-x 0px 8px;
            font-size: 13px;
            color: #333333;
            font-weight: bold;
            margin: 10px 0px !important;
            width: 98% !important;
        }

            h4 span {
                background: #fff;
                padding-right: 10px;
            }

        .inputClass {
            width: 198px;
            min-height: 19px;
            color: #000000;
            line-height: 18px;
            width: 257px;
            border: 1px solid #999999;
            min-height: 20px;
            padding: 2px 4px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
    </style>
    <script type="text/javascript">



        function isNumberKey(event) {

            var charCode = (event.which) ? event.which : event.keyCode
            var isnumeric = false;

            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            //if (charCode == 110)
            //    isnumeric = true;
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

        $(document).ready(function () {
            $("#txtCarOfficeName").tokenInput("../A2/Handler/searchcategoryhandler..ashx?ID=11", {
                theme: "facebook",
                preventDuplicates: true,
                minChars: 0,
                hintText: "Type a Car name to Search",
                tokenLimit: 1,
                prePopulate: [{ id: $("#<%=hdfOfficeCarname.ClientID%>").val(), name: $("#<%=hdfOfficeCarname.ClientID%>").val() }]
            });

            $("#txtCarHomeName").tokenInput("../A2/Handler/searchcategoryhandler..ashx?ID=11", {
                theme: "facebook",
                preventDuplicates: true,
                minChars: 0,
                hintText: "Type a Car name to Search",
                tokenLimit: 1,
                prePopulate: [{ id: $("#<%=hdfHomeCarname.ClientID%>").val(), name: $("#<%=hdfHomeCarname.ClientID%>").val() }]
            });

            $("#txtMobile").tokenInput("../A2/Handler/searchcategoryhandler..ashx?ID=12", {
                theme: "facebook",
                preventDuplicates: true,
                minChars: 0,
                hintText: "Type a Mobile name to Search",
                tokenLimit: 1,
                prePopulate: [{ id: $("#<%=hdfMobileName.ClientID%>").val(), name: $("#<%=hdfMobileName.ClientID%>").val() }]
            });
			$("#txtMobileHome").tokenInput("../A2/Handler/searchcategoryhandler..ashx?ID=12", {
                theme: "facebook",
                preventDuplicates: true,
                minChars: 0,
                hintText: "Type a Mobile name to Search",
                tokenLimit: 1,
                prePopulate: [{ id: $("#<%=hdfHomeMobileName.ClientID%>").val(), name: $("#<%=hdfHomeMobileName.ClientID%>").val() }]
             });


            $("#<%=txtGrossSalary.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtCompensatoryAllowance.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtProvidentFund.ClientID%>").attr("disabled", "disabled");
        });

        function Bind(j, ctrl) {
            var jObj = JSON.parse(j);

            for (var i = 0; i <= jObj.length - 1; i++) {

                $("#" + ctrl).tokenInput("add", jObj[i]);
            }
        }

        function setHiddenField() {
            $("#<%=hdfMobileName.ClientID%>").val($("#txtMobile").val());
            $("#<%=hdfHomeCarname.ClientID%>").val($("#txtCarHomeName").val());
            $("#<%=hdfOfficeCarname.ClientID%>").val($("#txtCarOfficeName").val());
			$("#<%=hdfHomeMobileName.ClientID%>").val($("#txtMobileHome").val());

            return true;
        }

        function GrossSalary() {
            var OtherAllowance = isNaN(parseInt($("#<%=txtOtherAllowance.ClientID%>").val())) ? 0 : parseInt($("#<%=txtOtherAllowance.ClientID%>").val());
            var BasicSalary = isNaN(parseInt($("#<%=txtBasicSalary.ClientID%>").val())) ? 0 : parseInt($("#<%=txtBasicSalary.ClientID%>").val());

            $("#<%=txtGrossSalary.ClientID%>").val(OtherAllowance + BasicSalary);
            $("#<%=txtCompensatoryAllowance.ClientID%>").val((OtherAllowance + BasicSalary) / 30);
            $("#<%=txtProvidentFund.ClientID%>").val((BasicSalary / 12) * 0.0833);

            return true;
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div id="searcharea" class="searcharea">

        <div class="SearchBox adjustwidth" style="margin-top: 3% !important; height: 172px !important;">
            <div class="InsideSearchBox" style="padding-top: 25px !important;">
                <div class="HeadingInside">
                    <span class="BasicInfoIcon"></span><span class="IconTxt">Search</span>
                    <span class="borderHeader"></span>
                </div>
                <!-- #HeadingInside -->
                <div class="basicSearchArea">
                    <div class="BasicLeft">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Reference #
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtRefNo" runat="server" ClientIDMode="Static" name="txtRefNo" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>

                    <%-- <div class="SectionDiv">
                    </div>
                    <div class="BasicRight">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Email
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" name="txtEmail" class="inputClass"></asp:TextBox>
                                <!--<span class="CheckBox"></span><span class="Checktxt">Exactly match Email</span>-->
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>--%>
                    <!-- #FieldWrapper -->


                    <!-- #BasicRight -->
                </div>
                <!-- #basicSearchArea -->
            </div>

            <div class="clearfix">
            </div>
            <div class="BorderDiv" style="margin-top: 12px;">
            </div>
            <div class="ButtonsSave" id="btnSearchF">
                <asp:Button ID="btnSearch" runat="server" class="SubmteForm" Text="Search" OnClick="btnSearch_Click" />
                <%--OnClick="BtnSearchFresh_Click"--%>
            </div>
        </div>
    </div>
    <div id="sortable" class="main-wrapper newscreen" style="height: 1200px !important;">
        <!-- Main Content Here -->
        <section class="main-content accordsec" style="height: 100% !important;">
      <div class="main-accrodian" style="height:100% !important;">
        <ul id="UlMain" style="height:100% !important;">
    <div class="user-profile-main onlyinfoboxes" style="height:100% !important;">
        <div class="user-profile-main onlyinfoboxes" style="height:100% !important;">
            <div class="user-profile-warpper" style="height:100% !important;">
                <div class="user-detail">
                    <h1 style="padding-left: 2% !important;">Candidate Benefits Details</h1>
                    <div class="p-padding" id="MainDiv" runat="server">
                         <h4><span>
                                            <img src="../assets/images/icon/personal-detail.png" alt="*"/>
                                            Personal Details</span></h4>  
                        <table style="width:98%">
                            
                            <tr  id="trRec" runat="server" >
                                <td style="width:4%" align="left" >
                                    Ref #:
                                </td>
                                <td style="width:10%" align="left" ><b>
                                    <asp:Label runat="server" ID="lblRefNo"></asp:Label></b>
                                </td>
                                  <td style="width:4%" align="left" >
                                    Name:
                                </td>
                                <td style="width:15%" align="left"><b>
                                    <asp:Label runat="server" ID="lblName"></asp:Label></b>
                                </td>
                                 <td style="width:4%" align="center">
                                    Grade:
                                </td>
                                <td style="width:15%" align="left"><b>
                                    <asp:Label runat="server" ID="lblGrade"></asp:Label>
                                    </b>
                                </td>
                                <%-- <td style="width:25%" align="center" class="bol bob">
                                   <label style="width:100%;text-align:center">
                                        <asp:HiddenField ID="hdfldCandidateID" runat="server"  />
                                        <asp:Label runat="server" ID="lblName"></asp:Label></label></td>
                                <td style="width:25%" align="center" class="bol bob"> <asp:Label runat="server" ID="lblEmailAddress"></asp:Label></td>
                                <td style="width:25%" align="center" class="bol bob bor"> <asp:Label runat="server" ID="lblPhoneNo"></asp:Label></td>--%>
                            </tr>
                            </table>
                         <h4><span>
                                            <img src="../assets/images/icon/salary.png" alt="*"/>
                                            Salary</span>
                                            <span class="xCustomTip"></span>
                                        </h4>   <table>
                                            <tr>
                                                 
                                                 <td style="width:15%" align="left">
                                                 Basic Salary:
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtBasicSalary" onkeyup="return GrossSalary();" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                                
                                                <td style="width:15%" align="left">
                                                 Other Allowance:
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtOtherAllowance" onkeyup="return GrossSalary();" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                            </tr>
                                            <tr> 
                                               <td style="width:15%" align="left">
                                                 Gross Salary:
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtGrossSalary"  MaxLength="15" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                                 <td style="width:15%" align="left">
                                                 Compensatory Allowance:
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtCompensatoryAllowance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                            </tr>
                                            <tr>
                                                 <td style="width:15%" align="left">
                                                 Provident Fund:
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtProvidentFund" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                                <td style="width:15%" align="left">
                                                 EOBI:
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtEOBI" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                            </tr>
											<tr>
                                                 <td style="width:15%" align="left">
                                                 Salary (International Package):
                                                 </td>
                                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtSalaryInternationalPackage" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td><td style="width:15%" align="left" >
                                 BOL League:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                                         <asp:DropDownList runat="server" ID="ddlBOLLeague"></asp:DropDownList>
                                          </div>
                                </td>
                                                 </tr>
                                                </table>
                        
                                        <h4><span>
                                            <img src="../assets/images/icon/vehicle.png" alt="*"/>
                                            Vehicle</span>
                                            <span class="xCustomTip"></span>
                                        </h4>   
                        <table>
                              <tr  id="tr1" runat="server" >
                                <td style="width:15%" align="left">
                                    Office Car Name:
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                 <asp:TextBox runat="server" ID="txtCarOfficeName" MaxLength="150" ClientIDMode="Static"  class="inputClass"></asp:TextBox>
                                      <asp:HiddenField ID="hdfldCandidateCode" runat="server"  /> 
                                            <asp:HiddenField ID="hdfldApplicationID" runat="server"  /> 
                                    <asp:HiddenField ID="hdfldCandidateID" runat="server"  /> 
                                    <asp:HiddenField ID="hdfOfficeCarname" runat="server"  /> 
                                </td>
                                    <td colspan="2"   style="width:15%" align="left">
                                  Office Fuel Allowance:
                                </td>
                                <td style="width:35%" align="left">
                                   <div class="InputField">
                                   <%-- <asp:TextBox runat="server" ID="txtOfficeFuelAllowance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                       <asp:DropDownList runat="server" ID="ddlOfficeFuelAllowance"></asp:DropDownList>
                                          </div>
                                </td>
                                  </tr>
                  
                            <tr>
                                  <td style="width:15%" align="left" >
                                    Home Car Name:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                    <asp:TextBox runat="server" ID="txtCarHomeName" MaxLength="150" ClientIDMode="Static"  class="inputClass"></asp:TextBox>
                                    <asp:HiddenField ID="hdfHomeCarname" runat="server"  /> 
                                </td>
                                  <td colspan="2"   style="width:15%" align="left">
                                  Home Fuel Allowance:
                                </td>
                                <td  style="width:35%" align="left">
                                   <div class="InputField">
                                  <%--  <asp:TextBox runat="server" ID="txtHomeFuelAllowance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                        <asp:DropDownList runat="server" ID="ddlHomeFuelAllowance"></asp:DropDownList>
                                          </div>
                                </td>
                                
                            </tr>
                            <tr>
                                <td style="width:15%" align="left">
                                    Car Allowance:
                                </td>
                                <td colspan="2">
                                     <asp:TextBox runat="server" ID="txtCarAllowance" ClientIDMode="Static"  class="inputClass" MaxLength="10" onkeydown="return isNumberKey(event);"></asp:TextBox>

                                </td>

                            </tr>
                            
                            <tr>
                                  <td style="width:15%" align="left" >
                                    Pick & Drop:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                    <asp:CheckBox runat="server" ID="chckBoxPickDrop" ></asp:CheckBox>
                                </td>
								<%-- <td style="width:15%" align="left" >
                                    Bike:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                    <asp:CheckBox runat="server" ID="chckBoxBike" ></asp:CheckBox>
                                </td>--%>
                            </tr>
                             <%--<tr>
                                 

                                 <td  style="width:15%" align="left">
                                    Office Car Monetization:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                     <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtOfficeCarMonetization" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                         </div>
                                </td>
                                  <td style="width:15%" align="left">
                                    Home Car Monetization:
                                </td>
                                <td colspan="2" style="width:35%" align="center">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtHomeCarMonetization" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                  <td  colspan="2" style="width:10%" align="left">
                                  Office Fuel Allowance (Amount):
                                </td>
                                <td style="width:15%" align="left">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtOfficeFuelAllowanceAmount" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                            </tr>--%>
                        <%--    <tr>
                                
                                   <td  colspan="2" style="width:10%" align="left">
                                   Home Fuel Allowance (Amount):
                                </td>
                                <td style="width:15%" align="left">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtHomeFuelAllowanceAmount" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                      
                            </tr>--%>
                                     </table>

                         <h4><span>
                                            <img src="../assets/images/icon/Mobile.png" alt="*"/>
                                            Mobile</span></h4> 
                            <table>                     <tr>
                                  <td style="width:15%" align="left" >
                                 Mobile Allowance:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtMobileAllowance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                         <asp:DropDownList runat="server" ID="ddlMobileAllowance"></asp:DropDownList>
                                          </div>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                  Mobile:
                                </td>
                                <td style="width:35%" align="left" >
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMobile" ClientIDMode="Static" MaxLength="100" class="inputClass"></asp:TextBox>
                                           <asp:HiddenField ID="hdfMobileName" runat="server"  /> 
                                          </div>
                                </td>
                            </tr>
							<tr>
                                  <td style="width:15%" align="left" >
                                 Mobile Allowance (Home):
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtMobileAllowance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                         <asp:DropDownList runat="server" ID="ddlMobileAllowanceHome"></asp:DropDownList>
                                          </div>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                  Mobile (Home):
                                </td>
                                <td style="width:35%" align="left" >
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMobileHome" ClientIDMode="Static" MaxLength="100" class="inputClass"></asp:TextBox>
                                           <asp:HiddenField ID="hdfHomeMobileName" runat="server"  /> 
                                          </div>
                                </td>
                            </tr>
                                <%--<tr>
                                     <td style="width:15%" align="left" >
                                 Monetization Mobile:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                               <asp:TextBox runat="server" ID="txtMobileMonetization" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                     <td  colspan="2" style="width:15%" align="left">
                               
                                </td>
                                <td style="width:35%" align="left" >
                                      <div class="InputField">
                                    
                                          </div>
                                </td>

                                </tr>--%>
                           
                                </table>
                          <h4><span>
                                            <img src="../assets/images/icon/HealthCare.png" alt="*"/>
                                            Healthcare</span></h4> 
                        <table>
                               <tr>
                                  <td style="width:15%" align="left" >
                                Medical Self:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                                   <asp:DropDownList runat="server" ID="ddlMedicalSelf"></asp:DropDownList>
                                          </div>
                                </td>
                                   <td style="width:15%" align="left">
                                Accidental Death Insurance (Amount):
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtAccidentalInsurance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                   <asp:DropDownList runat="server" ID="ddlAccidentalInsurance"></asp:DropDownList>
                                              </div>
                                </td>
                                 <%--   <td style="width:15%" align="left" >
                                Medical Parent:
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMedicalParent" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>--%>
                                  
                            </tr>
                             <%-- <tr>
                                  <td  colspan="2" style="width:15%" align="left">
                                  Monetization Health (self):
                                </td>
                                <td style="width:35%" align="left" >
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMedicalMonetizationSelf" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                  Monetization Health (Parent):
                                </td>
                                <td style="width:35%" align="left">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMedicalMonetizationParent" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                            </tr>
                             <tr>
                                  <td style="width:15%" align="left">
                                Meternity (Amount):
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                   <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMeternity" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                  Meternity Limit:
                                </td>
                                <td style="width:35%" align="left">
                                      <div class="InputField">
                                 <asp:DropDownList runat="server" ID="ddlMeternityLimit">
                                     <asp:ListItem Text="Rs. 20,000/- to Rs. 37,500/-" Value="Rs. 20,000/- to Rs. 37,500/-"></asp:ListItem>
                                     <asp:ListItem Text="Rs. 25,000/- to Rs. 47,500/-" Value="Rs. 25,000/- to Rs. 47,500/-"></asp:ListItem>
                                     <asp:ListItem Text="Rs. 40,000/- to Rs. 67,500/-" Value="Rs. 40,000/- to Rs. 67,500/-"></asp:ListItem>
                                     <asp:ListItem Text="Rs. 60,000/- to Rs. 120,000/-" Value="Rs. 60,000/- to Rs. 120,000/-"></asp:ListItem>
                                     <asp:ListItem Text="Rs. 100,000/- to Rs. 170,000/-" Value="Rs. 100,000/- to Rs. 170,000/-"></asp:ListItem>
                                 </asp:DropDownList>

                                          </div>
                                </td>
                            </tr>--%>
                              <%--<tr>
                                  
                                   <td  colspan="2" style="width:15%" align="left">
                                 Natural Death Insurance (Amount):
                                </td>
                                <td style="width:35%" align="left">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtNaturalInsurance" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                            </tr>--%>
                            </table>
                        
                         <h4><span>
                                            <img src="../assets/images/icon/other.png" alt="*"/>
                                            Other</span></h4> 
                        <table>
                             <tr>
                                  <td style="width:15%" align="left" >
                                 Mineral Water (Bottles):
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                                   <%-- <asp:TextBox runat="server" ID="txtMineralWaterBottles" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                       <asp:DropDownList runat="server" ID="ddlMineralWaterBottles"></asp:DropDownList>
                                          </div>
                                </td>
                                   <td style="width:15%" align="left">
                               Salon Qouta:
                                </td>
                                <td colspan="2" style="width:35%" align="center">
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtSalon" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                       <asp:DropDownList runat="server" ID="ddlSalon"></asp:DropDownList>
                                          </div>
                                </td>
                                 
                                 <%--  <td  colspan="2" style="width:10%" align="left" >
                                  Mineral Water Allowance (Amount):
                                </td>
                                <td style="width:15%" align="left" >
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMWAllowanceAmount" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>--%>
                            </tr>
                         
                            <tr>
                                  <td style="width:15%" align="left" >
                               Servant Count:
                                </td>
                                <td colspan="2" style="width:35%" align="left" >
                                   <div class="InputField">
                                  <%--  <asp:TextBox runat="server" ID="txtServantCount" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                       <asp:DropDownList runat="server" ID="ddlServantCount"></asp:DropDownList>
                                          </div>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                Monetization Servant:
                                </td>
                                <td style="width:35%" align="left">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMonetizationServant" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                            </tr>
                            <tr>
                                  <td style="width:15%" align="left">
                               Paid Vacations:
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtPaidVacations" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                           <asp:DropDownList runat="server" ID="ddlPaidVacations"></asp:DropDownList>
                                          </div>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                Monetization Leaves:
                                </td>
                                <td style="width:35%" align="left">
                                      <div class="InputField">
                                    <asp:TextBox runat="server" ID="txtMonetizationLeaves" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>
                                          </div>
                                </td>
                            </tr>
                              <tr>
                                   <td  colspan="2" style="width:15%" align="left">
                                Hut Facility:
                                </td>
                                <td style="width:35%" align="left">
                                      <div class="InputField">
                                     <asp:DropDownList runat="server" ID="ddlHutFacility"></asp:DropDownList>
                                          </div>
                                </td>
                            </tr>
                              <tr>
                                  <td style="width:15%" align="left">
                              Club Facility:
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtPaidVacations" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                           <asp:DropDownList runat="server" ID="ddlClubfacility">
              
                                           </asp:DropDownList>
                                          </div>
                                </td>
                                  <td style="width:15%" align="left">
                              Club Facility Detail:
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                   <div class="InputField">
                                    <%--<asp:TextBox runat="server" ID="txtPaidVacations" MaxLength="10" onkeydown="return isNumberKey(event);" class="inputClass"></asp:TextBox>--%>
                                           <asp:DropDownList runat="server" ID="ddlClubFacilityDetail"></asp:DropDownList>
                                          </div>
                                </td>
                            </tr>
                             <tr>
                                  <td style="width:15%" align="left">
                               Skip 2ND Page:
                                </td>
                                <td colspan="2" style="width:35%" align="left">
                                    <asp:CheckBox runat="server" ID="chckboxSecondPage"></asp:CheckBox>
                                </td>
                                   <td  colspan="2" style="width:15%" align="left">
                                Last page:
                                </td>
                                <td style="width:35%" align="left">
                                        <asp:RadioButtonList runat="server" ID="rdbtnlstLastPage" RepeatDirection="Horizontal">
<asp:ListItem Text="Default" Value="0" ></asp:ListItem>
                                        <asp:ListItem Text="Consultant" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Actor" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                         <div class="BorderDiv">
            </div>
                        <br />
                        <br />
            <div class="ButtonsSave" style="width:98%">
                <asp:Label runat="server" ID="lblError" style="float: left;font-size: 15px;"></asp:Label>
                <asp:Button ID="btnUpdate" runat="server" style="float: right;" OnClick="btnUpdate_Click" class="SubmteForm" OnClientClick="return setHiddenField();" Text="Generate Offer" />
                <%--OnClick="BtnSearchFresh_Click"--%>
            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            </ul>
          </div>
            </section>
    </div>

</asp:Content>
