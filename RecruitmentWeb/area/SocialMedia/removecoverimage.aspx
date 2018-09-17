<%@ Page Language="C#" AutoEventWireup="true" CodeFile="removecoverimage.aspx.cs"
    Inherits="StudentArea_removecoverimage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Remove Cover Image</title>
    <link rel="stylesheet" type="text/css" href="/assets2/css/popups.css" />
    <script type="text/javascript" src="/assets2/js/jquery.js"></script>
    <script type="text/javascript" src="/assets2/js/function.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.close').click(function () {
                $('.close').hide();
            });
        });
    </script>
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.href = "..~/Area.aspx";
        }

       
    </script>
</head>
<body>
    <form runat="server" id="Form1">
    <div class="career-service fullwidth" style="height: 170px;">
        <h3 class="popup-hd-top" style="width: 91.3%;">
            REMOVE COVER PICTURE</h3>
        <div class="clear">
        </div>
        <div class="profile-remove-content" style="width: 96.5%;">
            <img runat="server" id="imgCoverImage" width="30" height="30" />
            <span class="profile-remove-text">Are you sure you want to remove this picture?</span>
            <div class="clear">
            </div>
        </div>
        <div class="profile-remove-control" style="width: 96.5%;">
            <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn-cancel" OnClick="lnkCancel_Click"
                OnClientClick="parent.cover(); parent.closeBPopup();"><span>Cancel</span></asp:LinkButton>
            <asp:LinkButton ID="lnkRemoveCover" runat="server" CssClass="btn-ok" OnClick="lnkRemoveCover_Click"
                OnClientClick="parent.cover(); parent.closeBPopup();"><span>Okay</span></asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
