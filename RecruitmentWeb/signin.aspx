<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="signin.aspx.cs" Inherits="signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <script type="text/javascript">

        function validateForm(sender, arguments) {
            //alert("asdasda");
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
                    <h2>Welcome to
                        <%=ConfigurationManager.AppSettings["ClientName"].ToString() %>
                        Careers!</h2>
                    <p class="fa13 midgray">
                        Login to your applicant area to stay updated with your
                        <br />
                        application progress.
                    </p>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Email or Mobile Number</span>
                </div>
                <div class="span7">
                    <asp:TextBox ID="txtEmailOrMob" runat="server" MaxLength="100" CssClass="jqtranformdone email"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ControlToValidate="txtEmailOrMob"
                        ClientValidationFunction="ValidateTextBox" ValidateEmptyText="True"></asp:CustomValidator>
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
                </div>
                <div class="span5">
                    <a href="forgotpassword.aspx" title="" class="lineheight25 getforgot">Forgot Password?</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

'<!--Migrated Data- Form Pending-->
<div class="xbox">
<div class="row-fluid">
<div class="span12">
<h2>Welcome to Axact Careers! Complete your application</h2>
<p>VAR_Applicant_Name, welcome to our new recruitment system, where your existing application is present with us. However, some additional details are required from you to complete your application, which will help us evaluate and offer you the most suitable job position according to your profile.</p>
<p>Complete your profile by filling in the online application form or if you wish to take assistance from our career counselor, you may do so by clicking on the relevant link below. </p>
</div>
<div id="dvFirst" runat="server" class="row-fluid">
<div class="span6"> <a class="bottom-fifteen" href="javascript:void(0);"><img alt="" src="/Area/assets/img/step-form.png" /></a>
<p style="margin: 0px;"><span>Fill application form online in just a few easy steps.</span><br />
<br />
<br />
</p>
<a class="xBook-button-normal" href="/profile/redirector.aspx">Fill Application Form</a> </div>
<div class="span6 xborder-left-grey"> <a class="bottom-fifteen" href="javascript:void(0);"> <img alt="" src="/Area/assets/img/get-assistance.jpg" /></a>
<p style="margin: 0px;"><span>Contact our career counselors for assistance.</span> <br />
<br />
<br />
</p>
<button data-target="#xGetAssistance" data-toggle="modal" class="xBook-button-normal" type="button">Get Assistance</button>
</div>
</div>
</div>
</div>
<!--Migrated Data- Form Pending-->'
