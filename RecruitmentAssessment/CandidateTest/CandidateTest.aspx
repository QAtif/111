<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CandidateTest.aspx.cs" Inherits="CandidateTest" %>
<%@ Register Assembly="ZNet.Controls" Namespace="ZNet.Controls" TagPrefix="ZNet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

<script  type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.4.min.js"></script>

    <script language="javascript" type="text/javascript">

        // javascript to add to your aspx page
        function ValidateModuleList(source, args) {

            return ValidateList(var1);
        }

        function ValidateList(var1, source, args) {

            alert(var1);
            var chkListModules = document.getElementById(var1);
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    return true;

                }
            }
            return false;
        }



        var Timer;
        var TotalSeconds;


        function CreateTimer(TimerID, Time) {
            //Timer = document.getElementById(TimerID);
            //TotalSeconds = Time;

            //UpdateTimer()
            //window.setTimeout("Tick()", 1000);
        }

        function Tick() {
            //alert(TotalSeconds);
            document.getElementById('MainContent_hdntimeInSec').value = TotalSeconds;

            //'<%Session["TimeCount"] = "' + TotalSeconds + '"; %>';
            //alert('<%=Session["TimeCount"] %>');

            if (TotalSeconds <= 0) {
                //alert("Section Time's up!")
                //alert(document.getElementById('MainContent_Button1'));
                //document.getElementById('MainContent_Button1').click();
                //return;
            }

            //            TotalSeconds -= 1;
            //            UpdateTimer()
            //            window.setTimeout("Tick()", 1000);
        }

        function UpdateTimer() {
            var Seconds = TotalSeconds;

            var Days = Math.floor(Seconds / 86400);
            Seconds -= Days * 86400;

            var Hours = Math.floor(Seconds / 3600);
            Seconds -= Hours * (3600);

            var Minutes = Math.floor(Seconds / 60);
            Seconds -= Minutes * (60);


            var TimeStr = ((Days > 0) ? Days + " days " : "") + LeadingZero(Hours) + ":" + LeadingZero(Minutes) + ":" + LeadingZero(Seconds)


            Timer.innerHTML = TimeStr;
        }


        function LeadingZero(Time) {

            return (Time < 10) ? "0" + Time : +Time;

        }
        /*
        document.onkeydown = function (event) {
        if (window.event) {
        event.preventDefault();
        }
        }
        
        window.onbeforeunload = function (e) {
        e = e || window.event;
            
        // For IE and Firefox prior to version 4
        if (e) {
        e.returnValue = 'Sure?';
        }
            
        // For Safari
        return 'Sure?';
        };
        */


 $(document).ready(function () {
            $('#container').bind("cut copy paste", function (e) {
                e.preventDefault();
            });
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="headbar">
        <h2>
            <span>Candidate Test</span>
        </h2>
    </div>
    
    <asp:HiddenField runat="server" ID="hdntimeInSec" />
    <div id="container" class="contentarea">
        <div align="left">
            <table border="0" cellpadding="10" cellspacing="0">
                <tr class="grey">
                    <td colspan="2">
                        <h2>
                            <strong>Section : </strong>
                            <asp:Label runat="server" ID="lblSectionName"></asp:Label></h2>
                        <asp:HiddenField runat="server" ID="hdSection" />
                        <asp:HiddenField runat="server" ID="hdQuestionGroupCode" />

                    </td>
                </tr>
                <tr runat="server" id="trCaseStudy" style="display: none">
                    <td width="11%">
                        <strong>Case Study :</strong>
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltrCaseStudy"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="10" cellspacing="0">
                <thead>
                    <tr>
                        <th style="width: 5%" align="center">
                            S.No.
                        </th>
                        <th align="left">
                            Question
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptQuestion" runat="server" OnItemDataBound="rptQuestion_ItemDataBound">
                        <ItemTemplate>
                            <p>
                                <tr class="grey">
                                    <td style="width: 5%" align="center">
                                        <strong>
                                            <%#Container.ItemIndex + 1 %></strong>
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Literal runat="server" ID="ltrQuestion" Text='<%# Eval("QuestionName")%>'></asp:Literal></strong>
                                        <asp:HiddenField runat="server" ID="hdnQuestionCode" Value='<%# Eval("QuestionCode")%>'>
                                        </asp:HiddenField>
                                        <asp:HiddenField runat="server" ID="hdnSectionCode" Value='<%# Eval("SectionCode")%>'>
                                        </asp:HiddenField>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Repeater ID="rptOptions" runat="server" OnItemDataBound="rptOptions_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 10%">
                                                    </td>
                                                    <td style="width: 80%">
                                                        <asp:HiddenField runat="server" ID="hdnQuestionTypeCode"></asp:HiddenField>
                                                        <asp:HiddenField runat="server" ID="hdnQuestionCode"></asp:HiddenField>
                                                        <asp:CheckBoxList Visible="false" runat="server" ID="chkAnswer">
                                                        </asp:CheckBoxList>
                                                        <asp:FileUpload ID="fuDocument" Visible="false" runat="server" Width="251px" />
                                                        <ZNet:RequiredFieldValidatorForCheckBoxList ID="RequiredFieldValidatorForCheckBoxList1"
                                                            runat="server" ControlToValidate="chkAnswer" SetFocusOnError="true" ValidationGroup="signUp" NumberOfCheckBoxesToBeChecked="1"
                                                            ForeColor="Red" >Please provide answer</ZNet:RequiredFieldValidatorForCheckBoxList>
                                                        <asp:RadioButtonList Visible="false" runat="server" ID="rdoAnswer">
                                                        </asp:RadioButtonList>
                                                        <asp:TextBox Visible="false" Width="450px" runat="server" ID="txtAnswer"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rqdRequired" Display="Dynamic" ErrorMessage="Please provide answer"
                                                            ControlToValidate="txtAnswer" SetFocusOnError="true" ValidationGroup="signUp" ForeColor="Red">Please provide answer</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="signUp" Text="Submit"
                CssClass="btn-ora nl" OnClick="btnSubmit_Click" />
            <asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
