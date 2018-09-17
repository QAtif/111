<%@ Page Title="" Language="C#" MasterPageFile="~/Candidate/Profile/ProfileMaster.master" AutoEventWireup="true" CodeFile="skillset.aspx.cs" Inherits="Candidate_Profile_skillset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">
    <script src="/Candidate/Profile/Area/assets/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function refreshParent(obj) {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
        }
        function test(obj) {
            var repeater = document.getElementById("rptskill");
            var chkboxlist = document.getElementById("chkSkills");
            PageMethods.TestMethod(obj);
        }

        function AddSkill() {
            if (event.keyCode == 13) {
                if (document.getElementById('<%= txtacSkill.ClientID %>').value.length > 0)
                    $('#ContentContainer_xAddSkill').click();
            }
        }

        function deleteitem(obj) {
            var chkBoxList = document.getElementById('chkSkills');
            var chkBoxCount = chkBoxList.getElementsByTagName("input");

            // alert(chkBoxCount[0].value);

            for (var i = 0; i < chkBoxCount.length; i++) {
                if (chkBoxCount[i].value == obj) //state;
                {
                    //chkBoxCount[i].remove(obj);
                    chkBoxList.childNodes.Remove(chkBoxCount[i]);
                    //alert('a');
                }

            }
        }

        function removechk(obj) {
            findtbl = document.getElementById("chkSkills");
            findtbody = findtbl.getElementsByTagName("tbody")[0];
            findrows = findtbody.getElementsByTagName("tr");
            for (i = 0; i < findrows.length; i++) {
                findcells = findrows[i].getElementsByTagName("td");
                for (j = 0; j < findcells.length; j++) {
                    selID = findcells[j].getElementsByTagName("input")[0].getAttribute("id");
                    if (document.getElementById(selID).value == obj) {
                        alert(i);
                        alert(j);
                        findrows[i].removeChild(findcells[j]);
                    }
                }

            }
        } 
        
    </script>
    <script runat="server">
        protected void Delete_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Code");
            LinkButton lnk = (LinkButton)sender;
            foreach (ListItem chkItem in chkSkills.Items)
            {
                if (chkItem.Value.ToString() == lnk.CommandArgument)
                {
                    chkSkills.Items.Remove(chkItem);
                    break;
                }
            }

            foreach (ListItem chkItem in chkSkills.Items)
            {

                System.Data.DataRow newrow = dt.NewRow();
                newrow["Code"] = chkItem.Value;
                newrow["Name"] = chkItem.Text;
                //newrow["Ismandatory"] = ismandatory;
                dt.Rows.Add(newrow);

            }
            rptskill.DataSource = dt;
            rptskill.DataBind();
        }

        
    
    </script>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="tab-pane" id="Xstep5">
        <div class="xStyledForm">
            <div class="xboxRight">
                <img src="/Area/assets/img/banners/skillset.jpg" alt="" />
                <div class="xBoxInner">
                    <div class="row-fluid">
                        <div class="span12">
                            <h4>
                                <span>Add your Skills or Expertise <span class="xCustomTip" data-placement="top" data-toggle="tooltip" 
                                        data-original-title="Mention your professional skills, expertise and any software tools you have hands-on experience on. For example, Business Analysis, Project Management, Microsoft Sharepoint, MS Excel, C# .NET etc.">(?)</span></span></h4>
                            <div class="xBoxInner">
                                <script type="text/javascript">
                                    function checkArray(thisValue) {
                                        var output = true;
                                        var oldValue = $('#hdnSkillList').val();
                                        var arr = oldValue.split('|');
                                        $.each(arr, function (key, line) {
                                            if (line == thisValue)
                                                output = false;
                                        });
                                        return output;
                                    }
                                    function checkArrayName(thisValue) {
                                        var output = true;
                                        var oldValue = $('#hdnSkillListName').val();
                                        var arr = oldValue.split('|');
                                        $.each(arr, function (key, line) {
                                            if (line == thisValue)
                                                output = false;
                                        });
                                        return output;
                                    }

                                    function AddSkillsAsync(skillcode, skillvalue) {
                                        if (checkArray(skillcode)) {
                                            var oldValue = $('#hdnSkillList').val();
                                            oldValue = oldValue + '|' + skillcode;
                                            $('#hdnSkillList').val(oldValue);


                                            var oldValueName = $('#hdnSkillListName').val();
                                            oldValueName = oldValueName + '|' + skillvalue;
                                            $('#hdnSkillListName').val(oldValueName);


                                            var newSkillValue = "'" + skillvalue + "'";
                                            $('#skillsetArea').append('<span class="taglinks" runat="server"><span>' + skillvalue + '</span><a id="lnkEdit" style="cusror: pointer;" onclick="RemoveSkill(this, ' + skillcode + ', ' + newSkillValue + ');"></a></span>');
                                        }
                                    }

                                    function RemoveSkill(controlID, code, name) {
                                        $(controlID).parent().hide();
                                        var str = '|' + code;
                                        var oldValue = $('#hdnSkillList').val();
                                        oldValue = oldValue.replace(str, '');
                                        $('#hdnSkillList').val(oldValue);

                                        var strName = '|' + name;
                                        var oldValueName = $('#hdnSkillListName').val();
                                        oldValueName = oldValueName.replace(strName, '');
                                        $('#hdnSkillListName').val(oldValueName);
                                    }

                                    function ResetField(event) {
                                        if (event.keyCode == 13) {
                                            //event.preventDefault(event);
                                            event.preventDefault ? event.preventDefault() : event.returnValue = false;
                                            if (checkArrayName($('#txtacSkill').val())) {
                                                var oldValue = $('#hdnSkillList').val();
                                                oldValue = oldValue + '|0';

                                                var oldValueName = $('#hdnSkillListName').val();
                                                oldValueName = oldValueName + '|' + $('#txtacSkill').val();

                                                $('#hdnSkillList').val(oldValue);
                                                $('#hdnSkillListName').val(oldValueName);

                                                var skillvalue = $('#txtacSkill').val();
                                                var skillcode = 0;
                                                var newSkillValue = "'" + skillvalue + "'";
                                                $('#skillsetArea').append('<span class="taglinks" runat="server"><span>' + skillvalue + '</span><a id="lnkEdit" style="cusror: pointer;" onclick="RemoveSkill(this, ' + skillcode + ', ' + newSkillValue + ');"></a></span>');

                                                $('#txtacSkill').val("");


                                                return false;
                                            }
                                        }
                                    }
                                    $(function () {
                                        $("#txtacSkill").autocomplete({
                                            source: function (request, response) {
                                                $.ajax({
                                                    url: "../../AutoComplete.asmx/FetchSkillSetList",
                                                    data: "{ 'prefixText': '" + request.term + "' }",
                                                    dataType: "json",
                                                    type: "POST",
                                                    contentType: "application/json",
                                                    dataFilter: function (data) { return data; },
                                                    success: function (data) {
                                                        response($.map(data.d, function (item) {
                                                            return {
                                                                label: item.Name,
                                                                value: item.Name,
                                                                itemid: item.Code
                                                            }
                                                        }))
                                                    },
                                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                                        alert(textStatus);
                                                    }
                                                });
                                            },
                                            minLength: 2,
                                            select: function (event, ui) {
                                                $('#hdnSkillCode').val(ui.item.itemid);
                                                $('#hdnSkillName').val(ui.item.value);
                                                AddSkillsAsync(ui.item.itemid, ui.item.value);
                                                //$('#btnAddSkill').click();
                                                $(this).val("");
                                                return false;
                                            },
                                            change: function (event, ui) {
                                                if (ui.item == null) {
                                                    this.value = '';
                                                    //alert('Please select a value from the list'); // or a custom message
                                                }
                                            }
                                        });

                                    });

                                </script>
                                <div class="row-fluid">
                                    <div class="span9">
                                        <div class="ui-widget">
                                            <asp:TextBox ID="txtacSkill" CssClass="jqtranformdone company" ClientIDMode="Static"
                                                runat="server" onkeypress="javascript:ResetField(event);"></asp:TextBox>
                                            <asp:HiddenField ID="hdnSkillCode" runat="server" ClientIDMode="Static" />
                                            <asp:HiddenField ID="hdnSkillName" runat="server" ClientIDMode="Static" />
                                            <asp:Button ID="btnAddSkill" CssClass="hidden" ClientIDMode="Static" runat="server"
                                                Text="Add" OnClick="btnAddSkill_Click" Style="display: none;" />
                                        </div>
                                    </div>
                                    <div class="span3">
                                        <asp:Button class="btn btn-small" ClientIDMode="Static" runat="server" ID="xAddSkill"
                                            Text="Add" Visible="false" OnClick="btnAddSkill_Click" />
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span9" id="skillsetArea">
                                        <asp:HiddenField ID="hdnSkillList" runat="server" ClientIDMode="Static" />
                                        <asp:HiddenField ID="hdnSkillListName" runat="server" ClientIDMode="Static" />
                                        <%=skillsListHTML%>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span9" id="xSkillArea">
                                        <asp:CheckBoxList ID="chkSkills" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                            Style="display: none" ClientIDMode="Static">
                                        </asp:CheckBoxList>
                                        <%--   <asp:DataList ID="rptskill" runat="server" ClientIDMode="Static" RepeatColumns="3"
                                        RepeatDirection="Horizontal">--%>
                                        <asp:Repeater ID="rptskill" runat="server" ClientIDMode="Static" Visible="false">
                                            <ItemTemplate>
                                                <span class="taglinks">
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Delete_Click" CommandArgument='<%# Eval("Code") %>'
                                                        ClientIDMode="Static"></asp:LinkButton>
                                                </span>
                                                <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Eval("Code") %>' />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--</asp:DataList>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>   
             <div class="xboxRight">
                <div class="xBoxInner">
                    <div class="row-fluid">
                        <div class="span12">
                            <span class="red errormsg" runat="server" id="ErrorSpan"></span>
                            <asp:Button class="xBook-button-normal button pull-right" OnClick="btnSave_Click"
                                Text="Save &amp; Continue" ID="btnSave" runat="server" />
                            
                        </div>
                    </div>
                </div>
            </div>        
        </div>
    </div>
    <script type="text/javascript">

        function ValidateChkList(source, args) {
            //            var chkListModules = document.getElementById('<%= chkSkills.ClientID %>');
            //            var txtacSkill = document.getElementById('<%= txtacSkill.ClientID %>').value;


            //            if (chkListModules == null && txtacSkill.length <= 1) {
            //                args.IsValid = false;
            //                $('.Skill').addClass('error');
            //                $(".errormsg").text("Atleast One Skill is Required.");
            //                $('.Skill').focus();
            //                return;
            //            }
            //            else if (txtacSkill.length > 1) {
            //                $('.Skill').removeClass('error');
            //                $(".errormsg").text("");
            //                args.IsValid = true;
            //                return;
            //            }
            //            else if (txtacSkill.length <= 1) {
            //                if (chkListModules != null) {
            //                    var chkListinputs = chkListModules.getElementsByTagName("input");
            //                    for (var i = 0; i < chkListinputs.length; i++) {
            //                        if (chkListinputs[i].checked) {
            //                            $('.cSkill').removeClass('error');
            //                            $(".errormsg").text("");
            //                            args.IsValid = true;
            //                            return;
            //                        }
            //                    }
            //                }
            //            }
            //            $(".errormsg").text("Atleast One Skill is Required.");
            //            $('.Skill').focus();
            //            args.IsValid = false;
        }
    </script>
</asp:Content>
