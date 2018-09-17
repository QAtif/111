<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="TentativeCandidate.aspx.cs" Inherits="A2_Reports_TentativeCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <script type="text/javascript">
    function toggleCheckAll(chkAll) {
        var isChecked = chkAll.checked;
        var frm = document.getElementsByTagName('input');
        for (i = 0; i < frm.length; i++)
            if (frm[i].type == 'checkbox')
                frm[i].checked = isChecked;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            Tentative Joining Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px">
            <tr>
                <td>
                    <br />
                    Date From
                </td>
                <td>
                    <br />
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 180px" />
                </td>
                <td>
                    <br />
                    Date To
                </td>
                <td colspan="2">
                    <br />
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 180px" readonly="true" />
                </td>
            </tr>
            <tr style="height: 46px;">
                <td>
                    Reference No.
                </td>
                <td >
                    <asp:TextBox ID="txtref" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                 <td colspan="2">
                 <b><asp:RadioButton runat="server" GroupName="officer" ID="rdoOfficer" AutoPostBack="true" Text="Officer"
                            Checked="true" OnCheckedChanged="rdoOfficer_CheckedChanged" /></b> &nbsp;&nbsp;
                        <b>
                            <asp:RadioButton runat="server" GroupName="officer" ID="rdoSupportStaff" AutoPostBack="true" Text="Support Staff"
                                Checked="false" OnCheckedChanged="rdoSupportStaff_CheckedChanged" /></b>
                 </td>

                 
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;" id="dv" runat="server">
        <h3>
            Deparment Wise Count</h3>
        <table border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;width: 50% !important;">
            <tr>
                <td align="center" style="width: 20%">
                    <asp:Repeater ID="rptDepartment" runat="server" OnItemDataBound="rptDepartment_OnDataBound">
                        <HeaderTemplate>
                            <tr style="font-weight: bold; height: 30px;">
                                <td align="center" style="width: 15%">
                                    Department
                                </td>
                                <td align="center" style="width: 15%">
                                    Count
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 35px;">
                                <td align="left" style="padding-left:10px">
                                    <%# Eval("CandidateDepartment")%>
                                </td>
                                <td align="center">
                                    <%# Eval("Count")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="height: 35px;">
                                <td align="left" style="padding-left:10px">
                                    <strong>Total</strong>
                                </td>
                                <td align="center">
                                    <strong><asp:Label ID="lblTotalCount" runat="server"></asp:Label></strong>
                                </td>
                            </tr>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <table width="80%" border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnDataBound">
                <HeaderTemplate>
                    <tr style="font-weight: bold; height: 30px;">
                         <td align="center" style="width: 3%">
                            <asp:CheckBox ID="chkAll" runat="server" onclick="toggleCheckAll(this)" />
                        </td>
                        <td align="center" style="width: 3%">
                            S. No.
                        </td>
                        <td align="center" style="width: 5%">
                            Ref No.
                        </td>
                        <td align="center" style="width: 15%">
                            Name
                        </td>
                        <td align="center" style="width: 15%">
                            Designation
                        </td>
                        <td align="center" style="width: 15%">
                            Domain
                        </td>
                        <td align="center" style="width: 10%">
                            Location
                        </td>
                        <td align="center" style="width: 7%">
                            Shift
                        </td>
                        <td align="center" style="width: 7%">
                            Joining Date
                        </td>
                        <td align="center" style="width: 10%">
                            Assigned To
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="height: 35px;">
                     <td align="center">
                            <asp:CheckBox runat="server"  ID="chkRows" />
                        </td>
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td align="center">
                            <a id="aCandidateLink" runat="server" target="_blank">
                                <%# Eval("Candidate_ID")%></a>
                                <asp:HiddenField ID="hdnCandidate_ID" runat="server" Value='<%# Eval("Candidate_ID") %>' />
                        </td>
                        <td align="left" style="padding-left:10px">
                            <asp:HiddenField ID="hdnCandCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                            <asp:HiddenField ID="hdnFull_Name" runat="server" Value='<%# Eval("Full_Name") %>' />
                            <%# Eval("Full_Name")%>
                        </td>
                        <td align="left" style="padding-left:10px">
                            <%# Eval("Designation")%>
                            <asp:HiddenField ID="hdnDesignation" runat="server" Value='<%# Eval("Designation") %>' />
                        </td>
                        <td align="left" style="padding-left:10px">
                            <%# Eval("CandidateDepartment")%>
                            <asp:HiddenField ID="hdnCandidateDepartment" runat="server" Value='<%# Eval("CandidateDepartment") %>' />
                        </td>
                        <td align="left" style="padding-left:10px">
                            <%# Eval("City")%>
                            <asp:HiddenField ID="hdnCity" runat="server" Value='<%# Eval("City") %>' />
                        </td>
                        <td align="left" style="padding-left:10px">
                            <%# Eval("Shift")%>
                            <asp:HiddenField ID="hdnShift" runat="server" Value='<%# Eval("Shift") %>' />
                        </td>
                        <td align="center">
                            <%# Eval("Joining_Date")%>
                            <asp:HiddenField ID="hdnJoining_Date" runat="server" Value='<%# Eval("Joining_Date") %>' />
                        </td>
                        <td align="left" style="padding-left:10px">
                            <%# Eval("AssignTo")%>
                            <asp:HiddenField ID="hdnAssignTo" runat="server" Value='<%# Eval("AssignTo") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="4" align="center">
                    <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
                        Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="10" align="right">
                    <br />
                    <asp:Button runat="server" ID="btnSendEmail" Text="Send Email" 
                        onclick="btnSendEmail_Click" />
                </td>
            </tr>
        </table>
    </div>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
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
