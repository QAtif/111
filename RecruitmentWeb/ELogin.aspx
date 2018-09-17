<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="ELogin.aspx.cs" Inherits="ELogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
   <script type="text/javascript">

        function validateForm(sender, arguments) {
            alert("asdasda");
            var isEmail, isPwd = false;
            if ($('.email').val().trim() == "") {
                $('.email').addClass('error');
            } else {
                $('.email').removeClass('error');
                isEmail = true;
            }
            if ($('.password').val().trim() == "") {
                $('.password').addClass('error');
            } else {
                $('.password').removeClass('error');
                isPwd = true;
            }
            if (isEmail && isPwd) {
                $(".errormsg").text("");
            }
            else {
                $(".errormsg").text("Please provide complete information");
                arguments.IsValid = false;
                return false;
            }
        }

        function ValidateTextBox(source, args) {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                if (val == source) {
                    var cntrl_id = val.controltovalidate;
                    var cntrl = $("#" + cntrl_id);
                    var is_valid = $(cntrl).val().trim() != "";
                    is_valid ? $(cntrl).removeClass("error") : $(cntrl).addClass("error");

                    if (!is_valid)
                        $(".errormsg").text("Please provide complete & valid information");
                    args.IsValid = is_valid;
                }
            }

            //var cntrl_id = $(source).attr("ControlToValidate");
            //var cntrl_id = "ContentContainer_txtEmailOrMob";

        }
    </script>
    <div class="span7">
        <div class="signin loginscr">
            <div class="row-fluid">
                <div class="span12">
                    <h2>
                        Welcome to
                        <%=ConfigurationManager.AppSettings["ClientName"].ToString() %>
                        Careers!</h2>
                    <p class="fa13 midgray">
                        Login to your applicant area to stay updated with your
                        <br />
                        application progress.</p>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Email or Mobile Number</span>
                </div>
                <div class="span7">
                    <asp:Label ID="lblEmail" Text="Email Address" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Password</span>
                </div>
                <div class="span7">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="jqtranformdone password"
                        MaxLength="20"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ControlToValidate="txtPassword"
                        ClientValidationFunction="ValidateTextBox" ValidateEmptyText="True"></asp:CustomValidator>
                    <asp:CustomValidator ID="vldLoginFailed" runat="server" ErrorMessage="" ClientValidationFunction="validateForm"
                        Visible="false" CssClass=""></asp:CustomValidator>
                    <asp:Label ID="lblError" runat="server" CssClass="errormsg red"></asp:Label>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4">
                </div>
                <div class="span2">
                    <asp:ImageButton ID="btnSignIn" runat="server" Text="Sign In" ImageUrl="/Area/assets/img/loginbtn.jpg"
                        OnClick="btnSignIn_Click" />
                    <asp:HiddenField ID="hdnCandidateCode" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnURL" runat="server" Value="" />
                </div>
                <div class="span5">
                    <a href="forgotpassword.aspx" title="" class="lineheight25 getforgot">Forgot Password?</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
