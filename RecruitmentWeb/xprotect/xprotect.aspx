<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xprotect.aspx.cs" Inherits="FBConnectPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Download Axact Protect - </title>


<script type="text/javascript">

    function CloseWindow() {
        if (parent != null) {

            parent.window.location.href = "http://www.axact.com/products/protect/thanks.asp";
        }
        if (window.opener) {
            window.opener.location.href = "http://www.axact.com/products/protect/thanks.asp";
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">  

    </form>
</body>
</html>
