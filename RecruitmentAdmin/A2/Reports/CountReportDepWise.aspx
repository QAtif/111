<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="CountReportDepWise.aspx.cs" Inherits="A2_Reports_CountReportDepWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script language="javascript" type="text/javascript">

        function onpress() {
            $('#id_search_list').quicksearch('#UlMain>li');
        }
        // var qs = $('#id_search_list').quicksearch('#UlMain li');
      

    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="position: absolute; right: 605px; top: 121px;">
       
        &nbsp;From:&nbsp;
        <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
            readonly="true" style="border: 1px solid #E9E9E9 !important;" />
             &nbsp;To:&nbsp;
        <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
            readonly="true" style="border: 1px solid #E9E9E9 !important;"/>
       <asp:LinkButton id="btnSearch" OnClientClick="javascript:$('#imgLoadingF').show();" onclick="btnSearch_Onclick" runat="server" style="top: 5px;position: relative;left: 10px;">
                    <img src="../assets/images/search-b.png" height="20" width="20" /></asp:LinkButton>
                      <img id="imgLoadingF" runat="server" src="~/assets/images/loading.gif" alt="" style="display:none ;
                    position: absolute; right: -85px;bottom: -10px;" clientidmode="Static" />
    </div>
    <div class="ShowAllDataGrid">
        <section class="wrapit topmenu offeraproval" style="max-width: 989px !important;
            min-width: 1018px !important;"> <span class="msearch"><i class="deptstruct-icon"></i>Status Wise Report</span>
        
      <ul class="TopLeftMenu">
        <li class="last even searchhidden">
           
          <div class="srch-fix">     
            <input type="text"  name=""  value="" id="id_search_list" onkeyup="javascript:onpress();"  title="Enter Domain Name"/>            
            <input type="submit" class="showsearchtxt" value="" />
          </div>
        </li>
      </ul>
    </section>
        <div class="main-wrapper newscreen" style="max-width: 989px !important; min-width: 1018px !important;">
            <!-- Main Content Here -->
            <section class="main-content">
        <div class="main-accrodian newcoloredbar">
        
        <asp:HiddenField ID="hdnSelectedCategory" runat="server" />
          <ul id="UlMain">
           <asp:Repeater ID="rptDeparments" runat="server">
             <ItemTemplate>
            <li>
              <div class="accordian-btn">
                <div>
                <%--  <input type="checkbox" name="checkIt">--%>
              
                  <div><%# Eval("Domain") %><i></i></div>
                  <ul class="subcnt" style="width: 247px !important;">
                  	<li><strong><%# Eval("Test") %></strong> <strong class="status">Test</strong></li>
                    <li><strong><%# Eval("Interview") %></strong> <strong class="status">Interview</strong></li>
                    <li><strong><%# Eval("Offer") %></strong> <strong class="status">Offer</strong></li>
                    <li><strong><%# Eval("Appointment") %></strong> <strong class="status">Appointment</strong></li>
                   <%-- <li class="lastattachment"><a href="javascript:;" title=""><i class="icon-attachment"></i></a></li>
                    <li class="lastattachment"><a href='<%# Eval("DomainCode","#frame-sets{0}") %>' title="" class="viewrecpop poptheform"><i class="icon-viewrec"></i></a></li>--%>
                  </ul>
                </div>
              </div>
            
            </li>
              </ItemTemplate>
                              </asp:Repeater>
          </ul>
        </div>
      </section>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"


            });
        });

        $(function () {
            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });

    </script>
</asp:Content>
