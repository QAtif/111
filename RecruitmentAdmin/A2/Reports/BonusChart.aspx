<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="BonusChart.aspx.cs" Inherits="Candidate_BonusChart" %>
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
            Bonus Chart</h2>
    </div>
    
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px" class="table">
            <tr>
                <td style="width: 20%" align="center">
                    Select Domain:
                </td>
                <td style="width: 20%" align="center">
                    <asp:DropDownList ID="ddlDomain" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
                <td style="width: 20%" align="center">
                </td>
                <td style="width: 20%" align="center">
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" CssClass="ButtonsSave11" Text="Search"
                        OnClick="btnSearch_Click" />
                    <br />
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <asp:Label ID="lblMsg" runat="server" Visible="false" Text="No Data" ForeColor="Red"
            Font-Bold="true"></asp:Label>
        <table border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <tbody>
                <asp:DataList ID="rptDomain" runat="server" RepeatColumns="0" RepeatDirection="Horizontal"
                    RepeatLayout="Table" CellPadding="4" CellSpacing="5" OnItemDataBound="rptDomain_ItemDataBound">
                    <ItemTemplate>
                        <table border="1px; solid black">
                            <tr>
                                <td style="height: 25px;  text-align: center;">
                                    <asp:HiddenField ID="hdnDomainCode" runat="server" Value='<%# Eval("Domain_Code")%>' />
                                    <strong><%# Eval("Domain_Name")%></strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DataList ID="rptSubDomain" runat="server" RepeatColumns="0" RepeatDirection="Horizontal"
                                        RepeatLayout="Table" CellPadding="4" CellSpacing="5" OnItemDataBound="rptSubDomain_ItemDataBound">
                                        <ItemTemplate>
                                            <table border="1px; solid black">
                                                <tr>
                                                    <td style="height: 25px;  text-align: center;">
                                                        <asp:HiddenField ID="hdnSubDomainCode" runat="server" Value='<%# Eval("SubDomain_Code")%>' />
                                                        <strong><%# Eval("SubDomain_Name")%></strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DataList ID="rptCategory" runat="server" RepeatColumns="0" RepeatDirection="Horizontal"
                                                            RepeatLayout="Table" CellPadding="4" CellSpacing="5"  OnItemDataBound="rptCategory_ItemDataBound">
                                                            <ItemTemplate>
                                                                <table border="1px; solid black">
                                                                    <tr>
                                                                        <td colspan="2" style="height: 25px;  text-align: center;">
                                                                        <asp:HiddenField ID="hdnCategoryCode" runat="server" Value='<%# Eval("category_code")%>' />
                                                                            <strong><%# Eval("category_name")%></strong>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                             <asp:Repeater ID="rptGrade" runat="server" OnItemDataBound="rptGrade_ItemDataBound"
                                                                                >
                                                                                <ItemTemplate>
                                                                                   
                                                                                        <tr>
                                                                                            <td style="height: 25px;width:50px;color:White; background-color:#245E9C; text-align: center;" id="tdGrade" runat="server">
                                                                                                <strong><%# Eval("HRGrade_Description")%></strong>
                                                                                                 <asp:HiddenField ID="hdnHRGrade_ID" runat="server" Value='<%# Eval("HRGrade_ID")%>' />
                                                                                            </td>
                                                                                             <td style="height: 25px; background-color: #CCCCCC; text-align: center;">
                                                                                                <asp:TextBox runat="server" ID="txtAmount" Text='<%# Eval("Amount")%>'></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                   
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </tbody>
        </table>

         <table cellpadding="3px" class="table">
           
            <tr>
                <td  align="center" style="padding-top: 17px">
                    <asp:Button ID="Button1" runat="server" CssClass="ButtonsSave11" Text="Save" 
                        onclick="Button1_Click"/>
                    <br />
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
