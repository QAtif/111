<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="NadraVerification.aspx.cs" Inherits="NadraVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <style type="text/css">
        #showthebloodydiv:hover .show
        {
            display: block !important;
        }
        #showthebloodydiv1:hover .show
        {
            display: block !important;
        }
        #showthebloodydiv12:hover .show
        {
            display: block !important;
        }
        .ButtonsSave11
        {
            cursor: pointer;
            background: linear-gradient(to bottom, #4B8EFC 0%, #4787EE 100%) !important;
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4b8efc', endColorstr='#4787ee', GradientType=0 ) !important;
            border: 1px solid #3079ED !important;
            color: #FFF;
            padding: 4px 27px;
        }
        
        .error
        {
            /* background: #FFD9D9 !important; */
            border: 1px solid #C00 !important;
        }
    </style>
    <%-- <script>
        function callme(obj) {
            alert('a');
            $('#' + obj).click();
        }
    </script>--%>
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function onpress() {
            $('#id_search_list').quicksearch('#Candidate > tbody .ShowHide');

        }
      
       

    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="script" runat="server">
    </asp:ScriptManager>
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>
            Nadra Verification Report</h2>
    </div>
    <div style="background-color: White; padding: 15px 0px 15px 15px; margin: 5px 0px 5px 0px;">
        <h3>
            Search</h3>
        <table cellpadding="3px" style="border-collapse: separate !important; border-spacing: 3px">
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                <td>
                    Reference No.
                </td>
                <td>
                    <asp:TextBox ID="txtref" runat="server" Style="width: 180px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Date From
                </td>
                <td>
                    <input runat="server" type="text" id="postedFromDate" clientidmode="Static" class="inputClass"
                        readonly="true" style="width: 180px" />
                </td>
                <td>
                    Date To
                </td>
                <td>
                    <input runat="server" type="text" id="postedToDate" clientidmode="Static" class="inputClass"
                        style="width: 180px" readonly="true" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-top: 17px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="SubmteForm" OnClick="btnSearch_Click"
                        CssClass="ButtonsSave11" />
                    <%-- <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold"></asp:LinkButton>--%>
                </td>
            </tr>
        </table>
    </div>
    <div class="box-ScheduledActivities" style="background-color: White; padding: 5px 0px 5px 15px;
        margin: 5px 0px 5px 0px">
        Filter: &nbsp;
        <input type="text" name="" value="" id="id_search_list" placeholder="Candidate Name"
            onkeyup="javascript:onpress();" />
        <table id="Candidate">
            <asp:Repeater ID="rptCanddiate" runat="server" OnItemDataBound="rptCanddiate_OnDataBound"
                OnItemCommand="rptCanddiate_OnItemCammand">
                <HeaderTemplate>
                    <tr style="font-weight: bold" align="center">
                        <td style="width: 3%">
                            S. No.
                        </td>
                        <td style="width: 5%">
                            Ref #
                        </td>
                        <td style="width: 15%">
                            Name
                        </td>
                        <td style="width: 7%">
                            CNIC #
                        </td>
                        <td style="width: 10%">
                            DOB
                        </td>
                        <td style="width: 10%">
                            Address
                        </td>
                        <td style="width: 7%">
                            Nadra Nic
                        </td>
                        <td style="width: 7%">
                            Nic
                        </td>
                        <td style="width: 10%">
                            Updated By
                        </td>
                        <td style="width: 11%" align="center">
                            APM Comments
                        </td>
                        <td style="width: 15%" align="center">
                            Status
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center" class="ShowHide">
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td>
                            <%# Eval("Candidate_ID")%>
                        </td>
                        <td>
                            <%# Eval("full_name")%>
                            <br />
                            <br />
                            <b>Status: </b>
                            <%# Eval("CanStatus")%>
                        </td>
                        <td>
                            <%# Eval("NIC")%>
                            <asp:HiddenField ID="HdnCandidateCode" runat="server" Value='<%# Eval("Candidate_Code") %>' />
                        </td>
                        <td>
                            <%# Eval("DateOf_Birth")%>
                        </td>
                        <td>
                            <%# Eval("address")%>
                        </td>
                        <td>
                            <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                <a id="aViewBigImage" href='<%# Eval("CandDoc_Code","#frame-sets{0}") %>' title=""
                                    class="poptheform">
                                    <img src='<%# Eval("NadraNicPath") %>' alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "NadraBrowsed") + ";" %>' />
                                </a><a id="abrowseFile" runat="server">
                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "NadraNorBrowsed") + ";" %>' /></a>
                                <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                <br />
                                <asp:LinkButton ID="lnkUploadPic" CommandArgument='<%# Eval("CandDoc_Code") %>' CommandName="UploadNic"
                                    runat="server" Text="Save" Style="display: none" />
                                <a id="AimgEdit" runat="server" class="show" style="z-index: 999; display: none;
                                    position: absolute; cursor: pointer; top: 0px; left: 71px;" width="20px" height="20px">
                                    <img id="img3" alt="" src="/A2/assets/images/edit.png"></img></a>
                            </div>
                            <div id='<%# Eval("CandDoc_Code","frame-sets{0}") %>' style="display: none;">
                                <div>
                                    <img id="imgBigImage" runat="server" alt="" src='<%# Eval("NadraNicPath") %>' style="max-height:800px; max-width:1000px" /></div>
                            </div>
                        </td>
                        <td>
                            <div id="showthebloodydiv2" style="position: relative; padding: 4px 4px 4px 4px;">
                                <asp:HiddenField ID="hdnCanDocCode" Value='<%# Eval("CandDoc_Code") %>' runat="server" />
                                <asp:HiddenField ID="hdnCanCode1" Value='<%# Eval("Candidate_Code") %>' runat="server" />
                                <a id="aviewNic" href='<%# Eval("CandDoc_Code","#frame-sets1{0}") %>' title="" class="poptheform">
                                    <img src='<%# Eval("DocumentPath") %>' alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                </a><a id="aBrowseNic" runat="server">
                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsnotBrowsed") + ";" %>' /></a>
                                <asp:FileUpload ID="funic" runat="server" Style="display: none;" />
                                <br />
                                <asp:LinkButton ID="lnkSaveImg" CommandArgument='<%# Eval("CandDoc_Code") %>' CommandName="Nic"
                                    runat="server" Text="Save" Style="display: none" />
                                <a id="aEditbrowse" runat="server" class="show" style="z-index: 999; display: none;
                                    position: absolute; cursor: pointer; top: 0px; left: 71px;" width="20px" height="20px">
                                    <img id="img1" alt="" src="/A2/assets/images/edit.png"></img></a>
                            </div>
                            <div id='<%# Eval("CandDoc_Code","frame-sets1{0}") %>' style="display: none;">
                                <div>
                                    <img id="imgBigImage3" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height:800px; max-width:1000px" /></div>
                            </div>
                        </td>
                        <td>
                            <%# Eval("NadraUpdatedBy")%>
                        </td>
                        <td>
                            <asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Width="118px" Height="50px"
                                MaxLength="500" Text='<%# Eval("APM_Comments") %>'></asp:TextBox><br />
                            <span id="divAction124" runat="server" clientidmode="Static" visible="false">
                            <a id="aSaveComment" runat="server" style="cursor: pointer">
                                <img src="../assets/images/saveicon.png" alt="" width="30" height="30" /></a>
                            <img id="imgDone" runat="server" src="/A2/assets/images/check.png" width="10" height="10"
                                style="display: none" />
                                </span>
                        </td>
                        <td align="left">
                            <asp:Repeater ID="rptNadraStatus" runat="server" OnItemDataBound="rptNadraStatus_OnDataBound">
                                <ItemTemplate>
                                    <asp:Image ID="Image5" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                    <span id="divAction125" runat="server" clientidmode="Static" visible="false">
                                    <a id="aMarkStaus" runat="server" title="Mark Status" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "isnotExist") + ";" %>'>
                                        <img src="/A2/assets/images/unchecked.png" width="15" height="15" /></a> <a id="aUnMarkStaus"
                                            runat="server" title="Unmark Status" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "isExist") + ";" %>'>
                                            <img src="/A2/assets/images/check.png" width="15" height="15" /></a> &nbsp;
                                    &nbsp;</span>
                                    <%# Eval("NadraStatus_Name")%>
                                    &nbsp;
                                    <img src="/A2/assets/images/Done.png" width="15" height="15" style='<%# "display:" + DataBinder.Eval(Container.DataItem, "isExist") + ";" %>'
                                        alt="" />
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />
                            <a id="aShow" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "Isfamily") + ";" %>'
                                onclick='javascript:if ($("#" + <%# Eval("Candidate_Code") %>).css("display") == "none") $("#" + <%# Eval("Candidate_Code") %>).show(); else $("#" + <%# Eval("Candidate_Code") %>).hide();'>
                                Family Detail</a>
                            <%--<a id="ahide" onclick='$("#" + <%# Eval("Candidate_Code") %> ).show(); '> Show</a>--%>
                        </td>
                    </tr>
                    <tr style="background-color: #E5E5E5; display: none" id='<%# Eval("Candidate_Code") %>'>
                        <td colspan="11">
                            <table>
                                <asp:Repeater ID="rptFamily" runat="server" OnItemDataBound="rptFamily_OnitemDataBind"
                                    OnItemCommand="rptFamily_OnItemCammand">
                                    <HeaderTemplate>
                                        <tr style="font-weight: bold" align="center">
                                            <td style="width: 3%">
                                                S. No.
                                            </td>
                                            <td style="width: 15%">
                                                Name
                                            </td>
                                            <td style="width: 7%">
                                                Relation
                                            </td>
                                            <td style="width: 7%">
                                                DOB
                                            </td>
                                            <td style="width: 10%">
                                                UpdatedBy
                                            </td>
                                            <td style="width: 10%">
                                                Nadra NIC
                                                <td style="width: 10%">
                                                    NIC
                                                </td>
                                            </td>
                                            <td style="width: 5%">
                                                Age
                                            </td>
                                            <td style="width: 15%">
                                                APM Comments
                                            </td>
                                            <td style="width: 18%" align="center">
                                                Status
                                            </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr align="center">
                                            <td>
                                                <%#Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <%# Eval("Name") %>
                                            </td>
                                            <td>
                                                <%# Eval("Relation") %>
                                            </td>
                                            <td>
                                                <%# Eval("dateofbirth") %>
                                                <td>
                                                    <%# Eval("NadraUpdatedBy")%>
                                                </td>
                                            </td>
                                            <td>
                                                <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 4px 4px;">
                                                    <a id="aViewBigImage" href='<%# Eval("CandDoc_Code","#frame-sets{0}") %>' title=""
                                                        class="poptheform">
                                                        <img src='<%# Eval("NadraNicPath") %>' alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "NadraBrowsed") + ";" %>' />
                                                    </a><a id="abrowseFile" runat="server">
                                                        <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "NadraNorBrowsed") + ";" %>' /></a>
                                                    <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                                    <br />
                                                    <asp:LinkButton ID="lnkUploadPic" CommandArgument='<%# Eval("CandDoc_Code") %>' CommandName="UploadNic"
                                                        runat="server" Text="Save" Style="display: none" />
                                                    <a id="AimgEdit" runat="server" class="show" style="z-index: 999; display: none;
                                                        position: absolute; cursor: pointer; top: 0px; left: 71px;" width="20px" height="20px">
                                                        <img id="img3" alt="" src="/A2/assets/images/edit.png"></img></a>
                                                </div>
                                                <div id='<%# Eval("CandDoc_Code","frame-sets{0}") %>' style="display: none;">
                                                    <div>
                                                        <img id="imgBigImage" runat="server" alt="" src='<%# Eval("NadraNicPath") %>' style="max-height:800px; max-width:1000px"/></div>
                                                </div>
                                            </td>
                                            <td>
                                                <div id="showthebloodydiv12" style="position: relative; padding: 4px 4px 4px 4px;">
                                                    <asp:HiddenField ID="hdnMemberCode" Value='<%# Eval("CandidateFamilyMember_Code") %>'
                                                        runat="server" />
                                                    <asp:HiddenField ID="hdnCanCode" Value='<%# Eval("Candidate_Code") %>' runat="server" />
                                                    <a id="aviewNic" href='<%# Eval("CandidateFamilyMember_Code","#frame-sets{0}") %>'
                                                        title="" class="poptheform">
                                                        <img src='<%# Eval("DocumentPath") %>' alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                                    </a><a id="aBrowseNic" runat="server">
                                                        <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsnotBrowsed") + ";" %>' /></a>
                                                    <asp:FileUpload ID="funic" runat="server" Style="display: none;" />
                                                    <br />
                                                    <asp:LinkButton ID="lnkSaveImg" CommandArgument='<%# Eval("CandDoc_Code") %>' CommandName="Nic"
                                                        runat="server" Text="Save" Style="display: none" />
                                                    <a id="aEditbrowse" runat="server" class="show" style="z-index: 999; display: none;
                                                        position: absolute; cursor: pointer; top: 0px; left: 71px;" width="20px" height="20px">
                                                        <img id="img1" alt="" src="/A2/assets/images/edit.png"></img></a>
                                                </div>
                                                <div id='<%# Eval("CandidateFamilyMember_Code","frame-sets{0}") %>' style="display: none;">
                                                    <div>
                                                        <img id="imgBigImage3" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height:800px; max-width:1000px"/></div>
                                                </div>
                                            </td>
                                            <td>
                                                <%# Eval("memberage") %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Width="118px" Height="50px"
                                                    MaxLength="500" Text='<%# Eval("APM_Comments") %>'></asp:TextBox><br />
                                                <span id="divAction124" runat="server" clientidmode="Static" visible="false">
                                                    <a id="aSaveComment" runat="server" style="cursor: pointer">
                                                        <img src="../assets/images/saveicon.png" alt="" width="30" height="30" alt="" /></a>
                                                    <img id="imgDone" runat="server" src="/A2/assets/images/check.png" width="10" height="10"
                                                        style="display: none" alt="" /></span>
                                            </td>
                                            </td>
                                            <td align="left">
                                                <asp:Repeater ID="rptNadraStatus" runat="server" OnItemDataBound="rptNadraStatus_OnDataBound">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="/assets/images/bullet.gif" />
                                                        <span id="divAction125" runat="server" clientidmode="Static" visible="false">
                                                            <a id="aMarkStaus" runat="server" title="Mark Status" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "isnotExist") + ";" %>'>
                                                                <img src="/A2/assets/images/unchecked.png" width="15" height="15" /></a> <a id="aUnMarkStaus"
                                                                    runat="server" title="Unmark Status" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "isExist") + ";" %>'>
                                                                    <img src="/A2/assets/images/check.png" width="15" height="15" /></a> &nbsp;
                                                        </span>
                                                        &nbsp;
                                                        <%# Eval("NadraStatus_Name")%>
                                                        &nbsp;
                                                        <img src="/A2/assets/images/Done.png" width="15" height="15" style='<%# "display:" + DataBinder.Eval(Container.DataItem, "isExist") + ";" %>'
                                                            alt="" />
                                                        <br />
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="11" align="center">
                    <asp:Label ID="lblError" runat="server" Text="No Records Found." ForeColor="Red"
                        Style="display: none"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">

        function InsertNadraVerificationComments(CanCode, ddlStatusID, BtnSave, imgDone, isActive) {

            var Param = CanCode + '|' + ddlStatusID + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>' + '|' + isActive
            //alert(Param);
            $.ajax({ type: "POST",
                url: "NadraVerification.aspx/InsertNadraVerificationComments",
                data: JSON.stringify({ items: Param }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $('#' + BtnSave).hide();
                    $('#' + imgDone).show();

                },
                error: function (msg) {
                    alert("error");
                }
            });

        }
        function Update_APMVerificationComment(CanCode, txtComents, ImgDone) {
            if ($('#' + txtComents).val() != '') {
                var Param = CanCode + '|' + $('#' + txtComents).val() + '|' + '<%=UpdatedBy %>' + '|' + '<%=UpdatedIP %>'
                //alert(Param);
                $.ajax({ type: "POST",
                    url: "NadraVerification.aspx/Update_APMVerificationComment",
                    data: JSON.stringify({ items: Param }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        $('#' + ImgDone).show();
                    },
                    error: function (msg) {
                        alert("error");
                    }
                });
            }

        }

        $(function () {
            $("#postedToDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"


            });
        });

        $(function () {
            $("#postedFromDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "M dd, yy"
            });
        });
    
    </script>
</asp:Content>

