<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="UpdatedMasterSearch_.aspx.cs" Inherits="A2_Candidate_UpdatedMasterSearch_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <link href="../assets/css/jquery.multiselect.filter.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/jquery.multiselect.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function onpress() {
            $('#id_search_list').quicksearch('#UlMain>li');
        }
    </script>
    <style type="text/css">
        .InnerTable td
        {
            align: center;
            vertical-align: top;
        }
        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default
        {
            border: 1px solid #D3D3D3;
            background: #E6E6E6 url(images/ui-bg_glass_75_e6e6e6_1x400.png) 100% 100% repeat-x;
            font-weight: normal;
            color: #555;
        }
        .ui-state-hover, .ui-widget-content .ui-state-hover, .ui-widget-header .ui-state-hover, .ui-state-focus, .ui-widget-content .ui-state-focus, .ui-widget-header .ui-state-focus
        {
            border: 1px solid #D3D3D3;
            background: #D3D3D3 url(images/ui-bg_glass_75_e6e6e6_1x400.png) 100% 100% repeat-x;
            font-weight: normal;
            color: #212121;
        }
    </style>
</asp:Content>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="wrapit topmenu"> <span class="msearchIcon"></span> <span class="msearch showsrchbox">Master Search</span>
    <ul class="TopLeftMenu">
      <li><a href="javascript:;" id="af" data-rel="fresh-search-div" title="" class="active" onclick="$('hdnSelectedTab').val('1')">Fresh</a></li>
      <li class="borderNone">|</li>
      <li><a href="javascript:;" data-rel="experienced-search-div" title="" onclick="$('hdnSelectedTab').val('2')">Experienced</a></li>
      <asp:HiddenField ID="TotalCount" runat="server" ClientIDMode="Static"/>
      <asp:HiddenField ID="hdnSelectedTab" runat="server" value="1" ClientIDMode="Static"/>
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
          <input type="submit" class="showsearchtxt" value="" />
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
                                Type
                            </div>
                            <!-- #Lable -->
                            <div class="InputRadioMargin">
                                <asp:RadioButtonList ID="rblType" runat="server" CssClass="InputRadioMargin" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Text="Officer" Value="0">  Officer </asp:ListItem>
                                    <asp:ListItem Text="Staff" Value="1">   Staff </asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Referred By
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:DropDownList ID="ddlRefBy" runat="server" class="inputClass">
                                    <asp:ListItem Text="Both" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Refered" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Refered" Value="2"></asp:ListItem>
                                </asp:DropDownList>
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
                                <asp:TextBox ID="txtCity" runat="server" ClientIDMode="Static" name="txtCity" class="inputClass"></asp:TextBox>
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
                                 <asp:CheckBox ID="chkUnmapped" runat="server" Text="" Checked="false" />
                                Status
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtCategory" runat="server" ClientIDMode="Static" name="txtCategory"
                                    Style="display: none !important" class="hide" Visible="false"></asp:TextBox>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputClass">
                                </asp:DropDownList>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                <asp:CheckBox ID="chkIsDate" runat="server" Text="" Checked="true" />
                                &nbsp; From Date
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div style="float: left">
                                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                                        readonly="true" /></div>
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
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Domain
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div style="float: left">
                                    <asp:ListBox ID="ddlDomain" runat="server" hfValue="hfAgents" SelectionMode="Multiple"
                                        Style="width: 207px !important;"></asp:ListBox>
                                    <%-- <asp:ListBox ID="ddlAgents" DataValueField="Id" DataTextField="Name" runat="server"
                                        hfValue="hfAgents" SelectionMode="Multiple"></asp:ListBox>--%>
                                    <asp:HiddenField ID="hfAgents" runat="server" ClientIDMode="Static" />
                                </div>
                            </div>
                            <!-- #InputField -->
                        </div>
                         <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Category
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:DropDownList ID="ddlCategory" runat="server" class="inputClass">                                    
                                </asp:DropDownList>
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
                                Referral Deparment
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtRefUrl" runat="server" ClientIDMode="Static" name="txtRefUrl"
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
                                        readonly="true" /></div>
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
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Religion
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div style="float: left">
                                    <asp:DropDownList ID="ddlReligion" runat="server" class="inputClass">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->
                        <div class="clearfix">
                        </div>
                        <div class="FieldWrapper">
                             <div class="Lable">
                                <strong><asp:LinkButton ID="lnkExport" runat="server" Text="Export to Excel"
                        class="toogleview" onclick="lnkExport_Click"></asp:LinkButton></strong>
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <div style="float: left">
                                    
                        
                                </div>
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
                                    Keywords
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
                                    Keywords
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
                <img id="imgLoadingF" runat="server" src="~/assets/images/loading.gif" alt="" style="display: none;
                    position: absolute; right: 338px; bottom: 10px;" clientidmode="Static" />
                
                <a href="javascript:;" class="toogleview" id="toogleviewF">Show Advanced Search</a>
                &nbsp;&nbsp; | &nbsp;&nbsp;
                <asp:Button ID="btnSearchFresh" runat="server" class="SubmteForm" Text="Search Fresh"
                    OnClick="BtnSearchFresh_Click" OnClientClick="javascript:$('#imgLoadingF').show();" />
            </div>
            <div class="ButtonsSave" id="btnSearchE">
                <img id="imgLoadingE" runat="server" src="~/assets/images/loading.gif" alt="" style="display: none;
                    position: absolute; right: 380px; bottom: 10px;" clientidmode="Static" />
                    
                <a href="javascript:;" class="toogleview" id="toogleviewE">Show Advanced Search</a>
                &nbsp;&nbsp; | &nbsp;&nbsp;
                <asp:Button ID="btnSearchExp" runat="server" class="SubmteForm" Text="Search Exprienced"
                    OnClick="BtnSearchExperienced_Click" OnClientClick="javascript:$('#imgLoadingE').show();" />
            </div>
            <!-- #ButtonsSave -->
        </div>
    </div>
    <div id="sortable" class="main-wrapper" style="padding: 2px 9px 0 9px !important;">
        <!-- Main Content Here -->
        <section class="main-content accordsec">
    
      <div style="background-color: White; padding: 5px 0px 0px 0px;">
      <table border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
       <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound">
       <HeaderTemplate>
        <tr style="font-weight:bold; height:30px;" >
                                    <td align="center" style="width: 1%">
                                        S.No.
                                    </td>
                                    <td align="center" style="width: 7%">
                                        Ref#.
                                    </td>
                                    <td align="center" style="width: 17%">
                                        Full Name
                                    </td>
                                    <td align="center" style="width: 25%">
                                        Education
                                    </td>
                                    <td align="center" style="width: 25%">
                                        Experience
                                    </td>
                                    <td align="center" style="width: 15%">
                                        Email/Phone
                                    </td>
                                    <td align="center" style="width: 10%;">
                                        Department
                                    </td>
                      </tr>
       </HeaderTemplate>
       <ItemTemplate>
        <tr>
                                    <td align="center">
                                       <%# Eval("rownum") %>
                                    </td>
                                   <td align="center">
                                    <asp:HiddenField ID="hdnCandCode" runat="server" Value='<%# Eval("candidate_code") %>' />
                                      <a id="aRefno" runat="server" target="_blank"> <%# Eval("RefNo")%></a>
                                    </td>
                                    <td valign="top">
                                   
                                   <table style="margin: 5px 5px 5px 5px;"><tr><td align="left" valign="top" width="30%"><b> Name </b>:</td><td align="left"> <%# Eval("Full_Name")%></td></tr>
                                   <tr><td align="left" valign="top" width="30%"> <b>Status:</b></td><td align="left">  <%# Eval("CandidateStatus")%></td></tr>
                                    <tr><td align="left" valign="top" width="30%"><b>Category:</b></td><td align="left">  <%# Eval("CategoryName")%></td></tr>
                                    <tr><td align="left" valign="top" width="30%"><b>Date:</b> </td><td align="left"> <%# Eval("ApplyDate")%></td>
                                    </tr></table>
                                       
                                    </td>
                                    <td  valign="top">
                                        <span style="font-family: 'Open Sans';font-size: 11px;color: #333;"><%# Eval("lastQualification")%></span>
                                    </td>
                                    <td  valign="top">
                                      <span style="font-family: 'Open Sans';font-size: 11px;color: #333;"><%# Eval("lastExperience")%></span>
                                    </td>
                                    <td  valign="top" >
                                     <table style="margin: 5px 5px 5px 5px;">
                                        <tr><td align="left" valign="top" width="20%"><b>Email:</b></td><td><%# Eval("FullEmail") %></td></tr>
                                         <tr><td align="left" valign="top" width="20%"> <b>Cell:</b></td><td> <%# Eval("cell") %></td></tr>
                                       <tr><td align="left" valign="top" width="20%"> <b>Phone:</b></td><td> <%# Eval("Phone") %></td></tr>
                                       <tr><td align="left" valign="top" width="20%"> <b>City:</b></td><td>  <%# Eval("City") %> </td></tr></table>
                                    </td>
                                    <td align="center"   >
                                       <%# Eval("Department") %> 
                                              </td>
                      </tr>                      
       </ItemTemplate>
       </asp:Repeater></table>
       <table id="pagging" runat="server" style="margin-top:10px;margin-left: -38px;" width="90%">
       <tr>
        <td align="right">
          <asp:LinkButton ID="lnkback" runat="server" Text="" OnClick="lblBack_Click">
          <img src="../assets/images/Back.png" alt="" height="30" width="30"/>
          </asp:LinkButton>
          &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnknext" runat="server" Text=""  OnClick="lbl_Click">
        <img src="../assets/images/next.png" alt="" height="30" width="30"/>
        </asp:LinkButton>     
           <%-- <asp:PlaceHolder ID="plcPaging" runat="server" />--%>
        </td>
    </tr>
    <tr><td align="right">  <asp:Label ID="lblPagging" runat="server" Font-Bold="true"></asp:Label></td></tr>
