<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getfbprofilepicture.aspx.cs" Inherits="SocialMedia_getfbprofilepicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script language="javascript" type="text/javascript">
         function SetAreaImages(CoverImagePath, ProfileImagePath) {            
             if (CoverImagePath.length > 0) {                
                 window.opener.document.getElementById("profileArea_draggable").src = "";
                 window.opener.document.getElementById("profileArea_draggable").src = CoverImagePath.replace("~", "..");
                 window.opener.document.getElementById('profileArea_removeCoverPict').style.visibility = 'visible';                 
             }

             if (ProfileImagePath.length > 0) {
                 window.opener.document.getElementById("profileArea_imgProfileImage").src = "";
                 window.opener.document.getElementById("profileArea_imgProfileImage").src = ProfileImagePath.replace("~", "..");
                 window.opener.document.getElementById('profileArea_removeProfilePict').style.visibility = 'visible';
             }
         }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img id="myimage" runat="server" alt="" />
        <br />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Visible="false"></asp:Label>
        <br />
        <br />
        <a href="javascript:;" onclick="window.close();">Close window</a>
    </div>
    </form>
</body>
</html>
