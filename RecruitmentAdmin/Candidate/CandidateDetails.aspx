<%@ Page Title="Candidate Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CandidateDetails.aspx.cs" Inherits="Candidate_CandidateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <title>Candidate Details</title>
    <style type="text/css">
        .taglinks
        {
            display: block;
            background: #CDE2F6;
            border: 1px solid #BFDAF7;
            color: #036;
            font-size: 11px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 05px 10px 05px 4px;
            float: left;
            margin-right: 5px;
            margin-top: 10px;
        }
        .redselect
        {
            -webkit-appearance: button;
            -moz-appearance: button;
            appearance: button;
            display: inline-block;
            background: #FFD9D9;
            background: -webkit-linear-gradient(top,  #FFD9D9 0%,#FFD9D9 40%,#FFD9D9 100%);
            padding: 6px 30px 6px 15px;
            border-radius: 3px;
            border: 1px solid #aaa;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
            color: #444;
        }
        
        
        .select
        {
            -webkit-appearance: button;
            -moz-appearance: button;
            appearance: button;
            display: inline-block;
            background: #fafafa;
            background: -webkit-linear-gradient(top,  #fafafa 0%,#f4f4f4 40%,#e5e5e5 100%);
            padding: 6px 30px 6px 15px;
            border-radius: 3px;
            border: 1px solid #aaa;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
            color: #444;
        }
        
        .select:focus
        {
            outline: none;
        }
        
        .select-arrow
        {
            background-color: Black;
            display: inline-block;
            position: absolute;
            margin: .9em 0 0 -1.2em;
            border-left: 5px solid;
            border-right: 5px solid;
            border-top: 5px solid #777;
        }
        
        .chkbox INPUT
        {
            color: black;
            border-style: none;
            font-family: Tahoma;
            font-size: 11px;
            margin-right: 5px;
        }
        
        .mytd
        {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            border: 0px 0px 0px 0px;
            border-style: solid;
            border-width: 0px;
        }
        .mytable
        {
            margin: 0px;
            padding: 0px;
            border: 0px;
            width: 100px;
            cellspacing: 0px;
            cellpadding: 0px;
        }
        .layer1
        {
            margin: 0;
            padding: 0;
        }
        
        .heading
        {
            border: 1px solid #CCCCCC;
            background: url(/assets/images/graGradiant1.jpg) 50% 50% repeat-x;
            font-weight: normal;
            color: #555555;
            display: block;
            cursor: pointer;
            margin-top: 2px;
            padding: .5em .5em .5em .7em;
            min-height: 0;
            display: block;
            font-size: 1.17em;
            -webkit-margin-before: .5em;
            -webkit-margin-after: .5em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
            font-weight: bold;
            height: 20px;
            -khtml-border-radius: 4px 4px 4px 4px;
            -moz-border-radius: 4px 4px 4px 4px;
            -ms-border-radius: 4px 4px 4px 4px;
            -o-border-radius: 4px 4px 4px 4px;
            -webkit-border-radius: 4px 4px 4px 4px;
            border-radius: 4px 4px 4px 4px;
        }
        .content
        {
            background-color: #fafafa;
        }
        p
        {
            padding: 5px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <script type="text/javascript" src="/assets/js/stayontop.js">  
    </script>
    <script type="text/javascript">
        function isNumberKey(event) {

            var charCode = (event.which) ? event.which : event.keyCode
            var isnumeric = false;

            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 110)
                isnumeric = true;
            if (charCode == 9)
                isnumeric = true;
            if (charCode == 190)
                isnumeric = true;
            if (charCode >= 37 && charCode <= 40)
                isnumeric = true;
            if (charCode >= 96 && charCode <= 105)
                isnumeric = true;

            return isnumeric;

        }
        function validateControls() {

            var iscity = Page_ClientValidate('city');
            var isshift = Page_ClientValidate('shift');
            var rvalue = true;


            if (!iscity && !isshift) {
                document.getElementById('<%= ddlCity.ClientID %>').className = "redselect";
                document.getElementById('<%= ddlshift.ClientID %>').className = "redselect";
                rvalue = false;
            }
            else
                if (!iscity) {
                    document.getElementById('<%= ddlCity.ClientID %>').className = "redselect";
                    document.getElementById('<%= ddlshift.ClientID %>').className = "select";
                    rvalue = false;
                }
                else
                    if (!isshift) {
                        document.getElementById('<%= ddlshift.ClientID %>').className = "redselect";
                        document.getElementById('<%= ddlCity.ClientID %>').className = "select";
                        rvalue = false;
                    }



            return rvalue;
        }

        function showHideobj(obj, obj1, obj2) {

            var div = document.getElementById(obj);
            if (div.style.display == 'none') {
                div.style.display = '';
                document.getElementById(obj1).style.display = '';
                document.getElementById(obj2).style.display = 'none';
            }
            else {
                div.style.display = 'none';
                document.getElementById(obj1).style.display = 'none';
                document.getElementById(obj2).style.display = '';
            }
        }


        function ShowCalender() {

            var lblJoiningDate = document.getElementById('<%=lblJoiningDateName.ClientID%>').innerHTML;
            var lnkChange = document.getElementById('<%=lnkChangeJoiningDate.ClientID%>').innerHTML;
            var bl = false;
            var date = Date.parse(lblJoiningDate);


            if (!isNaN(date) && lnkChange == "Change") {
                document.getElementById('<%=lnkChangeJoiningDate.ClientID%>').innerHTML = "Submit";
                document.getElementById('<%=lblJoiningDateName.ClientID%>').style.display = 'none';
                document.getElementById('<%=txtJoiningDate.ClientID%>').style.display = '';
                document.getElementById('<%=txtJoiningDate.ClientID%>').value = lblJoiningDate;
                document.getElementById('<%=img1.ClientID%>').style.display = '';
            }
            else if (isNaN(date) && lnkChange == "Change") {
                alert('You cannot Change the Joning Date right now.');
            }
            else if (ValidDate(document.getElementById('<%=txtJoiningDate.ClientID%>'))) {
                document.getElementById('<%=lnkChangeJoiningDate.ClientID%>').innerHTML = "Change";
                document.getElementById('<%=lblJoiningDateName.ClientID%>').style.display = '';
                document.getElementById('<%=txtJoiningDate.ClientID%>').style.display = 'none';
                document.getElementById('<%=img1.ClientID%>').style.display = 'none';



                bl = true;
            }
            return bl;
        }

        //        $(document).ready(function () {

        //            $('a.fancybox-close').live('click', function () { location.reload(); });
        //        });


        function Hide(tr, lnkhide, lnkshow) {

            document.getElementById(tr).style.display = "none";
            document.getElementById(lnkhide).style.display = "none";
            document.getElementById(lnkshow).style.display = "";
        }

        function Show(tr, lnkhide, lnkshow) {

            document.getElementById(tr).style.display = "";
            document.getElementById(lnkshow).style.display = "none";
            document.getElementById(lnkhide).style.display = "";
        }

        function ValidDate(id) {

            var txtExpectedDOJ = Date.parse(id.value);
            var currentdate = new Date();
            var bl = false;

            if (txtExpectedDOJ <= currentdate) {
                alert('Expected Date of Joining cannot be todays or lesser.');
            }
            else if (txtExpectedDOJ > currentdate) {
                bl = true;
            }

            //  if (bl) {
            // bl = Page_ClientValidate('AcceptCheck');
            //  }
            // if (bl) {
            // bl = Page_ClientValidate('AcceptCheckRA');
            //}
            return bl;

        }

        function ValidateInterview() {
            var isValid = false;
            var isPass = document.getElementById('<%=rdbPass.ClientID%>').checked;
            var isFail = document.getElementById('<%=rdbFail.ClientID%>').checked;
            if (isPass)
                isPass = Page_ClientValidate('CommentsCheck');
            ; if (isPass)
                isValid = Page_ClientValidate('CommentsCheckPass');
            else if (isFail)
                isValid = Page_ClientValidate('CommentsCheck');

            return isValid;
        }

        jQuery(document).ready(function () {
            jQuery(".content").show();
            //toggle the componenet with class msg_body
            jQuery(".heading").click(function () {
                jQuery(this).next(".content").slideToggle(500);

            });
        });

        function expandAll() {
            jQuery(".content").show();

        }
        function CollapsAll() {
            jQuery(".content").hide();

        }


        function Validate1() {
            var isValid = false;
            isValid = Page_ClientValidate('AcceptCheck');

            return isValid;
        }
                               
                          

    </script>
    <div id="container" class="contentarea" style="width: 1100px;">
        <asp:HiddenField ID="hdnCandidateCode" runat="server" />
        <div>
            <table width="100%" style="background: transparent; border: 0px">
                <tr>
                    <td id="examplediv" align="right" style="background: transparent; border: 0px">
                        <a href="javascript:;" onclick="expandAll();" id="lnkexpend">
                            <image id="imgexpand" src="/assets/images/expand.png" alt="" width="20px" height="20px"></image>
                        </a>&nbsp; |&nbsp; <a href="javascript:;" onclick="CollapsAll();" id="lnkCollaps">
                            <image id="imgexpand" src="/assets/images/collapse.png" alt="" width="20px" height="20px"></image>
                        </a>
                    </td>
                </tr>
            </table>
            <p class="heading">
                <image id="imgper" src="/assets/images/personal-detail-icon.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp; Personal Details</p>
            <div class="content">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg)">
                            <span id="divAction1" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditPersonal"
                                runat="server" class="openframelarge">
                                <img id="img22" src="/assets/images/edit.png" alt="" />
                                 </a> </span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="50%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="left" style="font-weight: bold; font-size: 20px; background-color: #F7F7F7;
                            padding-left: 20px;">
                            <label id="lblName" runat="server">
                            </label>
                            &nbsp;&nbsp;
                            <label id="lblstatus" runat="server" style="font-size: 15px; color: #808080; font-weight: bold;">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="15" style="width: 50%">
                            <img id="imgCandidatePic" alt="No Picture" runat="server" style="height: 340px; width: 100%;" />
                            <div style="background-image: url(/assets/images/fadebg.png)">
                                <a id="lnkbtnCV" causesvalidation="false" runat="server" target="_blank">
                                    <img id="imgCV" src="/assets/images/118.png" height="40" width="45px" alt="" />
                                </a>&nbsp;
                                <asp:HiddenField ID="hdnCVPath" runat="server" />
                                <a id="APortFile" runat="server" target="_blank">
                                    <img id="imgportURL" src="/assets/images/120.png" height="40" width="60px" alt="" />
                                </a>
                                <asp:HiddenField runat="server" ID="hdnpFileName" Value="0" />
                                &nbsp; <a runat="server" id="APortURL" target="_blank">
                                    <img id="imgport" src="/assets/images/117.png" height="35" width="60px" alt="" />
                                </a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Reference No.</b>
                        </td>
                        <td>
                            <label id="lblRefNo" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <b>CandidateID</b>
                        </td>
                        <td>
                            <label id="lblCandidateID" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Email_Address</b>
                        </td>
                        <td id="tdEmil" runat="server">
                            <label id="lblEmailAddress" runat="server">
                            </label>
                            <div style="float: right">
                                <asp:Label ID="lblemailverificationCode" runat="server"></asp:Label>&nbsp;
                                <asp:Image ID="imgEmailNotVerified" runat="server" ToolTip="Email is not verified..!!"
                                    ImageUrl="/assets/images/Exclamation-Mark.png" Width="25" Height="17" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Phone Number</b>
                        </td>
                        <td id="tdPhone" runat="server">
                            <label id="lblPhoneNumber" runat="server">
                            </label>
                            <div style="float: right">
                                <asp:Label ID="lblPhoneVerificationCode" runat="server"></asp:Label>&nbsp;
                                <asp:Image ID="imgPhoneNotVerified" runat="server" ToolTip="Phone Number is not verified..!!"
                                    ImageUrl="/assets/images/Exclamation-Mark.png" Width="25" Height="17" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Landline Number</b>
                        </td>
                        <td>
                            <asp:Label ID="lblLandline" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Date Of Birth</b>
                        </td>
                        <td>
                            <label id="lblDoB" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>NIC</b>
                        </td>
                        <td id="tdNic" runat="server">
                            <label id="lblNic" runat="server">
                            </label>
                            <div style="float: right">
                                <asp:Image ID="imgNICNotVerified" runat="server" ToolTip="Dublicate N.I.C..!!" ImageUrl="/assets/images/Exclamation-Mark.png"
                                    Width="25" Height="17" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Gender</b>
                        </td>
                        <td>
                            <label id="lblGender" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Religion</b>
                        </td>
                        <td>
                            <label id="lblReligion" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Marital Status</b>
                        </td>
                        <td>
                            <label id="lblMaritalStatus" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Nationality</b>
                        </td>
                        <td>
                            <label id="lblNationality" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Address</b>
                        </td>
                        <td>
                            <label id="lblAddress" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Shift Availibility</b>
                        </td>
                        <td>
                            <label id="lblAvailbilityShift" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Referral</b>
                        </td>
                        <td>
                            <label id="lblReferral" runat="server">
                            </label>
                        </td>
                    </tr>
                </table>
                <br />
                <table id="tblPersonalHistory" runat="server" width="80%" border="0" cellspacing="0"
                    cellpadding="0">
                    <tr id="trlPersonalHistory" style="background-color: #909090; cursor: pointer" onclick="showHideobj('trrpt','lnkHide','lnkShow');">
                        <td align="left" style="background: url(/assets/images/graEdit3.jpg)">
                            >&nbsp; <b>Add/Edit<span style="color: #0000FF"> History</span></b>
                        </td>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg)">
                            <a id="lnkHide" style="display: none">Hide</a> <a id="lnkShow" style="display: inline">
                                Show</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblCHmessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trrpt" style="display: none" clientidmode="Static">
                        <td colspan="2" style="margin: 0px; padding: 0px;">
                            <table>
                                <asp:Repeater ID="rptCandidatehistory" runat="server">
                                    <HeaderTemplate>
                                        <tr style="background-color: #999999">
                                            <th align="center">
                                                S.No
                                            </th>
                                            <th align="center">
                                                Name
                                            </th>
                                            <th align="center">
                                                Nationality
                                            </th>
                                            <th align="center">
                                                NIC
                                            </th>
                                            <th align="center">
                                                D.O.B
                                            </th>
                                            <th align="center">
                                                Religion
                                            </th>
                                            <th align="center">
                                                Edit By
                                            </th>
                                            <th align="center">
                                                Date
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="normal">
                                            <td align="center">
                                                <%#Container.ItemIndex +1 %>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Name")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Nationality")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("NIC")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("DOB")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Religion")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Edit By")%>
                                            </td>
                                            <td align="center">
                                                <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="grey">
                                            <td align="center">
                                                <%#Container.ItemIndex +1 %>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Name")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Nationality")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("NIC")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("DOB")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Religion")%>
                                            </td>
                                            <td align="center">
                                                <%#Eval("Edit By")%>
                                            </td>
                                            <td align="center">
                                                <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgper" src="/assets/images/App-Status.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp; Application Status <span id="divAction61" style="padding-left: 790px;" runat="server"
                    clientidmode="Static" visible="false"><a class="openframelarge" id="aAppHistory"
                        visible="false" runat="server">Multiple Application</a></span>
            </p>
            <div class="content">
                <table width="50%" border="0" cellspacing="0" cellpadding="0">
                    <tr id="trPhoneCode" runat="server" visible="false">
                        <td class="mytd" colspan="2">
                            <td class="mytd">
                                <label id="lblVeriCode" runat="server">
                                </label>
                            </td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">
                            <b>Current Status</b>
                        </td>
                        <td style="width: 85%" colspan="3">
                            <label id="lblCurrentStatus" runat="server">
                            </label>
                            <span id="divAction45" runat="server" visible="false" clientidmode="Static"><span
                                id="sSchedule" runat="server" style="display: none">(Press to <a id="aSchedule" runat="server"
                                    style="font-weight: bold"></a>)</span> </span>
                            <div style="float: right; vertical-align: middle">
                                <span id="divAction41" runat="server" visible="false" clientidmode="Static"><a id="aStatusChange"
                                    runat="server" class="openframe">
                                    <img id="imgchnagesta" alt="" src="/assets/images/edit.png"></img></a> </span>
                                &nbsp;</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">
                            <b>Profile</b>
                        </td>
                        <td style="width: 35%">
                            <label id="lblProfileName" runat="server">
                            </label>
                            <span id="divAction42" runat="server" visible="false" clientidmode="Static"><a id="aProfileChange"
                                class="openframe" runat="server">
                                <div style="float: right">
                                    <image id="imgchnagepro" alt="" src="/assets/images/edit.png"></image>
                                    &nbsp;</div>
                            </a></span>
                        </td>
                        <td id="trDomain" runat="server" style="width: 15%">
                            <b>Domain</b>
                        </td>
                        <td style="width: 35%">
                            <label id="lblDomain" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Requistion</b>
                        </td>
                        <td class="mytd">
                            <label id="lblRequisitionName" runat="server">
                            </label>
                            &nbsp;&nbsp;&nbsp; <span id="sShortlist" runat="server" style="display: none;">(Press
                                to
                                <asp:LinkButton ID="lnkShortlist" runat="server" OnClick="lnkShortlist_Click"></asp:LinkButton>)</span>
                            <span id="divAction43" runat="server" visible="false" clientidmode="Static"><a id="aRequisitionChange"
                                runat="server" class="openframe">
                                <div style="float: right">
                                    <image id="imgchnageReq" alt="" src="/assets/images/edit.png"></image>
                                    &nbsp;</div>
                            </a></span>
                        </td>
                        <td id="trSubDomain">
                            <b>Sub Domain</b>
                        </td>
                        <td class="mytd">
                            <label id="lblSubDomain" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mytd">
                            <b>Category</b>
                        </td>
                        <td class="mytd">
                            <label id="lblCategoryName" runat="server">
                            </label>
                        </td>
                        <td id="trGrade">
                            <b>Grade</b>
                        </td>
                        <td class="mytd">
                            <label id="lblGradeName" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mytd">
                            <b>Joining Date</b>
                        </td>
                        <td>
                            <label id="lblJoiningDateName" runat="server">
                            </label>
                            <input runat="server" type="text" id="txtJoiningDate" style="width: 120px; display: none;"
                                clientidmode="Static" readonly="readonly" /><img src="/assets/images/icons/calendericon.jpg"
                                    alt="" width="16" style="display: none;" height="16" id="img1" runat="server" />
                            <script type="text/javascript">
                                Calendar.setup({
                                    inputField: "txtJoiningDate",      // id of the input field
                                    ifFormat: "M dd, y",       // format of the input field
                                    //ifFormat       :    "y-M-dd",       // format of the input field
                                    //ifFormat       :    "M-dd-y",       // format of the input field
                                    button: '<%=img1.ClientID %>',   // trigger for the calendar (button ID)
                                    singleClick: true            // double-click mode
                                });
                            </script>
                            <div style="float: right">
                                <span id="divAction44" runat="server" visible="false" clientidmode="Static">
                                    <asp:LinkButton runat="server" ID="lnkChangeJoiningDate" OnClick="lnkChangeJoiningDate_Click"
                                        Text="Change" OnClientClick="javascript:return ShowCalender();"></asp:LinkButton>
                                </span>
                            </div>
                        </td>
                        <td id="trDesignation">
                            <b>Designation</b>
                        </td>
                        <td class="mytd">
                            <label id="lblDesignation" runat="server">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mytd">
                            <b>Organizational Visit</b>
                        </td>
                        <td class="mytd">
                            <label id="lblTour" runat="server">
                            </label>
                        </td>
                        <td id="trRA" runat="server">
                            <b>Reporting Authority</b>
                        </td>
                        <td class="mytd">
                            <label id="lblRA" runat="server">
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgper" src="/assets/images/professional-experience-icon.jpg" height="20px"
                    width="20px" alt=""></image>
                &nbsp; Professional Experience</p>
            <div class="content">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg)">
                            <span id="divAction2" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditProfessional"
                                runat="server" class="openframe">
                                <img id="img1" src="/assets/images/edit-add.png" alt="" />
                                </a></span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="80%" border="0" cellspacing="0" cellpadding="10">
                    <tbody>
                        <asp:Repeater ID="rptProfessionalExperience" runat="server">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th>
                                        S.No.
                                    </th>
                                    <th>
                                        Company
                                    </th>
                                    <th>
                                        Title
                                    </th>
                                    <th>
                                        Job Type
                                    </th>
                                    <th>
                                        Location
                                    </th>
                                    <th>
                                        Start Date
                                    </th>
                                    <th>
                                        End Date
                                    </th>
                                    <th>
                                        Responsiblities
                                    </th>
                                    <th>
                                        Current Salary
                                    </th>
                                    <th>
                                        Initial Salary
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td align="center">
                                        <%#Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Company")%>
                                    </td>
                                    <td>
                                        <%# Eval("Position_Title")%>
                                    </td>
                                    <td>
                                        <%#Eval("Is_Permanent") %>
                                    </td>
                                    <td>
                                        <%# Eval("City")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("jobStart_Date")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("jobEnd_Date")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("Responsibilties_Included")%>
                                    </td>
                                    <td>
                                        <%# Eval("Current_Salary")%>
                                    </td>
                                    <td>
                                        <%# Eval("Initial_Salary")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td align="center">
                                        <%#Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Company")%>
                                    </td>
                                    <td>
                                        <%# Eval("Position_Title")%>
                                    </td>
                                    <td>
                                        <%#Eval("Is_Permanent") %>
                                    </td>
                                    <td>
                                        <%# Eval("City")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("jobStart_Date")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("jobEnd_Date")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("Responsibilties_Included")%>
                                    </td>
                                    <td>
                                        <%# Eval("Current_Salary")%>
                                    </td>
                                    <td>
                                        <%# Eval("Initial_Salary")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <br />
                <table id="tblProfessionalHistory" runat="server" width="80%" border="0" cellspacing="0"
                    cellpadding="0">
                    <tr style="background-color: #909090; cursor: pointer" onclick="showHideobj('trExHistory','lnkExHide','lnkExShow');">
                        <td align="left" style="background: url(/assets/images/graEdit3.jpg)">
                            >&nbsp; <b>Add/Edit<span style="color: #0000FF"> History</span></b>
                        </td>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg)">
                            <a id="lnkExHide" style="display: none">Hide</a> <a id="lnkExShow" style="display: inline">
                                Show</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblCEHMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trExHistory" style="display: none" clientidmode="Static">
                        <td colspan="2" style="margin: 0px; padding: 0px;">
                            <table>
                                <asp:Repeater ID="rptCandidateExHistory" runat="server">
                                    <HeaderTemplate>
                                        <tr style="background-color: #999999">
                                            <th>
                                                S.No
                                            </th>
                                            <th>
                                                Company
                                            </th>
                                            <th>
                                                City
                                            </th>
                                            <th>
                                                Position
                                            </th>
                                            <th>
                                                Start Date
                                            </th>
                                            <th>
                                                End Date
                                            </th>
                                            <th>
                                               Current Salary
                                            </th>
                                            <th>
                                                Initial Salary
                                            </th>
                                            <th>
                                                Updated By
                                            </th>
                                            <th>
                                                Updated Date
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="normal">
                                            <td align="center">
                                                <%#Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <%# Eval("Company")%>
                                            </td>
                                            <td>
                                                <%# Eval("City")%>
                                            </td>
                                            <td>
                                                <%# Eval("Position_Title")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "jobStart_Date", "{0:MMM dd, yyyy}")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "JobEndDate", "{0:MMM dd, yyyy}")%>
                                            </td>
                                            <td>
                                                <%# Eval("Current_Salary")%>
                                            </td>
                                            <td>
                                                <%# Eval("Initial_Salary")%>
                                            </td>
                                            <td>
                                                <%# Eval("Edit_By")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "LastUpdated_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="grey">
                                            <td align="center">
                                                <%#Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <%# Eval("Company")%>
                                            </td>
                                            <td>
                                                <%# Eval("City")%>
                                            </td>
                                            <td>
                                                <%# Eval("Position_Title")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "jobStart_Date", "{0:MMM dd, yyyy}")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "JobEndDate", "{0:MMM dd, yyyy}")%>
                                            </td>
                                            <td>
                                                <%# Eval("Current_Salary")%>
                                            </td>
                                            <td>
                                                <%# Eval("Initial_Salary")%>
                                            </td>
                                            <td>
                                                <%# Eval("Edit_By")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "LastUpdated_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgeducation" src="/assets/images/EducationIcon-icon.png" height="20px"
                    width="20px" alt=""></image>
                &nbsp; Educational Qualification</p>
            <div class="content">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" style="background: url(/assets/images/graEdit3.jpg); border-style: none">
                            <b>Educational Document(s)</b>
                        </td>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg); border-style: none">
                            <span id="divAction3" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditEducational"
                                runat="server" class="openframe">
                                <img id="img1" src="/assets/images/edit-add.png" alt="" />
                                </a></span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="10">
                    <tbody>
                        <asp:Repeater ID="rptEduQualification" runat="server">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th style="width: 2%">
                                        S.No.
                                    </th>
                                    <th style="width: 20%">
                                        Institute
                                    </th>
                                    <th style="width: 10%">
                                        Degree
                                    </th>
                                    <th>
                                        Board
                                    </th>
                                    <th style="width: 14%">
                                        Program
                                    </th>
                                    <th style="width: 14%">
                                        Major
                                    </th>
                                    <th style="width: 10%">
                                        Grade
                                    </th>
                                    <th style="width: 10%">
                                        Activities
                                    </th>
                                    <th style="width: 10%">
                                        Start Date
                                    </th>
                                    <th style="width: 10%">
                                        End Date
                                    </th>
                                <%--    <th style="width: 2%">
                                        Current Studying
                                    </th>--%>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td align="center">
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("Board")%>
                                    </td>
                                    <td>
                                        <%# Eval("Program_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Major_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Grade")%>
                                    </td>
                                    <td>
                                        <%# Eval("Activities")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("End_Date")%>
                                    </td>
                               <%--     <td align="center">
                                        <%# Eval("EducationStatus_Code")%>
                                    </td>--%>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td align="center">
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("Board")%>
                                    </td>
                                    <td>
                                        <%# Eval("Program_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Major_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Grade")%>
                                    </td>
                                    <td>
                                        <%# Eval("Activities")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("End_Date")%>
                                    </td>
                                 <%--   <td align="center">
                                        <%# Eval("EducationStatus_Code")%>
                                    </td>--%>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <br />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" style="background: url(/assets/images/graEdit3.jpg); border-style: none">
                            <b>Diploma(s)</b>
                        </td>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg); border-style: none">
                            <span id="divAction29" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditDiploma"
                                runat="server" class="openframe">
                                <img id="img1" src="/assets/images/edit-add.png" alt="" />
                                </a> </span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="10">
                    <tbody>
                        <asp:Repeater ID="rptDiploma" runat="server">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th style="width: 2%">
                                        S.No.
                                    </th>
                                    <th style="width: 20%">
                                        Institute
                                    </th>
                                    <th style="width: 10%">
                                        Title
                                    </th>
                                    <th style="width: 14%">
                                        Field of study
                                    </th>
                                    <th style="width: 10%">
                                        Start Date
                                    </th>
                                    <th style="width: 10%">
                                        End Date
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td align="center">
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("field")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("End_Date")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td align="center">
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("field")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("End_Date")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <br />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" style="background: url(/assets/images/graEdit3.jpg); border-style: none">
                            <b>Certificate(s)</b>
                        </td>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg); border-style: none">
                            <span id="divAction30" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditCertificate"
                                runat="server" class="openframe">
                                <img id="img1" src="/assets/images/edit-add.png" alt="" />
                               </a> </span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="10">
                    <tbody>
                        <asp:Repeater ID="rptCertificate" runat="server">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th style="width: 2%">
                                        S.No.
                                    </th>
                                    <th style="width: 20%">
                                        Institute
                                    </th>
                                    <th style="width: 10%">
                                        Title
                                    </th>
                                    <th style="width: 14%">
                                        Field of study
                                    </th>
                                    <th style="width: 10%">
                                        Start Date
                                    </th>
                                    <th style="width: 10%">
                                        End Date
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td align="center">
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("field")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("End_Date")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td align="center">
                                        <%# Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Institute")%>
                                    </td>
                                    <td>
                                        <%# Eval("Degree")%>
                                    </td>
                                    <td>
                                        <%# Eval("field")%>
                                    </td>
                                    <td>
                                        <%# Eval("Start_Date")%>
                                    </td>
                                    <td>
                                        <%# Eval("End_Date")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <br />
                <table id="tblEduHistory" runat="server" width="80%" border="0" cellspacing="0" cellpadding="0">
                    <tr style="background-color: #909090; cursor: pointer" onclick="showHideobj('trQaHistory','lnkQaHide','lnkQaShow');">
                        <td align="left" style="background: url(/assets/images/graEdit3.jpg); margin: 0px;
                            padding">
                            >&nbsp; <b>Add/Edit<span style="color: #0000FF"> History</span></b>
                            <div style="float: right">
                                <a id="lnkQaHide" style="display: none">Hide</a> <a id="lnkQaShow" style="display: inline">
                                    Show</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblQaMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trQaHistory" style="display: none" clientidmode="Static">
                        <td style="margin: 0px; padding: 0px;">
                            <table>
                                <asp:Repeater ID="rptQaHistory" runat="server">
                                    <HeaderTemplate>
                                        <tr style="background-color: #999999">
                                            <th style="width: 20%">
                                                Institute
                                            </th>
                                            <th>
                                                Degree
                                            </th>
                                            <th>
                                                Program_Name
                                            </th>
                                            <th>
                                                Major_Name
                                            </th>
                                            <th>
                                                Start_Date
                                            </th>
                                            <th>
                                                EndDate
                                            </th>
                                            <th>
                                                Grade
                                            </th>
                                            <th>
                                                Position
                                            </th>
                                            <th>
                                                Activities
                                            </th>
                                            <th>
                                                UserType
                                            </th>
                                            <th style="width: 10%">
                                                Date
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="normal">
                                            <td>
                                                <%# Eval("Institute")%>
                                            </td>
                                            <td>
                                                <%# Eval("Degree")%>
                                            </td>
                                            <td>
                                                <%# Eval("Program_Name")%>
                                            </td>
                                            <td>
                                                <%# Eval("Major_Name")%>
                                            </td>
                                            <td>
                                                <%# Eval("Start_Date")%>
                                            </td>
                                            <td>
                                                <%# Eval("EndDate")%>
                                            </td>
                                            <td>
                                                <%# Eval("Grade")%>
                                            </td>
                                            <td>
                                                <%# Eval("Position")%>
                                            </td>
                                            <td>
                                                <%# Eval("Activities")%>
                                            </td>
                                            <td>
                                                <%# Eval("UserType")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="grey">
                                            <td>
                                                <%# Eval("Institute")%>
                                            </td>
                                            <td>
                                                <%# Eval("Degree")%>
                                            </td>
                                            <td>
                                                <%# Eval("Program_Name")%>
                                            </td>
                                            <td>
                                                <%# Eval("Major_Name")%>
                                            </td>
                                            <td>
                                                <%# Eval("Start_Date")%>
                                            </td>
                                            <td>
                                                <%# Eval("EndDate")%>
                                            </td>
                                            <td>
                                                <%# Eval("Grade")%>
                                            </td>
                                            <td>
                                                <%# Eval("Position")%>
                                            </td>
                                            <td>
                                                <%# Eval("Activities")%>
                                            </td>
                                            <td>
                                                <%# Eval("UserType")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgskill" src="/assets/images/Skillset-icon.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp; Skill Set</p>
            <div class="content">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg);">
                            <span id="divAction4" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditSkillSet"
                                runat="server" class="openframe">
                                <img id="img21" src="/assets/images/edit-add.png" alt="" />
                                </a></span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td>
                            <asp:Repeater ID="rptSkills" runat="server" ClientIDMode="Static">
                                <ItemTemplate>
                                    <span class="taglinks">
                                        <%# Eval("Skill")%>
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgdocs" src="/assets/images/documents-icon.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp;Uploaded Documents <span id="divAction52" style="padding-left: 790px;" runat="server"
                    clientidmode="Static" visible="false"><a class="openframelarge" id="aDocVerification"
                        visible="false" runat="server">Document Verification</a></span>
            </p>
            <div class="content">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg)">
                            <span id="divAction5" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditDocuments"
                                runat="server" class="openframe">
                                <img id="img1" src="/assets/images/edit-add.png" alt="" />
                               </a> </span>&nbsp;
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td style="font-weight: bold; background: url(/assets/images/graEdit3.jpg)">
                                    Personal Documents
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <asp:Repeater ID="rptPersonal" runat="server" OnItemDataBound="rptPersonal_ItemDataBound"
                                            OnItemCommand="rptPersonal_ItemCommand">
                                            <HeaderTemplate>
                                                <tr style="background-color: #dddddd">
                                                    <th style="width: 2%">
                                                        S.No.
                                                    </th>
                                                    <th style="width: 28%">
                                                        Document Name
                                                    </th>
                                                    <th style="width: 20%">
                                                        Document Type
                                                    </th>
                                                    <th style="width: 30%">
                                                        Document From
                                                    </th>
                                                    <th style="width: 10%">
                                                        View
                                                    </th>
                                                    <th id="thPersonalAction" runat="server" style="display: none; width: 9%">
                                                        Action
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="normal" align="center">
                                                    <td>
                                                        <%# Container.ItemIndex +1 %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Document_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DocType_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CandidateDocumentName") %>
                                                    </td>
                                                    <td>
                                                        <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                            title="Click here to View Document">
                                                            <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                                Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                        <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                            Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                            ToolTip="No file Browsed." />
                                                    </td>
                                                    <td id="tdPersonalAction" runat="server" style="display: none;">
                                                        <span id="divAction53" runat="server" visible="false" clientidmode="Static">
                                                            <asp:LinkButton ID="lnkMarkVerified" Text="Mark Verified" runat="server" CommandName="MarkDocVerified"
                                                                CommandArgument='<%# Eval("CandDoc_Code")%>' ToolTip="Click here If Document is verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? false : true  %>' />
                                                            <asp:Image ID="imgChecked" runat="server" ImageUrl="/assets/images/1.gif" ToolTip="Document already verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? true : false  %>' /></span>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="grey" align="center">
                                                    <td>
                                                        <%# Container.ItemIndex +1 %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Document_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DocType_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CandidateDocumentName") %>
                                                    </td>
                                                    <td>
                                                        <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                            title="Click here to View Document">
                                                            <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                                Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                        <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                            Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                            ToolTip="No file Browsed." />
                                                    </td>
                                                    <td id="tdPersonalAction" runat="server" style="display: none;">
                                                        <span id="divAction53" runat="server" visible="false" clientidmode="Static">
                                                            <asp:LinkButton ID="lnkMarkVerified" Text="Mark Verified" runat="server" CommandName="MarkDocVerified"
                                                                CommandArgument='<%# Eval("CandDoc_Code")%>' ToolTip="Click here If Document is verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? false : true  %>' />
                                                            <asp:Image ID="imgChecked" runat="server" ImageUrl="/assets/images/1.gif" ToolTip="Document already verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? true : false  %>' /></span>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                    <div style="text-align: center">
                                        <asp:Label ID="lblemtypersonal" runat="server" ForeColor="Red"></asp:Label>
                                        <br />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; background: url(/assets/images/graEdit3.jpg)">
                                    Educational Documents
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <asp:Repeater ID="rptEducational" runat="server" OnItemDataBound="rptEducational_ItemDataBound"
                                            OnItemCommand="rptEducational_ItemCommand">
                                            <HeaderTemplate>
                                                <tr style="background-color: #dddddd">
                                                    <th style="width: 2%">
                                                        S.No.
                                                    </th>
                                                    <th style="width: 28%">
                                                        Document Name
                                                    </th>
                                                    <th style="width: 20%">
                                                        Document Type
                                                    </th>
                                                    <th style="width: 30%">
                                                        Document From
                                                    </th>
                                                    <th style="width: 10%">
                                                        View
                                                    </th>
                                                    <th id="thEduAction" runat="server" style="display: none;">
                                                        Action
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="normal" align="center">
                                                    <td>
                                                        <%# Container.ItemIndex +1 %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Document_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DocType_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CandidateDocumentName") %>
                                                    </td>
                                                    <td>
                                                        <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                            title="Click here to View Document">
                                                            <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                                Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                        <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                            Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                            ToolTip="No file Browsed." />
                                                    </td>
                                                    <td id="tdEduAction" runat="server" style="display: none;">
                                                        <span id="divAction53" runat="server" visible="false" clientidmode="Static">
                                                            <asp:LinkButton ID="lnkMarkVerified" Text="Mark Verified" runat="server" CommandName="MarkDocVerified"
                                                                CommandArgument='<%# Eval("CandDoc_Code")%>' ToolTip="Click here If Document is verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? false : true  %>' />
                                                            <asp:Image ID="imgChecked" runat="server" ImageUrl="/assets/images/1.gif" ToolTip="Document already verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? true : false  %>' /></span>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="grey" align="center">
                                                    <td>
                                                        <%# Container.ItemIndex +1 %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Document_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DocType_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CandidateDocumentName") %>
                                                    </td>
                                                    <td>
                                                        <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                            title="Click here to View Document">
                                                            <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                                Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                        <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                            Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                            ToolTip="No file Browsed." />
                                                    </td>
                                                    <td id="tdEduAction" runat="server" style="display: none;">
                                                        <span id="divAction53" runat="server" visible="false" clientidmode="Static">
                                                            <asp:LinkButton ID="lnkMarkVerified" Text="Mark Verified" runat="server" CommandName="MarkDocVerified"
                                                                CommandArgument='<%# Eval("CandDoc_Code")%>' ToolTip="Click here If Document is verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? false : true  %>' />
                                                            <asp:Image ID="imgChecked" runat="server" ImageUrl="/assets/images/1.gif" ToolTip="Document already verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? true : false  %>' /></span>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                    <div style="text-align: center">
                                        <asp:Label ID="lblemtyEducational" runat="server" ForeColor="Red"></asp:Label>
                                        <br />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; background: url(/assets/images/graEdit3.jpg)">
                                    Professional Documents
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <asp:Repeater ID="rptProfessional" runat="server" OnItemDataBound="rptProfessional_ItemDataBound"
                                            OnItemCommand="rptProfessional_ItemCommand">
                                            <HeaderTemplate>
                                                <tr style="background-color: #dddddd">
                                                    <th style="width: 2%">
                                                        S.No.
                                                    </th>
                                                    <th style="width: 28%">
                                                        Document Name
                                                    </th>
                                                    <th style="width: 20%">
                                                        Document Type
                                                    </th>
                                                    <th style="width: 30%">
                                                        Document From
                                                    </th>
                                                    <th style="width: 10%">
                                                        View
                                                    </th>
                                                    <th id="thProfAction" runat="server" style="display: none;">
                                                        Action
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="normal" align="center">
                                                    <td>
                                                        <%# Container.ItemIndex +1 %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Document_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DocType_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CandidateDocumentName") %>
                                                    </td>
                                                    <td>
                                                        <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                            title="Click here to View Document">
                                                            <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                                Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                        <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                            Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                            ToolTip="No file Browsed." />
                                                    </td>
                                                    <td id="tDProfAction" runat="server" style="display: none;">
                                                        <span id="divAction53" runat="server" visible="false" clientidmode="Static">
                                                            <asp:LinkButton ID="lnkMarkVerified" Text="Mark Verified" runat="server" CommandName="MarkDocVerified"
                                                                CommandArgument='<%# Eval("CandDoc_Code")%>' ToolTip="Click here If Document is verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? false : true  %>' />
                                                            <asp:Image ID="imgChecked" runat="server" ImageUrl="/assets/images/1.gif" ToolTip="Document already verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? true : false  %>' /></span>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="grey" align="center">
                                                    <td>
                                                        <%# Container.ItemIndex +1 %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Document_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DocType_Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CandidateDocumentName") %>
                                                    </td>
                                                    <td>
                                                        <a id="aViewPersonal" runat="server" target="_blank" href='<%#Eval("DocumentPath") %>'
                                                            title="Click here to View Document">
                                                            <asp:Image runat="server" ID="imgView" alt="" src="/assets/images/document-save.png"
                                                                Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? true : false  %>' /></a>
                                                        <asp:Image runat="server" ID="Image1" alt="" src="/assets/images/Icon_attention.png"
                                                            Height="30px" Width="35px" Visible='<%# ((bool)Eval("Is_Browsed")) == true ? false : true  %>'
                                                            ToolTip="No file Browsed." />
                                                    </td>
                                                    <td id="tDProfAction" runat="server" style="display: none;">
                                                        <span id="divAction53" runat="server" visible="false" clientidmode="Static">
                                                            <asp:LinkButton ID="lnkMarkVerified" Text="Mark Verified" runat="server" CommandName="MarkDocVerified"
                                                                CommandArgument='<%# Eval("CandDoc_Code")%>' ToolTip="Click here If Document is verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? false : true  %>' />
                                                            <asp:Image ID="imgChecked" runat="server" ImageUrl="/assets/images/1.gif" ToolTip="Document already verified."
                                                                Visible='<%# ((bool)Eval("Is_Verified")) == true ? true : false  %>' /></span>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                    <div style="text-align: center">
                                        <asp:Label ID="lblemtyProfessional" runat="server" ForeColor="Red"></asp:Label>
                                        <br />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <p class="heading">
                <image id="imgsfam" src="/assets/images/family-icon.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp; Family Details</p>
            <div class="content">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td align="right" style="background: url(/assets/images/graEdit3.jpg)">
                            <span id="divAction6" runat="server" visible="false" clientidmode="Static"><a id="lnkAddEditFamily"
                                runat="server" class="openframe">
                                <img id="img3" src="/assets/images/edit-add.png" alt="" />
                               </a></span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="80%" border="0" cellspacing="0" cellpadding="10">
                    <tbody>
                        <asp:Repeater ID="rptFamily" runat="server">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th style="width: 2%">
                                        S.No.
                                    </th>
                                    <th>
                                        Relation
                                    </th>
                                    <th style="width: 30%">
                                        Member Name
                                    </th>
                                    <th style="width: 15%">
                                        Date Of Birth
                                    </th>
                                    <th style="width: 5%">
                                        Age
                                    </th>
                                    <th style="width: 25%">
                                        Qualification
                                    </th>
                                    <th style="width: 25%">
                                        Company/Institute
                                    </th>
                                    <th style="width: 25%">
                                        Occupation
                                    </th>
                                    <th style="width: 25%">
                                        Designation
                                    </th>
                                    <th style="width: 25%">
                                        Monthly Income
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td align="center">
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Relation_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Member_Name")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("DateOfBirth")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("MemberAge")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Qualification")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Company_Name")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Occupation")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Designation")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("MonthlyIncome")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td align="center">
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <%# Eval("Relation_Name")%>
                                    </td>
                                    <td>
                                        <%# Eval("Member_Name")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("DateOfBirth")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("MemberAge")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Qualification")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Company_Name")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Occupation")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("Designation")%>
                                    </td>
                                    <td nowrap="nowrap">
                                        <%# Eval("MonthlyIncome")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table width="80%" border="0" cellspacing="0" cellpadding="10">
                    <tr>
                        <td>
                            <asp:Label ID="lblMsgfamily" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgsresult" src="/assets/images/result-icon.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp; Test Results</p>
            <div class="content">
                <table id="tblTest" runat="server" style="padding: 0px; margin: 0px; width: 100%">
                    <tr>
                        <td style="padding: 0px; margin: 0px; width: 100%">
                            <asp:Repeater ID="rptQuestionGroup" OnItemDataBound="rptQuestionGroup_ItemDataBound"
                                runat="server">
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="6" align="center">
                                                <strong style="font-size: 14px">Section Summary </strong>
                                            </td>
                                        </tr>
                                        <tr class="grey">
                                            <td align="center">
                                                <strong>S.No </strong>
                                            </td>
                                            <td>
                                                <strong>Name </strong>
                                            </td>
                                            <td align="center">
                                                <strong>Correct </strong>
                                            </td>
                                            <td align="center">
                                                <strong>Wrong </strong>
                                            </td>
                                            <td align="center">
                                                <strong>Pending </strong>
                                            </td>
                                            <td align="center">
                                                <strong>Total </strong>
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdfQuestionGroupCode" runat="server" Value='<%#Eval("QuestionGroupCode") %>'>
                                            </asp:HiddenField>
                                            <asp:HiddenField ID="hdfSectionCode" runat="server" Value='<%#Eval("SectionCode") %>'>
                                            </asp:HiddenField>
                                            <asp:Label runat="server" Text='<%#Eval("QuestionGroupName") %>' ID="lblSection"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblCorrect"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblWrong"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblPending"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblTotal"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="grey">
                                        <td align="center">
                                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdfQuestionGroupCode" runat="server" Value='<%#Eval("QuestionGroupCode") %>'>
                                            </asp:HiddenField>
                                            <asp:HiddenField ID="hdfSectionCode" runat="server" Value='<%#Eval("SectionCode") %>'>
                                            </asp:HiddenField>
                                            <asp:Label runat="server" Text='<%#Eval("QuestionGroupName") %>' ID="lblSection"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblCorrect"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblWrong"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblPending"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lblTotal"></asp:Label>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <strong>Total</strong>
                                        </td>
                                        </td>
                                        <td align="center">
                                            <strong>
                                                <asp:Label runat="server" ID="lblCorrecttot"></asp:Label></strong>
                                        </td>
                                        <td align="center">
                                            <strong>
                                                <asp:Label runat="server" ID="lblWrongtot"></asp:Label></strong>
                                        </td>
                                        <td align="center">
                                            <strong>
                                                <asp:Label runat="server" ID="lblPendingtot"></asp:Label></strong>
                                        </td>
                                        <td align="center">
                                            <strong>
                                                <asp:Label runat="server" ID="lblTotaltot"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span id="divAction46" runat="server" visible="false" clientidmode="Static">
                                <image id="img23" src="/assets/images/ToDoListIcon.jpg" alt="" height="15px" width="15px"></image>
                                <a id="alnkChktest" runat="server" target="_blank">View Test</a></span>&nbsp;
                        </td>
                    </tr>
                </table>
                <table width="1000%" border="0" cellspacing="0" cellpadding="0" id="tblTestmsg" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="lblMsgTest" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgsresul1t" src="/assets/images/Document-scheduled-tasks-icon.png" height="20px"
                    width="20px" alt=""></image>
                &nbsp; Scheduled Activities</p>
            <div class="content">
                <table id="tblScheduleActivity" runat="server">
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <asp:Repeater ID="rptScheduleHistory" runat="server" OnItemDataBound="rptScheduleHistory_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr class="grey" style="width: 3%">
                                            <td align="center">
                                                <strong>S.No.</strong>
                                            </td>
                                            <td align="center">
                                                <strong>Date</strong>
                                            </td>
                                            <td align="center">
                                                <strong>Time</strong>
                                            </td>
                                            <td align="center">
                                                <strong>Venue</strong>
                                            </td>
                                            <td align="center">
                                                <strong>Seat No.</strong>
                                            </td>
                                            <td align="center">
                                                <strong>Status</strong>
                                            </td>
                                            <td align="center">
                                                <strong>Panel</strong>
                                            </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <%# Container.ItemIndex+1 %>
                                            </td>
                                            <td align="center">
                                                <%# Eval("Date")%>
                                            </td>
                                            <td align="center" style="width: 15%">
                                                <asp:HiddenField ID="hdnRSCode" runat="server" Value='<%# Eval("RSCode") %>' />
                                                <%# Eval("Time")%>
                                            </td>
                                            <td align="center">
                                                <%# Eval("Venue") %>
                                            </td>
                                            <td align="center" style="width: 15%">
                                                <%# Eval("Seat") %>
                                            </td>
                                            <td align="center">
                                                <%# Eval("StatusName")%>
                                            </td>
                                            <td align="center">
                                                <a id="aShow" href="javascript:;" runat="server">
                                                    <asp:Label ID="lblShow" runat="server" Text="Show"></asp:Label></a> <a id="aHide"
                                                        href="javascript:;" runat="server" style="display: none">
                                                        <asp:Label ID="lblHide" runat="server" Text="Hide"></asp:Label>
                                                    </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="7" style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px">
                                                <table id="tblChild" runat="server" width="100%" cellpadding="0" cellspacing="0"
                                                    style="display: none">
                                                    <tr>
                                                        <td style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px">
                                                            <asp:Repeater ID="rptScheduledChild" runat="server">
                                                                <HeaderTemplate>
                                                                    <tr>
                                                                        <th style="width: 4%" align="center">
                                                                            <strong>S.No.</strong>
                                                                        </th>
                                                                        <th style="width: 32%">
                                                                            <strong>Name</strong>
                                                                        </th>
                                                                        <th style="width: 32%" align="center">
                                                                            <strong>Department</strong>
                                                                        </th>
                                                                        <th style="width: 32%" align="center">
                                                                            <strong>Designation</strong>
                                                                        </th>
                                                                    </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <%# Container.ItemIndex+1 %>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%# Eval("Name") %>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%# Eval("Department") %>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%# Eval("JobTitle")%>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="grey">
                                            <td align="center">
                                                <%# Container.ItemIndex+1 %>
                                            </td>
                                            <td align="center">
                                                <%# Eval("Date")%>
                                            </td>
                                            <td align="center" style="width: 15%">
                                                <asp:HiddenField ID="hdnRSCode" runat="server" Value='<%# Eval("RSCode") %>' />
                                                <%# Eval("Time")%>
                                            </td>
                                            <td align="center">
                                                <%# Eval("Venue") %>
                                            </td>
                                            <td align="center" style="width: 15%">
                                                <%# Eval("Seat") %>
                                            </td>
                                            <td align="center">
                                                <%# Eval("StatusName")%>
                                            </td>
                                            <td align="center">
                                                <a id="aShow" href="javascript:;" runat="server">
                                                    <asp:Label ID="lblShow" runat="server" Text="Show"></asp:Label></a> <a id="aHide"
                                                        href="javascript:;" runat="server" style="display: none">
                                                        <asp:Label ID="lblHide" runat="server" Text="Hide"></asp:Label>
                                                    </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="7" style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px">
                                                <table id="tblChild" runat="server" width="100%" cellpadding="0" cellspacing="0"
                                                    style="display: none">
                                                    <tr>
                                                        <td style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px">
                                                            <asp:Repeater ID="rptScheduledChild" runat="server">
                                                                <HeaderTemplate>
                                                                    <tr>
                                                                        <th style="width: 4%" align="center">
                                                                            <strong>S.No.</strong>
                                                                        </th>
                                                                        <th style="width: 32%">
                                                                            <strong>Name</strong>
                                                                        </th>
                                                                        <th style="width: 32%" align="center">
                                                                            <strong>Designation</strong>
                                                                        </th>
                                                                        <th style="width: 32%" align="center">
                                                                            <strong>Department</strong>
                                                                        </th>
                                                                    </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <%# Container.ItemIndex+1 %>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%# Eval("Name") %>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%# Eval("Department") %>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%# Eval("JobTitle")%>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <tr id="trempty" runat="server">
                                    <td colspan="6">
                                        <asp:Label ID="lblScheduledActivityEmpty" runat="server" Text="No record(s) found"
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgscommunication" src="/assets/images/communication-icon.png" height="20px"
                    width="20px" alt=""></image>
                &nbsp; Communication</p>
            <div class="content">
                <table width="80%" border="0" cellspacing="0" cellpadding="10">
                    <asp:Repeater ID="rptCommunication" runat="server" OnItemDataBound="rptCommunication_ItemDataBound">
                        <HeaderTemplate>
                            <tr class="grey">
                                <td style="width: 5%" align="center">
                                    <b>S.No.</b>
                                </td>
                                <td style="width: 10%" align="center">
                                    <b>Type</b>
                                </td>
                                <td align="center">
                                    <b>Comments</b>
                                </td>
                                <td align="center" style="width: 15%">
                                    <b>Communicator Name</b>
                                </td>
                                <td align="center" style="width: 10%">
                                    <b>Date</b>
                                </td>
                                <td align="center" style="width: 5%">
                                    <b>Status</b>
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="trCommunicationWayRecord" runat="server" class="center">
                                <td align="center">
                                    <%# Container.ItemIndex+1 %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%#Eval("CommunicationWay")%>
                                    </b>
                                    <asp:HiddenField ID="hdnCommCode" runat="server" Value='<%#Eval("CommunicationWayCode") %>' />
                                </td>
                                <td align="left">
                                    <%#Eval("Comments")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Fullname")%>
                                </td>
                                <td align="center">
                                    <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TestStatus")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id="trCommunicationWayRecord" runat="server" class="grey">
                                <td align="center">
                                    <%# Container.ItemIndex+1 %>
                                </td>
                                <td align="center">
                                    <b>
                                        <%#Eval("CommunicationWay")%>
                                    </b>
                                    <asp:HiddenField ID="hdnCommCode" runat="server" Value='<%#Eval("CommunicationWayCode") %>' />
                                </td>
                                <td align="left">
                                    <%#Eval("Comments")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Fullname")%>
                                </td>
                                <td align="center">
                                    <%# DataBinder.Eval(Container.DataItem, "Created_Date", "{0:MMM dd, yyyy hh:mm tt}")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TestStatus")%>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
                <table width="80%" border="0" cellspacing="0" cellpadding="10">
                    <tr>
                        <td>
                            <asp:Label ID="lblMsgCommu" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <p class="heading">
                <image id="imgsoffdoc" src="/assets/images/officialdoc-icon.png" height="20px" width="20px"
                    alt=""></image>
                &nbsp; Official Documents</p>
            <div class="content">
                <table width="50%" border="0" cellspacing="0" cellpadding="0">
                    <tr id="trOfferLetterAudio" runat="server" style="display: none;">
                        <td>
                            <asp:Image ID="Image5" runat="server" ImageUrl="/assets/images/bullet.gif" />
                            &nbsp; <a id="aOfferLetterAudio" runat="server">Offer Delivery Audio</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgbullet" runat="server" ImageUrl="/assets/images/bullet.gif" />
                            &nbsp; <a id="aOfferLetter" runat="server">Offer Letter</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="/assets/images/bullet.gif" />
                            &nbsp; <a id="aAppointmentLetter" runat="server">Appointment Letter</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="/assets/images/bullet.gif" />
                            &nbsp; <a id="aMedicalLetter" runat="server">Medical Letter</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image6" runat="server" ImageUrl="/assets/images/bullet.gif" />
                            &nbsp; <a id="aRemuneration" runat="server">Remuneration Sheet</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image4" runat="server" ImageUrl="/assets/images/bullet.gif" />
                            &nbsp; <a id="aDocCheckList" runat="server">Document Check List</a>
                        </td>
                    </tr>
                </table>
            </div>
            <p id="HActions" runat="server" class="heading">
                <img id="imgsaction" src="/assets/images/action-icon.png" height="20px" width="20px"
                    alt="" />
                &nbsp; Actions</p>
            <div class="content">
                <div id="divAction50" runat="server" visible="false" clientidmode="Static">
                    <table id="tblInterview" runat="server" width="80%" style="display: none">
                        <tr>
                            <td colspan="2">
                                <asp:RadioButton ID="rdbPass" Text="Mark Pass" runat="server" onclick="ShowHideGrade()"  GroupName="PassOrFail"
                                    Checked="true" />&nbsp;&nbsp;
                                <asp:RadioButton ID="rdbFail" Text="Mark Fail" runat="server" onclick="ShowHideGrade()"  GroupName="PassOrFail" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>Enter Interview Comments:</strong><br />
                                <textarea id="txtaComments" cols="50" rows="6" runat="server"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaComments"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                    Display="Dynamic" InitialValue="" ValidationGroup="CommentsCheck"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span id="divAction51" runat="server" visible="false" clientidmode="Static"><strong>
                                    Grade:</strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlGrade" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlGrade"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Grade is required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;&nbsp;<strong>Designation:</strong> 
                                    <asp:DropDownList ID="ddlDesignation" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlDesignation"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Designation is required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>
                                        &nbsp;&nbsp;
                                        <strong>Profile:</strong>
                                         <asp:DropDownList ID="ddlProfile" runat="server" Width="150px">
                                            <asp:ListItem Value="-1" Text="--Profile--"></asp:ListItem>                                                                                
                                            <asp:ListItem Value="0" Text="Fresh"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Experienced"></asp:ListItem>
                                         </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlProfile"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Profile is required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>


                                        <br /><br />
                                        <strong>Salary:</strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox runat="server" ID="txtDSalary" Width="110px" MaxLength="7" onkeydown="return isNumberKey(event);"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDSalary"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Salary is required!' />"
                                    Display="Dynamic" InitialValue="" ValidationGroup="CommentsCheck"></asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                    <strong>
                                    Bank Statement:</strong>
                                    <asp:DropDownList ID="ddlStatement" runat="server" Width="150px">
                                    <asp:ListItem Value="-1" Text="--Statement--"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Verified"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Not Verified"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlStatement"
                                        ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Statement Verification is required!' />"
                                        Display="Dynamic" InitialValue="-1" ValidationGroup="CommentsCheckPass"></asp:RequiredFieldValidator>

                                         
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSubmit_Click"
                                    OnClientClick="javascript:return ValidateInterview();">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Submit
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div width="100%" id="divAction47" runat="server" clientidmode="Static" visible="false">
                    <table id="tblOfferGenerationPending" runat="server" width="50%" style="display: none;">
                        <tr>
                            <td>
                                <strong>Enter Offer Generation Comments:</strong><br />
                                <textarea id="txtaOfferGenerationPending" cols="50" rows="6" runat="server"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtaOfferGenerationPending"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                    Display="Dynamic" InitialValue="" ValidationGroup="OfferPendingCheck"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lnkOfferGenerationPending" CssClass="btn-ora nl"
                                    OnClick="lnkOfferGenerationPending_Click" ValidationGroup="OfferPendingCheck">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Generated
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <table id="tblOfferGeneration" runat="server" width="50%" style="display: none;">
                    <tr id="trOfferGenerationReserve" runat="server">
                        <td>
                            Click here to <a id="AReserve" runat="server" class="openframe">Reserve</a> for
                            the Offer Letter.
                        </td>
                    </tr>
                    <tr id="trOfferGenerationReserved" runat="server">
                        <td>
                            <strong>Already Reserved</strong> for the Offer Letter.
                        </td>
                    </tr>
                </table>
                <div width="100%" id="divAction48" runat="server" clientidmode="Static" visible="false">
                    <table id="tblOfferDelivered" runat="server" width="50%" style="display: none;">
                        <tr>
                            <td>
                                <strong>Mark Offer delivered here :</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Enter Comments:</strong><br />
                                <textarea id="txtaOfferdelivered" cols="50" rows="6" runat="server"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaOfferdelivered"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                    Display="Dynamic" InitialValue="" ValidationGroup="OfferCheck"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkOfferLetter" CausesValidation="false" runat="server" OnClick="lnkOfferLetter_OnClick">View Offer Letter</asp:LinkButton>
                                <label id="lblNoOffer" runat="server" style="color: Red">
                                </label>
                                <asp:HiddenField ID="hdnOfferLetter" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="fuOffer" runat="server" Width="600px" />
                                <asp:RequiredFieldValidator ID="rfvOffer" runat="server" ControlToValidate="fuOffer"
                                    ErrorMessage="Please Select File to Upload" Font-Bold="True" ForeColor="Red"
                                    Text="<img src='/assets/Images/Exclamation.gif' title='File to Upload is required!' />"
                                    InitialValue="" Display="Dynamic" ValidationGroup="OfferCheck"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Select the Correct Format(mp3| flv| avi| wma| wmv| mpeg)"
                                    ValidationExpression="^.+(.flv|FLV|.avi|.AVI|.wma|.WMA|.wmv|.WMV|.mpeg|.MPEG|.mp3|.MP3)$"
                                    Display="Dynamic" ControlToValidate="fuOffer" ValidationGroup="OfferCheck" Text="<img src='/assets/Images/Exclamation.gif' title='Format(mp3) is required!' />"
                                    Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMsgOffer" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lnkMarkOfferDelivered" CssClass="btn-ora nl" OnClick="lnkMarkOfferDelivered_Click"
                                    ValidationGroup="OfferCheck">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Delivered
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div width="100%" id="divAction49" runat="server" clientidmode="Static" visible="false">
                    <table id="tblOfferAcceptance" runat="server" width="50%" style="display: none;">
                        <tr>
                            <td colspan="2">
                                <strong>Mark Offer accepetance here :</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>Enter Comments:</strong><br />
                                <textarea id="txtaOfferAccepetance" cols="50" rows="6" runat="server"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtaOfferAccepetance"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                    Display="Dynamic" InitialValue="" ValidationGroup="AcceptCheck"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Excepted Date Of Joining:</strong>&nbsp;&nbsp;
                                <input runat="server" type="text" id="txtExpectedDOJ" style="width: 120px;" clientidmode="Static"
                                    readonly="readonly" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                        height="16" id="img2" runat="server" />
                                <script type="text/javascript">
                                    Calendar.setup({
                                        inputField: "txtExpectedDOJ",      // id of the input field
                                        ifFormat: "M dd, y",       // format of the input field
                                        //ifFormat       :    "y-M-dd",       // format of the input field
                                        //ifFormat       :    "M-dd-y",       // format of the input field
                                        button: '<%=img2.ClientID %>',   // trigger for the calendar (button ID)
                                        singleClick: true            // double-click mode
                                    });
                                </script>
                            </td>
                            <td>
                                <strong>Reporting Authority</strong>&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlRA" runat="server" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRA"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='RA is required!' />"
                                    Display="Dynamic" InitialValue="-1" ValidationGroup="AcceptCheckRA"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:LinkButton runat="server" ID="lnkMarkOfferAccepted" CssClass="btn-ora nl" OnClick="lnkMarkOfferAccepted_Click"
                                    OnClientClick="javascript:return ValidDate(txtExpectedDOJ);">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Accepted
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkMarkOfferNotAccepted" CssClass="btn-ora nl"
                                    OnClick="lnkMarkOfferNotAccepted_Click" OnClientClick="javascript:return Validate1();">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Offer Not Accepted
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div width="100%" id="divAction59" runat="server" clientidmode="Static">
                    <table id="tblAppointmentGeneration" runat="server" width="50%" visible="false">
                        <tr>
                            <td>
                                <strong>Enter Appointment Generation Comments:</strong><br />
                                <textarea id="txtaAppointmentGeneration" cols="50" rows="6" runat="server"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtaAppointmentGeneration"
                                    ErrorMessage="" Font-Bold="True" ForeColor="Red" Text="<img src='/assets/Images/Exclamation.gif' title='Comment is required!' />"
                                    Display="Dynamic" InitialValue="" ValidationGroup="OfferPendingCheck"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lnkAppointmentGenerate" CssClass="btn-ora nl"
                                    OnClick="lnkAppointmentGenerate_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Generate Appointment Letter
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div width="100%" id="divAction60" runat="server" clientidmode="Static">
                    <table id="tblPortalActivation" runat="server" width="50%" visible="false">
                        <tr>
                            <td colspan="2">
                                <strong>Request To Create Portal </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Shift: &nbsp;
                                <asp:DropDownList ID="ddlshift" runat="server" Width="170px" CssClass="select">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvShift" ControlToValidate="ddlshift" runat="server"
                                    ValidationGroup="shift" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Select Location: &nbsp;
                                <asp:DropDownList ID="ddlCity" runat="server" Width="170px" CssClass="select">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvcity" ControlToValidate="ddlCity" runat="server"
                                    ValidationGroup="city" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>Select JobRole:</strong><br />
                                <asp:CheckBoxList ID="chkjobrole" runat="server" CssClass="chkbox">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:LinkButton runat="server" ID="lnkCreatePortal" CssClass="btn-ora nl" OnClick="lnkCreatePortal_Click"
                                    OnClientClick="javascript:return validateControls();">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Request to Create Portal
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            
           <p id="HOffer" runat="server" class="heading">
                <img id="imgsoffer" src="/assets/images/action-icon.png" height="20px" width="20px"
                    alt="" />
                &nbsp; Offer</p>
            <div class="content">
                <div id="dv" runat="server" visible="true" clientidmode="Static">
                    <table>
                        <asp:Repeater ID="rptOffer" runat="server">
                            <HeaderTemplate>
                                <tr style="background-color: #999999">
                                    <th align="center">
                                        S.No
                                    </th>
                                     <th align="center">
                                        User Name
                                    </th>
                                    <th align="center">
                                        User Type
                                    </th>
                                    <th align="center">
                                        Status
                                    </th>
                                    <th align="center">
                                        Date
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="normal">
                                    <td align="center">
                                        <%#Container.ItemIndex +1 %>
                                    </td>
                                    <td align="left">
                                        <%#Eval("username")%>                                        
                                    </td>
                                    <td align="left">
                                        <%#Eval("UserType")%>
                                    </td>
                                    <td align="left">
                                        <%#Eval("OfferApproval_NameDisplay")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Created_Date")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="normal">
                                    <td align="center">
                                        <%#Container.ItemIndex +1 %>
                                    </td>
                                    <td align="left">
                                        <%#Eval("username")%>                                        
                                    </td>
                                    <td align="left">
                                        <%#Eval("UserType")%>
                                    </td>
                                    <td align="left">
                                        <%#Eval("OfferApproval_NameDisplay")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Created_Date")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                    <table width="80%" border="0" cellspacing="0" cellpadding="10">
                        <tr>
                            <td>
                                <asp:Label ID="lblOffer" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowHideGrade() {

            if (document.getElementById('<%=rdbFail.ClientID%>').checked) {

                $('#divAction51').hide();

            }
            else {

                $('#divAction51').show();

            }
        }


        function ShowPanel(obj, obj1, obj2) {


            document.getElementById(obj2).style.display = '';
            document.getElementById(obj).style.display = 'none';
            document.getElementById(obj1).style.display = '';


        }
        function HidePanel(obj, obj1, obj2) {

            document.getElementById(obj2).style.display = 'none';
            document.getElementById(obj).style.display = 'none';
            document.getElementById(obj1).style.display = '';


        }
    </script>
    <script type="text/javascript">

        alwaysOnTop.init({
            targetid: 'examplediv',
            orientation: 2,
            position: [5, 40]
            // fadeduration: [100, 100],
            // frequency: 0.95,

        })

        alwaysOnTop.init({
            targetid: 'ajaxdiv',
            orientation: 3,
            position: [70, 100]


        })

    </script>
</asp:Content>



