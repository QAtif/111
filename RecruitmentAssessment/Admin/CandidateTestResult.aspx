<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CandidateTestResult.aspx.cs" Inherits="CandidateTestResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 <title>Candidate Test Result</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="head">
        <h2>
            <span>Candidate Test Result</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="10" cellspacing="0">
                        <thead>
                            <tr>
                                <th style="width: 5%" align="center">
                                    S.No.
                                </th>
                                <th align="left" colspan="2">
                                    Question
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptQuestion" runat="server" OnItemDataBound="rptQuestion_ItemDataBound">
                                <ItemTemplate>
                                    <p>
                                        <tr class="grey">
                                            <td style="width: 5%"  align="center">
                                                <strong>
                                                    <%#Container.ItemIndex + 1 %></strong>
                                            </td>
                                            <td colspan="2">
                                                <strong>
                                                    <asp:Literal runat="server" ID="ltrQuestion" Text='<%# Eval("QuestionName")%>'></asp:Literal></strong>
                                                <asp:HiddenField runat="server" ID="hdnQuestionCode" Value='<%# Eval("QuestionCode")%>'>
                                                </asp:HiddenField>
                                                <asp:HiddenField runat="server" ID="hdnSectionCode" Value='<%# Eval("SectionCode")%>'>
                                                </asp:HiddenField>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Repeater ID="rptOptions" runat="server" OnItemDataBound="rptOptions_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="width: 10%"  align="right">
                                                                Answer:
                                                            </td>
                                                            <td style="width: 80%">
                                                                <asp:Literal runat="server" ID="ltrAnswer"></asp:Literal>
                                                            </td>
                                                            <td style="width: 10%">
                                                                <img alt="" height="30" src="/assets/images/icons/success.png" runat="server"
                                                                    id="imgStatus" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </p>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
       
    </div>
</asp:Content>
