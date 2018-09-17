<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditTeam.aspx.cs" EnableEventValidation="false" Inherits="UniversalData_AddEditTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Team</title>
    <script type="text/javascript" src="../Scripts/jquery.dualListBox-1.3.min.js" language="javascript"></script>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            if (parent != null) {
                fullQs = window.location.search.substring(1);
                mainURL = parent.window.location.href;
                var url = mainURL.split("?");
                if (url != null && url.length > 0)
                    mainURL = url[0];
                // parent.window.location.href = mainURL;  //+ "?" + window.location.search.substring(1);
                parent.window.location.href = parent.window.location.href;
            }
            this.close();
        }


        $(function () {

            $.configureBoxes({
                box1View: '<%=lbUsersNotMark.ClientID%>',
                box1Storage: 'user1Storage',
                box1Filter: 'user1Filter',
                box1Clear: 'user1Clear',
                box1Counter: 'user1Counter',
                box2View: '<%=lbUsersMark.ClientID%>',
                box2Storage: 'user2Storage',
                box2Filter: 'user2Filter',
                box2Clear: 'user2Clear',
                box2Counter: 'user2Counter',
                to1: 'user2touser1',
                to2: 'user1touser2',
                allTo1: 'user2allTouser1',
                allTo2: 'user1allTouser2'
            });

        });

        function PutListBoxItemsToHiddenFields() {
            var lbox;

            //work for statuses
            var lbox = document.getElementById('<%=lbUsersMark.ClientID%>');
            var dVar = "";
            for (var i = 0; i < lbox.options.length; ++i)
                dVar = dVar + lbox.options[i].value + ",";
            document.getElementById('<%=hfUsers.ClientID%>').value = dVar;
            

        }

      

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Add Team"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnTeamCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        Team Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTeamName" runat="server" Width="200px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtTeamName"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="Team name can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="70%" border="1" cellspacing="2" cellpadding="2" class="simple">
                            <tr>
                                <th colspan="3">
                                    <b>Users Marking</b>
                                </th>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table border="0" align="left" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left" valign="baseline" class="gray">
                                                Filter:
                                            </td>
                                            <td align="left" valign="baseline">
                                                <input type="text" id="user1Filter" />
                                            </td>
                                            <td align="left" valign="baseline">
                                                <img type="button" id="user1Clear" src="/assetsprocurement/images/Delete.png" alt="Clear" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="margin: 10px 0; clear: both;">
                                        <asp:ListBox ID="lbUsersNotMark" runat="server" Width="300px" Height="350px" SelectionMode="Multiple"
                                            DataTextField="Name" DataValueField="UserID"></asp:ListBox>
                                        <br />
                                        <span id="user1Counter" class="countLabel"></span>
                                        <select id="user1Storage">
                                        </select>
                                    </div>
                                </td>
                                <td valign="middle">
                                    <button id="user1touser2" type="button">
                                        &nbsp;&gt;&nbsp;</button>
                                    <button id="user1allTouser2" type="button">
                                        &nbsp;&gt;&gt;&nbsp;</button>
                                    <button id="user2allTouser1" type="button">
                                        &nbsp;&lt;&lt;&nbsp;</button>
                                    <button id="user2touser1" type="button">
                                        &nbsp;&lt;&nbsp;</button>
                                </td>
                                <td align="center">
                                    <table border="0" align="left" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td align="left" valign="baseline">
                                                Filter:
                                            </td>
                                            <td align="left" valign="baseline">
                                                <input type="text" id="user2Filter" />
                                            </td>
                                            <td align="left" valign="baseline">
                                                <img type="button" id="user2Clear" src="/assetsprocurement/images/Delete.png" alt="Clear" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="margin: 10px 0; clear: both;">
                                        <asp:ListBox ID="lbUsersMark" Width="300px" Height="350px" SelectionMode="Multiple"
                                            runat="server" DataTextField="Name" DataValueField="UserID"></asp:ListBox>
                                        <br />
                                        <span id="user2Counter" class="countLabel"></span>
                                        <select id="user2Storage">
                                        </select>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr1" runat="server" class="simple">
                    <td bgcolor="#F7F7F7" colspan="2">
                        <table width="100%" border="0" cellspacing="0" cellpadding="6">
                            <tr>
                                <th>
                                    <b>Select Domain</b>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chblistDomain" BorderStyle="None" runat="server" CellPadding="2"
                                        CellSpacing="4" RepeatDirection="Horizontal" RepeatColumns="4">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                            <tr class="simple">
                                <td colspan="2" align="center">
                                    <asp:button id="btnAdd" runat="server" value="Add Team" class="btn-ora nl" OnClientClick="PutListBoxItemsToHiddenFields()" OnClick="btnAdd_Click"  ValidationGroup="valida" Text="Add Team">
                                       </asp:button>
                                    <%--<asp:Button ID="btnAdd" runat="server" Text="Add Team" CssClass="btn-ora nl" OnClientClick="PutListBoxItemsToHiddenFields();" />
                                    --%><br />
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                                    <%--<asp:Button ID="btn" runat="server" OnClick="btnAdd_Click" Style="display: none"
                                        ValidationGroup="valida" />--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <asp:HiddenField runat="server" ID="hfUsers" />
        </div>
    </div>
</asp:Content>
