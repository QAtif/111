<%@ Page Title="Scheduled Candidate" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="ScheduledCandidate.aspx.cs" Inherits="ScheduledCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="Server">
    <style type="text/css">
        #showthebloodydiv:hover #AimgEdit
        {
            display: block !important;
        }
        .DataHeading{padding-left:1px; font-size:15px; color:Gray}
        .RepeaterContainer{background-color: #FFF; margin-bottom: 15px; width: 98%; margin-left: 9px;
            padding: 5px 5px 5px 5px;}
            .SearchContainer{background-color: #FFF; margin-top: 15px;margin-bottom: 15px; width: 98%; margin-left: 9px;
            padding: 5px 5px 5px 5px;}
    </style>
    <title>Scheduled Candidate</title>
    <link href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="ShowAllDataGrid">
        <div class="SearchContainer">
            <div>
                <h2>
                    <span>Scheduled </span>Candidate</h2>
            </div>
            <table width="80%" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td style="color: Red" colspan="4">
                        <asp:Label runat="server" Font-Bold="true" ID="lblMsg" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        <asp:CheckBox ID="chkIsInclude" runat="server" Text="Select Date:" ToolTip="Do uncheck it, when you do not want this filter"
                            Checked="true" OnClick="Check_Clicked(this);" Width="200px" />
                    </td>
                    <td>
                        <input runat="server" type="text" id="postedFromDate" clientidmode="Static" style="width: 200px"
                            readonly="true" />
                    </td>
                    <td style="width: 15%">
                        Reference No:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRefNo" MaxLength="16" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvreff" runat="server" ValidationGroup="valida"
                            ControlToValidate="txtRefNo" Text="*" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        City:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCity" runat="server" Width="200px" Style="width: 213px;
                            margin-top: 10px;">
                        </asp:DropDownList>
                    </td>
                    <td valign="middle">
                        Department:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="200px" Style="width: 213px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr style="border-top: gray 1px">
                    <td align="center" style="height: 30px; padding-left: 45%;" colspan="6">
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" ValidationGroup="valida"
                            OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: none">
            <asp:FileUpload runat="server" ID="FuPic" Style="display: none" onchange="$('#ctl00_BodyContent_btnuploadPic').click();" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only Image file is allowed! "
                ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.png|.PNG)$" ControlToValidate="FuPic"
                ValidationGroup="upload" Display="Dynamic"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvfupic" runat="server" ControlToValidate="fuPic"
                ErrorMessage="Please Select File." Display="Dynamic" ValidationGroup="upload"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnCandidateCode" runat="server" />
            <asp:Button ID="btnuploadPic" runat="server" OnClick="btnSave_Upload" ValidationGroup="upload" />
        </div>
        <div class="RepeaterContainer">
            <b class="DataHeading">Scheduled For Test</b>
            <table border="1">
                <asp:Repeater ID="rptTestSheduled" runat="server">
                    <HeaderTemplate>
                        <tr style="font-weight: bold; background-color: #dddddd" align="center">
                            <td align="center">
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleCheck(this, 'chkSelect');" />
                            </th>
                            <th>
                                S/No.
                            </th>
                            <th>
                                Reference No.
                            </th>
                            <th>
                                Candidate Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Date - Time
                            </th>
                            <th>
                                Venue
                            </th>
                            <th>
                                Seat No.
                            </th>
                            <th>
                                Scheduler Name
                            </th>
                            <th>
                                Organization Tour
                            </th>
                            <th>
                                Is Arrived
                            </th>
                            <th>
                                Portal Picture
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                      <tr align="center" style='<%# "background-color:" +  DataBinder.Eval(Container.DataItem, "Trcolor") + ";" %>'">
                            <td align="center">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td align="center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                                <asp:HiddenField runat="server" ID="hdCandidateCode" Value='<%# Eval("CandidateCode")%>' />
                            </td>
                            <td>
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                                <br />
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Scheduler_Name")%>
                            </td>
                            <td align="center">
                                <span id="divAction56" runat="server" clientidmode="Static" visible="false"><a id="aMarkVisit"
                                    runat="server" title="Click here If candidate has visited organization" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsVisitedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,1,0,\"#ctl00_BodyContent_rptTestSheduled_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"#E5E5EE\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkVisit" runat="server" title="Click here If candidate has not visited organization"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsVisitedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,0,0,\"#ctl00_BodyContent_rptTestSheduled_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"white\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                                <asp:HiddenField ID="hdnReservedSlotCode" runat="server" Value='<%# Eval("ReservedSlotCode") %>' />
                            </td>
                            <td align="center">
                                <span id="divAction114" runat="server" clientidmode="Static" visible="false"><a id="aMarkArrive"
                                    runat="server" title="Click here If candidate has arrived" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsArrivedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,1,\"{1}\",\"#ctl00_BodyContent_rptTestSheduled_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If candidate has not arrived"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsArrivedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,0,\"{1}\",\"#ctl00_BodyContent_rptTestSheduled_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" />  </a> </span>
                            </td>
                            <td align="center">
                                <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                    <a id="aViewBigImage" href='<%# Eval("CandidateCode","#frame-sets{0}") %>' title=""
                                        class="poptheform">
                                        <img id="CanImage" runat="server" src='<%# Eval("ImagePath") %>' width="40" height="40"
                                            onerror="this.src='/A2/assets/images/no-icon.gif';" /></a> <span id="divAction55"
                                                runat="server" clientidmode="Static" visible="false"><a id="AimgEdit" onclick="javascript:$('#ctl00_BodyContent_hdnCandidateCode').val('<%# Eval("CandidateCode")%>'); $('#ctl00_BodyContent_FuPic').click();"
                                                    style="z-index: 999; display: none; position: absolute; cursor: pointer; top: 0px; left: 36px;" width="20px" height="20px">
                                                    <img id="img3" alt="" src="/a2/assets/images/edit.png"></img></a>
                                    </span>
                                    <div id='<%# Eval("CandidateCode","frame-sets{0}") %>' style="display: none;">
                                        <div>
                                            <img id="imgBigImage" runat="server" alt="" src='<%# Eval("ImagePath") %>' width="500"
                                                height="500" /></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trTestButton" runat="server">
                    <td colspan="12" style="padding-left: 40%;">
                        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn-ora nl" OnClick="LinkButton1_Click"
                            Style="margin-right: 15px;"> &nbsp;Mark Tour Done </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="LinkButton7" CssClass="btn-ora nl" OnClick="LinkButton7_Click"> &nbsp;Mark Arrived </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblemtyMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <div style="background-color: #FFF; margin-bottom: 15px; width: 98%; margin-left: 9px;
            padding: 5px 5px 5px 5px;">
            <b class="DataHeading">Scheduled For Final Interview</b>
            <table border="1">
                <asp:Repeater ID="rptInterViewScheduled" runat="server">
                    <HeaderTemplate>
                        <tr style="font-weight: bold; background-color: #dddddd" align="center">
                            <th>
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleCheck(this, 'chkSelect');" />
                            </th>
                            <th>
                                S/No.
                            </th>
                            <th>
                                Reference No.
                            </th>
                            <th>
                                Candidate Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Date - Time
                            </th>
                            <th>
                                Venue
                            </th>
                            <th>
                                Seat No.
                            </th>
                            <th>
                                Scheduler Name
                            </th>
                            <th>
                                Organization Tour
                            </th>
                            <th>
                                Is Arrived
                            </th>
                            <th>
                                Portal Picture
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                       <tr align="center" style='<%# "background-color:" +  DataBinder.Eval(Container.DataItem, "Trcolor") + ";" %>'">
                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                                <asp:HiddenField runat="server" ID="hdCandidateCode" Value='<%# Eval("CandidateCode")%>' />
                            </td>
                            <td>
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                                <br />
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Scheduler_Name")%>
                            </td>
                            <td align="center">
                                <span id="divAction56" runat="server" clientidmode="Static" visible="false"><a id="aMarkVisit"
                                    runat="server" title="Click here If candidate has visited organization" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsVisitedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,1,0,\"#ctl00_BodyContent_rptInterViewScheduled_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"#E5E5EE\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkVisit" runat="server" title="Click here If candidate has not visited organization"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsVisitedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,0,0,\"#ctl00_BodyContent_rptInterViewScheduled_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"white\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt=""/></a> </span>
                                <asp:HiddenField ID="hdnReservedSlotCode" runat="server" Value='<%# Eval("ReservedSlotCode") %>' />
                            </td>
                            <td align="center">
                                <span id="divAction114" runat="server" clientidmode="Static" visible="false"><a id="aMarkArrive"
                                    runat="server" title="Click here If candidate has arrived" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsArrivedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,1,\"{1}\",\"#ctl00_BodyContent_rptInterViewScheduled_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If candidate has not arrived"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsArrivedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,0,\"{1}\",\"#ctl00_BodyContent_rptInterViewScheduled_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                            </td>
                            <td align="center">
                                <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                    <a id="aViewBigImage" href='<%# Eval("CandidateCode","#frame-sets{0}") %>' title=""
                                        class="poptheform">
                                        <img id="CanImage" runat="server" src='<%# Eval("ImagePath") %>' width="40" height="40"
                                            onerror="this.src='/a2/assets//images/no-icon.gif';" /></a> <span id="divAction55"
                                                runat="server" clientidmode="Static" visible="false"><a id="AimgEdit" onclick="javascript:$('#ctl00_BodyContent_hdnCandidateCode').val('<%# Eval("CandidateCode")%>'); $('#ctl00_BodyContent_FuPic').click();"
                                                    style="z-index: 999; display: none; position: absolute; cursor: pointer; top: 0px;
                                                    left: 36px;" width="20px" height="20px">
                                                    <img id="img3" alt="" src="/a2/assets/images/edit.png"></img></a>
                                    </span>
                                    <div id='<%# Eval("CandidateCode","frame-sets{0}") %>' style="display: none;">
                                        <div>
                                            <img id="imgBigImage" runat="server" alt="" src='<%# Eval("ImagePath") %>' width="500"
                                                height="500" /></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trInterviewButton" runat="server">
                    <td colspan="12" style="padding-left: 40%;">
                        <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn-ora nl" OnClick="LinkButton2_Click"
                            Style="margin-right: 15px;">
                        &nbsp;Mark Tour Done
                        </asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="LinkButton8" CssClass="btn-ora nl" OnClick="LinkButton8_Click"> &nbsp;Mark Arrived </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblemtyInterview" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
        <div style="background-color: #FFF; margin-bottom: 15px; width: 98%; margin-left: 9px;
            padding: 5px 5px 5px 5px;">
            <b class="DataHeading">Scheduled For Offer Letter</b>
            <table border="1">
                <asp:Repeater ID="rptOfferInterview" runat="server">
                    <HeaderTemplate>
                        <tr style="font-weight: bold; background-color: #dddddd" align="center">
                            <th>
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleCheck(this, 'chkSelect');" />
                            </th>
                            <th>
                                S/No.
                            </th>
                            <th>
                                Reference No.
                            </th>
                            <th>
                                Candidate Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Date - Time
                            </th>
                            <th>
                                Venue
                            </th>
                            <th>
                                Seat No.
                            </th>
                            <th>
                                Scheduler Name
                            </th>
                            <th>
                                Organization Tour
                            </th>
                            <th>
                                Is Arrived
                            </th>
                            <th>
                                Portal Picture
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                      <tr align="center" style='<%# "background-color:" +  DataBinder.Eval(Container.DataItem, "Trcolor") + ";" %>'">
                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                                <asp:HiddenField runat="server" ID="hdCandidateCode" Value='<%# Eval("CandidateCode")%>' />
                            </td>
                            <td>
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                                <br />
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Scheduler_Name")%>
                            </td>
                            <td align="center">
                                <span id="divAction56" runat="server" clientidmode="Static" visible="false"><a id="aMarkVisit"
                                    runat="server" title="Click here If candidate has visited organization" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsVisitedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,1,0,\"#ctl00_BodyContent_rptOfferInterview_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"#E5E5EE\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkVisit" runat="server" title="Click here If candidate has not visited organization"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsVisitedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,0,0,\"#ctl00_BodyContent_rptOfferInterview_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"white\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                                <asp:HiddenField ID="hdnReservedSlotCode" runat="server" Value='<%# Eval("ReservedSlotCode") %>' />
                            </td>
                            <td align="center">
                                <span id="divAction114" runat="server" clientidmode="Static" visible="false"><a id="aMarkArrive"
                                    runat="server" title="Click here If candidate has arrived" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsArrivedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,1,\"{1}\",\"#ctl00_BodyContent_rptOfferInterview_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If candidate has not arrived"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsArrivedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,0,\"{1}\",\"#ctl00_BodyContent_rptOfferInterview_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                            </td>
                            <td align="center">
                                <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                    <a id="aViewBigImage" href='<%# Eval("CandidateCode","#frame-sets{0}") %>' title=""
                                        class="poptheform">
                                        <img id="CanImage" runat="server" src='<%# Eval("ImagePath") %>' width="40" height="40"
                                            onerror="this.src='/a2/assets//images/no-icon.gif';" /></a> <span id="divAction55"
                                                runat="server" clientidmode="Static" visible="false"><a id="AimgEdit" onclick="javascript:$('#ctl00_BodyContent_hdnCandidateCode').val('<%# Eval("CandidateCode")%>'); $('#ctl00_BodyContent_FuPic').click();"
                                                    style="z-index: 999; display: none; position: absolute; cursor: pointer; top: 0px;
                                                    left: 36px;" width="20px" height="20px">
                                                    <img id="img3" alt="" src="/a2/assets/images/edit.png"></img></a>
                                    </span>
                                    <div id='<%# Eval("CandidateCode","frame-sets{0}") %>' style="display: none;">
                                        <div>
                                            <img id="imgBigImage" runat="server" alt="" src='<%# Eval("ImagePath") %>' width="500"
                                                height="500" /></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trOfferButton" runat="server">
                    <td colspan="12" style="padding-left: 40%;">
                        <asp:LinkButton runat="server" ID="LinkButton3" CssClass="btn-ora nl" OnClick="LinkButton3_Click"
                            Style="margin-right: 15px;">
                        &nbsp;Mark Tour Done
                        </asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="LinkButton9" CssClass="btn-ora nl" OnClick="LinkButton9_Click"> &nbsp;Mark Arrived </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblemptyOffer" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
        <div class="RepeaterContainer">
            <b class="DataHeading">Scheduled For Verification</b>
            <table border="1">
                <asp:Repeater ID="rptVerification" runat="server">
                    <HeaderTemplate>
                        <tr style="font-weight: bold; background-color: #dddddd" align="center">
                            <th>
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleCheck(this, 'chkSelect');" />
                            </th>
                            <th>
                                S/No.
                            </th>
                            <th>
                                Reference No.
                            </th>
                            <th>
                                Candidate Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Date - Time
                            </th>
                            <th>
                                Venue
                            </th>
                            <th>
                                Seat No.
                            </th>
                            <th>
                                Scheduler Name
                            </th>
                            <th>
                                Organization Tour
                            </th>
                            <th>
                                Is Arrived
                            </th>
                            <th>
                                Portal Picture
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr align="center" style='<%# "background-color:" +  DataBinder.Eval(Container.DataItem, "Trcolor") + ";" %>'">
                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                                <asp:HiddenField runat="server" ID="hdCandidateCode" Value='<%# Eval("CandidateCode")%>' />
                            </td>
                            <td>
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                                <br />
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Scheduler_Name")%>
                            </td>
                            <td align="center">
                                <span id="divAction56" runat="server" clientidmode="Static" visible="false"><a id="aMarkVisit"
                                    runat="server" title="Click here If candidate has visited organization" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsVisitedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,1,0,\"#ctl00_BodyContent_rptVerification_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"#E5E5EE\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkVisit" runat="server" title="Click here If candidate has not visited organization"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsVisitedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,0,0,\"#ctl00_BodyContent_rptVerification_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"white\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                                <asp:HiddenField ID="hdnReservedSlotCode" runat="server" Value='<%# Eval("ReservedSlotCode") %>' />
                            </td>
                            <td align="center">
                                <span id="divAction114" runat="server" clientidmode="Static" visible="false"><a id="aMarkArrive"
                                    runat="server" title="Click here If candidate has arrived" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsArrivedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,1,\"{1}\",\"#ctl00_BodyContent_rptVerification_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If candidate has not arrived"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsArrivedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,0,\"{1}\",\"#ctl00_BodyContent_rptVerification_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                            </td>
                            <td align="center">
                                <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                    <a id="aViewBigImage" href='<%# Eval("CandidateCode","#frame-sets{0}") %>' title=""
                                        class="poptheform">
                                        <img id="CanImage" runat="server" src='<%# Eval("ImagePath") %>' width="40" height="40"
                                            onerror="this.src='/A2/assets/images/no-icon.gif';" /></a> <span id="divAction55"
                                                runat="server" clientidmode="Static" visible="false"><a id="AimgEdit" onclick="javascript:$('#ctl00_BodyContent_hdnCandidateCode').val('<%# Eval("CandidateCode")%>'); $('#ctl00_BodyContent_FuPic').click();"
                                                    style="z-index: 999; display: none; position: absolute; cursor: pointer; top: 0px;
                                                    left: 36px;" width="20px" height="20px">
                                                    <img id="img3" alt="" src="/a2/assets/images/edit.png"></img></a>
                                    </span>
                                    <div id='<%# Eval("CandidateCode","frame-sets{0}") %>' style="display: none;">
                                        <div>
                                            <img id="imgBigImage" runat="server" alt="" src='<%# Eval("ImagePath") %>' width="500"
                                                height="500" /></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trVerificationButton" runat="server">
                    <td colspan="12" style="padding-left: 40%;">
                        <asp:LinkButton runat="server" ID="LinkButton4" CssClass="btn-ora nl" OnClick="LinkButton4_Click"
                            Style="margin-right: 15px;">
                        &nbsp;Mark Tour Done
                        </asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="LinkButton10" CssClass="btn-ora nl" OnClick="LinkButton10_Click"> &nbsp;Mark Arrived </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblVarification" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
        <div class="RepeaterContainer">
            <b class="DataHeading">Scheduled For Appointment</b>
            <table border="1">
                <asp:Repeater ID="rptAppointment" runat="server">
                    <HeaderTemplate>
                        <tr style="font-weight: bold; background-color: #dddddd" align="center">
                            <th>
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleCheck(this, 'chkSelect');" />
                            </th>
                            <th>
                                S/No.
                            </th>
                            <th>
                                Reference No.
                            </th>
                            <th>
                                Candidate Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Date - Time
                            </th>
                            <th>
                                Venue
                            </th>
                            <th>
                                Seat No.
                            </th>
                            <th>
                                Scheduler Name
                            </th>
                            <th>
                                Organization Tour
                            </th>
                            <th>
                                Is Arrived
                            </th>
                            <th>
                                Portal Picture
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                       
                        <tr align="center"  style='<%# "background-color:" +  DataBinder.Eval(Container.DataItem, "Trcolor") + ";" %>'">
                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                                <asp:HiddenField runat="server" ID="hdCandidateCode" Value='<%# Eval("CandidateCode")%>' />
                            </td>
                            <td>
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                                <br />
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Scheduler_Name")%>
                            </td>
                            <td align="center">
                                <span id="divAction56" runat="server" clientidmode="Static" visible="false"><a id="aMarkVisit"
                                    runat="server" title="Click here If candidate has visited organization" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsVisitedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,1,0,\"#ctl00_BodyContent_rptAppointment_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"#E5E5EE\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkVisit" runat="server" title="Click here If candidate has not visited organization"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsVisitedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",1,0,0,\"#ctl00_BodyContent_rptAppointment_ctl0{1}_\"); $(this).closest(\"tr\").css(\"background-color\",\"white\")", Eval("CandidateCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                                <asp:HiddenField ID="hdnReservedSlotCode" runat="server" Value='<%# Eval("ReservedSlotCode") %>' />
                            </td>
                            <td align="center">
                                <span id="divAction114" runat="server" clientidmode="Static" visible="false"><a id="aMarkArrive"
                                    runat="server" title="Click here If candidate has arrived" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsArrivedMark") + ";" %>'
                                    onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,1,\"{1}\",\"#ctl00_BodyContent_rptAppointment_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If candidate has not arrived"
                                        style='<%# "cursor:pointer; color:Blue;display:" + DataBinder.Eval(Container.DataItem, "IsArrivedUnMark") + ";" %>'
                                        onclick='<%# String.Format("UpdateCandidatebyPro(\"{0}\",2,0,\"{1}\",\"#ctl00_BodyContent_rptAppointment_ctl0{2}_\")", Eval("CandidateCode"),Eval("ReservedSlotCode"),Container.ItemIndex+1) %>'>
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" /></a> </span>
                            </td>
                            <td align="center">
                                <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                    <a id="aViewBigImage" href='<%# Eval("CandidateCode","#frame-sets{0}") %>' title=""
                                        class="poptheform">
                                        <img id="CanImage" runat="server" src='<%# Eval("ImagePath") %>' width="40" height="40"
                                            onerror="this.src='/a2/assets/images/no-icon.gif';" /></a> <span id="divAction55"
                                                runat="server" clientidmode="Static" visible="false"><a id="AimgEdit" onclick="javascript:$('#ctl00_BodyContent_hdnCandidateCode').val('<%# Eval("CandidateCode")%>'); $('#ctl00_BodyContent_FuPic').click();"
                                                    style="z-index: 999; display: none; position: absolute; cursor: pointer; top: 0px;
                                                    left: 36px;" width="20px" height="20px">
                                                    <img id="img3" alt="" src="/a2/assets/images/edit.png"></img></a>
                                    </span>
                                    <div id='<%# Eval("CandidateCode","frame-sets{0}") %>' style="display: none;">
                                        <div>
                                            <img id="imgBigImage" runat="server" alt="" src='<%# Eval("ImagePath") %>' width="500"
                                                height="500" /></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trAppointmentButton" runat="server">
                    <td colspan="12" style="padding-left: 40%;">
                        <asp:LinkButton runat="server" ID="LinkButton5" CssClass="btn-ora nl" OnClick="LinkButton5_Click"
                            Style="margin-right: 15px;">
                        &nbsp;Mark Tour Done
                        </asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="LinkButton11" CssClass="btn-ora nl" OnClick="LinkButton11_Click"> &nbsp;Mark Arrived </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblAppointment" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
    </div>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        function UpdateCandidatebyPro(CandidateCode, Type, Bit, ReservedSlotCode, ContainerPrefix) {

            var Param = CandidateCode + '|' + Type + '|' + Bit + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIp %>' + '|' + ReservedSlotCode
            // alert(Param);
            $.ajax({ type: "POST",
                url: "ScheduledCandidate.aspx/UpdateCandidatebyPro",
                data: JSON.stringify({ items: Param }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    if ((Type == '1') && (Bit == '1')) {
                        // alert(ContainerPrefix + 'aMarkVisit');
                        $(ContainerPrefix + 'aMarkVisit').hide();
                        $(ContainerPrefix + 'aUnmarkVisit').show()
                        //  alert("Marked Sucessfully!");
                    }
                    if ((Type == '1') && (Bit == '0')) {
                        // alert(ContainerPrefix + '_aMarkVisit');
                        $(ContainerPrefix + 'aMarkVisit').show()
                        $(ContainerPrefix + 'aUnmarkVisit').hide();
                        // alert("UnMarked Sucessfully!");
                    }
                    if ((Type == '2') && (Bit == '1')) {
                        $(ContainerPrefix + 'aMarkArrive').hide();
                        $(ContainerPrefix + 'aUnmarkArrive').show();
                        // alert("Marked Sucessfully!");
                    }
                    if ((Type == '2') && (Bit == '0')) {
                        $(ContainerPrefix + 'aMarkArrive').show();
                        $(ContainerPrefix + 'aUnmarkArrive').hide();
                        // alert("UnMarked Sucessfully!");
                    }


                    //parent.location.href = parent.location.href;
                },
                error: function (msg) {
                    alert("error");
                }
            });
        }


        $(function () {
            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });


        //        $('#postedFromDate').on('change', function () {
        //            var today = new Date();
        //            today = new Date(today.getYear(), today.getMonth(), today.getDate());
        //            // compare the value of the field with whatever you want to test against
        //            if ($(this).val() > today) {
        //                // if the test fails, change the value to default
        //                $(this).datepicker('setDate', new Date());
        //            }
        //        })

        function PopupWindowCenter(URL, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            var newWin = window.open(URL, title, 'toolbar=no, location=no,directories=no, status=no, menubar=no, scrollbars=no, resizable=no,copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }


        function HideRow(obj) {

            document.getElementById(obj).style.display = 'none';
        }
        function ShowRow(obj) {

            document.getElementById(obj).style.display = '';
            var sloadcol = document.getElementById(obj).getElementsByTagName("td").item(0);
            sloadcol.setAttribute("colSpan", "9");
            // document.getElementById(obj).colSpan = 6;
            // document.getElementById(obj + obj1).style.display = 'none';
        }
        function Check_Clicked(obj) {

            if (obj.checked) {
                //   alert(document.getElementById('<%= rfvreff.ClientID %>'));
                var myVal = document.getElementById('<%= rfvreff.ClientID %>')
                ValidatorEnable(myVal, false);
            }
            else {
                //  alert(document.getElementById('<%= rfvreff.ClientID %>'));
                var myVal = document.getElementById('<%= rfvreff.ClientID %>')
                ValidatorEnable(myVal, true);
            }
        }
        function toggleCheck(chk, id) {
            var frm = chk.parentNode.parentNode.parentNode.parentNode.getElementsByTagName('input')
            for (var i = 0; i < frm.length; i++)
                if (frm[i].id.indexOf(id) > -1 && frm[i].type == 'checkbox')
                    frm[i].checked = chk.checked;
        }
    </script>
</asp:Content>
