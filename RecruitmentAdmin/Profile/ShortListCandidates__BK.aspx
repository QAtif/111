<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShortListCandidates__BK.aspx.cs" Inherits="Profile_ShortListCandidates__BK" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Shortlist Candidates</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Shortlisted Candidates</span>
        </h2>
        <script type="text/javascript">
            function CheckAllCheckBoxes(obj) {
                chk = document.documentElement.getElementsByTagName('input');
                for (var i = 0; i < chk.length; i++) {

                    if (chk[i].id.indexOf('chkCandidate') >= 0) {
                        chk[i].checked = obj.checked;
                    }
                }
            }


            function Validate() {
                var inputs = document.getElementsByTagName("input");
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type == "checkbox") {
                        if (inputs[i].checked == true)
                            return true;
                    }
                }
                alert("Please select some record(s) first.");
                return false;
            }
        </script>
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
                </td>
                <td align="center">
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
                    <th align="center" colspan="7">
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
                                <input type="checkbox" id="chkAllCandidate" runat="server" onclick="javascript:CheckAllCheckBoxes(this)" />
                            </th>
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center" style="width: 15%">
                                Profile Name
                            </th>
                            <th align="center" style="width: 15%">
                                Candidate Name
                            </th>
                            <th align="center" style="width: 15%">
                                Email Address
                            </th>
                            <th align="center" style="width: 15%">
                                Phone Number
                            </th>
                            <th align="center" style="width: 10%">
                                Score
                            </th>
                            <th align="center" style="width: 10%">
                                Is Locked
                            </th>
                            <th align="center" style="width: 30%">
                                Status
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <input id="chkCandidate" runat="server" type="checkbox" />
                            <asp:HiddenField ID="hdnCPM_Code" runat="server" Value='<%# Eval("CandidateProfileMapping_Code")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                            <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                            <%# Eval("Profile_Name")%>
                            <%--</a>--%>
                        </td>
                        <td style="text-align: center">
                            <a id="aCandDetail" runat="server" target="_blank">
                                <%# Eval("Full_Name")%></a>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email_Address")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Phone_Number")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Score")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Is_Locked")%>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <input id="chkCandidate" runat="server" type="checkbox" />
                            <asp:HiddenField ID="hdnCPM_Code" runat="server" Value='<%# Eval("CandidateProfileMapping_Code")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnProfileCode" runat="server" Value='<%# Eval("Profile_Code")%>' />
                            <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                            <%# Eval("Profile_Name")%>
                            <%--</a>--%>
                        </td>
                        <td style="text-align: center">
                            <a id="aCandDetail" runat="server"  target="_blank">
                                <%# Eval("Full_Name")%></a>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email_Address")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Phone_Number")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Score")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Is_Locked")%>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
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
            <br />
        </div>
        <div id="DLock" runat="server" style="text-align: center; float: right; display: none;">
            <asp:LinkButton runat="server" ID="lnkLockCandidate" CssClass="btn-ora nl" OnClick="lnkLockCandidate_Click"
                OnClientClick="javascript:return Validate();">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Lock Candidates
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>
