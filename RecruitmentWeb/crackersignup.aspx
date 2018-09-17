<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crackersignup.aspx.cs" Inherits="crackersignup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home Cracker</title>
    <link rel="shortcut icon" href="/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="/Area/assets/css/xbook.css" />
    <script type="text/javascript" src="http://j.maxmind.com/app/geoip.js"></script>
    <script type="text/javascript" src="/Area/assets/js/jquery.js"></script> 
    <script type="text/javascript">
        function refreshParent(obj) {
            window.parent.location.href = obj;
        }
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

        function parenturl() {
            $('#txtParentUrl').val(document.referrer);
        }

        function setCookie(cname, cvalue, exdays) {
            if (cvalue != window.location.href) {
                var d = new Date();
                d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                var expires = "expires=" + d.toGMTString();
                document.cookie = cname + "=" + cvalue + "; " + expires;
                $('#txtParentUrl').val(cvalue);
                //alert($('#txtParentUrl').val());
            }
        }

        function getCookie(cname) {
            var name = cname + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i].trim();
                if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
            }
            return "";
        }

        function checkCookie() 
        {
            //debugger;
//            var user = getCookie("parentURL");
//            if (user != "") {
//                $('#txtParentUrl').val(user);                 
//            }
//            else {
                var user = document.referrer;                
                if (user != "" && user != null) {
                    setCookie("parentURL", user, 365);
                }
            //}
        }


    </script>
    <style type="text/css">
