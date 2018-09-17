<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="Assessment.aspx.cs" Inherits="Assessment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
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
            border: 1px solid #CC0000 !important;
        }
        .DatalistCSS
        {
            padding: 4px 27px;
        }
        .center
        {
            margin-left: auto;
            margin-right: auto;
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="width: 100%">
        <div style="background-color: White; padding: 5px 0px 5px 0px; margin-top: 5px;"
            class="center">
            <h2>
                &nbsp;&nbsp;&nbsp; <b><span id="SpTestName" runat="server"></span>&nbsp; Evaluation
                    Form</b>
            </h2>
            <div style="width: 50%; right: 84px; top: 104px; color: #009200;position: absolute;" id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        <div style="background-color: White; padding: 5px 0px 5px 0px; margin-top: 5px;"
            class="center">
            <table>
                <tr>
                    <td style="height: 40px; padding-left: 20px">
                        Candidate Name:
                    </td>
                    <td>
                        <asp:Label ID="txtCandidateName" runat="server"></asp:Label>
                    </td>
                    <td style="padding-left: 20px">
                        Department:
                    </td>
                    <td>
                        <asp:Label ID="txtDepartmentName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px; padding-left: 20px">
                        Position:
                    </td>
                    <td>
                        <asp:Label ID="txtPosition" runat="server"></asp:Label>
                    </td>
                    <td style="padding-left: 20px">
                        Trail Date:
                    </td>
                    <td>
                        <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                            style="width: 180px" readonly="true" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: White; padding: 5px 0px 5px 0px; margin-top: 5px;"
            class="center">
            <table>
                <asp:Repeater ID="RptStaffTestHead" runat="server" OnItemDataBound="RptStaffTestHead_onDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <div style="background-color: #E6E6E6; font-weight: bold; height: 21px; width: 20%;
                                    padding: 6px 0px 0px 11px;">
                                    <%# Eval("Testhead_Name")%>
                                    <asp:HiddenField ID="hdnTestHEadCode" runat="server" Value='<%# Eval("Testhead_Code")%>' />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="margin-top: 5px !important; width: 100%">
                                    <tr>
                                        <td style="width: 33%; border: 1px solid #E5E5E5 !Important; padding: 20px 0px 20px 0px !important;">
                                            <asp:DataList ID="rptStaffHeadDetail" runat="server" RepeatDirection="Horizontal"
                                                RepeatColumns="3" OnItemDataBound="rptStaffHeadDetail_onDataBound" RepeatLayout="Table"
                                                ItemStyle-Width="33%" ItemStyle-Height="30px" ItemStyle-CssClass="DatalistCSS">
                                                <ItemTemplate>
                                                    <span id="divAction120" runat="server" visible="false" clientidmode="Static">
                                                        <input type="checkbox" id="chkHeadDetail" runat="server" /></span> <b>
                                                            <%#Eval("HeadDetail_Name")%></b>
                                                    <asp:HiddenField ID="hdnHeadDetailCode" runat="server" Value='<%# Eval("HeadDetail_Code")%>' />
                                                    <div style="position: relative">
                                                        <div style="text-align: right; margin-right: 0px; position: absolute; left: 170px;
                                                            bottom: -2px;">
                                                            <asp:Repeater ID="rptstaffEvaluation" runat="server" OnItemDataBound="rptstaffEvaluation_onDataBound">
                                                                <ItemTemplate>
                                                                    <span id="divAction121" runat="server" visible="false" clientidmode="Static">
                                                                        <input type="checkbox" id="chkEvaluationCode" runat="server" checked='<%# Eval("IsChecked") %>' /></span>
                                                                    <%#Eval("Evaluation_Name")%>
                                                                    &nbsp;&nbsp;
                                                                    <asp:HiddenField ID="hdnEvaluationCode" runat="server" Value='<%# Eval("Evaluation_Code")%>' />
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td align="center" style="height: 40px">
                        <div id="divAction119" runat="server" visible="false" clientidmode="Static">
                            <asp:Button ID="btnSave" OnClick="btnSave_Onclick" runat="server" Text="Save" CssClass="ButtonsSave11" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        function Insert_StaffResult(CanCode, HeadDetailCode, Ischecked) {

            //  alert($("#"+Ischecked).is(":checked"));
            var Param = CanCode + '|' + HeadDetailCode + '|' + '<%=TestCode %>' + '|' + $("#" + Ischecked).is(":checked") + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>'
            //  alert(Param);
            //alert(Param);
            $.ajax({ type: "POST",
                url: "Assessment.aspx/Insert_StaffResult",
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

        function Insert_StaffResultEvaluation(CanCode, EvaluationCode, Ischecked) {

            var Param = CanCode + '|' + EvaluationCode + '|' + '<%=TestCode %>' + '|' + $("#" + Ischecked).is(":checked") + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>'
            //alert(Param);
            $.ajax({ type: "POST",
                url: "Assessment.aspx/Insert_StaffResultEvaluation",
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

        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"


            });
        });

           

    </script>
</asp:Content>
