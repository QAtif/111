<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditCallRecording.aspx.cs" Inherits="AddEditCallRecording" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script type="text/javascript">
         function refreshParent(obj) {
             //window.parent.location.href = "FoodType.aspx";
             window.parent.location.href = window.parent.location.href;
         }
         

    </script>
    <div class="head">
        <h2>
            Add New Recording</h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="specialtab">
            <tbody>
                <tr id="trMessage" runat="server" align="center">
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="red"></asp:Label>
                    </td>
                </tr>
        
                <tr class="grey">
                    <td style="width: 200px">
                        Browse File :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fuDocument" runat="server" Width="251px" />
                        <a id="lnkView" href="" runat="server"></a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                    Comments : 
                    </td>
                    <td align="left">
                        <asp:TextBox TextMode="MultiLine" Rows="6" runat="server" ID="txtComments"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trAdd" runat="server">
                    <td align="center" colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr runat="server" id="SearchCategoryOptions2">
                    <td colspan="2">
                        <p>
                            <asp:Repeater ID="rptFile" runat="server" OnItemDataBound="rptFile_ItemDataBound">
                                <HeaderTemplate>
                                    <table width="50%" cellspacing="0" cellpadding="0" border="0" style="background-color: White">
                                        <tr>
                                            <td>
                                                <strong>File</strong>
                                            </td>
                                            <td>
                                                <strong>Comments</strong>
                                            </td>                                            
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td width="30%" align="left">
                                            <strong>                                                
                                                <a runat="server" id="lnkFile"></a>
                                                </strong>
                                            <asp:HiddenField runat="server" ID="hdnCandidateCode" Value='<%# Eval("Candidate_Code")%>'>
                                            </asp:HiddenField>
                                        </td>
                                        <td width="70%"  align="left">
                                            <asp:Literal runat="server" ID="lblIsCorrect" Text='<%# Eval("Comments")%>'></asp:Literal>
                                        </td>                                        
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </p>
                        <p>
                            &nbsp;
                        </p>
                        <p>
                            &nbsp;
                        </p>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        
    </div>
</asp:Content>
