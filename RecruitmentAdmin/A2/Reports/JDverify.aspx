<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="JDverify.aspx.cs" Inherits="A2_Reports_JDverify" %>

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
            Job Decription Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px" style="border-collapse: separate !important; border-spacing: 3px">
            <tr>
                <td>
                    Name</td>
                <td>
                    <asp:TextBox ID="txtbxName" runat="server" Width="268px"></asp:TextBox></td>
                <td>
                    Email</td>
                <td>
                    </td>

                <td><asp:TextBox ID="txtbxEmail" runat="server" Width="268px"></asp:TextBox>
                   
                </td>
                <td>Reference No.</td>
                <td><asp:TextBox ID="txtbxRefNo" runat="server" Width="268px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td>
                    User's Portal ID
                </td>
                <td>
                    <asp:TextBox ID="txtbxUserCode" runat="server" onkeypress="return ValidateNumber(event);" Width="268px" autocomplete="off"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click"
                        CssClass="ButtonsSave11" />
                    <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold;"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div class="box-ScheduledActivities">
        <asp:Repeater ID="rptCanddiate" runat="server">
            <HeaderTemplate>
                <table id="tblData">
                    <thead>
                        <tr style="font-weight: bold" align="center">
                            <th style="width: 5%">
                                S. No.
                            </th>
                            <th style="width: 20%">
                                Candidate Name
                            </th>
                            <th style="width: 25%">
                                Email Address
                            </th>
                            <th style="width: 25%">
                                Job Description
                            </th>
                            <th style="width: 5%">
                                Referrence No.
                            </th>
                            <th style="width: 5%">
                                Portal ID
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
                        <%# Eval("Full_Name")%>
                    </td>
                    <td>
                        <%# Eval("Email_address")%>
                    </td>
                    <td>
                        <%# Eval("jobDesc")%>
                    </td>
                    <td>
                        <%# Eval("Candidate_ID")%>
                    </td>
                    <td>
                        <%# Eval("PortalUserID")%>
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
            debugger;
            $('#ctl00_BodyContent_txtbxPortalNumber').val('');
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
    <script>
        function ValidateNumber(e) {
            //            if (e.value.length > 0) {
            //                //   var NumberRegExp = new RegExp(/^(0[1-9][0-9]{0,3}|00[1-9][0-9]{0,2}|000[1-9][0-9]{0,1}|0000[1-9]|[1-9][0-9]{0,4})$/);
            //                var NumberRegExp = new RegExp(/([^\d]*\d)/);
            //                if (NumberRegExp.test(e.value)) {
            //                    //if true 
            //                    e.style.borderColor = '#d3d7dc'; return true;
            //                }
            //                else {
            //                    //if false
            //                    e.style.border = '1px solid #DC1B5E';
            //                    return false;
            //                }
            //            } else { e.style.border = '1px solid #d3d7dc'; return true; }
            var specialKeys = new Array();
            specialKeys.push(8);
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            return ret;
        }
    </script>
</asp:Content>
