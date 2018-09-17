<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="QuestionGroupAddEditQuestion.aspx.cs" Inherits="QuestionGroupAddEditQuestion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function refreshParent(obj) {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
        }
        function ShowOption(ddl1) {
            //alert(ddl1);
            var ddl = ddl1;
            //alert(ddl[ddl.selectedIndex].value);
            if (ddl[ddl.selectedIndex].value == "2") 
            {
                document.getElementById('MainContent_trBlank').style.display = "";
                document.getElementById('MainContent_trOption').style.display = "none";
                document.getElementById('MainContent_trIsCorrect').style.display = "none";
                document.getElementById('MainContent_trAdd').style.display = "none";
                document.getElementById('MainContent_trBrowseFile').style.display = "none";

            }
            if (ddl[ddl.selectedIndex].value == "4") {
                document.getElementById('MainContent_trBlank').style.display = "none";
                document.getElementById('MainContent_trOption').style.display = "none";
                document.getElementById('MainContent_trIsCorrect').style.display = "none";
                document.getElementById('MainContent_trAdd').style.display = "none";
                document.getElementById('MainContent_trBrowseFile').style.display = "";

            }
            if (ddl[ddl.selectedIndex].value == "1" || ddl[ddl.selectedIndex].value == "3") {
                document.getElementById('MainContent_trBlank').style.display = "none";
                document.getElementById('MainContent_trOption').style.display = "";
                document.getElementById('MainContent_trIsCorrect').style.display = "";
                document.getElementById('MainContent_trAdd').style.display = "";
                document.getElementById('MainContent_trBrowseFile').style.display = "none";
            }
        }

    </script>
    <div class="head">
        <h2>
            Add New Question</h2>
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
                    <td style="width: 200px">
                        <strong>Section : </strong>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlSection" Width="222px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr >
                    <td style="width: 200px">
                        <strong>Case Study : </strong>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlQuestionGroup" Width="222px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <strong>Question : </strong>
                    </td>
                    <td align="left">
                        <telerik:radeditor runat="server" ID="txtName" > 
   <Content>
        
   </Content>
    <ImageManager ViewPaths="/assets/Images" UploadPaths="/assets/Images" DeletePaths="~/Images/New/Articles,~/Images/New/News" />
    
</telerik:radeditor>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtName" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="width: 200px">
                        <strong>Question Type : </strong>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlQuestionType" Width="222px" onChange="ShowOption(this);">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trOption" runat="server">
                    <td style="width: 200px">
                        <strong>Option : </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtOption" TextMode="MultiLine" Rows="3" Columns="2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trBlank" runat="server" style="display: none">
                    <td style="width: 200px">
                        <strong>Answer : </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtblank" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trBrowseFile" runat="server" style="display: none">
                    <td style="width: 200px">
                        Browse File :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fuDocument" runat="server" Width="251px" />
                        <a id="lnkView" href="" runat="server"></a>
                    </td>
                </tr>
                <tr id="trIsCorrect" runat="server">
                    <td style="width: 200px">
                    </td>
                    <td align="left">
                        <asp:CheckBox runat="server" ID="chkIsCorrect" Text=" Is Correct" />
                    </td>
                </tr>
                <tr id="trAdd" runat="server">
                    <td align="center" colspan="2">
                        <asp:Button ID="btnOptionAdd" runat="server" Text="Add Option" CssClass="btn-ora nl"
                            OnClick="btnOptionAdd_Click" />
                    </td>
                </tr>
                <tr runat="server" id="SearchCategoryOptions2">
                    <td colspan="2">
                        <p>
                            <asp:Repeater ID="rptOptions" runat="server" OnItemCommand="rptOptions_ItemCommand">
                                <HeaderTemplate>
                                    <table width="50%" cellspacing="0" cellpadding="0" border="0" style="background-color: White">
                                        <tr>
                                            <td>
                                                <strong>Answer</strong>
                                            </td>
                                            <td>
                                                <strong>IsCorrect</strong>
                                            </td>
                                            <td>
                                                <strong>Action</strong>
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td width="70%">
                                            <strong>
                                                <asp:Label runat="server" ID="lblAnswer" Text='<%# Eval("QuestionOptionDesc")%>'></asp:Label></strong>
                                            <asp:HiddenField runat="server" ID="hdnQuestionOptionCode" Value='<%# Eval("QuestionOptionCode")%>'>
                                            </asp:HiddenField>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblIsCorrect" Text='<%# Eval("IsCorrect")%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are You Sure you want to delete?')"
                                                CommandName="Delete" CommandArgument='<%# Eval("QuestionOptionCode")%>' ImageUrl="/assets/images/icons/cross.gif" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </p>
                        <p>
                            &nbsp;
                        </p>
                        <p>
                            &nbsp;
                        </p>
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
