<%@ Page Language="C#" AutoEventWireup="true" CodeFile="highchart.aspx.cs" Inherits="A2_DashBoard_highchart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="../assets/js/jquery-1.8.3.min.js" type="text/javascript"></script>
        <script src="../assets/js/jquery-ui.js" type="text/javascript"></script>
        <script src="../assets/js/hignchart.js" type="text/javascript"></script>
       <%-- <script src="../assets/js/exporting.js" type="text/javascript"></script>--%>
        
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto">
        </div>
    </div>
    </form>
    <script type="text/javascript">

        var pointsArray = new Array();   
        $(function () {
            var param = '1';

            $.ajax({ type: "POST",
                url: "highchart.aspx/UpdateCandidatebyPro",
                data: JSON.stringify({ items: param }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (Data) {
                    //alert(Data.d);
                    //pointsArray.push({                    
                    //data:Data.d});
                    console.log(Data);
                    createHihgCHart(Data.d[0], Data.d[1]);
                },
                error: function (msg) {
                    alert('error');
                }
            });
        });



        function createHihgCHart(ResignCandidate, HiredCandidate) {
            //alert(obj);


            $('#container').highcharts({
                title: {
                    text: 'Month Wise Candidate Summary',
                    x: -20 //center
                },
                subtitle: {
                    text: 'Total hired and resign candidates    ',
                    x: -20
                },
                xAxis: {
                    categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                },
                yAxis: {
                    title: {
                        text: 'Total Candidates'
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                },
                tooltip: {
                    valueSuffix: ' Candidates'
                },
                legend:
                {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0
                },

                series: [
                {
                    name: 'Hired',
                    data: ResignCandidate
                }
                ,
                {
                    name: 'Resign',
                    data: HiredCandidate
                }]
            });

        }
    </script>
</body>
</html>
