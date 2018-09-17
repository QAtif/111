<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categorylist.aspx.cs" Inherits="Categorylist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>JD Structure - Job Admin</title>
    <link rel="stylesheet" type="text/css" href="../../Include/stylesheet.css">
    <script language="javascript" src="../../include/validation.js"> </script>
    <style type="text/css">
        a
        {
            color: #ffffff;
            text-decoration: none;
            border: 0;
            outline: none;
        }
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
            height: 400px;
            z-index: 999;
            width: 350px;
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
        
        .Center
        {
            margin-right: auto;
            margin-left: auto;
            padding-left: auto;
            padding-right: auto;
            border: thin groove #C0C0C0;
        }
        
        .center tr, td
        {
            /*border: thin groove #C0C0C0;*/
            font-family: Calibri;
            font-size: 13px;
        }
        th[data-sort]
        {
            cursor: pointer;
            text-decoration: underline;
            color: blue;
        }
    </style>
    <link href="css/stylesheetMaster.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="/RecrutmentMisc//scripts/stupidtable.js"></script>
    <script src="/RecrutmentMisc//scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="/RecrutmentMisc//scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .grey
        {
            background: #F1F1F1;
            text-indent: 0px;
        }
        .greyHeading
        {
            background: #DBD3C1;
            text-indent: 0px;
            font-weight: bolder;
        }
        .normal
        {
            background: #ffffff;
            text-indent: 0px;
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
        th[data-sort]
        {
            cursor: pointer;
            text-decoration: underline;
            color: blue;
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
                document.getElementById('cbdept').checked = false;
                document.getElementById('trselecteion').style.display = '';
                $(".hideimg1").show();
                $(".showimg1").hide();
            }
        }


    </script>
    <script type="text/javascript">
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

    </script>
    <script type="text/javascript">

        function showhideSelectables() {
            var CHK = document.getElementById('cbdept');
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
                document.getElementById('cbdept').checked = false;
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


    </script>
    <script type="text/javascript">        var modalWindow = {
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
</head>
<body onload="LoadList()">
    <form id="Form1" runat="server">
    <table border="0" width="1200" cellspacing="0" cellpadding="0" id="tblmain" runat="server"
        style="padding-top: 10px;">
        <tr>
            <td width="100%" height="75">
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="30%" valign="top" style="padding-top: 2px">
                        </td>
                        <td valign="top">
                            <table>
                                <tr style="border: none">
                                    <td style="border: none">
                                        <table width="1000" cellspacing="0" cellpadding="4" class="Center">
                                            <tr>
                                                <td colspan="4">
                                                    <b class="pgHeading">Departmental JD Chart - Requisition </b>
                                                    <div style="float: right">
                                                        <asp:LinkButton ID="lnkRefresh" runat="server" OnClick="lnkRefresh_OnClick" Text="Refresh"
                                                            Style="color: #0033CC; text-decoration: underline"></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" align="right">
                                                    Departments :
                                                </td>
                                                <td style="width: 30%">
                                                    <asp:DropDownList ID="ddlDept" runat="server" Width="300px" Style="display: none">
                                                    </asp:DropDownList>
                                                    <div class="check textbox">
                                                        <input type="checkbox" checked="true" id="cbdept" runat="server" name="chkCategory"
                                                            onclick="javascript:showhideSelectables();" value="-1" />Show All &nbsp;<img class="showimg1"
                                                                src="../images/open.png" title="Show List" alt="" onclick="showHideCheckBoxList(false, true); "
                                                                style="cursor: pointer;">
                                                        &nbsp;<img class="hideimg1" src="../images/close.jpg" title="Close" alt="" onclick="showHideCheckBoxListIns(true,false);"
                                                            style="display: none; cursor: pointer;">
                                                    </div>
                                                    <div id="checks_container" style="display: none">
                                                        <div class="check" style="float: left;">
                                                            <asp:CheckBoxList runat="server" ID="cblDept">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="display: none;" align="right">
                                                    Categories :
                                                </td>
                                                <td style="width: 30%; display: none;">
                                                    <asp:DropDownList runat="server" ID="ddlCat" Width="300px" Style="display: none">
                                                    </asp:DropDownList>
                                                    <div class="check textbox">
                                                        <input type="checkbox" checked="false" id="cbcat" runat="server" name="chkCategory"
                                                            value="-1" />Show All &nbsp;<img class="showimg" src="../images/open.png" alt=""
                                                                onclick="showHideCheckBoxListCat(false, true);">
                                                        &nbsp;<img class="hideimg" src="../images/close.jpg" alt="" onclick="showHideCheckBoxListCat(true, false);"
                                                            style="display: none;">
                                                    </div>
                                                    <div id="category_container" style="display: none">
                                                        <div class="check" style="float: left;">
                                                            <asp:CheckBoxList runat="server" ID="cblCat">
                                                            </asp:CheckBoxList>
                                                            <img src="../images/close.jpg" alt="" onclick="showHideCheckBoxListIns(true, true); "></div>
                                                    </div>
                                                </td>
                                                <td rowspan="3" align="right" valign="bottom">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr valign="middle">
                                                                        <td>
                                                                            <image id="imgEditLeg" src="../images/edit.png" width="20px" height="20px">
                                                                        </td>
                                                                        <td align="left" valign="middle">
                                                                            Edit JD Details
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="middle">
                                                                        <td>
                                                                            <image id="imgEditLeg" src="../images/save.png" width="20px" height="20px">
                                                                        </td>
                                                                        <td align="left" valign="middle">
                                                                            Save Requisition Count
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="middle">
                                                                        <td>
                                                                            <image id="imgEditLeg" src="../images/accept.png" width="20px" height="20px">
                                                                        </td>
                                                                        <td align="left" valign="middle">
                                                                            Approve Requisition
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table>
                                                                    <tr valign="middle">
                                                                        <td>
                                                                            <image id="imgEditLeg" src="../images/upload.png" width="20px" height="20px">
                                                                        </td>
                                                                        <td align="left" valign="middle">
                                                                            Upload File
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="middle">
                                                                        <td>
                                                                            <image id="imgEditLeg" src="../images/download.png" width="22px" height="22px">
                                                                        </td>
                                                                        <td align="left" valign="middle">
                                                                            View Department Structure
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="middle">
                                                                        <td>
                                                                            <image id="imgEditLeg" src="../images/Disapprove.png" width="20px" height="20px">
                                                                        </td>
                                                                        <td align="left" valign="middle">
                                                                            Disapprove Requisition
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    JD Name :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtJDName" runat="server" Width="300px"></asp:TextBox>
                                                </td>
                                                <td style="display: none;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btn_SearchClick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" class="font11" valign="top" id="trselecteion">
                                                    <ul id="sortableIns">
                                                    </ul>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="border: none">
                                    <td style="border: none; padding-right: 100px;" align="right">
                                        <a id="aaddnew" runat="server" title="Edit JD" href="/example/modal-simple/modal.html"
                                            target="_blank" style="color: #0033CC; text-decoration: underline">Add New JD
                                        </a>
                                    </td>
                                </tr>
                                <tr id="trFound" runat="server" style="border: none">
                                    <td style="border: none">
                                        <table width="1000" cellspacing="0" cellpadding="0" class="Center" style="border: none;
                                            background-color: Grey;">
                                            <tr>
                                                <td width="100%" colspan="2">
                                                    <table class="table1" cellpadding="3" cellspacing="1" width="100%" id="Table4">
                                                        <asp:Repeater runat="server" ID="rptJDLIst" OnItemDataBound="rptjdlist_ItemDataBound"
                                                            OnItemCommand="rptjdlist_CommandArguments">
                                                            <HeaderTemplate>
                                                                <thead>
                                                                    <tr class="greyHeading">
                                                                        <th style="width: 5%" align="center">
                                                                            <input type="checkbox" id="chkAllCandidate" runat="server" onclick="javascript:CheckAllCheckBoxes(this)" />
                                                                        </th>
                                                                        <th data-sort="string" class="font9" width="22%" align="center" height="18">
                                                                            Department
                                                                        </th>
                                                                        <th data-sort="string" class="font9" width="22%" align="center" height="18">
                                                                            Job Description
                                                                        </th>
                                                                        <th style="display: none;" data-sort="string" class="font9" width="15%" align="center"
                                                                            height="18">
                                                                            Category
                                                                        </th>
                                                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                                                            Total Count Approved
                                                                        </th>
                                                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                                                            Filled Positions
                                                                        </th>
                                                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                                                            Unfilled Positions
                                                                        </th>
                                                                        <th data-sort="int" class="font9" width="5%" align="center" height="18">
                                                                            New Requisition
                                                                        </th>
                                                                        <th class="font9" width="17%" align="center" height="18">
                                                                            Action
                                                                        </th>
                                                                        <th class="font9" width="18%" align="center" height="18">
                                                                            Search
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr class="normal">
                                                                    <td style="text-align: center">
                                                                        <input id="chkCandidate" runat="server" type="checkbox" />
                                                                        <asp:HiddenField runat="server" ID="hdnJdcode" Value='<%# Eval("jdcode") %>' />
                                                                    </td>
                                                                    <td>
                                                                        <%# Eval("deptname")%>
                                                                        <div style="float: right" id="DivUpload" runat="server">
                                                                            <asp:HiddenField runat="server" ID="hdnFileUrl" Value='<%#Eval("File_Url") %>' />
                                                                            <asp:Image ID="imgClose" runat="server" ImageUrl="../images/close.png" runat="server"
                                                                                Style="display: none" title="Select New File" />
                                                                            <asp:Image ID="Imageselect" ImageUrl="../images/upload.png" runat="server" Width="20px"
                                                                                Height="20px" title="Select Department Structure File" />
                                                                            <asp:FileUpload ID="fuCandidateDocument" runat="server" Style="display: none" />
                                                                            <asp:Image ID="imgupload" ImageUrl="../images/save.png" runat="server" Width="20px"
                                                                                Height="20px" Style="display: none" title="Upload Selected Department Structure File" />
                                                                            <asp:LinkButton ID="lnkUpload" runat="server" ToolTip="Upload " CommandArgument='<%# Eval("dcode") %>'
                                                                                CommandName="upload" Style="display: none"></asp:LinkButton>
                                                                            <asp:Image ID="imgDownload" runat="server" ImageUrl="../images/download.png" runat="server"
                                                                                title="View Department Structure File" Width="22px" Height="22px" Style="display: none" />
                                                                            <asp:LinkButton ID="lnkDownload" runat="server" ToolTip="Download " CommandArgument='<%# Eval("File_Url") %>'
                                                                                CommandName="Download" Style="display: none"></asp:LinkButton>
                                                                        </div>
                                                                    </td>
                                                                    <td valign="middle">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="left" width="97%">
                                                                                    <%# Eval("jdname")%>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <a title="Edit JD" id="aeditjd" runat="server" href="/example/modal-simple/modal.html"
                                                                                        target="_blank">
                                                                                        <img id="imgEdit" src="../images/edit.png">
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="display: none;">
                                                                        <%# Eval("catname")%>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%# Eval("totalcount")%>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%# Eval("filledPos")%>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%--  <a id="aUnfilled" runat="server" target="_blank"></a>--%>
                                                                        <%# Eval("unfilledcount")%>
                                                                        <asp:HiddenField ID="hdnunfilledcount" Value='<%# Eval("unfilledcount")%>' runat="server" />
                                                                        <asp:HiddenField ID="hdnJdK" Value='<%# Eval("JDKeywords")%>' runat="server" />
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <span style="color: #FFFFFF; display: none;">
                                                                            <%# Eval("nr") %></span>
                                                                        <asp:HiddenField runat="server" ID="hdnCatCode" Value='<%# Eval("nr") %>' />
                                                                        <asp:HiddenField runat="server" ID="hdnnewvalue" Value='<%# Eval("nr") %>' />
                                                                        <asp:TextBox runat="server" ID="txtNewreq" Text='<%# Eval("nr") %>' Width="30px"
                                                                            MaxLength="3" ReadOnly="true" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%-- <asp:ImageButton runat="server" ToolTip="Click here to save record" ID="btnSave" CommandArgument='<%# Eval("jdcode") %>' CommandName="Save" />--%>
                                                                        <asp:LinkButton ID="lnlSave" runat="server" ToolTip="Save" Style="color: white;"
                                                                            CommandArgument='<%# Eval("jdcode") %>' CommandName="Save"> <img id="imgEdit" src="../images/save.png" width="20px" height="20px" /></asp:LinkButton>
                                                                        <%-- <span id="gap" runat="server">&nbsp;|&nbsp;</span>--%>
                                                                        &nbsp;&nbsp;
                                                                        <asp:LinkButton ID="lnkapprove" runat="server" ToolTip="Approve Requisition" CommandArgument='<%# Eval("jdcode") %>'
                                                                            CommandName="approve" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="imgEdit" src="../images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                                        &nbsp;&nbsp;
                                                                        <asp:LinkButton ID="lnkDisapprove" runat="server" ToolTip="Disapprove Requisition"
                                                                            CommandArgument='<%# Eval("jdcode") %>' CommandName="Disapprove" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img1" src="../images/Disapprove.png" width="20px" height="20px" /></asp:LinkButton>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <a id="aAxactSearch" runat="server" target="_blank">
                                                                            <img src="../images/favicon.png" height="15px" width="15px" />(<%# Eval("AxactCount")%>)</a>
                                                                        &nbsp; &nbsp;<a id="aBolSearch" runat="server" target="_blank"><img src="../images/logo.gif"
                                                                            height="15px" width="15px" />
                                                                            (<%# Eval("BolCount")%>) </a>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <AlternatingItemTemplate>
                                                                <tr class="grey">
                                                                    <td style="text-align: center">
                                                                        <input id="chkCandidate" runat="server" type="checkbox" />
                                                                        <asp:HiddenField runat="server" ID="hdnJdcode" Value='<%# Eval("jdcode") %>' />
                                                                    </td>
                                                                    <td>
                                                                        <%# Eval("deptname")%>
                                                                        <div style="float: right" id="DivUpload" runat="server">
                                                                            <asp:HiddenField runat="server" ID="hdnFileUrl" Value='<%#Eval("File_Url") %>' />
                                                                            <asp:Image ID="imgClose" runat="server" ImageUrl="../images/close.png" runat="server"
                                                                                Style="display: none" title="Select New File" />
                                                                            <asp:Image ID="Imageselect" ImageUrl="../images/upload.png" runat="server" Width="20px"
                                                                                Height="20px" title="Select Department Structure File" />
                                                                            <asp:FileUpload ID="fuCandidateDocument" runat="server" Style="display: none" />
                                                                            <asp:Image ID="imgupload" ImageUrl="../images/save.png" runat="server" Width="20px"
                                                                                Height="20px" Style="display: none" title="Upload Selected Department Structure File" />
                                                                            <asp:LinkButton ID="lnkUpload" runat="server" ToolTip="Upload " CommandArgument='<%# Eval("dcode") %>'
                                                                                CommandName="upload" Style="display: none"></asp:LinkButton>
                                                                            <asp:Image ID="imgDownload" runat="server" ImageUrl="../images/download.png" runat="server"
                                                                                title="View Department Structure" Width="22px" Height="22px" Style="display: none" />
                                                                            <asp:LinkButton ID="lnkDownload" runat="server" ToolTip="Download " CommandArgument='<%# Eval("File_Url") %>'
                                                                                CommandName="Download" Style="display: none"></asp:LinkButton>
                                                                        </div>
                                                                    </td>
                                                                    <td valign="middle">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="left" width="97%">
                                                                                    <%# Eval("jdname")%>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <a title="Edit JD" id="aeditjd" runat="server" href="/example/modal-simple/modal.html"
                                                                                        target="_blank">
                                                                                        <img id="imgEdit" src="../images/edit.png">
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="display: none;">
                                                                        <%# Eval("catname")%>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%# Eval("totalcount")%>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%# Eval("filledPos")%>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%--  <a id="aUnfilled" runat="server" target="_blank"></a>--%>
                                                                        <%# Eval("unfilledcount")%>
                                                                        <asp:HiddenField ID="hdnunfilledcount" Value='<%# Eval("unfilledcount")%>' runat="server" />
                                                                        <asp:HiddenField ID="hdnJdK" Value='<%# Eval("JDKeywords")%>' runat="server" />
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <span style="color: #FFFFFF; display: none;">
                                                                            <%# Eval("nr") %></span>
                                                                        <asp:HiddenField runat="server" ID="hdnCatCode" Value='<%# Eval("nr") %>' />
                                                                        <asp:HiddenField runat="server" ID="hdnnewvalue" Value='<%# Eval("nr") %>' />
                                                                        <asp:TextBox runat="server" ID="txtNewreq" Text='<%# Eval("nr") %>' Width="30px"
                                                                            MaxLength="3" ReadOnly="true" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <%-- <asp:ImageButton runat="server" ToolTip="Click here to save record" ID="btnSave" CommandArgument='<%# Eval("jdcode") %>' CommandName="Save" />--%>
                                                                        <asp:LinkButton ID="lnlSave" runat="server" ToolTip="Save" Style="color: white;"
                                                                            CommandArgument='<%# Eval("jdcode") %>' CommandName="Save"> <img id="imgEdit" src="../images/save.png" width="20px" height="20px" /></asp:LinkButton>
                                                                        <%-- <span id="gap" runat="server">&nbsp;|&nbsp;</span>--%>
                                                                        &nbsp;&nbsp;
                                                                        <asp:LinkButton ID="lnkapprove" runat="server" ToolTip="Approve Requisition" CommandArgument='<%# Eval("jdcode") %>'
                                                                            CommandName="approve" OnClientClick="return confirm('Are you sure you want to Approve');"> <img id="imgEdit" src="../images/accept.png" width="20px" height="20px" /></asp:LinkButton>
                                                                        &nbsp;&nbsp;
                                                                        <asp:LinkButton ID="lnkDisapprove" runat="server" ToolTip="Disapprove Requisition"
                                                                            CommandArgument='<%# Eval("jdcode") %>' CommandName="Disapprove" OnClientClick="return confirm('Are you sure you want to Disapprove');"> <img id="img1" src="../images/Disapprove.png" width="20px" height="20px"  /></asp:LinkButton>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <a id="aAxactSearch" runat="server" target="_blank">
                                                                            <img src="../images/favicon.png" height="15px" width="15px" />(<%# Eval("AxactCount")%>)</a>
                                                                        &nbsp; &nbsp;<a id="aBolSearch" runat="server" target="_blank"><img src="../images/logo.gif"
                                                                            height="15px" width="15px" />
                                                                            (<%# Eval("BolCount")%>) </a>
                                                                    </td>
                                                                </tr>
                                                            </AlternatingItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                    <table class="table1" cellpadding="3" cellspacing="1" width="100%" id="Table14" runat="server">
                                                        <tr class="greyHeading">
                                                            <th style="width: 5%" align="center">
                                                            </th>
                                                            <th colspan="2" class="font9" width="42.8%" align="right" height="18">
                                                                TOTAL&nbsp;
                                                            </th>
                                                            <th style="display: none;" data-sort="string" class="font9" width="15%" align="center"
                                                                height="18">
                                                            </th>
                                                            <th class="font9" width="5.3%" align="center" height="18">
                                                                <asp:Label runat="server" ID="lbltc"></asp:Label>
                                                            </th>
                                                            <th class="font9" width="5.1%" align="center" height="18">
                                                                <asp:Label runat="server" ID="lblfc"></asp:Label>
                                                            </th>
                                                            <th class="font9" width="5.1%" align="center" height="18">
                                                                <asp:Label runat="server" ID="lblufc"></asp:Label>
                                                            </th>
                                                            <th class="font9" width="6.2%" align="center" height="18">
                                                                <asp:Label runat="server" ID="lblnrc"></asp:Label>
                                                            </th>
                                                            <th class="font9" width="16.7%" align="center" height="18">
                                                            </th>
                                                            <th class="font9" width="17%" align="center" height="18">
                                                            </th>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="background-color: #ffffff;" id="trbuttons" runat="server">
                                    <td align="center" style="border: none; padding: 10px 20px 50px 0;">
                                        <asp:Button runat="server" ID="btnUpdate" Text="Update Requisition" OnClick="btnUpdate_Click"
                                            OnClientClick="javascript:return Validate();" />
                                        &nbsp;&nbsp;
                                        <asp:Button runat="server" ID="btnApprove" Text="Approve Requisition" OnClick="btnApprove_Click"
                                            OnClientClick="javascript:return Validate();" />
                                        &nbsp;&nbsp;
                                        <asp:Button runat="server" ID="btnDisapprove" Text="Disapprove Requisition" OnClick="btnDisapprove_Click"
                                            OnClientClick="javascript:return Validate();" />
                                    </td>
                                </tr>
                                <tr id="trnorecords" runat="server" style="border: none" align="center">
                                    <td style="border: none">
                                        <b>No records Found</b>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" width="1200" cellspacing="0" cellpadding="0" id="tblNA" style="padding-top: 10px;"
        runat="server">
        <tr>
            <td>
                You are not Authorized to view this page, Please contact the admin.
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
