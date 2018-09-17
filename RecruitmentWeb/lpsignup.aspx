<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lpsignup.aspx.cs" Inherits="lpsignup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1" />
<title>Signup Now to Apply At Axact</title>
<link rel="shortcut icon" href="/favicon.ico" />
<link rel="stylesheet" type="text/css" href="/Area/assets/css/xBook.css" />
<script type="text/javascript" src="http://j.maxmind.com/app/geoip.js"></script>
<script type="text/javascript" src="/Area/assets/js/jquery.js"></script> 
<style type="text/css">
    .error
        {
            background: #FFD9D9 !important;
            border: 1px solid #F00 !important;
        }
		body { background:#fbb51b; margin:0; }
    </style>
<script language="javascript" >
    function refreshParent(obj) {
        //debugger;
        window.parent.location.href = obj;
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

    function checkCookie() {
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
</head>
<body onload="checkCookie();">
    <form id="form1" runat="server">
    <div style="display: none;">
        <asp:TextBox ID="txtParentUrl" runat="server" BorderStyle="None" Font-Size="0px"
            ForeColor="#F6F6F6" Height="0px" Width="0px"></asp:TextBox>
    </div>
	<article class="formbox">
    	<div class="applyForm">
        <h3>Welcome to <strong>Axact!</strong></h3>
        <h4><strong>Sign Up Now</strong> to become part of <br> World’s Leading IT Company</h4>
        <div class="row-fluid" style="padding-top: 10px;" id="dvResume" runat="server" visible="false">
            <div class="span4 lineheight25">
                <span>Resume</span>
            </div>
            <div class="span7">
                <a href="javascript:" runat="server" id="aResume">View Resume</a>
            </div>
        </div>
        <table>
          <tr>
            <td>
                <asp:TextBox ID="txtFullname" runat="server" MaxLength="50" placeholder="Full Name*"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
        
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" placeholder="Email Address*"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td><p>Country*</p></td>
          </tr>
          <tr>
            <td>
        
                <asp:DropDownList ID="ddlCountry" runat="server" onchange="ShowHideCodes();" CssClass="country">
                </asp:DropDownList>
           </td>
          </tr>
          <tr>
            <td><p>Mobile Number</p></td>
          </tr>
          <tr>
            <td>
        
            <div id="dvCode" runat="server">
                <asp:DropDownList ID="ddlPhoneCodes" runat="server" class="mobcode">
                </asp:DropDownList>
            </div>
            <div id="dvCell" runat="server">
                <asp:TextBox ID="txtCell" runat="server" MaxLength="9" onkeydown="return isNumberKey(this);"
                     class="mobnumber"></asp:TextBox>
            </div>
            <div id="dvOther" runat="server" style="display: none">
                <asp:TextBox ID="txtCell2" MaxLength="11" runat="server" onkeydown="return isNumberKey(this);"
                     class="mobnumber"></asp:TextBox>
            </div>
        </td>
          </tr>
          <tr>
            <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"
                        
                        MaxLength="20"></asp:TextBox>
                </td>
          </tr>
          <tr>
            <td>
                    <asp:TextBox ID="txtReEnterPassPassword" runat="server" TextMode="Password" placeholder="Confirm Password"
                        MaxLength="20"></asp:TextBox>
                </td>
          </tr>
          <tr>
            <td>
            <br />
            <div>
            <div style="background:white">
                <div id="progressbar" style="display: none">
                    <div id="progress">
                    </div>
                </div>
                <div id="complexity" style="display: none">
                </div>
                
                <asp:Label ID="lblError" runat="server" style="color:red;"></asp:Label>
            </div>
        </div>
        </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ImageButton1" runat="server" text="Apply Now" OnClientClick="return validateForm();"
                    ValidationGroup="valida"
                    OnClick="btnSignUp_Click" />
            </td>
          </tr>
        </table>
    	</div>
    </article>
    </form>
</body>
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
    //function parenturl() {
    //    $('#txtParentUrl').val(document.referrer);
    //}

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

    function validateForm() {
        //debugger;
        var isName, isEmail, isPass, isConfirmPass, isPassMatch, isPhone = false;

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
        }
        if (isName && isEmail && isPass && isConfirmPass && isPassMatch && isPhone) {
            $(".errormsg").html("");
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