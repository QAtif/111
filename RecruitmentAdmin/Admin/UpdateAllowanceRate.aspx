<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="UpdateAllowanceRate.aspx.cs" Inherits="Admin_UpdateAllowanceRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
<style>
.ButtonsSave11 {
cursor: pointer;
background: linear-gradient(to bottom, #4B8EFC 0%, #4787EE 100%) !important;
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important;
border: 1px solid #3079ED !important;
color: #FFF;
padding: 4px 27px;
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White;padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;
        width: 70%; margin-left: auto; margin-right: auto"">
        <h2>
           Update Allowance 
        </h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;
        width: 70%; margin-left: auto; margin-right: auto"">
        <table>
            <tr><td colspan="2" align="center"><asp:Label ID="lblMsg" runat="server" Visible="false" Text="No Data" ForeColor="Red"
            Font-Bold="true"></asp:Label></td></tr>
            <tr>
                <td>
                    Fuel Rate:
                </td>
                <td>
                    <asp:TextBox ID="txtFuelRate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtFuelRate" ErrorMessage="*" ID="rfv1"
                        runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Mineral Watar Rate:
                </td>
                <td>
                    <asp:TextBox ID="txtMineralwater" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtMineralwater" ErrorMessage="*"
                        ID="rfv2" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                   <div id="divAction140" runat="server" visible="true" clientidmode="Static">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSearch_Click" CssClass="ButtonsSave11" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