p { font-family: 'FranklinGothic-MediumCond'; font-size: 18px; color: white; }
.cracker-wrapper, .cracker-wrapper2 { padding: 0 30px; }
.error { background: #FFD9D9; border: 1px solid #F00; }
.addpad { padding-top: 4px; }
body { margin:0px; background:transparent; }
form { background:#fff; max-width:850px; }
* { margin:0px; padding:0px; }
</style>

</head>
<body onload="checkCookie();">
    <form id="form1" runat="server">
     <div style="display: none;">
        <asp:TextBox ID="txtParentUrl" runat="server" BorderStyle="None" Font-Size="0px"
                    ForeColor="#F6F6F6" Height="0px" Width="0px"></asp:TextBox>
      </div>
    <%--<div class="formhover pattern">
        <span class="apnow">Apply Now</span>
        <ul class="clearfix">
            <li>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFullname" runat="server" MaxLength="50" placeholder="Full Name"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" placeholder="Email Address"></asp:TextBox>
                        </td>
                        <td>
                            <a href="javascript:;" title="" id="AStep1" class="nextButton" onclick="javascript:return validateStep1();"><img src="/Area/assets/img/signupbtn.jpg"/></a>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlCountry" runat="server" onchange="ShowHideCodes();" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div id="dvCode" runat="server">
                                <asp:DropDownList ID="ddlPhoneCodes" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div id="dvCell" runat="server">
                                <asp:TextBox ID="txtCell" runat="server" MaxLength="7" onkeydown="return isNumberKey(this);"
                                    placeholder="Enter Mobile Number"></asp:TextBox>
                            </div>
                            <div id="dvOther" runat="server" style="display: none;">
                                <asp:TextBox ID="txtCell2" MaxLength="11" runat="server" onkeydown="return isNumberKey(this);"
                                placeholder="Enter Mobile Number"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <a href="javascript:;" title="" id="AStep2" class="nextButton" onclick="javascript:return validateStep2();"><img src="/Area/assets/img/signupbtn.jpg"/></a>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"
                                onkeyup='javascript:ValidatePasswordStrength();' MaxLength="20"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReEnterPassPassword" runat="server" TextMode="Password" placeholder="Confirm Password"
                                Text="Confirm Password" MaxLength="20"></asp:TextBox>
                        </td>
                        <td>
                             <asp:ImageButton ID="ImageButton2" runat="server" text="Next" OnClientClick="return validateStep3();"
                ImageUrl="/Area/assets/img/signupbtn.jpg" ValidationGroup="valida" OnClick="btnSignUp_Click" />
                        </td>
                    </tr>
                </table>
            </li>
        </ul>
        <span class="nextButton">
            <asp:ImageButton ID="ImageButton1" runat="server" text="Next" OnClientClick="return validateForm();"
                ImageUrl="/Area/assets/img/signupbtn.jpg" ValidationGroup="valida" OnClick="btnSignUp_Click" />
        </span><span class="thankMessage">Congratulations! Your application has been submitted.
            You can follow-up on the status of your application by your reference number.</span>
    </div>--%>




    <div class="formApply">
    <span class="apnow">Apply Now</span>
    <ul class="clearfix">
        <li class="first">
            <p><asp:TextBox ID="txtFullname" runat="server" MaxLength="50" placeholder="Full Name"></asp:TextBox> </p>
            <p> <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" placeholder="Email Address"></asp:TextBox></p>
            <p> <a href="javascript:;" title="" id="AStep1" class="nextButton" onclick="return validateStep1();">Next</a>
            </p>
        </li>
        <li class="second">
            <p><asp:DropDownList ID="ddlCountry" runat="server" Width="225px" onchange="ShowHideCodes();"> </asp:DropDownList></p>
            <p id="dvCode" runat="server">
            	<asp:DropDownList ID="ddlPhoneCodes" runat="server" Width="140px"></asp:DropDownList>
            </p>
            <p id="dvCell" runat="server">
            <asp:TextBox ID="txtCell" runat="server" MaxLength="7" Width="215px" onkeydown="return isNumberKey(this);" placeholder="Enter Mobile Number"></asp:TextBox>
            </p>
            <p id="dvOther" runat="server" style="display: none;">
            <asp:TextBox ID="txtCell2" MaxLength="11" runat="server" onkeydown="return isNumberKey(this);" placeholder="Enter Mobile Number"></asp:TextBox>
            </p>
            <p><a href="javascript:;" title="" id="AStep2" class="nextButton" onclick="return validateStep2();">Next</a></p>
        </li>
        <li class="third">
            <p> <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"
                                onkeyup='javascript:ValidatePasswordStrength();' MaxLength="20"></asp:TextBox> </p>
            <p> <asp:TextBox ID="txtReEnterPassPassword" runat="server" TextMode="Password" placeholder="Confirm Password"
                                Text="Confirm Password" MaxLength="20"></asp:TextBox></p>
            <p><asp:Button ID="ImageButton2" runat="server" text="Next" OnClientClick="return validateStep3();"
                CssClass="nextButton" ValidationGroup="valida" OnClick="btnSignUp_Click" />
                </p>
        </li>
    </ul>
    <!--<span class="nextButton">
    <asp:ImageButton ID="ImageButton1" runat="server" text="Next" OnClientClick="return validateForm();"
                ImageUrl="/Area/assets/img/signupbtn.jpg" ValidationGroup="valida" OnClick="btnSignUp_Click" /> </span>-->
    <%--<span class="thankMessage">Congratulations! Your application has been submitted.  You can follow-up on the status of your application by your reference number.</span>--%>
</div>
    </form>
</body>
<script type="text/javascript">
    /* $(document).ready(function () {
    var counter = 0;
    $('.formApply ul li, .thankMessage').hide();
    $('.formApply ul li:first').show();
    $(".formApply .nextButton").click(function () {
    $('.formApply ul li:visible').fadeOut(function () {
    counter++;
    $(this).next().fadeIn('slow');
    if (counter == 2) {
    $(".formApply .nextButton input[type=button]").val('Apply');
    }
    else if (counter == 3) {
    $('.formApply .apnow').hide();
    $(".formApply .nextButton input[type=button]").val('Thank You');
    }
    if ($('.formApply ul li:visible').length == 0) {
    $('.formApply .thankMessage').show();
    }
    });
    });
    });*/

    $('.formApply ul li:first').show();
    //$('.thankMessage').hide();

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

        if ($('.password').val().length == 0) {
            $('#progressbar').attr("style", "display:none");
            $('#complexity').attr("style", "display:none");
            return;
        }


        if ($('.password').val().length != 0) {
            $('#progressbar').attr("style", "display:''");
            $('#complexity').attr("style", "display:''");


            if ($('.password').val().length == 0) {
                CheckPasswordStrength(false, 0);
                return;
            }

            if ($('.password').val().length <= 6) {
                CheckPasswordStrength(false, 5);
                return;
            }
            if ($('.email').val().indexOf($('.password').val()) >= 0) {
                CheckPasswordStrength(false, 5);
                return;
            }

            if ($('.password').val().length >= 10) {
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
        else if ($('.password').val().length == 0) {
            CheckPasswordStrength(false, 0);
            return;
        }
    }

    function validateStep1() {
        //debugger;
        var isName = false;
        var isEmail = false;

        if ($('#txtFullname').val() == "") {
            $('#txtFullname').addClass('error');
        }
        else {
            $('#txtFullname').removeClass('error');
            isName = true;
        }
        if ($('#txtEmail').val() == "") {
            $('#txtEmail').addClass('error');
        }
        else {
            //  $('.email').removeClass('error');
            var emailRegex = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
            if (emailRegex.test($('#txtEmail').val())) {
                $('#txtEmail').removeClass('error');
                isEmail = true;

            }
            else {
                $('#txtEmail').addClass('error');
            }

        }

        if (isName && isEmail) {
            $(".errormsg").html("");
            $('.formApply ul li.first').hide();
            $('.formApply ul li.second').show();
            return true;
        }
        else {
            $(".errormsg").html("Please provide complete & valid information <br/>");
            return false;
        }
    }



    function validateStep2() {
        var isPhone = false;
        //debugger;
        if ($('#ddlCountry').val() == "172") {
            if ($('#txtCell').val() == "") {
                $('#txtCell').addClass('error');
            }
            else {
                var phoneRegex = new RegExp("^[0-99]*$");
                if (phoneRegex.test($('#txtCell').val())) {
                    $('#txtCell').removeClass('error');
                    isPhone = true;

                }
                else {
                    $('#txtCell').addClass('error');
                }

            }
        }
        else {
            if ($('#txtCell2').val() == "") {
                $('#txtCell2').addClass('error');
            }
            else {
                var phoneRegex = new RegExp("^[0-99]*$");
                if (phoneRegex.test($('#txtCell2').val())) {
                    $('#txtCell2').removeClass('error');
                    isPhone = true;

                }
                else {
                    $('#txtCell2').addClass('error');
                }
            }

        }
        if (isPhone) {
            $(".errormsg").html("");
            $('.formApply ul li.second').hide();
            $('.formApply ul li.third').show();
            $(".formApply .nextButton").val('Apply');
            return true;
        }
        else {
            $(".errormsg").html("Please provide complete & valid information");
            return false;
        }
    }

    function validateStep3() {
        var isPass, isConfirmPass, isPassMatch = false;
        //debugger;
        if ($('#txtPassword').val() == "") {
            $('#txtPassword').addClass('error');
        }
        else {
            $('#txtPassword').removeClass('error');
            isPass = true;
        }

        if ($('#txtReEnterPassPassword').val() == "") {
            $('#txtReEnterPassPassword').addClass('error');
        }
        else {
            isConfirmPass = true;

            if ($('#txtPassword').val() == $('#txtReEnterPassPassword').val()) {
                $('#txtReEnterPassPassword').removeClass('error');
                $('#txtPassword').removeClass('error');
                isPassMatch = true;
            }
            else {
                $('#txtPassword').addClass('error');
                $('#txtReEnterPassPassword').addClass('error');
                isPassMatch = false;
            }

            //$('.thankMessage').show();
        }
        if (isPass && isConfirmPass && isPassMatch) {
            $(".errormsg").html("");
            $('.formApply ul li.third').hide();
            return true;
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
	
</script>
</html>
