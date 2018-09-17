<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Control_Header" %>
<header>
    <div class="logo"></div>
   <div class="header-icn"></div>
    <span class="userNm" id="spnPortalUserName" runat="server">Ali Ghaffar</span>
    <div class="clearfix"></div>
  </header>
        <nav> <span class="helloUser" id="spnPortalUserName1" runat="server"></span>
    <ul>
          <%=UsertypeHtml.ToString() %>
    </ul>    
    <!-- Profile Status -->
    <div class="clearfix"></div>
  </nav>
      