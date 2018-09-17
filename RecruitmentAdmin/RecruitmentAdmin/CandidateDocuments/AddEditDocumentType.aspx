<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Popup.master" CodeFile="AddEditDocumentType.aspx.cs"
    Inherits="RecruitmentAdmin_CandidateDocuments_AddEditDocumentType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Add Document Type</title>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                parent.window.location.href = mainURL; //  + "?" + window.location.search.substring(1);
                //   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Add Link"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <br />
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        Document Type Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumentTypeName" runat="server" Width="400px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtDocumentTypeName"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="DocumentType Name can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Program:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrograms" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Add New DocumentType" CssClass="btn-ora nl"
                            ValidationGroup="valida" OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
