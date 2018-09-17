<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateCheckList.aspx.cs"
    Inherits="Candidate_CandidateCheckList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Document Checklist </title>
    <style>
        BODY
        {
            color: #666666;
            font-family: Verdana,Arial,Helvetica,sans-serif;
            font-size: 12px;
            margin: 0;
        }
        .myBody
        {
            background-image: url("/assets/images/mbg2.gif");
            background-position: left top;
            background-repeat: no-repeat;
            margin: 15px;
        }
        
        .DG_LeaveHistory_Header
        {
            background-color: #DADADA;
            background-image: url("/assets/images/grayBg.gif");
            background-position: center top;
            background-repeat: repeat-x;
            border-style: none;
            color: #666666;
            font-family: Verdana;
            font-size: 12px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            height: 25px;
            text-align: center;
        }
    </style>
</head>
<body class="mybody" onload="javascript:Clickheretoprint();">
    <form runat="server" id="Form1">
    <div>
        <asp:HiddenField ID="hdnCandCode" runat="server" Value="0" />
        <table style="width: 90%" align="center" border="0" cellspacing="2" cellpadding="2">
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td colspan="5">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" style="background-color: #999999; color: White;">
                                <b>Candidate Info</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 22%">
                            </td>
                            <td style="width: 52%">
                            </td>
                            <td colspan="3" width="65%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 22%">
                                Candidate Name :&nbsp;
                            </td>
                            <td style="width: 52%">
                                <asp:Label ID="lblCandidateName" runat="server"></asp:Label>
                            </td>
                            <td colspan="3" width="65%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 22%">
                                Department :&nbsp;
                            </td>
                            <td style="width: 52%">
                                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                            </td>
                            <td colspan="3" width="65%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 22%">
                                Designation :&nbsp;
                            </td>
                            <td style="width: 52%">
                                <asp:Label ID="lblCandidateDesignation" runat="server"></asp:Label>
                            </td>
                            <td colspan="3" width="65%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 22%">
                                Job Category :&nbsp;
                            </td>
                            <td style="width: 52%">
                                <asp:Label ID="lblCandidateJobCategory" runat="server"></asp:Label>
                            </td>
                            <td colspan="3" width="65%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="rptDocumentPersonal" runat="server" OnItemDataBound="rptDocumentPersonal_OnItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0" border="1" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2" style="background-color: #999999; color: White" align="center">
                                        Personal Record
                                    </td>
                                </tr>
                                <tr class="DG_LeaveHistory_Header">
                                    <td width="8%" align="center">
                                        S.No.
                                    </td>
                                    <td align="center">
                                        Document
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblSNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                    <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                    <asp:Repeater ID="rptDocumentExperience" runat="server" OnItemDataBound="rptDocumentExperience_OnItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0" border="1" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2" style="background-color: #999999; color: White" align="center">
                                        Experience Record
                                    </td>
                                </tr>
                                <tr class="DG_LeaveHistory_Header">
                                    <td width="8%" align="center">
                                        S.No.
                                    </td>
                                    <td align="center">
                                        Document
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblSNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                    <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br />
                    <asp:Repeater ID="rptDocumentOther" runat="server" OnItemDataBound="rptDocumentOther_OnItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0" border="1" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2" style="background-color: #999999; color: White;" align="center">
                                        Other Record
                                    </td>
                                </tr>
                                <tr class="DG_LeaveHistory_Header">
                                    <td width="8%" align="center">
                                        S.No.
                                    </td>
                                    <td align="center">
                                        Document
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblSNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                    <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%--<table style="width: 100%" align="center" border="1" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="5" style="height: 18px" align="center" style="background-color: #999999">
                                Personal Record
                            </td>
                        </tr>
                        <tr class="DG_LeaveHistory_Header">
                            <td width="5%" align="center">
                                <p class="heading">
                                    <b>S.No.</b>
                                </p>
                            </td>
                            <td align="center">
                                <p class="heading">
                                    <b>Document</b>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-color: Black;" align="center">
                                1
                            </td>
                            <td style="border-color: Black;">
                                Medical Report
                            </td>
                        </tr>
                        <tr style="background-color: #F9FAFE;">
                            <td style="border-color: Black;" align="center">
                                2
                            </td>
                            <td style="border-color: Black;">
                                Bank Statement
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%--<table style="width: 100%" align="center" border="1" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="5" style="height: 18px" align="center" style="background-color: #999999">
                                Professional Record
                            </td>
                        </tr>
                        <tr class="DG_LeaveHistory_Header">
                            <td width="5%" align="center">
                                <p class="heading">
                                    <b>S.No.</b>
                                </p>
                            </td>
                            <td align="center">
                                <p class="heading">
                                    <b>Document</b>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-color: Black;" align="center">
                                1
                            </td>
                            <td style="border-color: Black;">
                                sas Experience Letter
                            </td>
                        </tr>
                        <tr style="background-color: #F9FAFE;">
                            <td style="border-color: Black;" align="center">
                                2
                            </td>
                            <td style="border-color: Black;">
                                sas Experience Letter
                            </td>
                        </tr>
                        <tr>
                            <td style="border-color: Black;" align="center">
                                3
                            </td>
                            <td style="border-color: Black;">
                                BCVBCVB Experience Letter
                            </td>
                        </tr>
                        <tr style="background-color: #F9FAFE;">
                            <td style="border-color: Black;" align="center">
                                4
                            </td>
                            <td style="border-color: Black;">
                                Abacusoft Experience Letter
                            </td>
                        </tr>
                        <tr>
                            <td style="border-color: Black;" align="center">
                                5
                            </td>
                            <td style="border-color: Black;">
                                iak Experience Letter
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="10">
                    <table width="100%">
                        <tr>
                            <td class="verdana12">
                                <b>1. Please bring 5 Copies of NIC.<br />
                                    <br />
                                    2. Please bring all the original documents and photocopies.<br />
                                    <br />
                                    3. Please note that the documents you submit should be in accordance with the information
                                    you submitted earlier.
                                    <br />
                                    <br />
                                </b>
                            </td>
                        </tr>
                        <tr style="background-color: #999999; color: White;">
                            <td>
                                Credential Verification Authorization
                            </td>
                        </tr>
                        <tr>
                            <td class="verdana12">
                                <b>You will be required to sign an authorization form that will be authorizing Axact
                                    to authenticate and verify all your credentials from the past employers, educational
                                    institutes, your provided references and any other entity as they deemed appropriate.
                                </b>
                            </td>
                        </tr>
                        <tr style="background-color: #999999; color: White;">
                            <td>
                                Full-time Job Declaration
                            </td>
                        </tr>
                        <tr>
                            <td class="verdana12">
                                <b>You will be required to sign a declaration form indicating that during the Employment
                                    Term, you will not be allowed to actively engage in any other employment, occupation,
                                    consultation, educational or charitable organization without the prior approval
                                    of the company. </b>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input type="hidden" name="hdnSupport" id="hdnSupport" value="0" />
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function Clickheretoprint() {
        window.print();
    }
</script>
