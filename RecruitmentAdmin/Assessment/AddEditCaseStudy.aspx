<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditCaseStudy.aspx.cs" Inherits="AddEditCaseStudy" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
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
            if (ddl[ddl.selectedIndex].value == "2") {
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
            Add/Edit Case Study</h2>
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
                <tr>
                    <td style="width: 200px">
                        <strong>Case Study : </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" Width="500px" MaxLength="500" ID="txtName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtName" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="width: 200px">
                        <strong>Details: </strong>
                    </td>
                    <td align="left">
                        <telerik:RadEditor runat="server" ID="txtCaseStudy">
                            <Content>
        
                            </Content>
                            <ImageManager ViewPaths="/assets/Images" UploadPaths="/assets/Images" DeletePaths="~/Images/New/Articles,~/Images/New/News" />
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="txtCaseStudy" CssClass="red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                 <tr id="trBrowseFile" runat="server" >
                    <td style="width: 200px">
                        Browse File :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fuDocument" runat="server" Width="251px" />
                        <a id="lnkView" href="" runat="server"></a>
                    </td>
                </tr>
            </tbody>
        </table>

        <div align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />

            <a runat="server" id="btnAdd" class="openframelarge" style="display:none">
                                                    <img src="/assets/images/icons/Add.png" /> Add Questions to this Case Study</a>
        </div>

        <table width="100%" border="0" cellspacing="0" cellpadding="0" >
            <tbody>
                <tr runat="server" id="SearchCategoryOptions2" class="grey">
                    <td colspan="2">
                        <p>
                            <asp:Repeater ID="rptOptions" OnItemDataBound="rptOptions_ItemDataBound" runat="server" OnItemCommand="rptOptions_ItemCommand">
                                <HeaderTemplate>
                                    <table width="50%" cellspacing="0" cellpadding="0" border="0" style="background-color: White">
                                        <tr>
                                            <td>
                                                <strong>Question</strong>
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
                                            <a runat="server" class="openframelarge" id="lnkQuestion">
                                                <asp:Literal runat="server" ID="lblAnswer" Text='<%# Eval("QuestionName")%>'></asp:Literal></a></strong>
                                            <asp:HiddenField runat="server" ID="hdnQuestionCode" Value='<%# Eval("QuestionCode")%>'>
                                            </asp:HiddenField>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are You Sure you want to delete?')"
                                                CommandName="Delete" CommandArgument='<%# Eval("QuestionCode")%>' ImageUrl="/assets/images/icons/cross.gif" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </p>
                        
                    </td>
                </tr>
            </tbody>
        </table>
        
    </div>
    
</asp:Content>
