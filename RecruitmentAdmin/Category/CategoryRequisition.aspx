<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CategoryRequisition.aspx.cs" Inherits="CategoryRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Category Requisition</title>
      <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
   

    <script src="../assets/js/stupidtable.js" type="text/javascript"></script>
    <style type="text/css">
        a img
        {
            outline: none;
        }
        img
        {
            border: 0;
            border-style: none;
        }
        
        #checks_container
        {
            background: none repeat scroll 0 0 white;
            border: 1.5px solid #E8E8E8;
            font-family: Calibri;
            font-size: 11px;
            overflow: auto;
            position: absolute;
           
            z-index: 999;
            
        }
        #category_container
        {
            background: none repeat scroll 0 0 white;
            border: 1.5px solid #E8E8E8;
            font-family: Calibri;
            font-size: 11px;
            overflow: auto;
            position: absolute;
            height: 400px;
            z-index: 999;
        }
        
        
        
        th[data-sort]
        {
            cursor: pointer;
            text-decoration: underline;
            color: blue;
        }
        
        
        
        #sortable
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 80%;
        }
        #sortableIns
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 53%;
        }
        #sortableIns li
        {
            margin: 0 3px 3px 3px;
            padding: 0.4em;
            padding-left: 1.5em;
            font-family: Calibri;
            font-size: 14px;
            height: 12px;
            width: 358px;
        }
        #sortableIns li span
        {
            position: absolute;
            margin-left: -1.3em;
        }
        
        .modal-overlay
        {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            background: #332F2F;
            opacity: .95;
            filter: alpha(opacity=95);
            -moz-opacity: 0.75;
            z-index: 101;
        }
        .modal-window
        {
            position: fixed;
            top: 30%;
            left: 50%;
            margin: 0;
            padding: 0;
            z-index: 102;
        }
        .close-window
        {
            position: absolute;
            width: 32px;
            height: 32px;
            right: 8px;
            top: 20px;
            background: url('../images/close.jpg') no-repeat scroll right top;
            text-indent: -99999px;
            overflow: hidden;
            cursor: pointer;
            opacity: .2;
            filter: alpha(opacity=50);
            -moz-opacity: 0.5;
        }
        .close-window:hover
        {
            opacity: .99;
            filter: alpha(opacity=99);
            -moz-opacity: 0.99;
        }
    </style>
    <script type="text/javascript">
        function clickSelect(obj, upload, close, select) {
            obj.click();
            upload.style.display = '';
            close.style.display = '';
            select.style.display = 'none';
        }
        function clickclose(download, upload, close, select) {
            //obj.click();
            download.style.display = 'none';
            upload.style.display = 'none';
            close.style.display = 'none';
            select.style.display = '';


        }

        function clickupload(obj, download, upload, close, select) {
            obj.click();
            download.style.display = '';
            upload.style.display = 'none';
            close.style.display = '';
            select.style.display = 'none';


        }

        function clickDownload(lnkDownload) {
            lnkDownload.click();
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

        function Validate() {
            var inputs = document.getElementsByTagName("input");

            for (var i = 0; i < inputs.length; i++) {

                if (i != 4)
                    if (inputs[i].type == "checkbox") {
                        if (inputs[i].checked == true)
                            return true;
                    }
            }
            alert("Please select some record(s) first.");
            return false;
        }

        function SetEditable(obj, obj1) {

            obj.readOnly = !obj1.checked;
            obj.disabled = !obj1.checked;

            //  alert(obj1.checked);
            //            if (obj1.checked) {
            //            }
            //            else {
            //                obj.readOnly = true;
            //                obj.disabled = true;
            //            }
        }
        function setvalue(obj, obj2) {
            obj2.value = obj.value;
            // alert(obj2.value);   
        }
        function CheckAllCheckBoxes(obj) {
            chk = document.documentElement.getElementsByTagName('input');
            for (var i = 0; i < chk.length; i++) {

                if (chk[i].id.indexOf('chkCandidate') >= 0) {
                    chk[i].checked = obj.checked;
                }
                if (chk[i].id.indexOf('txtNewreq') >= 0) {
                    if (obj.checked) {
                        chk[i].readOnly = false;
                        chk[i].disabled = false;
                    }
                    else {
                        chk[i].readOnly = true;
                        chk[i].disabled = true;
                    }
                }
            }


        }

        function showHideCheckBoxList(checkd, isPostBack) {

            if (checkd) {

                document.getElementById('checks_container').style.display = 'none';
                $(".hideimg1").hide();
                $(".showimg1").show();
            }
            else {

                document.getElementById('checks_container').style.display = '';

                document.getElementById('ctl00_BodyContent_cbdept').checked = false;

                document.getElementById('trselecteion').style.display = '';
                $(".hideimg1").show();
                $(".showimg1").hide();
            }
        }


    
       function LoadList()
    {        
        var ds=null;
        ds = <%=listFilter %>;
            $( "#txtJDName" ).autocomplete({
              source: ds
            });
    }
      
        $(function () {
            $("#Table4").stupidtable();          
            showHideCheckBoxList(true, false);
            showHideCheckBoxListIns(true,true);
            
             });


        function showhideSelectables() {
            var CHK = document.getElementById('ctl00_BodyContent_cbdept');
            // alert(CHK.checked);
            if (CHK.checked)
                document.getElementById('trselecteion').style.display = 'none';
            else
                document.getElementById('trselecteion').style.display = '';
        }

        $(function () {
            showhideSelectables();
            showHideCheckBoxListIns(true, true);
        });


        function showHideCheckBoxListIns(checkd, isPostBack) {

            if (checkd) {
                document.getElementById('checks_container').style.display = 'none';
                $(".hideimg1").hide();
                $(".showimg1").show();
            }
            else {
                document.getElementById('checks_container').style.display = '';
                document.getElementById('ctl00_BodyContent_cbdept').checked = false;
                $(".hideimg1").show();
                $(".showimg1").hide();
            }

            var CHK = document.getElementById("<%=cblDept.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var label = CHK.getElementsByTagName("label");
            document.getElementById('sortableIns').innerHTML = "";
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    var CompName = label[i].innerHTML;
                    var CompCode = "0";
                    document.getElementById('sortableIns').innerHTML += "<li id='" + CompCode + "' class='ui-state-default'>" + CompName + "</li>";
                }
            }
            return false;


        }


          var modalWindow = {
            parent: "body",
            windowId: null,
            content: null,
            width: null,
            height: null,
            close: function () {
                $(".modal-window").remove();
                $(".modal-overlay").remove();
            },
            open: function () {
                var modal = "";
                modal += "<div class=\"modal-overlay\"></div>";
                modal += "<div id=\"" + this.windowId + "\" class=\"modal-window\" style=\"width:" + this.width + "px; height:" + this.height + "px; margin-top:-" + (this.height / 2) + "px; margin-left:-" + (this.width / 2) + "px;\">";
                modal += this.content;
                modal += "</div>";

                $(this.parent).append(modal);

                $(".modal-window").append("<a class=\"close-window\">Close</a>");
                $(".close-window").click(function () { modalWindow.close(); window.parent.location.href = "jdlist.aspx" });
                $(".modal-overlay").click(function () { modalWindow.close(); });
            }
        }
        var openMyModal = function (source) {
            modalWindow.windowId = "myModal";
            modalWindow.width = 810;
            modalWindow.height = 307;
            modalWindow.content = "<iframe width='900' height='407' frameborder='0' scrolling='no' allowtransparency='true' src='" + source + "'></iframe>";
            modalWindow.open();
        };
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManafer1" runat="server">
    </asp:ScriptManager>
    <div id="container" class="contentarea">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table width="100%" cellspacing="0" cellpadding="0" style="padding: 0px; margin: 0px">
                        <tr>
                            <td colspan="4">
                                <b class="pgHeading">Departmental Category Chart - Requisition </b>
                                <div style="float: right">
                                </div>
                            </td> 
                        </tr>
                        <tr>
                            <td align="right">
                                Categories :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDept" runat="server" Width="300px" Style="display: none">
                                </asp:DropDownList>
                                <div class="check textbox">
                                    <input type="checkbox" checked="true" id="cbdept" runat="server" name="chkCategory"
                                        onclick="javascript:showhideSelectables();" value="-1" />Show All &nbsp;<img class="showimg1"
                                            src="../assets/images/open.png" title="Show List" alt="" onclick="showHideCheckBoxList(false, true); "
                                            style="cursor: pointer;">
                                    &nbsp;<img class="hideimg1" src="../assets/images/close.jpg" title="Close" alt="" onclick="showHideCheckBoxListIns(true,false);"
                                        style="display: none; cursor: pointer;">
                                </div>
                                <div id="checks_container" style="display: none">
                                    <div class="check" style="float: left;">
                                        <asp:CheckBoxList runat="server" ID="cblDept">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Department Name :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDept1" runat="server" Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td style="display: none;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btn_SearchClick"
                                    class="btn-ora nl" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="font11" valign="top" id="trselecteion">
                                <ul id="sortableIns">
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnUserTypeCode" />
                </td>
            </tr>
            <tr id="trFound" runat="server">
                <td>
                    <table cellpadding="3" cellspacing="1" width="100%" id="Table4">
                        <asp:Repeater runat="server" ID="rptCategoryList" OnItemDataBound="rptCategoryList_ItemDataBound"
                            OnItemCommand="rptCategoryList_ItemCommand">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th data-sort="string" class="font9" width="20%" align="center" height="18">
                                            Category
                                        </th>
                                        <th data-sort="string" class="font9" width="20%" align="center" height="18">
                                            Domain
                                        </th>
                                        <th data-sort="int" class="font9" width="20%" align="center" height="18">
                                            Sub Domain
                                        </th>
                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                            Approved
                                        </th>
                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                            Filled
                                        </th>
                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                            Unfilled
                                        </th>
                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                            New Requisition
                                        </th>
                                        <th class="font9" width="20%" align="center" height="18">
                                            Action
                                        </th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("CatName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("DomainName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("SubDomainName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("AC")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("FC")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("UP") %></span>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("NR") %></span>
                                    </td>
                                    <td style="text-align: center">
                                        <table width="100%" style="border-style: none">
                                            <tr style="border-style: none">
                                                <td style="border-style: none;width:33%;">
                                                    <div id="divAction65" runat="server" clientidmode="Static" visible="false">
                                                        <a title="Raise Requisition" id="aAddREquisition" runat="server" href="/example/modal-simple/modal.html"
                                                            target="_blank"><img id="img1" src="../assets/images/btn-add.png" width="20px" height="20px" /></a></a></div>
                                                    <asp:HiddenField ID="hdnRR" Value='<%# Eval("CatCode")%>' runat="server" />
                                                    <asp:HiddenField ID="hdnUsertype" Value='<%# Eval("UserType")%>' runat="server" />
                                                </td>
                                                <td style="border-style: none;width:33%;">
                                                    <div id="divAction63" runat="server" clientidmode="Static" visible="false">
                                                        <a id="aApprove" class="openframesmall" runat="server">
                                                            <img id="imgEdit" src="../assets/images/ToDoListIcon.jpg" width="20px" height="20px" title="View Requisition(s) Detail" /></a>
                                                        <%--   <asp:LinkButton ID="lnkapproveDO" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("CatCode") %>'
                                                            CommandName="Approved" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="imgEdit" src="../assets/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                        &nbsp;&nbsp;--%>
                                                    </div>
                                                </td>
                                                <td style="border-style: none;width:33%;"> 
                                                    <div id="divAction64" runat="server" clientidmode="Static" visible="false">
                                                        <%-- <asp:LinkButton ID="lnkDisapproveDO" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("CatCode") %>'
                                                            CommandName="Rejected" OnClientClick="return confirm('Are you sure you want to Reject');"> <img id="img1" src="../assets/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="grey">
                                    <td>
                                        <%# Eval("CatName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("DomainName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("SubDomainName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("AC")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("FC")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("UP") %></span>
                                    </td>
                                    <td style="text-align: center">
                                        <%# Eval("NR") %></span>
                                    </td>
                                    <td style="text-align: center">
                                        <table width="100%" style="border-style: none">
                                            <tr style="border-style: none">
                                                <td style="border-style: none;width:33%;">
                                                    <div id="divAction65" runat="server" clientidmode="Static" visible="false">
                                                        <a title="Raise Requisition" id="aAddREquisition" runat="server" href="/example/modal-simple/modal.html"
                                                            target="_blank"><img id="img1" src="../assets/images/btn-add.png" width="20px" height="20px" /></a></a></div>
                                                    <asp:HiddenField ID="hdnRR" Value='<%# Eval("CatCode")%>' runat="server" />
                                                    <asp:HiddenField ID="hdnUsertype" Value='<%# Eval("UserType")%>' runat="server" />
                                                </td>
                                                <td style="border-style: none;width:33%;">
                                                    <div id="divAction63" runat="server" clientidmode="Static" visible="false">
                                                        <a id="aApprove" class="openframesmall" runat="server">
                                                            <img id="imgEdit" src="../assets/images/ToDoListIcon.jpg" width="20px" height="20px" title="View Requisition(s) Detail" /></a>
                                                        <%--   <asp:LinkButton ID="lnkapproveDO" runat="server" ToolTip="Approve" CommandArgument='<%# Eval("CatCode") %>'
                                                            CommandName="Approved" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="imgEdit" src="../assets/images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                        &nbsp;&nbsp;--%>
                                                    </div>
                                                </td>
                                                <td style="border-style: none;width:33%;"> 
                                                    <div id="divAction64" runat="server" clientidmode="Static" visible="false">
                                                        <%-- <asp:LinkButton ID="lnkDisapproveDO" runat="server" ToolTip="Disapprove" CommandArgument='<%# Eval("CatCode") %>'
                                                            CommandName="Rejected" OnClientClick="return confirm('Are you sure you want to Reject');"> <img id="img1" src="../assets/images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr id="trnorecords" runat="server" align="center">
                <td>
                    <b>No records Found</b>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
