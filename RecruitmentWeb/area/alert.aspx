<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AreaMaster.master"
    CodeFile="alert.aspx.cs" Inherits="area_alert" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <%--    <script type="text/javascript">
        $(document).ready(function (e) {
            $(window).scroll(function () {
                if ($(window).scrollTop() + $(window).height() > $(document).height() - 100) {
                    $('#accordionAlerts .accordion-group:last-child').clone().appendTo('#accordionAlerts');
                }
            });
        });
    </script>--%>

    <script type="text/javascript">

        //        $('.accordion-group').click(function (event) {
        //            alert('asim');
        //        });

        function MarkRead(code, ctrl) {
            //  alert(code);

            PageMethods.ProcessIT(code, onSucess, onError);
            function onSucess(result) {
                var ID = ctrl.id.toString();
                var strID = "#ContentContainer_rptCandidateAlerts_dvhead_" + ID;
                //$(strID).css({ 'background-color': 'white' });
                $(strID).attr('class', 'accordion-heading');
            }
            function onError(result) {
                //  alert('Something wrong.');
            }
        }

        $(document).ready(function (e) {
            /* Tabs */
            $('.tabcontroller li a').click(function (e) {
                $(this).addClass('active');
                var relval = $(this).attr('data-rel');
                $('.tabs-content div').hide();
                $('.' + relval).fadeIn("fast");
                $(this).parents().siblings().children().removeClass('active');
            });
        });

    </script>

    <script type="text/javascript">
        xPageELEM = 2;
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="main">
        <div class="row-fluid">
            <div class="span12">
                <section>
    <div class="xboxRight">
        <div class="xBoxHeader">
            <h2 style="height: 20px; line-height: 30px;">
               <asp:Label ID="AlertHead" runat="server" Text=""></asp:Label>
                </h2>
                 
        </div>        
       
          <div class="accordion" id="accordionAlerts">
         <asp:Repeater ID="rptCandidateAlerts" runat="server" OnItemCommand="rptCandidateAlerts_OnItemCommand"
                OnItemDataBound="rptCandidateAlerts_OnItemDataBound">               
                <ItemTemplate> 
                
                 <div class="accordion-group">
                <div class="accordion-heading approved" runat="server" id="dvhead">                              
                    <a id="<%=counter++%>" class="accordion-toggle" data-toggle="collapse" data-parent="#accordionAlerts"
                        href="#collapse<%# DataBinder.Eval(Container.DataItem, "CandidateAlert_Code")%>" onclick="MarkRead(<%# DataBinder.Eval(Container.DataItem, "CandidateAlert_Code")%>,this);">
                        <img src="assets/img/notes/inactive.png" alt="">
                     <span runat="server" id="spanheading" >   <%# DataBinder.Eval(Container.DataItem, "AlertHead")%> </span>  <span class="pull-right"><%# DataBinder.Eval(Container.DataItem, "AlertDate", "{0:MMMMMMMMM dd, yyyy hh:mm tt}")%></span> </a>
                </div>
                <div id='collapse<%# DataBinder.Eval(Container.DataItem, "CandidateAlert_Code")%>' class="accordion-body collapse ">
                    <div class="accordion-inner">
                        <div class="xBoxInner">
                            <button class="close pull-right" data-toggle="collapse" data-parent="#accordionAlerts"
                                data-target="#collapse<%# DataBinder.Eval(Container.DataItem, "CandidateAlert_Code")%>">
                                x</button>
                            <div class="span11">
                                <p>
                                       <%# DataBinder.Eval(Container.DataItem, "AlertBody")%>
                                    </p>

                               <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center">
                    <%--            <asp:Button ID="btnRead" CommandName="Read" Text="Mark Read" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CandidateAlert_Code")%>'
                                    runat="server" BackColor="DimGray" Style="color: White;" />--%>
                            </td>
                        </tr>
                    </table>
                            </div>
                        </div>
                    </div>
                </div>
                        </div>         
               
                </ItemTemplate>                            
                </asp:Repeater>
                 </div>

                   <div class="xboxFooter" align="center"> <a href="javascript:;"><%--Scroll down to see more alerts--%></a> 
                      <asp:Label ID="lblMsg" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                   </div>
            </div>
            </section>
            </div>
        </div>
    </div>
    <div id="pre_joining_modal" class="modal hide theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                x</button>
            <h3>
                Pre-joining Document Checklist</h3>
        </div>
        <div class="modal-body nopad">
            <div class="row-fluid msgarea">
                <div class="span3">
                    <ul class="darkcolor">
                        <li>Candidate Name:</li>
                        <li>Department:</li>
                        <li>Designation:</li>
                        <li>Job Category:</li>
                    </ul>
                </div>
                <div class="span9" style="margin-left: 0">
                    <ul>
                        <li>
                            <asp:Label ID="lblName" runat="server"></asp:Label></li>
                        <li>
                            <asp:Label ID="lblDept" runat="server"></asp:Label></li>
                        <li>
                            <asp:Label ID="lblDesg" runat="server"></asp:Label></li>
                        <li>
                            <asp:Label ID="lblCat" runat="server"></asp:Label></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="modal-body nopad theScroll jsscrollerwidth" style="max-height: 350px !important;">
            <div class="row-fluid">
                <div class="span12">
                    <ul class="tabcontroller">
                        <li><a title="" href="javascript:;" data-rel="tab1" class="active">Education Record</a></li>
                        <li><a title="" href="javascript:;" data-rel="tab2">Personal Record</a></li>
                        <li><a title="" href="javascript:;" data-rel="tab3">Professional Record</a></li>
                    </ul>
                    <div class="tabs-content">
                        <div class="tab1" style="display: block;">
                            <asp:Label ID="lblDocumentOther" runat="server" Visible="false" Text="No Record Found"
                                ForeColor="Red"></asp:Label>
                            <ul>
                                <asp:Repeater ID="rptDocumentOther" runat="server" OnItemDataBound="rptDocumentOther_OnItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                            <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="tab2">
                            <asp:Label ID="lblDocumentPersonal" runat="server" Visible="false" Text="No Record Found"
                                ForeColor="Red"></asp:Label>
                            <ul>
                                <asp:Repeater ID="rptDocumentPersonal" runat="server" OnItemDataBound="rptDocumentPersonal_OnItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                            <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="tab3">
                            <asp:Label ID="lblDocumentExperience" runat="server" Visible="false" Text="No Record Found"
                                ForeColor="Red"></asp:Label>
                            <ul>
                                <asp:Repeater ID="rptDocumentExperience" runat="server" OnItemDataBound="rptDocumentExperience_OnItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                            <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="addpadd">
                        <ol class="addlisting">
                            <li>Please bring all the original documents and photocopies.</li>
                            <li>Please bring 1 Passport size photo of Self, Parents, Spouse and kids (if Applicable)</li>
                            <li>Please note that the documents you submit should be in accordance with the information
                                you submitted earlier.</li>
                        </ol>
                        <strong>Credential Verification Authorization</strong>
                        <p>
                            You will be required to sign an authorization form that will be authorizing Axact
                            to authenticate and verify all your credentials from the past employers, educational
                            institutes, your provided references and any other entity as they deemed appropriate.</p>
                    </div>
                </div>
            </div>
        </div>
        <%--<iframe id="IframeDoc" src="documentchecklist.aspx" width="100%" height="537px" frameborder="0"
                    scrolling="no"></iframe>--%>
    </div>
</asp:Content>
