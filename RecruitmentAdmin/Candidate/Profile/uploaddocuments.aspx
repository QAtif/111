<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Profile/ProfileMaster.master" AutoEventWireup="true" CodeFile="uploaddocuments.aspx.cs" Inherits="Candidate_Profile_uploaddocuments" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <link href="/assets/css/StylesA.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/telerik-Styles.css" rel="stylesheet" type="text/css" />
   
    <script type="text/javascript" src="/assets/js/scripts.js"></script>
    <script type="text/javascript">
        function onFileUploaded(sender, args) {
            var spanTag = document.createElement("span");
            spanTag.className = "ruFileProgressWrap";
            var spanTagInner = document.createElement("span");
            spanTagInner.className = "ruFileProgress ruProgressStarted";
            spanTag.appendChild(spanTagInner);

            var $span = window.$telerik.$(".ruUploadProgress", args.get_row());
            var text = $span.text();
            // if (text.length > 15) {
            //var newString = text.toLowerCase().substring(0, 15) + '...';
            var newString = 'Selected File Uploading';
            $span.text(newString);
            $span.append(spanTag);
            //}
            // else {
            //    var dots;
            //   for (var i = 0; i < (15 - (text.length)); i++) {
            //      dots = dots + '.';
            // }
            // var newString ='File Selected';
            $span.text(newString);
            $span.append(spanTag);
        }


        function UploadFiles() {

          
            $("#ctl00_ContentContainer_btnUpload").click();
        }

        function fileSelected(sender, args) {
            var spanTag = document.createElement("span");
            spanTag.className = "ruFileProgressWrap";
            var spanTagInner = document.createElement("span");
            spanTagInner.className = "ruFileProgress ruProgressStarted";
            spanTag.appendChild(spanTagInner);

            var $span = $(".ruUploadProgress", args.get_row());
            var name = $span.text();
            //            if (name.length > 15) {
            //                var newString = name.toLowerCase().substring(0, 15) + '...';
            var newString = 'Selected File Uploading';
            $span.text(newString);
            $span.append(spanTag);
            //            }
            //            else {
            //                var dots;
            //                for (var i = 0; i < (15 - (text.length)); i++) {
            //                    dots = dots + '.';
            //                }
            //                var newString = text.toLowerCase() + dots;
            $span.text(newString);
            $span.append(spanTag);
        }
           
        
    </script>
    <style type="text/css">
        .ruBrowse
        {
            background-position: 0 -46px !important;
            width: 122px !important;
        }
    </style>
    <style type="text/css">
        .ruBrowse, .ruFileInput
        {
            cursor: pointer !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="xboxRight">
                <img src="/Area/assets/img/banners/uploaddoc.jpg" alt="">
                <div class="xBoxInner">
                    <h6>
                        <strong>Please provide documents of your work and credentials</strong></h6>
                    <div class="row-fluid">
                        <div class="span5">
                        </div>
                        <div class="span7" style="color: #cccccc;">
                            (Supported file formats are: jpg, png, pdf ,jpeg)
                        </div>
                    </div>
                    <asp:Repeater ID="rptDocumentType" runat="server" OnItemDataBound="rptDocumentType_OnItemDataBound">
                        <ItemTemplate>
                            <tr id="trDocTypeName" runat="server">
                                <td>
                                    <asp:HiddenField ID="hdnProgramCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Program_Code")%>' />
                                    <asp:HiddenField ID="hdnDocumentTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DocType_Code")%>' />
                                    <h3>
                                        <span class="icon"></span>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <h4>
                                                    <span>
                                                        <asp:Label ID="lblDocTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocumentTypeName")%>'></asp:Label></span></h4>
                                            </div>
                                        </div>
                                        <a class="btn-add"></a>
                                    </h3>
                                </td>
                            </tr>
                            <div>
                                <div class="content">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="nopad">
                                                <asp:Repeater ID="rptCandidateDocument" runat="server" OnItemDataBound="rptCandidateDocument_OnItemDataBound">
                                                    <HeaderTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr style="display: none;">
                                                            <td>
                                                                <asp:HiddenField ID="hdnReferenceCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ReferencePK")%>' />
                                                                <asp:HiddenField ID="hdnProgram" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ProgramCode")%>' />
                                                                <asp:HiddenField ID="hdnDocument_Type" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DocumentType")%>' />
                                                                <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RefernecInstitute")%>'
                                                                    Style="font-size: large;"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Repeater ID="rptUploadDocuments" runat="server" OnItemCommand="rptUploadDocuments_OnItemCommand"
                                                                    OnItemDataBound="rptUploadDocuments_OnItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr id="trDocName" runat="server">
                                                                            <td colspan="2" style="width: 60%">
                                                                                <asp:Label ID="lblDocumentTypeCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Code").ToString()%>'
                                                                                    Visible="false" Style="display: none"></asp:Label>
                                                                                <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                                                    Visible="false" Font-Bold="true" Style="display: none"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td class="nopad" colspan="2">
                                                                                            <div class="row-fluid">
                                                                                                <div style="width: 67%; float: left">
                                                                                                    <asp:Image ID="Imgbtn" runat="server" ImageUrl="" CssClass="fixiconimg" Width="19px"
                                                                                                        Height="19px" />
                                                                                                    <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                                                                                </div>
                                                                                                <div class="span3">
                                                                                                    <asp:RegularExpressionValidator ID="revCD" runat="server" ErrorMessage="" ValidationExpression="^.+(.pdf|.PDF|.jpeg|.JPEG|.png|.PNG|.jpg|.JPG|.doc|.DOC|.docx|.DOCX|.gif|.GIF)$"
                                                                                                        Text="" Font-Bold="True" ForeColor="Red" ControlToValidate="fuCandidateDocument"
                                                                                                        ValidationGroup="upload" Display="None" SetFocusOnError="true"> </asp:RegularExpressionValidator>
                                                                                                    <div id="teln" runat="server">
                                                                                                        <span id="sFileName" runat="server" class="fileame">
                                                                                                            <asp:LinkButton ID="lblFileName" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Document_Path")%>'
                                                                                                                CommandName="Download" runat="server"></asp:LinkButton>
                                                                                                            <a id="lnkdeleteFile" data-original-title="" runat="server" href="javascript:;">
                                                                                                            </a></span><a href="javascript:;" id="aFU" runat="server" class="attackfile">
                                                                                                                <asp:Label runat="server" ID="lblAttach" Text=""></asp:Label></a>
                                                                                                        <asp:FileUpload ID="fuCandidateDocument" runat="server" Style="visibility: hidden;
                                                                                                            width: 1px; height: 1px;" ValidationGroup="upload" />
                                                                                                    </div>
                                                                                                    <div id="tel" runat="server">
                                                                                                        <telerik:RadAsyncUpload HttpHandlerUrl="~/Handlers/CustomHandler.ashx" runat="server"
                                                                                                            IsMultiselect="False" InitialFileInputsCount="1" ID="AsyncUpload1" HideFileInput="true" 
                                                                                                            MultipleFileSelection="Disabled" AllowedFileExtensions=".jpeg,.jpg,.png,.gif,.bmp,.psd,.doc,.docx,.xls,.xlsx,.zip,.rar,.ppt,.pptx,.pdf"
                                                                                                            MaxFileInputsCount="1" OnClientFileSelected="fileSelected" OnClientFilesUploaded="UploadFiles"
                                                                                                            OnClientFileUploaded="onFileUploaded" OnClientFileUploading="onFileUploaded">
                                                                                                            <Localization Select="Attach File"/>                                                                                                            
                                                                                                        </telerik:RadAsyncUpload>
                                                                                                    </div>
                                                                                                    <asp:HiddenField ID="ReferenceCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Reference_Code")%>' />
                                                                                                    <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Document_Code")%>' />
                                                                                                </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="xboxFooter">
                    <div class="row-fluid">
                        <div class="span8">
                            <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </div>
                        <div class="span4">
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="xboxRight">
                <div class="xBoxInner">
                    <div class="row-fluid">
                        <div class="span12">
                         <asp:Button ID="btn_saveAdd" runat="server" OnClick="btnSaveAdd_Click" class="btn btn-small
    pull-right" Text="Upload"  />
                            <asp:Button ID="btnUpload" runat="server" OnClick="btnSaveAdd_Click" class="btn btn-small
    pull-right" Text="Upload" />
                            <asp:Button ID="btnSave" class="xBook-button-normal button pull-right" runat="server"
                                OnClick="btnSave_Click" Text="Save &amp; Continue">
                            </asp:Button>
                            <a href="../profile/referral.aspx" class="xBook-button-back fa13 pull-right" style="text-decoration: none;display: none;
                                color: rgb(242, 246, 248);">Back</a> <a href="../profile/referral.aspx" runat="server"
                                    id="btnSkip" class="xBook-button-back fa13 pull-right" style="text-decoration: none;display: none;
                                    color: rgb(242, 246, 248);" onclick="btnSaveAdd_Click">Skip</a>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function test(radUpload, eventArgs) {
            //  alert(eventArgs.ClientID);
            var input = eventArgs.get_fileInputField();
            // alert(input.value);


        }

        function callme(oFile, objlbl, objsFileName, lbl) {
            var filename = oFile.value;
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }

            objlbl.innerHTML = 'File Selected';
            if (objlbl.innerHTML.length > 0) {
                objsFileName.className = objsFileName.className + " filename";
                lbl.innerHTML = "";

            }
            else {
                objsFileName.className = "";
            }

            return false;
        }

        function DoHideDisplay(img, btn, fuCandidateDocument, rfv) {
            $("#" + img.toString()).hide(500);
            $("#" + btn.toString()).hide(500);
            $("#" + fuCandidateDocument.toString()).show(500);
            ValidatorEnable(document.getElementById(rfv.toString()), true);
        }

        function clearFileUpload(obj, objn) {

            // document.getElementById(objn).style.display = 'none';
            //   document.getElementById(obj).style.display = '';

            $('#' + objn).hide();
            $('#' + obj).removeClass('hidden');
            $('#' + obj).show();




        }

        function ValidateDate() {

            var isPass;
            isPass = Page_ClientValidate('upload');

            if (isPass) {
                $(".errormsg").text("");
                return true;
            }
            else {
                $(".errormsg").text("Please Select the Correct Format (jpg,jpeg,gif,pdf,png,doc,docx)");
                return false;
            }

        }
    </script>
</asp:Content>
