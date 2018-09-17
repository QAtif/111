<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="CandidateProfile.aspx.cs" Inherits="A2_Candidate_CandidateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700' rel='stylesheet'
        type='text/css' />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/style.css" />
    <!--[if lt IE 9]><script type="text/javascript" src="/A2/assets/js/html5.js"></script><![endif]-->
    <style type="text/css">
        .taglinks {
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

        #showthebloodydiv:hover #AimgEdit {
            display: block !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <noscript>
        <div id="jqcheck">
            <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAB60lEQVQ4T2NkwAHePzrxf3ebL1jWp/0oA5egGiM2pVgFQQq31uj/N/ANZvj+8T3D7aNHGDwbTxNvwKtbO/9f3dLHYJ+axfDn5w+GI/NnMRhFtTEISJtjGIIh8Pv39/87ak0ZzCLiGMRUNMCufnLxDMOlrZsY3JtOMrCwsKPowTDg3tGZ/59f2sVgFRvPkO+bAzZgwsZJDEcXzWNQtIlikDGIwG3Az+9v/+9qsGOwTc1h4JeQhhswcfMUhrcP7zEcXzyXwb3xMAMbuwDcEBTTzi7P/s/M8IFB3zccbDPMBSADQODs2sUMzFwyDIah/ZgGfHt/7/+BvmAGm+RsBl4RMawGfHr5jOHowlkMjiUbGDj55MCGwE060Of1X0RZi0Hb2Q4e3eguAElc2X2A4e2DmwwOhVsRBnx6cfH/yXm5DFZxyQxcAoJ4Dfj24T3DsUVzGcwSJjLwSxkygk3ZVmv4X805gkHZRBNXwkQRv3/+NsP1nUsYvFvOMzI+PLXo/73DSxgsouIYOHj5UBRi8wJIwY8vnxlOLV/CIGcewsC4vkDhv01yLoOIoiqG7bgMACn88Owxw8HpvQyMGwqV/vs19TMwQnxDEthYW8DAeGCC3/9XN46TpBGmWEzDkoHx06dP/z9//kyWAby8vAwAcza2SBMOSCMAAAAASUVORK5CYII="
                alt="">
            Javascript is disabled. Please enable it for better working experience.
        </div>
    </noscript>
    <div class="overlay">
    </div>
    <div class="ShowAllDataGrid" id="UlMain">
        <section class="wrapit topmenu offeraproval"> <span class="msearch"><i class="deptstruct-icon"></i> Candidate Profile</span>
             <asp:TextBox ID="txtRefNo" runat="server" style="display:inline !important;left: 53pc;top: -2px;">
             </asp:TextBox><asp:RequiredFieldValidator ID="rfvrefno" runat="server" ControlToValidate="txtRefNo" Display="Dynamic" ErrorMessage="*" ValidationGroup="RefNoFilter"></asp:RequiredFieldValidator> 
             <asp:Button ID="btnSearchByRef" runat="server" Text="" OnClick="Btn_SearchByRefno" style="left: 81pc;top: 122px;" ValidationGroup="RefNoFilter"/></section>
        <section class="container-two-col">
    	    <article class="LeftContainer">        
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
                            <a id="AimgEdit" onclick="javascript:$('#ctl00_BodyContent_fuPic').click();" style="z-index:999; display:none;position:absolute; cursor:pointer; top:-6px;left:80px;" width="20px" height="20px"><img id="img3" alt="" src="/assets/images/edit.png"></img></a>                    
                          </div>
                      
                          <asp:FileUpload ID="fuPic" onchange="if (confirm('Upload ' + this.value + '?')) $('#PicSave').click();" runat="server" style="display:none;" />
                   
                         <asp:Button id="PicSave" runat="server" onclick="btn_SaveBrowsedImg" clientidmode="Static" Text="Save"  style="display:none;" />
                          </td>
                        </tr>
                      <tr style="display:none;">
                        <td>
                        <a href="javascript:;" title="">Details<i class="icon-detail"></i></a>
                        </td>
                      </tr>
                      <tr>
                        <td>  <a id="lnkbtnCV" causesvalidation="false" runat="server" target="_blank">View Resume<i class="icon-resume"></i></a></td>
                      </tr>
                    </table>
                </td>
                <td colspan="2"> <h4><asp:Label ID="lblCanName" runat="server"></asp:Label></h4>
                <div id="divAction136" visible="false" runat="server" clientidmode="Static" style="float:right;" >   
                <a id="APersonalEdit" runat="server" href="javascript:;"  class="editicon popnewform" title="Edit Candidate Personal Detail">
                        <img id="img1" alt="" src="/assets/images/edit.png"></img> </a>
                        <asp:Image ID="imgStaff" runat="server" Height="30" Width="30" ImageUrl="../assets/images/SupportStaff.jpg" /> 
                 </div>
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
                        <td><span>Date of Birth</span></td>
                        <td><asp:Label ID="lblDOB" runat="server"></asp:Label></td>
                      </tr>
                      </table>
                <div id="divAction128" visible="false" runat="server" clientidmode="Static">
                <table class="detailbox1" >
                  
                      <tr>
                        <td><span>Email Address</span></td>
                        <td><asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                        <div id="divAction113" runat="server" visible="false" clientidmode="Static"><a href="#EditContact" class="poptheform" style="position: absolute;left: 597px;top: 289px;" title="Edit Email and Number">  <img id="img4" alt="" src="/assets/images/edit.png"></img></a></div>
                        <asp:HiddenField ID="NewEmail" runat="server" />
                           <asp:HiddenField ID="NewContact" runat="server" />
                        <div id="EditContact" style="display: none;width:400px; height:154px !important;">  
                     <div style="padding-top:  10px;"><h3>Update Primary Contacts:</h3></div>
                      <div style="padding-top:  10px;">&nbsp;Email <asp:TextBox ID="txtEmailCandidate" runat="server" style="margin-left: 24px;" Width="250px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvemail1" runat="server" ControlToValidate="txtEmailCandidate" ErrorMessage="*" ValidationGroup="DivEdit"></asp:RequiredFieldValidator>
                      </div>
                        <div style="padding-top: 20px;">&nbsp;Phone<asp:TextBox ID="txtMobileCandidate" runat="server" style="margin-left: 20px;" Width="250px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMobileCandidate" ErrorMessage="*" ValidationGroup="DivEdit"></asp:RequiredFieldValidator></div>
                          <div  style="padding-top:  10px;text-align:center;">
                           <asp:LinkButton ID="LinkButton1" runat="server" Text="Save"  
                            OnClick="btnSaveContacts_Click" 
                            OnClientClick="javascript:$('#ctl00_BodyContent_NewEmail').val($('#ctl00_BodyContent_txtEmailCandidate').val());$('#ctl00_BodyContent_NewContact').val($('#ctl00_BodyContent_txtMobileCandidate').val());" 
                            CssClass="SubmteForm" ValidationGroup="DivEdit"></asp:LinkButton>
                          </div>
                       
                          </div>
                  
                         <div style="float:left;" id="tdEmil" runat="server">
                                  <asp:Label ID="lblemailverificationCode" runat="server"></asp:Label>
                                    </div>
                                    <div style="Width:30% !important;">
                                    <asp:Image ID="imgEmailNotVerified" runat="server" ToolTip="Email is not verified..!!"
                                        ImageUrl="/assets/images/Exclamation-Mark.png" Width="25" Height="17" /></div>
                                   
                        </td>
                      </tr>
                      <tr>
                        <td><span>Address</span></td>
                        <td><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                      </tr>
                      <tr>
                        <td><span>CNIC</span></td>
                        <td>
                        <div id="tdNic" runat="server" style="width:50% !important; float:left">
                        <asp:Label ID="lblNIC" runat="server"></asp:Label>  
                        </div><div>                
                        <asp:Image ID="imgNICNotVerified" runat="server" ToolTip="duplicate N.I.C..!!" ImageUrl="/assets/images/Exclamation-Mark.png"
                        Width="25" Height="17" />
                                        </div>
        </td> </tr>
        <tr>
            <td>
                <span> Apply Date </span>
            </td>
            <td>
               <asp:Label ID="lblApplyDate" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr style="display:none" id="trHeight" runat="server">
            <td>
                <span>Height</span>
            </td>
            <td>
                <asp:Label ID="lblHeight" runat="server"></asp:Label>
            </td>
        </tr>
        <tr  style="display:none" id="trWeight" runat="server">
            <td>
                <span>Weight</span>
            </td>
            <td>
                <asp:Label ID="lblWeight" runat="server"></asp:Label>
            </td>
        </tr>
        
        </table></div>
        <table class="detailbox1" >
        <tr id="trPRef" runat="server">
            <td>
                <span>Portal Referral</span>
            </td>
            <td>
                <asp:Label ID="lblPortalReferral" runat="server"></asp:Label>
            </td>
        </tr>
        <tr  style="display:none" ID="trShifts" runat="server" >
            <td>
                <span> Shift </span>
            </td>
            <td>
                <span id="SpShit" runat="server"></span>
            </td>
        </tr>
        </table>
        </td>
        <td>
            <div id="divAction129" visible="false" runat="server" clientidmode="Static" >
            <table class="detailbox2" >
                <tr>
                    <td>
                        <span>Contact</span>
                    </td>
                    <td>

                        <span class="cellicon"></span><span id="SPMobile" runat="server"></span>
                        <br />
                        <div id="tdPhone" runat="server" style="float:left">
                                    <asp:Label ID="lblPhoneVerificationCode" runat="server"></asp:Label>
                                    </div><div>
                                    <asp:Image ID="imgPhoneNotVerified" runat="server" ToolTip="Phone Number is not verified..!!"
                                        ImageUrl="/assets/images/Exclamation-Mark.png" Width="25" Height="17" /></div>
                    </td>
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

       
        <tr id="trLink" runat="server">
            <td>
                <span>Linkedin Connect</span>
            </td>
            <td>
                <asp:Label ID="lblIsLinkedin" runat="server"></asp:Label>
            </td>
        </tr>
        <tr  id="trMigrated" runat="server">
            <td>
                <span>Is Migrated</span>
            </td>
            <td>
                <asp:Label ID="lblIsMigrated" runat="server"></asp:Label>
            </td>
        </tr>
         
        <tr id="trOldStatus" runat="server">
            <td>
                <span>Old Status</span>
            </td>
            <td>
                <asp:Label ID="lblOldStatus" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <span>Expected Salary</span>
            </td>
            <td>
                <asp:Label ID="lblExpectedSal" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
         </div>
         <table class="detailbox2" >
        <tr>
            <td>
                <span>Referral</span>
            </td>
            <td>
                <asp:Label ID="lblRefferal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trReferralUrl" runat="server">
            <td>
                <span>Referral Url</span>
            </td>
            <td>
                <asp:Label ID="lblRefferalUrl" runat="server"></asp:Label>
            </td>
        </tr>
        </table></td> </tr> </table>
        <div class="tab-container">
            <ul class="controllers" style="width:167px !important">
                <li><a href="javascript:;" title="" data-rel="experience" class="active"><i class="icon1">
                </i>Experience</a></li>
                <li><a href="javascript:;" title="" data-rel="education"><i class="icon2"></i>Education</a></li>
                <li><a href="javascript:;" title="" data-rel="diploma"><i class="icon3"></i>Diploma</a></li>
                <li><a href="javascript:;" title="" data-rel="certification"><i class="icon4"></i>Certification</a></li>
                <li><a href="javascript:;" title="" data-rel="portfolio"><i class="icon5"></i>Portfolio</a></li>
                <li><a href="javascript:;" title="" data-rel="FamilyDetails"><i class="icon6"></i>Family
                    Details</a></li>
                <li><a href="javascript:;" title="" data-rel="documents"><i class="icon7"></i>Documents</a></li>
                <li><a href="javascript:;" title="" data-rel="ScheduledActivities"><i class="icon8">
                </i>Scheduled Activities</a></li>
                <li><a href="javascript:;" title="" data-rel="SkillsSet"><i class="icon8"></i>Skills
                    Set</a></li>
                <li><a href="javascript:;" title="" data-rel="Communication"><i class="icon8"></i>Communication</a></li>
                  <li><a href="javascript:;" title="" data-rel="OfficialDoc"><i class="icon8"></i>Official Documents</a></li>
                   <li><a href="javascript:;" title="" data-rel="OfferActivities"><i class="icon8"></i>Offer Approval Activities</a></li>
             
            </ul>
            <div class="TabsBoxes" style="width:70%">
                <div class="box-SkillsSet box ">
                    <h4>
                        Skill Set</h4>
                    <span class="history" id="divAction90" visible="false" runat="server" clientidmode="Static">
                        <a id="lnkAddEditSkillSet" runat="server" href="javascript:;" title="" class="editicon popnewform">
                        </a></span>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td>
                                <asp:Repeater ID="rptSkills" runat="server" ClientIDMode="Static">
                                    <ItemTemplate>
                                        <span class="taglinks">
                                            <%# Eval("Skill")%>
                                        </span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblSkill" runat="server" Text="No skills found."></asp:Label>
                </div>
                  <div class="box-OfficialDoc box " id="divAction130" runat="server" visible="false" clientidmode="Static">
                    <h4>
                        Official Documents</h4>
                    <span class="history" id="Span1" visible="false" runat="server" clientidmode="Static">
                        <a id="A2" runat="server" href="javascript:;" title="" class="editicon popnewform">
                        </a></span>
              
                   <table width="50%" border="0" cellspacing="0" cellpadding="0">
                        <tr id="trOfferLetterAudio" runat="server">
                            <td>
                                <%--<asp:Image ID="Image5" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aOfferLetterAudio" runat="server">Offer Delivery Audio</a>--%>

                                 <asp:Repeater ID="rptOfficialDocuments" runat="server"
                                    onitemcommand="rptOfficialDocuments_ItemCommand" 
                                    onitemdatabound="rptOfficialDocuments_ItemDataBound">
                                    <ItemTemplate>
                                    <tr>
                                    <td>
                                    <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("CandidateDocumentName")%>' />
                                    <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDocCode")%>' />
                                    <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("document_code")%>' />

                                    <asp:Image ID="Image5" runat="server" ImageUrl="/assets/images/bullet.gif" />
                               <a id="aOfferLetter" runat="server" target="_blank" href='<%# Eval("DocumentPath")%>'><%# Eval("CandidateDocumentName")%>  &nbsp;</a>
                                    </td>
                                    <td>
                                     <asp:Image ID="Image2" runat="server" style="height:12px;width:15px" ImageUrl="/assets/images/regenerate-icon.gif" />
                        
                                    <asp:LinkButton runat="server" ID="btnReserve" CommandName='<%# Eval("Candidate_Code")%>' CommandArgument='<%# Eval("OfficialLetter_Code")%>'>    &nbsp; Regenerate</asp:LinkButton>
                                
                                      <a id="AUploadDocs" runat="server" style="display:none" href="javascript:;">  <asp:Image ID="Image3" runat="server" style="height:12px;width:15px" ImageUrl="/assets/images/regenerate-icon.gif" />
                                &nbsp; Upload </a>
                                      <asp:FileUpload ID="FUDocs" runat="server" style="display:none" />
                                      <asp:LinkButton runat="server" ID="lnkUploadDoc" style="display:none;"  CommandName='<%# Eval("Candidate_Code")%>' CommandArgument='<%# Eval("OfficialLetter_Code")%>' Text="Save"></asp:LinkButton>
                                    </td>
                                    </tr>
                                
                                    </ItemTemplate>
                                    </asp:Repeater>

                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <asp:Image ID="imgbullet" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aOfferLetter" runat="server">Offer Letter</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image2" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aAppointmentLetter" runat="server">Appointment Letter</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image3" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aMedicalLetter" runat="server">Medical Letter</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image6" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aRemuneration" runat="server">Remuneration Sheet</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image7" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aFirstPageOfferLetter" runat="server">First Page Offer Letter</a>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Image ID="Image8" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aFirstPageAppointmentLetter" runat="server">First Page Appointment Letter</a>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Image ID="Image4" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                &nbsp; <a id="aDocCheckList" runat="server">Document Check List</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="box-Communication box ">
                    <h4>
                        Communication</h4>
                    <table>
                        <asp:Repeater ID="rptCommunication" runat="server">
                            <HeaderTemplate>
                                <tr>
                               
                                    <td style="width:10%" align="center">
                                        <b>Type</b>
                                    </td>
                                    <td style="width:40%" align="center">
                                        <b>Comments</b>
                                    </td>
                                    <td style="width:15%" align="center">
                                        <b>Communicator</b>
                                    </td>                                
                                    <td style="width:5%" align="center">
                                        <b>Status</b>
                                    </td>
                                    <td style="width:15%" align="center">
                                        <b>Date</b>
                                    </td>
                                    <td style="width:15%" align="center"><b>IP</b></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="trCommunicationWayRecord" runat="server">
                              
                                    <td align="center">
                                        <b>
                                            <%#Eval("CommunicationWay")%>
                                        </b>
                                        <asp:HiddenField ID="hdnCommCode" runat="server" Value='<%#Eval("CommunicationWayCode") %>' />
                                    </td>
                                    <td>
                                        <%#Eval("Comments")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Fullname")%>
                                    </td>
                                     <td align="center">
                                        <%#Eval("TestStatus")%>
                                    </td>
                                    <td align="center">
                                     <%#Eval("Created_Date")%>
                                       <%-- <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy}")%>--%>
                                    </td>
                                    <td align="center">
                                     <%#Eval("Updated_IP")%>                                
                                    </td>
                               
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblMsgCommu" runat="server" Text="No communication found."></asp:Label>
                </div>
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
                <div class="box-documents box">
                    <h4>
                        Documents
                    </h4>
                    <span class="history" id="divAction91" visible="false" runat="server" clientidmode="Static">
                        <a id="aDocuments" runat="server" href="javascript:;" title="" class="editicon popnewform">
                        </a></span>
                    <ul class="innController">
                        <li><a href="javascript:;" title="" data-rel="persona" class="active">Personal</a></li>
                        <li><a href="javascript:;" title="" data-rel="Exp">Experience</a></li>
                        <li><a href="javascript:;" title="" data-rel="Edu">Education</a></li>
                        <li><a href="javascript:;" title="" data-rel="Dip">Diploma</a></li>
                        <li><a href="javascript:;" title="" data-rel="Certi">Certification</a></li>
                        <li><a href="javascript:;" title="" data-rel="Hired">Hired Documents</a></li>
                    </ul>
                    <div class="innContainer">
                        <div class="first innBox box-persona active">
                            <table>
                                <asp:Repeater ID="rptDocPersonal" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("CandidateDocumentName") %>
                                            </td>
                                            <td>
                                                <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                    title="Click here to View Document">
                                                    <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                        Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                    Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                    ToolTip="No file Browsed." />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDocPersonal" runat="server" Text="No personal documents found."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divAction106" runat="server" clientidmode="Static" visible="false">
                                <a id="aDocVerification" href="javascript:;" visible="false" runat="server" class="multiapp popnewform">
                                    Document Verification</a></div>
                        </div>
                        <div class="innBox box-Exp">
                            <asp:Repeater ID="rptDocsExperience" runat="server">
                                <ItemTemplate>
                                    <strong><span id="SpDocExperience">
                                        <%# Eval("CandidateDocumentName") %></span></strong>
                                    <table class="addleftmar">
                                        <tr>
                                            <td>
                                                <%# Eval("Document_Name") %>
                                            </td>
                                            <td>
                                                <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                    title="Click here to View Document">
                                                    <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                        Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                    Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                    ToolTip="No file Browsed." />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lblDocProfessional" runat="server" Text="No professional documents found."></asp:Label>
                        </div>
                        <div class="innBox box-Edu">
                            <asp:Repeater ID="rptDocsEducation" runat="server">
                                <ItemTemplate>
                                    <strong><span id="SpDocEducation">
                                        <%# Eval("CandidateDocumentName") %></span></strong>
                                    <table class="addleftmar">
                                        <tr>
                                            <td>
                                                <%# Eval("Document_Name") %>
                                            </td>
                                            <td>
                                                <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                    title="Click here to View Document">
                                                    <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                        Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                    Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                    ToolTip="No file Browsed." />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbldocEducation" runat="server" Text="No educational documents found."></asp:Label>
                        </div>
                        <div class="innBox box-Dip">
                            <asp:Repeater ID="rptDocDiploma" runat="server">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%# Eval("Document_Name") %>
                                            </td>
                                            <td>
                                                <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                    title="Click here to View Document">
                                                    <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                        Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                    Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                    ToolTip="No file Browsed." />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lblDocDiploma" runat="server" Text="No diploma documents found."></asp:Label>
                        </div>
                        <div class="innBox box-Certi">
                            <asp:Repeater ID="rptDocCertificate" runat="server">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%# Eval("Document_Name") %>
                                            </td>
                                            <td>
                                                <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                    title="Click here to View Document">
                                                    <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                        Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                    Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                    ToolTip="No file Browsed." />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lbldocCertificate" runat="server" Text="No certificate documents found."></asp:Label>
                        </div>
                           <div class="innBox box-Hired">
                            <asp:Repeater ID="rptHiredDocs" runat="server">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%# Eval("Document_Name") %>
                                            </td>
                                            <td>
                                                <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                    title="Click here to View Document">
                                                    <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                        Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                    Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                    ToolTip="No file Browsed." />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lblHiredError" runat="server" Text="No Hired documents found."></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="box-FamilyDetails box">
                    <h4>
                        Family Details
                    </h4>
                    <span class="history" id="divAction92" visible="false" runat="server" clientidmode="Static">
                        <a id="aFamily" runat="server" href="javascript:;" title="" class="editicon popnewform">
                        </a></span>
                    <asp:Repeater ID="rptFamily" runat="server">
                        <ItemTemplate>
                            <table class="detailbox1">
                                <tbody>
                                    <tr class="first">
                                        <td rowspan="5" class="first">
                                            <img src="/A2/assets/images/father.jpg" width="50" height="50" alt="">
                                        </td>
                                        <td class="first">
                                            <span>Relation</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("Relation_Name") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            <span>Name</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("Member_name") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            <span>Date of Birth</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("DateOfBirth") %>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="first">
                                            <span>Marital Status</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("MaritalStatus")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            <span>Qualification</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("Qualification") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            &nbsp;
                                        </td>
                                        <td class="first">
                                            <span>Occupation</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("Occupation") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            &nbsp;
                                        </td>
                                        <td class="first">
                                            <span>Designation</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("Designation") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            &nbsp;
                                        </td>
                                        <td class="first">
                                            <span>Company/Institute</span>
                                        </td>
                                        <td class="last">
                                            <%# Eval("Company_Name") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="first">
                                            &nbsp;
                                        </td>
                                        <td class="first">
                                            <span>Monthly Income</span>
                                        </td>
                                        <td class="last">
                                            Rs.
                                            <%# Eval("MonthlyIncome") %>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lblinfoFamily" runat="server" Text="No family members information found."></asp:Label>
                </div>
                <div class="box-ScheduledActivities box">
                    <h4>
                        Scheduled Activities
                    </h4>
                    <table>
                        <asp:Repeater ID="rptScheduleHistory" runat="server" OnItemDataBound="rptScheduleHistory_ItemDataBound">
                            <HeaderTemplate>
                                <tr>
                                    <td>
                                        <span>#</span>
                                    </td>
                                    <td>
                                        <span>Date</span>
                                    </td>
                                    <td>
                                        <span>Time</span>
                                    </td>
                                    <td>
                                        <span>Venue</span>
                                    </td>
                                    <td>
                                        <span>Seat #</span>
                                    </td>
                                    <td>
                                        <span>Status</span>
                                    </td>
                                    <td>
                                        <span>Reserved By</span>
                                    </td>
                                    <td>
                                        <span>Panel</span>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Date")%>
                                    </td>
                                    <td style="width: 15%">
                                        <asp:HiddenField ID="hdnRSCode" runat="server" Value='<%# Eval("RSCode") %>' />
                                        <%# Eval("Time")%>
                                    </td>
                                    <td>
                                        <%# Eval("Venue") %>
                                    </td>
                                    <td style="width: 15%">
                                        <%# Eval("Seat") %>
                                    </td>
                                    <td>
                                        <%# Eval("StatusName")%>
                                    </td>
                                    <td> <%# Eval("ReservedBy")%></td>
                                    <td>
                                        <a id="aShow" href="javascript:;" runat="server">
                                            <asp:Label ID="lblShow" runat="server" Text="Show"></asp:Label></a> <a id="aHide"
                                                href="javascript:;" runat="server" style="display: none">
                                                <asp:Label ID="lblHide" runat="server" Text="Hide"></asp:Label>
                                            </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="7" style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px">
                                        <table id="tblChild" runat="server" width="100%" cellpadding="0" cellspacing="0"
                                            style="display: none">
                                            <tr>
                                                <td style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px">
                                                    <asp:Repeater ID="rptScheduledChild" runat="server">
                                                        <HeaderTemplate>
                                                            <tr>
                                                                <th style="width: 4%">
                                                                    <strong>S.No.</strong>
                                                                </th>
                                                                <th style="width: 32%">
                                                                    <strong>Name</strong>
                                                                </th>
                                                                <th style="width: 32%">
                                                                    <strong>Department</strong>
                                                                </th>
                                                                <th style="width: 32%">
                                                                    <strong>Designation</strong>
                                                                </th>
                                                            </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%# Container.ItemIndex+1 %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Name") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Department") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("JobTitle")%>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                    
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                        <tr id="trempty" runat="server">
                            <td colspan="6">
                                <asp:Label ID="lblScheduledActivityEmpty" runat="server" Text="No record(s) found"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="box-OfferActivities box MyTable">
                    <h4>
                        Offer Approval Activities
                    </h4>
                     <table>
                            <asp:Repeater ID="rptOffer" runat="server">
                                <HeaderTemplate>
                                    <tr>
                                        <td>
                                            S.No
                                        </td>
                                         <td>
                                            User Name
                                        </td>
                                        <td>
                                            User Type
                                        </td>
                                        <td>
                                            Status
                                        </td>
                                        <td>
                                            Date
                                        </td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <%#Eval("username")%>                                        
                                        </td>
                                        <td>
                                            <%#Eval("UserType")%>
                                        </td>
                                        <td>
                                            <%#Eval("OfferApproval_NameDisplay")%>
                                        </td>
                                        <td>
                                            <%#Eval("Created_Date")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>                            
                            </asp:Repeater>
                        </table>
                        <asp:Label ID="lblOffer" runat="server"></asp:Label>
                </div>

            </div>
        </div>
        </article>
        <article class="Sidebar">
      	    <div class="boxes" id='divSidebar'>
        	    <h4>Application Status</h4> <span id="divAction110" runat="server" visible="false"  clientidmode="Static"><a id="aAppHistory"
                            visible="false" runat="server" class="multiapp popnewform" style="position: absolute; right: 19px;">Multiple Application</a></span>
                <hr>
                <ul>
            	    <li>Current Status 
                    <span id="SpCurrentStatus" runat="server"></span>
                    <span id="divAction99" runat="server" visible="false" clientidmode="Static"><span
                                    id="sSchedule" runat="server" style="display: none">(Press to <a id="aSchedule" href="javascript:;" runat="server" class="popnewform"
                                        style="font-weight: bold"></a>)</span> </span>
                                <div style="float: right; vertical-align: middle; width:29%">
                                    <span id="divAction95" runat="server" visible="false" clientidmode="Static">
                                
                                    <a id="aStatusChange" href="javascript:;" class="multiapp popnewform"
                                        runat="server" title="Change Status">
                                        <img id="imgchnagesta" alt="" src="/assets/images/edit.png" /></a> 
                                    
                                        </span>
                                        <span id="divAction117" runat="server" visible="false" clientidmode="Static">
                                        <asp:LinkButton id="aSkipSchedule" OnClick="lnkSkipStatus_click" runat="server" Text="Skip" >
                                        </asp:LinkButton></span>
                                        <span id="divAction137" runat="server" visible="false" clientidmode="Static" style="position: absolute;right: -5px;top: -16px;">
                                        <asp:LinkButton id="lnkNotJoin" OnClick="lnkNotJoin_click" runat="server" Text="Not Join" >
                                        </asp:LinkButton></span>
                                    </div>
                    </li>
                    <li>Profile <span id="SpProfile" runat="server"></span>
                     <span id="divAction96" runat="server" visible="false" clientidmode="Static"><a id="aProfileChange" href="javascript:;"
                                    runat="server" class="multiapp popnewform" title="Change Profile">
                                    <div style="float: right">
                                        <image id="imgchnagepro" alt="" src="/assets/images/edit.png"></image>
                                       </div>
                                </a></span>
                    </li>
                    <li>Requistion # <span id="SpRequisition" runat="server"></span>               
                    <span id="sShortlist" runat="server" style="display: none;">(Press
                                    to
                                    <asp:LinkButton ID="lnkShortlist" runat="server" OnClick="lnkShortlist_Click"></asp:LinkButton>)</span>
                                <span id="divAction97" runat="server" visible="false" clientidmode="Static"><a id="aRequisitionChange" href="javascript:;"
                                    runat="server" class="multiapp popnewform" title="Change Requisition">
                                    <div style="float: right">
                                        <image id="imgchnageReq" alt="" src="/assets/images/edit.png"></image>
                                        </div>
                                </a></span>
                    </li>
                    <li>Category <span id="SpCategory" runat="server"></span></li>
                    <li>Joining Date <span id="SpJoiningDate" runat="server"></span>
                    <span id="divAction98" runat="server" visible="false" clientidmode="Static">
                     <a id="aEditDate" runat="server" onclick="javascript:$('#ChangeDate').show();" title="Change joining Date"> <image id="imgchnageReq" alt="" src="/assets/images/edit.png"></image></a>
                    </span>
                    <span id="ChangeDate" style="display:none">
                    <input name="JoiningDate" id="JoiningDate"  type="text" runat="server" clientidmode="Static" readonly="readonly"/> &nbsp;&nbsp;<asp:LinkButton ID="lnkEditDate" OnClick="lnkEditDate_Click" runat="server">Save</asp:LinkButton>
                    </span></li>
                    <%--<li>Organizational Visit <span id="SpVisit" runat="server"></span></li>--%>
                    <li>Domain <span id="SpDomain" runat="server"></span></li>
                    <li>Sub Domain <span id="SpSubDomain" runat="server"></span></li>
                    <li>Grade <span id="SpGrade" runat="server"></span>
                    
                    <span id="divAction134" runat="server" visible="false" clientidmode="Static"><a id="aEditProfile" href="javascript:;"
                                    runat="server" class="multiapp popnewform" title="Edit Profile Info">
                                    <div style="float: right">
                                        <image id="imgchnageReq" alt="" src="/assets/images/edit.png"></image>
                                        </div>
                                </a></span></li>
                    <li>Designation <span id="SpDesignation" runat="server"></span>
                    <span id="divAction115" runat="server" visible="false" clientidmode="Static">
                     <a id="aEditDesignation" runat="server" onclick="javascript:$('#ChangeDesignation').show();" title="Change Designation and grade"> 
                     <image id="imgchnageReq" alt="" src="/assets/images/edit.png"></image></a>
                    </span>
                    <span id="ChangeDesignation" style="display:none">
                   <asp:DropDownList ID="ddlDesignationC" runat="server"></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="cd" runat="server" ControlToValidate="ddlDesignationC" Display="Dynamic" ErrorMessage="*" ValidationGroup="changedesignation"  InitialValue="-1"></asp:RequiredFieldValidator>  
                   <asp:DropDownList ID="ddlgradeC" runat="server"></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlgradeC" Display="Dynamic" ErrorMessage="*" ValidationGroup="changedesignation" InitialValue="-1"> </asp:RequiredFieldValidator> <br />

                   <asp:LinkButton ID="LinkButton2" OnClick="lnkEdiDesignation_Click" runat="server" ValidationGroup="changedesignation">Save</asp:LinkButton> &nbsp;&nbsp;
                     <a id="aCancelDate" onclick="javascript:$('#ChangeDesignation').hide();">Cancel</a>
                    </span>
                    </li>
                    <li>Reporting Authority <span id="SpRA" runat="server"></span></li>
                     <li>Group Leader <span id="SPGL" runat="server"></span></li>
                      <li>Team Leader <span id="SPL" runat="server"></span></li>
                       <li>Team<span id="SPTeam" runat="server"></span></li>
                       <li>Business Unit<span id="SPBU" runat="server"></span></li>
                </ul>
            
                </div>
            <div class="boxes action fourth"  id="div1" runat="server" clientidmode="Static">
        	    <h4>Actions</h4> 
             <hr />       
                    <div id="divAction104" runat="server" visible="false" clientidmode="Static">
                    <div id="tblInterview" runat="server" style="display: none">
                        <table style="width:90%;">
                            <tr>
                                <td style="margin-right:10px">
                                    <asp:RadioButton ID="rdbPass" Text="Mark Pass" runat="server" onclick="ShowHideGrade()"  GroupName="PassOrFail"
                                        Checked="true" />
                                        </td>
                                        <td>
                                    <asp:RadioButton ID="rdbFail" Text="Mark Fail" runat="server" onclick="ShowHideGrade()"  GroupName="PassOrFail" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   Interview Comments
                                   </td>
                                   <td>
                                    <textarea id="txtaComments" runat="server" placeholder="Enter Comment..."></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaComments"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="CommentsCheck"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trInterviw">
                            <td colspan="2" >
                            <div  id="divAction105" runat="server" visible="false" clientidmode="Static" style="width:84%">
                            <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                        Grade</td><td>
                                        <asp:DropDownList ID="ddlGrade" runat="server">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlGrade"
                                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Grade is required!' />"
                                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                        <td>
                                   
                                     Designation</td><td>
                                        <asp:DropDownList ID="ddlDesignation" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlDesignation"
                                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Designation is required!' />"
                                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                           </td></tr>
                                           <tr>
                                           <td>
                                           Profile</td>
                                           <td>
                                             <asp:DropDownList ID="ddlProfile" runat="server">
                                                <asp:ListItem Value="-1" Text="--Profile--"></asp:ListItem>                                                                                
                                                <asp:ListItem Value="0" Text="Fresh"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Experienced"></asp:ListItem>
                                             </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlProfile"
                                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Profile is required!' />"
                                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                            </td></tr>
                                            <tr><td>
                                         Salary</td><td>
                                            <asp:TextBox runat="server" ID="txtDSalary" MaxLength="7" onkeydown="return isNumberKey(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDSalary"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Salary is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                       </td>
                                    
                                    </tr>
                                    <tr>
                                    <td>
                                        Bank Statement</td>
                                        <td>
                                        <asp:DropDownList ID="ddlStatement" runat="server">
                                        <asp:ListItem Value="-1" Text="--Statement--"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="N/A"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Verified"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Not Verified"></asp:ListItem>
                                  
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlStatement"
                                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Statement Verification is required!' />"
                                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                    <td>
                                        Team</td>
                                        <td>
                                        <asp:DropDownList ID="ddlJD" runat="server"></asp:DropDownList>
                                       <%-- <asp:TextBox runat="server" ID="txtTeamMapping"></asp:TextBox>--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlJD"
                                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Team is Required!' />"
                                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                    <td>
                                        Cost Center</td>
                                        <td>
                                        <asp:DropDownList ID="ddlBU" runat="server"></asp:DropDownList>
                                       <%-- <asp:TextBox runat="server" ID="txtTeamMapping"></asp:TextBox>--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlBU"
                                            ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='BU is Required!' />"
                                            Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                 <tr id="trFixedSalary" runat="server" style="display:none">
                                    <td>
                                        Fixed Salary</td>
                                        <td>
                                        <asp:TextBox runat="server" ID="txtFixedSalary" MaxLength="7" onkeydown="return isNumberKey(event);"></asp:TextBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFixedSalary"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Salary is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                       
                        
                            </table></div> </td></tr>
                      
                        </table>
                         <hr />
                        <div style="float:right; padding-bottom:10px; padding-right:10px;">
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSubmit_Click"
                                        OnClientClick="javascript:return ValidateInterview();">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Submit
                                    </asp:LinkButton>
                                    </div>
                                    </div>
                    </div>
                    <div width="100%" id="divAction101" runat="server" clientidmode="Static" visible="false">
                        <table id="tblOfferGenerationPending" runat="server" width="50%" style="display: none;">
                            <tr>
                                <td>
                                    <span>Enter Offer Generation Comments:</span>
                                    <textarea id="txtaOfferGenerationPending" cols="50" rows="6" runat="server" placeholder="Enter Comment..."></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtaOfferGenerationPending"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="OfferPendingCheck"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr><td>
                            <asp:DropDownList ID="ddlLeagueType" runat="server"></asp:DropDownList>
                            </td></tr>
                            <tr>                      
                                <td style="text-align:right">
                                <hr />
                                    <asp:LinkButton runat="server" ID="lnkOfferGenerationPending" CssClass="btn-ora nl"
                                        OnClick="lnkOfferGenerationPending_Click" ValidationGroup="OfferPendingCheck">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Generated
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table id="tblOfferGeneration" runat="server" width="50%" style="display: none;">
                        <tr id="trOfferGenerationReserve" runat="server">
                            <td>
                                Click here to <a id="AReserve" runat="server" class="multiapp popnewform">Reserve</a> for
                                the Offer Letter.
                            </td>
                        </tr>
                        <tr id="trOfferGenerationReserved" runat="server">
                            <td>
                                <strong>Already Reserved</strong> for the Offer Letter.
                            </td>
                        </tr>
                    </table>
                    <div width="100%" id="divAction102" runat="server" clientidmode="Static" visible="false">
                        <table id="tblOfferDelivered" runat="server" style="display: none;">
                            <tr>
                                <td>
                                   <span>Mark Offer Delivered here:</span>
                                </td>
                            </tr>
                            <tr>
                                <td>                               
                                    <textarea id="txtaOfferdelivered" cols="50" rows="6" runat="server" placeholder="Enter Comment..."></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaOfferdelivered"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="OfferCheck"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                          
                                    <asp:LinkButton ID="lnkOfferLetter" CausesValidation="false" runat="server" OnClick="lnkOfferLetter_OnClick" Visible="false">View Offer Letter</asp:LinkButton>
                                    <label id="lblNoOffer" runat="server" style="color: Red">
                                    </label>
                                    <asp:HiddenField ID="hdnOfferLetter" runat="server" />
                                     <asp:HiddenField ID="hdnDocName" runat="server" />
                                      <asp:HiddenField ID="hdnDocumentCode" runat="server" />
                                       <asp:HiddenField ID="hdnCanDocCode" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                  <hr />
                                    <asp:FileUpload ID="fuOffer" runat="server" Width="600px" />
                             <%--       <asp:RequiredFieldValidator ID="rfvOffer" runat="server" ControlToValidate="fuOffer"
                                        ErrorMessage="Please Select File to Upload" Font-Bold="True" ForeColor="Red"
                                        Text="<img src='/assets/Images/Exclamation.gif' title='File to Upload is required!' />"
                                        InitialValue="" Display="Dynamic" ValidationGroup="OfferCheck"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Select the Correct Format(mp3| flv| avi| wma| wmv| mpeg| 3ga| amr)"
                                        ValidationExpression="^.+(.flv|FLV|.avi|.AVI|.wma|.WMA|.wmv|.WMV|.mpeg|.MPEG|.mp3|.MP3|.3ga|.amr)$"
                                        Display="Dynamic" ControlToValidate="fuOffer" ValidationGroup="OfferCheck" Text="<img src='/assets/Images/Exclamation.gif' title='Format(mp3) is required!' />"
                                        Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMsgOffer" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:LinkButton runat="server" ID="lnkMarkOfferDelivered" CssClass="btn-ora nl" OnClick="lnkMarkOfferDelivered_Click"
                                        ValidationGroup="OfferCheck">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Delivered
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div width="100%" id="divAction103" runat="server" clientidmode="Static" visible="false">
                        <table id="tblOfferAcceptance" runat="server" width="50%" style="display: none;">
                            <tr>
                                <td>
                                    <strong>Mark Offer accepetance here :</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>                               
                                    <textarea id="txtaOfferAccepetance" cols="50" rows="6" runat="server" placeholder="Enter Comment..."></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtaOfferAccepetance"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="AcceptCheck"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        
                            <tr>
                                <td>
                                  Excepted Date Of Joining:
                                    <input runat="server" type="text" id="txtExpectedDOJ" clientidmode="Static"
                                        readonly="readonly" /><%--<img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                            height="16" id="img2" runat="server" />--%>
                                   <%-- <script type="text/javascript">
                                        Calendar.setup({
                                            inputField: "txtExpectedDOJ",      // id of the input field
                                            ifFormat: "M dd, y",       // format of the input field
                                            //ifFormat       :    "y-M-dd",       // format of the input field
                                            //ifFormat       :    "M-dd-y",       // format of the input field
                                            button: '<%=img2.ClientID %>',   // trigger for the calendar (button ID)
                                            singleClick: true            // double-click mode
                                        });
                                    </script>--%>
                                </td>
                                </tr>
                                 <tr>
                                <td>
                                   Tentative Shift
                                    <asp:DropDownList ID="ddlTentativeShift" runat="server" Width="200px">
                                    <asp:ListItem Value="-1" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Morning"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Afternoon"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Evening"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Night"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlTentativeShift"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Tentative Shift is Required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="AcceptCheckRA"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                   Reporting Authority
                                    <asp:DropDownList ID="ddlRA" runat="server" Width="200px">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRA"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='RA is required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="AcceptCheckRA"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Group Leader: 
                                    <asp:DropDownList ID="ddlGL" runat="server" Width="170px" CssClass="select">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlGL" runat="server"
                                        ValidationGroup="AcceptCheckRA" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </td>
                                </tr>
                                 <tr>
                                <td>
                                    Team Leader: 
                                    <asp:DropDownList ID="ddlTL1" runat="server" Width="170px" CssClass="select">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlTL" runat="server"
                                        ValidationGroup="shift" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </td>
                                </tr>
                         
                            <tr>
                                <td align="right">
                                    <asp:LinkButton runat="server" ID="lnkMarkOfferAccepted" CssClass="btn-ora nl" OnClick="lnkMarkOfferAccepted_Click"
                                        OnClientClick="javascript:return ValidDate(txtExpectedDOJ);">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Accepted
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkMarkOfferNotAccepted" CssClass="btn-ora nl"
                                        OnClick="lnkMarkOfferNotAccepted_Click" OnClientClick="javascript:return Validate1();">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Not Accepted
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div width="100%" id="divAction108" runat="server" clientidmode="Static">
                        <table id="tblAppointmentGeneration" runat="server" width="50%" visible="false">
                            <tr>
                                <td>
                                    <strong>Enter Appointment Generation Comments:</strong><br />
                                    <textarea id="txtaAppointmentGeneration" cols="50" rows="6" runat="server"></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtaAppointmentGeneration"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                        Display="Dynamic" InitialValue="" ValidationGroup="OfferPendingCheck"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:LinkButton runat="server" ID="lnkAppointmentGenerate" CssClass="btn-ora nl"
                                        OnClick="lnkAppointmentGenerate_Click">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Generate Appointment Letter
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div width="100%" id="divAction109" runat="server" clientidmode="Static" visible="false">
                        <table id="tblPortalActivation" runat="server" width="50%" visible="false">
                            <tr>
                                <td colspan="2">
                                   Request To Create Portal
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Select Shift: </td><td>
                                    <asp:DropDownList ID="ddlshift" runat="server" Width="170px" CssClass="select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvShift" ControlToValidate="ddlshift" runat="server"
                                        ValidationGroup="shift" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    Team Leader: </td><td>
                                    <asp:DropDownList ID="ddlTL" runat="server" Width="170px" CssClass="select">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlTL" runat="server"
                                        ValidationGroup="shift" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </td>
                                </tr>
                                <tr style="display:none" id="trAssignUsers" runat="server">
                                <td>
                                    Assigned User: </td><td>
                                    <asp:DropDownList ID="ddlAssignUser" runat="server" Width="170px" CssClass="select">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlTL" runat="server"
                                        ValidationGroup="shift" Display="Dynamic" InitialValue="-1"  ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </td>
                                </tr>
                            
                                <tr>
                                <td>
                                    Select Location: </td><td>
                                    <asp:DropDownList ID="ddlCity" runat="server" Width="170px" CssClass="select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvcity" ControlToValidate="ddlCity" runat="server"
                                        ValidationGroup="shift" Display="Dynamic" InitialValue="-1" ErrorMessage="*"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="display:none">
                                <td colspan="2">
                                   Select JobRole:
                               
                                </td>
                            </tr>
                            <tr  style="display:none"><td colspan="2">
                             <asp:CheckBoxList ID="chkjobrole" runat="server" RepeatLayout="UnorderedList">
                                    </asp:CheckBoxList>
                            </td></tr>
                            <tr>
                                <td colspan="2" style="text-align:right">
      
                                    <asp:LinkButton runat="server" ID="lnkCreatePortal" CssClass="btn-ora actionbtn nl" OnClick="lnkCreatePortal_Click"
                                        ValidationGroup="shift">
                            <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Request to Create Portal
                                    </asp:LinkButton>
                                    <asp:Label ID="lblNicverified" runat="server" Text="NIC not verified or Medical(X-Ray,H.B) files not uploaded If Staff!" style="color:Red;" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                         </div>
                    
         

                </div>  
                 <div class="boxes action fourth"  id="DivStaffAction" runat="server" clientidmode="Static" visible="false">
        	    <h4>Support Staff Assessment</h4> 
             <hr />   
               <div id="divAction123" runat="server" clientidmode="Static" visible="false" style="text-align:center; height:50px; width:100%">
                    <br />  <a id="aMarkStaffTest" runat="server" target="_blank" style="padding: 6px 8px;background: #F8F8F8;border: 1px solid #E5E5E5;margin-top: 7px;text-decoration: none;"> View Test</a>
                         </div>    
                         </div>
            <div class="boxes TestSummary"  id="tblTest" runat="server">
        	    <h4>Test Summary</h4>  <span id="divAction100" runat="server" visible="false" clientidmode="Static">
                                            
                                    <a id="alnkChktest" runat="server" target="_blank" class="multiapp" style="position: absolute; right: 19px;"  >View Test</a>
                                    </span>
                <hr />
                         <table>
                        <tr>
                            <td>
                                <asp:Repeater ID="rptQuestionGroup" OnItemDataBound="rptQuestionGroup_ItemDataBound"
                                    runat="server">
                                    <HeaderTemplate>
                                        <table>                                        
                                            <tr>                                          
                                       
                                            <td>&nbsp;</td>
                    <td class="alignCenter">Right</td>
                    <td class="alignCenter">Wrong</td>
                    <td class="alignCenter">Pending</td>
                    <td class="alignCenter">Total</td>
                     </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                        
                                            <td>
                                                <asp:HiddenField ID="hdfQuestionGroupCode" runat="server" Value='<%#Eval("QuestionGroupCode") %>'>
                                                </asp:HiddenField>
                                                <asp:HiddenField ID="hdfSectionCode" runat="server" Value='<%#Eval("SectionCode") %>'>
                                                </asp:HiddenField>
                                                <asp:Label runat="server" Text='<%#Eval("QuestionGroupName") %>' ID="lblSection"></asp:Label>
                                            </td>
                                            <td class="alignCenter fach">
                                                <asp:Label runat="server" ID="lblCorrect"></asp:Label>
                                            </td>
                                            <td class="alignCenter fach">
                                                <asp:Label runat="server" ID="lblWrong"></asp:Label>
                                            </td>
                                            <td class="alignCenter fach">
                                                <asp:Label runat="server" ID="lblPending"></asp:Label>
                                            </td>
                                            <td class="alignCenter fach">
                                                <asp:Label runat="server" ID="lblTotal"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                           
                                    <FooterTemplate>
                                        <tr>
                                            <td>
                                               Total
                                            </td>
                                       
                                            <td class="alignCenter fach">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblCorrecttot"></asp:Label></strong>
                                            </td>
                                            <td class="alignCenter fach">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblWrongtot"></asp:Label></strong>
                                            </td>
                                            <td class="alignCenter fach">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblPendingtot"></asp:Label></strong>
                                            </td>
                                            <td class="alignCenter fach">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblTotaltot"></asp:Label></strong>
                                            </td>
                                        
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                   
                    </table>
                         <table width="1000%" border="0" cellspacing="0" cellpadding="0" id="tblTestmsg" runat="server">
                        <tr>
                            <td>
                                <asp:Label ID="lblMsgTest" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>

                   </div>          
            <div class="boxes TestSummary" style="display:none">
        	    <h4>Test Summary</h4> <a href="javascript:;" title="" class="multiapp">View Test</a>
                <hr>
			    <table>
                  <tr>
                    <td>&nbsp;</td>
                    <td class="alignCenter">Right</td>
                    <td class="alignCenter">Pending</td>
                    <td class="alignCenter">Wrong</td>
                    <td class="alignCenter">Total</td>
                  </tr>
                  <tr>
                    <td>Intelligence Quotient</td>
                    <td class="alignCenter fach">25</td>
                    <td class="alignCenter fach">20</td>
                    <td class="alignCenter fach">05</td>
                    <td class="alignCenter fach">00</td>
                  </tr>
                  <tr>
                    <td>Content - Essay Writing</td>
                    <td class="alignCenter fach">25</td>
                    <td class="alignCenter fach">20</td>
                    <td class="alignCenter fach">05</td>
                    <td class="alignCenter fach">00</td>
                  </tr>
                  <tr>
                    <td>Case Study - MCQs</td>
                    <td class="alignCenter fach">25</td>
                    <td class="alignCenter fach">20</td>
                    <td class="alignCenter fach">05</td>
                    <td class="alignCenter fach">00</td>
                  </tr>
                  <tr>
                    <td>Total Sum</td>
                    <td class="alignCenter fach">25</td>
                    <td class="alignCenter fach">20</td>
                    <td class="alignCenter fach">05</td>
                    <td class="alignCenter fach">00</td>
                  </tr>
                </table>

              </div>            
            </article>
        </section>
        <!-- Page action -->
        <section class="page-action-warper">
          <div class="page-action-p" style="display:none">
            <div class="page-action">
              <div class="action-pad">
                <div class="save-btn">
                  <input type="submit" value="Approve" class="input-submit">
                </div>
              </div>
            </div>
          </div>
        </section>
    </div>
    <div id="frame-sets" style="display: none;">
        <div>
            <img id="imgBigImage" runat="server" alt="" width="500" height="500" />
        </div>
    </div>
    <script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">


        $(function () {
            $("#JoiningDate").datepicker({
                changeMonth: true,
                changeYear: true,
                //  buttonImage: '/assets/images/edit.png',
                // buttonImageOnly: true,
                dateFormat: "M dd, yy"
                // showOn: 'button',

            });
        });

        $(function () {
            $("#txtExpectedDOJ").datepicker({
                changeMonth: true,
                changeYear: true,
                //  buttonImage: '/assets/images/edit.png',
                // buttonImageOnly: true,
                dateFormat: "M dd, yy"
                // showOn: 'button',

            });
        });




        function validateControls() {

            var iscity = Page_ClientValidate('city');
            var isshift = Page_ClientValidate('shift');
            var rvalue = true;


            if (!iscity && !isshift) {
                document.getElementById('<%= ddlCity.ClientID %>').className = "redselect";
                document.getElementById('<%= ddlshift.ClientID %>').className = "redselect";
                rvalue = false;
            }
            else
                if (!iscity) {
                    document.getElementById('<%= ddlCity.ClientID %>').className = "redselect";
                    document.getElementById('<%= ddlshift.ClientID %>').className = "select";
                    rvalue = false;
                }
                else
                    if (!isshift) {
                        document.getElementById('<%= ddlshift.ClientID %>').className = "redselect";
                        document.getElementById('<%= ddlCity.ClientID %>').className = "select";
                        rvalue = false;
                    }



            return rvalue;
        }
        function Validate1() {
            var isValid = false;
            isValid = Page_ClientValidate('AcceptCheck');

            return isValid;
        }
        function ValidDate(id) {

            var txtExpectedDOJ = Date.parse(id.value);
            var currentdate = new Date();
            var bl = false;

            var ddlTL1 = document.getElementById('ctl00_BodyContent_ddlTL1');
            var ddlGL = document.getElementById('ctl00_BodyContent_ddlGL');
            var ddlRA = document.getElementById('ctl00_BodyContent_ddlRA');


            if (txtExpectedDOJ <= currentdate) {
                alert('Expected Date of Joining cannot be todays or lesser.');
            }
            else if (txtExpectedDOJ > currentdate) {
                if (ddlTL1[ddlTL1.selectedIndex].value == '-1' &&
                    ddlGL[ddlGL.selectedIndex].value == '-1' &&
                    ddlRA[ddlRA.selectedIndex].value == '-1') {
                    alert('Select atleast one from RA/GL/TL');
                }
                else {
                    bl = true;
                }
            }

            //      if (bl) {
            //     bl = Page_ClientValidate('AcceptCheck');
            //      }
            //      alert(bl);
            if (bl) {
                bl = Page_ClientValidate('AcceptCheckRA');
            }
            //    
            //     var isValid = false;
            //     isValid = Page_ClientValidate('AcceptCheck');
            //    
            //      if (!isValid)
            //      {
            //      bl=false;
            //       alert('Please insert comments.');
            //      }


            return bl;

        }

        function SetValues() {
            $('#ctl00_BodyContent_NewEmail').val($('#ctl00_BodyContent_txtEmailCandidate').val());
            $('#ctl00_BodyContent_NewContact').val($('#ctl00_BodyContent_txtMobileCandidate').val());
        }
        function ValidateInterview() {

            var isValid = false;
            var isPass = document.getElementById('<%=rdbPass.ClientID%>').checked;
            var isFail = document.getElementById('<%=rdbFail.ClientID%>').checked;
            //            if (isPass)
            //                isPass = Page_ClientValidate('CommentsCheck');
            if (isPass)
                isValid = Page_ClientValidate('CommentsCheckPass');
            else if (isFail)
                isValid = Page_ClientValidate('CommentsCheck');

            return isValid;
        }
        function ShowHideGrade() {

            if (document.getElementById('<%=rdbFail.ClientID%>').checked) {

                $('#divAction105').hide();

            }
            else {

                $('#divAction105').show();

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
        function ShowPanel(obj, obj1, obj2) {


            document.getElementById(obj2).style.display = '';
            document.getElementById(obj).style.display = 'none';
            document.getElementById(obj1).style.display = '';


        }
        function HidePanel(obj, obj1, obj2) {

            document.getElementById(obj2).style.display = 'none';
            document.getElementById(obj).style.display = 'none';
            document.getElementById(obj1).style.display = '';


        }

        $(function () {
            setTimeout(function () {
                var ele = $('#divSidebar').find('a');

                var l = ele.length;
                //alert(ele.length);
                for (var i = 0; i < l; i++) {
                    if ($(ele[i]).data('rel') != undefined) {
                        //alert($(ele[i]).data('rel'));
                        var toLink = $(ele[i]).data('rel').replace("http://recruitment.axact.com", "http://recruitment.bolnetwork.com");
                        //console.log(toLink);
                        //alert(toLink);
                        $(ele[i]).attr("data-rel", toLink);
                    }
                }
            }, 1000);
        });


        $(function () {
            setTimeout(function () {
                var ele = $('#divAction100').find('a');

                var l = ele.length;
                //alert(ele.length);
                for (var i = 0; i < l; i++) {
                    if ($(ele[i]).attr('href') != undefined) {
                        //alert($(ele[i]).data('rel'));
                        var toLink = $(ele[i]).attr('href').replace("http://recruitment.axact.com", "http://recruitment.bolnetwork.com");
                        //console.log(toLink);
                        //alert(toLink);
                        $(ele[i]).attr("href", toLink);
                    }
                }
            }, 1000);
        });

        $(function () {
            setTimeout(function () {
                //var ele = $('#ctl00_BodyContent_aDocVerification');
                var toLink = $('#ctl00_BodyContent_aDocVerification').data('rel').replace("http://recruitment.axact.com", "http://recruitment.bolnetwork.com");
                $('#ctl00_BodyContent_aDocVerification').attr("data-rel", toLink);

            }, 1000);
        });




    </script>
</asp:Content>
