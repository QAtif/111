<%@ Page Title="" Language="C#" MasterPageFile="~/AreaMaster2.master" AutoEventWireup="true" CodeFile="Allarea.aspx.cs" Inherits="area_Allarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <script type="text/javascript">
        xPageELEM = 1;
    </script>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="span4">
        <aside class="ignore">
          <div class="xbox-with-heading" data-step="6" data-intro="This area displays your Applicant ID and current status and progress of your application." data-position='right'>
          <h3>Applicant Summary</h3>
          <div class="xbox-content">
            <ul class="summary-list">
              <li>
                <div class="summary-head"><img src="/Area/assets/img/icons/id-icn.png" class="img-pad4x" alt="" />Applicant ID</div>
                <div class="summary-value"> <asp:Label runat="server" ID="lblID"></asp:Label></div>
              </li>
              <li>
                <div class="summary-head"><img src="/Area/assets/img/notes/icon-status.png" alt="" /> Status</div>
                <div class="summary-value">  <asp:Label runat="server" ID="lblStatus"></asp:Label></div>
              </li>
              <li>
                <div class="xspace" runat="server" id="dvProgressPercentage">
                  <div class="progress progress-success">
                    <div  runat="server" id="dvprogressbar" class="bar" ></div>
                  </div>
                  <p>Progress: <asp:Label ID="lblProgressPercentage" runat="server" ></asp:Label>
                  <a href="../profile/redirector.aspx" class="pull-right" data-original-title="" title="">Click here to complete</a>
                  
                  </p>
                </div>
              </li>
            </ul>
          </div>
        </div>
          <div class="xbox-with-heading " runat="server" data-step="7" data-intro="This area displays your contact information verification status, and helps you update the verification status." data-position='right' id="verification_skip">
          <h3>Verify Contact Information</h3>
          <div class="xbox-content">
          <p>We need to verify your contact information. </p>
            <ul class="summary-list">
              <li>
                <div class="summary-head"><img src="/Area/assets/img/icons/phone.png" class="img-pad4x" alt=""> Phone</div>
                <div class="summary-value"><asp:Label runat="server" ID="lblPhoneNumber"> </asp:Label><span runat="server" id="spverified1"><img src="/Area/assets/img/icons/tik.png" style="float:right" class="img-pad4x" alt=""></span>  <span runat="server" id="spnotverified1" >(<a href="#myModal_VerifyMobile" data-toggle="modal" role="button">Verify</a>)</span></div>
              </li>
              <li>
                <div class="summary-head"><img src="/Area/assets/img/icons/email.png" class="img-pad4x" alt=""> Email</div>
                <div class="summary-value" ><asp:Label runat="server" ID="lblEmail"  > </asp:Label><span runat="server" id="spverified2">
                <img src="/Area/assets/img/icons/tik.png" style="float:right" class="img-pad4x" alt=""></span>  <span runat="server" id="spnotverified2" >
                (<a href="#myModal_VerifyEmail" data-toggle="modal" role="button">Verify</a>)</span></div>
              </li>
         
            </ul>
          </div>
        </div>
        <br />        
  <input type="hidden" id="hdnValue" value="<%=javascriptvariable%>" />    
  
    <a href="#myModal_UploadSucess" title="" data-toggle="modal" id="aUploadSucess"
            runat="server"></a>
      </aside>
    </div>
    <div class="span8">
        <section>      
        <asp:Repeater ID="rptAreatext" runat="server">
        <ItemTemplate>
       <h3> <%# Eval("Status_Display_Text")%></h3>
        <span id="spArea" runat="server"> <%# Eval("status_Display_LongText")%></span>
        <br />
        </ItemTemplate>
    </asp:Repeater>
                           
      </section>
    </div>
    <!-- Get Assistance-->
    <div id="xGetAssistance" class="modal hide theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" onclick="javascript:ClearText();" data-dismiss="modal"
                aria-hidden="true">
                x</button>
            <h3>
                Get Assistance</h3>
        </div>
        <div class="modal-body">
            <div class="row-fluid">
                <div class="span6">
                    <div class="xbox-with-heading" style="min-height: 231px;">
                        <h3>
                            Phone</h3>
                        <div class="xbox-content">
                            <p>
                                Call on our UAN
                            </p>
                            <h4>
                                <%=ConfigurationManager.AppSettings["ClientPhone"].ToString()%>
                            </h4>
                            <p>
                                Our Career Consultants are always available to talk to you and entertain all queries
                                related to Axact Careers.</p>
                        </div>
                    </div>
                </div>
                <div class="span6">
                    <div class="xbox-with-heading" style="min-height: 231px;">
                        <h3>
                            Email</h3>
                        <div class="xbox-content">
                            <p>
                                You can also email us:</p>
                            <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" CssClass="txtarea codegetassistance "
                                MaxLength="3000" Width="245px" Height="72px" EnableViewState="true"></asp:TextBox>
                            <div class="span7">
                                <asp:Label ID="lblMsgGetAssistance" Width="245px" runat="server" CssClass="errormsggetassistance red"></asp:Label>
                            </div>
                            <asp:HiddenField ID="hfCandidateCode2" runat="server" />
                            <br />
                            <br />
                            <a href="javascript:VerifyGetAssistance();" id="agetassistance" class="xBook-button-normal">
                                Send Email</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <div class="row-fluid">
                <div class="span6">
                </div>
                <div class="span6">
                    <button data-dismiss="modal" onclick="javascript:ClearText();" data-toggle="modal"
                        class="xBook-button-back" data-original-title="" title="">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal -->
    <!-- Email Verify  -->
    <!-- start Email Verify -->
    <div id="myModal_VerifyEmail" class="modal hide fade theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" onclick="javascript:ClearEmail();" class="close" data-dismiss="modal"
                aria-hidden="true">
                x</button>
            <h3>
                Verify Email Address</h3>
        </div>
        <div>
            <div align="center">
                <iframe id="iframeEAdd" src="../Area/verify.aspx?data=iQJJN4Mgboo=" width="100%"
                    height="220px" frameborder="0" scrolling="no"></iframe>
            </div>
        </div>
        <asp:HiddenField ID="hfCandidateCode" runat="server" />
        <asp:HiddenField ID="hdnVerificationCode" runat="server" />
    </div>
    <!-- end Email Verify -->
    <!-- Mobile Verify  -->
    <div id="myModal_VerifyMobile" class="modal hide fade theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" onclick="javascript:ClearMobile();" data-dismiss="modal"
                aria-hidden="true">
                x</button>
            <h3>
                Verify Mobile Number</h3>
        </div>
        <div>
            <div align="center">
                <iframe id="iframeMobileVerify" src="../Area/verify.aspx?data=Jm54+4Wzi9g=" width="100%"
                    height="220px" frameborder="0" scrolling="no"></iframe>
            </div>
        </div>
        <asp:HiddenField ID="hfCandidateCode1" runat="server" />
        <asp:HiddenField ID="hdnVerificationCode1" runat="server" />
    </div>
    <!-- end Mobile Verify -->
    <div id="myModal_VerifyLinkedIn" class="modal hide fade theModals" tabindex="-1"
        role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                x</button>
            <h3>
                Import your profile from LinkedIn</h3>
        </div>
        <div class="modal-body">
            <div align="center">
                <iframe id="frmlinkedin" src="linkedin.aspx" width="500px" height="280px" frameborder="0"
                    scrolling="no"></iframe>
            </div>
        </div>
    </div>
    <!-- end Email Verify -->
    <!-- Start Document CheckList -->
    <div id="DivCheckList" class="modal hide fade theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                x</button>
            <h3>
                Document Check List
            </h3>
        </div>
        <div>
            <div align="center">
                <iframe id="Iframe2" src="documentchecklist.aspx" width="95%" height="300px" frameborder="0"
                    scrolling="yes"></iframe>
            </div>
        </div>
    </div>
    <!-- end Email Verifys -->
    <div id="DivSchedulePopUp" class="modal hide fade theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="document.location.reload(true)">
                x</button>
            <h3>
                Schedule your test</h3>
        </div>
        <div>
            <div align="center">
                <iframe id="Iframe1" src="schedule.aspx" width="100%" height="380px" frameborder="0"
                    scrolling="no"></iframe>
            </div>
        </div>
    </div>
    <div id="pre_joining_modal" class="modal hide theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                x</button>
            <h3>
                Pre-joining Document Checklist</h3>
        </div>
        <div class="modal-body nopad">
            <div class="row-fluid msgarea">
                <div class="span3">
                    <ul class="darkcolor">
                        <li>Candidate Name:</li>
                        <li>Department:</li>
                        <li>Designation:</li>
                        <li>Job Category:</li>
                    </ul>
                </div>
                <div class="span9" style="margin-left: 0">
                    <ul>
                        <li>
                            <asp:Label ID="lblName" runat="server"></asp:Label></li>
                        <li>
                            <asp:Label ID="lblDept" runat="server"></asp:Label></li>
                        <li>
                            <asp:Label ID="lblDesg" runat="server"></asp:Label></li>
                        <li>
                            <asp:Label ID="lblCat" runat="server"></asp:Label></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="modal-body nopad theScroll jsscrollerwidth" style="max-height: 350px !important;">
            <div class="row-fluid">
                <div class="span12">
                    <ul class="tabcontroller">
                        <li><a title="" href="javascript:;" data-rel="tab1" class="active">Education Record</a></li>
                        <li><a title="" href="javascript:;" data-rel="tab2">Personal Record</a></li>
                        <li><a title="" href="javascript:;" data-rel="tab3">Professional Record</a></li>
                    </ul>
                    <div class="tabs-content">
                        <div class="tab1" style="display: block;">
                            <asp:Label ID="lblDocumentOther" runat="server" Visible="false" Text="No Record Found"
                                ForeColor="Red"></asp:Label>
                            <ul>
                                <asp:Repeater ID="rptDocumentOther" runat="server" OnItemDataBound="rptDocumentOther_OnItemDataBound">
                                    <ItemTemplate>
                                        <li style="list-style:none;" >
                                         <div class="row-fluid" style="margin-bottom:-2px">
                                        <div class="span8">
                                            <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                            <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                            </div>
                                            <div class="span4"> <%# DataBinder.Eval(Container.DataItem, "Copy")%></div>
                                            </div>
                                        </li>
                                        
                                        
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="tab2">
                            <asp:Label ID="lblDocumentPersonal" runat="server" Visible="false" Text="No Record Found"
                                ForeColor="Red"></asp:Label>
                            <ul>
                                <asp:Repeater ID="rptDocumentPersonal" runat="server" OnItemDataBound="rptDocumentPersonal_OnItemDataBound">
                                    <ItemTemplate>
                                       <li style="list-style:none;" >
                                         <div class="row-fluid" style="margin-bottom:-2px">
                                        <div class="span8">
                                            <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                            <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                        </div>
                                            <div class="span4"> <%# DataBinder.Eval(Container.DataItem, "Copy")%></div>
                                            </div></li>
                                         
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="tab3">
                            <asp:Label ID="lblDocumentExperience" runat="server" Visible="false" Text="No Record Found"
                                ForeColor="Red"></asp:Label>
                            <ul >
                                <asp:Repeater ID="rptDocumentExperience" runat="server" OnItemDataBound="rptDocumentExperience_OnItemDataBound">
                                    <ItemTemplate>
                                        <li style="list-style:none;" >
                                         <div class="row-fluid" style="margin-bottom:-2px">
                                        <div class="span8">
                                            <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                            <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                        </div>
                                            <div class="span4"> <%# DataBinder.Eval(Container.DataItem, "Copy")%></div>
                                            </div></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="addpadd">
                        <ol class="addlisting">
                            <li>Please bring all the original documents and photocopies.</li>
                            <li>Please bring 1 Passport size photo of Self, Parents, Spouse and kids (if Applicable)</li>
                            <li>Please note that the documents you submit should be in accordance with the information
                                you submitted earlier.</li>
                        </ol>
                        <strong>Credential Verification Authorization</strong>
                        <p>
                            You will be required to sign an authorization form that will be authorizing Axact
                            to authenticate and verify all your credentials from the past employers, educational
                            institutes, your provided references and any other entity as they deemed appropriate.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--<iframe id="IframeDoc" src="documentchecklist.aspx" width="100%" height="537px" frameborder="0"
                    scrolling="no"></iframe>--%>
    </div>
   
    <!-- Upload Resume-->
    <div id="myModal_UploadFile" class="modal hide fade theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" data-original-title=""
                title="">
                ×</button>
            <h3>
                Upload Resume</h3>
        </div>
        <div class="modal-body">
            <iframe id="iframe3" src="../Area/UploadResume.aspx" width="100%" height="130px"
                frameborder="0" scrolling="no"></iframe>
            <!-- End modal-footer -->
        </div>
    </div>
    <!-- Upload Resume-->
    <!-- Upload Sucess-->
    <div id="myModal_UploadSucess" class="modal hide fade theModals " tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true" runat="server" clientidmode="Static">
        <div id="uploadSuccess" class="modal hide theModals in" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="false" style="display: block;" runat="server">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true" data-original-title=""
                    title="">
                    ×</button>
                <h3>
                    Upload Success</h3>
            </div>
            <div class="modal-body">
                <p>
                    Congratulations! You have successfully applied at Axact. Thank you for providing
                    your updated resume. This will indeed prove to be very useful to further evaluate
                    you and offer you the best position at Axact - World's Leading IT Company.</p>
                <p>
                    Connect with Facebook now to share this exciting news with your friends and family.</p>
                <div class="row-fluid uploaded">
                    <a href="javascript:;" class="clearfix connectFacebook" data-original-title="" title=""
                        onclick="window.open('../facebook/WallPost.aspx','_self'); return false;">
                        <img src="/Area/assets/img/connectFacebook.png" alt="">
                    </a>
                    <p class="clearfix notNow">
                        <a href="javascript:;" data-dismiss="modal" aria-hidden="true" data-original-title=""
                            title="" onclick="javascript:parent.location.href = 'http://careers.axact.com/Area/Area.aspx';">
                            Not Now! Later</a>
                    </p>
                </div>
                <!-- End row-fluid -->
            </div>
        </div>
    </div>
    <!-- End Upload Sucess-->
    

    <script type="text/javascript">

