<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmittedPerInfoList2.aspx.cs"
    Inherits="Existing_SubmittedPerInfoList2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>* Axact Admin </title>
    <link href="StyleSheet/css_ie4_ns.css" type="text/css" rel="stylesheet" />
    <script src="calender_files/calendar.js" type="text/javascript"></script>
    <!-- language for the calendar -->
    <script src="calender_files/calendar-en.js" type="text/javascript"></script>
    <!-- the following script defines the Calendar.setup helper function, which makes
       adding a calendar a matter of 1 or 2 lines of code. -->
    <script src="calender_files/calendar-setup.js" type="text/javascript"></script>
    <link title="win2k-cold-1" media="all" href="calender_files/calendar-win2k-cold-1.css"
        type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../Include/stylesheet.css" />
    <script language="javascript" src="../../include/validation.js"> </script>
    <script type="text/javascript">
        function showSkill() {            
            var skillCombo = event.srcElement;
            var visible;
            var n;
            if (skillCombo.value == 61)
                visible = "inline";
            else
                visible = "none";
            skills = document.all("skill");
            n = skills.length;
            for (i = 0; i < n; i++)
                skills(i).style.display = visible;
        }

        function showhideHearaboutLayer() {

            var text = document.getElementById("Layerhearabout");
            var index = document.getElementById("hearabout").selectedIndex;
            if (index == '6') {
                //hideLayer('Layerhearabout');
                showhideLayer('Layerhearabout', 'visible');
            }
            else {
                showhideLayer('Layerhearabout', 'hidden');
            }
        }

        function showhideLayer(layer_ref, state) {
            if (state == 'visible') {
                eval("document.getElementById(\"" + layer_ref + "\").style.display = ''");
                eval("document.getElementById(\"" + layer_ref + "\").style.visibility = '" + state + "'");
            }
            else {
                eval("document.getElementById(\"" + layer_ref + "\").style.display = 'none'");
                eval("document.getElementById(\"" + layer_ref + "\").style.visibility = 'hidden'");

            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" width="655" height="438" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="2" width="100%" height="75">
                Header
            </td>
        </tr>
        <tr>
            <td width="15%" height="500">
                Left Bar
            </td>
            <td width="85%" height="100%" valign="top">
                <asp:HiddenField ID="UserCode" runat="server" />
                <asp:HiddenField ID="CategoryCode" runat="server" />
                <table border="0" width="98%" align="center" cellspacing="0" cellpadding="0" id="Table2">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table3">
                                <tr>
                                    <td width="100%" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%" class="pgHeading">
                                        Candidate Submitted Per-Info
                                    </td>
                                    <td width="50%" align="right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="2">
                                        <hr>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="2" style="padding-left: 15px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table6">
                                            <tr>
                                                <td width="15%" class="font9">
                                                    Category
                                                </td>
                                                <td width="35%">
                                                    <asp:DropDownList runat="server" ID="category" CssClass="textbox" Style="width: 250px"
                                                        onchange='showSkill();'>
                                                        <asp:ListItem Value="" Text="----------- Select Category -----------"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="15%" class="font9" rowspan="2">
                                                    Qualification
                                                </td>
                                                <td width="35%" rowspan="2">
                                                    <asp:ListBox runat="server" ID="Qualification" CssClass="textbox" Style="width: 200"
                                                        SelectionMode="Multiple">
                                                        <asp:ListItem Value="-1">Show All</asp:ListItem>
                                                    </asp:ListBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" class="font9">
                                                    Status
                                                </td>
                                                <td width="35%">
                                                    <asp:DropDownList runat="server" ID="StatusCode" CssClass="textbox" Style="width: 200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" class="font9">
                                                    Gender
                                                </td>
                                                <td width="35%">
                                                    <asp:DropDownList runat="server" ID="Gender" CssClass="textbox" Style="width: 200">
                                                        <asp:ListItem Value="-1" Text="---------- Select Gender ----------"></asp:ListItem>
                                                        <asp:ListItem Value="M" Text="Male"></asp:ListItem>
                                                        <asp:ListItem Value="F" Text="Female"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="15%" class="font9" rowspan="3">
                                                    Institute
                                                </td>
                                                <td width="35%" rowspan="3">
                                                    <asp:ListBox runat="server" ID="Institute" CssClass="textbox" Style="width: 200"
                                                        SelectionMode="Multiple">
                                                        <asp:ListItem Value="-1">Show All</asp:ListItem>
                                                    </asp:ListBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" class="font9">
                                                    Age greater than
                                                </td>
                                                <td width="35%" class="font9">
                                                    <asp:DropDownList runat="server" ID="AgeG" CssClass="textbox" Style="width: 200">
                                                        <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                                        <asp:ListItem Value="21" Text="21">21</asp:ListItem>
                                                        <asp:ListItem Value="22" Text="22">22</asp:ListItem>
                                                        <asp:ListItem Value="23" Text="23">23</asp:ListItem>
                                                        <asp:ListItem Value="24" Text="24">24</asp:ListItem>
                                                        <asp:ListItem Value="25" Text="25">25</asp:ListItem>
                                                        <asp:ListItem Value="26" Text="26">26</asp:ListItem>
                                                        <asp:ListItem Value="27" Text="27">27</asp:ListItem>
                                                        <asp:ListItem Value="28" Text="28">28</asp:ListItem>
                                                        <asp:ListItem Value="29" Text="29">29</asp:ListItem>
                                                        <asp:ListItem Value="30" Text="30">30</asp:ListItem>
                                                        <asp:ListItem Value="31" Text="31">31</asp:ListItem>
                                                        <asp:ListItem Value="32" Text="32">32</asp:ListItem>
                                                        <asp:ListItem Value="33" Text="33">33</asp:ListItem>
                                                        <asp:ListItem Value="34" Text="34">34</asp:ListItem>
                                                        <asp:ListItem Value="35" Text="35">35</asp:ListItem>
                                                        <asp:ListItem Value="36" Text="36">36</asp:ListItem>
                                                        <asp:ListItem Value="37" Text="37">37</asp:ListItem>
                                                        <asp:ListItem Value="38" Text="38">38</asp:ListItem>
                                                        <asp:ListItem Value="39" Text="39">39</asp:ListItem>
                                                        <asp:ListItem Value="40" Text="40">40</asp:ListItem>
                                                    </asp:DropDownList>
                                                    Age Less than
                                                    <asp:DropDownList runat="server" ID="AgeL" CssClass="textbox" Style="width: 200">
                                                        <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                                        <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                                        <asp:ListItem Value="21" Text="21">21</asp:ListItem>
                                                        <asp:ListItem Value="22" Text="22">22</asp:ListItem>
                                                        <asp:ListItem Value="23" Text="23">23</asp:ListItem>
                                                        <asp:ListItem Value="24" Text="24">24</asp:ListItem>
                                                        <asp:ListItem Value="25" Text="25">25</asp:ListItem>
                                                        <asp:ListItem Value="26" Text="26">26</asp:ListItem>
                                                        <asp:ListItem Value="27" Text="27">27</asp:ListItem>
                                                        <asp:ListItem Value="28" Text="28">28</asp:ListItem>
                                                        <asp:ListItem Value="29" Text="29">29</asp:ListItem>
                                                        <asp:ListItem Value="30" Text="30">30</asp:ListItem>
                                                        <asp:ListItem Value="31" Text="31">31</asp:ListItem>
                                                        <asp:ListItem Value="32" Text="32">32</asp:ListItem>
                                                        <asp:ListItem Value="33" Text="33">33</asp:ListItem>
                                                        <asp:ListItem Value="34" Text="34">34</asp:ListItem>
                                                        <asp:ListItem Value="35" Text="35">35</asp:ListItem>
                                                        <asp:ListItem Value="36" Text="36">36</asp:ListItem>
                                                        <asp:ListItem Value="37" Text="37">37</asp:ListItem>
                                                        <asp:ListItem Value="38" Text="38">38</asp:ListItem>
                                                        <asp:ListItem Value="39" Text="39">39</asp:ListItem>
                                                        <asp:ListItem Value="40" Text="40">40</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="15%" align="right">
                                                    <asp:CheckBox runat="server" ID="test" Visible="false" Checked="true" />
                                                </td>
                                                <td width="35%" class="font9">
                                                    <%=t_only%>
                                                </td>
                                                <tr>
                                                    <td width="15%" class="font9">
                                                        Least related exp.
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="Experience" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Experience -----"></asp:ListItem>
                                                            <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                                            <asp:ListItem Value="0" Text="0">less than 1 yr</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="1">1 yr</asp:ListItem>
                                                            <asp:ListItem Value="2" Text="2">2 yrs</asp:ListItem>
                                                            <asp:ListItem Value="3" Text="3">3 yrs</asp:ListItem>
                                                            <asp:ListItem Value="4" Text="4">4 yrs</asp:ListItem>
                                                            <asp:ListItem Value="5" Text="5">5 yrs</asp:ListItem>
                                                            <asp:ListItem Value="6" Text="6">More than 5 yrs</asp:ListItem>
                                                            <asp:ListItem Value="7" Text="7">More than 10 yrs</asp:ListItem>
                                                            <asp:ListItem Value="8" Text="8">More than 15 yrs</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="skill" height="20" style="display: inline">
                                                    <td colspan="4" bgcolor='BADBDE'>
                                                        <b>Extended filtering properties for Office Assistant</b>
                                                    </td>
                                                </tr>
                                                <tr id="skill" style="display: inline">
                                                    <td width="15%" class="font9">
                                                        MS Word
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="pro22" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Proficiency -----"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Beginner">Beginner</asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Intermediate">Intermediate</asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Expert">Expert</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" class="font9">
                                                        Experience atleast
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="exp22" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Experience -----"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="4">3+ yrs</asp:ListItem>
                                                            <asp:ListItem Value="3" Text="3">3 yrs</asp:ListItem>
                                                            <asp:ListItem Value="2" Text="2">2 yrs</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="1">1 yr</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="skill" style="display: inline">
                                                    <td width="15%" class="font9">
                                                        MS Excel
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="pro23" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Proficiency -----"></asp:ListItem>
                                                            <asp:ListItem Value="1">Beginner</asp:ListItem>
                                                            <asp:ListItem Value="2">Intermediate</asp:ListItem>
                                                            <asp:ListItem Value="3">Expert</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" class="font9">
                                                        Experience atleast
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="exp23" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Experience -----"></asp:ListItem>
                                                            <asp:ListItem Value="4">3+ yrs</asp:ListItem>
                                                            <asp:ListItem Value="3">3 yrs</asp:ListItem>
                                                            <asp:ListItem Value="2">2 yrs</asp:ListItem>
                                                            <asp:ListItem Value="1">1 yr</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="skill" style="display: inline">
                                                    <td width="15%" class="font9">
                                                        MS Power Point
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="pro24" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Proficiency -----"></asp:ListItem>
                                                            <asp:ListItem Value="1">Beginner</asp:ListItem>
                                                            <asp:ListItem Value="2">Intermediate</asp:ListItem>
                                                            <asp:ListItem Value="3">Expert</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" class="font9">
                                                        Experience atleast
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="exp24" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Experience -----"></asp:ListItem>
                                                            <asp:ListItem Value="4">3+ yrs</asp:ListItem>
                                                            <asp:ListItem Value="3">3 yrs</asp:ListItem>
                                                            <asp:ListItem Value="2">2 yrs</asp:ListItem>
                                                            <asp:ListItem Value="1">1 yr</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="skill" style="display: inline">
                                                    <td width="15%" class="font9">
                                                        MS Visio
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="pro25" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1" Text="---- Select Proficiency -----"></asp:ListItem>
                                                            <asp:ListItem Value="1">Beginner</asp:ListItem>
                                                            <asp:ListItem Value="2">Intermediate</asp:ListItem>
                                                            <asp:ListItem Value="3">Expert</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" class="font9">
                                                        Experience atleast
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="exp25" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="4">3+ yrs</asp:ListItem>
                                                            <asp:ListItem Value="3">3 yrs</asp:ListItem>
                                                            <asp:ListItem Value="2">2 yrs</asp:ListItem>
                                                            <asp:ListItem Value="1">1 yr</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" class="font9">
                                                        Currently Studing
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="cboCurrentlyStuding" runat="server">
                                                            <asp:ListItem Value="null">All</asp:ListItem>
                                                            <asp:ListItem Value="Y">Y</asp:ListItem>
                                                            <asp:ListItem Value="N">N</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" class="font9">
                                                        Foreign Qualification
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="cboForeignQualification" runat="server">
                                                            <asp:ListItem Value="null">All</asp:ListItem>
                                                            <asp:ListItem Value="Y">Y</asp:ListItem>
                                                            <asp:ListItem Value="N">N</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" class="font9">
                                                        Date From
                                                    </td>
                                                    <td width="35%">
                                                        <asp:TextBox ID="txtdtFrom" runat="server" CssClass="textbox" Style="width: 70"></asp:TextBox>
                                                        <img id="topi1" title="Date selector" style="cursor: pointer" height="21" src="calender_files/calendar.gif"
                                                            align="absMiddle">
                                                    </td>
                                                    <script type="text/javascript">
                                                        Calendar.setup({
                                                            inputField: "txtdtFrom",      // id of the input field
                                                            ifFormat: "m/d/y",     // format of the input field
                                                            button: "topi1",   // trigger for the calendar (button ID)
                                                            singleClick: true            // double-click mode
                                                        });
                                                    </script>
                                                    <td width="15%" class="font9">
                                                        Preference 1
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="Priority1" CssClass="textbox" Style="width: 200">
                                                            <asp:ListItem Value="-1">---- Select Location ----- </asp:ListItem>
                                                            <asp:ListItem Value="Karachi">Karachi</asp:ListItem>
                                                            <asp:ListItem Value="Lahore">Lahore</asp:ListItem>
                                                            <asp:ListItem Value="Islamabad">Islamabad</asp:ListItem>
                                                            <asp:ListItem Value="Dubai">Dubai</asp:ListItem>
                                                            <asp:ListItem Value="US">US</asp:ListItem>
                                                            <asp:ListItem Value="Karachi – Home based">Karachi – Home based</asp:ListItem>
                                                            <asp:ListItem Value="Off station – Home based">Off station – Home based</asp:ListItem>
                                                            <asp:ListItem Value="Others">
                                                        Others</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" class="font9">
                                                        Date To
                                                    </td>
                                                    <td width="35%">
                                                        <asp:TextBox ID="txtdtTo" runat="server" CssClass="textbox" Style="width: 70"></asp:TextBox>
                                                        <img id="topi2" title="Date selector" style="cursor: pointer" height="21" src="calender_files/calendar.gif"
                                                            align="absMiddle">
                                                    </td>
                                                    <script type="text/javascript">
                                                        Calendar.setup({
                                                            inputField: "txtdtTo",      // id of the input field
                                                            ifFormat: "m/d/y",     // format of the input field
                                                            button: "topi2",   // trigger for the calendar (button ID)
                                                            singleClick: true            // double-click mode
                                                        });
                                                    </script>
                                                    <td width="15%" class="font9">
                                                        Preference 2
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="Priority2" CssClass="textbox" Style="width: 150">
                                                            <asp:ListItem Value="-1">---- Select Location ----- </asp:ListItem>
                                                            <asp:ListItem Value="Karachi">Karachi</asp:ListItem>
                                                            <asp:ListItem Value="Lahore">Lahore</asp:ListItem>
                                                            <asp:ListItem Value="Islamabad">Islamabad</asp:ListItem>
                                                            <asp:ListItem Value="Dubai">Dubai</asp:ListItem>
                                                            <asp:ListItem Value="US">US</asp:ListItem>
                                                            <asp:ListItem Value="Karachi – Home based">Karachi – Home based</asp:ListItem>
                                                            <asp:ListItem Value="Off station – Home based">Off station – Home based</asp:ListItem>
                                                            <asp:ListItem Value="Others">
                                                        Others</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" class="font9">
                                                        Referred By
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="ReferredBy" CssClass="textbox" Style="width: 150">
                                                            <asp:ListItem Value="R">Referred</asp:ListItem>
                                                            <asp:ListItem Value="N">Not Referred</asp:ListItem>
                                                            <asp:ListItem Value="B" Selected="True">Both</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="15%" class="font9">
                                                        Certification
                                                    </td>
                                                    <td width="35%" class="font9">
                                                        <asp:TextBox ID="certification" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="15%" class="font9">
                                                        Hear about
                                                    </td>
                                                    <td width="35%">
                                                        <asp:DropDownList runat="server" ID="hearabout" CssClass="textbox" onchange="showhideHearaboutLayer();">
                                                            <asp:ListItem Value="0">--All--</asp:ListItem>
                                                            <asp:ListItem Value="Newspaper">Newspaper</asp:ListItem>
                                                            <asp:ListItem Value="Axacts website">Axacts website</asp:ListItem>
                                                            <asp:ListItem Value="Referral">Referral</asp:ListItem>
                                                            <asp:ListItem Value="Campus advertisement">Campus advertisement</asp:ListItem>
                                                            <asp:ListItem Value="Axact Tour/Universitys placement office">Axact Tour/Universitys placement office</asp:ListItem>
                                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="font9">
                                                        Majors
                                                    </td>
                                                    <td width="35%" rowspan="2">
                                                        <asp:ListBox ID="Majors" runat="server">
                                                            <asp:ListItem Value="-1">Select All</asp:ListItem>
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Layerhearabout">
                                                    <td align="right" valign="top" class="font9">
                                                        Please mention:&nbsp;
                                                    </td>
                                                    <td>
                                                        <strong>
                                                            <%--    <%if isOtherhear = 1  >
                                                            <input name="hearaboutother" class="textbox" style="width: 204px" value="<%=txthearabout %>"
                                                        maxlength="100">
                                                        <%else %>
                                                        <input name="hearaboutother" class="textbox" style="width: 204px" value="" maxlength="100">
                                                        <%end if%>--%>
                                                            <asp:TextBox ID="hearaboutother" runat="server" Style="width: 204px" value="" MaxLength="100"></asp:TextBox>
                                                        </strong>
                                                    </td>
                                                </tr>
                                                <script>
                                                    showhideHearaboutLayer();</script>
                                                <tr height="15">
                                                    <td colspan="4" class="font11">
                                                        <br>
                                                        <b>&nbsp;&nbsp;Education Filter:</b>
                                                    </td>
                                                </tr>
                                                <tr height="15">
                                                    <td colspan="4" class="font9">
                                                        <table width="100%" border="1" cellpadding="0">
                                                            <tr bgcolor="#CCCCCC">
                                                                <td align="center" class="font9">
                                                                    <strong>Matric/O-Level</strong>
                                                                </td>
                                                                <td align="center" class="font9">
                                                                    <strong>Inter/A-Level</strong>
                                                                </td>
                                                                <td align="center" class="font9">
                                                                    <strong>Graduate</strong>
                                                                </td>
                                                                <td align="center" class="font9">
                                                                    <strong>Master</strong>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="2">
                                                                        <tr>
                                                                            <td align="center" class="font9">
                                                                                <strong>%</strong>
                                                                            </td>
                                                                            <td align="center" class="font9">
                                                                                <strong>A's</strong>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList runat="server" ID="matricPerc" CssClass="textbox" onchange="showhideHearaboutLayer();">
                                                                                    <asp:ListItem Value="101">Select</asp:ListItem>
                                                                                    <asp:ListItem Value="90">90+</asp:ListItem>
                                                                                    <asp:ListItem Value="80">80+</asp:ListItem>
                                                                                    <asp:ListItem Value="70">70+</asp:ListItem>
                                                                                    <asp:ListItem Value="60">60+</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50+</asp:ListItem>
                                                                                    <asp:ListItem Value="49">Below 50</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="OLevelA" runat="server" CssClass="textbox">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0">
                                                                        <tr>
                                                                            <td align="center" class="font9">
                                                                                <strong>%</strong>
                                                                            </td>
                                                                            <td align="center" class="font9">
                                                                                <strong>A's</strong>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList runat="server" ID="interPerc" CssClass="textbox">
                                                                                    <asp:ListItem Value="101">Select</asp:ListItem>                                                                                    
                                                                                    <asp:ListItem Value="90">90+</asp:ListItem>
                                                                                    <asp:ListItem Value="80">80+</asp:ListItem>
                                                                                    <asp:ListItem Value="70">70+</asp:ListItem>
                                                                                    <asp:ListItem Value="60">60+</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50+</asp:ListItem>
                                                                                    <asp:ListItem Value="49">Below 50</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ALevelA" runat="server" CssClass="textbox">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="0">
                                                            <tr>
                                                                <td align="center" class="font9">
                                                                    <strong>%</strong>
                                                                </td>
                                                                <td align="center" class="font9">
                                                                    <strong>GPA</strong>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList runat="server" ID="graduationPerc" CssClass="textbox">
                                                                        <asp:ListItem Value="101">Select</asp:ListItem>
                                                                        <asp:ListItem Value="90">90+</asp:ListItem>
                                                                        <asp:ListItem Value="80">80+</asp:ListItem>
                                                                        <asp:ListItem Value="70">70+</asp:ListItem>
                                                                        <asp:ListItem Value="60">60+</asp:ListItem>
                                                                        <asp:ListItem Value="50">50+</asp:ListItem>
                                                                        <asp:ListItem Value="49">Below 50</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList runat="server" ID="graduationGPA" CssClass="textbox">
                                                                        <asp:ListItem Value="101">Select</asp:ListItem>
                                                                        <asp:ListItem Value="5">Select</asp:ListItem>
                                                                        <asp:ListItem Value="4">4.0</asp:ListItem>
                                                                        <asp:ListItem Value="3.5">3.5+</asp:ListItem>
                                                                        <asp:ListItem Value="3">3.0+</asp:ListItem>
                                                                        <asp:ListItem Value="2.5">2.5+</asp:ListItem>
                                                                        <asp:ListItem Value="2">less than 2.5</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="0">
                                                            <tr>
                                                                <td align="center" class="font9">
                                                                    <strong>%</strong>
                                                                </td>
                                                                <td align="center" class="font9">
                                                                    <strong>GPA</strong>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList runat="server" ID="masterPerc" CssClass="textbox">
                                                                        <asp:ListItem Value="101">Select</asp:ListItem>
                                                                        <asp:ListItem Value="90">90+</asp:ListItem>
                                                                        <asp:ListItem Value="80">80+</asp:ListItem>
                                                                        <asp:ListItem Value="70">70+</asp:ListItem>
                                                                        <asp:ListItem Value="60">60+</asp:ListItem>
                                                                        <asp:ListItem Value="50">50+</asp:ListItem>
                                                                        <asp:ListItem Value="49">Below 50</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList runat="server" ID="masterGPA" CssClass="textbox">
                                                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                                                        <asp:ListItem Value="5">Select</asp:ListItem>
                                                                        <asp:ListItem Value="4">4.0</asp:ListItem>
                                                                        <asp:ListItem Value="3.5">3.5+</asp:ListItem>
                                                                        <asp:ListItem Value="3">3.0+</asp:ListItem>
                                                                        <asp:ListItem Value="2.5">2.5+</asp:ListItem>
                                                                        <asp:ListItem Value="2">
                                                                    less than 2.5</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="4" align="right">
                                        <asp:Button ID="submit1" runat="server" CssClass="textbox" Text="Search" 
                                            Style="width: 100;" onclick="submit1_Click" />
                                    </td>
                                </tr>
                                <input type="hidden" name="SgCodeArr" value="" id="Hidden1">
                                <asp:HiddenField ID="jPost" runat="server" />
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px">
                <br>
            </td>
        </tr>
        <tr>
            <td width="100%" style="padding-left: 15px">
                <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound">
                    <HeaderTemplate>
                        <table border="1" cellpadding="0" cellspacing="0" width="100%" id="Table4">
                            <tr bgcolor="#c6c3c6">
                                <td class="font9" width="4%" align="center" bordercolorlight="#000000" bordercolordark="#ffffff"
                                    bgcolor="#C0C0C0" height="18">
                                    <b>SNo</b>
                                </td>
                                <td class="font9" width="8%" align="center" bordercolorlight="#000000" bordercolordark="#ffffff"
                                    bgcolor="#C0C0C0" height="18">
                                    <b>Ref No</b>
                                </td>
                                <td class="font9" width="32%" align="center" bordercolorlight="#000000" bordercolordark="#ffffff"
                                    bgcolor="#C0C0C0" height="18">
                                    <b>Full Name</b>
                                </td>
                                <td class="font9" width="32%" align="center" bordercolorlight="#000000" bordercolordark="#ffffff"
                                    bgcolor="#C0C0C0" height="18">
                                    <b>Email/Phone</b>
                                </td>
                                <td class="font9" width="14%" align="center" bordercolorlight="#000000" bordercolordark="#ffffff"
                                    bgcolor="#C0C0C0" height="18">
                                    <b>Apply Date</b>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr height="30">
                            <td class="font9" width="4%" align="center">
                                <asp:Label ID="lblSNo" runat="server"></asp:Label>
                            </td>
                            <td class="font9" width="8%" align="center">
                                <a class="esl1" href="SubmittedPerInfoDetail.asp?RefNo=<%# Eval("CAND_CAT_CODE")%>&cand_code=<%# Eval("CAND_CODE")%>">
                                    <%# Eval("CAND_CAT_CODE")%>
                                </a>
                            </td>
                            <td class="font9" width="32%">
                                <%# Eval("FULL_NAME")%>
                                <%-- <%=GetPositionHolder(cand_code)%><br>--%>
                                <%# Eval("INSTITUTE")%>
                            </td>
                            <td class="font9" width="32%">
                                <%# Eval("EMAIL")%>
                                <br>
                                Phone:
                                <%# Eval("PHONE")%>
                                <asp:Label ID="lblCell" runat="server">
                                </asp:Label>
                            </td>
                            <td class="font9" width="14%" align="center">
                                <%# Eval("Applied_Date")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="recordColor" height="30">
                           <td class="font9" width="4%" align="center">
                                <asp:Label ID="lblSNo" runat="server"></asp:Label>
                            </td>
                            <td class="font9" width="8%" align="center">
                                <a class="esl1" href="SubmittedPerInfoDetail.asp?RefNo=<%# Eval("CAND_CAT_CODE")%>&cand_code=<%# Eval("CAND_CODE")%>">
                                    <%# Eval("CAND_CAT_CODE")%>
                                </a>
                            </td>
                            <td class="font9" width="32%">
                                <%# Eval("FULL_NAME")%>
                                <%-- <%=GetPositionHolder(cand_code)%><br>--%>
                                <%# Eval("INSTITUTE")%>
                            </td>
                            <td class="font9" width="32%">
                                <%# Eval("EMAIL")%>
                                <br>
                                Phone:
                                <%# Eval("PHONE")%>
                                <asp:Label ID="lblCell" runat="server">
                                </asp:Label>
                            </td>
                            <td class="font9" width="14%" align="center">
                                <%# Eval("Applied_Date")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td width="100%">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
