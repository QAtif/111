<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/SiteMaster.master"
    ValidateRequest="false" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs"
    Inherits="forgotpassword" %>

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
                                Forgot Password</h2>
                            <p class="fa13 midgray">
                                An automated Email will be sent to your email address <br>
                                to reset your password.
                            </p>
                            <br>
                            <br>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4 lineheight25">
                            <span>Email</span>
                        </div>
                        <div class="span7">
                            <asp:TextBox ID="txtEmailOrMob" runat="server" MaxLength="100" CssClass="jqtranformdone email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span7">
                            <asp:Label ID="lblError" runat="server" CssClass="errormsg red" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblMsg" runat="server" CssClass="success"></asp:Label>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span2">
                            <asp:ImageButton ID="btnSignIn" runat="server" Text="Sign Me In Now" ImageUrl="/Area/assets/img/submitbtn.jpg"
                                OnClientClick="return validateForm();" OnClick="btnSendPassword_Click" />
                             <div class="span5"> <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
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
            var isEmail = false;
            if ($('.email').val().trim() == "") {
                $('.email').addClass('error');
            } else {
                $('.email').removeClass('error');
                isEmail = true;
            }
            if (isEmail) {
                $(".errormsg").text("");
            }
            else {
                $(".success").text("");
                $(".errormsg").text("Please provide complete information");
                return false;
            }
        } 
    </script>
</asp:Content>