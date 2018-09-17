<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiscrepantReportPopUp.aspx.cs" Inherits="XRecruitmentAdmin.OfferLetterViewer.DiscrepantReportPopUp1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~")%>A2/assets/css/style.css" />
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/xlib.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~")%>A2/assets/js/function.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../assets/js/MultipleItemSelection/jQuery.Tokeninput.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="../assets/js/toastr.min.js"></script>
    <link rel="stylesheet" href="../assets/css/toastr.min.css" />
    <style type="text/css">
        .user-detail, .p-padding {
            width: 100% !important;
        }

        .bdr {
            border-right: 1px solid #D9D9D9;
        }

        .bdb {
            border-bottom: 1px solid #D9D9D9;
        }

        .bdt {
            border-top: 1px solid #D9D9D9;
        }

        .bdl {
            border-left: 1px solid #D9D9D9;
        }

        table th {
            font-size: 16px;
        }

        table td {
            font-size: 14px;
            
        }

        .Lable {
            width: 20% !important;
        }
        .hght {padding-left:1% !important;height:35px !important;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div id="sortable" class="main-wrapper newscreen">
        <!-- Main Content Here -->
        <section class="main-content accordsec">
      <div class="main-accrodian">
        <ul id="UlMain">
    <div class="user-profile-main onlyinfoboxes">
        <div class="user-profile-main onlyinfoboxes">
            <div class="user-profile-warpper" style="height: 765px;width: 79%;">
                <div class="user-detail">
                    <div class="p-padding">
                     <div>
            <table width="96%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" style="height: 91px">
                        <table class="border-gray" width="100%">
                            
                            <tr>
                                <td class="GridHeader" height="25" style="font-weight:bold;" align="center">Package Information
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" rowspan="1">
                                    <table align="center" border="0" cellpadding="3" cellspacing="0" style="width:98% !important;">

                                        <tr>
                                            <td valign="top" width="60%">
                                                <table id="Table2" align="center" border="0" cellpadding="5" cellspacing="1" class="bdt bdr bdb bdl"
                                                    width="100%">

                                                    <tr>
                                                        <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left">Employee:
                                                        </td>
                                                        <td align="left" valign="center" class="bdb fv11 hght">
                                                            <asp:Label ID="lblFullName" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb fv11 hght" valign="center" style="width: 157px; text-align: left">Salary:</td>
                                                        <td align="left" valign="top" class="bdb fv11">
                                                            <table class=" bdl" width="100%">
                                                                <tr>
                                                                    <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left">Salary:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                       <b>Rs </b><asp:Label ID="lblSalary" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="fv11 bdr hght" style="width: 157px; text-align: left;" valign="center">International Salary:
                                                                    </td>
                                                                    <td align="left" class="fv11 hght" valign="center" >
                                                                       <b>Rs </b><asp:Label ID="lblIntSalary" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    </tr>
                                                    <tr>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb fv11 hght" valign="center" style="width: 157px; text-align: left">Mobile Set:</td>
                                                        <td align="left" valign="top" class="fv11">
                                                            <table class=" bdl" width="100%">
                                                                <tr>
                                                                    <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left;">Office:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght" >
                                                                        <asp:Label ID="lblMobileSet" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left;">Home:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                        <asp:Label ID="lblMobileSetForHome" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb  fv11 hght" valign="center" style="width: 157px; text-align: left">Mobile Allowance:</td>
                                                        <td align="left" valign="top" class="fv11">
                                                            <table class=" bdl" width="100%">
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left;">Office:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                        <b>Rs </b><asp:Label ID="lblMobileAllowance" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left;">Home:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                       <b>Rs </b><asp:Label ID="lblMobileAllowanceForHome" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left">Water Allowance:
                                                        </td>
                                                        <td align="left" valign="center" class="bdb fv11 hght">
                                                            <asp:Label ID="lblWaterAllowance" runat="server" Font-Bold="True"></asp:Label> <b> bottles</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb  fv11 hght" valign="center" style="width: 157px; text-align: left">Fuel Allowance:</td>
                                                        <td align="left" valign="center" class="fv11">
                                                            <table class=" bdl" width="100%">
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left">Office:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb hght fv11">
                                                                        <asp:Label ID="lblFuelAllowanceOffice" runat="server" Font-Bold="True"></asp:Label><b> Liters</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left">Home:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                        <asp:Label ID="lblFuelAllowanceForHome" runat="server" Font-Bold="True"></asp:Label><b> Liters</b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb  fv11 hght" valign="center" style="width: 157px; text-align: left">Car:</td>
                                                        <td align="left" valign="center" class="bdb fv11">
                                                            <table class="bdl" width="100%">
                                                                <tr>
                                                                    <td class=" fv11 bdr hght" valign="center" style="width: 157px; text-align: left">Office:
                                                                    </td>
                                                                    <td align="left" valign="center" class=" fv11 hght">
                                                                        <asp:Label ID="lblCarOffice" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class=" fv11 bdt bdr hght" valign="center" style="width: 157px; text-align: left">Home:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdt fv11 hght">
                                                                        <asp:Label ID="lblCarHome" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>


                                                    <tr>
                                                        <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left">Servant:
                                                        </td>
                                                        <td align="left" valign="center" class="bdb fv11 hght">
                                                            <asp:Label ID="lblServantCount" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb  fv11 hght" valign="center" style="width: 157px; text-align: left">Life Insurance:</td>
                                                        <td align="left" valign="center" class="bdb fv11">
                                                            <table class="bdl" width="100%">
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left">Natural Death:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                        <b>Rs </b><asp:Label ID="lblNdeathAllowance" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class=" fv11 bdr hght" style="width: 157px; text-align: left" valign="center">Accidental Death:
                                                                    </td>
                                                                    <td align="left" class=" fv11 hght" valign="center">
                                                                        <b>Rs </b><asp:Label ID="lblAdeathAllowance" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bdb  fv11 hght" valign="center" style="width: 157px; text-align: left">Medical:</td>
                                                        <td align="left" valign="center" class="bdb fv11">
                                                            <table class="bdl" width="100%">
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left">Self, Spouse, Children:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb hght fv11">
                                                                        <b>Rs </b><asp:Label ID="lblMedicalSelf" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="bdb fv11 bdr hght" valign="center" style="width: 157px; text-align: left;">Parent:
                                                                    </td>
                                                                    <td align="left" valign="center" class="bdb fv11 hght">
                                                                        <b>Rs </b><asp:Label ID="lblMedicalParent" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="bdr hght" style="width: 157px; text-align: left" valign="center">Meternity:
                                                                    </td>
                                                                    <td align="left" valign="center" class="fv11 hght">
                                                                        <asp:Label ID="lblMeternity" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left">Paid Vacations:
                                                        </td>
                                                        <td align="left" valign="center" class="bdb fv11 hght">
                                                            <asp:Label ID="lblPaidVacation" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td class="bdb bdr fv11 hght" valign="center" style="width: 157px; text-align: left">League:
                                                        </td>
                                                        <td align="left" valign="center" class="bdb fv11 hght">
                                                            <asp:Label ID="lblLeague" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
                         <div class="BorderDiv">
            </div>
                        <br />
                        <br />
            
                    </div>
                </div>
        
            </div>
        </div>
    </div>
            </ul>
          </div>
            </section>
    </div>
    </form>
</body>
</html>
