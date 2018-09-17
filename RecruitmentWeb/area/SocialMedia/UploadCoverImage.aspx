<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadCoverImage.aspx.cs"
    Inherits="StudentArea_UploadProfileImage2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        function SetAreaImages(CoverImagePath) {

            if (CoverImagePath.length > 0) {
                debugger;
                window.opener.document.getElementById("imgCoverImage").src = "";
                window.opener.document.getElementById("imgCoverImage").src = CoverImagePath;
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
