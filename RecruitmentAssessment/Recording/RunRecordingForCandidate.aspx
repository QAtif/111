<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RunRecordingForCandidate.aspx.cs" Inherits="RunRecordingForCandidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Recording For Candidate</title>
    <style type="text/css">
        body
        {
            background-color: #fff;
            padding: 0 20px;
            color: #000;
            font: 13px/18px Arial, sans-serif;
        }
        a
        {
            color: #360;
        }
        h3
        {
            padding-top: 20px;
        }
        ol
        {
            margin: 5px 0 15px 16px;
            padding: 0;
            list-style-type: square;
        }
    </style>

    <script type="text/javascript">
        function CallRedirecter() {
            window.close();
        }

        function showPlayer() {
            //         alert('asda');
            //            document.getElementById('divPlayer').style['display'] = '';
            //            document.getElementById('btnContinue').style['display'] = 'none';
            //            document.getElementById('lblMsg').innerText = '';
            //        
            return true;
        }
    </script>

</head>
<body topmargin="0" leftmargin="0">
    <table background="bg.jpg" height="800px" width="100%">
        <tr>
            <td align="center">
                <form runat="server" id="form1">
                <table>
                    <tr>
                        <td align="center">
                        </td>
                        <td align="right">
                            <a href="javascript:CallRedirecter();">Close</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Maroon" Font-Bold="true"
                                Font-Size="Medium"></asp:Label>
                            <asp:Button ID="btnContinue" runat="server" Text="Start" OnClientClick="return showPlayer();"
                                OnClick="btnStart_Click" />
                            <div id="divPlayer" style="display: none;" runat="server">
                                <div id="mediaplayer">
                                    Loading the Player...</div>

                                <script type="text/javascript" src="jwplayer.js"></script>

                                <script type="text/javascript">
                                    jwplayer("mediaplayer").setup({
                                        flashplayer: "player.swf",
                                        controlbar: "none",
                                        file: "<%=Path%>",
                                        width: 500,
                                        height: 500,
                                        image: "../images/axact-login-screen.gif",
                                        autoplay: true
                                    });
                                </script>

                            </div>
                        </td>
                    </tr>
                </table>
                </form>
            </td>
        </tr>
    </table>
</body>
</html>