<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfferLetter.aspx.cs" Inherits="XRecruitmentAdmin.OfferLetterViewer.OfferLetter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../assets/js/jquery-1.8.2.min.js"></script>
    <script src="/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>
    <style>
        .error {border-color:red;        }
        .SubmteForm {
            cursor: pointer;
            background: #4b8efc !important; /* Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
            background: url('data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzRiOGVmYyIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiM0Nzg3ZWUiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+') !important;
            background: -moz-linear-gradient(top, #4b8efc 0%, #4787ee 100%) !important; /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #4b8efc), color-stop(100%, #4787ee)) !important; /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #4b8efc 0%, #4787ee 100%) !important; /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #4b8efc 0%, #4787ee 100%) !important; /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #4b8efc 0%, #4787ee 100%) !important; /* IE10+ */
            background: linear-gradient(to bottom, #4b8efc 0%, #4787ee 100%) !important; /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important; /* IE6-8 */
            border: 1px solid #3079ed !important;
            color: #fff;
            padding: 4px 27px;
            float: right;
        }

        td {
            padding-bottom: 3%;
            padding-left: 2%;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table align="center" style="width: 100%">
                    <tr>

                        <td style="width: 75%">
                            <iframe id="iframLetterViewer" runat="server" height="800px" width="100%"></iframe>
                        </td>
                        <td style="width: 25%">
                            <table style="width: 100%;">
                                <asp:HiddenField runat="server" ID="hdnfldCondidateCode" />
                                <tr>

                                    <td colspan="2" style="width: 100%;">
                                        <asp:RadioButtonList runat="server" name="Status" ClientIDMode="Static" Style="width: 100%; margin-left:-15px" ID="rdbtnlstStatus" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbtnlstStatus_SelectedIndexChanged" AutoPostBack="false">
                                            <asp:ListItem Text="Accepted" Selected="True" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Need to discuss" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList></td>

                                </tr>                                
								<tr id="trReason" style="display:none">
                                    
                                    <td colspan="2">
									<asp:Label runat="server" ClientIDMode="Static" ID="lblComments" Text="Please Enter Reason:"></asp:Label></br>
                                        <asp:TextBox ID="txtComments" ClientIDMode="Static" runat="server" TextMode="MultiLine" MaxLength="1000" Style="resize: none; width:237px" Rows="5"></asp:TextBox></td>
                                </tr>

                                <tr>

                                    <td colspan="2" style="padding-right: 22% !important;">
                                        <asp:Button runat="server" ID="btnSaveStatus" OnClick="btnSaveStatus_Click" OnClientClick="return Validation()" Text="Submit" class="SubmteForm" /></td>
                                </tr>
                                <tr>

                                    <td colspan="2" style="padding-right: 22% !important;">
                                        <asp:Label ID="lblMessage" ClientIDMode="Static" runat="server"></asp:Label>
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
<script type="text/javascript">
    $('#rdbtnlstStatus').change(function () {

       
        if ($("input[type='radio']:checked").val() == 1) {
            $('#trReason').hide();
			 
           
        } else {
            $('#trReason').show();
			
           
        }
    });

    function Validation() {
        if ($("input[type='radio']:checked").val() == 2) {
            if ($('#txtComments').val() == '') {
                $('#txtComments').addClass('error');
                return false;
            } else {
                $('#txtComments').removeClass('error');
                return true;
            }
        }
        return true;

    }
</script>
