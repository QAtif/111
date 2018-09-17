<%@ Page Title="Master Search" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CandidatesList.aspx.cs" Inherits="Candidate_CandidatesList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Candidates Master Search</title>
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
    <%-- <script type="text/javascript">

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
    </script>--%>

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
            <span>Candidates Master Search</span>
        </h2>
        <asp:ValidationSummary ID="vsValidators" HeaderText="Important Message(s) :" DisplayMode="BulletList"
            EnableClientScript="true" runat="server" ValidationGroup="Check" />
    </div>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
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
                            Select Category:
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="280px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15%" align="center">
                            Reference No.:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtRefNo" MaxLength="16" Width="280px"></asp:TextBox>
                             <%--<asp:RegularExpressionValidator runat="server" ID="valNumbersOnly" ControlToValidate=""
                                Display="Dynamic" Text="*" ErrorMessage="Please enter a numbers only in Reference No."
                                ValidationGroup="Check" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)">
                            </asp:RegularExpressionValidator>--%>
                        </td>
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
                            Lify Cycle Status :
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="280px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" align="center">
                            Candidate Email:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtEmail" Width="280px"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField1" Value="-1" runat="server" />
                        </td>
                        <td style="width: 15%" align="center">
                            Candidate Phone No:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtPhone" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" align="center">
                            Candidate NIC:
                        </td>
                        <td align="center">
                            <asp:TextBox runat="server" ID="txtNIC" Width="280px"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField2" Value="-1" runat="server" />
                        </td>
                        <td style="width: 15%" align="center">
                            Select City:
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlCity" runat="server" Width="280px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" align="center">
                            Skills/Expertise:
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtacSkill" runat="server" Width="280px"></asp:TextBox>
                            <ajax:autocompleteextender runat="server" id="acSkill" targetcontrolid="txtacSkill"
                                servicemethod="FetchSkillList" servicepath="~/AutoComplete.asmx" minimumprefixlength="2"
                                completioninterval="0" enablecaching="true" completionsetcount="20" completionlistcssclass="completionListElement"
                                completionlistitemcssclass="listItem" completionlisthighlighteditemcssclass="highlightedListItem"
                                firstrowselected="false" onclientitemselected="SkillItemSelected" showonlycurrentwordincompletionlistitem="true">
                            </ajax:autocompleteextender>
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
                            <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                                ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                            </asp:LinkButton>&nbsp;
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="/assets/images/Loading-Text-Animation.gif" alt="" align="middle" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table width="80%" border="0" cellpadding="10" cellspacing="0">
                    <thead>
                        <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                            <th align="center" colspan="10">
                                <table border="0" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <th style="background-color: #999999;" height="25" align="center">
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
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptCandidateLists" runat="server" OnItemDataBound="rptCandidateLists_ItemDataBound">
                            <HeaderTemplate>
                                <tr class="simple">
                                    <th align="center" style="width: 5%">
                                        S.No.
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Reference No.
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Full Name
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Email Address
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Gender
                                    </th>
                                    <th align="center" style="width: 10%">
                                        Phone Number
                                    </th>
                                    <th align="center" style="width: 10%;">
                                        City
                                    </th>
                                    <th align="center" style="width: 10%;">
                                        CNIC
                                    </th>
                                    <th align="center" style="width: 10%;">
                                        Category Name
                                    </th>
                                    <th align="center" style="width: 18%;">
                                        Current Status
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="simple">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("CandidateProfileMapping_Code")%>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                        <a id="aCandidateLink" runat="server" target="_blank">
                                            <%# Eval("Full_Name")%></a>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Email_Address")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Gender")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Phone_Number")%>
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("City")%>
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("NIC")%>
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("CategoryName")%>
                                    </td>
                                    <td style="text-align: left; font-weight: bold">
                                        <%# Eval("Status_Name")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("CandidateProfileMapping_Code")%>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                        <a id="aCandidateLink" runat="server" target="_blank">
                                            <%# Eval("Full_Name")%></a>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Email_Address")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Gender")%>
                                    </td>
                                    <td style="text-align: left">
                                        <%# Eval("Phone_Number")%>
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("City")%>
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("NIC")%>
                                    </td>
                                    <td style="text-align: left;">
                                        <%# Eval("CategoryName")%>
                                    </td>
                                    <td style="text-align: left; font-weight: bold">
                                        <%# Eval("Status_Name")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div style="text-align: center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
