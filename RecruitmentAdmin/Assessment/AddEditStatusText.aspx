<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="AddEditStatusText.aspx.cs" Inherits="AddEditStatusText" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function refreshParent(obj) {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
        }
       
    </script>
    <div class="head">
        <h2>
            Status Wise Area</h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="specialtab">
            <tbody>
                <tr id="trMessage" runat="server" align="center" class="grey">
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="red"></asp:Label>
                    </td>
                </tr>
                <tr class="grey">
                    <td colspan="2" align="center">
                        <asp:Label ID="lblStatusName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <strong>Status Name : </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtStatusName" runat="server" Width="500px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtStatusName" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <strong>Status Display Text : </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtStatusDisplayText" runat="server" Width="500px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtStatusDisplayText" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <strong>Meta Status : </strong>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlMetaStatus" runat="server" Width="500px">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="ddlMetaStatus" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <strong>Status Image : </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtStatusImage" runat="server" Width="500px"></asp:TextBox>

                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtStatusImage" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <strong>Area Text : </strong>
                    </td>
                    <td align="left">
                        <telerik:RadEditor runat="server" ID="txtName">
                            <Content>
        
                            </Content>
                            <ImageManager ViewPaths="/assets/Images" UploadPaths="/assets/Images" DeletePaths="~/Images/New/Articles,~/Images/New/News" />
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtName" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        <div align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
