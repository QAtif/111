<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewAllCategory.aspx.cs" Inherits="Category_ViewAllCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Category List</title>
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
<asp:ScriptManager id="ScriptManafer1" runat="server"></asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>List of Category</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <span id="divAction36" runat="server" clientidmode="Static" visible="false"><a href="AddEditCategory.aspx"
                class="openframe">Add New Category</a> </span>
        </div>
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Category Name:
                </td>
                <td align="center">
                    <asp:TextBox ID="txtCategoryName" runat="server" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 15%" align="center">
                    Select Domain:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlDomain" runat="server" Width="280px" AutoPostBack="true" OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged">
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
                    Select Profile:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlProfile" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td style="width: 15%" align="center">
                    Category User Type:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlUserCategory" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Job Role:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlJobRole" runat="server" Width="280px">
                    </asp:DropDownList>
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
        <div>Filter: &nbsp; <input type="text"  name=""  value="" id="id_search_list" placeholder="Search everything important" onkeyup="javascript:onpress();" style="width:200px;" /></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  
                      
        <table width="80%" border="0" cellpadding="10" cellspacing="0" id="test">

            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="11">
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
           
                <asp:Repeater ID="rptCategoryLists" runat="server" OnItemDataBound="rptCategoryLists_ItemDataBound"
                    OnItemCommand="rptCategoryLists_ItemCommand">
                    <HeaderTemplate>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center" style="width: 11%">
                                Category Name
                            </th>
                            <th align="center" style="width: 19%">
                                Category Title
                            </th>
                            <th align="center" style="width: 14%">
                                Domain
                            </th>
                            <th align="center" style="width: 14%">
                                SubDomain
                            </th>
                            <th align="center" style="width: 9%">
                                Position Type
                            </th>
                            <th align="center" style="width: 9%">
                                Grade From
                            </th>
                            <th align="center" style="width: 9%">
                                Grade To
                            </th>
                            <th align="center" style="width: 5%">
                                Test/Interview
                            </th>
                            <th align="center" style="width: 14%">
                                Duration
                            </th>
                            <th align="center" style="width: 24%">
                                Profile
                            </th>
                             <th align="center" style="width: 10%">
                                Job Role
                            </th>
                            <th align="center" style="width: 9%">
                                Action
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnCategoryCode" runat="server" Value='<%# Eval("Category_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Category_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Category_Title")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Domain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("SubDomain_Name")%>
                            </td>
                             <td style="text-align: center">
                                <%# Eval("PositionTypeName")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("GradeFromDesc")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("GradeToDesc")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Is_Test")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Duration")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_Name")%>
                            </td>
                             <td style="text-align: center">
                                <%# Eval("JobRole")%>
                            </td>
                            <td style="text-align: center">
                                <span id="divAction37" runat="server" clientidmode="Static" visible="false"><a id="aEdit" runat="server"
                                    class="openframe">
                                    <img src="/assetsprocurement/images/edit.png" />
                                </a>| </span><span id="divAction38" clientidmode="Static" runat="server" visible="false">
                                    <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                        CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                        CommandArgument='<%# Eval("Category_Code")%>' />
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
                                <asp:HiddenField ID="hdnCategoryCode" runat="server" Value='<%# Eval("Category_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Category_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Category_Title")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Domain_Name")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("SubDomain_Name")%>
                            </td>
                             <td style="text-align: center">
                                <%# Eval("PositionTypeName")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("GradeFromDesc")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("GradeToDesc")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Is_Test")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Duration")%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_Name")%>
                            </td>
                             <td style="text-align: center">
                                <%# Eval("JobRole")%>
                            </td>
                            <td style="text-align: center">
                                <span id="divAction37" runat="server" clientidmode="Static" visible="false"><a id="aEdit" runat="server"
                                    class="openframe">
                                    <img src="/assetsprocurement/images/edit.png" />
                                </a>| </span><span id="divAction38" clientidmode="Static" runat="server" visible="false">
                                    <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                        CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                        CommandArgument='<%# Eval("Category_Code")%>' />
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