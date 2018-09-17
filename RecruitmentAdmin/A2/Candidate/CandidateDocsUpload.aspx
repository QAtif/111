<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="CandidateDocsUpload.aspx.cs" Inherits="A2_Candidate_CandidateDocsUpload" %>

<%@ Register Src="~/A2/Control/CandidateInfo.ascx" TagName="CandDetail" TagPrefix="Can" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <style type="text/css">
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
        .Picsize
        {
            background: url(images/bg.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }
        .innContainer .innBox table tr td img
        {
            float: left;
            margin: 0px 9px 0 0 !important;
        }
        .innContainer .innBox table tr td td
        {
            padding: 0px 0 0 0 !important;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Validate() {
            if ($('#ctl00_BodyContent_txtRefNo').val() != '') {
                $('#ctl00_BodyContent_txtRefNo').removeClass('error');
                return true;

            }
            else {
                $('#ctl00_BodyContent_txtRefNo').addClass('error');
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="script" runat="server">
    </asp:ScriptManager>
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;
        width: 70%; margin-left: auto; margin-right: auto">
        <b>Document Upload Screen</b>
        <div style="width: 50%; float: right; top: 92px; right: 35px; position: absolute;">
            <asp:TextBox ID="txtRefNo" runat="server" placeholder="Enter Reference #" Style="position: absolute;
                right: 222px; top: 11px; height: 17px; width: 200px;">
            </asp:TextBox>
            <asp:LinkButton ID="btnSearchByRef" runat="server" OnClick="Btn_SearchByRefno" ValidationGroup="RefNoFilter"
                Style="position: absolute; right: 174px; top: 6px;" OnClientClick="Javascript:return Validate();"> <img src="../assets/images/SearchBtn.jpg" height="30" width="40" /> </asp:LinkButton>
        </div>
    </div>
    <div class="box-ScheduledActivities" style="background-color: White; margin: 5px 0px 5px 0px;
        padding: 5px 0px 5px 15px; width: 70%; margin-left: auto; margin-right: auto;"
        id="divCandetail" runat="server">
        <Can:CandDetail ID="Candetail" runat="server"></Can:CandDetail>
    </div>
    <div style="background-color: White; margin: 5px 0px 5px 0px; padding: 5px 0px 20px 15px;
        width: 70%; margin-left: auto; margin-right: auto;" id="divCanDocdetail" runat="server">
        <div class="box-documents box">
            <ul class="innController">
                <li><a href="javascript:;" title="" data-rel="persona" class="active">Personal</a></li>
                <li><a href="javascript:;" title="" data-rel="Exp">Experience</a></li>
                <li><a href="javascript:;" title="" data-rel="Edu">Education</a></li>
                <li><a href="javascript:;" title="" data-rel="Dip">Diploma</a></li>
                <li><a href="javascript:;" title="" data-rel="Certi">Certification</a></li>
                <li><a href="javascript:;" title="" data-rel="Hired">Hired Documents</a></li>
                <li><a href="javascript:;" title="" data-rel="Official">Official</a></li>
                <li><a href="javascript:;" title="" data-rel="AxPer">Axactian Personal</a></li>
                <li><a href="javascript:;" title="" data-rel="AxExp">Axactian Experience</a></li>
                <li><a href="javascript:;" title="" data-rel="AxEdu">Axactian Education</a></li>
                <li><a href="javascript:;" title="" data-rel="AxFam">Axactian Family</a></li>
                <li><a href="javascript:;" title="" data-rel="AxSep">Axactian Separation Documents</a></li>
                <li><a href="javascript:;" title="" data-rel="AxMisc">Axactian Misc. Documents</a></li>
            </ul>
            <div class="innContainer" style="margin-top: 80px;">
                <div class="innBox box-persona active">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptDocPersonal" runat="server" OnItemDataBound="rptPer_OnDataBound" OnItemCommand="rptAxPer_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblDocPersonal" runat="server" Text="No personal documents found."></asp:Label>
                </div>
                <div class="innBox box-Exp">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptDocsExperience" runat="server" OnItemDataBound="rptExp_OnDataBound" OnItemCommand="rptExp_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="SpDocNameHeading" runat="server">
                                    <td colspan="4">
                                        <strong><span id="sp" runat="server">
                                            <%# Eval("CandidateDocumentName") %></span></strong>
                                    </td>
                                </tr>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy")%>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="hdnDocName" runat="server" Value='<%# Eval("CandidateDocumentName") %>' />
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%-- <a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a>--%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img3" alt="" src="/A2/assets/images/edit.png" title="Browse File"></img></a><a
                                                        id="aDownload" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                        href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                        target="_blank"><img src="../assets/images/Download-file.png" width="18px" height="18px"
                                                            title="Download File" /></a>
                                                              <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <%-- <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblDocProfessional" runat="server" Text="No professional documents found."></asp:Label>
                </div>
                <div class="innBox box-Edu">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptDocsEducation" runat="server" OnItemDataBound="rptEdu_OnDataBound" OnItemCommand="rptEdu_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="SpDocNameHeading" runat="server">
                                    <td colspan="4">
                                        <strong><span id="sp" runat="server">
                                            <%# Eval("CandidateDocumentName") %></span></strong>
                                    </td>
                                </tr>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy")%>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="hdnDocName" runat="server" Value='<%# Eval("CandidateDocumentName") %>' />
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%-- <a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a>--%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img3" alt="" src="/A2/assets/images/edit.png" title="Browse File"></img></a><a
                                                        id="aDownload" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                        href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                        target="_blank"><img src="../assets/images/Download-file.png" width="18px" height="18px"
                                                            title="Download File" /></a>
                                                              <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <%-- <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lbldocEducation" runat="server" Text="No educational documents found."></asp:Label>
                </div>
                <div class="innBox box-Dip">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptDocDiploma" runat="server" OnItemDataBound="rptDiploma_OnDataBound"
                            OnItemCommand="rptDiploma_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="SpDocNameHeading" runat="server">
                                    <td colspan="4">
                                        <strong><span id="sp" runat="server">
                                            <%# Eval("CandidateDocumentName") %></span></strong>
                                    </td>
                                </tr>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy")%>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="hdnDocName" runat="server" Value='<%# Eval("CandidateDocumentName") %>' />
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%-- <a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a>--%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img3" alt="" src="/A2/assets/images/edit.png" title="Browse File"></img></a><a
                                                        id="aDownload" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                        href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                        target="_blank"><img src="../assets/images/Download-file.png" width="18px" height="18px"
                                                            title="Download File" /></a>
                                                              <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <%-- <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblDocDiploma" runat="server" Text="No diploma documents found."></asp:Label>
                </div>
                <div class="innBox box-Certi">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptDocCertificate" runat="server" OnItemDataBound="rptCertificate_OnDataBound"
                            OnItemCommand="rptCertificate_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="SpDocNameHeading" runat="server">
                                    <td colspan="4">
                                        <strong><span id="sp" runat="server">
                                            <%# Eval("CandidateDocumentName") %></span></strong>
                                    </td>
                                </tr>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy")%>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="hdnDocName" runat="server" Value='<%# Eval("CandidateDocumentName") %>' />
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%-- <a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a>--%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img3" alt="" src="/A2/assets/images/edit.png" title="Browse File"></img></a><a
                                                        id="aDownload" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                        href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                        target="_blank"><img src="../assets/images/Download-file.png" width="18px" height="18px"
                                                            title="Download File" /></a>
                                                              <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <%-- <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lbldocCertificate" runat="server" Text="No certificate documents found."></asp:Label>
                </div>
                <div class="innBox box-Hired">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptHiredDocs" runat="server" OnItemDataBound="rptHired_OnDataBound"
                            OnItemCommand="rptHired_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblHiredDoc" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-Official">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptOfficial" runat="server" OnItemDataBound="rptOfficial_OnDataBound"
                            OnItemCommand="rptOfficial_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblOfficial" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-AxPer">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptAxPer" runat="server" OnItemDataBound="rptAxPer_OnDataBound"
                            OnItemCommand="rptAxPer_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblrptAxPer" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-AxExp">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptAxExp" runat="server" OnItemDataBound="rptAxExp_OnDataBound"
                            OnItemCommand="rptAxExp_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblAxExp" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-AxEdu">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptAxEdu" runat="server" OnItemDataBound="rptAxEdu_OnDataBound"
                            OnItemCommand="rptAxEdu_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblAxEdu" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-AxFam">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptAxFam" runat="server" OnItemDataBound="rptAxFam_OnDataBound"
                            OnItemCommand="rptAxFam_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="SpDocNameHeading" runat="server">
                                    <td colspan="4">
                                        <strong><span id="sp" runat="server">
                                            <%# Eval("CandidateDocumentName") %></span></strong>
                                    </td>
                                </tr>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy")%>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="hdnDocName" runat="server" Value='<%# Eval("CandidateDocumentName") %>' />
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%-- <a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a>--%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img3" alt="" src="/A2/assets/images/edit.png" title="Browse File"></img></a><a
                                                        id="aDownload" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                        href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                        target="_blank"><img src="../assets/images/Download-file.png" width="18px" height="18px"
                                                            title="Download File" /></a>
                                                              <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <%-- <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblAxFam" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-AxSep">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptAxSep" runat="server" OnItemDataBound="rptAxSep_OnDataBound"
                            OnItemCommand="rptAxSep_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblAxSep" runat="server" Text="No documents found."></asp:Label>
                </div>
                <div class="innBox box-AxMisc">
                    <table style="width: 100%">
                        <asp:Repeater ID="rptAxMisc" runat="server" OnItemDataBound="rptAxMisc_OnDataBound"
                            OnItemCommand="rptAxMisc_OnItemCammand">
                            <HeaderTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <b>Document Name</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated By</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <b>Updated Date</b>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;" align="center">
                                        <b>Action</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background: #fff; min-height: 118px; border: 1px solid #c1c5d5;">
                                    <td style="width: 40%; padding-left: 10px;">
                                        <%# Eval("Document_Name") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdatedBy") %>
                                    </td>
                                    <td style="width: 20%; padding-left: 10px;">
                                        <%# Eval("UpdationDate")%>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:HiddenField ID="CandidateDocumentName" runat="server" Value='<%# Eval("Document_Name") %>' />
                                        <asp:HiddenField ID="hdnDocumentCode" runat="server" Value='<%# Eval("Document_Code") %>' />
                                        <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# Eval("CandDoc_Code") %>' />
                                        <div id="showthebloodydiv" style="position: relative; padding: 4px 4px 24px 4px;
                                            float: right;">
                                            <%--<a id="aViewBigImage" href='javascript:;' title="" class="poptheform">
                                                <img src='<%# Eval("DocumentPath") %>?<%# DateTime.Now.Ticks.ToString() %>' alt=""
                                                    width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>' />
                                            </a> --%>
                                            <%-- <a id="abrowseFile" runat="server">
                                                    <img src="../assets/images/noImageb.png" alt="" width="40" height="40" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsNotBrowsed") + ";" %>' /></a>--%>
                                            <asp:FileUpload ID="Fu" runat="server" Style="display: none;" />
                                            <img src="../assets/images/accept.png" alt="" width="30" height="20" style="position: absolute;
                                                right: -48px; top: 10px; display: none;" id="imgcheck" runat="server" />
                                            <div style="width: 100px; position: absolute; right: 4px; top: 4px;">
                                                <a id="AimgEdit" runat="server" width="18px" height="18px">
                                                    <img id="img2" alt="" src="/A2/assets/images/edit.png" title="Browse File" alt=""></img></a>
                                                <a id="a4" style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    href='<%# Eval("DocumentPath1") %>' runat="server" tooltip='<%# Eval("DocumentPath1") %>'
                                                    target="_blank">
                                                    <img src="../assets/images/Download-file.png" width="18px" height="18px" title="Download File"
                                                        alt="" /></a>
                                                          <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("CandDoc_Code") %>' style='<%# "cursor:pointer; color:Blue; display:" + DataBinder.Eval(Container.DataItem, "IsBrowsed") + ";" %>'
                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"><img alt="" src="/assetsprocurement/images/Delete.png" /> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id='<%# Eval("ID","frame-sets{0}") %>' style="display: none;">
                                            <div>
                                                <img id="imgBigImage" runat="server" alt="" src='<%# Eval("DocumentPath") %>' style="max-height: 800px;
                                                    max-width: 1000px;" /></div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <asp:Label ID="lblAxMisc" runat="server" Text="No documents found."></asp:Label>
                </div>
            </div>
        </div>
        <div style="padding: 32px 10px 15px 377px" id="divAction127" runat="server" visible="true"
            clientidmode="Static">
            <asp:HiddenField ID="hdnReload" runat="server" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btrnSaveAll_OnClick"
                CssClass="ButtonsSave11" />
            <%-- <button onclick="" type="button" id="btnReload">Reload</button>--%>
        </div>
    </div>
</asp:Content>