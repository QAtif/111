<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BrowseResume.aspx.cs" Inherits="Candidate_BrowseResume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Browse Resume</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div id="container" class="contentarea">
        <table border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td colspan="2"> 
                    Click here to download a sample form speciman. Fill it according to the fields provided in the document.
                </td>
               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="lbtnImage" runat="server" Text="Download Form" 
                        onclick="lbtnImage_Click" style="font-weight: 700"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Browse the filled form and then upload it on Axact Careers.
                </td>
               
            </tr>
            <tr>
                 <td colspan="2">
                    <asp:FileUpload ID="fuKeyword" runat="server"  />
                    <br />
                    &nbsp; &nbsp; <span>eg. xlsx, xls</span>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" 
                        onclick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>