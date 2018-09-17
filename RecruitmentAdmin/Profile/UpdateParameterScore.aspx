<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="UpdateParameterScore.aspx.cs" Inherits="Profile_UpdateParameterScore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Profile Parameter</title>
    <script type="text/javascript">
        function extractNumber(obj, decimalPlaces, allowNegative) {
            var temp = obj.value;

            // avoid changing things if already formatted correctly
            var reg0Str = '[0-9]*';
            if (decimalPlaces > 0) {
                reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
            } else if (decimalPlaces < 0) {
                reg0Str += '\\.?[0-9]*';
            }
            reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
            reg0Str = reg0Str + '$';
            var reg0 = new RegExp(reg0Str);
            if (reg0.test(temp)) return true;

            // first replace all non numbers
            var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
            var reg1 = new RegExp(reg1Str, 'g');
            temp = temp.replace(reg1, '');

            if (allowNegative) {
                // replace extra negative
                var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
                var reg2 = /-/g;
                temp = temp.replace(reg2, '');
                if (hasNegative) temp = '-' + temp;
            }

            if (decimalPlaces != 0) {
                var reg3 = /\./g;
                var reg3Array = reg3.exec(temp);
                if (reg3Array != null) {
                    // keep only first occurrence of .
                    //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
                    var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
                    reg3Right = reg3Right.replace(reg3, '');
                    reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
                    temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
                }
            }

            obj.value = temp;
        }
        function blockNonNumbers(obj, e, allowDecimal, allowNegative) {
            var key;
            var isCtrl = false;
            var keychar;
            var reg;

            if (window.event) {
                key = e.keyCode;
                isCtrl = window.event.ctrlKey
            }
            else if (e.which) {
                key = e.which;
                isCtrl = e.ctrlKey;
            }

            if (isNaN(key)) return true;

            keychar = String.fromCharCode(key);

            // check for backspace or delete, or if Ctrl was pressed
            if (key == 8 || isCtrl) {
                return true;
            }

            reg = /\d/;
            var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
            var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

            return isFirstN || isFirstD || reg.test(keychar);
        }

    </script>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                //   parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Profile Parameter"></asp:Label>
        </h4>
    </div>
    <div id="container" class="contentarea">
        <asp:HiddenField ID="hdnProfileCode" runat="server" Value="0" />
           <br />
            <br />
        <table width="60%" border="0" cellpadding="10" cellspacing="0">
            <thead>
                <tr id="trPagingControls" runat="server" style="display: none" class="simple">
                    <th align="center">
                        <table border="0" cellpadding="10" cellspacing="0">
                            <tr>
                                <th style="background-color: Black;" height="25" align="center">
                                    <asp:LinkButton ID="lnkbtnFirstPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="First Page" OnClick="lnkbtnFirstPage_Click" Visible="False">&lt;</asp:LinkButton>
                                    &nbsp; &nbsp;<asp:LinkButton ID="lnkbtnPrevPage" runat="server" Font-Bold="True"
                                        Font-color="white" Font-Underline="False" ToolTip="Previous Page" OnClick="lnkbtnPrevPage_Click"
                                        Visible="False">&lt;&lt;</asp:LinkButton>&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblPageIndex"
                                            runat="server" Text="Label" Visible="False" ForeColor="White"></asp:Label>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnNextPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Next Page" OnClick="lnkbtnNextPage_Click" Visible="False">&gt;&gt;</asp:LinkButton>&nbsp;
                                    &nbsp;<asp:LinkButton ID="lnkbtnLastPage" runat="server" Font-Bold="True" Font-Underline="False"
                                        ToolTip="Last Page" OnClick="lnkbtnLastPage_Click" Visible="False">&gt;</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptParameter" runat="server" OnItemDataBound="rptParameter_ItemDataBound"
                    OnItemCommand="rptParameter_ItemCommand">
                    <HeaderTemplate>
                        <tr class="simple">
                            <th style="width: 5%" style="font-weight: bold;">
                                S.No.
                            </th>
                            <th align="center" style="width: 50%; font-weight: bold;">
                                Parameter Name
                            </th>
                            <th align="center" style="width: 10%; font-weight: bold;">
                                Rank
                            </th>
                            <%--         <th align="center" style="width: 20%; font-weight: bold;">
                                Action
                            </th>--%>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="simple">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnProfileParameterScoreCode" runat="server" Value='<%# Eval("ProfileParameterScore_Code")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnParameterCode" runat="server" Value='<%# Eval("Parameter_Code")%>' />
                                <%# Eval("Parameter_Name")%>
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txtRank" onblur="extractNumber(this,0,false);" onkeyup="extractNumber(this,0,false);"
                                    onKeyPress="return blockNonNumbers(this, event, true, false);" runat="server"
                                    MaxLength="3" Width="35px" Text='<%# Eval("Rank")%>'></asp:TextBox>
                            </td>
                            <%--         <td align="center">
                               <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument='<%# Eval("ProfileParameterScore_Code")%>'
                                            Text="Update" CommandName="UpdateScore" /> 
                                <asp:Button ID="btnUpdate" Width="90px" runat="server" CommandArgument='<%# Eval("ProfileParameterScore_Code")%>'
                                    Text="Update" CommandName="UpdateScore" />
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                    <tr class="grey">
                            <td style="text-align: center">
                                <asp:Label ID="lblSno" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnProfileParameterScoreCode" runat="server" Value='<%# Eval("ProfileParameterScore_Code")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:HiddenField ID="hdnParameterCode" runat="server" Value='<%# Eval("Parameter_Code")%>' />
                                <%# Eval("Parameter_Name")%>
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txtRank" onblur="extractNumber(this,0,false);" onkeyup="extractNumber(this,0,false);"
                                    onKeyPress="return blockNonNumbers(this, event, true, false);" runat="server"
                                    MaxLength="3" Width="35px" Text='<%# Eval("Rank")%>'></asp:TextBox>
                            </td>
                            <%--         <td align="center">
                               <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument='<%# Eval("ProfileParameterScore_Code")%>'
                                            Text="Update" CommandName="UpdateScore" /> 
                                <asp:Button ID="btnUpdate" Width="90px" runat="server" CommandArgument='<%# Eval("ProfileParameterScore_Code")%>'
                                    Text="Update" CommandName="UpdateScore" />
                            </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <br />
        <div align="center">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-ora nl" OnClick="btnUpdate_Click" />
        </div>
    </div>
</asp:Content>
