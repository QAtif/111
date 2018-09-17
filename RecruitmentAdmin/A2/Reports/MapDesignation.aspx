<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/A2/Admin.master"
    CodeFile="MapDesignation.aspx.cs" Inherits="A2_Reports_MapDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
    <script type="text/javascript" src="/assets/js/jquery1.4.4.js"></script>
    <%--<script type="text/javascript" src="/assets/js/jquery-ui-1.8.4.custom.min.js"></script>
    <script type="text/javascript" src="/assets/js/jq.menu.js"></script>
    <script type="text/javascript" src="/assets/js/jquery.colorbox.js"></script>
    <script type="text/javascript" src="/assets/js/jquery.functions.js"></script>--%>
    <script type="text/javascript" src="/assets/js/jQuery.dualListBox-1.2.min.js" language="javascript"></script>
    <script src="../assets/js/QuicjSearch.js" type="text/javascript"></script>
    <%--<link href="../assets/css/style.css" rel="stylesheet" type="text/css" />--%>
    <script language="javascript" type="text/javascript">

        function onpress() {

            $('#id_search_list').quicksearch('table tbody tr');
        }
    </script>
    <script type="text/javascript">
        //        ddsmoothmenu.init({
        //            mainmenuid: "smoothmenu1", //menu DIV id
        //            orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
        //            classname: 'ddsmoothmenu', //class added to menu's outer DIV
        //            //customtheme: ["#1c5a80", "#18374a"],
        //            contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
        //        })
    </script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $.configureBoxes({
                box1View: 'client1View',
                box1Storage: 'client1Storage',
                box1Filter: 'client1Filter',
                box1Clear: 'client1Clear',
                box1Counter: 'client1Counter',
                box2View: 'ctl00_BodyContent_client2View',
                box2Storage: 'client2Storage',
                box2Filter: 'client2Filter',
                box2Clear: 'client2Clear',
                box2Counter: 'client2Counter',
                to1: 'client2toclient1',
                to2: 'client1toclient2',
                allTo1: 'client2allToclient1',
                allTo2: 'client1allToclient2'
            });




        });

        function PutListBoxItemsToHiddenFields() {

            var lbox;

            //work for clients
            var lbox = document.getElementById('ctl00_BodyContent_client2View');
            var dVar = "";
            for (var i = 0; i < lbox.options.length; ++i)
                dVar = dVar + lbox.options[i].value + ",";
            document.getElementById('hfClients').value = dVar;

            alert(document.getElementById('hfClients').value);

            return true;
        }
        function valthisform() {
            //debugger;

            var dpt = document.getElementById("ctl00_BodyContent_client2View");
            //alert(dpt.options[dpt.selectedIndex].value);
            //return false;

            var frm = document.getElementsByTagName('input')
            var okay = false;
            for (var i = 0; i < frm.length; i++) {
                if (frm[i].type == 'checkbox')
                    if (frm[i].checked) {
                        okay = true;
                    }
            }
            if (okay) {
                if (dpt.selectedIndex != '-1')
                    return confirm('Are you sure you want to Map this Designation');
                else {
                    alert("Please Select Record from Filter 2.");
                    return false;
                }
            }
            else {
                alert("Please Select atleast One Record.");
                return false;
            }
        }
        function valthisformInstitute() {
            //debugger;
            var frm = document.getElementById('ctl00_BodyContent_txtDesignation');
            if (frm.value != '')
                return true;
            else {
                alert("Please Enter Designation Name.");
                return false;
            }
        }
        function ShowDiv() {
            //debugger;
            //if (document.getElementById('dvIns').style.display = '')
            //    document.getElementById('dvIns').style.display = 'none';
            //else
            $('#dvIns').fadeIn('slow');
            //document.getElementById('dvIns').style.display = '';
        }
        function CreateCompanyArray(obj1, obj2) {

            var newVal = $('#ctl00_BodyContent_hdInstitute').val();

            if (obj1.checked) {
                $('#ctl00_BodyContent_hdInstitute').val(newVal + "," + obj2);
            }
            else {
                var oldValue = "," + obj2;
                newVal = newVal.replace(oldValue, '');
                $('#ctl00_BodyContent_hdInstitute').val(newVal);
            }
            //alert($('#ctl00_BodyContent_hdInstitute').val());
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
	
    <section class="pagewrap">
    	<article>
        	<div class="leftside">
            <div class="filtertbl">
                  <label>Filter :</label>
                  <%-- <input type="text" name="" placeholder="Search" value="" id="id_search_list" onkeyup="javascript:onpress();" />--%>
                 <asp:TextBox ID="txtSearchKeyword" runat="server" AutoPostBack="true" OnTextChanged="txtSearchKeyword_TextChanged"></asp:TextBox>
                   </div>

                
                <div class="scrollable">
                <table border="1" cellpadding="0" cellspacing="0" width="40%">
                <asp:HiddenField runat="server" ID="hdInstitute" />
                    <asp:Repeater ID="rptInstitute" runat="server" OnItemDataBound="rptInstitute_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center" style="width: 10%">
                                    <asp:CheckBox runat="server" ID="chk" />
                                </td>
                                <td align="center" style="width: 10%">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td align="left">
                                    <%# Eval("JobTitle")%>
                                    <asp:HiddenField runat="server" ID="hdfInstituteCode" Value='<%# Eval("JobTitle_Code")%>' />
                                </td>
                                <td align="center" style="width: 30%">
                                    <asp:HiddenField runat="server" ID="hdRefNo" Value='<%# Eval("Candidate_Code")%>' />
                                    <a id="a1" runat="server" target="_blank">
                                        <%# Eval("Reference_Code")%></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </div>
                
            </div>
            <div class="rightside">
            	<div class="filtertbl">
                  <label>Filter :</label>
                   <input type="text" id="client2Filter" placeholder="Search" />
                   </div>
            	<asp:ListBox ID="client2View" runat="server" SelectionMode="Single" CssClass="multiselectbox" DataTextField="JobTitle" DataValueField="JobTitle_Code"></asp:ListBox>
           		<span id="client2Counter" class="countLabel"></span>
				
            
            </div>
            
            <div class="centerdiv">
            	
                <select id="client2Storage"></select>
            
            
            <asp:Button ID="ImageButton1" Text="Map Designation" OnClick="BtnSearchFresh_Click" ImageUrl="" ToolTip="Map Designation"
                OnClientClick="return valthisform();" CssClass="input-submit" runat="server" />
            
            <input type="button" value="Add New Designation" class="input-submit" onclick="ShowDiv();" />
            <br clear="all">

            	<div id="dvIns" class="hiddentbl">
                    <div class="row"><label>Designation:</label>
                    <asp:TextBox runat="server" ID="txtDesignation"></asp:TextBox></div>
                    
                  
                    <div class="row">
                    <label>&nbsp;</label>
                    <asp:Button ID="imgInstitute" Text="Submit" ImageUrl="" ToolTip="Submit" OnClientClick="return valthisformInstitute();"
                        runat="server" OnClick="imgInstitute_Click" CssClass="input-submit" /></div>
                </div>
            </div>
            
                
 
        </article>
    </section>
 
</asp:Content>
