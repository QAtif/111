<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="UserReferralReport.aspx.cs" Inherits="A2_Reports_UserReferralReport" %>




<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>Referred Candidate Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">

        <table cellpadding="3px">
            <tr>
                <td>Candidate Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Style="width: 180px"></asp:TextBox>
                </td>

                <td>Department
                </td>
                <td>
                    <asp:DropDownList ID="ddlDomain" runat="server" AutoPostBack="true" Style="width: 190px !important;" OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>Referred By
                </td>
                <td>
                    <asp:DropDownList ID="ddlUser" runat="server" Style="width: 190px !important;"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    Date From
                </td>
                <td>
                    <br />
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 180px" />
                </td>
                <td>
                    <br />
                    Date To
                </td>
                <td>
                    <br />
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 180px" readonly="true" />
                </td>
                <td>Reference No.
                </td>
                <td>
                    <asp:TextBox ID="txtref" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    City</td>
                <td>
                    <br />
                    <asp:DropDownList ID="ddlCity" runat="server" Style="width: 190px !important;"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <div align="center" style="display: inline-block;">
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="btnSearch_Click"
                            ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <table width="80%" border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnDataBound">
                <HeaderTemplate>
                    <tr style="font-weight: bolder; font-size: 13px; height: 30px; background-color: #ebebeb;">
                        <td align="center" style="width: 3%">S. No.
                        </td>
                        <td align="center" style="width: 8%">Ref No.
                        </td>
                        <td align="center" style="width: 15%">Name
                        </td>
                        <td align="center" style="width: 15%">Email
                        </td>
                        <td align="center" style="width: 15%">City
                        </td>
                        <td align="center" style="width: 15%">Apply Date
                        </td>
                        <td align="center" style="width: 20%">Referred by
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="font-size: 12px; height: 30px;">
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td align="center">
                            <a id="aCandidateLink" runat="server" target="_blank">
                                <%# Eval("CandidateReferenceNo")%></a>
                        </td>

                        <td align="center" valign="top" width="15%">
                            <asp:HiddenField ID="hdnCandCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />


                            <%# Eval("ReferredCanidateName")%>
                        </td>


                        <td align="center">
                            <%# Eval("EmailAddress")%>
                        </td>

                        <td align="center">
                            <%# Eval("City")%>
                        </td>

                        <td align="center">
                            <%# Eval("CreationDate")%>
                        </td>



                        <td align="center" class="last">
                            <%# Eval("ReferByName")%>
                        </td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="4" align="center">
                    <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
                        Style="display: none"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">



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
