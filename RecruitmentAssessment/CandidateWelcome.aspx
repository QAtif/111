<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CandidateWelcome.aspx.cs" Inherits="CandidateWelcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <title>B O L</title>
    <div class="head">
        <h2>
            <span>Thank You
                <asp:Label runat="server" ID="lblName"></asp:Label>
                , </span>
        </h2>
    </div>
    <div id="container" class="contentarea">
        <div align="left" style="font-size: 14px;" >
		<br />
			<br />
            You may now proceed to the Evaluation Test for
            <asp:Label runat="server" ID="lblCategoryName"></asp:Label>. 
			
            <!-- Total duration for the test is -->
            <asp:Label runat="server" ID="lblHours" style="display:none"></asp:Label>
           <!-- hour(s). Your test details are given below in phase wise.-->
            <br />
			<br />
            You are not allowed to take help from any website or other sources from internet, you can only use the system calculator for calculation purpose, if any. Please
            note that all the unanswered questions will be scored as incorrect.
            <br />
            <br />
            <strong runat="server" id="lblPhase1">Phase I</strong>
    <div runat="server" id="lblGeneralIQ" style="margin-top: 2.5%;">
            <strong >General IQ</strong>
    </div>
            <div>
                <table runat="server" id="tblIQ" border="0" cellpadding="10" cellspacing="0" style="margin-top:2.5% !important;margin-bottom:2.5% !important">
                    <tr>
                        <td style="width:10%" align="center">
                            1.
                        </td>
                        <td>
                            Sequence and Series
                        </td>
                    </tr>
                    <tr>
                        <td style="width:10%"  align="center">
                            2.
                        </td>
                        <td>
                            Picture Pattern
                        </td>
                    </tr>
                    <tr>
                        <td style="width:10%"  align="center">
                            3.
                        </td>
                        <td>
                            Word Problem
                        </td>
                    </tr>                    
                </table>
            </div>
        
            <strong runat="server" id="lblPhase2">Phase <span id="testphase" runat="server"></span></strong>
        <div runat="server" id="lblGeneralTest">
            <table  border="0" cellpadding="10" cellspacing="0" style="margin-top:2.5% !important;margin-bottom:2.5% !important">
                <tbody>
                    <asp:Repeater ID="rptSection" runat="server">
                        <ItemTemplate>
                            <tr>
                               <td style="width:10%"  align="center">
                                    <%# int.Parse(DataBinder.Eval(Container, "ItemIndex", "")) + 1%>
                                </td>
                                <td style="text-align: left">
                                    <%# Eval("QuestionGroupName")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
         </div>
            <br />
            <br />
            By clicking on ‘Proceed to Test’ button, you will be directed to the Phase-I of
            the evaluation test.
            <br />
            <br />
            After completing the test kindly save your document in your folder on desktop with
            your Login ID, by using 'save as' option.
            <br />
            <br />
            Best of Luck!
        </div>

        <div class="contentarea">
        <asp:Button ID="btnSubmit" runat="server" Text="Proceed to Test" 
                CssClass="btn-ora nl" onclick="btnSubmit_Click"  />
        </div>
    </div>
</asp:Content>
