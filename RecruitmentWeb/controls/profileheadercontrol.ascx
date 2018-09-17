<%@ control language="C#" autoeventwireup="true" inherits="controls_profileheadercontrol, App_Web_profileheadercontrol.ascx.cc671b29" %>
<div class="row-fluid">
    <div class="span3">
        <a href="/" id="logo">
            <%=ConfigurationManager.AppSettings["ClientName"].ToString() %>
            Recruitment</a>
    </div>
    <div class="span9">
        <div id="xprofile-menu">
            <div>
                <a href="javascript:void(0);">
                    <asp:Image ID="imgProfileImageSmall" ImageUrl="../Area/SocialMedia/UserImagePath/profile.jpg"
                        runat="server" /><%--<img id="imgProfileImageSmall" runat="server" alt="ProfileImageSmall" />--%></a>
                <div class="XProMenu xbox">
                    <ul>
                        <li class="active"><a href="../Area/Area.aspx">Home</a></li>
                        <li><a href="../Area/alert.aspx">Alerts</a></li>
                        <li><a href="javascript:;">Tips and Guides</a></li>
                        <%--<li><a href="javascript:;">Career Services</a></li>--%>
                        <%--<li class="Xsep"><a href="javascript:;">&nbsp;</a></li>--%>
                        <%--<li><a href="#myModal_ChangePassword" data-toggle="modal" role="button">Change Password</a></li>--%>
                        <li><a role="button" data-toggle="modal" href="#myModal_ChangePassword">Change Password</a></li>
                        <li style="display: none;"><a href="javascript:;" onclick="$(this).children('span').toggle();$('.notification').slideToggle();">
                            <span>Show Help</span><span style="display: none;">Hide Help</span></a></li>
                        <%--<li class="Xsep"><a href="javascript:;">&nbsp;</a></li>--%>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton1" Text="Logout" OnClick="logout_Click"></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <h3>
                <a href="/Area/Area.aspx">
                    <asp:Label ID="lblProfileFullName" runat="server"></asp:Label></a>
            </h3>
        </div>
        <ul id="xcta-menu">
            <li><a href="javascript:void(0);">Call us on <span>
                <%=ConfigurationManager.AppSettings["ClientPhone"].ToString()%></span></a></li>
            <%--<li><a href="javascript:void(0);">Chat</a></li>--%>
            <%--<li><a href="javascript:void(0);">Email</a></li>   --%>
        </ul>
    </div>
</div>
<!-- Change Password  -->
<div id="myModal_ChangePassword" class="modal hide theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="javascript:ClearPassword();">
            ×</button>
        <h3>
            Account Settings</h3>
    </div>
    <div>
        <div align="center">
            <iframe id="iframeChangePwd" src="../changepassword.aspx" width="100%" height="332px"
                frameborder="0" scrolling="no"></iframe>
                
                      <button id="paswdCancel" data-dismiss="modal" data-toggle="modal" class="xBook-button-back"
                data-original-title="" title="" style="display: none">
                Cancel</button>
        </div>
    </div>
</div>
<!-- end Change Password  -->
<style type="text/css">
    #uploadcover
    {
        display: none !important;
    }
</style>
<%--<script type="text/javascript">
    $(document).ready(function () {
        $('#lnkUpload2').click(function () {
            $('#uploadcover').trigger('click');
        });
    });
</script>--%>
<style type="text/css">
    #uploadprofile
    {
        display: none !important;
    }
</style>
<%--<script type="text/javascript">
    $(document).ready(function () {
        $('#lnkUpload').click(function () {
            $('#uploadprofile').trigger('click');
        });
    });
