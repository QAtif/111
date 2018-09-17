<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ManageDocuments.aspx.cs"
    Inherits="RecruitmentAdmin_CandidateDocuments_ManageDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Document Management</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Document</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <a href="AddEditDocumentType.aspx" class="openframe">Add Document Type</a>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="10" cellspacing="0">
                    <asp:Repeater ID="rptDocumentType" runat="server" OnItemDataBound="rptDocumentType_ItemDataBound"
                        OnItemCommand="rptDocumentType_ItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="10" cellspacing="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="simple">
                                <td align="center">
                                    <asp:HiddenField ID="hdnDocumentTypeCode" runat="server" Value='<%# Eval("DocumentTypeCode")%>' />
                                    <asp:HiddenField ID="hdnProgramCode" runat="server" Value='<%# Eval("ProgramCode")%>' />
                                    <strong>
                                        <%# Eval("DocumentTypeName")%></strong>
                                </td>
                                <td align="center" width="10%">
                                    <a id="aAdd" runat="server" class="openframe">
                                        <img src="/assetsprocurement/images/icons/plus-ico.png" title="Add New Document Type" />
                                    </a><a id="aEdit" runat="server" class="openframe">
                                        <img src="/assetsprocurement/images/Edit.png" title="Edit Document Type" /></a>
                                    <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                        CommandName="Delete" ToolTip="Delete Category" ImageUrl="/assetsprocurement/images/Delete.png"
                                        CommandArgument='<%# Eval("DocumentTypeCode")%>' />
                                </td>
                            </tr>
                            <tr id="tr" runat="server">
                                <td colspan="2">
                                    <asp:Repeater ID="rptDocument" runat="server" OnItemDataBound="rptDocument_ItemDataBound"
                                        OnItemCommand="rptDocument_ItemCommand">
                                        <HeaderTemplate>
                                            <table width="100%" border="0" cellpadding="10" cellspacing="0">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center" width="40%">
                                                    <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("DocumentCode")%>' />
                                                    <asp:HiddenField ID="hfDocTypeCode" runat="server" Value='<%# Eval("DocType_Code")%>' />
                                                    <%# Eval("DocumentName")%>
                                                </td>
                                                <td align="center" width="40%">
                                                    <%# Eval("URL")%>
                                                </td>
                                                <td align="center" width="8%">
                                                    <a id="aEdit" runat="server" class="openframe">
                                                        <img src="/assetsprocurement/images/Edit.png" title="Edit Document" />
                                                    </a>
                                                    <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                        CommandName="Delete" ToolTip="Delete Link" ImageUrl="/assetsprocurement/images/Delete.png"
                                                        CommandArgument='<%# Eval("DocumentCode")%>' />
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
                    </asp:Repeater>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </div>
</asp:Content>
