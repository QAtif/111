<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CheckTest.aspx.cs" Inherits="Admin_CheckTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%--<script type="text/javascript" src="/Scripts/jquery-1.6.4.min.js"></script>--%>
    <style type="text/css">
        .heading
        {
            background: url("/images/banacc-bg.gif") repeat-x scroll 0 0 transparent;
            color: #000000;
            font: 14px 'MyriadProSemibold';
            cursor: pointer;
        }
        .bor
        {
            border-right: 1px;
            border-color: Gray;
            border-style: solid;
        }
        .bol
        {
            border-left: 1px;
            border-color: Gray;
            border-style: solid;
        }
        .bob
        {
            border-bottom: 1px;
            border-color: Gray;
            border-style: solid;
        }
        .style1
        {
            height: 21px;
        }
    </style>
    <script type="text/javascript">
        function ToggleRecord(id) {
            $('#' + id).toggle();
        }

        function isNumberKey(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        
    </script>
    <title>Candidate Check Test</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
    </div>
    <div id="container" class="contentarea">
        <table>
            <tr class="simple">
                <td align="left" style="width: 15%">
                    <strong>Name</strong>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label runat="server" ID="lblName"></asp:Label>
                </td>
                <td align="left" style="width: 15%">
                    <strong>Reference No.</strong>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label runat="server" ID="lblReferenceNo"></asp:Label>
                </td>
            </tr>
            <tr class="grey">
                <td align="left" style="width: 15%">
                    <strong>Email</strong>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label runat="server" ID="lblEmailAddress"></asp:Label>
                </td>
                <td align="left" style="width: 15%">
                    <strong>Candidate Status</strong>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label runat="server" ID="lblCandStatus"></asp:Label>
                </td>
            </tr>
            <tr class="simple">
                <td align="left" style="width: 15%">
                    <strong>Category</strong>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label runat="server" ID="lblCategory"></asp:Label>
                </td>
                <td align="left" style="width: 15%">
                    <strong>Sub Domain</strong>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label runat="server" ID="lblSubDomain"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="6">
                    <asp:Repeater ID="rptQuestionGroup" OnItemDataBound="rptQuestionGroup_ItemDataBound"
                        runat="server">
                        <HeaderTemplate>
                            <table width="100%" cellpadding="4" cellspacing="1">
                                <tr>
                                    <td colspan="6" align="center">
                                        <strong style="font-size: 14px">Section Summary </strong>
                                    </td>
                                </tr>
                                <tr class="grey">
                                    <td align="center">
                                        <strong>S.No </strong>
                                    </td>
                                    <td>
                                        <strong>Name </strong>
                                    </td>
                                    <td align="center">
                                        <strong>Correct </strong>
                                    </td>
                                    <td align="center">
                                        <strong>Wrong </strong>
                                    </td>
                                    <td align="center">
                                        <strong>Pending </strong>
                                    </td>
                                    <td align="center">
                                        <strong>Total </strong>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdfQuestionGroupCode" runat="server" Value='<%#Eval("QuestionGroupCode") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hdfSectionCode" runat="server" Value='<%#Eval("SectionCode") %>'>
                                    </asp:HiddenField>
                                    <asp:Label runat="server" Text='<%#Eval("QuestionGroupName") %>' ID="lblSection"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblCorrect"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblWrong"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblPending"></asp:Label>
                                </td>
                                <td align="center">
                                    <a runat="server" id="lnkTotal" target="_blank">
                                        <asp:Label runat="server" ID="lblTotal"></asp:Label></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="grey">
                                <td align="center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdfQuestionGroupCode" runat="server" Value='<%#Eval("QuestionGroupCode") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hdfSectionCode" runat="server" Value='<%#Eval("SectionCode") %>'>
                                    </asp:HiddenField>
                                    <asp:Label runat="server" Text='<%#Eval("QuestionGroupName") %>' ID="lblSection"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblCorrect"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblWrong"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblPending"></asp:Label>
                                </td>
                                <td align="center">
                                    <a runat="server" id="lnkTotal" target="_blank">
                                        <asp:Label runat="server" ID="lblTotal"></asp:Label></a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr class="white">
                <td colspan="2" align="center" style="width: 20.5%">
                </td>
                <td align="center" style="width: 7.5%">
                    <strong>
                        <asp:Label runat="server" ID="lblCorrect"></asp:Label></strong>
                </td>
                <td align="center" style="width: 7%">
                    <strong>
                        <asp:Label runat="server" ID="lblWrong"></asp:Label></strong>
                </td>
                <td align="center" style="width: 8%">
                    <strong>
                        <asp:Label runat="server" ID="lblPending"></asp:Label></strong>
                </td>
                <td align="center" style="width: 6%">
                    <strong>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label></strong>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblQA">
            <tr>
                <td align="center">
                    <strong style="font-size: 14px">QA Recordings </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <asp:Repeater ID="rptFile" runat="server" OnItemDataBound="rptFile_ItemDataBound">
                            <HeaderTemplate>
                                <table width="50%" cellspacing="0" cellpadding="0" border="0" style="background-color: White">
                                    <tr>
                                        <td>
                                            <strong>File</strong>
                                        </td>
                                        <td>
                                            <strong>Comments</strong>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td width="30%" align="left">
                                        <strong><a runat="server" id="lnkFile"></a></strong>
                                        <asp:HiddenField runat="server" ID="hdnCandidateCode" Value='<%# Eval("Candidate_Code")%>'>
                                        </asp:HiddenField>
                                    </td>
                                    <td width="70%" align="left">
                                        <asp:Literal runat="server" ID="lblIsCorrect" Text='<%# Eval("Comments")%>'></asp:Literal>
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
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td width="83%" align="left">
                    <asp:HiddenField ID="hdfCandidateTestCode" runat="server"></asp:HiddenField>
                    <asp:Repeater ID="rptSection" runat="server" OnItemDataBound="rptSection_ItemDataBound">
                        <HeaderTemplate>
                            <table width="100%" cellpadding="4" cellspacing="0">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="trHeading" runat="server" class="grey">
                                <td class="heading" colspan="4">
                                    <asp:HiddenField ID="hdfSectionCode" runat="server" Value='<%#Eval("SectionCode") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hdfCandidateTestSectionCode" runat="server" Value='<%#Eval("CandidateTestSectionCode") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hdfQuestionGroupCode" runat="server" Value='<%#Eval("QuestionGroupCode") %>'>
                                    </asp:HiddenField>
                                    <strong>
                                        <asp:Label Font-Size="16px" ID="lblQuestionGroupName" runat="server" Text='<%#Eval("QuestionGroupName") %>'></asp:Label></strong>
                                </td>
                            </tr>
                            <tr id="trDetail" runat="server" style="display: none">
                                <td colspan="4">
                                    <table width="100%" cellpadding="4" cellspacing="0">
                                        <tr>
                                            <td colspan="4">
                                                <asp:Repeater ID="rptQuestions" runat="server" OnItemCommand="rptQuestions_CommandArguments">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="4" cellspacing="1">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:HiddenField ID="hdfCandidateTestDetailCode" runat="server" Value='<%#Eval("CandidateTestDetailCode") %>' />
                                                                <asp:HiddenField ID="hdfQuestionCode" runat="server" Value='<%#Eval("QuestionCode") %>' />
                                                                <asp:Literal ID="ltrQuestionName" runat="server" Text='<%#Eval("QuestionName") %>'></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Answer : <a runat="server" href='<%#Eval("FileAttachment") %>' id="lnkFile">View Submitted
                                                                    File</a>

                                                                <div id="divAction116" runat="server" style="text-align: left" clientidmode="Static"
                                                                    visible="false">
                                                                    <br />
                                                                    Edit File: <asp:FileUpload ID="fuDocument" runat="server" Width="251px" />
                                                                    <asp:RequiredFieldValidator runat="server" ID="rqdRequired" Display="Dynamic" ErrorMessage="Please provide answer"
                                                            ControlToValidate="fuDocument" SetFocusOnError="true" ValidationGroup="signUp" ForeColor="Red">Please provide File</asp:RequiredFieldValidator>

                                                                    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="signUp" CommandName="SaveFile" CommandArgument='<%#Eval("CandidateTestDetailCode") %>' Text="Save" CssClass="btn-ora nl"/>


                                                                </div>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:DropDownList runat="server" ID="ddlQuestionResult">
                                                                    <asp:ListItem Text="Correct" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Wrong" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr class="grey">
                                                            <td>
                                                                Marks :
                                                                <asp:TextBox runat="server" ID="txtSectionMarks" onkeypress="return isNumberKey(event)"
                                                                    MaxLength="3"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                Comments :
                                                                <asp:TextBox runat="server" ID="txtSectionComments" TextMode="MultiLine" Rows="3"
                                                                    Columns="4"></asp:TextBox>
                                                                <br />
                                                                <br />
                                                            </td>
                                                            <td colspan="3">
                                                                Section Result :
                                                                <asp:DropDownList runat="server" ID="ddlSectionResult">
                                                                    <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <br />
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblComments"
            style="display: none">
            <tr class="grey">
                <td>
                    <strong>Users</strong>
                </td>
                <td>
                    <strong>Status</strong>
                </td>
                <td>
                    <strong>Comments</strong>
                </td>
                <td>
                    <strong>Plagiarism</strong>
                </td>
                <td>
                    <strong>Grammer</strong>
                </td>
                <td>
                    <strong>Compliance</strong>
                </td>
            </tr>
            <tr runat="server" id="trRA">
                <td>
                    <asp:Label runat="server" ID="lblRA"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblRAStatus"></asp:Label>
                </td>
                <td align="left">
                    <asp:Literal runat="server" ID="ltrRAComments"></asp:Literal>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblPlagiarism"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblGrammer"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblCompliance"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trRec" class="grey">
                <td>
                    <asp:Label runat="server" ID="lblRec"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblRECStatus"></asp:Label>
                </td>
                <td colspan="4" align="left">
                    <asp:Literal runat="server" ID="ltrRECComments"></asp:Literal>
                </td>
            </tr>
            <tr runat="server" id="trDomainOwner">
                <td>
                    <asp:Label runat="server" ID="lblDomainOwner"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblDomainOwnerStatus"></asp:Label>
                </td>
                <td colspan="4" align="left">
                    <asp:Literal runat="server" ID="ltrDomainOWnerComments"></asp:Literal>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblContentRA"
            style="display: none">
            <tr class="grey">
                <td colspan="6">
                    <strong>Reporting Authority Action</strong>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Plagiarism Ratio
                </td>
                <td align="left">
                    <asp:TextBox runat="server" Widtd="50px" MaxLengtd="5" ID="txtPlagiarism"></asp:TextBox>
                </td>
                <td align="right">
                    Grammer
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlGrammer">
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="B" Value="B"></asp:ListItem>
                        <asp:ListItem Text="C" Value="C"></asp:ListItem>
                        <asp:ListItem Text="F" Value="F"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    Compliance
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlCompliance">
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="B" Value="B"></asp:ListItem>
                        <asp:ListItem Text="C" Value="C"></asp:ListItem>
                        <asp:ListItem Text="F" Value="F"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="grey">
                <td align="right">
                    Comments
                </td>
                <td align="left">
                    <asp:TextBox runat="server" TextMode="MultiLine" MaxLengtd="500" ID="txtRAComments"
                        Rows="5"></asp:TextBox>
                </td>
                <td align="right">
                    Test Status
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlRATestResult">
                        <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="center" colspan="2">
                    <asp:Button ID="btnRA" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblContentREC"
            style="display: none">
            <tr class="grey">
                <td colspan="4">
                    <strong>Recruiter Action</strong>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Comments
                </td>
                <td align="left">
                    <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="500" ID="txtRECComments"
                        Rows="5"></asp:TextBox>
                </td>
                <td align="right">
                    Test Status
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlRECTestResult">
                        <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="center" colspan="2">
                    <asp:Button ID="btnRec" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="btnRec_Click" />
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblContentDomainOwner"
            style="display: none">
            <tr class="grey">
                <td colspan="6">
                    <strong>Domian Owner Action</strong>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Comments
                </td>
                <td align="left">
                    <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="500" ID="txtDomainOwnerComments"
                        Rows="5"></asp:TextBox>
                </td>
                <td align="right">
                    Test Status
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlDomainOwnerTestResult">
                        <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDomainOwner" runat="server" Text="Save" CssClass="btn-ora nl"
                        OnClick="btnDomainOwner_Click" />
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblTest" style="display: none">
            <tr>
                <th style="width: 10%">
                    Test Result
                </th>
                <th align="left">
                    <asp:DropDownList runat="server" ID="ddlTestResult">
                        <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-ora" OnClick="btnSubmit_Click" />
                </th>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
