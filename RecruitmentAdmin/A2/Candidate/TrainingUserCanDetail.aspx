<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="TrainingUserCanDetail.aspx.cs" Inherits="A2_Candidate_TrainingUserCanDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700' rel='stylesheet'
        type='text/css' />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/style.css" />
    <!--[if lt IE 9]><script type="text/javascript" src="/A2/assets/js/html5.js"></script><![endif]-->
    <style type="text/css">
        .taglinks
        {
            display: block;
            background: #CDE2F6;
            border: 1px solid #BFDAF7;
            color: #036;
            font-size: 11px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 05px 10px 05px 4px;
            float: left;
            margin-right: 5px;
            margin-top: 10px;
        }
        #showthebloodydiv:hover #AimgEdit
        {
            display: block !important;
        }
        .error
        {
            /* background: #FFD9D9 !important; */
            border: 1px solid #C00 !important;
        }
        .RefText
        {
            display:inline;
            }
    </style>
    <script language="javascript" type="text/javascript">
        function Validate() {
            if ($('#ctl00_BodyContent_txtRefNo').val() != '') {
                $('#ctl00_BodyContent_txtRefNo').removeClass('error');
                return true;

            }
            else {
                $('#ctl00_BodyContent_txtRefNo').addClass('error');
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <noscript>
        <div id="jqcheck">
            <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAB60lEQVQ4T2NkwAHePzrxf3ebL1jWp/0oA5egGiM2pVgFQQq31uj/N/ANZvj+8T3D7aNHGDwbTxNvwKtbO/9f3dLHYJ+axfDn5w+GI/NnMRhFtTEISJtjGIIh8Pv39/87ak0ZzCLiGMRUNMCufnLxDMOlrZsY3JtOMrCwsKPowTDg3tGZ/59f2sVgFRvPkO+bAzZgwsZJDEcXzWNQtIlikDGIwG3Az+9v/+9qsGOwTc1h4JeQhhswcfMUhrcP7zEcXzyXwb3xMAMbuwDcEBTTzi7P/s/M8IFB3zccbDPMBSADQODs2sUMzFwyDIah/ZgGfHt/7/+BvmAGm+RsBl4RMawGfHr5jOHowlkMjiUbGDj55MCGwE060Of1X0RZi0Hb2Q4e3eguAElc2X2A4e2DmwwOhVsRBnx6cfH/yXm5DFZxyQxcAoJ4Dfj24T3DsUVzGcwSJjLwSxkygk3ZVmv4X805gkHZRBNXwkQRv3/+NsP1nUsYvFvOMzI+PLXo/73DSxgsouIYOHj5UBRi8wJIwY8vnxlOLV/CIGcewsC4vkDhv01yLoOIoiqG7bgMACn88Owxw8HpvQyMGwqV/vs19TMwQnxDEthYW8DAeGCC3/9XN46TpBGmWEzDkoHx06dP/z9//kyWAby8vAwAcza2SBMOSCMAAAAASUVORK5CYII="
                alt="">
            Javascript is disabled. Please enable it for better working experience.</div>
    </noscript>
    <div class="overlay">
    </div>
    <div class="ShowAllDataGrid">
        <section class="wrapit topmenu " style="margin-left:auto; margin-right:auto;float:none !important;width: 73% !important;min-width:73% !important; max-width: 73% !important;"> <span class="msearch"><i class="deptstruct-icon"></i> Candidate Profile</span>
         <asp:TextBox placeholder="Enter Reference #" ID="txtRefNo" runat="server" style="right: 250px;top: 124px;position: absolute;height: 21px;width: 181px;border-color: #CDD4E4;">
         </asp:TextBox> 
           <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Btn_SearchByRefno" ValidationGroup="RefNoFilter"
               style="top: 122px;position: absolute;right: 196px;" OnClientClick="Javascript:return Validate();"> <img src="../assets/images/SearchBtn.jpg" height="30" width="40" /> </asp:LinkButton>
         </section>
        <section class="container-two-col" style="margin: 13px auto 10px auto;"  id="DivDetail" runat="server">
    	<article class="LeftContainer" style="margin-left:auto; margin-right:auto;float:none !important">        
        <table class="main">
          <tr>
            <td rowspan="2">
            	<table class="picarea">
                  <tr>
                      <td>
                      <div id="showthebloodydiv" style="position:relative;">
                        <a id="ABigImage" runat="server" href="#frame-sets" title=""  class="poptheform">
                        <img id="imgCandidate" runat="server" src="/A2/assets/images/users/img1.jpg" width="100" height="100" alt="">
                        </a>                        
                      </div>
                      
                   
                      </td>
                    </tr>
                  <tr style="display:none;">
                    <td>
                    <a href="javascript:;" title="">Details<i class="icon-detail"></i></a>
                    </td>
                  </tr>
                 
                </table>
            </td>
            <td colspan="2"> <h4><asp:Label ID="lblCanName" runat="server"></asp:Label></h4>
            <div style="float:right;">   <asp:Image ID="imgStaff" runat="server" Height="30" Width="30" ImageUrl="../assets/images/SupportStaff.jpg" /> </div>
            </td>
          </tr>
          <tr>
            <td>
            <table class="detailbox1">
                  <tr>
                    <td><span>Reference No.</span></td>
                    <td> <asp:Label ID="lblRefNo" runat="server"></asp:Label></td>
                  </tr>
    <tr>
        <td>
            <span>Gender</span>
        </td>
        <td>
            <asp:Label ID="lblGender" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <span>Religion</span>
        </td>
        <td>
            <asp:Label ID="lblReligion" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <span>Marital Status</span>
        </td>
        <td>
            <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <span>Nationality</span>
        </td>
        <td>
            <asp:Label ID="lblNationality" runat="server"></asp:Label>
        </td>
    </tr>
    </table></td>
    <td>
        <table class="detailbox2">
        <tr>
                <td>
                    <span>Joining Date </span>
                </td>
                <td>
                <span id="SpJoiningDate" runat="server"></span>
                   </td>
                            
            </tr>
             <tr>
                <td>
                    <span>Domain</span>
                </td>
                <td>
             <span id="SpDomain" runat="server"></span>
                   </td>
                            
            </tr>
             <tr>
                <td>
                    <span>Sub Domain</span>
                </td>
                <td>
              <span id="SpSubDomain" runat="server"></span>
                   </td>
                            
            </tr>
             <tr>
                <td>
                    <span>Grade </span>
                </td>
                <td>
               <span id="SpGrade" runat="server"></span>
                   </td>
                            
            </tr>
             <tr>
                <td>
                    <span>Designation</span>
                </td>
                <td>
               <span id="SpDesignation" runat="server"></span>  
                   </td>
                            
            </tr>
    

     
              

    </table> </td> </tr> </table>
    <div class="tab-container">
        <ul class="controllers" style="width:167px !important">
            <li><a href="javascript:;" title="" data-rel="experience" class="active"><i class="icon1">
            </i>Experience</a></li>
            <li><a href="javascript:;" title="" data-rel="education"><i class="icon2"></i>Education</a></li>
            <li><a href="javascript:;" title="" data-rel="diploma"><i class="icon3"></i>Diploma</a></li>
            <li><a href="javascript:;" title="" data-rel="certification"><i class="icon4"></i>Certification</a></li>
            <li><a href="javascript:;" title="" data-rel="portfolio"><i class="icon5"></i>Portfolio</a></li>
    
             
        </ul>
        <div class="TabsBoxes" style="width:70%">          
            <div class="box-experience box active">
                <h4>
                    Experience &nbsp;&nbsp; <asp:Label ID="lblTotalExp" runat="Server"></asp:Label>
                </h4>
                <span class="history" id="divAction88" visible="false" runat="server" clientidmode="Static">
                    <a id="aEditExperience" runat="server" title="" class="editicon popnewform"></a>
                </span>
                <asp:Repeater ID="rptExperience" runat="server" OnItemDataBound="RptExperienence_ItemDataBound">
                    <ItemTemplate>
                        <table class="detailbox1">
                            <tbody>
                                <tr class="first">
                                    <td rowspan="6" class="first">
                                        <img src='<%# Eval("LogoPath") %>' width="56" height="56" alt="">
                                    </td>
                                    <td class="first">
                                        <span>Company</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Company") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Job Title</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Position_title") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Responsibilities</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Responsibilties_Included")%>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="first">
                                        <span>Reason for leaving</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("ReasonForLeaving")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Duration</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("jobStart_Date") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Current Salary</span>
                                    </td>
                                    <td class="last">
                                        Rs.
                                        <%# Eval("Current_Salary") %>
                                    </td>
                                </tr>
                                <tr class="last">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Initial Salary</span>
                                    </td>
                                    <td class="last">
                                        Rs.
                                        <%# Eval("Initial_Salary") %>
                                    </td>
                                </tr>
                                <tr class="last">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Cash Allowance</span>
                                    </td>
                                    <td class="last">
                                        <span id="SpCashAll" runat="server"></span>
                                    </td>
                                </tr>
                                 <tr class="last">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Benefits</span>
                                    </td>
                                    <td class="last">
                                        <span id="SpBenefit" runat="server"></span>
                                    </td>
                                </tr>
                                 <tr class="last">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Life Style</span>
                                    </td>
                                    <td class="last">
                                        <span id="SpLifeStyle" runat="server"></span>
                                    </td>
                                </tr>
                                 <tr class="last">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Off Days</span>
                                    </td>
                                    <td class="last">
                                        <span id="SPOffDays" runat="server"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <a href="javascript:;" class="toggle-history activehis">Show History</a>
                <div class="historytbl" id="tblExpHistory" runat="server">
                    <div>
                        <h4>
                            History</h4>
                        </strong></div>
                    <table>
                        <asp:Repeater ID="rptCandidateExHistory" runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <th>
                                        S.No
                                    </th>
                                    <th>
                                        Company
                                    </th>
                                    <th>
                                        City
                                    </th>
                                    <th>
                                        Position
                                    </th>
                                    <th>
                                        Start Date
                                    </th>
                                    <th>
                                        End Date
                                    </th>
                                    <th>
                                        Current Salary
                                    </th>
                                    <th>
                                        Initial Salary
                                    </th>
                                    <th>
                                        Updated By
                                    </th>
                                    <th>
                                        Updated Date
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Company")%>
                                    </td>
                                    <td>
                                        <%# Eval("City")%>
                                    </td>
                                    <td>
                                        <%# Eval("Position_Title")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "jobStart_Date", "{0:MMM dd, yyyy}")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "JobEndDate", "{0:MMM dd, yyyy}")%>
                                    </td>
                                    <td>
                                        <%# Eval("Current_Salary")%>
                                    </td>
                                    <td>
                                        <%# Eval("Initial_Salary")%>
                                    </td>
                                    <td>
                                        <%# Eval("Edit_By")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "LastUpdated_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <asp:Label ID="lblinfoExp" runat="server" Text="No professional experience found."></asp:Label>
            </div>
            <div class="box-education box ">
                <h4>
                    Education
                </h4>
                <span class="history" id="divAction89" visible="false" runat="server" clientidmode="Static">
                    <a id="aEditEducation" runat="server" href="javascript:;" title="" class="editicon popnewform">
                    </a></span>
                <asp:Repeater ID="rptEducation" runat="server">
                    <ItemTemplate>
                        <table class="detailbox1">
                            <tbody>
                                <tr class="first">
                                    <td rowspan="6" class="first">
                                        <img src='<%# Eval("LogoPath") %>' width="50" height="50" alt="">
                                    </td>
                                    <td class="first">
                                        <span>Institute Name</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("institute") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Level of Education</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Program_Name") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Field of Study</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Degree") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Majors</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Major_Name") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Duration</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Duration") %>
                                    </td>
                                </tr>
                                <tr class="last">
                                    <td class="first">
                                        <span>Marks Scored</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Percentage") %>
                                    </td>
                                </tr>
                                <tr class="last" style="display: none">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Position</span>
                                    </td>
                                    <td class="last">
                                        <ul class="blueblocks">
                                            <li class="first even">Searching</li>
                                            <li class="odd">Socializing</li>
                                            <li class="even">Teaching</li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr class="last" style="display: none">
                                    <td class="first">
                                        &nbsp;
                                    </td>
                                    <td class="first">
                                        <span>Extra Curricular
                                            <br>
                                            Activities</span></td>
                                    <td class="last">
                                        <ul class="blueblocks">
                                            <li class="first even">Playing Game</li>
                                        </ul>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblinfoEdu" runat="server" Text="No educational information found."></asp:Label>
                <a href="javascript:;" class="toggle-history activehis">Show History</a>
                <div class="historytbl" id="trQaHistory" runat="server" clientidmode="Static">
                    <div>
                        <h4>
                            History</h4>
                        </strong></div>
                    <table>
                        <asp:Repeater ID="rptQaHistory" runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <th>
                                        Institute
                                    </th>
                                    <th>
                                        Degree
                                    </th>
                                    <th>
                                        Program_Name
                                    </th>
                                    <th>
                                        Major_Name
                                    </th>
                                    <th>
                                        Start_Date
                                    </th>
                                    <th>
                                        EndDate
                                    </th>
                                    <th>
                                        Grade
                                    </th>
                                    <th>
                                        Position
                                    </th>
                                    <th>
                                        Activities
                                    </th>
                                    <th>
                                        UserType
                                    </th>
                                    <th style="width: 10%">
                                        Date
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("Program_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Major_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("EndDate")%>
                                    </td>
                                    <td>
                                        <%# Eval("Grade")%>
                                    </td>
                                    <td>
                                        <%# Eval("Position")%>
                                    </td>
                                    <td>
                                        <%# Eval("Activities")%>
                                    </td>
                                    <td>
                                        <%# Eval("UserType")%>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <div class="box-diploma box">
                <h4>
                    Diploma
                </h4>
                <span class="history" id="divAction93" visible="false" runat="server" clientidmode="Static">
                    <a id="aDiploma" runat="server" href="javascript:;" title="" class="editicon popnewform">
                    </a></span>
                <asp:Repeater ID="rptDiploma" runat="server">
                    <ItemTemplate>
                        <table class="detailbox1">
                            <tbody>
                                <tr class="first">
                                    <td rowspan="4" class="first">
                                        <img src='<%# Eval("LogoPath") %>' width="50" height="50" alt="">
                                    </td>
                                    <td class="first">
                                        <span>Institute Name</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("institute") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Diploma Title</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Program_Name") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Field of Study</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Degree") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Duration</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Duration") %>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblinfoDiploma" runat="server" Text="No diploma found."></asp:Label>
            </div>
            <div class="box-certification box ">
                <h4>
                    Certification
                </h4>
                <span class="history" id="divAction94" visible="false" runat="server" clientidmode="Static">
                    <a id="aCertificate" runat="server" href="javascript:;" title="" class="editicon popnewform">
                    </a></span>
                <asp:Repeater ID="rptCertificate" runat="server">
                    <ItemTemplate>
                        <table class="detailbox1">
                            <tbody>
                                <tr class="first">
                                    <td rowspan="4" class="first">
                                        <img src='<%# Eval("LogoPath") %>' width="50" height="50" alt="">
                                    </td>
                                    <td class="first">
                                        <span>Institute Name</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("institute") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Certification Title</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Program_Name") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Field of Study</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Degree") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="first">
                                        <span>Duration</span>
                                    </td>
                                    <td class="last">
                                        <%# Eval("Duration") %>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblinfoCertificate" runat="server" Text="No certificates found."></asp:Label>
            </div>
            <div class="box-portfolio box">
                <h4>
                    Portfolio
                </h4>
                <span class="history" id="divActio" visible="false" runat="server"><a href="javascript:;"
                    title="" class="editicon popnewform" id="aPortfolio" runat="server"></a></span>
                <table>
                    <tr>
                        <td>
                            <h3>
                                <span>Attached Files</span>
                            </h3>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <asp:Repeater ID="rptPortfolioFiles" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img src='<%# Eval("LogoPath") %>' alt="" width="102" height="102">
                                            <strong>
                                            <a id="A1" href='<%# Eval("FILEPATH") %>' runat="server" ToolTip='<%# Eval("fullFileName") %>' target="_blank"> <%# Eval("FILENAME") %></a>
                                                <%--<asp:LinkButton ID="lbedit" runat="server" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidatePortfolioFile_Code")%>'
                                            CausesValidation="false" Text='<%# Eval("FILENAME") %>' ToolTip='<%# Eval("fullFileName") %>' />--%>
                                              </strong>

                                            <%# Eval("FileSize") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPortFiles" runat="server" Text="No portfolio files found."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h3>
                                <span>URLs</span>
                            </h3>
                        </td>
                    </tr>
                    <asp:Repeater ID="rptPortfolioUrl" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <label>
                                        <%# Eval("URLTitle")%>
                                    </label>
                                    <a href='<%# Eval("URL")%>' title="">
                                        <%# Eval("URL")%>
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td>
                            <asp:Label ID="lblPortURL" runat="server" Text="No portfolio URL found."></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
       

        </div>
    </div>
    </article>
   
    </section>
        <!-- Page action -->
      
    </div>
    <div id="frame-sets" style="display: none;">
        <div>
            <img id="imgBigImage" runat="server" alt="" /></div>
    </div>
    
</asp:Content>