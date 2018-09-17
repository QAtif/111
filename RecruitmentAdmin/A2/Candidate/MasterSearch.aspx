<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="MasterSearch.aspx.cs" Inherits="A2_Candidate_MasterSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <script language="javascript" type="text/javascript">

        function onpress() {
            $('#id_search_list').quicksearch('#UlMain>li');
            // $('#id_search_list').val('content');
        }
        // var qs = $('#id_search_list').quicksearch('#UlMain li');
       

    
    </script>
</asp:Content>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server" onload="fun()">
    <section class="wrapit topmenu"> <span class="msearchIcon"></span> <span class="msearch showsrchbox">Master Search</span>
    <ul class="TopLeftMenu">
      <li><a href="javascript:;" id="af" data-rel="fresh-search-div" title="" class="active">Fresh</a></li>
      <li class="borderNone">|</li>
      <li><a href="javascript:;" data-rel="experienced-search-div" title="">Experienced</a></li>
    </ul>
  </section>
    <section class="wrapit topmenu offeraproval searchbar">
    <div class="domain-name">
      <!--<input id="selectall" type="checkbox" name="checkIt">-->
      <label>Search Results</label>
    </div>
    <ul class="TopLeftMenu">
      <li class="last even searchhidden">
        <div class="srch-fix">
         <input type="text"  name=""  value="" id="id_search_list" placeholder="Select Department" onkeyup="javascript:onpress();" />   
          <input type="submit" class="showsearchtxt" value="">
        </div>
      </li>
    </ul>
  </section>
    <div id="searcharea" class="searcharea">
  
        <div class="SearchBox adjustwidth">
            <div class="InsideSearchBox">
                <div class="HeadingInside">
                    <span class="BasicInfoIcon"></span><span class="IconTxt">Basic Information</span>
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
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Name
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtName" runat="server" ClientIDMode="Static" name="txtName" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
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
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Mobile #
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtPhone" runat="server" ClientIDMode="Static" name="txtPhone" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Referral Deparment
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtRefUrl" runat="server" ClientIDMode="Static" name="txtRefUrl" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                    </div>
                    <!-- #BasicLeft -->
                    <div class="SectionDiv">
                    </div>
                    <div class="BasicRight">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Location
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtCity" runat="server" ClientIDMode="Static" name="txtCity"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                CNIC
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtNic" runat="server" ClientIDMode="Static" name="txtNic" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                               <!-- Category-->
                               Status
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtCategory" runat="server" ClientIDMode="Static" name="txtCategory"
                                     style="display:none !important" class="hide" Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputClass"></asp:DropDownList>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                               <asp:CheckBox ID="chkIsDate" runat="server" Text="" Checked="true" /> &nbsp;  From Date
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div style="float: left">

                                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                                       readonly="true"  /></div>
                                <%--<div style="float: right; padding-left: 2px;">
                                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img5"
                                        style="margin-top: 4px; margin-left: 2px;" /></div>
                                <strong>
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
                                </strong>--%>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                         <%-- <div class="FieldWrapper">
                            <div class="Lable">
                               
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div>
                                  
                                   </div>                           
                            </div>
                            <!-- #InputField -->
                        </div>--%>
                    </div>
                    <!-- #BasicRight -->
                    <div class="SectionDiv second">
                    </div>
                    <div class="BasicRight last">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Level of Education
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtEducationLevel" runat="server" ClientIDMode="Static" name="txtEducationLevel"
                                    class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Marital Status
                            </div>
                            <!-- #Lable -->
                            <div class="InputRadioMargin">
                                <asp:RadioButtonList ID="rdMaritalStatus" runat="server" CssClass="InputRadioMargin"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="Married" Value="2">Married</asp:ListItem>
                                    <asp:ListItem Text="Un Married" Value="1">Un Married</asp:ListItem>
                                    <asp:ListItem Text="Both" Value="0" Selected="True">Both</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable padtop8">
                                Gender
                            </div>
                            <!-- #Lable -->
                            <div class="InputRadioMargin">
                                <asp:RadioButtonList ID="rdGender" runat="server" CssClass="InputRadioMargin" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Text="Married" Value="1">Male</asp:ListItem>
                                    <asp:ListItem Text="Un Married" Value="2">Female</asp:ListItem>
                                    <asp:ListItem Text="Both" Value="0" Selected="True">Both</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                To Date
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div style="float: left">
                                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                                        style="width: 180px" readonly="true" /></div>
                                <%--<div style="float: right; padding-left: 2px;">
                                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img1"
                                        style="margin-top: 4px; margin-left: 2px;" /></div>--%>
                              <%--  <strong>
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
                                </strong>--%>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                    </div>
                    <!-- #BasicRight -->
                </div>
                <!-- #basicSearchArea -->
                <div class="clearfix">
                </div>
                <div class="advancedsearch" id="fresh-search-div">
                    <br>
                    <br>
                    <div class="HeadingInside">
                        <span class="BasicInfoIcon Education"></span><span class="IconTxt">Education</span>
                        <span class="borderHeader borderHeader2"></span>
                    </div>
                    <!-- #HeadingInside -->
                    <div class="basicSearchArea">
                        <div class="BasicLeft padtop9">
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    University
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:TextBox ID="txtUniversity" runat="server" ClientIDMode="Static" name="txtUniversity"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Degree
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:TextBox ID="txtDegree" runat="server" ClientIDMode="Static" name="txtDegree"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Majors
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:TextBox ID="txtMajors" runat="server" ClientIDMode="Static" name="txtMajors"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- #BasicLeft -->
                        <div class="SectionDiv2">
                        </div>
                        <div class="BasicRight middlesec padtop9">
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    End Year
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:DropDownList ID="ddlYears" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- #BasicRight -->
                        <div class="SectionDiv2 second">
                        </div>
                        <div class="BasicRight last padtop9">
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Skill Set
                                </div>
                                <!-- #Lable -->
                                <div class="InputField jqtranformdone">
                                    <asp:TextBox ID="txtSkills" runat="server" ClientIDMode="Static" name="txtSkills"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Portfolio
                                </div>
                                <!-- #Lable -->
                                <div class="InputRadioMargin">
                                    <asp:RadioButtonList ID="rdPortfolio" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper ddlfix">
                                <div class="Lable">
                                    Age
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <div class="gtthan">
                                        Greater than<br />
                                        <asp:DropDownList ID="ddlAgeFrom" runat="server" class="inputClass">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="ltthan">
                                        Less than
                                        <br>
                                        <asp:DropDownList ID="ddlAgeTo" runat="server" class="inputClass">
                                        </asp:DropDownList>
                                        <!-- #CustomWidthClasss -->
                                    </div>
                                    <!-- #Width124px -->
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- #BasicRight -->
                    </div>
                    <!-- #basicSearchArea -->
                </div>
                <div class="advancedsearch" id="experienced-search-div">
                    <br>
                    <br>
                    <div class="HeadingInside">
                        <span class="BasicInfoIcon Education"></span><span class="IconTxt">Experience</span>
                        <span class="borderHeader borderHeader2"></span>
                    </div>
                    <!-- #HeadingInside -->
                    <div class="basicSearchArea">
                        <div class="BasicLeft padtop9">
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Company
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:TextBox ID="txtCompany" runat="server" ClientIDMode="Static" name="txtCompany"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Designation
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:TextBox ID="txtDesignation" runat="server" ClientIDMode="Static" name="txtDesignation"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Responsibilities
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <asp:TextBox ID="txtResponsiblities" runat="server" ClientIDMode="Static" name="txtResponsiblities"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- #BasicLeft -->
                        <div class="SectionDiv2 height135">
                        </div>
                        <div class="BasicRight middlesec" style="margin-top: 10px;">
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Salary Range
                                </div>
                                <!-- #Lable -->
                                <div class="InputField singlefld">
                                    <div class="matsec">
                                        From<br>
                                        <asp:DropDownList ID="ddlSalaryFrom" runat="server" class="inputClass firstddl">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="threesec">
                                        <div class="CustomWidthClass">
                                            To
                                            <br>
                                            <asp:DropDownList ID="ddlSalaryTo" runat="server" class="inputClass firstddl">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <!-- #Width124px -->
                                </div>
                                <!-- #InputField -->
                                <div class="Lable adtoppad">
                                    No. of Years
                                </div>
                                <!-- #Lable -->
                                <div class="InputField padtop7">
                                    <div class="matsec">
                                        <asp:DropDownList ID="ddlNoOfYear" runat="server" class="inputClass fullwidth">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- #BasicRight -->
                        <div class="SectionDiv2 height135 second" style="margin-top: 12px;">
                        </div>
                        <div class="BasicRight last padtop9">
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Skill Set
                                </div>
                                <!-- #Lable -->
                                <div class="InputField jqtranformdone">
                                    <asp:TextBox ID="txtSKillSetE" runat="server" ClientIDMode="Static" name="txtSKillSetE"
                                        class="inputClass"></asp:TextBox>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper">
                                <div class="Lable">
                                    Portfolio
                                </div>
                                <!-- #Lable -->
                                <div class="InputRadioMargin">
                                    <asp:RadioButtonList ID="rdEPortfolio" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                            <div class="FieldWrapper ddlfix">
                                <div class="Lable">
                                    Age
                                </div>
                                <!-- #Lable -->
                                <div class="InputField">
                                    <div class="gtthan">
                                        Greater than<br />
                                        <asp:DropDownList ID="ddlEAgeFrom" runat="server" class="inputClass">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="ltthan">
                                        Less than
                                        <br>
                                        <asp:DropDownList ID="ddlEAgeTo" runat="server" class="inputClass">
                                        </asp:DropDownList>
                                        <!-- #CustomWidthClasss -->
                                    </div>
                                    <!-- #Width124px -->
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- #BasicRight -->
                    </div>
                    <!-- #basicSearchArea -->
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="BorderDiv">
            </div>
            <div class="ButtonsSave" id="btnSearchF">
            <img id="imgLoadingF" runat="server" src="~/assets/images/loading.gif" alt=""  style="display:none; position: absolute;
    right: 338px; bottom:10px;" clientidmode="Static" />
                <a href="javascript:;" class="toogleview" id="toogleviewF">Show Advanced Search</a>
                &nbsp;&nbsp; | &nbsp;&nbsp;
                <asp:Button ID="btnSearchFresh" runat="server" class="SubmteForm" Text="Search Fresh"
                    OnClick="BtnSearchFresh_Click" OnClientClick="javascript:$('#imgLoadingF').show();" />
            </div>
            <div class="ButtonsSave" id="btnSearchE">
             <img id="imgLoadingE" runat="server" src="~/assets/images/loading.gif" alt=""  style="display:none; position: absolute;
    right: 380px; bottom:10px;" clientidmode="Static" />
                <a href="javascript:;" class="toogleview" id="toogleviewE">Show Advanced Search</a>
                &nbsp;&nbsp; | &nbsp;&nbsp;
                <asp:Button ID="btnSearchExp" runat="server" class="SubmteForm" Text="Search Exprienced"
                    OnClick="BtnSearchExperienced_Click"  OnClientClick="javascript:$('#imgLoadingE').show();" />
            </div>
            <!-- #ButtonsSave -->
        </div>
      
    </div>
    <div id="sortable" class="main-wrapper newscreen">
        <!-- Main Content Here -->
        <section class="main-content accordsec">
      <div class="main-accrodian">
        <ul id="UlMain">
        <asp:Repeater ID="rptDepartments" runat="server" OnItemDataBound="rptDepartments_itemDataBound"><ItemTemplate>
          <li>
            <div class="accordian-btn">
              <div>
              <%--  <input type="checkbox" name="checkIt">--%>
                <asp:HiddenField id="hdnDomainCode" runat="server" Value='<%# Eval("Domain_Code") %>' />
                <div><%# Eval("Domain_Name") %><i><%# Eval("CandCount") %></i></div>
              </div>
            </div>
            <div class="accrodian-content">                         
               <asp:Repeater ID="rptDeptCandidate" runat="server" OnItemDataBound="rptDeptCandidate_ItemDataBound" >
            <ItemTemplate>     
            <div class="user-profile-main onlyinfoboxes"> 
             <div class="user-profile-main onlyinfoboxes">          
                    <div class="user-profile-warpper">
                        <div class="user-detail">
                            <div class="p-padding">
                                <label class="p-name"  style="margin-top:0px !important">
                                    <input type="checkbox">
                                    <asp:HiddenField ID="hdnCandCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                                   <a id="aCandidateName" runat="server"  target="_blank" title='<%# Eval("Full_Name") %>'> <%# Eval("Name") %></a></label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="p-grade">
                                    <div class="grade-join left-side width112">
                                        Status<br>
                                        Apply Date<br>
                                        Reference #<br>
                                        Category
                                    </div>
                                    <div class="grade-join right-side width195">
                                         <%# Eval("CandidateStatus") %><br>
                                        <%# Eval("ApplyDate") %><br>
                                           <a id="aCandidateLink" runat="server"  target="_blank"> <%# Eval("RefNo") %></a><%--&nbsp;(<a id="aCandidatelinkOld" runat="server"  target="_blank">Old</a>)--%><br>
                                       <%# Eval("CategoryName") %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="user-growth">
                            <div class="p-padding">
                                <h5>
                                    Last Professional Experience</h5>
                                <div class="grade-join left-side width99">
                                    Salary<br>
                                    Company<br>
                                    Duration<br>
                                    Job Title<br>
                                    <br>
                                    Applied For
                                </div>
                                <div class="grade-join right-side">
                                    <asp:Label ID="lblSalary" runat="server" Text='<%# Eval("Current_Salary") %>'></asp:Label><br>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("CompanyName") %>' ToolTip='<%# Eval("FullNameCom") %>'></asp:Label><br>
                                    <asp:Label ID="lblDuration" runat="server" Text='<%# Eval("duration") %>'></asp:Label><br>
                                    <asp:Label ID="lblJobTitle" runat="server" Text='<%# Eval("Position") %>' ToolTip='<%# Eval("FullPosition") %>'></asp:Label><br>
                                    <br>
                                    <%--<asp:Label ID="lblTotalExperience" runat="server" Text='<%# Eval("years") %>'></asp:Label>--%>
                                    <asp:Label ID="lblAppliedFor" runat="server" Text='<%# Eval("AppliedForUrl") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="user-grade">
                            <div class="p-padding">
                                <h5>
                                    Highest Academic Qualification</h5>
                                <div class="grade-join left-side width88">
                                    Degree<br>
                                    Institute<br>
                                    CGPA/Grades<br>
                                    Passing Year<br>
                                    <br>
                                    Majors
                                </div>
                                <div class="grade-join right-side width180">
                                    <asp:Label ID="lblDegree" runat="server" Text='<%# Eval("Degree") %>'></asp:Label><br>
                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Eval("Institute") %>' ToolTip='<%# Eval("FullNameIns") %>'></asp:Label><br>
                                    <asp:Label ID="lblGPA" runat="server" Text='<%# Eval("GPA") %>'></asp:Label><br>
                                    <asp:Label ID="lblPassingYear" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label><br>
                                    <br>
                                    <asp:Label ID="lblMajorName" runat="server"  Text='<%# Eval("Majors") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="user-ranking">
                            <div class="p-padding">
                                <h5>
                                    Contact Details</h5>
                                <div class="grade-join left-side width88">
                                    Email<br>
                                    Phone #<br>
                                    Cell #<br>
                                    City
                                </div>
                                <div class="grade-join right-side">
                                   <asp:Label ID="lblEmailShow" Text='<%# Eval("Email") %>' runat="server" ToolTip='<%# Eval("FullEmail") %>' ></asp:Label><br>
                                    <%# Eval("Phone") %><br>
                                     <%# Eval("Cell") %><br>
                                    <%# Eval("city") %>
                                </div>
                            </div>
                        </div>
                        <br class="clearfix">
                    </div>
                  
                    </div>    
                    </div>     
            </ItemTemplate>
        </asp:Repeater>
                       
            </div>
          </li>
          </ItemTemplate></asp:Repeater>
       
        </ul>
      </div>
    </section>
    </div>
    <script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../assets/js/MultipleItemSelection/jQuery.Tokeninput.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
  
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">

  $(function() {
      $("#postedToDate").datepicker({
      changeMonth: true,
      changeYear: true,
      dateFormat:"M dd, yy"
      
     
    });
});

