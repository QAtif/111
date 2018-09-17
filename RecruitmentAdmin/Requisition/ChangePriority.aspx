<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ChangePriority.aspx.cs" Inherits="Requisition_ChangePriority" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=EDGE" />
    <title>Requisition Priority List</title>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.9.2.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/json2.js"></script>
    <style type="text/css">
        #list tbody tr
        {
            cursor: move;
        }
        #list tbody tr:hover
        {
            background: #BDBDBD;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Change Priority</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" id="list" border="0" cellpadding="10" cellspacing="0">
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
                <tr class="simple">
                    <th style="width: 5%; font-weight: bold;">
                        Priority
                    </th>
                    <th align="center" style="width: 8%">
                        Requisition Name
                    </th>
                    <th align="center" style="width: 8%">
                        Requisition Status
                    </th>
                    <th align="center" style="width: 6%">
                        Raised By
                    </th>
                    <th align="center" style="width: 8%">
                        Category Name
                    </th>
                    <th align="center" style="width: 8%">
                        City
                    </th>
                    <th align="center" style="width: 8%">
                        Domain
                    </th>
                    <th align="center" style="width: 8%">
                        Sub Domain
                    </th>
                    <th align="center" style="width: 5%">
                        No. Of Candidates Required
                    </th>
                    <th align="center" style="width: 5%">
                        No. Of Candidates to be Shortlisted
                    </th>
                    <th align="center" style="width: 5%">
                        Mapped Candidates
                    </th>
                    <%--         <th align="left" style="width: 10%">
                    Priority
                </th>--%>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptRequisitionLists" runat="server" OnItemDataBound="rptRequisitionLists_ItemDataBound"
                    OnItemCommand="rptRequisitionLists_ItemCommand">
                    <ItemTemplate>
                        <tr id='<%# Eval("Requisition_Code") %>' style="height: 25px;" class="simple">
                            <td style="text-align: center; font-weight: bold" class="index">
                                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority")%>'></asp:Label>
                                <%--<asp:HiddenField ID="hdnPriority" runat="server" Value='<%# Eval("Priority") %>' />--%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value='<%# Eval("Requisition_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Requisition_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("RequisitionStatus_Name")%>
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
                            <%--                 <td style="text-align: center">
                              <input id="txtTest" runat="server" class="myClass" value='<%# Eval("Priority")%>' /> 
                        <asp:TextBox ID="txtPriority" Width="30px" class="myClass" runat="server" Text='<%# Eval("Priority")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server"
                            ControlToValidate="txtPriority" Text="*" ValidationGroup="valida" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                            runat="server" ControlToValidate="txtPriority" ValidationGroup="valida" Text="*"
                            InitialValue="" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lblMsg" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                        </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id='<%# Eval("Requisition_Code") %>' style="height: 25px;" class="grey">
                            <td style="text-align: center; font-weight: bold" class="index">
                                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority")%>'></asp:Label>
                                <%--<asp:HiddenField ID="hdnPriority" runat="server" Value='<%# Eval("Priority") %>' />--%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value='<%# Eval("Requisition_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Requisition_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("RequisitionStatus_Name")%>
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
                            <%--                 <td style="text-align: center">
                              <input id="txtTest" runat="server" class="myClass" value='<%# Eval("Priority")%>' /> 
                        <asp:TextBox ID="txtPriority" Width="30px" class="myClass" runat="server" Text='<%# Eval("Priority")%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server"
                            ControlToValidate="txtPriority" Text="*" ValidationGroup="valida" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                            runat="server" ControlToValidate="txtPriority" ValidationGroup="valida" Text="*"
                            InitialValue="" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lblMsg" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                        </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr class="simple">
                    <td colspan="11" align="center">
                        <input id="save" type="button" value="Update Priority" class="btn-ora nl" />
                        <%--     <asp:Button ID="btnPriority" runat="server" ValidationGroup="valida" CssClass="btn"
                            Text="Update Priority" OnClick="btnPriority_Click" />--%>
                        <br />
                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </tfoot>
        </table>
        <%-- <input id="save" type="button" value="save" />--%>
    </div>
    <script type="text/javascript">
        $(function () {

            function items(requisition_id, requisition_priority) {
                this.requisition_id = requisition_id;
                this.requisition_priority = requisition_priority;
            }
            var fixHelperModified = function (e, tr) {

                var $originals = tr.children();
                var $helper = tr.clone();
                $helper.children().each(function (index) {
                    $(this).width($originals.eq(index).width())
                });
                return $helper;
            },
    updateIndex = function (e, ui) {

        var C = 0;
        var arr = new Array();
        var item = new items();
        $('td.index', ui.item.parent()).each(function (i) {

            var rowid = $(this).closest("tr").attr('id');
            if (rowid != '') {
                arr[C] = new items(rowid, i + 1);
                C++;
            }
            $(this).html(i + 1);
        });



    };

            $('#list tbody').sortable({
                helper: fixHelperModified,
                stop: updateIndex
            }).disableSelection();
            //$('#list tbody').disableSelection();

            $('#list tbody tr').droppable({
                tolerance: 'intersect'

            });

            $('#save').click(function () {
                var C = 0;
                var arr = new Array();
                var item = new items();
                $('#list tbody tr').each(function (i) {

                    //            var rowid = $(this).closest("tr").attr('id');
                    var rowid = this.id;
                    if (rowid != '') {
                        arr[C] = new items(rowid, i);
                        C++;
                    }

                });

                $.ajax({ type: "POST",
                    url: "ChangePriority.aspx/save_sort",
                    data: JSON.stringify({ items: arr }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert("Successfully Saved!");
                    },
                    error: function (msg) {
                        alert("error");
                    }
                });

            });
        });


    </script>
</asp:Content>
