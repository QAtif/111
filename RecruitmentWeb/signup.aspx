<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <title>Signup Now to Apply At Axact</title>
    <script type="text/javascript">
        function ShowHideCodes() {
            var ddl = document.getElementById('<%=ddlCountry.ClientID%>');
            var codes = document.getElementById('<%=ddlPhoneCodes.ClientID%>');
            var txt = document.getElementById('<%=txtCell.ClientID%>');

            var dvCode = document.getElementById('<%=dvCode.ClientID%>');
            var dvCell = document.getElementById('<%=dvCell.ClientID%>');
            var dvOther = document.getElementById('<%=dvOther.ClientID%>');

            if (ddl.value == '172') {
                dvOther.style.display = 'none';
                dvCode.style.display = '';
                dvCell.style.display = '';
                // codes.style.display = '';
            }
            else {
                dvOther.style.display = '';
                dvCode.style.display = 'none';
                dvCell.style.display = 'none';
                // codes.style.display = 'none';
            }
            return false;
        }

    </script>
    <script type="text/javascript">

        function checkCookie() {

            var user = document.referrer;

            if (user != "" && user != null) {
                setCookie("parentURL", user, 365);
            }
        }
        function setCookie(cname, cvalue, exdays) {

            if (cvalue != window.location.href) {
                var d = new Date();
                d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                var expires = "expires=" + d.toGMTString();
                document.cookie = cname + "=" + cvalue + "; " + expires;
                //debugger;
                document.getElementById('ContentContainer_txtParentUrl').value = cvalue;
                //alert(document.getElementById('ContentContainer_txtParentUrl').value);

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="span7">
        <div class="signin signupscr">
            <div class="row-fluid">
                <div class="span12">
                    <h2>Welcome to
                        <%=ConfigurationManager.AppSettings["ClientName"].ToString() %>
                        Careers!</h2>
                    <p class="fa13 midgray">
                        Sign up with us to become a part of
                        <%=ConfigurationManager.AppSettings["ClientName"].ToString() %>'s Lifestyle.
                    </p>
                    <asp:HiddenField ID="hdnXML" runat="server" />
                    <asp:HiddenField ID="hdnSignuptypecode" runat="server" Value="1" />
                    <asp:HiddenField ID="hdnCanCode" runat="server" />
                    <asp:HiddenField ID="txtParentUrl" runat="server" />
                </div>
            </div>
            <div class="row-fluid" style="padding-top: 10px;" id="dvResume" runat="server" visible="false">
                <div class="span4 lineheight25">
                    <span>Resume</span>
                </div>
                <div class="span7">
                    <a href="javascript:" runat="server" id="aResume">View Resume</a>
                </div>
            </div>
            <div class="row-fluid" style="padding-top: 10px;">
                <div class="span4 lineheight25">
                    <span>Full Name</span>
                </div>
                <div class="span7">
                    <asp:TextBox ID="txtFullname" runat="server" onpaste="return false;" onkeydown="return isAlphabatKey(this);" MaxLength="50" CssClass="jqtranformdone fullname"></asp:TextBox>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Email Address</span>
                </div>
                <div class="span7">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="jqtranformdone email"></asp:TextBox>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Country</span>
                </div>
                <div class="span7">
                    <asp:DropDownList ID="ddlCountry" runat="server" onchange="ShowHideCodes();" CssClass="country">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Mobile Number</span>
                </div>
                <div id="dvCode" runat="server" class="span2">
                    <asp:DropDownList ID="ddlPhoneCodes" runat="server">
                    </asp:DropDownList>
                </div>
                <div id="dvCell" runat="server" class="span5">
                    <asp:TextBox ID="txtCell" runat="server" MaxLength="7" onkeydown="return isNumberKey(this);"
                        CssClass="jqtranformdone cell"></asp:TextBox>
                </div>
                <div id="dvOther" runat="server" style="display: none" class="span7">
                    <asp:TextBox ID="txtCell2" runat="server" onkeydown="return isNumberKey(this);"
                        CssClass="jqtranformdone othercell"></asp:TextBox>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span4 lineheight25">
                    <span>Password</span>
                </div>
                <div class="span7">
                    <div class="span6">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter Password" onkeyup='javascript:ValidatePasswordStrength();'
                            CssClass="jqtranformdone password"
                            MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="span6">
                        <asp:TextBox ID="txtReEnterPassPassword" runat="server" TextMode="Password" placeholder="Confirm Password" Text="Confirm Password" CssClass="jqtranformdone confirmpassword"
                            MaxLength="20"></asp:TextBox>

                    </div>
                </div>
            </div>

            <div class="row-fluid">
                <div class="span4 lineheight25"></div>
                <div class="span7">

                    <div id="progressbar" style="display: none" class="progress progress-success span9">
                        <div id="progress" class="bar progressbarInvalid">
                        </div>
                    </div>
                    <div id="complexity" style="display: none" class="span3">
                    </div>
                    <asp:Label ID="lblError" runat="server" CssClass="errormsg red"></asp:Label>
                </div>
            </div>
            <div class="row-fluid testp">
                <div class="span4">
                </div>
                <div class="signUp test">
                    <asp:ImageButton ID="ImageButton1" runat="server" text="Sign Me Up Now" OnClientClick="return validateForm();"
                        ImageUrl="/Area/assets/img/signupbtn.jpg" ValidationGroup="valida" CssClass="xSignupNow"
                        OnClick="btnSignUp_Click" />
                </div>
                <div>
                    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                        DisplayAfter="0">
                        <ProgressTemplate>
                            <img src="/Area/assets/img/loading.gif" alt="" align="middle" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>--%>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function CheckPasswordStrength(isvalid, complex) {
            if (!isvalid) {
                $('#progress').css({
                    'width': complex * 4 + '%'
                }).removeClass('progressbarValid').addClass('progressbarInvalid');
            } else {
                $('#progress').css({
                    'width': complex * 4 + '%'
                }).removeClass('progressbarInvalid').addClass('progressbarValid');
            }


            if (complex * 4 >= 0 && complex * 4 <= 25) {

                //$('#complexity').html(Math.round(complex * 4) + '% Weak');
                $('#complexity').html('Weak');
            }

            else if (complex * 4 >= 26 && complex * 4 <= 50) {
                //            else if (complex * 4 <= 68) {
                //$('#complexity').html(Math.round(complex * 4) + '% Medium');
                $('#complexity').html('Medium');
                //  $('#complexity').html(50 + '% Medium');
            }

                //            else if (complex * 4 <= 90) {
            else if (complex * 4 >= 51 && complex * 4 <= 75) {
                // $('#complexity').html(80 + '% Strong');
                //$('#complexity').html(Math.round(complex * 4) + '% Strong');

                $('#complexity').html('Strong');
            }

            else if (complex * 4 >= 76 && complex * 4 <= 100) {
                // $('#complexity').html(80 + '% Strong');
                //$('#complexity').html(Math.round(complex * 4) + '% Strong');

                $('#complexity').html('Strongest');
            }

            else if (complex * 4 >= 101) {
                // $('#complexity').html(80 + '% Strong');
                //$('#complexity').html(Math.round(complex * 4) + '% Strong');

                $('#complexity').html('Strongest');
            }


            //            if (complex == 0) {
            //			
            //                //$('#complexity').html('0' + '% Weak');
            //                $('#complexity').html('');
            //				
            //            }

            //            if (complex * 4 >= 100) {
            //                //$('#complexity').html('100' + '% Strong');
            //                $('#complexity').html('Strong');
            //            }

            //            if (complex * 4 <= 34) {

            //                //$('#complexity').html(Math.round(complex * 4) + '% Weak');
            //                
            //				$('#complexity').html('Weak');
            //				
            //            }

            //            else if (complex * 4 <= 68) {
            //                //$('#complexity').html(Math.round(complex * 4) + '% Medium');
            //                $('#complexity').html('Medium');
            //                //  $('#complexity').html(50 + '% Medium');
            //            }

            //            else if (complex * 4 <= 90) {
            //                // $('#complexity').html(80 + '% Strong');
            //                //$('#complexity').html(Math.round(complex * 4) + '% Strong');
            //                $('#complexity').html('Strong');
            //            }

            //            else {
            //                if (Math.round(complex * 4) >= 100) {
            //                    //$('#complexity').html('100' + '% Strong');
            //                    $('#complexity').html('Strong');
            //                }
            //                else {
            //                    // change string Strong to show very Strong :)
            //                    //$('#complexity').html(Math.round(complex * 4) + '%  Strong');
            //                    $('#complexity').html('Strong');
            //                }
            //            }
        }

        function ValidatePasswordStrength() {
            //debugger;
            var score = 1; var isOK = false;
            var complexity = 0; var valid = false;

            if ($('.password').val().trim().length == 0) {
                $('#progressbar').attr("style", "display:none");
                $('#complexity').attr("style", "display:none");
                return;
            }


            if ($('.password').val().trim().length != 0) {
                $('#progressbar').attr("style", "display:''");
                $('#complexity').attr("style", "display:''");


                if ($('.password').val().trim().length == 0) {
                    CheckPasswordStrength(false, 0);
                    return;
                }

                if ($('.password').val().trim().length <= 6) {
                    CheckPasswordStrength(false, 5);
                    return;
                }
                if ($('.email').val().trim().indexOf($('.password').val()) >= 0) {
                    CheckPasswordStrength(false, 5);
                    return;
                }

                if ($('.password').val().trim().length >= 10) {
                    score++;
                    complexity = complexity + 6.25;
                }
                var numberRegex = new RegExp("[0-9]", "g");
                if (numberRegex.test($('.password').val())) {
                    score++;
                    complexity = complexity + 6.25;
                }

                var alphaRegex = new RegExp("[a-zA-Z]+", "g");
                if (alphaRegex.test($('.password').val())) {
                    score++;
                    complexity = complexity + 6.25;
                }

                var charRegex = /.[!,@,#,$,%,^,&,*,?,_,~,.,-,£,(,)]/;
                if (charRegex.test($('.password').val())) {
                    score++;
                    complexity = complexity + 6.25;
                }

                CheckPasswordStrength(valid, complexity);
            }
            else if ($('.password').val().trim().length == 0) {
                CheckPasswordStrength(false, 0);
                return;
            }
        }

        function validateForm() {
            var isName, isEmail, isPhone, isPass, isConfirmPass, isPassMatch = false;
            if ($('.fullname').val().trim() == "") {
                $('.fullname').addClass('error');
            } else {
                $('.fullname').removeClass('error');
                isName = true;
            }
            if ($('.email').val().trim() == "") {
                $('.email').addClass('error');
            } else {
                //  $('.email').removeClass('error');
                var emailRegex = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
                if (emailRegex.test($('.email').val().trim())) {
                    $('.email').removeClass('error');
                    isEmail = true;
                }
                else {
                    $('.email').addClass('error');
                }
            }

            if ($('.password').val().trim() == "") {
                $('.password').addClass('error');
            } else {
                $('.password').removeClass('error');
                isPass = true;
            }

            if ($('.confirmpassword').val().trim() == "") {
                $('.confirmpassword').addClass('error');
            } else {
                isConfirmPass = true;

                if ($('.password').val().trim() == $('.confirmpassword').val().trim()) {
                    $('.confirmpassword').removeClass('error');
                    $('.password').removeClass('error');
                    isPassMatch = true;
                }
                else {
                    $('.password').addClass('error');
                    $('.confirmpassword').addClass('error');
                    isPassMatch = false;
                }
            }

            if ($('.country').val() == "172") {
                if ($('.cell').val() == "") {
                    $('.cell').addClass('error');
                } else {
                    //$('.cell').removeClass('error');

                    var phoneRegex = new RegExp("^[0-99]*$");
                    if (phoneRegex.test($('.cell').val())) {
                        $('.cell').removeClass('error');
                        isPhone = true;
                    }
                    else {
                        $('.cell').addClass('error');
                    }
                }
            }
            else {
                if ($('.othercell').val().trim() == "") {
                    $('.othercell').addClass('error');
                } else {
                    var phoneRegex = new RegExp("^[0-99]*$");
                    if (phoneRegex.test($('.othercell').val())) {
                        $('.othercell').removeClass('error');
                        isPhone = true;
                    }
                    else {
                        $('.othercell').addClass('error');
                    }
                }
            }

            if (isName && isEmail && isPass && isPhone && isConfirmPass) {
                if (isPassMatch)
                    $(".errormsg").html("");
                else {
                    $(".errormsg").html("Password does not match <br/>");
                    return false;
                }
            }
            else {
                $(".errormsg").html("Please provide complete & valid information");
                return false;
            }
        }

        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var isnumeric = false;
            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 9)
                isnumeric = true;
            if (charCode == 110)
                isnumeric = true;
            if (charCode == 190)
                isnumeric = true;
            if (charCode >= 37 && charCode <= 40)
                isnumeric = true;
            if (charCode >= 96 && charCode <= 105)
                isnumeric = true;

            return isnumeric;

        }

        function isAlphabatKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var isnumeric = false;
            if (charCode >= 65 && charCode <= 90)
                isnumeric = true;
            if (charCode == 57)
                isnumeric = true;
            if (charCode == 48)
                isnumeric = true;
            if (charCode == 189)
                isnumeric = true;
            if (charCode == 55)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 222)
                isnumeric = true;
            if (charCode == 17)
                isnumeric = false;
            if (charCode == 32)
                isnumeric = true;
            if (charCode == 9)
                isnumeric = true;
            return isnumeric;

        }



    </script>
</asp:Content>
