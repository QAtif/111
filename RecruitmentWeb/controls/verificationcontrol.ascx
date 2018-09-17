<%@ Control Language="C#" AutoEventWireup="true" CodeFile="verificationcontrol.ascx.cs"
    EnableViewState="true" Inherits="controls_verificationcontrol" %>
<style type="text/css">
    .error
    {
        /*background: #FFD9D9 !important;*/
        border: 1px solid #CC0000 !important;
    }
    .errormsgemail
    {
        /*background: #FFD9D9 !important;*/
        border: 1px solid #CC0000 !important;
    }
</style>
<script type="text/javascript">

    function validateFormMobile() {
        var isName = false;
        if ($('.codemobile').val() == "") {
            $('.codemobile').addClass('error');
        } else {
            $('.codemobile').removeClass('error');
            isName = true;
        }
        if (isName) {
        }
        else {
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
        }
        else {
            $(".errormsgemail").text("Please provide complete & valid information");
            return false;
        }
    }
</script>
<div class="span4">
    <aside>
<div class="xbox-with-heading">
          <h3>Verify Contact Information</h3>
          <div class="xbox-content">
          <p>We need to verify your contact information. </p>
            <ul class="summary-list">
              <li>
                <div class="summary-head"><img src="/Area/assets/img/icons/phone.png" class="img-pad4x" alt=""> Phone</div>
                <div class="summary-value"><asp:Label runat="server" ID="lblPhoneNumber"> </asp:Label>... <span runat="server" id="spverified1"><img src="/Area/assets/img/icons/tik.png" style="float:right" class="img-pad4x" alt=""></span>  <span runat="server" id="spnotverified1" >(<a href="#myModal_VerifyMobile" data-toggle="modal" role="button">Verify</a>)</span></div>
              </li>
              <li>
                <div class="summary-head"><img src="/Area/assets/img/icons/email.png" class="img-pad4x" alt=""> Email</div>
                <div class="summary-value"><asp:Label runat="server" ID="lblEmail"> </asp:Label> ... <span runat="server" id="spverified2"><img src="/Area/assets/img/icons/tik.png" style="float:right" class="img-pad4x" alt=""></span>  <span runat="server" id="spnotverified2" >(<a href="#myModal_VerifyEmail" data-toggle="modal" role="button">Verify</a>)</span></div>
              </li>
         
            </ul>
          </div>
        </div>
         </aside>
</div>
<!-- Email Verify  -->
<div id="myModal_VerifyEmail" class="modal hide fade theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            ×</button>
        <h3>
            Verify Email Address</h3>
    </div>
    <div class="modal-body">
        <p>
            We need to verify your email address. For this purpose a verification code has been
            emailed to you. Enter the verification code below:
        </p>
        <div align="center">
            <br />
            <table width="70%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        Verification Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="jqtranformdone  codeemail"
                            MaxLength="100"></asp:TextBox>
                            <asp:HiddenField   ID="hdnVerificationCode" runat="server" />
                        <br />
                        <span runat="server" id="spErrorMsg" style="display: none;">
                            <asp:Label ID="lblMsg" runat="server" CssClass="errormsg red"></asp:Label></span>
                        <div class="span7">
                            <asp:Label ID="lblError" runat="server" CssClass="errormsgemail red"></asp:Label></div>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
    <div class="modal-footer">
        <div class="row-fluid">
            <div class="span12">
                <asp:LinkButton ID="lnkVerifyEmail" Text="Verify" OnClick="lnkVerifyEmail_Click"
                    runat="server" OnClientClick="return validateFormEmail();" />
                <asp:LinkButton ID="lnkResendCodeEmail" Text="Resend Code" OnClick="lnkResendCodeEmail_Click"
                    runat="server" />
                <button class="xBook-button-back cancle-btn" data-toggle="modal" data-dismiss="modal">
                    Cancel</button>
            </div>
        </div>
    </div>
</div>
<!-- end Email Verify -->
<!-- Mobile Verify  -->
<div id="myModal_VerifyMobile" class="modal hide fade theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            ×</button>
        <h3>
            Verify Mobile Number</h3>
    </div>
    <div class="modal-body">
        <p>
            We need to verify your mobile number. For this purpose a verification code has been
            sent by sms on your mobile phone. Enter the verification code below:
        </p>
        <div align="center">
            <br />
            <table width="70%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        Verification Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtVerificationCode1" runat="server" CssClass="jqtranformdone  codemobile"
                            MaxLength="100"></asp:TextBox>
                        <br />
                        <span runat="server" id="spErrorMsg1" style="display: none;">
                            <asp:Label ID="lblMsg1" runat="server" CssClass="errormsg red"></asp:Label></span>
                        <div class="span7">
                            <asp:Label ID="lblError1" runat="server" CssClass="errormsgmobile red"></asp:Label></div>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
    <div class="modal-footer">
        <div class="row-fluid">
            <div class="span12">
                <asp:LinkButton ID="lnkVerifyMobile" Text="Verify" OnClick="lnkVerifyMobile_Click"
                    runat="server" OnClientClick="return validateFormMobile();" />
                <asp:LinkButton ID="lnkResendCodeMobile" Text="Resend Code" OnClick="lnkResendCodeMobile_Click"
                    runat="server" />
                <button class="xBook-button-back cancle-btn" data-toggle="modal" data-dismiss="modal">
                    Cancel
                </button>
            </div>
        </div>
    </div>
</div>
<!-- end Mobile Verify -->
