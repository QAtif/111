<%@ Page Language="C#" AutoEventWireup="true" CodeFile="verify.aspx.cs" Inherits="Area_verification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!--#include virtual="/Area/includes/header-scripts.html"-->
    <style type="text/css">
        body
        {
            background: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divmainMob" runat="server">
        <div class="modal-body">
            <p>
                We need to verify your mobile number. For this purpose a verification code has been
                sent by sms on your mobile phone. Enter the verification code below:
            </p>
            <div align="center">
                <br />
                <table width="70%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;
                    border-spacing: 0; color: #666666; font: 11px 'LucidaGrande';">
                    <tr>
                        <td width="140">
                            Verification Code
                        </td>
                        <td>
                            <asp:TextBox ID="txtVerificationCode1" runat="server" CssClass="jqtranformdone  codemobile"
                                MaxLength="100"></asp:TextBox>
                            <asp:HiddenField ID="hfCandidateCode1" runat="server" />
                            <asp:HiddenField ID="hdnVerificationCode1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            &nbsp;
                        </td>
                        <td>
                            <span runat="server" id="spErrorMsg1" style="display: none;">
                                <asp:Label ID="lblMsg1" runat="server" CssClass="errormsg"></asp:Label></span>
                            <div>
                                <asp:Label ID="lblError1" runat="server" ForeColor="Red" CssClass="errormsgmobile"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="modal-footer">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button runat="server" ID="phoneVerify" CssClass="xBook-button-normal button"
                        OnClick="lnkVerifyMobile_Click" Text="Verify" OnClientClick="javascript:return validateFormMobile();" />
                    <asp:Button ID="lnkResendCodeMobile" Text="Resend Code" OnClick="lnkResendCodeMobile_Click"
                        runat="server" Style="width: 105px;" CssClass="xBook-button-back resend-btn" />
                    <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:RefreshParent();"
                        ForeColor="White" class="xBook-button-back" />--%>
                </div>
            </div>
        </div>
    </div>
    <div id="divmainEAdd" runat="server">
        <div class="modal-body">
            <p>
                We need to verify your email address. For this purpose a verification code has been
                emailed to you. Enter the verification code below:
            </p>
            <div align="center">
                <br />
                <table width="70%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;
                    border-spacing: 0; color: #666666; font: 11px 'LucidaGrande';">
                    <tr>
                        <td width="140">
                            Verification Code
                        </td>
                        <td>
                            <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="jqtranformdone  codeemail"
                                MaxLength="100"></asp:TextBox>
                            <asp:HiddenField ID="hfCandidateCode" runat="server" />
                            <asp:HiddenField ID="hdnVerificationCode" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35">
                            &nbsp;
                        </td>
                        <td>
                            <span runat="server" id="spErrorMsg" style="display: none;">
                                <asp:Label ID="lblMsg" runat="server" CssClass="errormsg"></asp:Label></span>
                            <div>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="errormsgemail"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="modal-footer">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button runat="server" ID="emailVerify" CssClass="xBook-button-normal button"
                        OnClick="lnkVerifyEmail_Click" Text="Verify" OnClientClick="javascript:return validateFormEmail();" />
                    <asp:Button ID="lnkResendCodeEmail" Text="Resend Code" OnClick="lnkResendCodeEmail_Click"
                        runat="server" Style="width: 105px;" CssClass="xBook-button-back resend-btn" />
                    <%--<asp:Button ID="btnCancel1" runat="server" Text="Cancel" OnClientClick="javascript:RefreshParent();"
                        ForeColor="White" class="xBook-button-back" />--%>
                </div>
            </div>
        </div>
    </div>
    </form>
    <!--#include virtual="/Area/includes/footer-scripts.html"-->
</body>
</html>

<script type="text/javascript" language="javascript">

    function RefreshParent() {
        parent.location.reload(true);
    }

    function validateFormMobile() {
        var isMobile = false;
        if ($('.codemobile').val() == "") {
            $('.codemobile').addClass('error');
        } else {
            $('.codemobile').removeClass('error');
            isMobile = true;
        }
        if (isMobile) {
            return true;
        }
        else {
            $(".errormsgmobile").show();
            $(".errormsg").hide();
            $(".errormsgmobile").text("");
            $(".errormsgmobile").text("Please provide valid verification code");
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
            $(".errormsgemail").show();
            $(".errormsg").hide();
            $(".errormsgemail").text("");
            $(".errormsgemail").text("Please provide valid verification code");
            return false;
        }


    }


</script>

<style type="text/css">
    .error
    {
        /*background: #FFD9D9 !important;*/
        border: 1px solid #CC0000 !important;
    }
    .red
    {
        color: #CC0000 !important;
    }
</style>
