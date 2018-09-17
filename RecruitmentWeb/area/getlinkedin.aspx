<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getlinkedin.aspx.cs" Inherits="area_getLinkedIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="/Area/assets/css/xBook.css">
    <script type="text/javascript">
        function StartProcess() {
            if (document.getElementById("txtoAuth_verifier").value != "") {
                document.getElementById("myimage").style.display = "inline";
                document.getElementById("tblinkedin").style.display = "none";
                document.getElementById("Label1").style.display = "inline";
                document.getElementById("btnGetAccessToken").style.display = "none";
                document.getElementById('Label1').innerHTML = 'Importing Data from Linkedin and updating your Record...';
                return true;
            }
            else {
                document.getElementById("txtoAuth_verifier").className = document.getElementById("txtoAuth_verifier").className + " error";
                return false;
            }
        }
        function LinkedInProfileDone() {
            document.getElementById("myimage").style.display = "inline";
            document.getElementById("divFirst").style.display = "none";
            document.getElementById("divSecond").style.display = "none";
            document.getElementById("txtoAuth_verifier").style.display = "none";
            document.getElementById("lblSecurity").style.display = "none";
            document.getElementById("btnGetAccessToken").style.display = "none";
            document.getElementById("btnRedirect").style.display = "none";
            RedirecttoExperience();
        }
        function RedirecttoExperience() {
            var v1 = '<%=ConfigurationManager.AppSettings["DomainAddress"].ToString() %>'
            window.parent.location.href = v1 + "profile/experience.aspx";
        }
    </script>
    <style type="text/css">
        body
        {
            background-color: #fff !important;
            font: normal 11px 'LucidaGrande';
            cursor:pointer;
            color: #666666;
        }
    </style>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
    <link href="/Area/assets/css/bootstrap.min.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="xStyledForm jqtransformdone">
    <div align="center">
        <img id="myimage" src="/Area/assets/img/icon-loading-animated.gif" alt="Loading..."/>
        <br />
        <label id="Label1" runat="server" forecolor="Red" />
    </div>
    <table width="500px" border="0" cellspacing="0" cellpadding="0" style="display: none; border-collapse: collapse;
        border-spacing: 0; color: #666666; font: 11px 'LucidaGrande';" runat="server"
        id="tblinkedin" >
        <tr>
            <td width="300px">
                <asp:HiddenField ID="hdnSignuptypecode" runat="server" Value="1" />
                <asp:HiddenField ID="hdnRequestToken" runat="server" />
                <asp:HiddenField ID="hdnTokenSecret" runat="server" />
                <asp:HiddenField ID="hdnAuth_token" runat="server" />
                <asp:HiddenField ID="hdnAccessToken" runat="server" />
                <asp:HiddenField ID="hdnAccessTokenSecret" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="display: none;" runat="server" id="divFirst">
                    <p>
                        Please follow the following steps to import your profile from LinkedIn.
                        <br />
                        <br />
                        1.<b>
                            <asp:HyperLink ID="hypAuthToken" runat="server">Click Here</asp:HyperLink></b>&nbsp;
                        and login with your LinkedIn username and password
                        <br />
                        <br />
                        2. A security code will be provided to you by LinkedIn
                        <br />
                        <br />
                        3. Enter the security code below and click ‘Import Profile’
                        <br />
                        <br />
                    </p>
                </div>
                <div style="display: none;" runat="server" id="divSecond">
                    Your LinkedIn profile has been imported successfully; however, some additional information
                    is required from you to complete your application.
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                <asp:Label ID="lblSecurity" runat="server" Text="Security Code: "></asp:Label>&nbsp;&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="txtoAuth_verifier" runat="server" class="jqtranformdone verify" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input type="button" id="btnRedirect" runat="server" class="xBook-button-center"
                    value="Complete Profile" onclick="javascript:RedirecttoExperience();" style="display: none;" />
                <asp:Button ID="btnGetAccessToken" runat="server" Text="Import Profile" OnClientClick="javascript:return StartProcess();"
                    OnClick="btnGetAccessToken_Click" CssClass="xBook-button-center" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
</html>