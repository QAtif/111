<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/ProfileMaster.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="portfolio.aspx.cs"
    Inherits="profile_portfolio" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
        function ShowHideportfolio(obj) {
            if (document.getElementById("rblHasPortfolio_0").checked == true) {
                $('#profePort').removeClass('hidden');
                $('#ContentContainer_footerport').removeClass('hidden');
            }
            else {
                $('#profePort').addClass('hidden');
                $('#ContentContainer_footerport').addClass('hidden');
            }
        }

        function OpenDiv(obj) {
            //alert('dsfsdf');
            $('#AttachFiles').removeClass('hidden');
            $('#UploadFiles').addClass('hidden');
        }

     
           
    </script>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
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
    </style>
    <script type="text/javascript" src="/Area/assets/js/AddMoreBrowse.js"></script>
    <link href="/Area/assets/css/telerik-Styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Area/assets/js/telerik-scripts.js"></script>
    <title>Portfolio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="xboxRight">
        <img src="/Area/assets/img/banners/portfolio.jpg" alt="" />
        <div class="xBoxInner">
            <div class="row-fluid" runat="server" id="profeportfolioCheck">
                <div class="span12">
                    <h6>
                        <strong>Please provide us details of your portfolio</strong></h6>
                    <div class="row-fluid">
                        <div class="span4">
                            Do you have a portfolio?</div>
                        <div class="span7">
                            <asp:RadioButtonList ID="rblHasPortfolio" runat="server" CssClass="radiobuttonlist"
                                RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="20" CellSpacing="10"
                                ClientIDMode="Static" onclick="javascript:return ShowHideportfolio(this.value);">
                                <asp:ListItem Enabled="true" Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Enabled="true" Selected="False" Text="No" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <%--    <div class="span12">
                    <div class="row-fluid">
                        <div class="span4">
                        </div>
                        <div class="span8" style="color: #cccccc;">
                            <span class="allowed-attachments"><span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                data-original-title="<%= String.Join( ", ", AsyncUpload1.AllowedFileExtensions )%>">
                                View Supported file formats</span> </span>
                        </div>
                    </div>
                </div>--%>
            </div>
            <div id="profePort" runat="server" clientidmode="Static">
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            <span>Portfolio</span><span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                data-original-title="Your professional portfolio which can show the best of your work. ">(?)</span>
                        </h4>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span11 offset1">
                        <h4>
                            <span>Attach Files</span></h4>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row-fluid attachedpixs" id="profePortList" runat="server" style="margin-left: 20px">
                            <asp:ListView ID="lvPortFolio" runat="server" OnItemCommand="lvPortFolio_OnItemCommand"
                                OnItemEditing="lvPortFolio_ItemEditing" OnItemDeleting="lvPortFolio_OnItemDeleting">
                                <LayoutTemplate>
                                    <ul>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </ul>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:Label ID="lblPortFolioFileCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidatePortfolioFile_Code")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblFilePath" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FILEPATH")%>'
                                            Visible="false"></asp:Label>
                                        <div class="fadeit" title='<%# DataBinder.Eval(Container.DataItem, "fullFileName").ToString()%>'>
                                        </div>
                                        <asp:LinkButton ID="lbdel" runat="server" CommandName="Delete" class="closeicon"
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidatePortfolioFile_Code")%>'
                                            CausesValidation="false" OnClientClick="javascript:return confirm('Are you sure you want to remove?');" />
                                        <asp:Image runat="server" ID="sdfsdf" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "LogoPath")%>'
                                            Width="90px" Height="90px" AlternateText="Image Not Found" BorderColor="GrayText"
                                            BorderWidth="1px" BorderStyle="Solid" />
                                        <br>
                                        <asp:LinkButton ID="lbedit" runat="server" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidatePortfolioFile_Code")%>'
                                            CausesValidation="false" Text='<%# DataBinder.Eval(Container.DataItem, "FILENAME").ToString()%>'
                                            ToolTip='<%# DataBinder.Eval(Container.DataItem, "fullFileName").ToString()%>' />
                                        <%-- <br>
                                        <%# DataBinder.Eval(Container.DataItem, "FileSize")%>--%>
                                    </li>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <p>
                                        Nothing here.</p>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </div>
                        <div class="row-fluid">
                            <div class="span11 offset1">
                                <telerik:RadAsyncUpload HttpHandlerUrl="~/Handlers/CustomHandler.ashx" runat="server"
                                    ID="AsyncUpload1" HideFileInput="true" MultipleFileSelection="Automatic" AllowedFileExtensions=".jpeg,.jpg,.png,.gif,.bmp,.psd,.doc,.docx,.xls,.xlsx,.zip,.rar,.ppt,.pptx,.pdf,.mp3"
                                    OnClientFilesUploaded="UploadFiles" OnClientFileUploaded="onFileUploaded" OnClientFileUploading="onFileUploading" OnClientValidationFailed="onValidationFail">
                                    <Localization Select="Attach Files" />
                                </telerik:RadAsyncUpload>
                                <%--<span class="allowed-attachments"><span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                    data-original-title="<%= String.Join( ", ", AsyncUpload1.AllowedFileExtensions )%>">
                                    View Supported file formats</span> </span>--%>
                                <asp:Button ID="btnUpload" runat="server" Text="Button" Style="display: none;" OnClick="btnUpload_OnClick" />
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span11 offset1" style="min-height: 1px !important">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                    DisplayAfter="0">
                                    <ProgressTemplate>
                                        <img src="/Area/assets/img/loading.gif" alt="" align="middle" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <span style="padding-left: 50px" class="allowed-attachments"><span class="xCustomTip"
                    data-placement="top" data-toggle="tooltip" data-original-title="<%= String.Join( ", ", AsyncUpload1.AllowedFileExtensions )%>">
                    View Supported file formats</span> </span>
                <div class="row-fluid">
                    <div class="span11 offset1">
                        <h4>
                            <span>Add Urls</span><span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                data-original-title="If you have your portfolio uploaded on a webiste, you can povide us with the URL.">(?)</span>
                        </h4>
                    </div>
                </div>
                <div id="xportArea" runat="server">
                    <div id="AddMoreFilesList">
                    </div>
                    <div id="BrowseFilediv1" class="row-fluid item">
                        <div class="span3 offset1">
                            <input type="text" class="jqtranformdone" name="txtTitle1" id="txtTitle1" placeholder="Title" />
                        </div>
                        <div class="span6">
                            <input class="jqtranformdone" value="" type="text" name="txtURL1" id="txtURL1" placeholder="URL" />
                        </div>
                        <div class="span1">
                            <input id="hdfFileCounter" type="hidden" value="1" runat="server" />
                            <input id="hdnFileControlIDs" runat="server" type="hidden" value="AddMoreBrowse_Control_BrowseFile1:" />
                            <div id="MoreFileAdder" runat="server">
                                <button title="" data-original-title="" class="btn btn-small " type="button" onclick="javascript: AddFileInput('AddMoreFilesList', 100);"
                                    style="padding: 6px 10px;">
                                    <img src="/Area/assets/img/plus.png" alt=""></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="xboxFooter" id="footerport" runat="server">
                <div class="row-fluid">
                    <div class="span10">
                        <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="xboxRight">
        <div class="xBoxInner">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row-fluid">
                        <div class="span12">
                            <span class=" pull-right" style="padding-left: 5px;">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                                    DisplayAfter="0">
                                    <ProgressTemplate>
                                        <img src="/Area/assets/img/loading.gif" alt="" align="middle" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </span>
                            <asp:Button ID="btnSave" class="xBook-button-normal button pull-right" Text="Save &amp; Continue"
                                runat="server" OnClick="btnSave_Click" />
                            <a href="../profile/skillset.aspx" onclick="return confirm('Are you sure you want to go back?');"
                                class="xBook-button-back fa13 pull-right" style="text-decoration: none; color: rgb(242, 246, 248);">
                                Back</a>&nbsp;
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        function Validate() {
            alert($("#ContentContainer_rptURL_txtTitle_0"));
            if ($('#ContentContainer_profePortList').css('display') != "none") {
                (".errormsg").text("");
                return true;
            }
            else if ($("#ContentContainer_rptURL_txtTitle_0") != null) {
                $(".errormsg").text("");
                return true;
            }
            else {
                $(".errormsg").text("Atleast One Field is Required...");
                return false;
            }
        }
    </script>
</asp:Content>
