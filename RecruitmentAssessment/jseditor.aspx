<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtjs.Text = System.IO.File.ReadAllText(Server.MapPath(txtfilepath.Text));
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    
    [System.Web.Services.WebMethod]
    public static string  ReadFile(string path)
    {
        return "";
        //txtjs.Text = System.IO.File.ReadAllText(Server.MapPath(txtfilepath.Text));
    }
    
    [System.Web.Services.WebMethod]
    public static void write(string text, string path)
    {
        System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(path), text);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
    function Write()
    {
        PageMethods.write(document.getElementById('txtjs').value,document.getElementById('txtfilepath').value)
    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sc1" runat="server" EnablePageMethods=true ></asp:ScriptManager>
    
    <div>
        <asp:TextBox ID="txtfilepath" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtjs" runat="server" Height="489px" TextMode="MultiLine" Width="476px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Read" OnClick="Button1_Click" />
        <a onclick="Write()">write </a>
        
        </div>
        
        
    </form>
</body>
</html>