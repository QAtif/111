<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewAllAction.aspx.cs" Inherits="UniversalData_ViewAllAction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Action List</title>
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
            <span>List of Action</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div style="text-align: right; font-size: larger;">
            <a href="AddEditAction.aspx" class="openframe">Add New Action</a>
        </div>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <table width="80%" border="0" cellpadding="10" cellspacing="0" id="test">
                    <thead>
                        <tr>
                            <th colspan="4" align="left">
                            Filter: &nbsp; <input type="text"  name=""  value="" id="id_search_list" placeholder="Action Name" onkeyup="javascript:onpress();" />   
                            </th>
                        </tr>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="4">
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
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center" style="width: 10%">
                                Action Name
                            </th>
                            <th align="center" style="width: 10%">
                                User Type
                            </th>
                            <th align="center" style="width: 10%">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptRoleLists" runat="server" OnItemDataBound="rptRoleLists_ItemDataBound"
                            OnItemCommand="rptRoleLists_ItemCommand">
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnActionCode" runat="server" Value='<%# Eval("ActionCode")%>' />
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Action")%>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("UserType")%>'></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <a id="aEdit" runat="server" class="openframelarge">
                                            <img src="/assetsprocurement/images/edit.png" />
                                        </a>|
                                        <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                            CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                            CommandArgument='<%# Eval("ActionCode")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnActionCode" runat="server" Value='<%# Eval("ActionCode")%>' />
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Action")%>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("UserType")%>'></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <a id="aEdit" runat="server" class="openframelarge">
                                            <img src="/assetsprocurement/images/edit.png" />
                                        </a>|
                                        <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                            CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                            CommandArgument='<%# Eval("ActionCode")%>' />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: center; position: relative;">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
     
</asp:Content>