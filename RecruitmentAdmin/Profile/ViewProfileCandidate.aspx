﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewProfileCandidate.aspx.cs" Inherits="Profile_ViewProfileCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Shortlisted Candidates</title>
    <style type="text/css">
        a:link
        {
            text-decoration: none;
        }
        /* unvisited link */
        a:visited
        {
            text-decoration: none;
        }
        /* visited link */
        a:hover
        {
            text-decoration: underline;
        }
        /* mouse over link */
        a:active
        {
            text-decoration: underline;
        }
        /* selected link */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Shortlisted Candidates</span>
        </h2>
        <script type="text/javascript">
            $(".openframeCand").fancybox({
                fitToView: false,
                width: '93%',
                height: '93%',
                autoSize: false,
                openEffect: 'none',
                closeEffect: 'none',
                type: 'iframe'
            });
        </script>
        <script type="text/javascript">

            $(document).ready(
        function () {

            $.widget("custom.threecolumnautocomplete2", $.ui.autocomplete, {
                _renderMenu: function (ul, items) {
                    var self = this;
                    ul.append("<div id='container' style='min-height: 20px !important;min-width:80px !important;width:280px; !important;' class='specialpointer'><table  border='0' cellpadding='0' cellspacing='none'><tbody></tbody></table></div>");
                    $.each(items, function (index, item) {
                        self._renderItem(ul.find("table tbody"), item);
                    });
                },

                _renderItem: function (table, item) {
                    return $("<tr></tr>").click(function () {
                        document.getElementById("<%=txtCandidateName.ClientID %>").value = item.value.split("|")[0];
                        document.getElementById("<%=hdnCandidateCode.ClientID %>").value = item.value.split("|")[1];
                        $('#<%=txtCandidateName.ClientID %>').threecolumnautocomplete2("close");
                    })
         .data("item.autocomplete", item)
    	.append("<td>" + item.label + " &nbsp;</td>")
    .appendTo(table);
                }
            });

            $('#<%=txtCandidateName.ClientID %>').threecolumnautocomplete2({
                //                select: function (event, ui) {
                //                    $('#hdnAssetCategoryID').val(ui.item.code);
                //                    $('#txtAssetCategory').val(ui.item.label);
                //                    return false;
                //                },
                source: function (request, response) {
                    $.ajax({

                        url: "../AutoComplete.asmx/FetchMappedCandidate",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json",
                        data: "{ 'prefixText': '" + request.term + "' }",
                        // dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {

                                    label: item.CandidateFullName + "[" + item.CandidateEmailAddress + "]",
                                    value: item.CandidateFullName + "|" + item.CandidateCode
                                    //code: item.AssetCategoryID
                                }
                            }));
                        },

                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                            alert(errorThrown);
                        }

                    });
                }, minLength: 1
            });
        });
        </script>
    </div>
    <div id="container" class="contentarea">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Select Profile:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlProfile" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Select Requisition:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlRequisition" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Candidate Name:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtCandidateName" Width="280"></asp:TextBox>
                    <asp:HiddenField ID="hdnCandidateCode" Value="-1" runat="server" />
                </td>
                <td style="width: 15%" align="center">
                    Select Status:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="280px">
                        <asp:ListItem Value="0" Text="----All----"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Mapped"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Shortlisted"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                    </asp:LinkButton>
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="80%" border="0" cellpadding="10" cellspacing="0">
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
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="Label" Visible="False" Font-Bold="true"
                                        ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton ID="lnkbtnNextPage"
                                            runat="server" Font-Bold="True" Font-Underline="False" ToolTip="Next Page" OnClick="lnkbtnNextPage_Click"
                                            Visible="False">&gt;&gt;</asp:LinkButton>&nbsp; &nbsp;<asp:LinkButton ID="lnkbtnLastPage"
                                                runat="server" Font-Bold="True" Font-Underline="False" ToolTip="Last Page" OnClick="lnkbtnLastPage_Click"
                                                Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
            </thead>
           <asp:Repeater ID="rptProfileLists" runat="server" OnItemDataBound="rptProfileLists_ItemDataBound">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center" style="width: 10%">
                                Reference No.
                            </th>
                            <th align="center" style="width: 20%">
                                Profile Name
                            </th>
                            <th align="center" style="width: 20%">
                                Candidate Name
                            </th>
                            <th align="center" style="width: 5%">
                                Score
                            </th>
                            <th align="center" style="width: 20%">
                                Status
                            </th>
                             <th align="center" style="width: 30%">
							 Current Status
							 </th>
                            <th id="thAction" runat="server" align="center" style="width: 30%">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Candidate_ID")%>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                            <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                            <%# Eval("Profile_Name")%>
                            <%--</a>--%>
                        </td>
                        <td style="text-align: left">
                            <a id="aCandDetail" runat="server" class="link" target="_blank">
                                <%# Eval("Full_Name")%></a>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Score")%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                         <td style="text-align: left">
                           <%# Eval("statusName")%>
                        </td>
                        <td id="tdAction" runat="server" style="text-align: center">
                          <span id="divAction57" runat="server" clientidmode="Static"  visible="false">
                        <asp:HiddenField ID="hdnStatus_Code" runat="server" Value='<%# Eval("Status_Code")%>' />
                            <a id="AReserve" runat="server" class="openframe">Reserve</a>
                            </span>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Candidate_ID")%>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                            <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                            <%# Eval("Profile_Name")%>
                            <%--</a>--%>
                        </td>
                        <td style="text-align: left">
                            <a id="aCandDetail" runat="server" class="link" target="_blank">
                                <%# Eval("Full_Name")%></a>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Score")%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                         <td style="text-align: left">
                           <%# Eval("statusName")%>
                        </td>
                        <td id="tdAction" runat="server" style="text-align: center">
                          <span id="divAction57" runat="server" clientidmode="Static"  visible="false">
                        <asp:HiddenField ID="hdnStatus_Code" runat="server" Value='<%# Eval("Status_Code")%>' />
                            <a id="AReserve" runat="server" class="openframe">Reserve</a>
                            </span>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <div style="text-align: center">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
