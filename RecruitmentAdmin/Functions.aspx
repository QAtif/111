<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Functions.aspx.cs" Inherits="Functions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
     <div style="text-align: center;">
        <asp:Button ID="btnMapping" runat="server" CssClass="btn-ora nl" Text="Run Mapping Function"
            OnClick="btnMapping_Click" />
            <br />
        <asp:Label ID="lblMsgMapping" runat="server"></asp:Label>
    </div>
    <br />
    <div style="text-align: center;">
        <asp:Button ID="btnShortlisting" runat="server" CssClass="btn-ora nl" Text="Run Shortlisting Function"
            OnClick="btnShortlisting_Click" />
            <br />
        <asp:Label ID="lblMsgShortlisting" runat="server"></asp:Label>
    </div>
</asp:Content>

