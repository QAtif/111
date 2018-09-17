<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UpdateRAtoPortal.aspx.cs" Inherits="Candidate_UpdateRAtoPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate Detail</title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Sync Portal RA to XRecruitment"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
   
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Sync Portal RA to XRecruitment" CssClass="btn-ora nl"
                            ValidationGroup="valida" OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
