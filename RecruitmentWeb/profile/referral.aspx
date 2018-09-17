<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.master" AutoEventWireup="true"
    CodeFile="referral.aspx.cs" Inherits="profile_referral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="tab-pane" id="Xstep8">
        <form class="xStyledForm jqtransformdone">
        <div class="xboxRight">
            <img src="/Area/assets/img/banners/aboutaxact.jpg" alt="">
            <div class="xBoxInner">
                <h6>
                    <strong>Please tell us, where did you hear about Bol</strong></h6>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="xBoxInner" style="padding-top: 0;">
                            <div class="row-fluid">
                                <div class="span4">
                                    Select a Medium</div>
                                <div class="span7">
                                    <asp:RadioButtonList ID="rblMedium" runat="server" onclick="javascript:return rblMedium_OnClick();"
                                        RepeatDirection="Vertical" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div id="xAxactian" runat="server" class="hidden">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <h4>
                                            <span>Enter Reference Details</span> <span class="xCustomTip" data-placement="top"
                                                data-toggle="tooltip" data-original-title="Full name and department of the person you know at BOL.">
                                                (?)</span></h4>
                                        <div class="xBoxInner">
                                            <div class="row-fluid">
                                                <div class="span4">
                                                    Bolwalas Name</div>
                                                <div class="span7">
                                                    <asp:TextBox ID="txtAxactianName" runat="server" MaxLength="100"  CssClass="jqtranformdone"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span4">
                                                    Department</div>
                                                <div class="span7">
                                                    <asp:TextBox ID="txtDepartment" runat="server" MaxLength="100"  CssClass="jqtranformdone"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="xRefDetails" runat="server" class="hidden">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <h4>
                                            <span>Enter Reference Details</span></h4>
                                        <div class="xBoxInner">
                                            <div class="row-fluid">
                                                <div class="span4">
                                                    Reference Code <span class="xCustomTip" data-placement="top" data-toggle="tooltip"
                                                        data-original-title="The reference code of the person who has referred you at Bol.">
                                                        (?)</span></div>
                                                <div class="span7">
                                                    <asp:TextBox ID="txtReferenceCode" onkeydown="return isNumberKey(this);" runat="server"
                                                        MaxLength="9" CssClass="jqtranformdone"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="xOtherRef" runat="server" class="hidden">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <h4>
                                            <span>Enter Other Medium Details</span></h4>
                                        <div class="xBoxInner">
                                            <div class="row-fluid">
                                                <div class="span4">
                                                    Other Medium</div>
                                                <div class="span7">
                                                    <asp:TextBox ID="txtOtherMedium" runat="server" CssClass="jqtranformdone" MaxLength="100" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="xboxFooter">
                <div class="row-fluid">
                    <div class="span8">
                        <span class="red errormsg" style="line-height: 26px;"></span>
                    </div>
                </div>
            </div>
        </div>
        <div class="xboxRight">
            <div class="xBoxInner">
                <div class="row-fluid">
                    <div class="span12">
                        <%--<asp:HiddenField ID="hdnMediumCode" runat="server" Value="0" />--%>
                        <asp:Button ID="btnSave" runat="server" Text="Save &amp; Continue" OnClientClick="return validateForm();"
                            OnClick="btnProceed_Click" CssClass="xBook-button-normal button pull-right" />
                        <a href="../profile/personaldetails.aspx"  onclick="return confirm('Are you sure you want to go back?');" class="xBook-button-back fa13 pull-right"
                            style="text-decoration: none; color: rgb(242, 246, 248);">Back</a>
                    </div>
                </div>
            </div>
        </div>
        </form>
    </div>
    <script type="text/javascript">

        function rblMedium_OnClick() {

            if ($('#<%=rblMedium.ClientID %> input:checked').val() == '1') {
                ResetValues();
                $('#<%=xAxactian.ClientID%>').addClass('hidden');
                $('#<%=xRefDetails.ClientID%>').addClass('hidden');
                $('#<%=xOtherRef.ClientID%>').addClass('hidden');
            }
            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '2') {
                ResetValues();
                $('#<%=xAxactian.ClientID%>').addClass('hidden');
                $('#<%=xRefDetails.ClientID%>').addClass('hidden');
                $('#<%=xOtherRef.ClientID%>').addClass('hidden');
            }

            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '3') {
                ResetValues();
                $('#<%=xAxactian.ClientID%>').addClass('hidden');
                $('#<%=xRefDetails.ClientID%>').addClass('hidden');
                $('#<%=xOtherRef.ClientID%>').addClass('hidden');
            }

            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '4') {
                ResetValues();
                $('#<%=xAxactian.ClientID%>').removeClass('hidden');
                $('#<%=xRefDetails.ClientID%>').addClass('hidden');
                $('#<%=xOtherRef.ClientID%>').addClass('hidden');
            }

            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '5') {
                ResetValues();
                $('#<%=xAxactian.ClientID%>').addClass('hidden');
                $('#<%=xRefDetails.ClientID%>').removeClass('hidden');
                $('#<%=xOtherRef.ClientID%>').addClass('hidden');
            }


            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '6') {
                ResetValues();
                $('#<%=xAxactian.ClientID%>').addClass('hidden');
                $('#<%=xRefDetails.ClientID%>').addClass('hidden');
                $('#<%=xOtherRef.ClientID%>').removeClass('hidden');
            }

        }


        function ResetValues() {
            $(".errormsg").text("");
            $('#<%=txtAxactianName.ClientID%>').removeClass('error');
            $('#<%=txtDepartment.ClientID%>').removeClass('error');
            $('#<%=txtReferenceCode.ClientID%>').removeClass('error');
            $('#<%=txtOtherMedium.ClientID%>').removeClass('error');
        }

        function validateForm() {
            var isError = false;
            var code = 0;

            if ($('#<%=rblMedium.ClientID %> input:checked').val() == '') {
                isError = true;
            }
            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '4') {
                if ($('#<%=txtAxactianName.ClientID%>').val().trim() == "") {
                    $('#<%=txtAxactianName.ClientID%>').addClass('error');
                    isError = true;
                } else {
                    $('#<%=txtAxactianName.ClientID%>').removeClass('error');
                }

                if ($('#<%=txtDepartment.ClientID%>').val().trim() == "") {
                    $('#<%=txtDepartment.ClientID%>').addClass('error');
                    isError = true;
                } else {
                    $('#<%=txtDepartment.ClientID%>').removeClass('error');
                }
            }
            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '5') {
                if ($('#<%=txtReferenceCode.ClientID%>').val().trim() == "") {
                    $('#<%=txtReferenceCode.ClientID%>').addClass('error');
                    isError = true;
                } else {
                    var phoneRegex = new RegExp("^[0-99]*$");
                    if (phoneRegex.test($('#<%=txtReferenceCode.ClientID%>').val())) {
                        $('#<%=txtReferenceCode.ClientID%>').removeClass('error');
                    }
                    else {
                        $('#<%=txtReferenceCode.ClientID%>').addClass('error');
                        isError = true;
                    }
                }
            }
            else if ($('#<%=rblMedium.ClientID %> input:checked').val() == '6') {
                if ($('#<%=txtOtherMedium.ClientID%>').val().trim() == "") {
                    $('#<%=txtOtherMedium.ClientID%>').addClass('error');
                    isError = true;
                } else {
                    $('#<%=txtOtherMedium.ClientID%>').removeClass('error');
                }
            }


            if (isError) {
                $(".errormsg").text("Please provide complete information");
                return false;
            }
            else {
                $(".errormsg").text("");
                return true;
            }
        }



        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var isnumeric = false;
            if (charCode >= 48 && charCode <= 57)
                isnumeric = true;
            if (charCode == 46)
                isnumeric = true;
            if (charCode == 8)
                isnumeric = true;
            if (charCode == 110)
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

