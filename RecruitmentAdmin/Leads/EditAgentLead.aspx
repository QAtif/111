<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="EditAgentLead.aspx.cs" Inherits="Leads_EditAgentLead" %>
   


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Lead Agent Signup</title>  
    <script type="text/javascript">
        function ClosebtnClick() {
            this.parent.btnClick();
            this.close();
        }


        function numbersonly(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) || (key == 9) || (key == 13) || (key == 27))
                return true;

            // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
                return true;

            // decimal point jump
            else if (dec && (keychar == ".")) {
                myfield.form.elements[dec].focus();
                return false;
            }
            else
                return false;
        }

        function getQueryStringByName(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.search);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function getOnloadData() {
            //$('#ddlCountry :selected').text('' + geoip_country_name() + '').val();
            $("#ddlCountry").each(function () {
                $('option', this).each(function () {
                    if ($(this).text().toLowerCase() == geoip_country_name().toLowerCase()) {
                        $(this).attr('selected', 'selected')
                    };
                });
            });

            document.getElementById('<%= txtParentUrl.ClientID %>').value = parent.document.location.href;
            bindCode();
        }

        function bindCode() {
            document.getElementById('<%= txtphonecode.ClientID %>').value = $('#ddlCountry :selected').val();
        }

        function CompanyItemSelected(sender, e) {
            document.getElementById('<%=hfCompany.ClientID %>').value = e.get_value();
        }
        function LocationItemSelected(sender, e) {
            document.getElementById('<%=hfCompany.ClientID %>').value = e.get_value();
        }
    </script>
    <style type="text/css">
        .completionListElement
        {
            visibility: hidden;
            margin: 0px !important;
            background-color: inherit;
            color: black;
            border: solid 1px;
            cursor: pointer;
            text-align: left;
            list-style-type: none;
            font-family: Verdana;
            font-size: 12px;
            padding: 0;
        }
        .listItem
        {
            background-color: White;
            padding: 1px;
        }
        .highlightedListItem
        {
            background-color: Silver;
            padding: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
<asp:HiddenField ID="hfCompany" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Lead Agent Signup"></asp:Label>
        </h4>
    </div>
    <div id="container" class="contentarea">
        <asp:TextBox ID="txtParentUrl" runat="server" BorderStyle="None" Font-Size="0px"
            ForeColor="#F6F6F6" Height="0px" Width="0px"></asp:TextBox>
        <asp:HiddenField ID="hdnLeadID" runat="server" Value="0" />
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must correct following fields:"
            DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
            BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
            runat="server" />
        <br />
        <br />
        <table style="width: 98%" border="0" cellpadding="10" cellspacing="0">
            <tbody>
                <tr class="simple">
                    <td>
                        Company Name:
                    </td>
                    <td>                   
                        <asp:TextBox ID="txtcompanyname" runat="server" Width="300px">
                        </asp:TextBox>
                             <ajax:AutoCompleteExtender runat="server" ID="acCompany" TargetControlID="txtcompanyname"
                            ServiceMethod="FetchCompanyLive" ServicePath="~/AutoComplete.asmx" MinimumPrefixLength="1"
                            CompletionInterval="0" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="completionListElement"
                            CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="highlightedListItem"
                            DelimiterCharacters=";, :" FirstRowSelected="false" OnClientItemSelected="CompanyItemSelected">
                        </ajax:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtcompanyname"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="Please enter company name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Industry:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIndustry" runat="server" Width="200px">
                            <asp:ListItem Value="1" Text="Aerospace"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Airlines"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Automotive"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Banking"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Chemicals"></asp:ListItem>
                            <asp:ListItem Value="6" Text="Consumer Products"></asp:ListItem>
                            <asp:ListItem Value="7" Text="Defense & Security"></asp:ListItem>
                            <asp:ListItem Value="8" Text="Education"></asp:ListItem>
                            <asp:ListItem Value="9" Text="Energy"></asp:ListItem>
                            <asp:ListItem Value="10" Text="Engineering, Construction, and Operations"></asp:ListItem>
                            <asp:ListItem Value="11" Text="Healthcare"></asp:ListItem>
                            <asp:ListItem Value="12" Text="High-Tech"></asp:ListItem>
                            <asp:ListItem Value="13" Text="Hospitality and Leisure"></asp:ListItem>
                            <asp:ListItem Value="14" Text="Industrial Manufacturing"></asp:ListItem>
                            <asp:ListItem Value="15" Text="Insurance"></asp:ListItem>
                            <asp:ListItem Value="16" Text="Life Sciences"></asp:ListItem>
                            <asp:ListItem Value="17" Text="Media & Entertainment"></asp:ListItem>
                            <asp:ListItem Value="18" Text="Mill Products"></asp:ListItem>
                            <asp:ListItem Value="19" Text="Mining"></asp:ListItem>
                            <asp:ListItem Value="20" Text="Oil and Gas"></asp:ListItem>
                            <asp:ListItem Value="21" Text="Publishing"></asp:ListItem>
                            <asp:ListItem Value="22" Text="Public Sector"></asp:ListItem>
                            <asp:ListItem Value="23" Text="Retail"></asp:ListItem>
                            <asp:ListItem Value="24" Text="Telecommunications"></asp:ListItem>
                            <asp:ListItem Value="25" Text="Transportation & Logistics"></asp:ListItem>
                            <asp:ListItem Value="26" Text="Utilities"></asp:ListItem>
                            <asp:ListItem Value="27" Text="Wholesale Distribution"></asp:ListItem>
                            <asp:ListItem Value="28" Text="Others"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                            ControlToValidate="ddlIndustry" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Please select industry"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Interest:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlInterest" runat="server" Width="200px">
                            <asp:ListItem Value="1" Text="Customer"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Partner"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Relations"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Career"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                            ControlToValidate="ddlInterest" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select interest"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                            ControlToValidate="txtName" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="please enter name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Designation:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDesignation" runat="server" Width="200px">
                            <asp:ListItem Value="1" Text="Owner / CEO"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Manager"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Consultant"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Developer"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                            ControlToValidate="ddlDesignation" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select designation"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Country:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" Width="200px" onchange="bindCode(this);">
                            <asp:ListItem Value="93">AFGHANISTAN</asp:ListItem>
                            <asp:ListItem Value="355">ALBANIA</asp:ListItem>
                            <asp:ListItem Value="213">ALGERIA</asp:ListItem>
                            <asp:ListItem Value="168">AMERICAN SAMOA</asp:ListItem>
                            <asp:ListItem Value="376">ANDORRA</asp:ListItem>
                            <asp:ListItem Value="244">ANGOLA</asp:ListItem>
                            <asp:ListItem Value="264">ANGUILLA</asp:ListItem>
                            <asp:ListItem Value="167">ANTARCTICA</asp:ListItem>
                            <asp:ListItem Value="268">ANTIGUA AND BARBUDA</asp:ListItem>
                            <asp:ListItem Value="54">ARGENTINA</asp:ListItem>
                            <asp:ListItem Value="374">ARMENIA</asp:ListItem>
                            <asp:ListItem Value="297">ARUBA</asp:ListItem>
                            <asp:ListItem Value="61">AUSTRALIA</asp:ListItem>
                            <asp:ListItem Value="43">AUSTRIA</asp:ListItem>
                            <asp:ListItem Value="994">AZERBAIJAN</asp:ListItem>
                            <asp:ListItem Value="242">BAHAMAS</asp:ListItem>
                            <asp:ListItem Value="973">BAHRAIN</asp:ListItem>
                            <asp:ListItem Value="880">BANGLADESH</asp:ListItem>
                            <asp:ListItem Value="246">BARBADOS</asp:ListItem>
                            <asp:ListItem Value="375">BELARUS</asp:ListItem>
                            <asp:ListItem Value="32">BELGIUM</asp:ListItem>
                            <asp:ListItem Value="501">BELIZE</asp:ListItem>
                            <asp:ListItem Value="229">BENIN</asp:ListItem>
                            <asp:ListItem Value="441">BERMUDA</asp:ListItem>
                            <asp:ListItem Value="975">BHUTAN</asp:ListItem>
                            <asp:ListItem Value="591">BOLIVIA</asp:ListItem>
                            <asp:ListItem Value="387">BOSNIA AND HERZEGOVINA</asp:ListItem>
                            <asp:ListItem Value="267">BOTSWANA</asp:ListItem>
                            <asp:ListItem Value="55">BRAZIL</asp:ListItem>
                            <asp:ListItem Value="246">BRITISH INDIAN OCEAN TERRITORY</asp:ListItem>
                            <asp:ListItem Value="673">BRUNEI DARUSSALAM</asp:ListItem>
                            <asp:ListItem Value="359">BULGARIA</asp:ListItem>
                            <asp:ListItem Value="226">BURKINA FASO</asp:ListItem>
                            <asp:ListItem Value="257">BURUNDI</asp:ListItem>
                            <asp:ListItem Value="855">CAMBODIA</asp:ListItem>
                            <asp:ListItem Value="237">CAMEROON</asp:ListItem>
                            <asp:ListItem Value="1">CANADA</asp:ListItem>
                            <asp:ListItem Value="238">CAPE VERDE</asp:ListItem>
                            <asp:ListItem Value="345">CAYMAN ISLANDS</asp:ListItem>
                            <asp:ListItem Value="236">CENTRAL AFRICAN REPUBLIC</asp:ListItem>
                            <asp:ListItem Value="235">CHAD</asp:ListItem>
                            <asp:ListItem Value="56">CHILE</asp:ListItem>
                            <asp:ListItem Value="86">CHINA</asp:ListItem>
                            <asp:ListItem Value="672">CHRISTMAS ISLAND</asp:ListItem>
                            <asp:ListItem Value="672">COCOS (KEELING) ISLANDS</asp:ListItem>
                            <asp:ListItem Value="57">COLOMBIA</asp:ListItem>
                            <asp:ListItem Value="269">COMOROS</asp:ListItem>
                            <asp:ListItem Value="242">CONGO</asp:ListItem>
                            <asp:ListItem Value="242">CONGO, THE DEMOCRATIC REPUBLIC OF THE</asp:ListItem>
                            <asp:ListItem Value="682">COOK ISLANDS</asp:ListItem>
                            <asp:ListItem Value="506">COSTA RICA</asp:ListItem>
                            <asp:ListItem Value="225">COTE D'IVOIRE</asp:ListItem>
                            <asp:ListItem Value="385">CROATIA</asp:ListItem>
                            <asp:ListItem Value="53">CUBA</asp:ListItem>
                            <asp:ListItem Value="357">CYPRUS</asp:ListItem>
                            <asp:ListItem Value="420">CZECH REPUBLIC</asp:ListItem>
                            <asp:ListItem Value="45">DENMARK</asp:ListItem>
                            <asp:ListItem Value="253">DJIBOUTI</asp:ListItem>
                            <asp:ListItem Value="176">DOMINICA</asp:ListItem>
                            <asp:ListItem Value="809">DOMINICAN REPUBLIC</asp:ListItem>
                            <asp:ListItem Value="593">ECUADOR</asp:ListItem>
                            <asp:ListItem Value="20">EGYPT</asp:ListItem>
                            <asp:ListItem Value="503">EL SALVADOR</asp:ListItem>
                            <asp:ListItem Value="240">EQUATORIAL GUINEA</asp:ListItem>
                            <asp:ListItem Value="291">ERITREA</asp:ListItem>
                            <asp:ListItem Value="372">ESTONIA</asp:ListItem>
                            <asp:ListItem Value="251">ETHIOPIA</asp:ListItem>
                            <asp:ListItem Value="500">FALKLAND ISLANDS (MALVINAS)</asp:ListItem>
                            <asp:ListItem Value="298">FAROE ISLANDS</asp:ListItem>
                            <asp:ListItem Value="679">FIJI</asp:ListItem>
                            <asp:ListItem Value="358">FINLAND</asp:ListItem>
                            <asp:ListItem Value="33">FRANCE</asp:ListItem>
                            <asp:ListItem Value="594">FRENCH GUIANA</asp:ListItem>
                            <asp:ListItem Value="689">FRENCH POLYNESIA</asp:ListItem>
                            <asp:ListItem Value="689">FRENCH SOUTHERN TERRITORIES</asp:ListItem>
                            <asp:ListItem Value="241">GABON</asp:ListItem>
                            <asp:ListItem Value="220">GAMBIA</asp:ListItem>
                            <asp:ListItem Value="995">GEORGIA</asp:ListItem>
                            <asp:ListItem Value="49">GERMANY</asp:ListItem>
                            <asp:ListItem Value="233">GHANA</asp:ListItem>
                            <asp:ListItem Value="350">GIBRALTAR</asp:ListItem>
                            <asp:ListItem Value="30">GREECE</asp:ListItem>
                            <asp:ListItem Value="299">GREENLAND</asp:ListItem>
                            <asp:ListItem Value="473">GRENADA</asp:ListItem>
                            <asp:ListItem Value="590">GUADELOUPE</asp:ListItem>
                            <asp:ListItem Value="671">GUAM</asp:ListItem>
                            <asp:ListItem Value="502">GUATEMALA</asp:ListItem>
                            <asp:ListItem Value="224">GUINEA</asp:ListItem>
                            <asp:ListItem Value="245">GUINEA-BISSAU</asp:ListItem>
                            <asp:ListItem Value="592">GUYANA</asp:ListItem>
                            <asp:ListItem Value="509">HAITI</asp:ListItem>
                            <asp:ListItem Value="39">HOLY SEE (VATICAN CITY STATE)</asp:ListItem>
                            <asp:ListItem Value="503">HONDURAS</asp:ListItem>
                            <asp:ListItem Value="852">HONG KONG</asp:ListItem>
                            <asp:ListItem Value="36">HUNGARY</asp:ListItem>
                            <asp:ListItem Value="354">ICELAND</asp:ListItem>
                            <asp:ListItem Value="91">INDIA</asp:ListItem>
                            <asp:ListItem Value="62">INDONESIA</asp:ListItem>
                            <asp:ListItem Value="98">IRAN, ISLAMIC REPUBLIC OF</asp:ListItem>
                            <asp:ListItem Value="964">IRAQ</asp:ListItem>
                            <asp:ListItem Value="353">IRELAND</asp:ListItem>
                            <asp:ListItem Value="972">ISRAEL</asp:ListItem>
                            <asp:ListItem Value="39">ITALY</asp:ListItem>
                            <asp:ListItem Value="876">JAMAICA</asp:ListItem>
                            <asp:ListItem Value="81">JAPAN</asp:ListItem>
                            <asp:ListItem Value="962">JORDAN</asp:ListItem>
                            <asp:ListItem Value="7">KAZAKHSTAN</asp:ListItem>
                            <asp:ListItem Value="254">KENYA</asp:ListItem>
                            <asp:ListItem Value="686">KIRIBATI</asp:ListItem>
                            <asp:ListItem Value="82">KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF</asp:ListItem>
                            <asp:ListItem Value="82">KOREA, REPUBLIC OF</asp:ListItem>
                            <asp:ListItem Value="965">KUWAIT</asp:ListItem>
                            <asp:ListItem Value="996">KYRGYZSTAN</asp:ListItem>
                            <asp:ListItem Value="856">LAO PEOPLE'S DEMOCRATIC REPUBLIC</asp:ListItem>
                            <asp:ListItem Value="371">LATVIA</asp:ListItem>
                            <asp:ListItem Value="961">LEBANON</asp:ListItem>
                            <asp:ListItem Value="266">LESOTHO</asp:ListItem>
                            <asp:ListItem Value="231">LIBERIA</asp:ListItem>
                            <asp:ListItem Value="218">LIBYAN ARAB JAMAHIRIYA</asp:ListItem>
                            <asp:ListItem Value="423">LIECHTENSTEIN</asp:ListItem>
                            <asp:ListItem Value="370">LITHUANIA</asp:ListItem>
                            <asp:ListItem Value="352">LUXEMBOURG</asp:ListItem>
                            <asp:ListItem Value="853">MACAO</asp:ListItem>
                            <asp:ListItem Value="389">MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF</asp:ListItem>
                            <asp:ListItem Value="261">MADAGASCAR</asp:ListItem>
                            <asp:ListItem Value="265">MALAWI</asp:ListItem>
                            <asp:ListItem Value="60">MALAYSIA</asp:ListItem>
                            <asp:ListItem Value="960">MALDIVES</asp:ListItem>
                            <asp:ListItem Value="223">MALI</asp:ListItem>
                            <asp:ListItem Value="356">MALTA</asp:ListItem>
                            <asp:ListItem Value="692">MARSHALL ISLANDS</asp:ListItem>
                            <asp:ListItem Value="596">MARTINIQUE</asp:ListItem>
                            <asp:ListItem Value="222">MAURITANIA</asp:ListItem>
                            <asp:ListItem Value="230">MAURITIUS</asp:ListItem>
                            <asp:ListItem Value="269">MAYOTTE</asp:ListItem>
                            <asp:ListItem Value="52">MEXICO</asp:ListItem>
                            <asp:ListItem Value="691">MICRONESIA, FEDERATED STATES OF</asp:ListItem>
                            <asp:ListItem Value="373">MOLDOVA, REPUBLIC OF</asp:ListItem>
                            <asp:ListItem Value="377">MONACO</asp:ListItem>
                            <asp:ListItem Value="976">MONGOLIA</asp:ListItem>
                            <asp:ListItem Value="664">MONTSERRAT</asp:ListItem>
                            <asp:ListItem Value="212">MOROCCO</asp:ListItem>
                            <asp:ListItem Value="258">MOZAMBIQUE</asp:ListItem>
                            <asp:ListItem Value="95">MYANMAR</asp:ListItem>
                            <asp:ListItem Value="264">NAMIBIA</asp:ListItem>
                            <asp:ListItem Value="674">NAURU</asp:ListItem>
                            <asp:ListItem Value="977">NEPAL</asp:ListItem>
                            <asp:ListItem Value="31">NETHERLANDS</asp:ListItem>
                            <asp:ListItem Value="599">NETHERLANDS ANTILLES</asp:ListItem>
                            <asp:ListItem Value="687">NEW CALEDONIA</asp:ListItem>
                            <asp:ListItem Value="64">NEW ZEALAND</asp:ListItem>
                            <asp:ListItem Value="505">NICARAGUA</asp:ListItem>
                            <asp:ListItem Value="227">NIGER</asp:ListItem>
                            <asp:ListItem Value="234">NIGERIA</asp:ListItem>
                            <asp:ListItem Value="683">NIUE</asp:ListItem>
                            <asp:ListItem Value="672">NORFOLK ISLAND</asp:ListItem>
                            <asp:ListItem Value="167">NORTHERN MARIANA ISLANDS</asp:ListItem>
                            <asp:ListItem Value="47">NORWAY</asp:ListItem>
                            <asp:ListItem Value="968">OMAN</asp:ListItem>
                            <asp:ListItem Value="92">PAKISTAN</asp:ListItem>
                            <asp:ListItem Value="680">PALAU</asp:ListItem>
                            <asp:ListItem Value="970">PALESTINIAN TERRITORY, OCCUPIED</asp:ListItem>
                            <asp:ListItem Value="507">PANAMA</asp:ListItem>
                            <asp:ListItem Value="675">PAPUA NEW GUINEA</asp:ListItem>
                            <asp:ListItem Value="595">PARAGUAY</asp:ListItem>
                            <asp:ListItem Value="51">PERU</asp:ListItem>
                            <asp:ListItem Value="63">PHILIPPINES</asp:ListItem>
                            <asp:ListItem Value="672">PITCAIRN</asp:ListItem>
                            <asp:ListItem Value="48">POLAND</asp:ListItem>
                            <asp:ListItem Value="351">PORTUGAL</asp:ListItem>
                            <asp:ListItem Value="787">PUERTO RICO</asp:ListItem>
                            <asp:ListItem Value="974">QATAR</asp:ListItem>
                            <asp:ListItem Value="262">REUNION</asp:ListItem>
                            <asp:ListItem Value="40">ROMANIA</asp:ListItem>
                            <asp:ListItem Value="7">RUSSIAN FEDERATION</asp:ListItem>
                            <asp:ListItem Value="250">RWANDA</asp:ListItem>
                            <asp:ListItem Value="290">SAINT HELENA</asp:ListItem>
                            <asp:ListItem Value="186">SAINT KITTS AND NEVIS</asp:ListItem>
                            <asp:ListItem Value="175">SAINT LUCIA</asp:ListItem>
                            <asp:ListItem Value="508">SAINT PIERRE AND MIQUELON</asp:ListItem>
                            <asp:ListItem Value="180">SAINT VINCENT AND THE GRENADINES</asp:ListItem>
                            <asp:ListItem Value="885">SAMOA</asp:ListItem>
                            <asp:ListItem Value="378">SAN MARINO</asp:ListItem>
                            <asp:ListItem Value="239">SAO TOME AND PRINCIPE</asp:ListItem>
                            <asp:ListItem Value="966">SAUDI ARABIA</asp:ListItem>
                            <asp:ListItem Value="221">SENEGAL</asp:ListItem>
                            <asp:ListItem Value="381">SERBIA AND MONTENEGRO</asp:ListItem>
                            <asp:ListItem Value="248">SEYCHELLES</asp:ListItem>
                            <asp:ListItem Value="232">SIERRA LEONE</asp:ListItem>
                            <asp:ListItem Value="65">SINGAPORE</asp:ListItem>
                            <asp:ListItem Value="421">SLOVAKIA</asp:ListItem>
                            <asp:ListItem Value="386">SLOVENIA</asp:ListItem>
                            <asp:ListItem Value="677">SOLOMON ISLANDS</asp:ListItem>
                            <asp:ListItem Value="252">SOMALIA</asp:ListItem>
                            <asp:ListItem Value="27">SOUTH AFRICA</asp:ListItem>
                            <asp:ListItem Value="34">SPAIN</asp:ListItem>
                            <asp:ListItem Value="94">SRI LANKA</asp:ListItem>
                            <asp:ListItem Value="249">SUDAN</asp:ListItem>
                            <asp:ListItem Value="597">SURINAME</asp:ListItem>
                            <asp:ListItem Value="47">SVALBARD AND JAN MAYEN</asp:ListItem>
                            <asp:ListItem Value="268">SWAZILAND</asp:ListItem>
                            <asp:ListItem Value="46">SWEDEN</asp:ListItem>
                            <asp:ListItem Value="41">SWITZERLAND</asp:ListItem>
                            <asp:ListItem Value="963">SYRIAN ARAB REPUBLIC</asp:ListItem>
                            <asp:ListItem Value="886">TAIWAN, PROVINCE OF CHINA</asp:ListItem>
                            <asp:ListItem Value="992">TAJIKISTAN</asp:ListItem>
                            <asp:ListItem Value="255">TANZANIA, UNITED REPUBLIC OF</asp:ListItem>
                            <asp:ListItem Value="66">THAILAND</asp:ListItem>
                            <asp:ListItem Value="670">TIMOR-LESTE</asp:ListItem>
                            <asp:ListItem Value="228">TOGO</asp:ListItem>
                            <asp:ListItem Value="690">TOKELAU</asp:ListItem>
                            <asp:ListItem Value="676">TONGA</asp:ListItem>
                            <asp:ListItem Value="186">TRINIDAD AND TOBAGO</asp:ListItem>
                            <asp:ListItem Value="216">TUNISIA</asp:ListItem>
                            <asp:ListItem Value="90">TURKEY</asp:ListItem>
                            <asp:ListItem Value="993">TURKMENISTAN</asp:ListItem>
                            <asp:ListItem Value="164">TURKS AND CAICOS ISLANDS</asp:ListItem>
                            <asp:ListItem Value="688">TUVALU</asp:ListItem>
                            <asp:ListItem Value="256">UGANDA</asp:ListItem>
                            <asp:ListItem Value="380">UKRAINE</asp:ListItem>
                            <asp:ListItem Value="971">UNITED ARAB EMIRATES</asp:ListItem>
                            <asp:ListItem Value="44">UNITED KINGDOM</asp:ListItem>
                            <asp:ListItem Value="1">UNITED STATES</asp:ListItem>
                            <asp:ListItem Value="598">URUGUAY</asp:ListItem>
                            <asp:ListItem Value="998">UZBEKISTAN</asp:ListItem>
                            <asp:ListItem Value="678">VANUATU</asp:ListItem>
                            <asp:ListItem Value="58">VENEZUELA</asp:ListItem>
                            <asp:ListItem Value="84">VIETNAM</asp:ListItem>
                            <asp:ListItem Value="128">VIRGIN ISLANDS, BRITISH</asp:ListItem>
                            <asp:ListItem Value="134">VIRGIN ISLANDS, U.S.</asp:ListItem>
                            <asp:ListItem Value="681">WALLIS AND FUTUNA</asp:ListItem>
                            <asp:ListItem Value="212">WESTERN SAHARA</asp:ListItem>
                            <asp:ListItem Value="967">YEMEN</asp:ListItem>
                            <asp:ListItem Value="260">ZAMBIA</asp:ListItem>
                            <asp:ListItem Value="263">ZIMBABWE</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:TextBox ID="txtphonecode" CssClass="form-input-style" Text="92" ReadOnly="true"
                            Style="width: 40px;" runat="server" onkeypress="return numbersonly(this, event)"
                            MaxLength="4" />
                        &nbsp;&nbsp; &nbsp; <strong>Phone No: </strong>&nbsp;
                        <asp:TextBox ID="txtphoneNo" CssClass="form-input-style" Style="width: 150px; margin-right: 5px;"
                            runat="server" onkeypress="return numbersonly(this)" MaxLength="12" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server"
                            ControlToValidate="txtphoneNo" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please enter phone no"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtemail" CssClass="form-input-style" Style="width: 200px;" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server"
                            ControlToValidate="txtemail" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regularExpression1" runat="server" ControlToValidate="txtemail"
                            Text="*" ErrorMessage="Please enter valid email address" ValidationGroup="valida"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Product:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProductType" runat="server" Width="200px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged">
                                    <asp:ListItem Value="" Selected="True">-- Select --</asp:ListItem>
                                    <asp:ListItem Value="1">Core Products </asp:ListItem>
                                    <asp:ListItem Value="2">Industry Specific Products </asp:ListItem>
                                    <asp:ListItem Value="3">Small Business Products </asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlProduct" runat="server" Width="200px">
                                    <asp:ListItem Value="">-- Select --</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server"
                                    ControlToValidate="ddlProduct" InitialValue="" Text="*" ValidationGroup="valida"
                                    ErrorMessage="Please Select Product"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Comments:
                    </td>
                    <td>
                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="134px" Width="452px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                            ControlToValidate="txtComment" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Please enter comments"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnNext" runat="server" Text="Save" CssClass="btn-ora nl" ValidationGroup="valida"
                            OnClick="btnNext_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="text-align: center">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
        </div>
    </div>
</asp:Content>
