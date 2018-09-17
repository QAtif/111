<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewUnMappedCandidate.aspx.cs" Inherits="Profile_ViewUnMappedCandidate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>UnMapped Candidates</title>
    <%--  <script type="text/javascript">

        $(document).ready(
        function () {

            $.widget("custom.threecolumnautocomplete2", $.ui.autocomplete, {
                _renderMenu: function (ul, items) {
                    var self = this;
                    ul.append("<div id='container' style='min-height: 20px !important;min-width:100px !important;width:310px; !important;' class='specialpointer'><table  border='0' cellpadding='0' cellspacing='none'><tbody></tbody></table></div>");
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

                        url: "../AutoComplete.asmx/FetchUnMappedCandidate",
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
    </script>--%>
    <style type="text/css">
        .completionListElement
        {
            visibility: hidden;
            margin: 0px !important;
            background-color: inherit;
            color: black;
            border: solid 1px;
            cursor: pointer;
            text-align: left;
            list-style-type: none;
            font-family: Verdana;
            font-size: 12px;
            padding: 0;
        }
        .listItem
        {
            background-color: White;
            padding: 1px;
        }
        .highlightedListItem
        {
            background-color: Silver;
            padding: 1px;
        }
    </style>
    <script type="text/javascript">
        function SkillItemSelected(sender, e) {
            document.getElementById('<%=hfSkillCode.ClientID %>').value = e.get_value();
            document.getElementById('<%=hfSkillName.ClientID %>').value = e.get_text();
            document.getElementById('<%=btnAddSkill.ClientID %>').click();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>UnMapped Candidates</span>
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
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="container" class="contentarea">
                <table width="60%" border="0" cellpadding="10" cellspacing="0">
                    <tr>
                        <th colspan="4">
                            Search Criteria
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 15%" align="center">
                            Candidate Name:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtCandidateName" Width="280px"></asp:TextBox>
                            <asp:HiddenField ID="hdnCandidateCode" Value="-1" runat="server" />
                        </td>
                        <td style="width: 15%" align="center">
                            Candidate Email:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtEmail" Width="280px"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField1" Value="-1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" align="center">
                            Candidate Phone No:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtPhone" Width="280px"></asp:TextBox>
                        </td>
                        <td style="width: 15%" align="center">
                            Candidate NIC:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtNIC" Width="280px"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField2" Value="-1" runat="server" />
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
                        <td style="width: 15%" align="center">
                            Skills/Expertise:
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtacSkill" runat="server" Width="280px"></asp:TextBox>
                            <ajax:AutoCompleteExtender runat="server" ID="acSkill" TargetControlID="txtacSkill"
                                ServiceMethod="FetchSkillList" ServicePath="~/AutoComplete.asmx" MinimumPrefixLength="2"
                                CompletionInterval="0" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="completionListElement"
                                CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="highlightedListItem"
                                FirstRowSelected="false" OnClientItemSelected="SkillItemSelected" ShowOnlyCurrentWordInCompletionListItem="true">
                            </ajax:AutoCompleteExtender>
                            <asp:HiddenField ID="hfSkillCode" runat="server" />
                            <asp:HiddenField ID="hfSkillName" runat="server" />
                            <asp:Button ID="btnAddSkill" runat="server" Text="Add" OnClick="btnAddSkill_Click"
                                Style="display: none;" />
                        </td>
                        <td colspan="2" align="left">
                            <asp:CheckBoxList ID="chkSkills" BorderStyle="None" RepeatLayout="Flow" CellSpacing="4"
                                runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
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
                            <th align="center" colspan="5">
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
                                    <th align="center" style="width: 20%">
                                        Candidate Name
                                    </th>
                                    <th align="center" style="width: 20%">
                                        Email Address
                                    </th>
                                    <th align="center" style="width: 20%">
                                        Phone Number
                                    </th>
                                    <th align="center" style="width: 10%">
                                        &nbsp;
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="trView" runat="server" class="simple">
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                    <%--  <a id="aRequisitionLink" runat="server" class="openframe">--%>
                                    <%# Eval("Full_Name")%>
                                    <%--</a>--%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Email_Address")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Phone_Number")%>
                                </td>
                                <td style="text-align: center">
                                    <a id="aCand" runat="server" class="openframeCand">View Detail</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id="trView" runat="server" class="grey">
                                <td style="text-align: center">
                                    <asp:Label ID="lblSno" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                    <%# Eval("Full_Name")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Email_Address")%>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("Phone_Number")%>
                                </td>
                                <td style="text-align: center">
                                    <a id="aCand" runat="server" class="openframeCand">View Detail</a>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageDescription" runat="Server">
</asp:Content>