//        $(document).ready(function (e) {
//            /* Tabs */
//            $('.tabcontroller li a').click(function (e) {
//                $(this).addClass('active');
//                var relval = $(this).attr('data-rel');
//                $('.tabs-content div').hide();
//                $(this).parents().siblings().children().removeClass('active');
//                $('.' + relval + ' div').show();
//            });
//        });


        $(document).ready(function (e) {
            /* Tabs */
            $('.tabcontroller li a').click(function (e) {
                $(this).addClass('active');
                var relval = $(this).attr('data-rel');
                $('.tab1').hide();
                $('.tab2').hide();
                $('.tab3').hide();
                $(this).parents().siblings().children().removeClass('active');
                //alert('.' + relval + ' div');
                $('.' + relval + ' div').fadeIn();
                $('.' + relval + ' div').show();
                $('.' + relval).fadeIn();
                $('.' + relval).show();
            });
            $('.tab1 div').show(); $('.' + relval + ' div').fadeIn();
        });
      

        function validategetAssistance() {
            var isName = false;
            if ($('.codegetassistance').val() == "") {
                $('.codegetassistance').addClass('error');
            } else {
                $('.codegetassistance').removeClass('error');
                isName = true;
            }
            if (isName) {
                return true;
            }
            else {
                $(".errormsggetassistance").text("Please provide complete information");
                return false;
            }
        }


        function validateFormMobile() {
            var isName = false;
            if ($('.codemobile').val() == "") {
                $('.codemobile').addClass('error');
            } else {
                $('.codemobile').removeClass('error');
                isName = true;
            }
            if (isName) {
                return true;
            }
            else {
                $(".errormsgmobile").text("");
                $(".errormsgmobile").text("Please provide complete & valid information");
                return false;
            }
        }

        function validateFormEmail() {

            var isName = false;
            if ($('.codeemail').val() == "") {
                $('.codeemail').addClass('error');
            } else {
                $('.codeemail').removeClass('error');
                isName = true;
            }
            if (isName) {
                return true;
            }
            else {
                $(".errormsgemail").text("");
                $(".errormsgemail").text("Please provide complete & valid information");
                return false;
            }


        }
        function ClearText() {
            $('#<%=txtMsg.ClientID %>').val("");
            $('.codegetassistance').removeClass('error');
        }

        function ClearMobile() {

            window.frames['iframeMobileVerify'].document.getElementById('txtVerificationCode1').value = '';
            window.frames['iframeMobileVerify'].document.getElementById('txtVerificationCode1').className = '';
            window.frames['iframeMobileVerify'].document.getElementById('lblError1').style.display = 'none';
            window.frames['iframeMobileVerify'].document.getElementById('lblMsg1').style.display = 'none';

        }


        function ClearEmail() {

            window.frames['iframeEAdd'].document.getElementById('txtVerificationCode').value = '';
            window.frames['iframeEAdd'].document.getElementById('txtVerificationCode').className = '';
            window.frames['iframeEAdd'].document.getElementById('lblError').style.display = 'none';
            window.frames['iframeEAdd'].document.getElementById('lblMsg').style.display = 'none';
        }



        function VerifyGetAssistance() {
            var GetAssistanceCode = $('#<%=txtMsg.ClientID %>').val().trim();
            var CandidateCode = $('#<%=hfCandidateCode2.ClientID %>').attr('value');
            if (GetAssistanceCode == '') {
                $('.codegetassistance').addClass('error');

            }

            else {
                $('.codegetassistance').removeClass('error');

                $.ajax({
                    url: 'getassistancehandler.ashx?gc=' + GetAssistanceCode + '&cc=' + CandidateCode,
                    dataType: 'HTML',
                    async: true,
                    type: 'POST',
                    success: function (data) {
                        if (data != null && $.trim(data) != '') {
                            //                            alert(data);
                            //                            if (data == "False")
                            //                                $(".errormsggetassistance").text("Invalid Code");

                            //window.location = "http://xwebsrv:60114/Area/Area.aspx";
                            var v1 = '<%=ConfigurationManager.AppSettings["DomainAddress"].ToString() %>'
                            window.location = v1 + "/Area/Area.aspx";
                        }
                    }
                });
            }
        }

    </script>
</asp:Content>

