<%@ Page Title="" Language="C#" MasterPageFile="../Admin.master" AutoEventWireup="true"
    CodeFile="Departmental-Structure.aspx.cs" Inherits="Departments_Departmental_Structure" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function onpress() {
            $('#id_search_list').quicksearch('#UlMain>li');
        }
        // var qs = $('#id_search_list').quicksearch('#UlMain li');

        $(document).ready(function () {
            //$(".openframe").fancybox({
            //    fitToView: false,
            //    width: '70%',
            //    height: '100%',
            //    type: 'iframe'
            //});
            $('.openframe').fancybox({
                fitToView: false,
                //autoDimensions: true,
                height: 'auto',
                width: '770',
                autoSize: true,
                openEffect: 'none',
                closeEffect: 'none',
                padding: 0,
                'closeBtn': false,
                'scrolling': 'no',
               type: 'iframe',
                afterShow: function () {
                    $.fancybox.update();
                }
            });
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManafer1" runat="server"></asp:ScriptManager>
    <div class="ShowAllDataGrid">

        <section class="wrapit topmenu joinbot">
            <span class="msearchIcon"></span><span class="msearch showsrchbox">Departmental Structure</span>
        </section>
        <form class="searcharea">
            <div id="fresh-search" class="SearchBox adjustwidth">
                <div class="InsideSearchBox">
                    <div class="HeadingInside"><span class="BasicInfoIcon"></span><span class="IconTxt">Search</span> <span class="borderHeader"></span></div>
                    <!-- #HeadingInside -->

                    <div class="basicSearchArea">
                        <div class="BasicLeft">
                            <div class="clearfix"></div>
                            <div class="FieldWrapper">
                                <div class="Lable">Department</div>
                                <!-- #Lable -->
                                <div class="InputField jqtranformdone">
                                    <asp:DropDownList ID="ddlDepartment" CssClass="inputClass jqtranformdone" AutoPostBack="true" OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged" runat="server" Width="280px">
                                    </asp:DropDownList>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->
                            </div>
                          <div class="SectionDiv"></div>

                           <div class="BasicRight">
                            <div class="FieldWrapper">
                                <div class="Lable">Category</div>
                                <!-- #Lable -->
                                <div class="InputField jqtranformdone">
                                    <asp:DropDownList ID="ddlCategory" CssClass="inputClass jqtranformdone" runat="server" Width="280px">
                                    </asp:DropDownList>
                                </div>
                                <!-- #InputField -->
                            </div>
                            <!-- #FieldWrapper -->

                        
                        <!-- #basicSearchArea -->

                        <div class="clearfix"></div>
</div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="BorderDiv"></div>
                <div class="ButtonsSave">
                    <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="Search_Click"
                        ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                    </asp:LinkButton>
                </div>
                <!-- #ButtonsSave -->
            </div>
        </form>

        <section class="departmental">
            <header>
                <ul class="headlist">
                    <li class="NewLi"></li>
                    <li>Approved</li>
                    <li>Filled</li>
                    <li>UnFilled</li>
                    <li>New</li>
                </ul>
                <h3>Department</h3>

            </header>
            <article>
                <asp:HiddenField ID="hdnSelectedCategory" runat="server" />
                <asp:Repeater ID="rptDeparments" runat="server" OnItemDataBound="rptDepartment_ItemDataBound">
                    <ItemTemplate>
                        <div class="accord">
                            <asp:HiddenField ID="hdnDepCode" runat="server" Value='<%# Eval("DomainCode") %>' />
                            <div class="acchead lstbar clear">
                                <i class="icon-switch"></i>
                                <%--<a href="#" class="rfl cldr"><i class="icon-cldr"></i></a>--%>
                                
                                <a href="#" id="UpdateReqStatus" runat="server" class="openframe rfl cldr "><i class="icon-cldr switchaccord"></i></a>
                                
                                <hr class="rfl">
                                <ul class="listdat">
                                    <li><%# Eval("AC") %></li>
                                    <li><%# Eval("FC") %></li>
                                    <li><%# Eval("UP") %></li>
                                    <li><%# Eval("NR") %></li>
                                </ul>
                                <h4 title='<%# Eval("DomainName") %>'><%# Eval("DomainName") %><span></span></h4>
                            </div>
                            <div class="accinside">
                                <asp:Repeater ID="rptCat" runat="server">
                                    <ItemTemplate>
                                        <div class="lstbar clear">
                                            <asp:HiddenField ID="hdnCatCode" runat="server" Value='<%# Eval("CatCode") %>' />
                                            <div id="divAction82" runat="server" clientidmode="Static" visible="false">
                                                <a href="#frame-sets" title="" class=" poptheform rfl butn" onclick='$("#ctl00_BodyContent_hdnSelectedCategory").val("");$("#ctl00_BodyContent_hdnSelectedCategory").val(<%# Eval("CatCode") %>)'>New Requisition</a>
                                            </div>

                                            <ul class="listdat">
                                                <li class="NewLi"><%# Eval("SubDomain") %></li>
                                                <li><%# Eval("AC") %></li>
                                                <li><%# Eval("FC") %></li>
                                                <li><%# Eval("UP") %></li>
                                                <li><%# Eval("NR") %></li>
                                            </ul>
                                            <h4 title='<%# Eval("FullCategoryName") %>'><%# Eval("CatName") %></h4>

                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <%--<div id='<%# Eval("DomainCode","frame-sets{0}") %>' style="display: none;">
                                <section class="popcontainer poptheformbody width740">
                                    <article>
                                        <a href="javascript:;" title="" class="closebtn" onclick="javascript:$.fancybox.close();"></a>
                                        <h2>View Requisition</h2>
                                        <table>
                                            <asp:Repeater ID="rptRequisitions" runat="server" OnItemCommand="rptRequisitions_ItemCommand">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <td scope="col" class="widtd76">Requisition</td>
                                                        <td scope="col" class="widtd100">Category</td>
                                                        <td scope="col" class="widtd119">Last Updated By</td>
                                                        <td scope="col" class="widtd180">Status</td>
                                                        <td scope="col" class="widtd50" style="text-align: center">Quantity</td>
                                                        <td scope="col" class="widtd50" style="text-align: center">Category Specialist</td>
                                                        <td scope="col" style="text-align: center">Action</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>

                                                        <td>
                                                            <asp:HiddenField ID="hdnRR" runat="server" Value='<%# Eval("CatCode") %>' />
                                                            <asp:Label ID="lbltest" runat="server" Text='<%# Eval("CatCode") %>'> </asp:Label>
                                                            <%# Eval("ReqName")%></td>
                                                        <td><%# Eval("CatName")%></td>
                                                        <td><%# Eval("LastUpdatedBy") %></td>
                                                        <td><%# Eval("ReqStatus")%></td>
                                                        <td style="text-align: center"><%# Eval("Quantity") %></td>
                                                        <td style="text-align: center">
                                                            <asp:DropDownList ID="ddlCategorySpecialist" CssClass="inputClass jqtranformdone" runat="server" Width="200px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <ul class="updateState">
                                                                <li class="approve first odd" style="text-align: center;">
                                                                    <div id="divAction76" runat="server" clientidmode="Static" visible="false">
                                                                        <asp:LinkButton ID="lnkADO" runat="server" Visible='<%#((int)Eval("ApproveDO") == 1) ? true : false %>'
                                                                            CommandName="ApprovedDO" CommandArgument='<%# Eval("ReqCode") %>' OnClientClick="javascript:return confirm('Are you sure you want to approve?');"><img id="img2" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                                    </div>
                                                                    <div id="divAction77" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                                                        <asp:LinkButton ID="lnkAHrDO" runat="server" Visible='<%#((int)Eval("ApproveHRDO") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to approve?');"
                                                                            CommandName="ApprovedHrDo" CommandArgument='<%# Eval("ReqCode") %>'>
                                                           <img id="img3" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                                    </div>
                                                                    <div id="divAction78" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                                                        <asp:LinkButton ID="lnkAOPD" runat="server" Visible='<%#((int)Eval("ApproveOPD") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to approve?');"
                                                                            CommandName="ApprovedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img4" src="../assets/images/accept.png" width="20px" height="20px" title="Approve Requisition" /></asp:LinkButton>
                                                                    </div>
                                                                </li>
                                                                <li class="reject last even">
                                                                    <div id="divAction79" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                                                        <asp:LinkButton ID="lnkDDO" runat="server" Visible='<%#((int)Eval("DisapproveDO") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to reject?');"
                                                                            CommandName="RejectedDO" CommandArgument='<%# Eval("ReqCode") %>'><img id="img1" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                                    </div>
                                                                    <div id="divAction80" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                                                        <asp:LinkButton ID="lnkDHrDO" runat="server" Visible='<%#((int)Eval("DisapproveHRDO") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to reject?');"
                                                                            CommandName="RejectedHrDo" CommandArgument='<%# Eval("ReqCode") %>'><img id="img5" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                                    </div>
                                                                    <div id="divAction81" runat="server" clientidmode="Static" visible="false" style="text-align: center;">
                                                                        <asp:LinkButton ID="lnkDOPD" runat="server" Visible='<%#((int)Eval("DisapproveOPD") == 1) ? true : false %>' OnClientClick="javascript:return confirm('Are you sure you want to reject?');"
                                                                            CommandName="RejectedOPD" CommandArgument='<%# Eval("ReqCode") %>'><img id="img6" src="../assets/images/Disapprove.png" width="20px" height="20px" title="Reject Requisition" /></asp:LinkButton>
                                                                    </div>
                                                                </li>
                                                            </ul>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />

                                    </article>
                                </section>
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </article>
        </section>

    </div>
    <!-- #form -->






    <div id="frame-sets" style="display: none;">
        <section class="popcontainer poptheformbody">
            <article>
                <a href="javascript:;" title="" class="closebtn" onclick="javascript:$.fancybox.close();"></a>
                <h2>Raise Requisition</h2>
                <ul>
                    <li><span class="labelbox">No. of Candidates</span>
                        <input type="text" name="txtno" placeholder="" id="NoOfCan" maxlength="3" onkeydown="return isNumberKey(event);" /></li>
                    <li><span class="labelbox">City</span>
                        <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList></li>

                </ul>
                <label id="lblError" style="padding-left: 11px;color:red;"></label>
                <div class="ftbuttons">

                    <input type="button" class="SubmteForm" value="Add Requisition" onclick="RaiseRequisition()" />
                    

                </div>
            </article>
        </section>
    </div>
    <style>
      
    </style>
    <script language="javascript" type="text/javascript">

        function RaiseRequisition() {
            if ($('#NoOfCan').val() != '' && $('#NoOfCan').val() != 0) {
                $('#NoOfCan').removeClass('BorderRed');
              //  $('#lblError').text('');
                // alert($('#BodyContent_hdnSelectedCategory').val() + '|' + $("#BodyContent_ddlCity :selected").val() + '|' + $('#NoOfCan').val() + '|' + '<%=UserCode1 %>' + '|' + '<%=updateByIP %>');
                var Param = $('#ctl00_BodyContent_hdnSelectedCategory').val() + '|' + $("#ctl00_BodyContent_ddlCity :selected").val() + '|' + $('#NoOfCan').val() + '|' + '<%=UserCode1 %>' + '|' + '<%=updateByIP %>';
                //   if($('#ASubmit1').text().trim() != "Request sent") {
                $.ajax({
                    type: "POST",
                    url: "Departmental-Structure.aspx/RaiseRequisition",
                    data: JSON.stringify({ items: Param }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert("Successfully Saved!");
                        parent.location.href = parent.location.href;
                    },
                    error: function (msg) {
                        alert("error");
                    }
                });
            }
            else {
               // $('#lblError').text("Number of candidates should be greater than 0");
                $('#NoOfCan').addClass('BorderRed');
                return false;
            }
        }
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


