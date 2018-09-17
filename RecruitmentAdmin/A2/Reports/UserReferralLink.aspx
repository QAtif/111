<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="UserReferralLink.aspx.cs" Inherits="A2_Reports_UserReferralLink" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>User Referral Link</h2>
    </div>

    <form class="searcharea">
        <div id="fresh-search" class="SearchBox adjustwidth">
            <div class="InsideSearchBox">
                <%--<div class="HeadingInside"> <span class="BasicInfoIcon"></span> <span class="IconTxt">Basic Information</span> <span class="borderHeader"></span> </div>--%>
                <!-- #HeadingInside -->

                <div class="basicSearchArea">
                    <div class="BasicLeft">
                        <div class="FieldWrapper">
                            <div class="Lable">Domain</div>
                            <!-- #Lable -->
                            <div class="InputField jqtranformdone">
                                <asp:DropDownList ID="ddlDomain" runat="server" class="inputClass jqtranformdone">
                                </asp:DropDownList>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <!-- #FieldWrapper -->


                        <!-- #FieldWrapper -->

                        <div class="clearfix"></div>

                        <!-- #FieldWrapper -->

                    </div>
                    <!-- #BasicLeft -->

                    <div class="SectionDiv"></div>
                    <div class="BasicRight">
                        <div class="clearfix"></div>
                        <div class="FieldWrapper">
                            <div class="Lable">User ID </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtUserID" runat="server" MaxLength="7" class="inputClass" onkeydown="return isNumberKey(event);"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        <div class="clearfix"></div>

                        <!-- #FieldWrapper -->


                        <!-- #FieldWrapper -->


                        <!-- #FieldWrapper -->

                    </div>
                    <!-- #BasicRight -->

                    <div class="SectionDiv second"></div>
                    <div class="BasicRight last">
                        <div class="FieldWrapper">
                            <div class="Lable">Name </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtUserName" MaxLength="100" runat="server" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                        </div>
                    </div>
                        <div class="clearfix"></div>

                    
                    </div>
                    <div class="clearfix"></div>
                
                    <div class="BorderDiv"></div>

                    <div class="ButtonsSave">
                        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                            ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
                    </div>
                </div>
    </form>

    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <table width="80%" border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <asp:Repeater ID="rptUserReferral" runat="server">
                <HeaderTemplate>
                    <tr style="font-weight: bolder; font-size: 13px; height: 30px; background-color: #ebebeb;">
                        <td align="center" style="width: 3%">S. No.
                        </td>
                        <td align="center" style="width: 8%">User ID
                        </td>
                        <td align="center" style="width: 15%">Name
                        </td>
                        <td align="center" style="width: 15%">Email
                        </td>
                        <td align="center" style="width: 15%">Department
                        </td>
                        <td align="center" style="width: 40%">Referral URL
                        </td>

                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="font-size: 12px; height: 30px;">
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td align="center">
                            <%# Eval("UserID")%>
                        </td>

                        <td align="center" valign="top" width="15%">
                            <%# Eval("Name")%>
                        </td>


                        <td align="center">
                            <%# Eval("Email")%>
                        </td>

                        <td align="center">
                            <%# Eval("Department")%>
                        </td>

                        <td align="center">
                            <%# Eval("ReferralURL")%>
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
    <script type="text/javascript" src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></scrip>
    <script type="text/javascript">
        function isNumberKey(event) {

            var charCode = (event.which) ? event.which : event.keyCode
            var isnumeric = false;

            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 110)
                isnumeric = true;
            if (charCode == 9)
                isnumeric = true;
            if (charCode == 190)
                isnumeric = true;
            if (charCode >= 37 && charCode <= 40)
                isnumeric = true;
            if (charCode >= 96 && charCode <= 105)
                isnumeric = true;

            return isnumeric;

        }
    </script>

</asp:Content>
