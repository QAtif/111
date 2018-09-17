<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditTest.aspx.cs" Inherits="AddEditQuestion" %>

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
        function ShowOption(ddl1) {
            //alert(ddl1);
            var ddl = ddl1;
            //alert(ddl[ddl.selectedIndex].value);
            if (ddl[ddl.selectedIndex].value == "6") {
                document.getElementById('MainContent_trCaseStudy').style.display = "";

            }
            else {
                document.getElementById('MainContent_trCaseStudy').style.display = "none";
            }
        }


        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            return (charCode >= 48 && charCode <= 57);
        }
        function toggleCheck(id, checked) {
            var frm = document.getElementsByTagName('input')
            for (var i = 0; i < frm.length; i++)
                if (frm[i].id.indexOf(id) > -1 && frm[i].type == 'checkbox')
                    frm[i].checked = checked;
        }

    </script>
    <div class="head">
        <h2>
            Add/Edit New Test</h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="specialtab">
            <tbody>
                <tr id="trMessage" runat="server" align="center" class="grey">
                    <td colspan="4" align="center">
                        <asp:Label ID="lblMessage" runat="server" CssClass="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h2>
                            <strong>Test Information</strong></h2>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px">
                        <strong>Test Name : </strong>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtName" runat="server" Width="800px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Test Name"
                            ControlToValidate="txtName" ValidationGroup="btnSubmit" CssClass="red" Display="Dynamic"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="Tr1" runat="server" class="grey">
                    <td style="width: 250px">
                        <strong>Total Marks: </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTotalMarks" OnKeyPress="return isNumberKey(this);" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Total Marks"
                            ControlToValidate="txtTotalMarks" ValidationGroup="btnSubmit" CssClass="red"
                            Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 250px">
                        <strong>Min Passing Marks:</strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMinPassingMarks" OnKeyPress="return isNumberKey(this);" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Min Passing Marks"
                            ControlToValidate="txtMinPassingMarks" ValidationGroup="btnSubmit" CssClass="red"
                            Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px">
                        <strong>Max Time Of Test: </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMaxTimeOfTest" OnKeyPress="return isNumberKey(this);" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Max Time Of Test"
                            ControlToValidate="txtMaxTimeOfTest" ValidationGroup="btnSubmit" CssClass="red"
                            Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" colspan="2">
                        <strong>
                            <asp:CheckBox runat="server" ID="chkSectionTimeDependency" Text=" Is Section Time Dependency" /></strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <br />
                        <h2>
                            <strong>Add Section to Test</strong></h2>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="width: 250px">
                        <strong>Section : </strong>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList runat="server" ID="ddlSection" Width="222px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="grey" style="display: none" id="trQuestionGroup" runat="server">
                    <td style="width: 250px">
                        <strong>Case Study : </strong>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList runat="server" ID="ddlQuestionGroup" Width="222px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px">
                        <strong>Max Time For Section: </strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMaxTimeForSection" OnKeyPress="return isNumberKey(this);" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="btnAdd"
                            runat="server" ErrorMessage="Enter Max Time For Section" ControlToValidate="txtMaxTimeForSection"
                            CssClass="red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 250px">
                        <strong>Weightage of Each Section</strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtWeightageofEachSection" OnKeyPress="return isNumberKey(this);"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="btnAdd"
                            runat="server" ErrorMessage="Weightage of Each Section" ControlToValidate="txtWeightageofEachSection"
                            CssClass="red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="grey">
                    <td style="width: 250px">
                        <strong>Min. No of Questions</strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMinNoofQuestions" OnKeyPress="return isNumberKey(this);" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="btnAdd"
                            runat="server" ErrorMessage="Min. No of Questions" ControlToValidate="txtMinNoofQuestions"
                            CssClass="red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 250px">
                        <strong>Random Questions : </strong>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtRandomQuestions" OnKeyPress="return isNumberKey(this);" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="btnAdd"
                            runat="server" ErrorMessage="Random Questions" ControlToValidate="txtRandomQuestions"
                            CssClass="red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trCaseStudy" runat="server" style="display: none">
                    <td style="width: 250px">
                        Case Study :&nbsp;
                    </td>
                    <td align="left" colspan="3">
                        <telerik:RadEditor runat="server" ID="txtCaseStudy" Width="808px" Height="600">
                            <Content>
                            </Content>
                            <ImageManager ViewPaths="/assets/Images" UploadPaths="/assets/Images" DeletePaths="~/Images/New/Articles,~/Images/New/News" />
                        </telerik:RadEditor>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <strong>Select Questions</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>
                            <asp:CheckBox ID="chkSelectAll" runat="server" Text=" Select All" onclick="toggleCheck('chkQuestion', this.checked);" /></b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList runat="server" TextAlign="Right" ID="chkQuestion">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="trAdd" runat="server">
                    <td align="center" colspan="4">
                        <asp:Button ID="btnOptionAdd" runat="server" ValidationGroup="btnAdd" Text="Add Section"
                            CssClass="btn-ora nl" OnClick="btnOptionAdd_Click" />
                    </td>
                </tr>
                <tr runat="server" id="SearchCategoryOptions2">
                    <td colspan="4">
                        <asp:Repeater ID="rptSection" runat="server" OnItemDataBound="rptSection_ItemDataBound">
                            <ItemTemplate>
                                <tr class="grey">
                                    <td width="10%">
                                        <strong>Section :
                                            <asp:Label runat="server" ID="lblSectionName" Text=' <%# Eval("SectionName")%>'></asp:Label></strong>
                                        <asp:HiddenField runat="server" ID="hdnSectionCode" Value='<%# Eval("SectionCode")%>'>
                                        </asp:HiddenField>
                                        <asp:HiddenField runat="server" ID="hdnMaxTimeForSection" Value='<%# Eval("MaxTimeForSection")%>'>
                                        </asp:HiddenField>
                                        <asp:HiddenField runat="server" ID="hdnWeightageofEachSection" Value='<%# Eval("WeightageofEachSection")%>'>
                                        </asp:HiddenField>
                                         <asp:HiddenField runat="server" ID="hdnRandomQuestions" Value='<%# Eval("RandomQuestions")%>'>
                                        </asp:HiddenField>
                                    </td>
                                    <td width="30%">
                                        Max. Time:
                                        <%# Eval("MaxTimeForSection")%>
                                    </td>
                                    <td colspan="2" width="30%">
                                        Weightage :
                                        <%# Eval("WeightageofEachSection")%>
                                    </td>
                                </tr>
                                <tr class="grey" runat="server" id="trQuestionGroup" style="display:none">
                                    <td colspan="3">
                                        <asp:HiddenField runat="server" ID="hdnQuestionGroupCode" Value='<%# Eval("QuestionGroupCode")%>'>
                                        </asp:HiddenField>
                                        <asp:Literal runat="server" ID="ltrQuestionGroupName" Text=' <%# Eval("QuestionGroupName")%>'></asp:Literal>
                                       

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <p>
                                            <asp:Repeater ID="rptOptions" runat="server" OnItemCommand="rptOptions_ItemCommand">
                                                <HeaderTemplate>
                                                    <table width="50%" cellspacing="0" cellpadding="0" border="0" style="background-color: White">
                                                        <tr>
                                                            <td>
                                                                <strong>S.No</strong>
                                                            </td>
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
                                                        <td>
                                                            <strong>
                                                                <%#Container.ItemIndex + 1 %></strong>
                                                        </td>
                                                        <td width="70%">
                                                            <strong>
                                                                <asp:Label runat="server" ID="lblQuestionName" Text='<%# Eval("QuestionName")%>'></asp:Label></strong>
                                                            <asp:HiddenField runat="server" ID="hdnQuestionCode" Value='<%# Eval("QuestionCode")%>'>
                                                            </asp:HiddenField>
                                                            <asp:HiddenField runat="server" ID="hdnIsNew" Value='<%# Eval("IsNew")%>'></asp:HiddenField>
                                                            <asp:HiddenField runat="server" ID="hdnTestDetailCode" Value='<%# Eval("TestDetailCode")%>'>
                                                            </asp:HiddenField>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are You Sure you want to delete?')"
                                                                CommandName="Delete" CommandArgument='<%# Eval("QuestionCode")%>' ImageUrl="/assets/images/icons/cross.gif" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </p>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
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
            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="btnSubmit" Text="Submit"
                CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
