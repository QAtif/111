<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

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


</head>
<body>
    <div id="divmain" runat="server">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="spm" runat="server">
        </asp:ScriptManager>
        <div class="modal-body">
            <h2>
                Change Password</h2>
            <p>
                This password is used to log into your account area as well as acts as a key in
                case you forget your master password of your security applications.
            </p>
            <div align="center">
                <div align="center">
                    <table width="70%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                Current Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="jqtranformdone codecurrentpassword"
                                    MaxLength="20">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                New Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="jqtranformdone codenewpassword"
                                    MaxLength="20" onkeyup='javascript:ValidatePasswordStrength();' onkeypress="javascript:ValidatePasswordStrength();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtRetypeNewPassword" runat="server" MaxLength="20" TextMode="Password"
                                    CssClass="jqtranformdone codeconfirmpassword"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <div class="row-fluid">
                                    <div id="progressbar" style="display: none" class="progress progress-success span6">
                                        <div id="progress" class="bar">
                                        </div>
                                    </div>
                                    <div id="complexity" style="display: none" class="span6">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                &nbsp;<asp:Label ID="lblError" runat="server" CssClass="errormsg red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"
                        CssClass="xBook-button-normal button" ValidationGroup="changepassword" data-toggle="modal"
                        data-dismiss="modal" OnClientClick="return validateChangePassword();" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:return RefreshParent();"
                        class="xBook-button-back" />
                </div>
            </div>
        </form>
        <br />
    </div>
</body>
</html>

<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        $(".codenewpassword").change(function() {

            if ($(this).val().indexOf(' ') >= 0) {
                $(this).val($(this).val().replace(/ /g, ''));
                alert('Spaces are not allowed');
            }
        });

        $('.codenewpassword').keypress(function(event) {
            if (event.which == 32) {
                alert('Spaces are not allowed');
                return false;
            }
        });
    });

    function RefreshParent() {
        $('#txtCurrentPassword').val('');
        $('#txtNewPassword').val('');
        $('#txtRetypeNewPassword').val('');

        $('#progressbar').attr("style", "display:none");
        $('#complexity').attr("style", "display:none");

        $('.codecurrentpassword').removeClass('error');
        $('.codenewpassword').removeClass('error');
        $('.codeconfirmpassword').removeClass('error');
        $(".errormsg").text("");

        parent.$("#paswdCancel").click();
        return false;
        //        //debugger;
        //        var referrer = document.referrer;

        //        //        if (referrer.indexOf("area.aspx") != -1)
        //        //            window.parent.location.href = "area~/Area.aspx";
        //        //        else if (referrer.indexOf("changepassword.aspx") != -1)
        //        parent.location.reload(true);
        //        //        else
        //        //            window.parent.location.href = referrer;
    }

    function CheckPasswordStrength(isvalid, complex) {
        //debugger;
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
    }


    function ValidatePasswordStrength() {


        var score = 1; var isOK = false;
        var complexity = 0; var valid = false;

        if ($('.codenewpassword').val().trim().length == 0) {
            $('#progressbar').attr("style", "display:none");
            $('#complexity').attr("style", "display:none");
            return;
        }


        if ($('.codenewpassword').val().trim().length != 0) {
            $('#progressbar').attr("style", "display:''");
            $('#complexity').attr("style", "display:''");


            if ($('.codenewpassword').val().trim().length == 0) {
                CheckPasswordStrength(false, 0);
                return;
            }

            if ($('.codenewpassword').val().trim().length <= 6) {
                CheckPasswordStrength(false, 5);
                return;
            }

            if ($('.codenewpassword').val().trim().length >= 10) {
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
        else if ($('.codenewpassword').val().trim().length == 0) {
            CheckPasswordStrength(false, 0);
            return;
        }
    }




    function validateChangePassword() {
        // debugger;
        var isName, isPass, isConfirmPass, isPassMatch = false;

        if ($('.codecurrentpassword').val().trim() == "") {
            $('.codecurrentpassword').addClass('error');
        } else {
            $('.codecurrentpassword').removeClass('error');
            isName = true;
        }

        if ($('.codenewpassword').val().trim() == "") {
            $('.codenewpassword').addClass('error');
        } else {
            $('.codenewpassword').removeClass('error');
            isPass = true;
        }
        if ($('.codeconfirmpassword').val().trim() == "") {
            $('.codeconfirmpassword').addClass('error');
        } else {
            isConfirmPass = true;

            if ($('.codenewpassword').val().trim() == $('.codeconfirmpassword').val().trim()) {
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
            $(".errormsg").show();
            if (isPassMatch) {
                if ($('.codecurrentpassword').val().trim() != $('.codeconfirmpassword').val().trim())
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
            $(".errormsg").show();
            $(".errormsg").text("Please provide complete & valid information");
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


