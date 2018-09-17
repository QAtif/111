<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="QuestionType.aspx.cs" Inherits="QuestionType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Question Type Setup</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            <div style="width: 50%; float: right;" align="right">
                &nbsp;<a href="AddEditQuestionType.aspx" class="openframemini btn-ora" style="float: right;"><img
                    src="/assets/images/add-icon.png" alt="Add" title="Add" align="absmiddle" />&nbsp;&nbsp;Add
                    New Question Type</a></p></div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="10" cellspacing="0">
                        <thead>
                            <tr>
                                <th style="width: 10%">
                                    S.No.
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
                            <asp:Repeater ID="rptSection" runat="server" OnItemCommand="rptSection_ItemCommand" OnItemDataBound="rptSection_ItemDataBound">
                                <ItemTemplate>
                                    <tr class="simple">
                                        <td style="text-align: center">
                                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("QuestionTypeName")%>
                                            <asp:HiddenField ID="hfQuestionTypeCode" Value='<%# Eval("QuestionTypeCode") %>' runat="server" />
                                        </td>
                                      
                                        <td style="text-align: center">
                                             <a runat="server" id="btnEdit" class="openframemini">
                                                    <img src="/assets/images/icons/edit.png" /></a>
                                            <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                                AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("QuestionTypeCode") %>'
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
                                            <%# Eval("QuestionTypeName")%>
                                            <asp:HiddenField ID="hfQuestionTypeCode" Value='<%# Eval("QuestionTypeCode") %>' runat="server" />
                                        </td>                                       
                                        <td style="text-align: center">
                                            <a runat="server"  id="btnEdit" class="openframemini">
                                                    <img src="/assets/images/icons/edit.png" /></a>
                                            <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assets/images/icons/cancel.png"
                                                AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("QuestionTypeCode") %>'
                                                runat="server" />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
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
