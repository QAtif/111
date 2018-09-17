<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="ReferralCandidate.aspx.cs" Inherits="ReferralCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            Referred Candidate Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px">
            <tr>
                <td>
                    Candidate Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                <td>
                    Reference No.
                </td>
                <td>
                    <asp:TextBox ID="txtref" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                <td>
                    Referred By
                </td>
                <td>
                    <asp:TextBox ID="txtAxactian" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Date From
                </td>
                <td>
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 180px" />
                </td>
                <td>
                    Date To
                </td>
                <td>
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 180px" readonly="true" />
                </td>
                <td>
                    Department
                </td>
                <td>
                    <asp:DropDownList ID="ddlDomain" runat="server"  Style="width: 191px !important;
                        margin-top: 14px;">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Users
                </td>
                <td>
                    <asp:DropDownList ID="ddlUsers" runat="server" Style="width: 191px !important">
                    </asp:DropDownList>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click" />
                     <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold;"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <table width="80%" border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnDataBound">
                <HeaderTemplate>
                    <tr style="font-weight: bold; height: 30px;">
                        <td align="center" style="width: 3%">
                            S. No.
                        </td>
                        <td align="center" style="width: 5%">
                            Ref No.
                        </td>
                        <td align="center" style="width: 15%">
                            Candidate Details
                        </td>
                        <td align="center" style="width: 20%">
                            Axactian Details
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td align="center">
                            <a id="aCandidateLink" runat="server" target="_blank">
                                <%# Eval("Candidate_ID")%></a>
                        </td>
                        <td valign="top">
                            <table style="margin: 5px 5px 5px 5px;">
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <asp:HiddenField ID="hdnCandCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                                        <b>Name </b>:
                                    </td>
                                    <td align="left">
                                        <%# Eval("Full_Name")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Email </b>:
                                    </td>
                                    <td align="left">
                                        <%# Eval("Email_Address")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Status:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("CandidateStatus")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Department:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("CandidateDepartment")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>City:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("City")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Date:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("Created_Date")%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table style="margin: 5px 5px 5px 5px;">
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Name </b>:
                                    </td>
                                    <td align="left">
                                        <%# Eval("Referralname")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Department </b>:
                                    </td>
                                    <td align="left">
                                        <%# Eval("Department")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>JobTitle:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("JobTitle")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Email:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("Email")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="20%">
                                        <b>Ext:</b>
                                    </td>
                                    <td align="left">
                                        <%# Eval("Ext")%>
                                    </td>
                                </tr>
                            </table>
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
        </table>
    </div>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
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
