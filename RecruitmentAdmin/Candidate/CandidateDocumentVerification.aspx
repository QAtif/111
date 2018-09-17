<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="CandidateDocumentVerification.aspx.cs" Inherits="Candidate_CandidateDocumentVerification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <title>Candidate Details</title>
    <style>
        .DG_LeaveHistory_Header
        {
            background-color: #DADADA;
            background-image: url("/assets/images/grayBg.gif");
            background-position: center top;
            background-repeat: repeat-x;
            border-style: none;
            color: #666666;
            font-family: Verdana;
            font-size: 12px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            height: 25px;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                // parent.window.location.href = mainURL; //  + "?" + window.location.search.substring(1);
                parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="container" class="contentarea">
        <asp:HiddenField ID="hdnCandCode" runat="server" Value="0" />
        <div>
            <div style="text-align: center">
                <p class="heading">
                    &nbsp;
                    <h3>
                        CANDIDATE INFO
                    </h3>
                </p>
            </div>
            <table width="90%" style="background-color: #F5F5F5; border: 0px">
                <tr>
                    <td width="30%">
                        Candidate Name:
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Department:
                    </td>
                    <td>
                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Designation:
                    </td>
                    <td>
                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Job Category:
                    </td>
                    <td>
                        <asp:Label ID="lblJobCategory" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                    <asp:Repeater ID="rptDocumentType" runat="server" OnItemDataBound="rptDocumentType_OnItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%--    <tr>
                                <td>
                                    <asp:HiddenField ID="hdnProgramCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Program_Code")%>' />
                                    <asp:HiddenField ID="hdnDocumentTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DocType_Code")%>' />
                                    <h3>
                                        <span class="icon"></span>
                                        <%# DataBinder.Eval(Container.DataItem, "DocumentTypeName")%><a class="btn-add">
                                        </a>
                                    </h3>
                                </td>
                            </tr>--%>
                            <tr class="DG_LeaveHistory_Header">
                                <td style="font-weight: bold;" align="center">
                                    <asp:HiddenField ID="hdnProgramCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Program_Code")%>' />
                                    <asp:HiddenField ID="hdnDocumentTypeCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DocType_Code")%>' />
                                    <%# DataBinder.Eval(Container.DataItem, "DocumentTypeName")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Repeater ID="rptCandidateDocument" runat="server" OnItemDataBound="rptCandidateDocument_OnItemDataBound">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="background-color: #9FABCD; border-style: none; color: #FFFFFF; font-family: Verdana;
                                                    font-size: 12px; font-style: normal; font-variant: normal; font-weight: bold;
                                                    height: 25px; padding-left: 10px; text-align: left;">
                                                    <asp:HiddenField ID="hdnReferenceCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ReferencePK")%>' />
                                                    <asp:HiddenField ID="hdnProgram" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ProgramCode")%>' />
                                                    <asp:HiddenField ID="hdnDocument_Type" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DocumentType")%>' />
                                                    <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RefernecInstitute")%>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Repeater ID="rptUploadDocuments" runat="server" OnItemDataBound="rptUploadDocuments_OnItemDataBound">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                    <tr>
                                                                        <th style="width: 20%; font-weight: bold;">
                                                                            Document Name
                                                                        </th>
                                                                        <th style="width: 25%; font-weight: bold;">
                                                                            &nbsp;
                                                                        </th>
                                                                        <th style="width: 15%; font-weight: bold;">
                                                                            &nbsp;
                                                                        </th>
                                                                        <th style="width: 15%; font-weight: bold;">
                                                                            &nbsp;
                                                                        </th>
                                                                        <th style="width: 15%; font-weight: bold;">
                                                                            &nbsp;
                                                                        </th>
                                                                    </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                                                    <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="200px" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <div id="dvStatus" style="text-align: left" runat="server" visible="false">
                                                                        <br />
                                                                        <asp:DropDownList ID="ddlDayCount" Width="50px" runat="server">
                                                                        </asp:DropDownList>
                                                                        <br />
                                                                        <asp:TextBox ID="txtStatusComment" runat="server" Width="250px" Height="80px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                        <br />
                                                                        <asp:CheckBox ID="chkSupportDoc" runat="server" Text="Has Supportive Document" />
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkOriginal" runat="server" Text="Original Seen" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkObjection" runat="server" Text="Objection" AutoPostBack="True"
                                                                        OnCheckedChanged="chkObjection_CheckedChanged" />
                                                                    <asp:TextBox ID="txtObjectionComments" runat="server" Width="250px" Height="80px"
                                                                        TextMode="MultiLine" Visible="false"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DOCUMENT_Path") %>'
                                                                        title="Click here to View Document">View</a>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table> </div>
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
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
            <br />
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="3" style="font-weight: bold; background: url(/assets/images/graEdit3.jpg)"
                        align="center">
                        Others
                    </td>
                </tr>
                <tr>
                    <td width="33%">
                        Medical Report
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblMedical" runat="server"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:RadioButton ID="rbtnPass" runat="server" GroupName="doc" Text="Passed" />
                        <asp:RadioButton ID="rbtnFail" runat="server" GroupName="doc" Text="Failed" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <div style="text-align: center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn-ora nl" Text="Save" OnClick="btnSave_Click" />
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
