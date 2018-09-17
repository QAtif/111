<%@ Page Title="" Language="C#" MasterPageFile="~/A2/A2Popup.master" AutoEventWireup="true" CodeFile="UpdateRequisition.aspx.cs" Inherits="A2_Requisition_UpdateRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        iframe.fancybox-iframe
        {
            overflow: hidden;
        }
    </style>
    <script>
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                //   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <section class="popcontainer poptheformbody width740">
        <article>
            <a href="javascript:;" title="" class="closebtn" onclick="parent.jQuery.fancybox.close()"></a>
            <h2>View Requisition</h2>
            <table>
                <asp:Repeater ID="rptRequisitions" runat="server" OnItemCommand="rptRequisitions_ItemCommand" OnItemDataBound="rptRequisitions_ItemDataBound">
                    <HeaderTemplate>
                        <tr>
                            <td scope="col" class="widtd76">Requisition</td>
                            <td scope="col" class="widtd100">Category</td>
                            <td scope="col" class="widtd119">Last Updated By</td>
                            <td scope="col" class="widtd180">Status</td>
                            <td scope="col" class="widtd50" style="text-align: center">Quantity</td>
                            <td scope="col" class="widtd50" style="text-align: center" runat="server">Category Specialist</td>
                            <td scope="col" style="text-align: center">Action</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>

                            <td>
                                <asp:HiddenField ID="hdnRR" runat="server" Value='<%# Eval("CatCode") %>' />
                                <%# Eval("ReqName")%></td>
                            <td><%# Eval("CatName")%></td>
                            <td><%# Eval("LastUpdatedBy") %></td>
                            <td><%# Eval("ReqStatus")%></td>
                            <td style="text-align: center"><%# Eval("Quantity") %></td>
                            <td style="text-align: center">
                                <asp:DropDownList ID="ddlCategorySpecialist" CssClass="inputClass jqtranformdone" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: center">
                                <ul class="updateState">
                                    <li class="approve first odd" style="text-align: center;">
                                        <div id="divAction140" runat="server" clientidmode="Static" visible="false">
                                            <asp:LinkButton ID="lnkADO" runat="server" Visible='<%#((int)Eval("ApproveDO") == 1) ? true : false %>'
                                                CommandName="ApprovedDO" CommandArgument='<%# Eval("ReqCode") %>' OnClientClick="javascript:return confirm('Are you sure you want to approve?');"><img id="img2" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                        </div>
                                        <div id="divAction141" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                            <asp:LinkButton ID="lnkAHrDO" runat="server" Visible='<%#((int)Eval("ApproveHRDO") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to approve?');"
                                                CommandName="ApprovedHrDo" CommandArgument='<%# Eval("ReqCode") %>'>
                                                           <img id="img3" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                        </div>
                                        <div id="divAction142" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                            <asp:LinkButton ID="lnkAOPD" runat="server" Visible='<%#((int)Eval("ApproveOPD") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to approve?');"
                                                CommandName="ApprovedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img4" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                        </div>
                                    </li>
                                    <li class="reject last even">
                                        <div id="divAction143" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                            <asp:LinkButton ID="lnkDDO" runat="server" Visible='<%#((int)Eval("DisapproveDO") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to reject?');"
                                                CommandName="RejectedDO" CommandArgument='<%# Eval("ReqCode") %>'><img id="img1" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                        </div>
                                        <div id="divAction144" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                            <asp:LinkButton ID="lnkDHrDO" runat="server" Visible='<%#((int)Eval("DisapproveHRDO") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to reject?');"
                                                CommandName="RejectedHrDo" CommandArgument='<%# Eval("ReqCode") %>'><img id="img5" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                        </div>
                                        <div id="divAction145" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                            <asp:LinkButton ID="lnkDOPD" runat="server" Visible='<%#((int)Eval("DisapproveOPD") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to reject?');"
                                                CommandName="RejectedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img6" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                        </div>
                                    </li>
                                </ul>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="text-align: center;font-weight: bold;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="No record found"></asp:Label>
                    <br />
                </div>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </article>
    </section>


</asp:Content>
