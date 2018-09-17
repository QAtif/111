<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="UploadInitialPic.aspx.cs" Inherits="UploadInitialPic" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function refreshParent() 
        {
            //window.parent.location.href = "FoodType.aspx";
            window.parent.location.href = window.parent.location.href;
        }
       
        

    </script>
    <div class="head">
        <h2>
            Browse Picture</h2>
    </div>
    <div id="container" class="contentarea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="specialtab">
            <tbody>
              
                 <tr id="trBrowseFile" runat="server" >
                    <td style="width: 200px">
                        Browse File :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fuDocument" runat="server" Width="251px" />
                        <a id="lnkView" href="" runat="server"></a>
                    </td>
                </tr>
            </tbody>
        </table>

        <div align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-ora nl" OnClick="btnSubmit_Click" />

            
        </div>

      
        
    </div>
    
</asp:Content>
