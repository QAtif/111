<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Schedule.aspx.cs" Inherits="CandidateDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reserve Slot</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <style type="text/css">
        @font-face
        {
            font-family: 'LucidaGrande';
            src: url('/AxactMediaSolutions/DMS~/Area-V1.1/assets/fonts/lucidaGrandeNormal.eot');
            src: url('/AxactMediaSolutions/DMS~/Area-V1.1/assets/fonts/lucidaGrandeNormal.eot?#iefix') format('embedded-opentype'), /* url('/AxactMediaSolutions/DMS~/Area-V1.1/assets/fonts/lucidaGrandeNormal.woff') format('woff'), */ url('/AxactMediaSolutions/DMS~/Area-V1.1/assets/fonts/lucidaGrandeNormal.ttf') format('truetype'), url('/AxactMediaSolutions/DMS~/Area-V1.1/assets/fonts/lucidaGrandeNormal.svg#lucidaGrandeNormal') format('svg');
            font-weight: normal;
            font-style: normal;
        }
        @font-face
        {
            font-family: "lucida_grandebold";
            font-style: normal;
            font-weight: normal;
        }
        body
        {
            
            font: normal .810em/162% LucidaGrande;
            color: #666;
        }
        a
        {
            color: #036;
            outline: none !important;
        }
        button
        {
            outline: none !important;
            white-space: nowrap;
            font-family: LucidaGrande;
            font-size: 11px !important;
        }
        h1, h2, h3, h4, h5, h6
        {
            color: #333;
            font-family: LucidaGrande;
            font-weight: 400;
        }
        strong
        {
            font-family: lucida_grandebold;
        }
        .btn-ora
        {
            background: url(/assets-final/images/btn-bg.png) repeat-x left top;
            font-size: 11px;
            padding: 4px 20px;
            border: 1px solid #555555;
            cursor: pointer;
            color: #474747;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="spm" runat="server">
    </asp:ScriptManager>
    <div id="divmain" runat="server">
        <div style=" width: 100%; float: left; padding-bottom: 30px;
            padding-top: 30px; background-color: #F7F7F7;">
            <div style="float: left; width: 55%; padding-left: 20px;">
                <div id="datepicker1">
                </div>
                <asp:TextBox ID="txtSelectedDate" runat="server" Style="display: none" OnTextChanged="GetUnreservedSlots"
                    AutoPostBack="true" ValidationGroup="select"> Select Date</asp:TextBox>
            </div>
            <div style="float: right; width: 40%; text-align: -webkit-left;">
                <span style="font-weight: bold;">Available Slots</span>
                <br />
                <br />
                <asp:Panel ID="pnl" Height="200px" ScrollBars="Auto" runat="server">
                    <asp:RadioButtonList ID="rblSlot" runat="server" RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <asp:Label ID="lblSlotMsg" ForeColor="Red" runat="server"></asp:Label>
                </asp:Panel>
            </div>
        </div>
        <div style="width: 100%; float: left; padding-top: 25px; padding-left: 20px;">
            <div style="float: left; width: 50%; text-align: left">
                <asp:RequiredFieldValidator ID="rfvddlSlotTime" Display="Dynamic" runat="server"
                    ControlToValidate="rblSlot" Font-Bold="True" ForeColor="Red" Text="" ValidationGroup="this"></asp:RequiredFieldValidator>
                <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label></div>
            <div style="float: right; width: 45%; text-align: right; padding-right:30px;">
                <a id="btnSave1" runat="server" title="" onclick="javascript:return validateForm();"
                    class="btn-ora" style="cursor: pointer;">Save</a>
                <asp:Button ID="Save1" runat="server" Text="Save1" OnClick="btnSave_Click" Style="display: none !important" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function validateForm() {
        if (!Page_ClientValidate('this'))
            document.getElementById('lblmessage').innerHTML = "* Please select slot.";
        else
            $('#Save1').click();

        return Page_ClientValidate('this');


    }



    $("#datepicker1").datepicker({
        dateFormat: 'yy-mm-dd',
        changeMonth: true,
        changeYear: true,
        minDate: 0,
        //            showOn: "both",
        //            disabled: false,
        //defaultDate: '01/01/2013',
        onSelect: function () {
            callme(this);
        }
    });

    $(document).ready(function () {
        dtString = $("#<%=txtSelectedDate.ClientID%>").val();
        dtString = dtString.replace('/', '-');
        dtString = dtString.replace('/', '-');
        // alert(dtString);
        // alert(jQuery.datepicker.parseDate("yy-mm-dd", dtString.split("T")[0]));           
        var defaultDate = new Date(jQuery.datepicker.parseDate("yy-mm-dd", dtString.split("T")[0]));
        // alert(defaultDate);          
        $("#datepicker1").datepicker("setDate", defaultDate);

    });

    function changeCalenderDate() {

        // alert('a');
        debugger;
        dtString = $("#<%=txtSelectedDate.ClientID%>").val();
        dtString = dtString.replace('/', '-');
        dtString = dtString.replace('/', '-');
        var defaultDate = new Date(jQuery.datepicker.parseDate("yy-mm-dd", dtString.split("T")[0]));
        $("#datepicker1").datepicker("setDate", defaultDate);

    }
    function callme(objDate) {
        var myDate = $(objDate).datepicker('getDate');
        //var currentDate = (myDate.getMonth() + 1) + '/' + myDate.getDate() + '/' + myDate.getFullYear();
        var currentDate = myDate.getFullYear() + '/' + (myDate.getMonth() + 1) + '/' + myDate.getDate();

        document.getElementById("txtSelectedDate").value = currentDate;
        document.getElementById("txtSelectedDate").onchange();
    }

    //        $(function () {
    //            $("#datepicker").datepicker({
    //                changeMonth: true,
    //                changeYear: true,
    //                showOn: "both",
    //                disabled: false
    //            });
    //        });

    function setupCalendars() {
        // Embedded Calendar
        Calendar.setup(
          {
              dateField: 'txtSelectedDate',
              parentElement: 'embeddedCalendar'
          }
        )
    }
   
       
</script>
