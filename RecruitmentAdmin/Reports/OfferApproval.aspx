<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="OfferApproval.aspx.cs"
    Inherits="OfferApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/assets/includes/calendar/calendar.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-en.js" type="text/javascript"></script>
    <script src="/assets/includes/calendar/calendar-setup.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="/assets/includes/calendar/calendar-win2k-cold-1.css" />
    <title>Offer Approval</title>
    <style type="text/css">
        .taglinks
        {
            display: block;
            background: #CDE2F6;
            border: 1px solid #BFDAF7;
            color: #036;
            font-size: 11px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 05px 10px 05px 4px;
            float: left;
            margin-right: 5px;
            margin-top: 10px;
        }
        .redselect
        {
            -webkit-appearance: button;
            -moz-appearance: button;
            appearance: button;
            display: inline-block;
            background: #FFD9D9;
            background: -webkit-linear-gradient(top,  #FFD9D9 0%,#FFD9D9 40%,#FFD9D9 100%);
            padding: 6px 30px 6px 15px;
            border-radius: 3px;
            border: 1px solid #aaa;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
            color: #444;
        }
        
        
        .select
        {
            -webkit-appearance: button;
            -moz-appearance: button;
            appearance: button;
            display: inline-block;
            background: #fafafa;
            background: -webkit-linear-gradient(top,  #fafafa 0%,#f4f4f4 40%,#e5e5e5 100%);
            padding: 6px 30px 6px 15px;
            border-radius: 3px;
            border: 1px solid #aaa;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
            color: #444;
        }
        
        .select:focus
        {
            outline: none;
        }
        
        .select-arrow
        {
            background-color: Black;
            display: inline-block;
            position: absolute;
            margin: .9em 0 0 -1.2em;
            border-left: 5px solid;
            border-right: 5px solid;
            border-top: 5px solid #777;
        }
        
        .chkbox INPUT
        {
            color: black;
            border-style: none;
            font-family: Tahoma;
            font-size: 11px;
            margin-right: 5px;
        }
        
        .mytd
        {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            border: 0px 0px 0px 0px;
            border-style: solid;
            border-width: 0px;
        }
        .mytable
        {
            margin: 0px;
            padding: 0px;
            border: 0px;
            width: 100px;
            cellspacing: 0px;
            cellpadding: 0px;
        }
        .layer1
        {
            margin: 0;
            padding: 0;
        }
        
        .heading
        {
            border: 1px solid #CCCCCC;
            background: url(/assets/images/graGradiant1.jpg) 50% 50% repeat-x;
            font-weight: normal;
            color: #555555;
            display: block;
            cursor: pointer;
            margin-top: 2px;
            padding: .5em .5em .5em .7em;
            min-height: 0;
            display: block;
            font-size: 1.17em;
            -webkit-margin-before: .5em;
            -webkit-margin-after: .5em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
            font-weight: bold;
            height: 20px;
            -khtml-border-radius: 4px 4px 4px 4px;
            -moz-border-radius: 4px 4px 4px 4px;
            -ms-border-radius: 4px 4px 4px 4px;
            -o-border-radius: 4px 4px 4px 4px;
            -webkit-border-radius: 4px 4px 4px 4px;
            border-radius: 4px 4px 4px 4px;
        }
        .content
        {
            background-color: #fafafa;
        }
        p
        {
            padding: 5px 0;
        }
    </style>
    <script type="text/javascript">
        function CheckAllCheckBoxes(obj) {
            chk = document.documentElement.getElementsByTagName('input');
            for (var i = 0; i < chk.length; i++) {

                if (chk[i].id.indexOf('chkCandidate') >= 0) {
                    chk[i].checked = obj.checked;
                }
                if (chk[i].id.indexOf('txtNewreq') >= 0) {
                    if (obj.checked) {
                        chk[i].readOnly = false;
                        chk[i].disabled = false;
                    }
                    else {
                        chk[i].readOnly = true;
                        chk[i].disabled = true;
                    }
                }
            }


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Offer Approval</span>
        </h2>
    </div>
    <div class="contentarea">
        <table id="tblmain" runat="server" width="100%" cellspacing="0" cellpadding="4" class="Center">
            <tr>
                <td style="width: 20%" align="right">
                    Departments :
                </td>
                <td style="width: 30%" colspan="3">
                    <asp:DropDownList ID="ddlDept" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td align="right" width="100px">
                    Name :
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Date :
                </td>
                <td>
                    <input runat="server" width="50px" type="text" id="postedFromDate" style="width: 120px" />
                    <img src="/assets/Includes/calendar/calendar.gif" alt="" width="20" height="20" id="img5" /><strong>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "ctl00_BodyContent_postedFromDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img5",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </strong>
                    <input runat="server" width="50px" type="text" id="postedToDate" style="width: 120px" />
                    <img src="/assets/Includes/calendar/calendar.gif" alt="" width="20" height="20" id="img6" /><strong>
                        <script type="text/javascript">
                            Calendar.setup({
                                inputField: "ctl00_BodyContent_postedToDate",      // id of the input field
                                ifFormat: "M dd, y",       // format of the input field
                                //ifFormat       :    "y-M-dd",       // format of the input field
                                //ifFormat       :    "M-dd-y",       // format of the input field
                                button: "img6",   // trigger for the calendar (button ID)
                                singleClick: true            // double-click mode
                            });
                        </script>
                    </strong>
                </td>
                <td align="right">
                    Ref # :
                </td>
                <td>
                    <asp:TextBox ID="txtRefNo" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button runat="server" ID="btnSearch" CssClass="btn-ora nl" Text="Search" OnClick="btn_SearchClick" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <div id="container" class="contentarea">
            <table border="0" cellpadding="5" cellspacing="0" class="none">
                <tr class="simple" id="trPagingControls" runat="server" align="center">
                    <td bgcolor="#EFEFEF" style="text-align: center;" width="100%">
                        <asp:HiddenField ID="hdCount" runat="server"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="hdnUserTypeCode" />
                        <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False"><img src="/aasets/images/icons/first.png" alt="First Page" /></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click" Visible="False"><img src="/aasets/images/icons/left.png" alt="Previous Page" /></asp:LinkButton>&nbsp;
                        &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
                        &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False"><img src="/aasets/images/icons/right.png" alt="Next Page" /></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                            ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False"><img src="/aasets/images/icons/last.png" alt="Last Page" /></asp:LinkButton>&nbsp;
                    </td>
                </tr>
            </table>
            <table>
                <tr id="trFound" runat="server" style="border: none">
                    <td style="border: none">
                        <table>
                            <asp:Repeater runat="server" ID="rptJDLIst" OnItemDataBound="rptjdlist_ItemDataBound"
                                OnItemCommand="rptjdlist_CommandArguments">
                                <HeaderTemplate>
                                    <thead>
                                        <tr class="greyHeading">
                                            <th style="width: 5%" align="center">
                                                <input type="checkbox" id="chkAllCandidate" runat="server" onclick="javascript:CheckAllCheckBoxes(this)" />
                                            </th>
                                            <th class="font9" width="3%" align="center" height="18">
                                                S.No
                                            </th>
                                            <th class="font9" width="7%" align="center" height="18">
                                                Ref #
                                            </th>
                                            <th class="font9" width="20%" align="center" height="18">
                                                Name
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Department
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Profile
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Considerd for Jd
                                            </th>
                                            <th class="font9" width="5%" align="center" height="18">
                                                Mapping
                                            </th>
                                            <th class="font9" width="5%" align="center" height="18">
                                                Salary Quote
                                            </th>
                                            <th class="font9" width="5%" align="center" height="18">
                                                Bank Statement
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Offered Grade
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Offered Salary
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Offered Position
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Justification
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                HR Approval
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Domain owner approval
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                OPD Approval
                                            </th>
                                            <th class="font9" width="10%" align="center" height="18">
                                                Audit Approval
                                            </th>
                                        </tr>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="normal">
                                        <td style="text-align: center;">
                                            <input id="chkCandidate" runat="server" type="checkbox" />
                                            <asp:HiddenField runat="server" ID="hdnCand_Cat_Code" Value='<%# Eval("Candidate_Code") %>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label runat="server" ID="lblSno"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("Candidate_ID")%>
                                        </td>
                                        <td valign="middle">
                                            <%# Eval("Full_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Domain_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("UserProfile")%>
                                        </td>
                                        <td>
                                            <%# Eval("CansideredForJD")%>
                                        </td>
                                        <td>
                                            <%# Eval("Mapping")%>
                                        </td>
                                        <td>
                                            <%# Eval("SalaryQuote")%>
                                        </td>
                                        <td>
                                            <%# Eval("BankStatement")%>
                                        </td>
                                        <td>
                                            <%# Eval("Grade_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("OfferedSalary")%>
                                        </td>
                                        <td>
                                            <%# Eval("Designation_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Justification")%>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction66" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveHR" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveHR" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="img11" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveHR" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveHR" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img12" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                            </div>
                                            <asp:Literal runat="server" ID="ltrHR"></asp:Literal>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction67" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveDO" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveDO" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="imgEdit" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveDO" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveDO" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img1" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                            <asp:Literal runat="server" ID="ltrDO"></asp:Literal>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction68" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveOPD" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveOPD" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="img15" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveOPD" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveOPD" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img16" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                            </div>
                                            <asp:Literal runat="server" ID="ltrOPD"></asp:Literal>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction69" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveAA" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveAA" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="img13" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveAA" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveAA" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img14" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                            <asp:Literal runat="server" ID="ltrAA"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="grey">
                                        <td style="text-align: center">
                                            <input id="chkCandidate" runat="server" type="checkbox" />
                                            <asp:HiddenField runat="server" ID="hdnCand_Cat_Code" Value='<%# Eval("Candidate_Code") %>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label runat="server" ID="lblSno"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("Candidate_ID")%>
                                        </td>
                                        <td valign="middle">
                                            <%# Eval("Full_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Domain_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("UserProfile")%>
                                        </td>
                                        <td>
                                            <%# Eval("CansideredForJD")%>
                                        </td>
                                        <td>
                                            <%# Eval("Mapping")%>
                                        </td>
                                        <td>
                                            <%# Eval("SalaryQuote")%>
                                        </td>
                                        <td>
                                            <%# Eval("BankStatement")%>
                                        </td>
                                        <td>
                                            <%# Eval("Grade_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("OfferedSalary")%>
                                        </td>
                                        <td>
                                            <%# Eval("Designation_Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Justification")%>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction66" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveHR" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveHR" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="img11" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveHR" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveHR" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img12" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                            </div>
                                            <asp:Literal runat="server" ID="ltrHR"></asp:Literal>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction67" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveDO" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveDO" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="imgEdit" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveDO" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveDO" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img1" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                            <asp:Literal runat="server" ID="ltrDO"></asp:Literal>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction68" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveOPD" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveOPD" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="img15" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveOPD" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveOPD" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img16" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                            </div>
                                            <asp:Literal runat="server" ID="ltrOPD"></asp:Literal>
                                        </td>
                                        <td style="text-align: center">
                                            <div id="divAction69" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveAA" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="ApproveAA" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="img13" src="/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveAA" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("Candidate_Code") %>'
                                                    CommandName="DisapproveAA" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img14" src="/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                            </div>
                                            <asp:Literal runat="server" ID="ltrAA"></asp:Literal>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <FooterTemplate>
                                    <tr class="normal">
                                        <td colspan="14">
                                        </td>
                                        <td align="center">
                                            <div id="divAction66" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveHR" runat="server" ToolTip="Approve All" CommandName="ApproveHRAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img11" src="/images/approveall.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveHR" runat="server" ToolTip="Disapprove All" CommandName="DisapproveHRAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img12" src="/images/rejectall.jpg" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                        </td>
                                        <td align="center">
                                            <div id="divAction67" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveDO" runat="server" ToolTip="Approve All" CommandName="ApproveDOAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="imgEdit" src="/images/approveall.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveDO" runat="server" ToolTip="Disapprove All" CommandName="DisapproveDOAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img1" src="/images/rejectall.jpg" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                        </td>
                                        <td align="center">
                                            <div id="divAction68" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveOPD" runat="server" ToolTip="Approve All" CommandName="ApproveOPDAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img15" src="/images/approveall.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveOPD" runat="server" ToolTip="Disapprove All" CommandName="DisapproveOPDAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img16" src="/images/rejectall.jpg" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                        </td>
                                        <td align="center">
                                            <div id="divAction69" runat="server" clientidmode="Static" visible="false">
                                                <asp:LinkButton ID="lnkapproveAA" runat="server" ToolTip="Approve All" CommandName="ApproveAAAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img13" src="/images/approveall.png" width="20px" height="20px" /></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDisapproveAA" runat="server" ToolTip="Disapprove All" CommandName="DisapproveAAAll"
                                                    OnClientClick="javascript:return Validate();"> <img id="img14" src="/images/rejectall.jpg" width="20px" height="20px" /></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                </FooterTemplate>
                            </asp:Repeater>
                        </table>
                        <table class="table1" cellpadding="3" cellspacing="1" width="100%" id="Table14" runat="server"
                            style="display: none">
                            <tr class="greyHeading">
                                <th style="width: 5%" align="center">
                                </th>
                                <th colspan="2" class="font9" width="42.8%" align="right" height="18">
                                    TOTAL&nbsp;
                                </th>
                                <th style="display: none;" data-sort="string" class="font9" width="15%" align="center"
                                    height="18">
                                </th>
                                <th class="font9" width="5.3%" align="center" height="18">
                                    <asp:Label runat="server" ID="lbltc"></asp:Label>
                                </th>
                                <th class="font9" width="5.1%" align="center" height="18">
                                    <asp:Label runat="server" ID="lblfc"></asp:Label>
                                </th>
                                <th class="font9" width="5.1%" align="center" height="18">
                                    <asp:Label runat="server" ID="lblufc"></asp:Label>
                                </th>
                                <th class="font9" width="6.2%" align="center" height="18">
                                    <asp:Label runat="server" ID="lblnrc"></asp:Label>
                                </th>
                                <th class="font9" width="16.7%" align="center" height="18">
                                </th>
                                <th class="font9" width="17%" align="center" height="18">
                                </th>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trnorecords" runat="server" style="border: none">
                    <td style="border: none">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>No records Found</b>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
