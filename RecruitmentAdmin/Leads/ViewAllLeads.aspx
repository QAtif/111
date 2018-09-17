<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ViewAllLeads.aspx.cs" Inherits="Leads_ViewAllLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Leads</title>
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/css/iframe.css" />
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <style>
        .maincontainer, .greyfooterbarbg
        {
            width: 99% !important;
            margin: 0 auto;
        }
        #container
        {
            padding: 5px 0;
        }
    </style>
    <script type="text/javascript">
        function btnClick() {
            document.getElementById('<%= lnkSearch.ClientID %>').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Signup Leads</span>
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
    <div id="container" class="contentarea" style="width: 100%">
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <tr>
                <th colspan="4">
                    Search Criteria
                </th>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Select Industry:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlIndustry" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Select Intrest:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlIntrest" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Select Country:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    Select Designation:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlDesignation" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    FeedBack Type:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlFeedBackType" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    SignUp Type:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlSignupType" runat="server" Width="280px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Name:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtName" Width="280"></asp:TextBox>
                </td>
                <td style="width: 15%" align="center">
                    Email Address:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="txtEmail" Width="280"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    Product:
                </td>
                <td align="center">
                    <asp:DropDownList ID="ddlProduct" runat="server"  Width="280px">
                    </asp:DropDownList>
                </td>
                <td style="width: 15%" align="center">
                    &nbsp;
                </td>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 15%" align="center">
                    From Date:
                </td>
                <td align="center">
                    <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 260px"
                        clientidmode="Static" />
                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img5" /><strong>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedFromDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img5",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </strong>
                </td>
                <td style="width: 15%" align="center">
                    To Data:
                </td>
                <td align="center">
                    <input runat="server" width="50px" type="text" id="postedToDate" style="width: 260px"
                        clientidmode="Static" />
                    <img src="/assets/images/icons/calendericon.jpg" alt="" width="16" height="16" id="img6" /><strong>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "postedToDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img6",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </strong>
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
        <table width="100%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControlsFeedBack" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="14">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPageFeedBack" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPageFeedBack_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPageFeedBack" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPageFeedBack_Click"
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndexFeedBack" runat="server" Text="Label" Visible="False"
                                        Font-Bold="true" ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton
                                            ID="lnkbtnNextPageFeedBack" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="Next Page" OnClick="lnkbtnNextPageFeedBack_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPageFeedBack" runat="server" Font-Bold="True"
                                        Font-Underline="False" ToolTip="Last Page" OnClick="lnkbtnLastPageFeedBack_Click"
                                        Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr id="trPagingControlsMagazine" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="14">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPageMagazine" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPageMagazine_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPageMagazine" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPageMagazine_Click"
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndexMagazine" runat="server" Text="Label" Visible="False"
                                        Font-Bold="true" ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton
                                            ID="lnkbtnNextPageMagazine" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="Next Page" OnClick="lnkbtnNextPageMagazine_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPageMagazine" runat="server" Font-Bold="True"
                                        Font-Underline="False" ToolTip="Last Page" OnClick="lnkbtnLastPageMagazine_Click"
                                        Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr id="trPagingControlsPreSignup" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="9">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPageSignup" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPageSignup_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPageSignUp" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPageSignUp_Click"
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndexSignUp" runat="server" Text="Label" Visible="False"
                                        Font-Bold="true" ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton
                                            ID="lnkbtnNextPageSignUp" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="Next Page" OnClick="lnkbtnNextPageSignUp_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPageSignUp" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Last Page" OnClick="lnkbtnLastPageSignUp_Click" Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr id="trPagingControlsContactUS" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="13">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPageContact" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPageContact_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPageContact" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPageContact_Click"
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndexContact" runat="server" Text="Label" Visible="False"
                                        Font-Bold="true" ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton
                                            ID="lnkbtnNextPageContact" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="Next Page" OnClick="lnkbtnNextPageContact_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPageContact" runat="server" Font-Bold="True"
                                        Font-Underline="False" ToolTip="Last Page" OnClick="lnkbtnLastPageContact_Click"
                                        Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                <tr id="trPagingControlsOther" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="14">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPageOther" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPageOther_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPageOther" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPageOther_Click"
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndexOther" runat="server" Text="Label" Visible="False"
                                        Font-Bold="true" ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton
                                            ID="lnkbtnNextPageOther" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="Next Page" OnClick="lnkbtnNextPageOther_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPageOther" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Last Page" OnClick="lnkbtnLastPageOther_Click" Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
                

                <tr id="trPagingControlsBusEmp" runat="server" style="display: none" class="simple">
                    <th align="center" colspan="14">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPageBusEmp" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPageBusEmp_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPageBusEmp" runat="server" Font-Bold="True"
                                        Font-color="Black" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPageBusEmp_Click"
                                        Visible="False"><strong> &lt;&lt;</strong></asp:LinkButton>&nbsp; &nbsp;&nbsp;
                                    &nbsp;<asp:Label ID="lblPageIndexBusEmp" runat="server" Text="Label" Visible="False"
                                        Font-Bold="true" ForeColor="Black"></asp:Label><strong>&nbsp; &nbsp;</strong><asp:LinkButton
                                            ID="lnkbtnNextPageBusEmp" runat="server" Font-Bold="True" Font-Underline="False"
                                            ToolTip="Next Page" OnClick="lnkbtnNextPageBusEmp_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPageBusEmp" runat="server" Font-Bold="True"
                                        Font-Underline="False" ToolTip="Last Page" OnClick="lnkbtnLastPageBusEmp_Click"
                                        Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="rptFeedBack" runat="server" OnItemDataBound="rptFeedBack_ItemDataBound"
                OnItemCommand="rptFeedBack_ItemCommand">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center">
                                Name
                            </th>
                            <th align="center">
                                Email
                            </th>
                            <th align="center">
                                Country
                            </th>
                            <th align="center">
                                Phone Number
                            </th>
                            <th align="center">
                                State
                            </th>
                            <th align="center">
                                City
                            </th>
                            <th align="center">
                                FeedBack Type
                            </th>
                            <th align="center">
                                FeedBack
                            </th>
                            <th align="center">
                                Date
                            </th>
                            <th align="center">
                                Updated IP
                            </th>
                            <th align="center">
                                Referer URL
                            </th>
                            <th align="center">
                                URL
                            </th>
                            <th align="center">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("State")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("City_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("FeedBackType")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("FeedBack")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Updated_IP")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("URL")%>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("State")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("City_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("FeedBackType")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("FeedBack")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Updated_IP")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("URL")%>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPreSignUp" runat="server" OnItemDataBound="rptPreSignUp_ItemDataBound"
                OnItemCommand="rptPreSignUp_ItemCommand">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center">
                                Company Name
                            </th>
                            <th align="center">
                                Industry Name
                            </th>
                            <th align="center">
                                Intrest Name
                            </th>
                            <th align="center">
                                Date
                            </th>
                            <th align="center">
                                Updated IP
                            </th>
                            <th align="center">
                                Referer URL
                            </th>
                            <th align="center">
                                URL
                            </th>
                            <th align="center">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Company_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Industry_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Intrest_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Updated_IP")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("URL")%>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Company_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Industry_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Intrest_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Updated_IP")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("URL")%>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptContactUS" runat="server" OnItemDataBound="rptContactUS_ItemDataBound"
                OnItemCommand="rptContactUS_ItemCommand">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center">
                                Name
                            </th>
                            <th align="center">
                                Email
                            </th>
                            <th align="center">
                                Country
                            </th>
                            <th align="center">
                                Phone Number
                            </th>
                            <th align="center">
                                State
                            </th>
                            <th align="center">
                                City
                            </th>
                            <th align="center">
                                FeedBack
                            </th>
                            <th align="center">
                                Date
                            </th>
                            <th align="center">
                                Updated IP
                            </th>
                            <th align="center">
                                Referer URL
                            </th>
                            <th align="center">
                                URL
                            </th>
                            <th align="center">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("State")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("City_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("FeedBack")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Updated_IP")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("URL")%>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("State")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("City_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("FeedBack")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Updated_IP")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("URL")%>
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptOther" runat="server" OnItemDataBound="rptOther_ItemDataBound"
                OnItemCommand="rptOther_ItemCommand">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center">
                                Company Name
                            </th>
                            <th align="center">
                                Industry Name
                            </th>
                            <th align="center">
                                Intrest Name
                            </th>
                            <th align="center">
                                Name
                            </th>
                            <th align="center">
                                Email
                            </th>
                            <th align="center">
                                Country
                            </th>
                            <th align="center">
                                Phone Number
                            </th>
                            <th align="center">
                                Designation
                            </th>
                            <th align="center">
                                Date
                            </th>
                            <th align="center">
                                Referer URL
                            </th>
                            <th align="center">
                                Product
                            </th>
                            <th align="center">
                                Comments
                            </th>
                            <th align="center">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Company_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Industry_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Intrest_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Designation")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("ProductName")%>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblComment" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <a href='<%# String.Format("EditAgentLead.aspx?lCode={0}",Eval("LeadID")) %>' class="openframe"
                                id="aEdit" runat="server">
                                <img src="/assetsprocurement/images/edit.png" />
                            </a>|
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Company_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Industry_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Intrest_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Designation")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Created_Date")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Referer_URL")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("ProductName")%>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblComment" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <a href='<%# String.Format("EditAgentLead.aspx?lCode={0}",Eval("LeadID")) %>' class="openframe"
                                id="aEdit" runat="server">
                                <img src="/assetsprocurement/images/edit.png" />
                            </a>|
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Repeater ID="rptMagazine" runat="server" OnItemDataBound="rptMagazine_ItemDataBound"
                OnItemCommand="rptMagazine_ItemCommand">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center">
                                Name
                            </th>
                            <th align="center">
                                Email
                            </th>
                            <th align="center">
                                Alternate Email
                            </th>
                           
                            <th align="center">
                                Phone Number
                            </th>
                            <th align="center">
                                Cell Number
                            </th>
                            <th align="center">
                                Address
                            </th>
                            <th align="center">
                                City
                            </th>
                            <th align="center">
                                Country
                            </th>
                            
                            <th align="center">
                                Date
                            </th>
                            
                            <th align="center">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("Subscription_Code")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("EmailAddress")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("AlternateEmailAddress")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNo")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("cell_phone")%>
                        </td>
                        <td style="text-align: left">
                            <%# Eval("PermanentAddress")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("City")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        
                        <td style="text-align: center">
                            <%# Eval("creation_date")%>
                        </td>
                                                
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("Subscription_Code")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("Subscription_Code")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("EmailAddress")%>
                        </td>
                        <td style="text-align: left">
                            <%# Eval("AlternateEmailAddress")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PhoneNo")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("cell_phone")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("PermanentAddress")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("City")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        
                        <td style="text-align: center">
                            <%# Eval("creation_date")%>
                        </td>
                                                
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("Subscription_Code")%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>


            <asp:Repeater ID="rptBusEmp" runat="server" OnItemDataBound="rptBusEmp_ItemDataBound"
                OnItemCommand="rptBusEmp_ItemCommand">
                <HeaderTemplate>
                    <tbody>
                        <tr class="simple">
                            <th style="width: 2%">
                                S.No.
                            </th>
                            <th align="center">
                                Name
                            </th>
                            <th align="center">
                                Email
                            </th>                           
                            <th align="center">
                                Phone Number
                            </th>
                            <th align="center">
                                Cell Number
                            </th>
                            <th align="center">
                                Company
                            </th>      
                            <th align="center">
                                Designation
                            </th>          
                            <th align="center">
                                Website
                            </th>                  
                            <th align="center">
                                Country
                            </th>
                            
                            <th align="center">
                                Date
                            </th>
                            
                            <th align="center">
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="trView" runat="server" class="simple">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>                      
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Cell_Number")%>
                        </td>
                        
                        <td style="text-align: center">
                            <%# Eval("Company_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Designation")%>
                        </td>
                        <td style="text-align: left">
                            <%# Eval("WebSite_URL")%>
                        </td>

                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        
                        <td style="text-align: center">
                            <%# Eval("created_date")%>
                        </td>
                                                
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trView" runat="server" class="grey">
                        <td style="text-align: center">
                            <asp:Label ID="lblSno" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:HiddenField ID="hdnLeadID" runat="server" Value='<%# Eval("LeadID")%>' />
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Email")%>
                        </td>                      
                        <td style="text-align: center">
                            <%# Eval("PhoneNumber")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Cell_Number")%>
                        </td>
                        
                        <td style="text-align: center">
                            <%# Eval("Company_Name")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("Designation")%>
                        </td>
                        <td style="text-align: left">
                            <%# Eval("WebSite_URL")%>
                        </td>

                        <td style="text-align: center">
                            <%# Eval("CountryName")%>
                        </td>
                        
                        <td style="text-align: center">
                            <%# Eval("created_date")%>
                        </td>
                                                
                        <td style="text-align: center">
                            <asp:ImageButton ID="imgbtnDel" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandName="Delete" ToolTip="Delete" ImageUrl="/assetsprocurement/images/Delete.png"
                                CommandArgument='<%# Eval("LeadID")%>' />
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
</asp:Content>
