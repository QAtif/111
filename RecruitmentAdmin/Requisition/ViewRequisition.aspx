<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="ViewRequisition.aspx.cs" Inherits="Requisition_ViewRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Requisition List</title>
      <script src="../A2/assets/js/QuicjSearch.js" type="text/javascript"></script> 
      <script language="javascript" type="text/javascript">

          function onpress() {
              $('#id_search_list').quicksearch('#test tbody tr');
              // $('#id_search_list').val('content');
          }
          // var qs = $('#id_search_list').quicksearch('#UlMain li');
       

    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>List of Requisitions</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <span id="divAction39" runat="server" visible="false" clientidmode="Static"><a href="RaiseRequisition.aspx"
                class="openframe">Raise New Requisition</a> | </span><span id="divAction40" clientidmode="Static"
                    runat="server" visible="false"><a href="ChangePriority.aspx">Update Requisition Priority</a>
                </span>
        </div>
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Requisition Name:
                </td>
                <td align="center">
                    <asp:TextBox ID="txtRequisitionName" runat="server" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 15%" align="center">
                    Select Domain:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlDomain" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Select SubDomain:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlSubDomain" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Select Category:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Select City:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlCity" runat="server" Width="280px">
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
                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                        ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                    </asp:LinkButton>
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="80%" border="0" cellpadding="10" cellspacing="0" id="test">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="8">
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
                        <tr> <th colspan="13" align="left"> Filter: &nbsp; <input type="text"  name=""  value="" id="id_search_list" placeholder="Requisition Name" onkeyup="javascript:onpress();" /> </tr>
                        <tr class="simple">
                         </th>
                            <th style="width: 2%" rowspan="3">
                                S.No.
                            </th>
                            <th align="center" style="width: 15%" rowspan="3">
                                Requisition Name
                            </th>
                            <th align="center" style="width: 15%" rowspan="3">
                                Requisition Status
                            </th>
                            <th align="center" style="width: 13%" rowspan="3">
                                Raised By
                            </th>
                            <th align="center" style="width: 15%" rowspan="3">
                                Category Name
                            </th>
                            <th align="center" style="width: 14%" rowspan="3">
                                City
                            </th>
                            <th align="center" style="width: 14%" rowspan="3">
                                Domain
                            </th>
                            <th align="center" style="width: 14%" rowspan="3">
                                Sub Domain
                            </th>
                            <th align="center" colspan="3" style="width: 24%">
                                Candidate Count
                            </th>
                            <th align="center" style="width: 2%" rowspan="3">
                                Priority
                            </th>
                            <th align="center" style="width: 10%" rowspan="3">
                                Action
                            </th>
                        </tr>
                        <tr>
                            <th align="center" style="width: 10%">
                                Required
                            </th>
                            <th align="center" style="width: 10%">
                                To be Shortlisted
                            </th>
                            <th align="center" style="width: 10%">
                                Mapped Count
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
                                        <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                        <%# Eval("Requisition_Name")%>
                                        <%--</a>--%>
                                    </td>
                                    <td style="text-align: center">
                                        <a id="aStatus" runat="server" class="openframe">
                                            <%# Eval("RequisitionStatus_Name")%>
                                        </a>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Raised_By")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Category_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("City")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Domain_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("SubDomain_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("ShortList_Count")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("MappedCount")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Priority")%>
                                    </td>
                                    <td style="text-align: center">
                                        <span id="divAction25" runat="server" clientidmode="Static" visible="false"><a id="aEdit"
                                            runat="server" class="openframe">
                                            <img src="/assetsprocurement/images/edit.png" />
                                        </a></span>|<span id="divAction24" clientidmode="Static" runat="server" visible="false">
                                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                                CommandArgument='<%# Eval("Requisition_Code")%>' />
                                        </span>
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
                                        <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                        <%# Eval("Requisition_Name")%>
                                        <%--</a>--%>
                                    </td>
                                    <td style="text-align: center">
                                        <a id="aStatus" runat="server" class="openframe">
                                            <%# Eval("RequisitionStatus_Name")%>
                                        </a>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Raised_By")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Category_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("City")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Domain_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("SubDomain_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("ShortList_Count")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("MappedCount")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Priority")%>
                                    </td>
                                    <td style="text-align: center">
                                        <span id="divAction25" runat="server" clientidmode="Static" visible="false"><a id="aEdit"
                                            runat="server" class="openframe">
                                            <img src="/assetsprocurement/images/edit.png" />
                                        </a></span>|<span id="divAction24" clientidmode="Static" runat="server" visible="false">
                                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                                CommandArgument='<%# Eval("Requisition_Code")%>' />
                                        </span>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                        <div style="text-align: center">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="No Data"></asp:Label>
                            <br />
                        </div>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
