<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfileParameter.aspx.cs"
    Inherits="EditProfileParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WebForm1</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <style type="text/css">
        
        .scrollingControlContainer
        {
            overflow-x: hidden;
            overflow-y: scroll;
        }
        
        .scrollingCheckBoxList
        {
            border: 1px #808080 solid;
            margin: 10px 10px 10px 10px;
            height: 600px;
            width :800px;
        }
    </style>
</head>
<body>
    <script type="text/javascript">
        function showHide(obj) {
            document.getElementById("trskill").style.display = 'none';
            document.getElementById("trEducation").style.display = 'none';
            document.getElementById("trIndustry").style.display = 'none';
            document.getElementById("trmajor").style.display = 'none';
            document.getElementById("trdegree").style.display = 'none';
            document.getElementById(obj).style.display = '';


        }

    </script>
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        Select profile:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlprofile" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%; vertical-align: top">
                        <table>
                            <tr>
                                <td>
                                    <a id="aeducation" href="javascript:;" onclick="showHide('trEducation')">Education</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a id="aIndustry" href="javascript:;" onclick="showHide('trIndustry')">Industry</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a id="amajor" href="javascript:;" onclick="showHide('trmajor')">Major</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a id="askill" href="javascript:;" onclick="showHide('trskill')">Skilll</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a id="adegree" href="javascript:;" onclick="showHide('trdegree')">Degree</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table>
                            <tr id="trskill" style="display: none">
                                <td>
                                    <asp:Panel ID="Panel5" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                        <table width="100%">
                                            <asp:Repeater ID="lstskill" runat="server">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td>
                                                            Skill
                                                        </td>
                                                        <td>
                                                            Ismadantory
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("skill") %>' />
                                                            <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("skill_code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr id="trEducation" style="display: inline">
                                <td>
                                    <asp:Panel ID="Panel6" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                        <table width="100%">
                                            <asp:Repeater ID="lstEducationl" runat="server">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td>
                                                            Institute
                                                        </td>
                                                        <td width="15%">
                                                            Ismadantory
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("institute") %>' />
                                                            <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("institute_code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr id="trIndustry" style="display: none">
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                        <table width="100%">
                                            <asp:Repeater ID="lstindustryl" runat="server">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td>
                                                            Industry
                                                        </td>
                                                        <td width="15%">
                                                            Ismadantory
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("industry") %>' />
                                                            <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("industry_code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr id="trmajor" style="display: none">
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                        <table width="100%">
                                            <asp:Repeater ID="lstmajor" runat="server">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td>
                                                            Major
                                                        </td>
                                                        <td width="15%">
                                                            Ismadantory
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("major_name") %>' />
                                                            <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("major_code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr id="trdegree" style="display: none">
                                <td>
                                    <asp:Panel ID="Panel3" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
                                        <table width="100%">
                                            <asp:Repeater ID="lstdegree" runat="server">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td>
                                                            Degree
                                                        </td>
                                                        <td width="15%">
                                                            Ismadantory
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="checkBoxPanel" runat="server" Text='<%# Eval("degree") %>' />
                                                            <asp:HiddenField ID="parameterValueCode" runat="server" Value='<%# Eval("degree_code") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkmandatory" runat="server" Text="mandatory" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl" runat="server"></asp:Label>
                                    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
