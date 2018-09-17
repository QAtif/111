<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LinksPage.aspx.cs" Inherits="LinksPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

                
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="container" class="contentarea">
    <div align="left">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="10" cellspacing="0">
                        <thead>
                            <tr>
                               
                                <th align="left">
                                    Assessment
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="simple">
                                <td style="text-align: left">
                                <a href="Section.aspx" id="lnkSection">Section</a>    
                                    
                                </td>
                            </tr>
                             <tr class="simple">
                                <td style="text-align: left">
                                <a href="QuestionType.aspx" id="lnkQuestionType">Question Type</a>    
                                    
                                </td>
                            </tr>
                             <tr class="simple">
                                <td style="text-align: left">
                                <a href="Question.aspx" id="A2">Question</a>    
                                    
                                </td>
                            </tr>
                            <tr class="simple">
                                <td style="text-align: left">
                                <a href="CaseStudy.aspx" id="A7">Case Study</a>    
                                    
                                </td>
                            </tr>
                             <tr class="simple">
                                <td style="text-align: left">
                                <a href="Test.aspx" id="A3">Test</a>    
                                    
                                </td>
                            </tr>
                             <tr class="simple">
                                <td style="text-align: left">
                                <a href="/Assessment/CandidateTest/CandidateTest.aspx?tid=5" id="A4">Candidate Test</a>                                        
                                </td>
                            </tr>



                          
                             <thead>
                            <tr>
                               
                                <th align="left">
                                    Scheduling
                                </th>
                            </tr>
                        </thead>
                            <tr class="simple">
                                <td style="text-align: left">
                                <a href="TestTypeMedium.aspx" id="A1">Test Type Medium</a>                                        
                                </td>
                            </tr>
                            <tr class="simple">
                                <td style="text-align: left">
                                <a href="Venue.aspx" id="A5">Venue</a>                                        
                                </td>
                            </tr>
                            <tr class="simple">
                                <td style="text-align: left">
                                <a href="SlotGeneration.aspx" id="A6">Slot Generation</a>                 
                                    
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" runat="server" id="tblMsg">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
