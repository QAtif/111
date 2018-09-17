<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadProfileImage.aspx.cs" Inherits="StudentArea_UploadProfileImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        function SetAreaImages(ProfileImagePath) {
                  
            if (ProfileImagePath.length > 0) {
                window.opener.document.getElementById("imgProfileImage").src = "";
                window.opener.document.getElementById("imgProfileImage").src = ProfileImagePath;
            }

        }
    </script>

</head>
<body>
    <form id="Form1" runat="server">
    <div>
        <asp:Label ID="lblImage" runat="server"></asp:Label>
        <asp:Image ID="imgUpload" runat="server" />
    </div>
    </form>
</body>
</html>
