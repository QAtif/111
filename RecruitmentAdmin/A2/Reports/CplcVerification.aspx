<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="CplcVerification.aspx.cs" Inherits="CplcVerification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <style type="text/css">
        .ButtonsSave11
        {
            cursor: pointer;
            background: linear-gradient(to bottom, #4B8EFC 0%, #4787EE 100%) !important;
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important;
            border: 1px solid #3079ED !important;
            color: #FFF;
            padding: 4px 27px;
        }
        .error
        {
            /* background: #FFD9D9 !important; */
            border: 1px solid #C00 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            CPLC Verification Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px" style="border-collapse: separate !important; border-spacing: 3px">
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                <td>
                    Reference No.
                </td>
                <td>
                    <asp:TextBox ID="txtref" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Date From
                </td>
                <td>
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 180px" />
                </td>
                <td>
                    Date To
                </td>
                <td>
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 180px" readonly="true" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click"
                        CssClass="ButtonsSave11" />
                    <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div class="box-ScheduledActivities" >
        <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnDataBound">
            <HeaderTemplate>
                <table id="tblData">
                    <thead>
                        <tr style="font-weight: bold" align="center">
                            <th style="width: 3%">
                                S. No.
                            </th>
                            <th style="width: 15%">
                                Name
                            </th>
                            <th style="width: 7%">
                                CNIC #
                            </th>
                            <th style="width: 10%">
                                Father Name
                            </th>
                            <th style="width: 5%">
                                DOB
                            </th>
                            <th style="width: 20%">
                                Address
                            </th>
                            <th style="width: 5%">
                                Reference no.
                            </th>
                            <th style="width: 10%" align="center">
                                Status
                            </th>
                            <th style="width: 20%" align="center">
                                Comments
                            </th>
                            <th style="width: 5%">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr align="center">
                    <td align="center">
                        <%#Container.ItemIndex +1 %>
                    </td>
                    <td>
                        <%# Eval("full_name")%>
                    </td>
                    <td>
                        <%# Eval("NIC")%>
                        <asp:HiddenField ID="HdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                    </td>
                    <td>
                        <%# Eval("fatherName")%>
                    </td>
                    <td>
                        <%# Eval("dob")%>
                    </td>
                    <td>
                        <%# Eval("Address")%>
                    </td>
                    <td>
                        <%# Eval("Candidate_ID")%>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlCplcStatus" runat="server" Width="100px">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="rfvstatus" runat="server" ControlToValidate="ddlCplcStatus" InitialValue="0" ValidationGroup=' <%# Eval("Candidate_ID")%>'></asp:RequiredFieldValidator>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCPLCComents" runat="server" TextMode="MultiLine" Text=' <%# Eval("CPLCComents")%>'
                            placeholder="Enter comments">   </asp:TextBox>
                    </td>
                    <td>
                        <div id="divAction118" runat="server" clientidmode="Static" visible="false">
                            <a id="asave" runat="server" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsExsist") + ";" %>'
                                title="Click here to Save">
                                <img src="../assets/images/saveicon.png" alt="" width="30" height="30" /></a>
                        </div>
                        <img src="../assets/images/done.png" alt="" runat="server" id="imgDone" title="Submitted"
                            width="30" height="30" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
            Style="display: none"></asp:Label>
    </div>
    <link href="<%=Page.ResolveUrl("~")%>A2/assets/css/Jquery-Ui-Smoothness.css" rel="stylesheet" type="text/css" />
    <link href="<%=Page.ResolveUrl("~")%>A2/assets/css/DataTable.css" rel="stylesheet" type="text/css" />
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/DataTable.js" type="text/javascript"></script>
    <script type="text/javascript">

        function InsertCplcVerification(CanCode, ddlStatusID, txtComments, BtnSave, imgDone) {

            var e = document.getElementById(ddlStatusID);
            var status = e.options[e.selectedIndex].value;
            if (status != 0 && $('#' + txtComments).val() != '') {
                $('#' + ddlStatusID).removeClass('error');
                $('#' + txtComments).removeClass('error');
                var Param = CanCode + '|' + status + '|' + $('#' + txtComments).val() + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>'
                //alert(Param);
                $.ajax({ type: "POST",
                    url: "CplcVerification.aspx/InsertCplcVerification",
                    data: JSON.stringify({ items: Param }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        $('#' + BtnSave).hide();
                        $('#' + imgDone).show();

                    },
                    error: function (msg) {
                        alert("error");
                    }
                });
            }

            else {
                if (status == 0)
                    $('#' + ddlStatusID).addClass('error');
                else
                    $('#' + ddlStatusID).removeClass('error');

                if ($('#' + txtComments).val() == '')
                    $('#' + txtComments).addClass('error');
                else
                    $('#' + txtComments).removeClass('error');

            }
        }
        $(document).ready(function () {
            $('#tblData').dataTable();
        });

        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });

            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });

    
    </script>
</asp:Content>
