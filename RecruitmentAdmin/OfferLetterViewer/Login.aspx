<%@ Page Language="C#" AutoEventWireup="true" CodeFIle="Login.aspx.cs" Inherits="XRecruitmentAdmin.OfferLetterViewer.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BOL</title>
       <!--#include virtual="/assets/includes/scripts.asp"--> 
</head>
<body>
    <form name="form1" id="form1" runat="server">
    <div class="topbarbg">
        <div class="topbar">
            <div class="logo">
               
            </div>
            <div class="topnavigation">
            </div>
        </div>
    </div>
    <div class="maincontainer">
        <br />
        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td valign="top" colspan="2">
                    <p>
                        &nbsp;</p>
                    <table cellspacing="0" cellpadding="0" width="739" align="center" border="0">
                        <tr>
                            <td>
                                <img alt="" height="17" src="/assets/images/logineboxtop.gif" width="739">
                            </td>
                        </tr>
                        <tr>
                            <td background="/assets/images/loginboxbg.gif">
                                <table cellspacing="0" cellpadding="6" width="100%" border="0">
                                    <tr>
                                        <td valign="middle" width="49%" rowspan="5">
                                            <div align="center">
                                                <h2>
                                                    <img alt="" height="224" src="/assets/images/BOlOffer.png" width="340"></h2>
                                            </div>
                                        </td>
                                        <td width="4%">
                                            &nbsp;
                                        </td>
                                        <td width="47%">
                                            <font face="Verdana, Arial, Helvetica, sans-serif" color="#00868d" size="5"><strong>
                                                <font size="4">Please Sign In to Continue</font></strong></font><font face="Verdana, Arial, Helvetica, sans-serif"
                                                    color="#00868d" size="4">&nbsp;</font><font face="Verdana, Arial, Helvetica, sans-serif"
                                                        color="#00868d">
                                                        <br>
                                                    </font>
                                            <br>
                                            <font color="red" size="2" face="verdana, arial, helvetica, sans-serif"><b>
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                            </b></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="padding-left:30px">
                                            <asp:ValidationSummary ID="vsValidators" DisplayMode=BulletList
                                                EnableClientScript="true" runat="server" Style="color: #F00;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <br />
                                            &nbsp;
                                        </td>
                                        <td>
                                            <font face="Verdana, Arial, Helvetica, sans-serif" size="2"><strong>Email or Mobile
                                                :</strong></font><br>
                                            <asp:TextBox ID="txtCell" runat="server" MaxLength="100" CssClass="phone" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                ControlToValidate="txtCell" ErrorMessage="Mobile Number / Email Address is Required"
                                                Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Mobile Number / Email Address is Required' />"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <br />
                                            &nbsp;
                                        </td>
                                        <td>
                                            <font face="Verdana, Arial, Helvetica, sans-serif" size="2"><strong>Password</strong></font><br>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="passfield"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                                ErrorMessage="Password is Required" Font-Bold="True" ForeColor="Red" ControlToValidate="txtPassword"
                                                Text="<img src='/assets/Images/Exclamation.gif' title='Password is Required' />"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                                <br />
                                                <strong><font face="Verdana, Arial, Helvetica, sans-serif" color="#00868d" size="1">(You can also use your Reference # / Applicant ID as password) </font></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <br />
                                            &nbsp;
                                        </td>
                                        <td>
                                            <div align="right">
                                                <asp:ImageButton ID="btnSignIn" runat="server" text="Sign In" src="/assets/images/butconti.gif"
                                                    OnClick="btnSignIn_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img alt="" height="13" src="/assets/images/logineboxbottom.gif" width="738">
                            </td>
                        </tr>
                    </table>
                    <p>
                        <br>
                        <br>
                    </p>
                    <table cellspacing="0" cellpadding="0" width="780" border="0">
                        <tr>
                            <td width="1240">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
   
    </form>
</body>
</html>
