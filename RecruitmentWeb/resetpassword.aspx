<%@ Page Language="C#" Title="Reset Password" MasterPageFile="~/SiteMaster.master"
    ValidateRequest="false" AutoEventWireup="true" CodeFile="resetpassword.aspx.cs"
    Inherits="ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="span7">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="signin loginscr">
                    <div class="row-fluid">
                        <div class="span12">
                            <h2>
                                Reset Password</h2>
                            <p class="fa13 midgray">
                                Provide a new password to access your Account Area.<br>
                                
                            </p>
                            <br>
                            <br>
                        </div>
                    </div>
                    <div class="row-fluid" runat="server" id="dvForm">
                        <div class="span4 lineheight25">
                            <span>&nbsp;&nbsp; New Password:</span>
                        </div>
                        <div class="span7">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="jqtranformdone newpass"></asp:TextBox>
                        </div>
                        <div class="lineheight25">
                            <br>
                            <span style="margin-left: 2.564%; float: left;">Re-type New Password:&nbsp;&nbsp;</span>
                        </div>
                        <div class="span7">
                            <asp:TextBox ID="txtRetypeNewPassword" runat="server" TextMode="Password" CssClass="jqtranformdone retypenewpass"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span7">
                            <asp:Label ID="lblError" runat="server" CssClass="errormsg red"></asp:Label>
                            <asp:Label ID="lblMsg" runat="server" CssClass="success"></asp:Label><br />
							<a href="area/Area.aspx" id="aLogin" runat="server">Click here to login.</a>
                            <asp:HiddenField ID="hdncandidateCode" runat="server" />
                            <asp:HiddenField ID="hdnemailAddress" runat="server" />
                            <asp:HiddenField ID="hdnexpiry" runat="server" />
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span2" runat="server" id="dvbtn">
                            <asp:ImageButton ID="btnSendPassword" runat="server" Text="Send Me Password Now"
                                ImageUrl="/Area/assets/img/submitbtn.jpg" OnClick="btnSendPassword_Click"
                                OnClientClick="return validateForm();" />
                            <div class="span5">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                    DisplayAfter="0">
                                    <ProgressTemplate>
                                        <img src="/Area/assets/img/loading.gif" alt="" align="middle" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        function validateForm() {
            var isPass, isConfirmPass, isPassMatch = false;
            if ($('.newpass').val() == "") {
                $('.newpass').addClass('error');
            } else {
                $('.newpass').removeClass('error');
                isPass = true;
            }

            if ($('.retypenewpass').val() == "") {
                $('.retypenewpass').addClass('error');
            } else {
                isConfirmPass = true;

                if ($('.newpass').val() == $('.retypenewpass').val()) {
                    $('.retypenewpass').removeClass('error');
                    $('.newpass').removeClass('error');
                    isPassMatch = true;
                }
                else {
                    $('.newpass').addClass('error');
                    $('.retypenewpass').addClass('error');
                    isPassMatch = false;
                }
            }

            if (isPass && isConfirmPass) {
                if (isPassMatch)
                    $(".errormsg").text("");
                else {
                    $(".errormsg").text("Password does not match");
                    return false;
                }
            }
            else {
                $(".errormsg").text("Please provide complete & valid information");
                return false;
            }
        } 
    </script>
</asp:Content>
