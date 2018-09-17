<%@ Page Title="Reserve Slots" Language="C#" AutoEventWireup="true" CodeFile="BulkSchduleCandidate.aspx.cs"
    Inherits="BulkSchduleCandidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <link href="/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/inc-final/calendarview.css" />
    <script type="text/javascript" src="/inc-final/prototype.js"></script>
    <script type="text/javascript" src="/inc-final/calendarview.js"></script>
    <title>Reserve Slots</title>
    <style type="text/css">
        .btn-ora1
        {
            background: url(/assetsprocurement/images/bgs/btn.png) repeat-x top left;
            padding: 8px;
            color: #333333 !important;
            font-size: 12px;
            font-weight: bold;
            text-decoration: none;
          
            
           
            border: 0px;
        }
        #mycontainer
        {
            width: 100%;
            float: left;
            font-size: 12px;
            min-height: 600px;
            z-index: 0 !important;
        }
        #mycontainer table
        {
            margin-right: auto;
            margin-left: auto;
            align: center;
            width: 80%;
            border-top: 1px solid #d5d5d5;
            border-right: 1px solid #d5d5d5;
        }
        #mycontainer table th
        {
            padding: 7px;
        }
        #mycontainer table td, #mycontainer table th
        {
            border-left: 1px solid #d5d5d5;
            border-bottom: 1px solid #d5d5d5;
        }
        
        #mycontainer table thead
        {
            background: url(/assetsprocurement/images/th-bg.jpg) repeat-x bottom left;
            font-size: 12px;
            color: #666666;
        }
        #mycontainer table tbody tr.grey td
        {
            background: #f7f7f7;
            text-indent: 0px;
        }
        #mycontainer table tbody tr.blue td
        {
            background: #eaf5ff;
            text-indent: 10px;
        }
        #mycontainer table tbody tr td.sred
        {
            background: #fc5656;
            text-indent: 0px;
        }
        
        #mycontainer table tbody tr td.sgreen
        {
            background: #56a257;
            text-indent: 10px;
        }
        #mycontainer table tbody tr th.grey
        {
            background: #f7f7f7;
        }
        #mycontainer table tbody tr td
        {
            background: #fff;
            padding: 5px;
            text-indent: 0px;
            font-size: 12px;
            color: #666;
            text-indent: 0px;
        }
    </style>
    <script type="text/javascript">
        function setupCalendars() {
            // Embedded Calendar
            Calendar.setup(
          {
              dateField: 'txtSelectedDate',
              parentElement: 'embeddedCalendar'
          }

        )
        }
        Event.observe(window, 'load', function () { setupCalendars() })

        

    </script>
    <script type="text/javascript">
        function CheckAllCheckBoxes(obj) {
            chk = document.documentElement.getElementsByTagName('input');
            for (var i = 0; i < chk.length; i++) {

                if (chk[i].id.indexOf('chkCandidate') >= 0) {
                    chk[i].checked = obj.checked;
                }
            }
        }

        function Validate() {
            var inputs = document.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (inputs[i].checked == true)
                        return true;
                }
            }
            alert("Please select some record(s) first.");
            return false;
        }
    </script>
    <script type="text/javascript">
        function refreshParent() {
            alert('Save Sucessfully');
            window.parent.location.href = "../Profile/ViewProfileCandidate.aspx";
        }
        function refreshParentCandidateDetail() {
            alert('Save Sucessfully');
            var t = '<%= QueryString %>';
            window.parent.location.href = "../candidate/CandidateDetails.aspx?data=" + t;
        }
        function refreshParent1() {
            alert('Save Sucessfully');
            var t = '<%= QueryString %>';
            window.parent.location.href = "../candidate/CandidateDetails.aspx?data=" + t;
        }
        function ShowHideStatus() {
            if (document.getElementById("ddlcategories").value != '-1') {
                document.getElementById("trStatus").style.display = '';
                document.getElementById("ddlStatus").value = '-1';

                if (document.getElementById("ddlStatus").value != '-1') {
                    document.getElementById("trVanue").style.display = '';
                    document.getElementById("ddlVenue").value = '-1';
                }
                else {

                    document.getElementById("ddlVenue").value = '-1';

                }
                if (document.getElementById("ddlVenue").value != '-1') {
                    document.getElementById("trSlots").style.display = '';
                    document.getElementById("trSearchBtn").style.display = '';
                }
                else
                    document.getElementById("trSlots").style.display = 'none';
                document.getElementById("trSearchBtn").style.display = 'none';
            }
            else {


                document.getElementById("trStatus").style.display = 'none';
                document.getElementById("trVanue").style.display = 'none';
                document.getElementById("trSlots").style.display = 'none';
                document.getElementById("tblCandidate").style.display = 'none';

                //                document.getElementById("ddlStatus").value = '-1';
                //                document.getElementById("ddlVanue").value = '-1';
            }

        }
    </script>
