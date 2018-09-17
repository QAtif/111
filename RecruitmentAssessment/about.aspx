<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>B O L</title>
	<link rel="shortcut icon" type="image/x-icon" href="/assets/images/favicon.ico"/>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">    
    <meta content="MSHTML 6.00.2800.1106" name="GENERATOR">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <!--#include virtual="/assets/includes/scripts.asp"-->
 
        <script type="text/javascript">
            $(document).ready(function () {
                $("td:empty").html("&nbsp;");
            });
        </script>
    </head>
    <script src="/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
    <script>
        var milisec = 0
        var seconds = 60
        function display() {
            if (milisec <= 0) {
                milisec = 9
                seconds -= 1
            }

            if (seconds <= -1) {
                milisec = 0
                seconds += 1
                if (confirm('Do you want to start your test?') == true) {
                    window.document.getElementById("btnRow").style.display = "block"
                    seconds = 60
                    var testid = document.getElementById('hdTestID').value;
                    window.location.href = "CandidateWelcome.aspx?tid=" + testid;
                }
                else {
                    window.document.getElementById("btnRow").style.display = "block"
                    seconds = 60
                }

            }
            else
                milisec -= 1

            window.document.getElementById("d2").value = seconds + "." + milisec
            setTimeout("display()", 100)
        } 

    </script>
    
</style>
</head>
<body onLoad="display() ;">
    <form id="form2" runat="server">
    
    <div class="maincontainer">
        <table>
            <tr>
                <td height="5" align="left" >
                    <asp:HiddenField runat="server" ID="hdTestID" />
					 <img src="/assets/Images/BOL-Logo.jpg" alt="BOL" width="77" height="76" hspace="5">
                    <img src="/assets/Images/hr-hd.gif" alt="We Value Quality Human Resources" width="168" height="31" hspace="5" style="margin-bottom: 23px;">
                </td>
            </tr>
            <tr>
                <td height="5" align="left" >
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="5" align="left" >
                    <span style="line-height: 18px; font-family: Verdana, Arial, Helvetica, sans-serif;
                        font-size: 14px">If you're the one with a passion for learning and exploring;
                        if you want to win and have a desire to excel, <span class="style1">we value you</span>.</span>
                </td>
            </tr>
            <tr style="display:none">
                <td height="5" align="left" >
                    <span style="line-height: 18px; font-family: Verdana, Arial, Helvetica, sans-serif;
                        font-size: 14px">Learn more about the Enviable Lifestyle BOL offers all Bolwala.
                        through our interactive video below:</span>
                </td>
            </tr>
            <tr>
                <td height="5" align="left" >
                    &nbsp;
                </td>
            </tr>
            <tr style="display:none">
                <td align="left" 
                    padding-left: 12px">
                    <br>
                    <iframe src="" allowtransparency="true"
                        height="600" width="800" scrolling="no" frameborder="0"></iframe>
                    
                    <br>
                </td>
            </tr>
            <tr>
                <td>
                <br />
                  <span style="line-height: 18px; font-family: Verdana, Arial, Helvetica, sans-serif;
                        font-size: 14px">We Recommend you to update your Educational, Professional and Personal Details before you proceed your test. 
                <br /><a href="http://careers.bolnetwork.com/signin.aspx" target="_blank">Click Here</a> to update your details.</span> 
                <br />
                </td>
                </tr>
            <tr>
                <td align="left" 
                    padding-left: 12px">
                    <br>
                    <asp:Button ID="btnSubmit" runat="server" Text="Continue to Test" 
                CssClass="btn-ora nl" onclick="btnSubmit_Click"  />
                    
                    <br>
                </td>
            </tr>
        </table>
    </div>
   
   </form>
</body>
</html>