<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="XRecruitmentAdmin.OfferLetterViewer.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
 <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~")%>A2/assets/css/style.css" />
	 <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/xlib.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/function.js" type="text/javascript"></script>
    <style type="text/css">
        .user-detail, .p-padding {
            width: 100% !important;
        }

        .bor {
            border-right: 1px solid #D9D9D9;
        }

        .bob {
            border-bottom: 1px solid #D9D9D9;
        }

        .bot {
            border-top: 1px solid #D9D9D9;
        }

        .bol {
            border-left: 1px solid #D9D9D9;
        }

        table th {
            font-size: 16px;
        }

        table td {
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="searcharea" class="searcharea">

        <div class="SearchBox adjustwidth" style="margin-top: 3% !important;">
            <div class="InsideSearchBox">
                <div class="HeadingInside">
                    <span class="BasicInfoIcon"></span><span class="IconTxt">Search</span>
                    <span class="borderHeader"></span>
                </div>
                <!-- #HeadingInside -->
                <div class="basicSearchArea">
                    <div class="BasicLeft">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Reference #
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtRefNo" runat="server" ClientIDMode="Static" name="txtRefNo" class="inputClass"></asp:TextBox>
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>

                    <div class="SectionDiv">
                    </div>
                    <div class="BasicRight">
                        <div class="FieldWrapper">
                            <div class="Lable">
                                Email
                            </div>
                            <!-- #Lable -->
                            <div class="InputField">
                                <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" name="txtEmail" class="inputClass"></asp:TextBox>
                                <!--<span class="CheckBox"></span><span class="Checktxt">Exactly match Email</span>-->
                            </div>
                            <!-- #InputField -->
                        </div>
                    </div>
                    <!-- #FieldWrapper -->


                    <!-- #BasicRight -->
                </div>
                <!-- #basicSearchArea -->
            </div>

            <div class="clearfix">
            </div>
            <div class="BorderDiv">
            </div>
            <div class="ButtonsSave" id="btnSearchF">
                <asp:Button ID="btnSearch" runat="server" class="SubmteForm" Text="Search" OnClick="btnSearch_Click" />
                <%--OnClick="BtnSearchFresh_Click"--%>
            </div>
        </div>
    </div>
    <div id="sortable" class="main-wrapper newscreen">
        <!-- Main Content Here -->
        <section class="main-content accordsec">
      <div class="main-accrodian">
        <ul id="UlMain">
    <div class="user-profile-main onlyinfoboxes">
        <div class="user-profile-main onlyinfoboxes">
            <div class="user-profile-warpper">
                <div class="user-detail">
                    <div class="p-padding">
                        <table style="width:98%">
                            <tr>
                                <th style="width:25%" class="bol bob bot">Reference #</th>
                                <th style="width:25%" class="bol bob bot">Name</th>
                                <th style="width:25%" class="bol bob bot">Email</th>
                                <th style="width:25%" class="bol bob bot bor">Phone</th>
                            </tr>
                            <tr  id="trRec" runat="server" visible="false">
                                <td style="width:25%" align="center" class="bol bob">
                                    <asp:Label runat="server" ID="lblRefNo"></asp:Label>
                                </td>
                                <td style="width:25%" align="center" class="bol bob">
                                    <label style="width:100%;text-align:center">
                                        <asp:HiddenField ID="hdfldCandidateID" runat="server"  />
                                        <asp:Label runat="server" ID="lblName"></asp:Label></label></td>
                                <td style="width:25%" align="center" class="bol bob"> <asp:Label runat="server" ID="lblEmailAddress"></asp:Label></td>
                                <td style="width:25%" align="center" class="bol bob bor"> <asp:Label runat="server" ID="lblPhoneNo"></asp:Label></td>
                            </tr>
                            <tr runat="server" id="trNoRec">
                                <td colspan="4" width="100%" align="center" class="bol bob bor"> No Record Found</td>
                            </tr>
                        </table>
                         <div class="BorderDiv">
            </div>
                        <br />
                        <br />
            <div class="ButtonsSave" style="width:98%">
                <asp:Label runat="server" ID="lblError" style="float: left;font-size: 15px;"></asp:Label>
                <asp:Button ID="btnUpdate" runat="server" style="float: right;" class="SubmteForm" Text="Reset Password" OnClick="btnResetPassword_Click" Visible="false"/>
                <%--OnClick="BtnSearchFresh_Click"--%>
            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            </ul>
          </div>
            </section>
    </div>


</asp:Content>
