<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadResume.aspx.cs" Inherits="UploadResume" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!--#include virtual="/Area/includes/header-scripts.html"-->
    <link href="/Area/assets/css/Styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Area/assets/js/telerik-scripts.js">       
    </script>
    <style type="text/css">
        body
        {
          background:  #FFF !important;
            }
        .ruFileWrap label
        {
            visibility: hidden;
            display: none;
        }
        .ruBrowse
        {
            background-position: 0 -46px !important;
            width: 122px !important;
        }
        
        .ruBrowse, .ruFileInput
        {
            cursor: pointer !important;
        }
        .xBook-button-normal
        {
            height: 25px;
            background: url(/Area/assets/img/button-normal.png) repeat-x left top;
            border: none;
            outline: none;
            margin: 3px 10px 0 0;
            padding: 0px 10px;
            line-height: 25px;
            text-align: left;
            font-size: 11px;
            color: #ffffff !important;
            display: inline-block;
            border-radius: 3px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    
    <p>
        Simply upload your resume to apply at Bol.</p>
    <div class="row-fluid">
        <div class="span4">
            <p>
                Candidate Resume</p>
        </div>
        <div class="span6 para">
            <div>
                <telerik:RadAsyncUpload HttpHandlerUrl="~/Handlers/CustomHandler.ashx" runat="server"
                    ismultiselect="False" InitialFileInputsCount="1" ID="AsyncUpload1" HideFileInput="true"
                    MultipleFileSelection="Disabled" AllowedFileExtensions=".jpeg,.jpg,.png,.gif,.bmp,.psd,.doc,.docx,.pdf"
                    MaxFileInputsCount="1" OnClientFileUploaded="onFileUploaded" OnClientFileUploading="onFileUploading"
                    OnClientValidationFailed="onValidationFail">
                    <Localization Select="Attach File" />
                </telerik:RadAsyncUpload>
            </div>
            <div class="loader"></div>
            <p>
                Files format: (doc, docx, jpg, jpeg, png, pdf)</p>
        </div>
    </div>
    <!-- End row-fluid -->
    <div class="modal-footer">
        <div class="row-fluid">
            <div class="span6" align="left">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="span6">
                <asp:LinkButton ID="lnk" runat="server" OnClick="btnSave_Click" CssClass="xBook-button-normal">Save</asp:LinkButton>
            </div>
        </div>
    </div>
    <!-- End modal-footer -->
    </form>
    <!--#include virtual="/Area/includes/footer-scripts.html"-->
</body>

</html>