$(function () {
    $("#postedFromDate").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "M dd, yy"
    });
});

        $("#txtCategory").tokenInput("../Handler/searchcategoryhandler..ashx?ID=1", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Category to Search"
        });
        $("#txtCity").tokenInput("../Handler/searchcategoryhandler..ashx?ID=2", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a City to Search"
        });
        $("#txtEducationLevel").tokenInput("../Handler/searchcategoryhandler..ashx?ID=3", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Education Level to Search"
        });
        $("#txtDegree").tokenInput("../Handler/searchcategoryhandler..ashx?ID=4", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Degree to Search"
        });
        $("#txtMajors").tokenInput("../Handler/searchcategoryhandler..ashx?ID=5", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Majors to Search"
        });
        $("#txtUniversity").tokenInput("../Handler/searchcategoryhandler..ashx?ID=6", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a University to Search"
        });
        $("#txtSkills").tokenInput("../Handler/searchcategoryhandler..ashx?ID=7", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Skills to Search"
        });
        $("#txtSKillSetE").tokenInput("../Handler/searchcategoryhandler..ashx?ID=7", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Skills to Search"
        });
        $("#txtCompany").tokenInput("../Handler/searchcategoryhandler..ashx?ID=8", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Company to Search"
        });
        $("#txtDesignation").tokenInput("../Handler/searchcategoryhandler..ashx?ID=9", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Designation to Search"
        });
        $("#txtRefUrl").tokenInput("../Handler/searchcategoryhandler..ashx?ID=10", {
            theme: "facebook",
            preventDuplicates: true,
            minChars: 0,
            hintText: "Type a Department to Search"
        });
        

        function Bind(j, ctrl) {
            var jObj = JSON.parse(j);

            for (var i = 0; i <= jObj.length - 1; i++) {

                $("#" + ctrl).tokenInput("add", jObj[i]);
            }
        }




    </script>
</asp:Content>



