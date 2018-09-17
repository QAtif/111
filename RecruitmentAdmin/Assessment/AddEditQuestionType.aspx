<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditQuestionType.aspx.cs" Inherits="AddEditQuestionType" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <script type="text/javascript">
        function refreshParent(obj) {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
        }


        

    </script>
    <div class="head">
        <h2>Add New QuestionType</h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="specialtab">
            <tbody>
                <tr id="trMessage" runat="server" align="center" class="grey">
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Question Type : </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
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
            <asp:Button ID="btnSubmit" runat="server" Text="Finish" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
