<%@ Page Language="C#" AutoEventWireup="true" CodeFile="downloadreport.aspx.cs" Inherits="xprotect_downloadreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Download Data Report</title>
    <style type="text/css">
        body
        {
            font-family: Calibri;
            font-size: 14px;
        }
        .rowclass
        {
        }
        .headclass
        {
            background-color: ActiveBorder;
            font-size: 16px;
            border-color: Green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" id="divLogin" runat="server">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td>
                    <b>Login ID : </b>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtLogin" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvlogin" runat="server" ValidationGroup="A" ControlToValidate="txtLogin"
                        Style="font-size: 10px;" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td>
                    <b>Password : </b>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvpass" runat="server" ValidationGroup="A" ControlToValidate="txtPass"
                        Style="font-size: 10px;" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="100px" OnClick="btnLogin_Click"
                        ValidationGroup="A" />
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div align="center" id="divData" runat="server" visible="false">
    <div style="font-size: 18px; font-weight: bold; color: Teal; padding-bottom: 10px;  ">
   Total Count : <%=objDS.Tables[0].Rows.Count %>
 <input type="button" value="Refresh" onclick="window.location.href = window.location.href " />
       </div>
        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="true" HeaderStyle-CssClass="headclass"
            RowStyle-CssClass="rowclass" AlternatingRowStyle-CssClass="rowclass" CellPadding="5">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
