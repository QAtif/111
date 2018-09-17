<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="ViewRequisition.aspx.cs" Inherits="ViewRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Category Requisition</title>
    <link href="../assets/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">        function refreshParent(obj) {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
        }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManafer1" runat="server">
    </asp:ScriptManager>
    <div id="container" class="contentarea" style="min-height:100px !important;">
        <table border="0" style="height:auto; width:100%" cellspacing="0" cellpadding="0">
            <tr id="trFound" runat="server">
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <asp:Repeater runat="server" ID="rptCategoryList" OnItemCommand="rptCategoryList_ItemCommand">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th width="20%" align="center" height="18">
                                            Requisition
                                        </th>
                                        <th width="20%" align="center" height="18">
                                            Last Updated By
                                        </th>
                                        <th width="20%" align="center" height="18">
                                            Status
                                        </th>
                                        <th width="10%" align="center" height="18">
                                            Quantity
                                        </th>
                                        <th width="30%" align="center" height="18">
                                            Action
                                        </th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="normal">
                                    <td style="text-align: center">
                                        <%# Eval("ReqName")%>
                                        <asp:HiddenField ID="hdnRR" runat="server" Value='<%# Eval("CatCode") %>' />
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("LastUpdatedBy")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("ReqStatus")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td style="text-align: center">
                                        <table width="100%" style="border-style: none">
                                            <tr style="border-style: none">
                                                <td style="border-style: none; width: 33%;">
                                                    <div id="divAction70" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkADO" runat="server" Visible='<%#((int)Eval("ApproveDO") == 1) ? true : false %>'
                                                            CommandName="ApprovedDO" CommandArgument='<%# Eval("ReqCode") %>'><img id="img2" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction71" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkAHrDO" runat="server" Visible='<%#((int)Eval("ApproveHRDO") == 1) ? true : false %>'
                                                            CommandName="ApprovedHrDo" CommandArgument='<%# Eval("ReqCode") %>'>
                                                           <img id="img3" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction72" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkAOPD" runat="server" Visible='<%#((int)Eval("ApproveOPD") == 1) ? true : false %>'
                                                            CommandName="ApprovedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img4" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td style="border-style: none; width: 33%;">
                                                    <div id="divAction73" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkDDO" runat="server" Visible='<%#((int)Eval("DisapproveDO") == 1) ? true : false %>'
                                                            CommandName="RejectedDO" CommandArgument='<%# Eval("ReqCode") %>'><img id="img1" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction74" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkDHrDO" runat="server" Visible='<%#((int)Eval("DisapproveHRDO") == 1) ? true : false %>'
                                                            CommandName="RejectedHrDo" CommandArgument='<%# Eval("ReqCode") %>'><img id="img5" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction75" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkDOPD" runat="server" Visible='<%#((int)Eval("DisapproveOPD") == 1) ? true : false %>'
                                                            CommandName="RejectedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img6" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="normal">
                                    <td style="text-align: center">
                                        <%# Eval("ReqName")%>
                                        <asp:HiddenField ID="hdnRR" runat="server" Value='<%# Eval("CatCode") %>' />
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("LastUpdatedBy")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("ReqStatus")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td style="text-align: center">
                                        <table width="100%" style="border-style: none">
                                            <tr style="border-style: none">
                                                <td style="border-style: none; width: 33%;">
                                                    <div id="divAction70" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkADO" runat="server" Visible='<%#((int)Eval("ApproveDO") == 1) ? true : false %>'
                                                            CommandName="ApprovedDO" CommandArgument='<%# Eval("ReqCode") %>'><img id="img2" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction71" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkAHrDO" runat="server" Visible='<%#((int)Eval("ApproveHRDO") == 1) ? true : false %>'
                                                            CommandName="ApprovedHrDo" CommandArgument='<%# Eval("ReqCode") %>'>
                                                           <img id="img3" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction72" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkAOPD" runat="server" Visible='<%#((int)Eval("ApproveOPD") == 1) ? true : false %>'
                                                            CommandName="ApprovedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img4" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td style="border-style: none; width: 33%;">
                                                    <div id="divAction73" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkDDO" runat="server" Visible='<%#((int)Eval("DisapproveDO") == 1) ? true : false %>'
                                                            CommandName="RejectedDO" CommandArgument='<%# Eval("ReqCode") %>'><img id="img1" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction74" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkDHrDO" runat="server" Visible='<%#((int)Eval("DisapproveHRDO") == 1) ? true : false %>'
                                                            CommandName="RejectedHrDo" CommandArgument='<%# Eval("ReqCode") %>'><img id="img5" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                    </div>
                                                    <div id="divAction75" runat="server" clientidmode="Static" visible="false">
                                                        <asp:LinkButton ID="lnkDOPD" runat="server" Visible='<%#((int)Eval("DisapproveOPD") == 1) ? true : false %>'
                                                            CommandName="RejectedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img6" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr id="trnorecords" runat="server" align="center" visible="false">
                <td style="border: none">
                    <b>No records Found</b>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