</script>--%>
<script type="text/javascript">

    /*Demo Work Start*/

    function ClearPassword() {

        window.frames['iframeChangePwd'].document.getElementById('txtCurrentPassword').value = '';
        window.frames['iframeChangePwd'].document.getElementById('txtNewPassword').value = '';
        window.frames['iframeChangePwd'].document.getElementById('txtRetypeNewPassword').value = '';

        window.frames['iframeChangePwd'].document.getElementById('txtCurrentPassword').className = 'jqtranformdone codecurrentpassword';
        window.frames['iframeChangePwd'].document.getElementById('txtNewPassword').className = 'jqtranformdone codenewpassword';
        window.frames['iframeChangePwd'].document.getElementById('txtRetypeNewPassword').className = 'jqtranformdone codeconfirmpassword';

        window.frames['iframeChangePwd'].document.getElementById('progressbar').style.display = 'none';
        window.frames['iframeChangePwd'].document.getElementById('complexity').style.display = 'none';

        window.frames['iframeChangePwd'].document.getElementById('lblError').style.display = 'none';

    }


    $(document).ready(function() {
        if (getCookie("Demo") != null && getCookie("Demo") == '1') {
            //alert('asim');
            $('.notification').hide();
        }
        else {
            //alert('baig');
        }
    });

    function checkdemostatus() {

        if (getCookie("Demo") == null)
            createCookie("Demo", 1, 30);
    }

    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    function getCookie(NameOfCookie) {
        if (document.cookie.length > 0) {
            begin = document.cookie.indexOf(NameOfCookie + "=");
            if (begin != -1) // Note: != means "is not equal to"
            {
                begin += NameOfCookie.length + 1;
                end = document.cookie.indexOf(";", begin);
                if (end == -1) end = document.cookie.length;
                return unescape(document.cookie.substring(begin, end));
            }
        }
        return null;
    }

    $('.xclose').click(function(event) {
        event.stopPropagation();
        $(this).closest('div').slideUp();
        checkdemostatus();
    });


    /*Demo Work End*/

    function RefreshParent() {
        window.parent.location.reload();
    }

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

        if (complex == 0) {
            //$('#complexity').html('0' + '% Weak');
            $('#complexity').html('Weak');
        }

        if (complex * 4 >= 100) {
            //$('#complexity').html('100' + '% Strong');
            $('#complexity').html('Strong');
        }

        if (complex * 4 <= 34) {

            //$('#complexity').html(Math.round(complex * 4) + '% Weak');
            $('#complexity').html('Weak');
        }

        else if (complex * 4 <= 68) {
            //$('#complexity').html(Math.round(complex * 4) + '% Medium');
            $('#complexity').html('Medium');
            //  $('#complexity').html(50 + '% Medium');
        }

        else if (complex * 4 <= 90) {
            // $('#complexity').html(80 + '% Strong');
            //$('#complexity').html(Math.round(complex * 4) + '% Strong');
            $('#complexity').html('Strong');
        }

        else {
            if (Math.round(complex * 4) >= 100) {
                //$('#complexity').html('100' + '% Strong');
                $('#complexity').html('Strong');
            }
            else {
                // change string Strong to show very Strong :)
                //$('#complexity').html(Math.round(complex * 4) + '%  Strong');
                $('#complexity').html('Strong');
            }
        }
    }


    function ValidatePasswordStrength() {
        var score = 1; var isOK = false;
        var complexity = 0; var valid = false;

        $('#progressbar').attr("style", "display:''");
        $('#complexity').attr("style", "display:''");


        if ($('.codenewpassword').val().length == 0) {
            CheckPasswordStrength(false, 0);
            return;
        }

        if ($('.codenewpassword').val().length <= 6) {
            CheckPasswordStrength(false, 5);
            return;
        }
        //            if ($('.email').val().indexOf($('.codenewpassword').val()) >= 0) {
        //                CheckPasswordStrength(false, 5);
        //                return;
        //            }

        if ($('.codenewpassword').val().length >= 10) {
            score++;
            complexity = complexity + 6.25;
        }
        var numberRegex = new RegExp("[0-9]", "g");
        if (numberRegex.test($('.codenewpassword').val())) {
            score++;
            complexity = complexity + 6.25;
        }

        var alphaRegex = new RegExp("[a-zA-Z]+", "g");
        if (alphaRegex.test($('.codenewpassword').val())) {
            score++;
            complexity = complexity + 6.25;
        }

        var charRegex = /.[!,@,#,$,%,^,&,*,?,_,~,.,-,£,(,)]/;
        if (charRegex.test($('.codenewpassword').val())) {
            score++;
            complexity = complexity + 6.25;
        }

        CheckPasswordStrength(valid, complexity);
    }




    function validateChangePassword() {
        // debugger;
        var isName, isPass, isConfirmPass, isPassMatch = false;

        if ($('.codecurrentpassword').val() == "") {
            $('.codecurrentpassword').addClass('error');
        } else {
            $('.codecurrentpassword').removeClass('error');
            isName = true;
        }

        if ($('.codenewpassword').val() == "") {
            $('.codenewpassword').addClass('error');
        } else {
            $('.codenewpassword').removeClass('error');
            isPass = true;
        }
        if ($('.codeconfirmpassword').val() == "") {
            $('.codeconfirmpassword').addClass('error');
        } else {
            isConfirmPass = true;

            if ($('.codenewpassword').val() == $('.codeconfirmpassword').val()) {
                $('.codeconfirmpassword').removeClass('error');
                $('.codenewpassword').removeClass('error');
                isPassMatch = true;
            }
            else {
                $('.codenewpassword').addClass('error');
                $('.codeconfirmpassword').addClass('error');
                isPassMatch = false;
            }
        }

        if (isName && isPass && isConfirmPass) {
            if (isPassMatch) {
                if ($('.codecurrentpassword').val() != $('.codeconfirmpassword').val())
                    $(".errormsg").text("");
                else {
                    $(".errormsg").text("Old and New Passwords are same");
                    return false;
                }
            }
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

