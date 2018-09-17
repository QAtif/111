<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EditProfilePriority.aspx.cs" Inherits="EditProfilePriority" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=EDGE" />
    <title>Profile Priority List</title>
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
                    <th align="center" colspan="8">
                        <table border="0" cellpadding="10" cellspacing="0" style="display: none" >
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
                <tr class="simple" style="height:45px">
                    <th style="width: 5%; font-weight: bold;">
                        Priority
                    </th>
                    <th align="center" style="width: 8%; font-weight: bold;">
                        Profile Name
                    </th>
                    <th align="center" style="width: 8%; font-weight: bold;">
                        Profile Desc
                    </th>
                   
                    
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptRequisitionLists" runat="server" OnItemDataBound="rptRequisitionLists_ItemDataBound"
                    OnItemCommand="rptRequisitionLists_ItemCommand">
                    <ItemTemplate>
                        <tr id='<%# Eval("Profile_Code") %>' style="height: 25px;" class="simple">
                            <td style="text-align: center; font-weight: bold" class="index">
                                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority")%>'></asp:Label>
                                <%--<asp:HiddenField ID="hdnPriority" runat="server" Value='<%# Eval("Priority") %>' />--%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Profile_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_desc")%>
                            </td>
                           
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id='<%# Eval("Profile_Code") %>' style="height: 25px;" class="grey">
                             <td style="text-align: center; font-weight: bold" class="index">
                                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority")%>'></asp:Label>
                                <%--<asp:HiddenField ID="hdnPriority" runat="server" Value='<%# Eval("Priority") %>' />--%>
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnRequisitionCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                                <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                <%# Eval("Profile_Name")%>
                                <%--</a>--%>
                            </td>
                            <td style="text-align: center">
                                <%# Eval("Profile_desc")%>
                            </td>
                           
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr class="simple">
                    <td colspan="8" align="center">
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

            function items(Profile_id, Profile_priority) {
                this.Profile_id = Profile_id;
                this.Profile_priority = Profile_priority;
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
                    url: "EditProfilePriority.aspx/save_sort",
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
