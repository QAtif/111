<%@ control language="C#" autoeventwireup="true" CodeFile="CandidateInfo.ascx.cs" Inherits="A2_Control_CandidateInfo" %>
<div>
    <table>
        <tr>
            <td style="padding-left:10px">
            <asp:HiddenField ID="hdnCancode" runat="server" />
                Name
            </td>
            <td style="padding-left:10px">
            <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
            <td style="padding-left:10px">
                Reference #
            </td>
            <td style="padding-left:10px">
               <asp:Label ID="lblref" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">
                Department
            </td>
            <td style="padding-left:10px">
               <asp:Label ID="lbldep" runat="server"></asp:Label>
            </td>
            <td style="padding-left:10px">
                Status
            </td>
            <td style="padding-left:10px">
               <asp:Label ID="lblsts" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
