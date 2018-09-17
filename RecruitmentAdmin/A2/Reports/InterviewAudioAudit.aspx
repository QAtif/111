<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="InterviewAudioAudit.aspx.cs" Inherits="A2_Reports_InterviewAudioAudit" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <style type="text/css">
        .Star
        {
            background-image: url(../assets/images/Star.gif);
            height: 17px;
            width: 17px;
        }
        .WaitingStar
        {
            background-image: url(../assets/images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }
        .FilledStar
        {
            background-image: url(../assets/images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
    <link href="<%=Page.ResolveUrl("~")%>A2/assets/css/Jquery-Ui-Smoothness.css" rel="stylesheet"
        type="text/css" />
    <link href="<%=Page.ResolveUrl("~")%>A2/assets/css/DataTable.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            Offer Audio Audit</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px" style="border-collapse: separate !important; border-spacing: 3px">
            <tr>
                <td>
                    Date From
                </td>
                <td>
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 186px; height: 19px; margin-bottom: 5px; border: 1px #A7A6A6 !important;" />
                </td>
                <td>
                    Date To
                </td>
                <td>
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 186px; height: 19px; margin-bottom: 5px; border: 1px #A7A6A6  !important;"
                        readonly="true" />
                </td>
                <%-- <td>
                Requisition Status
                </td>
                <td>
                  <asp:DropDownList ID="ddlApprovalStatus" runat="server" Width="198px">
                    </asp:DropDownList>
                </td>--%>
            </tr>
            <tr>
                <td>
                    Department
                </td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="198px" >
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                </td>
                <%-- <td>
                    Category
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="198px">
                    </asp:DropDownList>
                </td>
                <td>
                Hired Candidate Status
                </td>
                <td>
                 <asp:DropDownList ID="ddlRequisitionStatus" runat="server" Width="198px">
                    </asp:DropDownList>
                </td>--%>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click"
                        CssClass="ButtonsSave11" />
                    <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold; display:none"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div class="box-ScheduledActivities">
        <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnItemDataBound">
            <HeaderTemplate>
                <table id="tblData">
                    <thead>
                        <tr style="font-weight: bold" align="center">
                            <th style="width: 2%">
                                S. No.
                            </th>
                            <th style="width: 10%">
                                Ref No.
                            </th>
                            <th style="width: 20%">
                                Name
                            </th>
                            <th style="width: 18%">
                                Domain
                            </th>
                            <th style="width: 15%">
                                Comments
                            </th>
                            <th style="width: 5%">
                                Audio File
                            </th>
                            <th style="width: 10%">
                                Rating
                            </th>
                            <th style="width: 10%">
                                Uploaded Date
                            </th>
                            <th style="width: 10%">
                                Reviewed Date
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
                        <%# Eval("candidate_id")%>
                    </td>
                    <td>
                        <%# Eval("full_name")%>
                    </td>
                    <td>
                        <%# Eval("DomainName")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtComments" runat="server" Text='<%# Eval("Comment")%>' TextMode="MultiLine"
                            Style="height: 51px; width: 162px;"></asp:TextBox>
                        <br />
                        <div id="divAction132" runat="server" clientidmode="Static" visible="true">
                            <a id="asave" runat="server" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                title="Click here to Save">
                                <img src="../assets/images/saveicon.png" alt="" width="30" height="30" /></a>
                        </div>
                        <img src="../assets/images/done.png" alt="" runat="server" id="imgDone" title="Submitted"
                            width="30" height="30" style="display: none" />
                    </td>
                    <td>
                        <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                            href='<%# Eval("FilePath") %>' runat="server" tooltip='<%# Eval("FilePath") %>'
                            target="_blank">
                            <img src="/A2/assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                alt="" /></a>
                    </td>
                    <td align="center" style="padding-left: 22px;">
                      <div id="divAction133" runat="server" clientidmode="Static" visible="true" style='<%# "display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'>
                        <cc1:Rating ID="Rating1" AutoPostBack="true" OnChanged="OnRatingChanged" runat="server"
                            StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star" CurrentRating='<%# Eval("Rating")%>'
                            FilledStarCssClass="FilledStar" Tag='<%# Eval("candidate_code")%>' BackImageUrl='<%# Eval("candDoc_code")%>'> 
                        </cc1:Rating>
                        </div>
                    </td>
                    <td>
                        <%# Eval("UpdationDate")%>
                    </td>
                    <td>
                        <%# Eval("UpdatedDate")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <div style="position: absolute; right: 650px;">
            <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
                Style="display: none"></asp:Label>
        </div>
    </div>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/DataTable.js" type="text/javascript"></script>
    <script type="text/javascript">

        function InsertOfferAudioComments(CanCode, CandDocCode, txtComments, BtnSave, imgDone) {

            if ($('#' + txtComments).val() != '') {
                $('#' + txtComments).removeClass('error');
                var Param = CanCode + '|' + CandDocCode + '|' + $('#' + txtComments).val() + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>'
                $.ajax({ type: "POST",
                    url: "InterviewAudioAudit.aspx/InsertOfferAudioComments",
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
                $('#' + txtComments).addClass('error');
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

            if ($input.hasClass('jqTransform') || !$input.is('input')) { return; }
        });

     
    
    </script>
</asp:Content>
