<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MarkShortListCandidate.aspx.cs" Inherits="Requisition_MarkShortListCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>List of Requisitions</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="8">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th style="background-color: Black;" height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                        Font-color="white" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                        Visible="False">&lt;&lt;</asp:LinkButton>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex"
                                            runat="server" Text="Label" Visible="False" ForeColor="White"></asp:Label>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr class="simple">
                    <th style="width: 2%">
                        S.No.
                    </th>
                    <th align="left" style="width: 10%">
                        Requisition Name
                    </th>
                    <th align="left" style="width: 15%">
                        Raised By
                    </th>
                    <th align="left" style="width: 15%">
                        Profile Name
                    </th>
                    <th align="left" style="width: 15%">
                        Sub Domain
                    </th>
                    <th align="left" style="width: 10%">
                        No. Of Candidates Required
                    </th>
                    <th align="left" style="width: 2%">
                        Priority
                    </th>
                    <th align="left" style="width: 10%">
                        No. Of Candidates to be Shortlisted
                    </th>
                    <th align="left" style="width: 15%">
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptRequisitionLists" runat="server" OnItemDataBound="rptRequisitionLists_ItemDataBound"
                    OnItemCommand="rptRequisitionLists_ItemCommand">
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value='<%# Eval("Requisition_Code")%>' />
                                <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Requisition_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Raised_By")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Quantity")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Priority")%>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("ShortList_Count")%>'></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <a id="aViewCandidate" runat="server" class="openframe">Mark Candidates</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value='<%# Eval("Requisition_Code")%>' />
                                <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Requisition_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Raised_By")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("SubDomain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Quantity")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Priority")%>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("ShortList_Count")%>'></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <a id="aViewCandidate" runat="server" class="openframe">Mark Candidates</a>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
