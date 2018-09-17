<%@ Page Title="Verification" Language="C#" MasterPageFile="~/SiteMaster.master"
    AutoEventWireup="true" CodeFile="verification.aspx.cs" Inherits="verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <title>Verification to Apply At Axact</title>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="span7">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="signin forgetpass">
                    <div class="row-fluid">
                        <div class="span12">
                            <h2>
                                Verify your Account!</h2>
                            <p class="fa13 midgray">
                                To get started with your application, you first need to verify your account information
                                i.e. email address and mobile number. For this purpose a verification code has been
                                emailed and sent by SMS on your mobile phone.
                                <br>
                                <br>
                               Please provide any one of the verification codes to proceed further:</p>
                            <br>
                            <br>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4 lineheight25">
                            <span>Verification Code</span>
                        </div>
                        <div class="span7">
                            <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="jqtranformdone code"
                                MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span7">
                            <asp:Label ID="lblError" runat="server" CssClass="errormsg red"></asp:Label>
                            <asp:Label ID="lblMsg" runat="server" CssClass="success"></asp:Label>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span2">
                            <asp:ImageButton ID="btnVerify" runat="server" text="Proceed Me Now" OnClientClick="return validateForm();"
                                ImageUrl="/Area/assets/img/verifybtn.jpg" OnClick="btnVerify_Click" />
                        </div>
                        <div class="span5">
                            <asp:ImageButton ID="btnSave" runat="server" text="Proceed Me Now" ImageUrl="/Area/assets/img/resendcodebtn.jpg"
                                OnClick="btnSave_Click" />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="/Area/assets/img/loading.gif" alt="" align="middle" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        function validateForm() {
            var isCode = false;
            if ($('.code').val().trim() == "") {
                $('.code').addClass('error');
            } else {
                $('.fullname').removeClass('error');
                isCode = true;
            }


            if (isCode) {
                $(".errormsg").text("");
            }
            else {
                $(".errormsg").text("Please provide valid Verification Code");
                return false;
            }

        }


    </script>

</asp:Content>