<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JCalendar.ascx.cs" Inherits="Controls_JCalendar" %>

<link href="css/cupertino/jquery-ui-1.7.3.custom.css" rel="stylesheet" type="text/css" />

    <link href="fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />


    <script src="jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="jquery/jquery-ui-1.7.3.custom.min.js" type="text/javascript"></script>

    <script src="jquery/jquery.qtip-1.0.0-rc3.min.js" type="text/javascript"></script>

    <script src="fullcalendar/fullcalendar.min.js" type="text/javascript"></script>

    <script src="scripts/calendarscript.js" type="text/javascript"></script>
    <script src="jquery/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>
    <style type='text/css'>
        
        #calendar
        {
            width: 450px;
            margin: 0 auto;
        }
       

.reportSection .fc { color:#999; font-size:13px; font-weight:300; text-transform:uppercase; }
.reportSection .fc .fc-button-today,
.fc-agenda-divider.fc-widget-header,
.reportSection .fc .fc-header-right { display: block !important; }
.reportSection .fc .fc-header-right table{position: relative;
right: -334px;
top: 7px;}
.reportSection .fc-header { background:#e2e7e6; } 
.reportSection .fc .fc-header-center { float:left; font-size:13px; color:#999; text-transform:uppercase; padding:8px 20px; }
.reportSection .fc .fc-header-center table{position: relative;
top: 24px;
right: 44px;}
.reportSection .fc .fc-header-center h2 { margin:0px; }
.reportSection .fc .fc-header-left { float:right; width:auto; padding:6px 0px; }
.reportSection .fc-header .fc-button { margin-bottom:0px; color:#acadad; }
.reportSection .fc-content { margin-top:20px; }
.reportSection .fc-widget-header{ background:#e2e7e6; padding:8px 0; font-weight:300; }
.reportSection .fc-grid .fc-day-number { float:left; padding:5px 10px 0; }
.reportSection .fc-button { padding:0px; }
.reportSection td.fc-day div { min-height: inherit !important; }
.reportSection .fc-event { background:#f7ede0; border:1px solid #f7ede0; word-wrap:break-word; color:#666; text-transform:capitalize; font-size:9px; padding:4px 10px; }
.reportSection .fc-event:before { top:0; left: 0; border: solid transparent; content: ""; height: 0; width: 0; position: absolute; pointer-events: none; border-color: rgba(231,231,231,0); border-top-color: #fdc689;  border-left-color: #fdc689;
border-width:5px; }
.reportSection .fc-agenda-slots .fc-agenda-axis{ background:#f5f7f6; text-transform:capitalize; padding:4px; }
        
        /* table fields alignment*/
        .alignRight
        {
        	text-align:right;
        	padding-right:10px;
        	padding-bottom:10px;
        }
        .alignLeft
        {
        	text-align:left;
        	padding-bottom:10px;
        }
    </style>


    

<div id="calendar">
    </div>
        <div runat="server" id="jsonDiv" />
    <input type="hidden" id="hdClient" runat="server" />