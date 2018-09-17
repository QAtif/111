<%@ Page Title="" Language="C#" MasterPageFile="../Admin.master" AutoEventWireup="true"
    CodeFile="DomainOwners.aspx.cs" Inherits="DomainOwners" %>

<%@ Register Src="../Control/JCalendar.ascx" TagName="JCalendar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="page">
        <section class="wrapit topmenu"> 
        <span class="resource-icon"></span> 
        <span class="msearch showsrchbox">Domain Owner</span>
    </section>
        <!-- TOPMENU END HERE -->
        <section class="mainSection">    	
         <div class="clearfix">
            <ul class="pendingColumn">
                <li class="radishColor grid_240">
                    <div class="clearfix">
                        <i class="note-icon"></i>
                        <span>Offers Pending <br /> My Approval</span>
                    </div>
                    <ul class="clearfix">
                         <li><asp:Label ID="lblOfferPending" runat="server"></asp:Label> <small>Pending</small> </li>
                    </ul>
                </li>
                <li class="orangeColor grid_240">
                    <div class="clearfix">
                        <i class="opd-icon"></i>
                        <span>Requisition Pending <br /> My Approval </span>
                    </div>
                    <ul class="clearfix">
                       <li><asp:Label ID="lblOPDPending" runat="server"></asp:Label> <small>Pending</small> </li>
                    </ul>
                </li>
                <li class="lighGreenColor grid_240">
                    <div class="clearfix">
                        <i class="status-icon"></i>
                        <span>Current Requisitions <br /> Status</span>
                    </div>
                    <ul class="clearfix">                                            
                        <li><asp:Label ID="lblCurrentPending" runat="server"></asp:Label>  <small>Pending</small> </li>
                    </ul>
                </li>
                <li class="lighBlueColor grid_530 sixColumn">
                    <div class="clearfix">
                        <i class="schedule-icon"></i>
                        <span>Today's <br /> Schedule</span>
                    </div>
                    <ul class="clearfix">
                        <li><asp:Label ID="lblTest" runat="server"></asp:Label> <small>Test</small> </li>
                        <li><asp:Label ID="lblIntervew" runat="server"></asp:Label> <small>Final Intervew</small> </li>
                        <li><asp:Label ID="lblOffer" runat="server"></asp:Label> <small>OfFer Letter</small> </li>
                        <li><asp:Label ID="lblVerification" runat="server"></asp:Label> <small>Verification</small> </li>
                        <li><asp:Label ID="lblAppointment" runat="server"></asp:Label> <small>Appointment</small> </li>
                        <li><asp:Label ID="lblNewJoining" runat="server"></asp:Label> <small>New Joinings</small> </li>
                    </ul>
                </li>
            </ul>
        </div>
        
        <section class="clearfix oneThirdWedgit reportSection">
            <div class="leftAside reportStatus">
            	<div class="topSection clearfix">
            		
                </div><!-- TOPSECTION END HERE -->
                <div class="clearfix">
                 <iframe id="if" runat="server" src="highchart.aspx" style="min-width: 677px; height: 440px; margin: 0 auto;border: none;"></iframe>
                </div>
            </div><!-- LEFT-ASIDE END HERE -->
            
            <div class="rightAside reportStatus">
            	<div class="topSection clearfix">
                   <%--<uc1:JCalendar ID="JCalendar1" runat="server" />--%>
                   <iframe id="Iframe1" runat="server" src="Scheduler.aspx" style="min-width: 464px; height: 440px; margin: 0 auto;border: none;"></iframe>
                </div><!-- TOPSECTION END HERE -->
				
                
            </div><!-- RIGHT-ASIDE END HERE -->
        </section><!-- REPORTSECTION END HERE -->
        
    </section>
        <!-- MAIN-SECTION END HERE -->
    </div>
</asp:Content>
