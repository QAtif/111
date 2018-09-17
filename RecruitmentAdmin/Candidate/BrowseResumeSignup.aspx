<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BrowseResumeSignup.aspx.cs" Inherits="Candidate_BrowseResumeSignup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link href="/Area/assets/css/telerik-Styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Area/assets/js/telerik-scriptsResume.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManageer1" runat="server">
    </asp:ScriptManager>
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Browse Resume"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnProfileCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <asp:HiddenField ID="counter" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                        <tr class="simple">
                            <td>Select Domain:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDomain" runat="server" Width="250px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="ddlDomain"
                                    Text="*" InitialValue="" ForeColor="Red" ValidationGroup="valida" ErrorMessage="Please select Domain"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="simple">
                            <td>Select SubDomain:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubDomain" Width="250px" AutoPostBack="true" runat="server"
                                    OnSelectedIndexChanged="ddlSubDomain_SelectedIndexChanged">
                                    <asp:ListItem Value="" Text="--Select--"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                    ControlToValidate="ddlSubDomain" Text="*" InitialValue="" ValidationGroup="valida"
                                    ErrorMessage="Please select subdomain" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="simple">
                            <td>Select Category:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" Width="250px" runat="server">
                                    <asp:ListItem Value="" Text="--Select--"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                    ControlToValidate="ddlCategory" Text="*" InitialValue="" ValidationGroup="valida"
                                    ErrorMessage="Please select category" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="simple">
                            <td>Browse CV:
                            </td>
                            <td>
                                <asp:Button ID="btntest" runat="server" Style="display: none" />
                                <telerik:RadAsyncUpload HttpHandlerUrl="~/Handlers/CustomHandler.ashx" runat="server"
                                    ID="AsyncUpload1" HideFileInput="true" MultipleFileSelection="Automatic" AllowedFileExtensions=".doc,.docx,.pdf"
                                    OnClientFileUploadFailed="onUploadFailed" OnClientFileSelected="fileSelected"
                                    OnClientFileUploaded="onFileUploaded" PostbackTriggers="btnSubmit" OnClientFilesUploaded="UploadFiles"
                                    OnClientFileUploading="onFileUploaded">
                                    <Localization Select="Attach Files" />
                                </telerik:RadAsyncUpload>
                                <span style="padding-left: 50px" class="allowed-attachments"><span class="xCustomTip"
                                    data-placement="top" data-toggle="tooltip" data-original-title="<%= String.Join( ", ", AsyncUpload1.AllowedFileExtensions )%>">View Supported file formats</span> </span>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validateRadUpload"
                                    ErrorMessage="Please browse at least one file" ForeColor="Red" Text="*" Display="Dynamic"
                                    ValidationGroup="valida" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
            <br />
            <div style="text-align: center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-ora nl" ValidationGroup="valida"
                    OnClick="btnSubmit_Click" />
                <br />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
    <script>
        function validateRadUpload(source, e) {
            var upload = $find("<%=AsyncUpload1.ClientID %>");
            e.IsValid = upload.getUploadedFiles().length != 0;

            return e.IsValid;
        }

    </script>
</asp:Content>
