<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="offerApprovalCOOPending.aspx.cs" Inherits="A2_Reports_offerApprovalCOOPending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $('#selectall').trigger('change');
        function onpress() {
            //debugger;
            //$('#id_search_list').quicksearch('#UlMain>li');
            expandAll();
            $('#id_search_list').quicksearch('#UlMain>li');
        }
        //        $('#selectall').on('click', function () {
        //            $('.selectedId').attr('checked', $(this).is(":checked"));
        //        });
        function toggleCheck(chk, id) {
            var frm = chk.parentNode.parentNode.parentNode.parentNode.getElementsByTagName('input')
            var controlID = chk.id;
            controlID = controlID.replace('_chkDept', '');

            for (var i = 0; i < frm.length; i++)
                if (frm[i].id.indexOf(controlID) > -1 && frm[i].id.indexOf(id) > -1 && frm[i].type == 'checkbox')
                    frm[i].checked = chk.checked;
        }
        function valthisform() {
            //debugger;
            var frm = document.getElementsByTagName('input')
            var okay = false;
            for (var i = 0; i < frm.length; i++) {
                if (frm[i].type == 'checkbox')
                    if (frm[i].checked) {
                        okay = true;
                    }
            }
            if (okay) {
                return confirm('Are you sure you want to Approve');
            }
            else {
                alert("Please Select atleast One Record.");
                return false;
            }
        }
        function SetValue(obj, obj1) {
            //debugger;
            //alert(obj1);
            document.getElementById('ctl00_BodyContent_hdnComments').value = obj + String.fromCharCode(obj1);
            //alert(document.getElementById('ctl00_BodyContent_hdnComments').value);
        }
        function expandAll() {
            //debugger;
            jQuery(".accrodian-content").show();

        }

        function expandAllTo(obj) {
            //debugger;
            //alert(obj);
            //alert(obj.id);
            jQuery('#' + obj).show();

        }
        function CollapsAll() {
            jQuery(".accrodian-content").hide();

        }

        
    
    </script>
    <%--<style type="text/css">
       .lastStatus
       {
            padding-left: 11px;
            display: block;
            float: right;
            width: 85px;
            padding-right: 11px;

       }
   
   </style>--%>
    <style type="text/css">
        .InnerTable td
        {
            align: center;
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:HiddenField runat="server" ID="hdnUserTypeCode" />
    <div class="ShowAllDataGrid resetcheck">
        <section class="wrapit topmenu offeraproval searchbar"> <div class="domain-name" style="padding:0"> 
        <span class="msearch showsrchbox" style="padding: 16px 0 9px 10px;"><input id="selectall" type="checkbox" style="margin: 0 7px 0 0;" name="checkIt"/>Offer Approval</span></div>
    <ul class="TopLeftMenu">
      <li class="last even searchhidden">
        <div class="srch-fix" >
        
         <input type="text"  name="" placeholder="Search By Department or Candidate"  value="" id="id_search_list" onkeyup="javascript:onpress();" />   
          <input type="submit" class="showsearchtxt" value="">
        </div>
      </li>
    </ul>
  </section>
        <table width="100%" style="background: transparent; border: 0px">
            <tr style="height:50px">
                <td align="center" style="background: transparent; border: 0px">
                    <b>Date From</b>
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 180px" />
                    <b>Date To</b>
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 180px" readonly="true" />
                </td>
            </tr>
            <tr style="height:30px">
                <td align="center" style="background: transparent; border: 0px">
                    <a href="javascript:;" id="A2" runat="server"></a>&nbsp;&nbsp; <span><b>
                        <asp:RadioButton runat="server" GroupName="officer" ID="rdoOfficer" AutoPostBack="true"
                            Text="Officer" Checked="true" OnCheckedChanged="rdoOfficer_CheckedChanged" /></b>
                        &nbsp;&nbsp; <b>
                            <asp:RadioButton runat="server" GroupName="officer" ID="rdoSupportStaff" AutoPostBack="true"
                                Text="Support Staff" Checked="false" OnCheckedChanged="rdoSupportStaff_CheckedChanged" /></b>
                    </span>
                </td>
            </tr>
            <tr style="height:30px">
                <td align="center" style="background: transparent; border: 0px">
                <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" 
                        onclick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td id="examplediv" align="right" style="background: transparent; border: 0px">
                    <a href="javascript:;" onclick="expandAll();" id="lnkexpend">
                        <image id="imgexpand" src="/A2/assets/images/expand.png" alt="" width="20px" height="20px"></image>
                    </a>&nbsp; |&nbsp; <a href="javascript:;" onclick="CollapsAll();" id="lnkCollaps">
                        <image id="imgexpand" src="/A2/assets/images/collapse.png" alt="" width="20px" height="20px"></image>
                    </a>
                </td>
            </tr>
        </table>
        </a>
        <div class="main-wrapper newscreen resetcheck" id="offrdiv">
            <!-- Main Content Here -->
            <section class="main-content">
                    
                    <div class="main-accrodian">
                        <ul><asp:HiddenField runat="server" ID="hdnComments" />
                            
                         <asp:Repeater ID="rptDeparments" runat="server" OnItemDataBound="rptDepartment_ItemDataBound">
             <ItemTemplate>
                            <li runat="server" id="liDept">
                                <div class="accordian-btn ">
                                    <div class="showcheckbox"> 
                                        <asp:CheckBox runat="server"  ID="chkDept" onclick="toggleCheck(this, 'chkCandCode');"  />
                  <asp:HiddenField ID="hdnDepCode" runat="server" Value='<%# Eval("Domain_Code") %>' />
                  <div><%# Eval("Domain_Name")%><i><%# Eval("DeptCount")%></i></div>
                                    </div>
                                </div>
                                <div class="accrodian-content" runat="server" id="dvContent" > 
                                 <ul id="UlMain">
                                     <asp:Repeater ID="rptCat" runat="server" OnItemDataBound="rptCat_ItemDataBound"  OnItemCommand="rptCat_CommandArguments">
             <ItemTemplate> <li>
                                    <div class="user-profile-main">
                                        
                                        <div class="user-profile-warpper">
                                            
                                            <div class="user-detail">
                                                <div class="p-padding" style="margin-bottom: 38px !important;">
                                                <asp:HiddenField ID="hdnCandCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                                                    <asp:CheckBox runat="server" ID="chkCandCode"  /> <a id="a1" runat="server"   target="_blank"><label class="p-name" style="float:none !important;cursor:pointer">
                                                    <%# Eval("Full_Name")%></label></a>
                                                    <span style="display:none"><%# Eval("Domain_Name")%></span>
                                                    <br />
                                                    <a id="ABigImage" runat="server" href='<%# Eval("Candidate_Code","#frame-sets{0}") %>' title=""  class="poptheform">
                                                    <img src='<%# Eval("ProfileImage_Path")%>' runat="server" id="imgProfile" class="avatar" width="70" height="70" alt="">
                                                    </a>  
                                                    <div id='<%# Eval("Candidate_Code","frame-sets{0}") %>' style="display: none;">
        <div><img id="imgBigImage" runat="server" alt="" width="500" height="500" /></div>
    </div>
                                                    <div class="p-grade">
                            <div class="grade-join left-side width95">
                                                        Reference #<br>
                                                        Profile<br>
                                                        Salary Quoted<br>
                                                        Bank Statement<br />                                                        
                                                        Status                                               
                                                        </div>
                                                        <div class="grade-join right-side width85">
                                                       <a id="aCandidateLink" runat="server"  target="_blank"> <%# Eval("Candidate_ID")%></a><br>
                                                       <%# Eval("Profile")%><br>
                                                       Rs. <%# Eval("SalaryDemanded")%><br>
                                                       <%# Eval("BankStatement")%><br />                                                        
                                                       <%# Eval("LastStatus") %><%# Eval("LastStatusBy") %>
                                                        
                                                        </div>
                                                   </div>
                                                </div>
                                            </div>
                                            
                                            <div class="user-growth">
                                                <div class="p-padding">
                                                    <h5>Highest Academic Qualification</h5>
                                                    <div class="grade-join left-side width88">
                                                        Degree<br>
                                                        Institute<br>
                                                        CGPA/Grades<br>
                                                        Passing Year<br><br>
                                                        Majors
                                                        </div>
                                                    <div class="grade-join right-side width180">
                                                       <asp:Label runat="server" id="lblDegree"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblInstitute"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblGPA"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblPassingYear"></asp:Label><br><br>
                                                       <asp:Label runat="server" id="lblMajorName"></asp:Label>
                                                        </div>
                                                </div>
                                            </div>
                                            
                                            <div class="user-grade">
                                                <div class="p-padding">
                                                    <h5>Last Professional Experience</h5>
                                                    
                                                    <div class="grade-join left-side width99">
                                                        Salary<br>
                                                        Duration<br>
                                                        Company<br>
                                                        Job Title<br><br>
                                                        Total Experience
                                                        </div>
                                                    <div class="grade-join right-side">
                                                       Rs. <asp:Label runat="server" id="lblSalary"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblDuration"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblCompany"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblJobTitle"></asp:Label><br><br>
                                                       <asp:Label runat="server" id="lblTotalExperience"></asp:Label>
                                                        </div>
                                                </div>
                                            </div>
                                            
                                            <div class="user-ranking">
                                                <div class="p-padding">
                                                    <h5>Offer from Axact</h5>
                                                    <div class="grade-join left-side width88">
                                                        Grade<br>
                                                        Salary<br>
                                                        Department<br>
                                                        Position<br>
                                                        Team<br>     
                                                        Shifts<br>                                                   
                                                        Assigned JD<br>
                                                        Unit
                                                        </div>
                                                    <div class="grade-join right-side">
                                                       <%# Eval("Grade_Name") %><br>
                                                       Rs. <%# Eval("OfferedSalary") %><br>
                                                       <asp:Label runat="server" id="lblDomain_Name"></asp:Label><br>
                                                       <asp:Label runat="server" id="lblDesignation" Text='<%# Eval("Designation_Name") %>'></asp:Label><br>
                                                       <%# Eval("Team_Mapping") %><br>    
                                                       <%# Eval("Shifts") %><br>                                                   
                                                       <asp:Label runat="server" id="lblCansideredForJD" Text='<%# Eval("CansideredForJD") %>'></asp:Label><br>
                                                       <%# Eval("Unit") %>
                                                        </div>
                                                    
                                                </div>
                                            </div>
                                            
                                             
                                            <div id="divAction" runat="server" style="text-align:center" clientidmode="Static" class="p-padding">
                                                
                                                 <div id='<%# Eval("Candidate_Code","ApproveHR{0}") %>' style="display: none; width:500px;height:300px">
                                                
                                                        <div style="padding-top:15px;padding-left:15px" class="ButtonsSave">
                                                            <font face="Verdana, Arial, Helvetica, sans-serif" size="2"><strong>Enter Comments : </strong></font>
                                                        <asp:TextBox runat="server" Width="450px" onkeypress="SetValue(this.value,event.keyCode);" Height="180px" TextMode="MultiLine" ID="txtApproveHR" 
                                                        ></asp:TextBox>
                                                        <br />
                                                        <div style="padding-top:8px;">
                                                        <asp:LinkButton Text="Submit" CssClass="SubmteForm" ID="LinkButton5" runat="server" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                            CommandName="ApproveHR" ></asp:LinkButton> </div>
                                                        </div>
                                                </div>
                                                 <div id='<%# Eval("Candidate_Code","RejectHR{0}") %>' style="display: none; width:500px;height:300px">
                                                
                                                        <div style="padding-top:15px;padding-left:15px" class="ButtonsSave">
                                                            <font face="Verdana, Arial, Helvetica, sans-serif" size="2"><strong>Enter Comments : </strong></font>
                                                        <asp:TextBox runat="server" Width="450px" onkeypress="SetValue(this.value,event.keyCode);" Height="180px" TextMode="MultiLine" ID="txtRejectHR" 
                                                        ></asp:TextBox>
                                                        <br />
                                                        <div style="padding-top:8px;">
                                                        <asp:LinkButton Text="Submit" CssClass="SubmteForm" ID="LinkButton6" runat="server" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                            CommandName="DisapproveHR" ></asp:LinkButton> </div>
                                                        </div>
                                                </div>  
                                                <div class="p-padding">
                                                    <h5>COO&acute;s Decision</h5>                                                        
                                                
                                                 <ul class="updateState">
                                                            <li class="approve">
                                                <asp:LinkButton href='<%# Eval("Candidate_Code","#ApproveHR{0}") %>'
                                                     class="poptheform" ID="lnkApproveHR" runat="server" ToolTip="Approve"> <img style="margin-top:5px" id="img2" src="../assets/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                
                                                
                                                  </li>
                                                
                                                            <li class="reject">          
                                                <asp:LinkButton href='<%# Eval("Candidate_Code","#RejectHR{0}") %>'
                                                     class="poptheform" ID="LinkButton7" runat="server" ToolTip="Disapprove"> <img style="margin-top:5px" id="img3" src="../assets/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                </li></ul></div> 
                                            </div>
                                            
                                            
                                            <br class="clearfix">
                                            
                                        </div>
                                    
                                        <div class="profile-tabs-warper">
                                        
                                            <ul class="tabs_btns">
                                                <li><a title="Personal Details" href="#personal-details"></a></li>
                                                <li><a title="Academic Qualification" href="#academic-qualification"></a></li>
                                                <li><a title="Employment History" href="#employment-history"></a></li>
                                                <li><a title="Comments" href="#comments"></a></li>
                                            </ul>
                                            
                                            <div class="tab-panes">
                                                
                                                <div data-name="#personal-details" class="t-performance-trends">
												

                                                    <span class="tab-close"></span>
                                                    <div class="leftfixside">
                                                    	<h5>Personal Details</h5>
                                                        <div class="carousel-box">
                                                                           <div class="grade-join left-side width88">
                                                                              <%-- Reference#<br>--%>
                                                                                Gender<br>
                                                                                Date of Birth<br>
                                                                                Email<br><br>
                                                                                Phone
                                                                                </div>
                                                                           <div class="grade-join right-side width195">
                                                                             <%--<a id="a2" runat="server"  target="_blank"> <%# Eval("Candidate_ID")%></a><br>--%>
                                                                                <%# Eval("Gender")%><br>
                                                                                <%# Eval("DateOf_Birth")%><br>
                                                                                <%# Eval("Email_Address")%><br>
                                                                                <br>
                                                                               <%# Eval("Phone_Number")%><br>
                                                                                <%# Eval("Home_Number")%>
                                                                            </div>
                                                                        </div>
                                                    </div>
                                                    <div class="performance-left threeboxview">
                                                        <h5>Family Details</h5>
                                                       <div class="perform-jcarousel-wrapper">
                
                                                            <!-- Carousel -->
                                                            <div class="perform-jcarousel xjcarousel">
                                                                <ul>   
                                                                 <asp:Repeater ID="rptFamilyDetails" runat="server">
             <ItemTemplate>
                                                                    <li>
                                                                        <div class="carousel-box">
                                                                           <div class="grade-join left-side width88">
                                                                                Relation<br>
                                                                                Name<br>
                                                                                Date of Birth<br>
                                                                                Occupation<br><br>
                                                                                Monthly Income
                                                                                </div>
                                                                           <div class="grade-join right-side width195">
                                                                              <%# Eval("Relation_Name")%><br>
                                                                              <%# Eval("Member_Name")%><br>
                                                                              <%# Eval("dateofbirth")%><br>
                                                                              <%# Eval("Occupation")%><br><br>
                                                                                <%# Eval("MonthlyIncome")%>
                                                                            </div>
                                                                        </div>
                                                                    </li></ItemTemplate></asp:Repeater>
                                                                   
                                                                </ul>  
                                                            </div>
                                                            
                                                            <!-- Prev/next controls -->
                                                            <a href="#" class="control-btn perform-prev"></a>
                                                            <a href="#" class="control-btn perform-next inactive"></a>
                                                        
                                                        </div>
                                                    </div>                                            
                                                   <div class="clearfix"></div>
                                                </div>


                                                <!-- Performance Trends Pane -->
                                                <div data-name="#academic-qualification" class="t-performance-trends">
                                                    <span class="tab-close"></span>
                                                    <div class="performance-left">
                                                        <h5>Academic Qualification</h5>
                                                        
                                                        <div class="perform-jcarousel-wrapper">
                
                                                            <!-- Carousel -->
                                                            <div class="perform-jcarousel xjcarousel">
                                                                <ul>   
                                                                 <asp:Repeater ID="rptQualification" runat="server">
             <ItemTemplate>
                                                                    <li>
                                                                        <div class="carousel-box">
                                                                           <div class="grade-join left-side width88">
                                                                                Degree<br>
                                                                                Institute<br>
                                                                                CGPA/Grades<br>
                                                                                Passing Year<br><br>
                                                                                Majors
                                                                                </div>
                                                                           <div class="grade-join right-side width195">
                                                                              <%# Eval("CandidateEducation")%><br>
                                                                              <%# Eval("Institute")%><br>
                                                                              <%# Eval("GPA")%><br>
                                                                              <%# Eval("EndDate")%><br><br>
                                                                                <%# Eval("Field")%>
                                                                            </div>
                                                                        </div>
                                                                    </li></ItemTemplate></asp:Repeater>
                                                                   
                                                                </ul>  
                                                            </div>
                                                            
                                                            <!-- Prev/next controls -->
                                                            <a href="#" class="control-btn perform-prev"></a>
                                                            <a href="#" class="control-btn perform-next inactive"></a>
                                                        
                                                        </div>
                                                    </div>                                            
                                                   <div class="clearfix"></div>
                                                </div>
                                                
                                                <!-- Growth Trends Pane -->
                                                <div data-name="#employment-history" class="t-growth">
                                                    <span class="tab-close"></span>
                                                    <h5>Employment History</h5>
                                                    
                                                    <div class="growth-jcarousel-wrapper">
            
                                                        <!-- Carousel -->
                                                        <div class="growth-jcarousel xjcarousel">
                                                            <ul> 
                                                            <asp:Repeater ID="rptExperience" runat="server">
             <ItemTemplate>  
                                                                <li>
                                                                        <div class="carousel-box">
                                                                           <div class="grade-join left-side width99">
                                                        Salary<br>
                                                        Duration<br>
                                                        Company<br>
                                                        Job Title<br><br>
                                                        Total Experience
                                                        </div>
                                                    <div class="grade-join right-side">
                                                       Rs. <%# Eval("Current_Salary")%><br>
                                                       <%# Eval("duration")%><br>
                                                       <%# Eval("fullname")%><br>
                                                       <%# Eval("Position")%><br><br>
                                                       <%# Eval("TotalExperience")%> 
                                                        </div>
                                                                        </div>
                                                                    </li>
                                                                   </ItemTemplate></asp:Repeater>
                                                                
                                                            </ul>
                                                            
                                                        </div>
                                                        
                                                        <!-- Prev/next controls -->
                                                        <a href="#" class="control-btn growth-prev"></a>
                                                        <a href="#" class="control-btn growth-next"></a>
                                                    
                                                    </div>
                                                    
                                                </div>
                                                
                                                <!-- COMMENTS PANE -->
                                                <div data-name="#comments" class="t-comments updated">
                                                    <span class="tab-close"></span>
                                                    <h5>Interview Evaluation Sheet</h5>
                                                    
                                                    <div class="performance-left">
                                                    <div class="growth-jcarousel-wrapper">
            
                                                        <!-- Carousel -->
                                                        <div class="growth-jcarousel xjcarousel">
                                                            <ul>  
                                                            <asp:Repeater ID="rptInterviewComments" runat="server" OnItemDataBound="rptInterviewComments_ItemDataBound">
             <ItemTemplate>   
                                                                <li>
                                                                        <div class="carousel-box">
                                                                           <div class="grade-join left-side width99">
                                                        Assessor Name<br>
                                                        Decision<br><br>
                                                        Comments
                                                        </div>
                                                    <div class="grade-join right-side">
                                                        <%# Eval("Name")%><br>
                                                        <%# Eval("Decision")%><br><br>
                                                        <asp:Label runat="server" Visible="false"  ID="lblComments" Text='<%# Eval("Comments")%>'></asp:Label> 
                                                        <%# Eval("CommentsLess")%>
                                                        <p class="visiblemore"><%# Eval("CommentsMore")%></p><a href="javascript:;" title="">more..</a> 
                                                        </div>
                                                                        </div>
                                                                   </li>
                                                                   </ItemTemplate></asp:Repeater>
                                                               
                                                                
                                                            </ul>
                                                            
                                                        </div>
                                                        
                                                        
                                                        
                                                        <!-- Prev/next controls -->
                                                        <a href="#" class="control-btn growth-prev"></a>
                                                        <a href="#" class="control-btn growth-next"></a>
                                                    
                                                    </div></div>
                                                </div>
                                            </div>
                                            
                                        </div>
                                    
                                    </div>
                                    </li></ItemTemplate></asp:Repeater>
                                    </ul>
                                </div>
                                
                            </li>
                            </ItemTemplate>
                              </asp:Repeater>
                            
                      
                            
                        </ul>
                    </div>
                    
                </section>
        </div>
        <table width="100%" style="background: transparent; border: 0px; display: none" id="tblNoRecord"
            runat="server">
            <tr>
                <td align="center" style="background: transparent; border: 0px">
                    <asp:Label ForeColor="Red" Font-Bold="true" runat="server" ID="lblNoRecord" Text="No Record Found !"></asp:Label>
                </td>
            </tr>
        </table>
        <!-- Page action -->
        <section class="page-action-warper">
            <div class="page-action-p">	
                <div class="page-action">
                    <div class="action-pad">
                        <div class="save-btn">                            
                                        
                                                
                                                <asp:LinkButton  ID="lnkapproveAll" runat="server" ToolTip="Approve All" 
                                                    CommandName="ApproveHR" CssClass="input-submit" Text="Approve"
                                                    OnClientClick="return valthisform();" 
                                                    onclick="lnkapproveAll_Click"></asp:LinkButton>
                                                
                                                <asp:LinkButton Visible="false" ID="lnkDisapproveAll" runat="server" ToolTip="Reject All"
                                                    CommandName="DisapproveHR"   CssClass="input-submit" Text="Reject"
                                                    OnClientClick="return confirm('Are you sure you want to Reject');" 
                                                    > </asp:LinkButton>
                                                &nbsp;&nbsp;
                                            
                                            
                                               
                                            
                                            
                                                
                                            
                                            
                        </div>
                                            




                        <!--<a href="#send-email" class="input-submit xpop">Send Email</a>
                        <input type="submit" value="Save Recording" class="input-submit">
                        <input type="submit" value="Download PDF" class="input-submit"> -->
                    </div>
                </div>
            </div>
        </section>
    </div>
    <%--<script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../assets/js/MultipleItemSelection/jQuery.Tokeninput.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript">
        function CheckSelected(obj) {

            document.getElementById(obj).checked = true;
            alert(document.getElementById(obj).checked);
        }

    </script>
<link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
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
    
    </script>
</asp:Content>
