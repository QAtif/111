<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true" CodeFile="BOLGradeWiseBenefits.aspx.cs" Inherits="A2_Reports_BOLGradeWiseBenefits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <script type="text/javascript" src="../assets/js/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });
        function onpress() {
            //debugger;
            $('#id_search_list').quicksearch('table .GridviewScrollItem');

            //document.getElementById('ctl00_BodyContent_hdSearch').value = $('#id_search_list').val();

            //$("table .GridviewScrollItem").addClass("GridviewScrollItem"); 
        }
        function SetValue() {
            $('#id_search_list').val(document.getElementById('ctl00_BodyContent_hdSearch').value);

            document.getElementById('id_search_list').style.display = 'block';
            showsearchtxt
            $("#id_search_list").keyup(onpress);
        }
        function gridviewScroll() {
            $('#<%=gvDetails.ClientID%>').gridviewScroll({
                width: 1240,
                height: 700,
                freezesize: 3,
                startVertical: $("#<%=hfGridView1SV.ClientID%>").val(),
                startHorizontal: $("#<%=hfGridView1SH.ClientID%>").val(),
                onScrollVertical: function (delta) {
                    $("#<%=hfGridView1SV.ClientID%>").val(delta);
                },
                onScrollHorizontal: function (delta) {
                    $("#<%=hfGridView1SH.ClientID%>").val(delta);
                }
            });
            }
            function valthisform() {
                //debugger;
                var frm = document.getElementsByTagName('input')
                var okay = false;
                for (var i = 0; i < frm.length; i++) {
                    if (frm[i].type == 'checkbox')
                        if (frm[i].checked) {
                            okay = true;
                        }
                }
                if (okay) {
                    return confirm('Are you sure you want to Save');
                }
                else {
                    alert("Please Select atleast One Record.");
                    return false;
                }
            }
    </script>
    <style type="text/css">
        .button_example {
            border: 1px solid #25729a;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            font-size: 12px;
            font-family: arial, helvetica, sans-serif;
            padding: 5px 20px 5px 20px;
            text-decoration: none;
            display: inline-block;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight: bold;
            color: #FFFFFF;
            background-color: #3093c7;
            background-image: linear-gradient(to bottom, #3093c7, #1c5a85);
        }

            .button_example:hover {
                border: 1px solid #1c5675;
                background-color: #26759e;
                background-image: linear-gradient(to bottom, #26759e, #133d5b);
            }

        .Gridview {
            font-family: Verdana;
            font-size: 10pt;
            font-weight: normal;
            color: black;
        }

        .GridviewScrollHeader TH, .GridviewScrollHeader TD {
            padding: 5px;
            font-weight: bold;
            white-space: nowrap;
            border-right: 1px solid #AAAAAA;
            border-bottom: 1px solid #AAAAAA;
            background-color: #245E9C;
            text-align: left;
            vertical-align: bottom;
            font-size: 16px;
        }

        .GridviewScrollItem TD {
            padding: 5px;
            white-space: nowrap;
            border-right: 1px solid #AAAAAA;
            border-bottom: 1px solid #AAAAAA;
            font-size: 16px;
        }

        .GridviewScrollPager {
            border-top: 1px solid #AAAAAA;
            background-color: #FFFFFF;
        }

            .GridviewScrollPager TD {
                padding-top: 3px;
                font-size: 18px;
                padding-left: 5px;
                padding-right: 5px;
            }

            .GridviewScrollPager A {
                color: #666666;
            }

            .GridviewScrollPager SPAN {
                font-size: 18px;
                font-weight: bold;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="wrapit topmenu offeraproval "> <div class="domain-name" style="padding:0"> 
        <span class="msearch showsrchbox" style="padding: 16px 0 9px 10px;">Grade wise Benefits</span></div>
    <ul class="TopLeftMenu">
      <%--<li class="last even searchhidden">
        <div class="srch-fix" >
        <asp:HiddenField runat="server" ID="hdSearch" />

         <input type="text"  name="" placeholder="Search By Grade" value="" id="id_search_list" onkeyup="javascript:onpress();" />   
          <input type="submit" class="showsearchtxt" value="">
        </div>
      </li>--%>
    </ul>
  </section>
    <div>
        <table width="100%">
            <tr>
                <td>
                    <br />
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 40%; font-size: 16px" align="right">
                    <strong>Grade : </strong>
                    <asp:TextBox Height="20" runat="server" ID="txtGradeSearch"></asp:TextBox>
                    &nbsp;&nbsp;
                </td>
                <td style="width: 50%; font-size: 16px" align="left">
                    <asp:Button ID="imgGradeSearch" CssClass="button_example" Text="Search" ImageUrl=""
                        ToolTip="Search" runat="server" OnClick="imgGradeSearch_Click" />
                    <asp:LinkButton ID="lnkExport" runat="server" OnClick="imgExcel_Click" Text="Export to excel"
                        Style="margin-left: 10px; font-weight: bold;"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
    <div class="leftside">
        <asp:HiddenField ID="hfGridView1SV" runat="server" />
        <asp:HiddenField ID="hfGridView1SH" runat="server" />
        <%--<div id="div-datagrid" >--%>
        <table border="1" cellpadding="0" cellspacing="0" width="100%">
            <asp:GridView ID="gvDetails" DataKeyNames="OG_OfferletterDataLattest" runat="server"
                AutoGenerateColumns="False" HeaderStyle-BackColor="#61A6F8" HeaderStyle-Font-Bold="true"
                HeaderStyle-ForeColor="White" OnRowCommand="gvDetails_RowCommand" OnRowEditing="gvDetails_RowEditing"
                OnRowCancelingEdit="gvDetails_RowCancelingEdit" OnRowUpdating="gvDetails_RowUpdating">
                <HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chk" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="/assets/Images/update.jpg"
                                ToolTip="Update" Height="20px" Width="20px" />
                            <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="/assets//Images/Cancel.jpg"
                                ToolTip="Cancel" Height="20px" Width="20px" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div id="divAction138" runat="server" visible="false" clientidmode="Static">
                                <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="/assets/images/edit.png"
                                    ToolTip="Edit" Height="20px" Width="20px" />
                            </div>
                        </ItemTemplate>
                        <HeaderTemplate>
                            Action
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:Label ID="lbleditGrade" runat="server" Text='<%#Eval("HrGrade_Description") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGrade" runat="server" Text='<%#Eval("HrGrade_Description") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle Font-Bold="True" Font-Size="16pt" />
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="GrossSalry" DataField="GrossSalry" SortExpression="GrossSalry" />--%>
                    <asp:TemplateField HeaderText="GrossSalry" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtGrossSalry" runat="server" Visible="false" Text='<%#Eval("GrossSalry") %>' />
                            <asp:Label ID="lblGrossSalry" runat="server" Text='<%#Eval("GrossSalry") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Basic Salary" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtBasicSalary" Visible="false" runat="server" Text='<%#Eval("[Basic Salary]") %>' />
                            <asp:Label ID="lblBasicSalary" runat="server" Text='<%#Eval("[Basic Salary]") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Other Allowance" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtOtherAllownce" Visible="false" runat="server" Text='<%#Eval("[Other Allownce]") %>' />
                            <asp:Label ID="lblOtherAllownce" runat="server" Text='<%#Eval("[Other Allownce]") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PF" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPF" Visible="false" runat="server" Text='<%#Eval("PF") %>' />
                            <asp:Label ID="lblPF" runat="server" Text='<%#Eval("PF") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EOBI" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtEOBI" Visible="false" runat="server" Text='<%#Eval("EOBI") %>' />
                            <asp:Label ID="lblEOBI" runat="server" Text='<%#Eval("EOBI") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Accidental Death" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtAccidentalDeath" Visible="false" runat="server" Text='<%#Eval("AccidentalDeath") %>' />
                            <asp:Label ID="lblAccidentalDeath" runat="server" Text='<%#Eval("AccidentalDeath") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Natural Death" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNaturalDeath" Visible="false" runat="server" Text='<%#Eval("NaturalDeath") %>' />
                            <asp:Label ID="lblNaturalDeath" runat="server" Text='<%#Eval("NaturalDeath") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MedicalSelf" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMedicalSelf" Visible="false" runat="server" Text='<%#Eval("MedicalSelf") %>' />
                            <asp:Label ID="lblMedicalSelf" runat="server" Text='<%#Eval("MedicalSelf") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medical Parent" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMedicalParent" Visible="false" runat="server" Text='<%#Eval("MedicalParent") %>' />
                            <asp:Label ID="lblMedicalParent" runat="server" Text='<%#Eval("MedicalParent") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Maternity" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMaternity" Visible="false" runat="server" Text='<%#Eval("Maternity") %>' />
                            <asp:Label ID="lblMaternity" runat="server" Text='<%#Eval("Maternity") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MobileAllowance" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMobileAllowance" Visible="false" runat="server" Text='<%#Eval("MobileAllowance") %>' />
                            <asp:Label ID="lblMobileAllowance" runat="server" Text='<%#Eval("MobileAllowance") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CarName" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCarName" Visible="false" Width="300px" runat="server" Text='<%#Eval("CarName") %>' />
                            <asp:Label ID="lblCarName" runat="server" Text='<%#Eval("CarName") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fuel Quantity" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFuelQuantity" Visible="false" runat="server" Text='<%#Eval("FuelQuantity") %>' />
                            <asp:Label ID="lblFuelQuantity" runat="server" Text='<%#Eval("FuelQuantity") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mineral Water" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtWaterAllownceQuantity" Visible="false" runat="server" Text='<%#Eval("WaterAllownceQuantity") %>' />
                            <asp:Label ID="lblWaterAllownceQuantity" runat="server" Text='<%#Eval("WaterAllownceQuantity") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Compensatory" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCompensatoryAllowance" Visible="false" runat="server" Text='<%#Eval("CompensatoryAllowance") %>' />
                            <asp:Label ID="lblCompensatoryAllowance" runat="server" Text='<%#Eval("CompensatoryAllowance") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paid Vacations" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPaidVacationsAllownace" Visible="false" runat="server" Text='<%#Eval("[Paid Vacations Allownace]") %>' />
                            <asp:Label ID="lblPaidVacationsAllownace" runat="server" Text='<%#Eval("[Paid Vacations Allownace]") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Salon Slots" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtSalonSlot" Visible="false" runat="server" Text='<%#Eval("SalonSlot") %>' />
                            <asp:Label ID="lblSalonSlot" runat="server" Text='<%#Eval("SalonSlot") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GeneratorLoan" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtGeneratorLoan" Visible="false" runat="server" Text='<%#Eval("GeneratorLoan") %>' />
                            <asp:Label ID="lblGeneratorLoan" runat="server" Text='<%#Eval("GeneratorLoan") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CarName2" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCarName2" Visible="false" Width="300px" runat="server" Text='<%#Eval("CarName2") %>' />
                            <asp:Label ID="lblCarName2" runat="server" Text='<%#Eval("CarName2") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Servant" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtServantCount" Visible="false" runat="server" Text='<%#Eval("ServantCount") %>' />
                            <asp:Label ID="lblServantCount" runat="server" Text='<%#Eval("ServantCount") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Servant" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationServant" Visible="false" runat="server" Text='<%#Eval("MonetizationServant") %>' />
                            <asp:Label ID="lblMonetizationServant" runat="server" Text='<%#Eval("MonetizationServant") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Leaves" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationLeaves" Visible="false" runat="server" Text='<%#Eval("MonetizationLeaves") %>' />
                            <asp:Label ID="lblMonetizationLeaves" runat="server" Text='<%#Eval("MonetizationLeaves") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Car1" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationCar1" Visible="false" runat="server" Text='<%#Eval("MonetizationCar1") %>' />
                            <asp:Label ID="lblMonetizationCar1" runat="server" Text='<%#Eval("MonetizationCar1") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Mobile" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationMobile" Visible="false" runat="server" Text='<%#Eval("MonetizationMobile") %>' />
                            <asp:Label ID="lblMonetizationMobile" runat="server" Text='<%#Eval("MonetizationMobile") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Car2" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationCar2" Visible="false" runat="server" Text='<%#Eval("MonetizationCar2") %>' />
                            <asp:Label ID="lblMonetizationCar2" runat="server" Text='<%#Eval("MonetizationCar2") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Health Self" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationHealthSelf" Visible="false" runat="server" Text='<%#Eval("MonetizationHealthSelf") %>' />
                            <asp:Label ID="lblMonetizationHealthSelf" runat="server" Text='<%#Eval("MonetizationHealthSelf") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monet. Health Parent" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonetizationHealthParent" Visible="false" runat="server" Text='<%#Eval("MonetizationHealthParent") %>' />
                            <asp:Label ID="lblMonetizationHealthParent" runat="server" Text='<%#Eval("MonetizationHealthParent") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MobileName" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMobileName" runat="server" Visible="false" Text='<%#Eval("MobileName") %>' />
                            <asp:Label ID="lblMobileName" runat="server" Text='<%#Eval("MobileName") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fuel Quantity 2nd Car" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFuelAllowance2" Visible="false" runat="server" Text='<%#Eval("FuelAllowance2") %>' />
                            <asp:Label ID="lblFuelAllowance2" runat="server" Text='<%#Eval("FuelAllowance2") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridviewScrollHeader" />
                <RowStyle CssClass="GridviewScrollItem" />
            </asp:GridView>
        </table>
        <!-- Page action -->
        <div>

            <asp:Label ID="lblresult" runat="server"></asp:Label>
        </div>

    </div>
    <div class="page-action">
        <div class="page-action-p">
            <div class="page-action">
                <div class="action-pad">
                    <div class="save-btn">


                        <asp:LinkButton ID="lnkapproveAll" runat="server" ToolTip="Save All"
                            CommandName="ApproveHR" CssClass="input-submit" Text="Save All"
                            OnClientClick="return valthisform();" OnClick="lnkapproveAll_Click"></asp:LinkButton>


                        &nbsp;&nbsp;
                                            
                                            
                                               
                                            
                                            
                                                
                                            
                                            
                    </div>





                    <!--<a href="#send-email" class="input-submit xpop">Send Email</a>
                        <input type="submit" value="Save Recording" class="input-submit">
                        <input type="submit" value="Download PDF" class="input-submit"> -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
