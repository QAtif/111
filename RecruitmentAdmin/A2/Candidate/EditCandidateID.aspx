<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="EditCandidateID.aspx.cs" Inherits="A2_Candidate_EditCandidateID" %>

<asp:content id="Content1" contentplaceholderid="headerContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
</asp:content>
<%-- Add content controls here --%>
<asp:content id="Content2" contentplaceholderid="BodyContent" runat="server">
    <section class="wrapit topmenu offeraproval searchbar">
    <div class="domain-name">
      <!--<input id="selectall" type="checkbox" name="checkIt">-->
      <label>Enter Candidate</label> 
      
    </div>
  </section>
  <article>
    <div class="wrapit">
     <asp:TextBox ID="txtbxRefNum" runat="server" style="margin-top: 22px;margin-left: 41px;" MaxLength="25" Font-Size="X-Large" ToolTip="Please Enter Candidate Reference Number" Text="" Width="287px" ></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="txtbxRefNum" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Enter Reference no."></asp:RequiredFieldValidator>
        <br />
     <div class="ButtonsSave" id="btnSearchF">
            <asp:Button ID="btnMove" runat="server" class="SubmteForm" Text="Update Reference Number" OnClick="btnEditCandidateID_Click"/>
     </div>
     <div>
     <br />
     <br />
        <asp:Label ID="lblCandidate" runat="server" Font-Size="XX-Large" ForeColor="Crimson" ></asp:Label>
     </div>
    </div>
  </article>

</asp:content>