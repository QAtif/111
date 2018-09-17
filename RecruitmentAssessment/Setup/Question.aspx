<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Question.aspx.cs" Inherits="Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Question Setup</span>
        </h2>
        <div align="left">
            <div style="width: 50%; float: right;" align="right">
                &nbsp;<a href="AddEditQuestion.aspx" class="openframelarge btn-ora" style="float: right;">&nbsp;&nbsp;Add
                    New Question </a></p></div>
        </div>
    </div>
    <div id="container" class="contentarea">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr>
                            <th style="width: 10%">
                                S.No.
                            </th>
                            <th align="left">
                                Question
                            </th>
                            <th align="left">
                                Section
                            </th>
                            <th align="left">
                                Question Type
                            </th>
                            <th style="width: 10%">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptSection" runat="server" OnItemCommand="rptSection_ItemCommand"
                            OnItemDataBound="rptSection_ItemDataBound">
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("QuestionName")%>
                                        <asp:HiddenField ID="hfQuestionCode" Value='<%# Eval("QuestionCode") %>' runat="server" />
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("SectionName")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("QuestionTypeName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a runat="server" id="btnEdit" class="openframelarge">
                                            <img src="/assets/images/icons/edit.png" /></a>
                                        <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                            AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("QuestionCode") %>'
                                            runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("QuestionName")%>
                                        <asp:HiddenField ID="hfQuestionCode" Value='<%# Eval("QuestionCode") %>' runat="server" />
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("SectionName")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("QuestionTypeName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a runat="server" id="btnEdit" class="openframelarge">
                                            <img src="/assets/images/icons/edit.png" /></a>
                                        <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                            AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("QuestionCode") %>'
                                            runat="server" />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table border="0" cellpadding="5" cellspacing="0" class="none">
                    <tr class="simple" id="trPagingControls" runat="server" align="center">
                        <td bgcolor="#EFEFEF" style="text-align: center;" width="100%">
                            <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False"><img src="/assets/images/icons/first.png" alt="First Page" /></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True" Font-Underline="False"
                                ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click" Visible="False"><img src="/assets/images/icons/left.png" alt="Previous Page" /></asp:LinkButton>&nbsp;
                            &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
                            &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                                ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False"><img src="/assets/images/icons/right.png" alt="Next Page" /></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                                ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False"><img src="/assets/images/icons/last.png" alt="Last Page" /></asp:LinkButton>&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
