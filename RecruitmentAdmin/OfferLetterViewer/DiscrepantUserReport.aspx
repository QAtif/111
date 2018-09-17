<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="DiscrepantUserReport.aspx.cs" Inherits="XRecruitmentAdmin.OfferLetterViewer.DiscrepantUserReport" %>

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
<script src="<%=Page.ResolveUrl("~")%>assets/inc-Signup/calendar/calendar.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>assets/inc-Signup/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>assets/inc-Signup/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="<%=Page.ResolveUrl("~")%>assets/css/calendar-win2k-cold-1.css" />


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
			height:30px;
        }

        table td {
            font-size: 14px;
			padding-left:0.5% !important;
        }
 .Lable  {width:20% !important;
        }
    </style>
<script type="text/javascript">
        $(document).ready(function () {
            $('#txtFromDate').attr('readonly', 'readonly');
            $('#txtToDate').attr('readonly', 'readonly');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="searcharea" class="searcharea">

        <div class="SearchBox adjustwidth" style="margin-top: 3% !important;">
            <div class="InsideSearchBox">
                <div class="HeadingInside">
                    <span class="BasicInfoIcon"></span><span class="IconTxt">Search</span>
                    <span class="borderHeader"></span>
                </div>
                <!-- #HeadingInside -->
                <div class="basicSearchArea">
                    <div class="BasicLeft">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                From Date
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <input runat="server" width="50px" type="text" id="txtFromDate" style="width: 120px"
                                    clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                        height="16" id="img1" />
                                <script type="text/javascript">
                                    Calendar.setup({
                                        inputField: "txtFromDate",      // id of the input field
                                        ifFormat: "M dd, y",       // format of the input field
                                        //ifFormat       :    "y-M-dd",       // format of the input field
                                        //ifFormat       :    "M-dd-y",       // format of the input field
                                        button: "img1",   // trigger for the calendar (button ID)
                                        singleClick: true            // double-click mode
                                    });
                                </script>
                            </div>
                            <!-- #InputField -->
                        </div>
						<div class="FieldWrapper">
                            <div class="Lable">
                               Reference No.
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                               <asp:TextBox runat="server" width="50px" id="txtRefNo" style="width: 120px" maxlength="50" clientidmode="Static"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>

                    <div class="SectionDiv">
                    </div>
                    <div class="BasicRight">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                To Date
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <input runat="server" width="50px" type="text" id="txtToDate" style="width: 120px"
                                    clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                        height="16" id="img2" />
                                <script type="text/javascript">
                                    Calendar.setup({
                                        inputField: "txtToDate",      // id of the input field
                                        ifFormat: "M dd, y",       // format of the input field
                                        //ifFormat       :    "y-M-dd",       // format of the input field
                                        //ifFormat       :    "M-dd-y",       // format of the input field
                                        button: "img2",   // trigger for the calendar (button ID)
                                        singleClick: true            // double-click mode
                                    });
                                </script>
                            </div>
                            <!-- #InputField -->
                        </div>
						  <div class="FieldWrapper">
                            <div class="Lable">
                               Name
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox runat="server" width="50px" id="txtName" style="width: 120px" maxlength="50" clientidmode="Static"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>
                    <!-- #FieldWrapper -->
  <div class="SectionDiv second">
                    </div>
                     <div class="BasicRight last">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Domain
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:DropDownList runat="server" ID="ddlDomain"></asp:DropDownList>
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>

                    <!-- #BasicRight -->
                </div>
                <!-- #basicSearchArea -->
            </div>

            <div class="clearfix">
            </div>
            <div class="BorderDiv">
            </div>
            <div class="ButtonsSave" id="btnSearchF">
                <asp:Button ID="btnSearch" runat="server" class="SubmteForm" Text="Search" OnClick="btnSearch_Click" />

<asp:Button ID="btnExportToExcel" runat="server" class="SubmteForm" Text="Export To Excel" OnClick="btnExportToExcel_Click" />
<asp:Button ID="btnClearFilter" runat="server" class="SubmteForm" Text="Clear Filter" OnClick="btnClearFilter_Click" />
                <%--OnClick="BtnSearchFresh_Click"--%>
            </div>
        </div>
    </div>
    <div id="sortable" class="main-wrapper newscreen">
        <!-- Main Content Here -->
        <section class="main-content accordsec">
      <div class="main-accrodian">
        <ul id="UlMain">
    <div class="user-profile-main onlyinfoboxes">
        <div class="user-profile-main onlyinfoboxes">
            <div class="user-profile-warpper"  style="height:auto;">
                <div class="user-detail">
				<h1 style="padding-left: 2% !important;">Discrepant User Detail</h1>
                    <div class="p-padding">
                         <asp:Repeater ID="rptCustomizeUsers" runat="server" OnItemDataBound="rptCustomizeUsers_ItemDataBound">
                            <HeaderTemplate>
                        <table style="width:98%">
                            <tr>
                                <th style="width:3%" align="center" class="bol bob bot"  background="/assets/css/images/tbg2.gif">SNo.</th>
								<th style="width:6%" align="center" class="bol bob bot"  background="/assets/css/images/tbg2.gif">User ID</th>
								<th style="width:10%;" align="center" class="bol bob bot" background="/assets/css/images/tbg2.gif">Ref. #</td>
                                <th style="width:20%" align="center"  class="bol bob bot"  background="/assets/css/images/tbg2.gif">User Detail</th>
                                <th style="width:17%" align="center" class="bol bob bot bor" background="/assets/css/images/tbg2.gif">Salary</th>    
                                <th style="width:32%" align="center" class="bol bob bot bor" background="/assets/css/images/tbg2.gif">Car</th>       
                                <th style="width:12%" align="center" class="bol bob bot bor" background="/assets/css/images/tbg2.gif">Mobile</th>        
                               <%-- <th style="width:4%"   class="bol bob bot bor">Water Allowance</th>    
                                <th style="width:10%"  class="bol bob bot bor">Servant</th> --%>   
                               
                            </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                            <tr  id="trRec" runat="server" >
                                <td style="width:3%" align="center" class="bol bob"><%#Eval("ID") %></td>
                                <td style="width:6%" align="center" class="bol bob"><asp:Label ID="lblUserID" runat="server"></asp:Label></td>
								 <td style="width:10%" align="center" class="bol bob"> <a id="aCandidateLink" runat="server"  target="_blank"> <%# Eval("Candidate_ID")%></a>
								 <br/>( <%# Eval("StatusName")%> )</td>
                                <td style="width:20%" class="bol bob">
                                    <b><%#Eval("Full_Name") %></b> 
                                                                    
  <div style="width:100% !important;"><%#Eval("Designation_Name") %> 
                                                                      ( <a  class="editicon popnewform" id="lnkPackage" runat="server" href="javascript:" >
                                            <%#Eval("Grade")%></a> )
                                        </div>
                                    <%#Eval("Domain_Name") %>
                                    <br /><%#Eval("JoiningDate") %>
                                    <br /><%#Eval("City") %>
                                </td>
                                <td style="width:17%"  class="bol bob bor">
                                   <b>Salary:</b>  <%#Eval("TotalSalary") %>
                                    <br/><b>International Salary: </b><%#Eval("SalaryForInternationalPackage") %>
                                </td>
                                  <td style="width:32%" class="bol bob bor">
                                    <b>Office:</b> <%#Eval("OfficeCarName") %> 
                                    <br /><b>Fuel (Office):</b> <%#Eval("OfficeFuelAllowance") %> Liters 
                                 <br /><asp:Label ID="lblHomeCar" runat="server"></asp:Label> 

                                </td>
                               
                                <td style="width:12%" class="bol bob bor">
                                   <b>Mobile 1:</b> <%#Eval("MobileName") %> 
                                  <br /><b>SIM 1:</b> Rs <%#Eval("MobileAllowance") %>
                                    <br /><asp:Label ID="lblMobileHome" runat="server"></asp:Label> 
                                </td>
                               
                            </tr>
                           <%-- <tr runat="server" id="trNoRec">
                                <td colspan="4" width="100%" align="center" class="bol bob bor"> No Record Found</td>
                            </tr>--%>
                                </ItemTemplate>
                            <FooterTemplate>
                        </table>
                                </FooterTemplate>
                            </asp:Repeater>
<div id="divNoRcrd" align="center" runat="server" visible="false"><span> No Record Found</span></div>
                         <div class="BorderDiv">
            </div>
                        <br />
                        <br />
            
                    </div>
                </div>
 <table width="100%" id="tblPaging" runat="server" style="border: 0; margin-bottom: 1%;">
               <tr id="trPaging" runat="server">

                    <td style="border: 0;" width="25%" align="right">
                        <span style="padding-right: 15px;">Total Record(s):
                            <asp:Label ID="lblTotalRec" runat="server"></asp:Label></span>
                        <span style="padding-right: 20px;">Page:
                <asp:DropDownList ID="ddlPageNum" runat="server" AutoPostBack="true" Style="width: 45px;" OnSelectedIndexChanged="ddlPageNum_SelectedIndexChanged">
                </asp:DropDownList></span>
                        <span style="padding-right: 20px;">Page Size:
                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" Style="width: 50px;" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                    <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="25" Value="25" ></asp:ListItem>
                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                </asp:DropDownList>
                        </span>
                        &nbsp;
                    </td>
                    <td style="border: 0;" width="10%" align="left">

                        <asp:LinkButton ID="IbtnPrevious" runat="server" Font-Bold="True" Font-Size="Larger"
                            Font-Underline="False" ToolTip="First Page" OnClick="IbtnPrevious_Click" Enabled="false"><</asp:LinkButton>&nbsp;
                &nbsp;<asp:LinkButton ID="IbtnNext" runat="server" Font-Bold="True" Font-Size="Larger"
                    Font-Underline="False" ToolTip="Last Page" OnClick="IbtnNext_Click" Enabled="false">></asp:LinkButton>&nbsp;
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </div>
            </ul>
          </div>
            </section>
    </div>



</asp:Content>
