<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Test Setup</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left">
            <div style="width: 50%; float: right;" align="right">
                &nbsp;<a href="AddEditTest.aspx" class="openframelarge btn-ora" style="float: right;"><img
                    src="/assetsprocurement/images/add-icon.png" alt="Add" title="Add" align="absmiddle" />&nbsp;&nbsp;Add
                    New Test</a></p></div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="10" cellspacing="0">
                        <thead>
                            <tr>
                                <th style="width: 10%">
                                    S.No.
                                </th>
                                <th align="left">
                                    Test Name
                                </th>
                                <th align="left">
                                    Total Marks
                                </th>
                                <th align="left">
                                    Min. Marks
                                </th>
                                 <th align="left">
                                    Max. Time
                                </th>
                                
                                <th style="width: 10%">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptTest" runat="server" OnItemCommand="rptTest_ItemCommand" OnItemDataBound="rptTest_ItemDataBound">
                                <ItemTemplate>
                                    <tr class="simple">
                                        <td style="text-align: center">
                                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TestName")%>
                                            <asp:HiddenField ID="hfTestCode" Value='<%# Eval("TestCode") %>' runat="server" />
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TotalMarks")%>
                                            
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("MinPassingMarks")%>
                                            
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("MaxTimeOfTest")%>
                                            
                                        </td>
                                      
                                        <td style="text-align: center">
                                             <a runat="server" id="btnEdit" class="openframelarge">
                                                    <img src="/assetsprocurement/images/icons/edit.png" /></a>
                                            <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assetsprocurement/images/icons/cancel.png"
                                                AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("TestCode") %>'
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
                                            <%# Eval("TestName")%>
                                            <asp:HiddenField ID="hfTestCode" Value='<%# Eval("TestCode") %>' runat="server" />
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("TotalMarks")%>
                                            
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("MinPassingMarks")%>
                                            
                                        </td>
                                        <td style="text-align: left">
                                            <%# Eval("MaxTimeOfTest")%>
                                            
                                        </td>
                                      
                                        <td style="text-align: center">
                                             <a runat="server" id="btnEdit" class="openframelarge">
                                                    <img src="/assetsprocurement/images/icons/edit.png" /></a>
                                            <asp:ImageButton CssClass="button" ID="btnDelete" ImageUrl="/assetsprocurement/images/icons/cancel.png"
                                                AlternateText="Delete" CommandName="Delete" CommandArgument='<%#Eval("TestCode") %>'
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
