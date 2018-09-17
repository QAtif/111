<%@ Page Title="Interview Scheduled Candidate" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="IntScheduledCandidate.aspx.cs" Inherits="IntScheduledCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <title>Scheduled Candidate</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
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
    
    
    </script>
    <div class="headbar">
        <h2>
            <span>Scheduled </span>Candidate</h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="grey" style="color: Red" colspan="4">
                        <asp:Label runat="server" Font-Bold="true" ID="lblMsg" Visible="false" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="text-align: left">
                        Select From Date :
                    </td>
                    <td style="text-align: left">
                        <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 120px"
                            clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                height="16" id="img5" />
                    </td>
                    <td style="text-align: left">
                        Select To Date :
                    </td>
                    <td style="text-align: left">
                        <input runat="server" width="50px" type="text" id="postedToDate" style="width: 120px"
                            clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                height="16" id="img1" />
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedToDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img1",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%" align="left">
                        Reference No.:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtRefNo" MaxLength="16"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="valNumbersOnly" ControlToValidate="txtRefNo"
                            Display="Dynamic" Text="*" ErrorMessage="Please enter a numbers only in Reference No."
                            ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)">
                        </asp:RegularExpressionValidator>
                    </td>
                     <td style="width: 15%" align="left">
                        Scheduled For:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlScheduledFor" runat="server" Width="150px">
                        <asp:ListItem Text="All" Value="0">                       
                        </asp:ListItem>
                         <asp:ListItem Text="Test" Value="1060">                       
                        </asp:ListItem>
                         <asp:ListItem Text="Interview" Value="1140">                       
                        </asp:ListItem>
                         <asp:ListItem Text="Offer Letter" Value="1190">                       
                        </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="bold center">
                    <td style="text-align: center" colspan="4">
                        <%--<asp:Button ID="btnSearch" CssClass="btn-ora nl" runat="server" Text="Search" OnClick="btnSearch_Onclick" />--%>
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedFromDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img5",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table border="1" width="500px">
                <asp:Repeater ID="rptTestSheduled" runat="server" OnItemCommand="rptTestSheduled_ItemCommand"
                    OnItemDataBound="rptCandidateLists_ItemDataBound">
                    <HeaderTemplate>
                        <tr style="background-color: #dddddd">
                            <th>
                                S/No.
                            </th>
                            <th>
                                Ref No.
                            </th>
                            <th>
                                Candidate
                            </th>
                            <th>
                                Date
                            </th>
                            <th>
                               Time Slot
                            </th>
                            <th>
                                Venue
                            </th>
                            <th>
                                Seat No.
                            </th>
                            <th>
                                Requisition
                            </th>
                            <th>
                                Schduled For
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Organization Tour
                            </th>
                            <th>
                                Portal Picture
                            </th>
                            <th>
                                Action
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="normal">
                            <td>
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("CandidateCode")%>' />
                                <a id="aCandidateLink" runat="server" target="_blank">
                                    <%# Eval("CandidateFullName")%></a>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                            </td>
                            <td>
                                <%# Eval("SlotStartTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Requisition_Name")%>
                            </td>
                            <td>
                            <asp:HiddenField ID="hdnCanStatus" runat="server" Value=' <%# Eval("canStatus")%>' />
                            <asp:Label ID="lblSchuduleFor" runat="server" ></asp:Label>
                               <%--<asp:Label ID="Label2" runat="server" Visible='<%# ((bool)Eval("Is_TestOrInterview")) == true ? true : false  %>'>Interview</asp:Label>--%>
                                <%--<asp:Label ID="Label3" runat="server" Visible='<%# ((bool)Eval("Is_TestOrInterview")) == false ? true : false  %>'>Test</asp:Label>--%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td align="center">
                                <asp:Label ID="imgbtnBrouse" Text="Pending" runat="server" Visible='<%# ((bool)Eval("IsVisited")) == true ? false : true  %>' />
                                <asp:Label ID="imgChecked" runat="server" Text="Done" Visible='<%# ((bool)Eval("IsVisited")) == true ? true : false  %>' />
                            </td>
                            <td align="center">
                                <asp:Label ID="Label1" Text="Pending" runat="server" Visible='<%# ((bool)Eval("Ispicture")) == true ? false : true  %>' />
                                <a href="javascript:void(0);" onclick="PopupWindowCenter('ViewInitialPic.aspx?ID=<%# Eval("CandidateCode")%>', 'Picture',250,250)">
                                    <asp:Label ID="lblView" runat="server" Visible='<%# ((bool)Eval("Ispicture")) == true ? true : false  %>'>View</asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CommandArgument='<%# Eval("CandidateCode")%>'>Mark not appeared</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td>
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td>
                                <%# Eval("reffNo")%>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("CandidateCode")%>' />
                                <a id="aCandidateLink" runat="server" target="_blank">
                                    <%# Eval("CandidateFullName")%></a>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                            </td>
                            <td>
                                <%# Eval("SlotStartTime")%>
                            </td>
                            <td>
                                <%# Eval("VenueName")%>
                            </td>
                            <td>
                                <%# Eval("VenuePrefix")%>
                            </td>
                            <td>
                                <%# Eval("Requisition_Name")%>
                            </td>
                            <td>
                             <asp:HiddenField ID="hdnCanStatus" runat="server" Value=' <%# Eval("canStatus")%>' />
                            <asp:Label ID="lblSchuduleFor" runat="server" ></asp:Label>
                              <%-- <asp:Label ID="Label2" runat="server" Visible='<%# ((bool)Eval("Is_TestOrInterview")) == true ? true : false  %>'>Interview</asp:Label>
                                <asp:Label ID="Label3" runat="server" Visible='<%# ((bool)Eval("Is_TestOrInterview")) == false ? true : false  %>'>Test</asp:Label>--%>
                            </td>
                            <td>
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td align="center">
                                <asp:Label ID="imgbtnBrouse" Text="Pending" runat="server" Visible='<%# ((bool)Eval("IsVisited")) == true ? false : true  %>' />
                                <asp:Label ID="imgChecked" runat="server" Text="Done" Visible='<%# ((bool)Eval("IsVisited")) == true ? true : false  %>' />
                            </td>
                            <td align="center">
                                <asp:Label ID="Label1" Text="Pending" runat="server" Visible='<%# ((bool)Eval("Ispicture")) == true ? false : true  %>' />
                                <a href="javascript:void(0);" onclick="PopupWindowCenter('ViewInitialPic.aspx?ID=<%# Eval("CandidateCode")%>', 'Picture',250,250)">
                                    <asp:Label ID="lblView" runat="server" Visible='<%# ((bool)Eval("Ispicture")) == true ? true : false  %>'>View</asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CommandArgument='<%# Eval("CandidateCode")%>'>Mark not appeared</asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblemtyMsg" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
