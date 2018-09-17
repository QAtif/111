<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ToDaysSchedule.ascx.cs"
    Inherits="Control_HeaderToDaysSchedule" %>

<div class="clearfix">
    <i class="schedule-icon"></i>
    <span>Today's
        <br>
        Schedule</span>
</div>
<ul class="clearfix">
    <li>
        <asp:Label ID="lblTest" runat="server"></asp:Label>
        <small>Test</small> </li>
    <li>
        <asp:Label ID="lblIntervew" runat="server"></asp:Label>
        <small>Final Intervew</small> </li>
    <li>
        <asp:Label ID="lblOffer" runat="server"></asp:Label>
        <small>OfFer Letter</small> </li>
    <li>
        <asp:Label ID="lblVerification" runat="server"></asp:Label>
        <small>Verification</small> </li>
    <li>
        <asp:Label ID="lblAppointment" runat="server"></asp:Label>
        <small>Appointment</small> </li>
</ul>