</table>
       </div>
     
    </section>
    </div>
    <script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../assets/js/MultipleItemSelection/jQuery.Tokeninput.js" type="text/javascript"></script>
    <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="../assets/js/jquery.multiselect.js" type="text/javascript"></script>
    <script src="../assets/js/jquery.multiselect.filter.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"


            });
        });

        $(function () {
            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });

        //debugger;
        // $("#ctl00_BodyContent_ddlDomain").multiselect().multiselectfilter();
        $("#ctl00_BodyContent_ddlDomain").multiselect({
            multiple: true,
            header: false,
            noneSelectedText: "Select Department",
            selectedList: 100,
            close: function (e) {

                var values = new Array();
                $(this).multiselect("getChecked").each(function (index, item) {

                    values.push($(item).val());
                });

                $("input[id*=" + this.getAttribute('hfValue') + "]").val(values.join(","));
            }
        }).multiselectfilter({
            filter: function (event, matches) {
                if (!matches.length) {
                    // do something
                }
            }
        });


        //        $(document).ready(function () {
        //            alert($('#<%= hfAgents.ClientID %>').val());
        //            if ($('#<%= hfAgents.ClientID %>').val() != '') {
        //                var selected = new Array();
        //                selected = $('#<%= hfAgents.ClientID %>').val().split(",");
        //                //alert(selected);
        //                $("#<%=ddlDomain.ClientID%> > option").each(function () {
        //                    if ($.inArray(this.value, selected) > -1) {
        //                      
        //                       
        //                        // alert(selected);
        //                        // alert(this.value);
        //                        $(this).attr("selected", "selected");
        //                        $(this).attr("aria-selected", "true");
        //                        alert($(this).attr('selected'));
        //                        alert($(this).attr('aria-selected'));

        //                    }
        //                });
        //                 $("#<%=ddlDomain.ClientID%>").multiselect('refresh');
        //            }
        //        });


        //        $("#txtCategory").tokenInput("../Handler/searchcategoryhandler..ashx?ID=1", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Category to Search"
        //        });
        //        $("#txtCity").tokenInput("../Handler/searchcategoryhandler..ashx?ID=2", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a City to Search"
        //        });
        //        $("#txtEducationLevel").tokenInput("../Handler/searchcategoryhandler..ashx?ID=3", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Education Level to Search"
        //        });
        //        $("#txtDegree").tokenInput("../Handler/searchcategoryhandler..ashx?ID=4", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Degree to Search"
        //        });
        //        $("#txtMajors").tokenInput("../Handler/searchcategoryhandler..ashx?ID=5", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Majors to Search"
        //        });
        //        $("#txtUniversity").tokenInput("../Handler/searchcategoryhandler..ashx?ID=6", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a University to Search"
        //        });
        //        $("#txtSkills").tokenInput("../Handler/searchcategoryhandler..ashx?ID=7", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Skills to Search"
        //        });
        //        $("#txtSKillSetE").tokenInput("../Handler/searchcategoryhandler..ashx?ID=7", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Skills to Search"
        //        });
        //        $("#txtCompany").tokenInput("../Handler/searchcategoryhandler..ashx?ID=8", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Company to Search"
        //        });
        //        $("#txtDesignation").tokenInput("../Handler/searchcategoryhandler..ashx?ID=9", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Designation to Search"
        //        });
        //        $("#txtRefUrl").tokenInput("../Handler/searchcategoryhandler..ashx?ID=10", {
        //            theme: "facebook",
        //            preventDuplicates: true,
        //            minChars: 0,
        //            hintText: "Type a Department to Search"
        //        });


        function Bind(j, ctrl) {
            var jObj = JSON.parse(j);

            for (var i = 0; i <= jObj.length - 1; i++) {

                $("#" + ctrl).tokenInput("add", jObj[i]);
            }
        }
        


    </script>
</asp:Content>

