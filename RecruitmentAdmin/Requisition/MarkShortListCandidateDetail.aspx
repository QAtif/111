<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="MarkShortListCandidateDetail.aspx.cs" Inherits="Requisition_MarkShortListCandidateDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                parent.window.location.href = mainURL; //  + "?" + window.location.search.substring(1);
                //   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="List of Candidates"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnProfileCode" runat="server" />
            <asp:HiddenField ID="hdnRequisitionCode" runat="server" />
            <asp:HiddenField ID="hdnCount" runat="server" />
            <div style="text-align: center">
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" Visible="false" runat="server"></asp:Label>
            </div>
            <br />
            <table width="100%" border="0" cellpadding="10" cellspacing="0">
                <thead>
                    <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                        <th align="center" colspan="5">
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
                </thead>
                <tbody>
                    <asp:Repeater ID="rptRequisitionLists" runat="server" OnItemDataBound="rptRequisitionLists_ItemDataBound"
                        OnItemCommand="rptRequisitionLists_ItemCommand">
                        <HeaderTemplate>
                            <tr class="simple">
                                <th style="width: 1%">
                                    &nbsp;
                                </th>
                                <th style="width: 2%">
                                    S.No.
                                </th>
                                <th align="center" style="width: 20%">
                                    Candidate Name
                                </th>
                                <th align="center" style="width: 20%">
                                    Email Address
                                </th>
                                <th align="center" style="width: 10%">
                                    Gender
                                </th>
                                <th align="center" style="width: 5%">
                                    Score
                                </th>
                                <%--   <th align="left" style="width: 15%">
                        Action
                    </th>--%>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="simple">
                                <td>
                                    <asp:CheckBox ID="chk" runat="server" />
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                    <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                    <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                    <%# Eval("Full_Name")%>
                                    <%--</a>--%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Email_Address")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Gender")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Score")%>
                                </td>
                                <%--           <td style="text-align: center">
                                <a id="aViewCandidate" runat="server" class="openframe">View Detail</a>
                            </td>--%>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                        <tr class="grey">
                                <td>
                                    <asp:CheckBox ID="chk" runat="server" />
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                    <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                    <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                    <%# Eval("Full_Name")%>
                                    <%--</a>--%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Email_Address")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Gender")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Score")%>
                                </td>
                                <%--           <td style="text-align: center">
                                <a id="aViewCandidate" runat="server" class="openframe">View Detail</a>
                            </td>--%>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <br />
            <div style="text-align: center">
                <asp:Label ID="lblMsg" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
