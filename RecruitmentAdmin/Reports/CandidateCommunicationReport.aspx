<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CandidateCommunicationReport.aspx.cs" Inherits="Reports_CandidateCommunicationReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidate Communication</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Candidate Communication</span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="2">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 30%" align="center">
                    Candidate Name:
                </td>
                <td align="center">
                    <asp:TextBox ID="txtCandidateName" runat="server" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" align="center">
                    Query Status&nbsp;</td>
                <td align="center">
                    <asp:DropDownList runat="server" ID="ddlStatus" Width="280px">
                    <asp:ListItem Value="-1">--Select All--</asp:ListItem>
                    <asp:ListItem Value="1">Solved</asp:ListItem>
                    <asp:ListItem Value="0">UnSolved</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
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
                <table width="80%" border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="5">
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
                            <th align="center">
                                Candidate Name
                            </th>
                            <th align="center">
                                Query
                            </th>
                            <th align="center">
                                Action
                            </th>
                             <th align="center">
                                Status
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptRequisitionLists" runat="server" OnItemDataBound="rptRequisitionLists_ItemDataBound">
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                        <%# Eval("Full_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Message")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a id="aView" runat="server" target="_blank">View Detail </a>

                                        
                                    </td>
                                     <td style="text-align: center">
                                     <a id="aMarkArrive" runat="server" title="Click here If Query is solved" style="cursor:pointer; color:Blue;">                                     
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If Query is not solved"
                                        style="cursor:pointer; color:Blue">                                        
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" />  </a>
                                     </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                        <%# Eval("Full_Name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("Message")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a id="aView" runat="server" target="_blank">View Detail </a>
                                    </td>
                                    <td style="text-align: center">
                                     <a id="aMarkArrive" runat="server" title="Click here If Query is solved" style="cursor:pointer; color:Blue;">                                     
                                    Mark</a> <a id="aUnmarkArrive" runat="server" title="Click here If Query is not solved"
                                        style="cursor:pointer; color:Blue">                                        
                                        <img src="../A2/assets/images/accept.png" width="20" height="20" alt="" />  </a>
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
    <script type="text/javascript">
        function UpdateCandidateQuery(CandidateCode, Type, aMarkArrive, aUnmarkArrive) {

            var Param = CandidateCode + '|' + Type 
            // alert(Param);
            $.ajax({ type: "POST",
                url: "CandidateCommunicationReport.aspx/UpdateCandidateQuery",
                data: JSON.stringify({ items: Param }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    
                    if (Type == '1') {
                        $('#' + aMarkArrive).hide();
                        $('#' + aUnmarkArrive).show();
                        // alert("Marked Sucessfully!");
                    }
                    if (Type == '0') {
                        $('#' + aMarkArrive).show();
                        $('#' + aUnmarkArrive).hide();
                        // alert("UnMarked Sucessfully!");
                    }


                    //parent.location.href = parent.location.href;
                },
                error: function (msg) {
                    alert("error");
                }
            });
        }

    </script>
</asp:Content>
