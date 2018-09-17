<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="CreateDatabase.aspx.cs" Inherits="A2_Reports_CreateDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <style type="text/css">
        .user-profile-warpper
        {
            text-align: left;
        }
        p, div, a
        {
            font: 14px Verdana, Arial, Helvetica, sans-serif;
        }
        .btn
        {
            font: 14px Verdana, Arial, Helvetica, sans-serif;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function toggleCheck(chk, id) {
            var frm = chk.parentNode.parentNode.parentNode.parentNode.getElementsByTagName('input')
            for (var i = 0; i < frm.length; i++)
                if (frm[i].id.indexOf(id) > -1 && frm[i].type == 'checkbox')
                    frm[i].checked = chk.checked;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="wrapit topmenu offeraproval searchbar">
    <div class="domain-name">
      <!--<input id="selectall" type="checkbox" name="checkIt">-->
      <label>SCHEDULED CANDIDATE</label>
    </div>
    
    </section>
    <div >
        <!-- Main Content Here -->
        <div >
            <table width="800px" >
                <tr>
                    <td align="right" style="width:50%">
                        <strong>From Date</strong> &nbsp;&nbsp;
                    </td>
                    <!-- #Lable -->
                    <td style="width:50%">
                        <input runat="server" type="text" id="postedFromDate" clientidmode="Static" 
                            readonly="true" />
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" 
                            OnClick="lnkSearch_Click"><img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div><br />
            </div>
            <div><br />
            </div>
            <table border="1" cellpadding="0" cellspacing="0" width="100%">
                <asp:Repeater ID="rptCandidate" runat="server" OnItemDataBound="rptDeptCandidate_ItemDataBound">
                    <HeaderTemplate>
                        <tbody>
                            <tr bgcolor="#3399ff">
                                <th>
                                <asp:CheckBox runat="server"  ID="chkAll" onclick="toggleCheck(this, 'chk');"  />
                                </th>
                                <th>
                                    <font color="#FFFFFF">S. No. </font>
                                </th>
                                <th>
                                    <font color="#FFFFFF">Reference No. </font>
                                </th>
                                <th>
                                    <font color="#FFFFFF">Candidate Name </font>
                                </th>
                                <th>
                                    <font color="#FFFFFF">Date </font>
                                </th>
                                <th>
                                    <font color="#FFFFFF">Test Time Slot <font color="#FFFFFF">
                                </th>
                                <th>
                                    <font color="#FFFFFF">Venue </font>
                                </th>
                                <th>
                                    <font color="#FFFFFF">UserID/ PWD/ DB </font>
                                </th>
                                <th>
                                    <font color="#FFFFFF">DB Status</font>
                                </th>

                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                         <td align="center">
                                <asp:CheckBox runat="server"  ID="chk"  />
                            </td>
                            <td align="center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="center">
                                <asp:HiddenField runat="server" ID="hdRefNo" Value='<%# Eval("reffNo")%>' />
                                <%# Eval("reffNo")%>
                            </td>
                            <td align="center">
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td align="center">
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                            </td>
                            <td align="center">
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td align="center">
                                <%# Eval("VenueName")%>
                            </td>
                             <td align="center">
                                <%# Eval("DBLogin_Id")%>
                            </td>
                             <td align="center">
                                <%# Eval("Is_DBCreatedStatus")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                    <tr>
                    <td align="center">
                                <asp:CheckBox runat="server"  ID="chk"  />
                            </td>
                            <td align="center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="center">
                                <asp:HiddenField runat="server" ID="hdRefNo" Value='<%# Eval("reffNo")%>' />
                                <%# Eval("reffNo")%>
                            </td>
                            <td align="center">
                                <%# Eval("CandidateFullName")%>
                            </td>
                            <td align="center">
                                <%# DataBinder.Eval(Container.DataItem,"SlotDate","{0:dd MMM, yyyy}" )%>
                            </td>
                            <td align="center">
                                <%# Eval("SlotStartTime")%>
                                &nbsp; - &nbsp;
                                <%# Eval("SlotEndTime")%>
                            </td>
                            <td align="center">
                                <%# Eval("VenueName")%>
                            </td>
                            <td align="center">
                                <%# Eval("DBLogin_Id")%>
                            </td>
                             <td align="center">
                                <%# Eval("Is_DBCreatedStatus")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
            <div style="text-align: center">
                <br />
                <br />
                <asp:LinkButton runat="server" ID="lnkDatabase" CssClass="btn-ora nl" OnClick="LinkButton1_Click">
                        <img src="/assets/images/icons/map-img.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Create Database
                </asp:LinkButton>
                <br />
            </div>
            <div style="text-align: center">
                <asp:Label ID="lblemtyMsg" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </div>
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
