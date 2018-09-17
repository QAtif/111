<%@ Page Title="Candidate Initial Picture" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="ViewInitialPic.aspx.cs" Inherits="ViewInitialPic" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 <title>Candidate Initial Picture</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="head">
       
    </div>
    <div id="container" class="contentarea">
     <asp:Image ID="imgCandidate" ImageUrl="" runat="server" />
      
        
    </div>
    
</asp:Content>

