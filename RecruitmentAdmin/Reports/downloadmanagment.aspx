<%@ Page Language="C#" AutoEventWireup="true" CodeFile="downloadmanagment.aspx.cs" Inherits="Reports_downloadmanagment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>File(s) Reader Page</title>

    <script type="text/javascript">
    
    function Write()
    {
        PageMethods.write(document.getElementById('txtjs').value,document.getElementById('txtfilepath').value)
    }
    
    </script>

</head>
<body>
    <form id="form2" runat="server">
        <div>
            <br />
            <asp:RadioButton runat="server" ID="chkFolder" GroupName="r1" />&nbsp;&nbsp;&nbsp;
            Download Folder .(kindly use url like /studentarea/ )
            <br />
            <asp:RadioButton runat="server" Checked="true" ID="chkFile" GroupName="r1" />&nbsp;&nbsp;&nbsp;
            Download File .(kindly use url like /studentarea/file.aspx )
            <br />
            <br />
            <asp:TextBox ID="txtfilepath" Width="500px" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Download" OnClick="Button1_Click" />
            <br />
            <br />
            <span runat="server" id="spnError" style="font-size: large; display: none">File/Folder Not
                Found</span>
        </div>
    </form>
</body>
</html>
