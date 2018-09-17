<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="MoveCandidate.aspx.cs" Inherits="A2_Candidate_MoveCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
</asp:Content>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="wrapit topmenu offeraproval searchbar">
    <div class="domain-name">
      <!--<input id="selectall" type="checkbox" name="checkIt">-->
      <label>Move Candidate</label> 
      
    </div>
  </section>
    <article>
    <div class="wrapit">
  
    Enter Candidate Bol Reference No.
     <asp:TextBox ID="txtbxRefNum" runat="server" Font-Size="X-Large" ToolTip="Please Enter Candidate Reference Number" Text="" ></asp:TextBox>
   
    
     <br />
    
     <div class="ButtonsSave" id="btnSearchF" >
               <asp:Button ID="btnMove" runat="server" class="SubmteForm"  Text="Move Candidate" OnClick="BtnSearchFresh_Click" OnClientClick="javascript:$('#imgLoadingF').show();" />
     </div>
     <div>
     <br />
     <br />
        <asp:Label ID="lblCandidate" runat="server" Font-Size="XX-Large" ForeColor="Crimson" ></asp:Label>
     </div>
    </div>
  </article>
</asp:Content>
