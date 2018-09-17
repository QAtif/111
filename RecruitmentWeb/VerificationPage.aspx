<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerificationPage.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="ver" TagName="verification" Src="~/controls/verificationcontrol.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--#include virtual="/Area/includes/header-scripts.html"-->
</head>
<body>
    <form id="form1" runat="server">
    <ver:verification ID="verification" runat="server" />
    </form>
    <!-- Start Footer -->
    <div id="footer" class="row-fluid">
        
    </div>
    <!-- End Footer -->
    <!--#include virtual="/Area/includes/footer-scripts.html"-->
</body>
</html>
