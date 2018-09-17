<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewSignupResume.aspx.cs" Inherits="Candidate_ViewSignupResume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Resume Signup</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    
    <div class="headbar">
        <h2>
            <span>Candidate Resume</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <span id="dv" runat="server" clientidmode="Static"><a href="BrowseResumeSignup.aspx"
                target="_parent">Add Candidate Resume</a> </span>
        </div>
        <div style="text-align: center">
            <table width="40%" border="0" cellpadding="10" cellspacing="0">
                <tr>
                    <th colspan="4">
                        <strong>Search Criteria</strong>
                    </th>
                </tr>
                <tr>
                    <td>
                        Date From
                    </td>
                    <td>
                        <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                            readonly="true" style="width: 180px" />
                    </td>
                    <td>
                        Date To
                    </td>
                    <td>
                        <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                            style="width: 180px" readonly="true" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" align="center">
                        Select Domain:
                    </td>
                    <td style="width: 20%" align="center">
                        <asp:DropDownList ID="ddlDomain" runat="server" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20%" align="center">
                        Select SubDomain:
                    </td>
                    <td style="width: 20%" align="center">
                        <asp:DropDownList ID="ddlSubDomain" runat="server" Width="250px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" align="center">
                        Select Category:
                    </td>
                    <td style="width: 20%" align="center">
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <br />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn-ora nl" Text="Search" OnClick="btnSearch_Click"
                            ValidationGroup="Check" />
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label ID="lblMsg" runat="server" Visible="false" Text="No Data" ForeColor="Red"
                Font-Bold="true"></asp:Label>
            <table width="80%" border="0" cellpadding="10" cellspacing="0">
                <thead>
                    <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                        <th align="center" colspan="6">
                            <table border="0" cellpadding="10" cellspacing="0">
                                <tr>
                                    <th height="25" align="center">
                                        <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                        &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                            Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                            Visible="False">&lt;&lt;</asp:LinkButton>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex"
                                                runat="server" Text="Label" Visible="False" ForeColor="Black"></asp:Label>&nbsp;
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
                    <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound">
                        <HeaderTemplate>
                            <tr class="simple">
                                <th style="width: 2%">
                                    <strong>S.No. </strong>
                                </th>
                                <th align="center" style="width: 15%">
                                    <strong>Domain</strong>
                                </th>
                                <th align="center" style="width: 15%">
                                    <strong>SubDomain</strong>
                                </th>
                                <th align="center" style="width: 18%">
                                    <strong>Category</strong>
                                </th>
                                <th align="center" style="width: 18%">
                                    <strong>Date</strong>
                                </th>
                                <th align="center" style="width: 18%">
                                    <strong>Updated By</strong>
                                </th>
                                <th align="center" style="width: 15%">
                                    <strong>Resume</strong>
                                </th>
                                <th align="center" style="width: 20%">
                                    <strong>Action</strong>
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="simple">
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Domain_Name")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("SubDomain_Name")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Category_Name")%>
                                </td>
                                 <td style="text-align: center">
                                    <%# Eval("Created_Date")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("Updated_By")%>
                                </td>
                                <td style="text-align: center">
                                    <asp:HiddenField ID="hdnUserResumeCode" runat="server" Value='<%# Eval("UserResume_Code")%>' />
                                    <a id="aREsume" runat="server" href="javascript:">
                                        <%# Eval("Resume_File_Name")%></a>
                                </td>
                                <td style="text-align: center">
                                    <a href="javascript:" runat="server" id="aSignUp">
                                        <%# Eval("Status_Name")%></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="grey">
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Domain_Name")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("SubDomain_Name")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Category_Name")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Created_Date")%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("Updated_By")%>
                                </td>
                                <td style="text-align: center">
                                    <asp:HiddenField ID="hdnUserResumeCode" runat="server" Value='<%# Eval("UserResume_Code")%>' />
                                    <a id="aREsume" runat="server" href="javascript:">
                                        <%# Eval("Resume_File_Name")%></a>
                                </td>
                                <td style="text-align: center">
                                    <a href="javascript:" runat="server" id="aSignUp">
                                        <%# Eval("Status_Name")%></a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">



        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"


            });
        });

        $(function () {
            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });
    
    </script>
</asp:Content>