</head>
<body>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <br />
        <div id="mycontainer" style="vertical-align: middle !important; margin-right: auto;
            margin-left: auto;">
            <table border="0" cellspacing="0" cellpadding="0">
                <tr class="grey">
                    <td colspan="3">
                        <h2>
                            <span>Bulk </span>Slot Reservation
                            <asp:Label ID="lblReqType" runat="server" Font-Bold="false"></asp:Label></h2>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        Select category:
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlcategories" runat="server" onChange="javascript:ShowHideStatus();"
                            Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trStatus" runat="server" style="display: none">
                    <td style="width: 10%" valign="top" align="left">
                        Select Status:
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="OnStatusChange"
                            AutoPostBack="true" Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trVanue" runat="server" style="display: none">
                    <td>
                        Select Venue:
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlVenue" runat="server" Width="300px" OnSelectedIndexChanged="OnVanueChange"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trSlots" runat="server" style="display: none">
                    <td align="left" valign="top">
                        Select Slot:&nbsp;
                    </td>
                    <td valign="top" align="left" style="width: 26%; border-right-style: solid; border-right-width: 0px; border-right-color: #FFFFFF;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSlotTime" runat="server" OnSelectedIndexChanged="OnSlotChange"
                                    AutoPostBack="true" Width="300px">
                                </asp:DropDownList>
                                <asp:Label ID="Label1" runat="server" ForeColor="#CC3300"></asp:Label><br />
                                <br />
                                <br />
                                <asp:Label ID="lbltime" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblCount" runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                    ControlToValidate="ddlSlotTime" ErrorMessage="Please select your position in Sibling"
                                    Font-Bold="True" ForeColor="Red" Text="<img src='/area/assets/img/Exclamation.gif' title='Please Select Time First!' />"
                                    InitialValue="-1"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="Date must be greater then or equal to current date"
                                    Text="<img src='/area/assets/img/Exclamation.gif' title='Date must be greater then or equal to current date!' />"
                                    ControlToValidate="txtSelectedDate" ClientValidationFunction="ValidateFromDate"></asp:CustomValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtSelectedDate" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="/area/assets/img/loading.gif" alt="" align="middle" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </td>
                    <td align="left" valign="top">
                        <div id="embeddedExample" style="width: 300px; height: 100px">
                            <div id="embeddedCalendar" style="font-size: 9px; margin-left: auto; margin-right: auto;
                                width: 300px; float: left;">
                            </div>
                            <br />
                            <div id="embeddedDateField">
                                <asp:TextBox ID="txtSelectedDate" Style="display: none" runat="server" OnTextChanged="GetUnreservedSlots"
                                    AutoPostBack="true"> Select Date</asp:TextBox>
                            </div>
                            <br />
                        </div>
                    </td>
                </tr>
                <tr id="trSearchBtn" align="center" style="display: none" runat="server">
                    <td colspan="3">
                        <asp:Button ID="btnSearchCandidate" runat="server" Text="Search Candidate" OnClick="btnSearchCandidate_Click" CssClass="btn-ora1"/>
                    </td>
                </tr>
            </table>
            <br />
            <table id="tblCandidate" runat="server" cellpadding="0" cellspacing="0" style="display: none"
                border="0">
                <tr>
                    <td>
                        <asp:Repeater ID="rptCandidates" runat="server">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" style="padding: 0px; margin: 0px; background-color: #969696; width: 100% !important">
                                    <tr class="grey">
                                        <td style="width: 2%">
                                            <input type="checkbox" id="chkAllCandidate" runat="server" onclick="javascript:CheckAllCheckBoxes(tdis)" />
                                        </td>
                                        <td style="width: 32%">
                                            ID
                                        </td>
                                        <td style="width: 32%">
                                            Name
                                        </td>
                                        <td style="width: 33%">
                                            Status
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background-color: #ffffff;">
                                    <td>
                                        <input id="chkCandidate" runat="server" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:HiddenField runat="server" ID="hdnCandCode" Value=' <%#Eval("ID") %>' />
                                        <%#Eval("ID") %>
                                    </td>
                                    <td>
                                        <%#Eval("name") %>
                                    </td>
                                    <td>
                                        <%#Eval("status") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td>
                                        <input id="chkCandidate" runat="server" type="checkbox" />
                                    </td>
                                    <td>
                                        <asp:HiddenField runat="server" ID="hdnCandCode" Value=' <%#Eval("ID") %>' />
                                        <%#Eval("ID") %>
                                    </td>
                                    <td>
                                        <%#Eval("name") %>
                                    </td>
                                    <td>
                                        <%#Eval("status") %>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table></FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btnSave1" Text="Reserve" OnClick="Save_click"  CssClass="btn-ora1" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="DivError" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <script type="text/javascript" language="javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        var postBackElement;
        function CancelAsyncPostBack() {
            alert('1');
            if (prm.get_isInAsyncPostBack()) {
                prm.abortPostBack();
            }
        }
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);

        function InitializeRequest(sender, args) {


            if (prm.get_isInAsyncPostBack()) {
                args.set_cancel(true);
            }
            postBackElement = args.get_postBackElement();

            if (postBackElement.id == 'txtSelectedDate') {

                $get('UpdateProgress1').style.display = 'block';
            }
        }
        function EndRequest(sender, args) {


            if (postBackElement.id == 'txtSelectedDate') {
                $get('UpdateProgress1').style.display = 'none';
            }
        }
       
    </script>
    </form>
</body>
</html>
