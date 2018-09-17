<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CandidatesList__BK.aspx.cs" Inherits="Candidate_CandidatesList__BK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidates List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>List of Candidates</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="11">
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
                <tr>
                    <th style="width: 10%">
                        S.No.
                    </th>
                    <th align="left">
                        Full Name
                    </th>
                    <th align="left">
                        Email Address
                    </th>
                    <th align="left">
                        Date Of Birth
                    </th>
                    <th align="left">
                        NIC
                    </th>
                    <th align="left">
                        Gender
                    </th>
                    <th align="left">
                        Phone Number
                    </th>
                    <th align="left">
                        Religon
                    </th>
                    <th align="left">
                        MaritalStatus
                    </th>
                    <th align="left">
                        Nationality
                    </th>
                    <th align="left">
                        Address
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptCandidateLists" runat="server" OnItemDataBound="rptCandidateLists_ItemDataBound">
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                <a id="aCandidateLink" runat="server" class="openframe">
                                    <%# Eval("Full_Name")%></a>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Email_Address")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("DateOf_Birth")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("NIC")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Gender")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Phone_Number")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Religon")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("MaritalStatus")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Nationality")%>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Address")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
