<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="DocumentPrinting.aspx.cs" Inherits="DocumentPrinting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            Document Printing Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px">
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
                    Department
                </td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" Style="width: 180px">
                    </asp:DropDownList>
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
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="box-ScheduledActivities" style="background-color: White; padding: 5px 0px 5px 15px;
        margin: 5px 0px 5px 0px">
        <table>
            <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnDataBound">
                <HeaderTemplate>
                    <tr style="font-weight: bold" align="center">
                        <td style="width: 3%">
                            S. No.
                        </td>
                        <td style="width: 6%">
                            Refference No.
                        </td>
                        <td style="width: 15%">
                            Name
                        </td>
                        <td style="width: 15%">
                            Department
                        </td>
                        <td style="width: 15%">
                            Designation
                        </td>
                        <td style="width: 10%">
                            Applied Date
                        </td>
                        <td style="width: 15%" align="left">
                            Documents
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center">
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td>
                            <%# Eval("Candidate_ID")%>
                        </td>
                        <td>
                            <%# Eval("Full_Name")%>
                            <asp:HiddenField ID="HdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                        </td>
                        <td>
                            <%# Eval("Domain_Name")%>
                        </td>
                         <td>
                            <%# Eval("Designation")%>
                        </td>
                        <td>
                            <%# Eval("ApplyDate")%>
                        </td>
                        <td align="left">
                            <div>
                                <asp:Repeater ID="rptDocuments" runat="server" OnItemDataBound="rptDocuments_ItemDatabound">
                                    <ItemTemplate>
                                        <%--<asp:Image ID="Image5" runat="server" ImageUrl="/assets/images/bullet.gif" />--%>
                                        <a id="aMarkPrinted" runat="server" title="Mark Print" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsPrinted") + ";" %>'>
                                            <img src="/A2/assets/images/unchecked.png" width="15" height="15" /></a> <a id="aUnMarkPrinted"
                                                runat="server" title="Unmark Print" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsUnPrinted") + ";" %>'>
                                                <img src="/A2/assets/images/check.png" width="15" height="15" /></a> &nbsp;
                                        &nbsp;<a id="aOfferLetter" runat="server" target="_blank" href='<%# Eval("DocPath")%>'>
                                            <%# Eval("DocName")%></a>
                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="6" align="center">
                    <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
                        Style="display: none"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">

        function UpdateDocPrintingStatus(CanDocCode, IsPrinted, ObjID, obj2ID) {
            var Param = CanDocCode + '|' + '<%=UpdatedBy %>' + '|' + IsPrinted
            // alert(Param);
            $.ajax({ type: "POST",
                url: "DocumentPrinting.aspx/UpdateDocPrintingStatus",
                data: JSON.stringify({ items: Param }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $('#' + ObjID).hide();
                    $('#' + obj2ID).show();

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

        $(function () {
            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });
    
    </script>
</asp:Content>
