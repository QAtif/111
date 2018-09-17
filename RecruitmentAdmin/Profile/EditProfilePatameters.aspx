<%@ Page Title="Interview Scheduled Candidate" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="EditProfilePatameters.aspx.cs" Inherits="EditProfilePatameters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Edit Profile Parameter</title>
    <style type="text/css">
        .scrollingControlContainer
        {
            overflow-x: hidden;
            overflow-y: scroll;
        }
        
        .scrollingCheckBoxList
        {
            border: 1px #808080 solid;
            margin: 0px 10px 10px 10px;
            height: 600px;
            width: 800px;
        }
        .scrollingCheckBoxList1
        {
            border: 1px #808080 solid;
            margin: 10px 10px 0px 10px;
            width: 800px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="headbar">
        <h2>
            <span>Edit Profile </span>Parameter</h2>
    </div>
    <div id="container" class="contentarea">
        <script type="text/javascript">
            function showHide(obj, obj2) {
                document.getElementById("trskill").style.display = 'none';
                document.getElementById("trEducation").style.display = 'none';
                document.getElementById("trIndustry").style.display = 'none';
                document.getElementById("trmajor").style.display = 'none';
                document.getElementById("trdegree").style.display = 'none';
                document.getElementById(obj).style.display = '';

                document.getElementById("degree").style.backgroundColor = '';
                document.getElementById("Education").style.backgroundColor = '';
                document.getElementById("Industry").style.backgroundColor = '';
                document.getElementById("major").style.backgroundColor = '';
                document.getElementById("skill").style.backgroundColor = '';
                document.getElementById(obj2).style.backgroundColor = '#666666';


            }

        </script>
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <table width="100%" border="0px">
            <tr>
                <td align="right">
                    <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" /><strong>Search
                        :</strong>&nbsp;<asp:TextBox ID="txtsearch" runat="server" OnTextChanged="txtsearch_ontextChange"
                            AutoPostBack="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server"
            UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="center">
                            Select profile:
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlprofile" runat="server" Width="800px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; vertical-align: top">
                            <table>
                                <tr>
                                    <th id="Education" style="background-color: #666666">
                                        <a id="aeducation" href="javascript:;" onclick="showHide('trEducation','Education')">
                                            Institute</a>
                                    </th>
                                </tr>
                                <tr>
                                    <th id="Industry">
                                        <a id="aIndustry" href="javascript:;" onclick="showHide('trIndustry','Industry')">Industry</a>
                                    </th>
                                </tr>
                                <tr>
                                    <th id="major">
                                        <a id="amajor" href="javascript:;" onclick="showHide('trmajor','major')">Major</a>
                                    </th>
                                </tr>
                                <tr>
                                    <th id="skill">
                                        <a id="askill" href="javascript:;" onclick="showHide('trskill','skill')">Skilll</a>
                                    </th>
                                </tr>
                                <tr>
                                    <th id="degree">
                                        <a id="adegree" href="javascript:;" onclick="showHide('trdegree','degree')">Degree</a>
                                    </th>
                                </tr>
                                <tr>
                                    <td align="center" style="margin-top: 450px">
                                        <asp:Label ID="lbl" runat="server"></asp:Label>
                                        <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" class="btn-ora nl">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr id="trskill" style="display: none">
                                    <td>
                                        <asp:Panel ID="Panel4" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList1">
                                            <table width="100%">
                                                <tr class="gray" align="left">
                                                    <th>
                                                        <strong>Skill</strong>
                                                    </th>
                                                    <th style="width: 15%">
                                                        <strong>Ismadantory</strong>
                                                    </th>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel5" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                            <table width="100%">
                                                <asp:Repeater ID="lstskill" runat="server">
                                                    <ItemTemplate>
                                                        <tr align="left">
                                                            <td>
                                                                <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("skill") %>' />
                                                                <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("skill_code") %>' />
                                                            </td>
                                                            <td style="width: 15%">
                                                                <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <tr class="gray" align="left">
                                                            <td>
                                                                <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("skill") %>' />
                                                                <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("skill_code") %>' />
                                                            </td>
                                                            <td style="width: 15%">
                                                                <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                            </td>
                                                        </tr>
                                                    </AlternatingItemTemplate>
                                                </asp:Repeater>
                                        </asp:Panel>
                            </table>
                        </td>
                    </tr>
                    <tr id="trEducation" style="display: inline">
                        <td>
                            <asp:Panel ID="Panel7" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList1">
                                <table width="100%">
                                    <tr class="gray" align="left">
                                        <th>
                                            <strong>Institute</strong>
                                        </th>
                                        <th style="width: 15%">
                                            <strong>Ismadantory</strong>
                                        </th>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel6" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                <table width="100%">
                                    <asp:Repeater ID="lstEducationl" runat="server">
                                        <ItemTemplate>
                                            <tr class="simple" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("institute") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("institute_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="gray" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("institute") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("institute_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr id="trIndustry" style="display: none">
                        <td>
                            <asp:Panel ID="Panel8" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList1">
                                <table width="100%">
                                    <tr class="gray" align="left">
                                        <th>
                                            <strong>Industry</strong>
                                        </th>
                                        <th style="width: 15%">
                                            <strong>Ismadantory</strong>
                                        </th>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel1" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                <table width="100%">
                                    <asp:Repeater ID="lstindustryl" runat="server">
                                        <ItemTemplate>
                                            <tr class="simple" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("industry") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("industry_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="gray" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("industry") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("industry_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr id="trmajor" style="display: none">
                        <td>
                            <asp:Panel ID="Panel9" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList1">
                                <table width="100%">
                                    <tr class="gray" align="left">
                                        <th>
                                            <strong>Major</strong>
                                        </th>
                                        <th style="width: 15%">
                                            <strong>Ismadantory</strong>
                                        </th>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel2" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                <table width="100%">
                                    <asp:Repeater ID="lstmajor" runat="server">
                                        <ItemTemplate>
                                            <tr class="simple" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("major_name") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("major_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="gray" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("major_name") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("major_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr id="trdegree" style="display: none">
                        <td>
                            <asp:Panel ID="Panel10" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList1">
                                <table width="100%">
                                    <tr class="gray" align="left">
                                        <th>
                                            <strong>Degree</strong>
                                        </th>
                                        <th style="width: 15%">
                                            <strong>Ismadantory</strong>
                                        </th>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel3" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                <table width="100%">
                                    <asp:Repeater ID="lstdegree" runat="server">
                                        <ItemTemplate>
                                            <tr class="simple" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("degree") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("degree_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="gray" align="left">
                                                <td>
                                                    <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("degree") %>' />
                                                    <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("degree_code") %>' />
                                                </td>
                                                <td width="15%">
                                                    <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                </td> </tr> </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtsearch" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
