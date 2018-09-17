<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="OfferRejectionReport.aspx.cs" Inherits="A2_Reports_OfferRejectionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <style type="text/css">
        .ButtonsSave11
        {
            cursor: pointer;
            background: linear-gradient(to bottom, #4B8EFC 0%, #4787EE 100%) !important;
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important;
            border: 1px solid #3079ED !important;
            color: #FFF;
            padding: 4px 27px;
        }
        .error
        {
            /* background: #FFD9D9 !important; */
            border: 1px solid #C00 !important;
        }
    </style>
    <link href="<%=Page.ResolveUrl("~")%>A2/assets/css/Jquery-Ui-Smoothness.css" rel="stylesheet"
        type="text/css" />
    <link href="<%=Page.ResolveUrl("~")%>A2/assets/css/DataTable.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
           Offer Rejection Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px" style="border-collapse: separate !important; border-spacing: 3px">
            <tr>
                <td>
                    Date From
                </td>
                <td>
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 186px; height: 19px; margin-bottom: 5px; border: 1px #A7A6A6 !important;" />
                </td>
                <td>
                    Date To
                </td>
                <td>
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 186px; height: 19px; margin-bottom: 5px; border: 1px #A7A6A6  !important;"
                        readonly="true" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click"
                        CssClass="ButtonsSave11" />
                    <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold;"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div class="box-ScheduledActivities">
        <asp:Repeater ID="rptOfferRejection" runat="server">
            <HeaderTemplate>
                <table id="tblData">
                    <thead>
                        <tr style="font-weight: bold" align="center">
                            <th style="width: 2%">
                                S. No.
                            </th>
                            <th style="width: 10%">
                                Name
                            </th>
                            <th style="width: 10%">
                                ReferenceNo
                            </th>                           
                             <th style="width: 10%">
                              Profile
                            </th>
                             <th style="width: 10%">
                             Department
                            </th>
                            <th style="width: 10%">
                                Offered Designation
                            </th>
                            <th style="width: 8%">
                            Offered Grade
                            </th>
                            <th style="width: 10%">
                                Offered Salary
                            </th>
                            <th style="width: 10%">
                               Salary Demand
                            </th>
                            <th style="width: 10%">
                               Rejection Reason
                            </th>
                             <th style="width: 10%">
                              Deliverd by
                            </th>
							<th style="width: 10%">
                              Last Experience
                            </th>
							<th style="width: 10%">
                              Last Education
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr align="center">
                    <td align="center">
                        <%#Container.ItemIndex +1 %>
                    </td>
                    <td>
                        <%# Eval("full_name")%>
                    </td>
                    <td>
                        <%# Eval("candidate_id")%>
                    </td>
                    <td>
                        <%# Eval("Profile_Name")%>
                    </td>
                    <td>
                        <%# Eval("Department")%>
                    </td>
                    <td>
                        <%# Eval("designation")%>
                    </td>
                    <td>
                        <%# Eval("grade")%>
                    </td>
                    <td>
                        <%# Eval("OfferedSalary")%>
                    </td>
                     <td>
                        <%# Eval("Demanded_Salary")%>
                    </td>
                     <td>
                        <%# Eval("RejectionComments")%>
                    </td>
                     <td>
                        <%# Eval("offerdiliveredby")%>
                    </td>
					<td>
                        <%# Eval("lastexperience")%>
                    </td>
					<td>
                        <%# Eval("lasteducation")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <div style="position: absolute; right: 650px;">
            <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
                Style="display: none"></asp:Label>
        </div>
    </div>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/DataTable.js" type="text/javascript"></script>
    <script type="text/javascript">


        $(document).ready(function () {
            $('#tblData').dataTable();
        });

        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });

            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });

    
    </script>
</asp:Content>
