<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MockupCandidateList.aspx.cs" Inherits="Admin_MockupCandidateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .heading
        {
            background: url("/images/banacc-bg.gif") repeat-x scroll 0 0 transparent;
            color: #000000;
            font: 14px 'MyriadProSemibold';
            cursor: pointer;
        }
        .bor
        {
            border-right: 1px;
            border-color: Gray;
            border-style: solid;
        }
        .bol
        {
            border-left: 1px;
            border-color: Gray;
            border-style: solid;
        }
        .bob
        {
            border-bottom: 1px;
            border-color: Gray;
            border-style: solid;
        }
        .style1
        {
            height: 21px;
        }
    </style>
    <title>Candidate Check Test</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="Server">
    <div class="headbar">
    </div>
    <div id="container" class="contentarea">
        <br />
        <table>
            <tr>
                <td colspan="6">
                    <asp:Repeater ID="rptDetails" OnItemDataBound="rptDetails_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table width="100%" cellpadding="4" cellspacing="1">
                                <tr class="grey">
                                    <td align="center">
                                        <strong>S.No </strong>
                                    </td>
                                    <td>
                                        <strong>Name </strong>
                                    </td>
                                    <td align="center">
                                        <strong>Status </strong>
                                    </td>
                                    <td align="center">
                                        <strong>Ref. #</strong>
                                    </td>
                                    <td style="width: 10%" align="center">
                                         <strong>Action</strong>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# (Container.ItemIndex)+1%>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdfCandidate_Code" runat="server" Value='<%#Eval("Candidate_Code") %>'>
                                    </asp:HiddenField>
                                    <asp:Label runat="server" Text='<%#Eval("Full_Name") %>' ID="lblFull_Name"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("Status_Name") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblRefNo" Text='<%#Eval("ReferenceNo") %>'></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <a runat="server" id="btnEdit" class="openframe">
                                        <img src="/assets/images/icons/edit.png" /></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="grey">
                                <td align="center">
                                    <%# (Container.ItemIndex)+1%>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdfCandidate_Code" runat="server" Value='<%#Eval("Candidate_Code") %>'>
                                    </asp:HiddenField>
                                    <asp:Label runat="server" Text='<%#Eval("Full_Name") %>' ID="lblFull_Name"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("Status_Name") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label runat="server" ID="lblRefNo" Text='<%#Eval("ReferenceNo") %>'></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <a runat="server" id="btnEdit" class="openframe">
                                        <img src="/assets/images/icons/edit.png" /></a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </div>
</asp:Content>
