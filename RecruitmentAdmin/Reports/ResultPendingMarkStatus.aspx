<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResultPendingMarkStatus.aspx.cs" Inherits="Reports_ResultPendingMarkStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Pending Results</title>
    <script src="/a2/assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
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


        function toggleCheck(chk, id) {
            
            var frm = chk.parentNode.parentNode.parentNode.parentNode.getElementsByTagName('input')
            for (var i = 0; i < frm.length; i++)
                if (frm[i].id.indexOf(id) > -1 && frm[i].type == 'checkbox')
                    frm[i].checked = chk.checked;
        }

        function onpress() {

            $('#id_search_list').quicksearch('#test tbody tr');
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Pending Test Results</span>
        </h2>
        <asp:ValidationSummary ID="vsValidators" HeaderText="Important Message(s) :" DisplayMode="BulletList"
            EnableClientScript="true" runat="server" ValidationGroup="Check" />
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
                    Select Requisition:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlrequisition" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Reference No.:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRefNo" MaxLength="16" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Candidate Name:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtCandidateName" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 15%" align="center">
                    Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="280px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter valid Email Address" Font-Bold="True" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="<img src='/assets/images/Exclamation.gif' title='Valid Email Address is required!' />"
                        ValidationGroup="Check" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Department
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    NIC
                </td>
                <td>
                    <asp:TextBox ID="txtNIC" runat="server" Width="280px"></asp:TextBox><br />
                    (e.g 9999999999999)
                    <asp:RegularExpressionValidator ID="revNIC" runat="server" ControlToValidate="txtNIC"
                        ErrorMessage="Please enter valid NIC Number" Font-Bold="True" Display="Dynamic"
                        ForeColor="Red" Text="<img src='/assets/images/Exclamation.gif' title='Valid NIC is required!' />"
                        ValidationExpression="^[0-9]*$" ValidationGroup="Check"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                    <td style="width: 15%" align="center"">
                        From Date :
                    </td>
                    <td style="width: 15%;padding-left:10px" >
                        <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 120px"
                            clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                height="16" id="img1" />

                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedFromDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img1",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>


                    </td>
                     <td style="width: 15%" align="center">
                        To Date :
                    </td>
                    <td style="width: 15%" >
                        <input runat="server" width="50px" type="text" id="postedToDate" style="width: 120px"
                            clientidmode="Static" /><img src="/assets/images/icons/calendericon.jpg" alt="" width="16"
                                height="16" id="img2" />
                    
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedToDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img2",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>

                    </td>
                </tr>
            <tr>
                <td align="center" style="width: 15%">
                    Status&nbsp;
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="280px">
                    </asp:DropDownList>
                    &nbsp;
                </td>
                <td style="width: 15%" align="center" colspan="2">
                </td>
                
            </tr>
            <tr>
                <td align="center" colspan="4">
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
        <span style="padding-left:20px">Filter :</span>
            <input type="text" name="" placeholder="Search" value="" id="id_search_list" onkeyup="javascript:onpress();" />
            <br /><br />
        <table width="80%" border="0" cellpadding="10" cellspacing="0" id="test">
            <tbody>
                <asp:Repeater ID="rptCandidateLists" runat="server" OnItemDataBound="rptCandidateLists_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="simple">
                            <th align="center" style="width: 5%">
                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleCheck(this, 'chkSelect');" />
                            </th>
                            <th align="center" style="width: 5%">
                                S.No.
                            </th>
                            <th align="center" style="width: 5%">
                                Reference No.
                            </th>
                            <th align="center" style="width: 30%">
                                Full Name
                            </th>
                            <th align="center" style="width: 15%">
                                Department
                            </th>
                            <th align="center" style="width: 25%;">
                                Current Status
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="simple">
                            <td align="center" style="width: 5%">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td style="text-align: center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td style="text-align: center">
                                <a id="a1" runat="server" target="_blank">
                                    <%# Eval("Candidate_ID")%></a>
                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Status_Code")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                <a id="aCandidateLink" runat="server" target="_blank">
                                    <%# Eval("Full_Name")%></a>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Department")%>
                            </td>
                            <td style="text-align: left; font-weight: bold">
                                <%# Eval("Status_Name")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="grey">
                            <td align="center" style="width: 5%">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td style="text-align: center">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td style="text-align: center">
                                <a id="a1" runat="server" target="_blank">
                                    <%# Eval("Candidate_ID")%></a>
                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Status_Code")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:HiddenField ID="hdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code")%>' />
                                <a id="aCandidateLink" runat="server" target="_blank">
                                    <%# Eval("Full_Name")%></a>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("Department")%>
                            </td>
                            <td style="text-align: left; font-weight: bold">
                                <%# Eval("Status_Name")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="divAction126" runat="server" visible="false" clientidmode="Static">
        <table border="0" cellpadding="10" cellspacing="0" runat="server" id="tblTest" >
            <tr>
                <th style="width: 10%">
                    Test Result
                </th>
                <th align="left">
                    <asp:DropDownList runat="server" ID="ddlTestResult">
                        <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </th>
                <th style="width: 10%">
                    Comments
                </th>
                <th align="left">
                    <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Height="62px" 
                        Width="306px"></asp:TextBox>
                </th>
            </tr>

            <tr>
                <th colspan="4">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
                </th>
            </tr>
        </table>
        </div>
        <div style="text-align: center">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            <br />
        </div>
    </div>
</asp:Content>
