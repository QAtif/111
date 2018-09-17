﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="headbar">
    </div>
    <div id="container" class="contentarea">
        <table>
            <tr>
                <td align="left" style="width: 23%">
                    <strong>Candidate Status</strong>
                </td>
                <td align="left" style="color: Blue">
                    <strong>
                        <asp:Label runat="server" ID="lblCandStatus"></asp:Label></strong>
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
                <td colspan="2" align="center" style="width: 28.2%">
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
                                                <asp:Repeater ID="rptQuestions" runat="server">
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
        <br />
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblTest" style="display: none">
            <thead>
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
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
                    </th>
                </tr>
            </thead>
        </table>
        <br />
    </div>
</asp:Content>
