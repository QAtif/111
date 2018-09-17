<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="BonusType.aspx.cs" Inherits="Candidate_BonusType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <style type="text/css">
        .table
        {
            width: 70%;
        }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            Bonus Type</h2>
    </div>
    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <asp:Label ID="lblMsg" runat="server" Visible="false" Text="No Data" ForeColor="Red"
            Font-Bold="true"></asp:Label>
        <table border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <tbody>
                <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="simple">
                            <th style="width: 2%">
                                <strong>S.No. </strong>
                            </th>
                            <th align="center" style="width: 15%">
                                <strong>Type Name</strong>
                            </th>
                            <th align="center" style="width: 15%">
                                <strong>Bonus Type Description</strong>
                            </th>
                            <th align="center" style="width: 18%">
                                <strong>Bonus Line</strong>
                            </th>
                            <th align="center" style="width: 8%">
                                <strong>Action</strong>
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("BonusTypeName")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("BonusTypeDesc")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("BonusLine")%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnBonusTypeCode" runat="server" Value='<%# Eval("BonusTypeCode")%>' />
                                <a href="javascript:" runat="server" id="aIsChart">
                                    <asp:Label runat="server" ID="lblIsChart"></asp:Label>
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("BonusTypeName")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("BonusTypeDesc")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("BonusLine")%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnBonusTypeCode" runat="server" Value='<%# Eval("BonusTypeCode")%>' />
                                <a href="javascript:" runat="server" id="aIsChart">
                                    <asp:Label runat="server" ID="lblIsChart"></asp:Label>
                                </a>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
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
