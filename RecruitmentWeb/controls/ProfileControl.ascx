<%@ control language="C#" enableviewstate="true" autoeventwireup="true" inherits="controls_ProfileControl, App_Web_profilecontrol.ascx.cc671b29" %> 
   <style type="text/css">
 .hide-tour-div {
    display: none;
}
</style>

<div class="row-fluid">
    <div class="span3">
        <a href="/" id="logo">
            <%=ConfigurationManager.AppSettings["ClientName"].ToString() %>
            Recruitment</a>
    </div>
    <div class="span9">
        <div id="xprofile-menu">
            <div>
                <a href="javascript:void(0);">
                    <asp:Image ID="imgProfileImageSmall" ImageUrl="../Area/SocialMedia/UserImagePath/profile.jpg"
                        runat="server" /><%--<img id="imgProfileImageSmall" runat="server" alt="ProfileImageSmall" />--%></a>
                <div class="XProMenu xbox">
                    <ul>
                        <li class="active"><a href="/Area/Area.aspx">Home</a></li>
                        <li><a href="/Area/alert.aspx">Alerts</a></li>
                        <li><a id="ATnGUpper" runat="server" href="javascript:;">Tips and Guides</a></li>
                        <li class="Xsep"><a href="javascript:;">&nbsp;</a></li>
                        <%--<li><a href="#myModal_ChangePassword"
                            data-toggle="modal" role="button">Change Password</a></li>--%>
                        <li><a role="button" data-toggle="modal" href="#myModal_ChangePassword">Change Password</a></li>
                        <li><a href="javascript:;" id="xShowHelp"><span>Show Help</span><span style="display: none;">Hide
                            Help</span></a></li>
                        <li class="Xsep"><a href="javascript:;">&nbsp;</a></li>
                        <li>
                            <asp:LinkButton runat="server" ID="logout" Text="Logout" OnClick="logout_Click"></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <h3>
                <a href="/Area/Area.aspx">
                    <asp:Label ID="lblProfileFullName" runat="server"></asp:Label></a></h3>
        </div>
        <ul style="margin: 25px 0 0 0;list-style: none;display: inline-block;float: right;">
            <li>  <a  class="xBook-button-normal" href="javascript:;" data-toggle="modal" data-target="#NeedHelp">Need Help? </a> Call<span>
                <%=ConfigurationManager.AppSettings["ClientPhone"].ToString()%></span></li>
            <%--<li><a href="javascript:void(0);">Chat</a></li>--%>
            <%--<li><a href="javascript:void(0);">Email</a></li>--%>
        </ul>
    </div>
</div>
<div class="row-fluid">
    <!-- mirza copy cat beginsssss -->
    <div class="xbox2  introjs-helperNumberLayer2 hide-tour-div">
        <div class="Xend-tour-btn">
            <button class="btn btn-small pull-right xend-tour endtour-btn" type="button" onclick="javascript:void(0);"
                data-original-title="" title="">
                End Demo</button>
        </div>
        <a href="javascript:void(0);" class="xclose2 xend-tour" title="Close">Close</a>
        <p style="margin: 0px;">
            Take a tour of your Member Area:</p>
        <br />
        <div class="process-steps">
            <ul class="crumbs">
                <li class="selected"><a href="javascript:;" class="first" onclick="introJs().goToStep(1).start();">
                    <span class="last-tail"></span>Cover Photo</a></li>
                <li><a href="javascript:;" style="z-index: 9;" onclick="introJs().goToStep(2).start();">
                    <span class="last-tail"></span>Profile Picture</a></li>
                <li><a href="javascript:;" style="z-index: 8;" onclick="introJs().goToStep(3).start();">
                    <span class="last-tail"></span>Edit Profile</a></li>
                <li><a href="javascript:;" style="z-index: 7;" onclick="introJs().goToStep(4).start();">
                    <span class="last-tail"></span>Alerts</a></li>
                <li><a href="javascript:;" style="z-index: 7;" onclick="introJs().goToStep(5).start();">
                    <span class="last-tail"></span>Profile</a></li>
                <li><a href="javascript:;" style="z-index: 6;" onclick="introJs().goToStep(6).start();">
                    <span class="last-tail"></span>Tips &amp; Guides</a></li>
                <li><a href="javascript:;" style="z-index: 5;" onclick="introJs().goToStep(7).start();">
                    <span class="last-tail"></span>Applicant Summary</a></li>
                <li><a href="javascript:;" style="z-index: 4;" onclick="introJs().goToStep(8).start();">
                    <span class="last-tail"></span>Verification</a></li>
                <li style="display:none"><a href="javascript:;" style="z-index: 2;" onclick="introJs().goToStep(9).start();"
                    id="verification_step"><span class="last-tail"></span>Application Status</a></li>
            </ul>
        </div>
    </div>
    <div class="xbox2 notification">
        <div class="span10">
            <h3>
                Get started with your Job Application!</h3>
            <p>
                Welcome to your personalized Applicant Area! Learn how to manage your area and profile
                by watching Demo.</p>
        </div>
        <div class="span3">
            <button class="btn btn-small pull-right endtour-btn" type="button" id="start-demo">
                Start Demo</button>
        </div>
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a>
    </div>
    <!-- mirza copy cat ends -->
</div>
<div class="row-fluid">
    <div class="span12">
        <div id="xcover">
            <!-- this show only on Demo tour -->
            <div style="top: 311px; left: 746px; position: absolute;">
                  <button class="btn btn-small edit-profile" type="button" data-step="2" data-intro="Use this button to view and update your profile information like personal, professional and academic details."
                    data-position="left" data-original-title="" title="">
                    Edit Profile</button>
            </div>
            <!-- this show only on Demo tour end-->
            <div id="xdetails">
                <h1>
                    <asp:Label ID="lblCoverFullName" runat="server"></asp:Label></h1>
                <div id="xoptions">
                    <a href="../profile/redirector.aspx" class="btn btn-small edit-profile">Edit Profile</a>
                    <button class="btn btn-small call" type="button" data-placement="top" data-toggle="tooltip"
                        data-original-title="Call us on <%=ConfigurationManager.AppSettings["ClientPhone"].ToString() %>">
                        <img src="/Area/assets/img/icon-call.png" alt=""></button>
                    <button class="btn btn-small email" type="button" data-placement="top" data-toggle="tooltip"
                        data-original-title="Email us  at <%=ConfigurationManager.AppSettings["ClientEmail"].ToString() %> ">
                        <img src="/Area/assets/img/icon-email.png" alt=""></button>
                </div>
                <div id="xCoverOptions">
                    <asp:Button ID="btnSaveCoverPositions" runat="server" CssClass="btn btn-small edit-xCover"
                        Text="Save" OnClick="btnSaveCoverPositions_Click"></asp:Button>
                    <button class="btn btn-small edit-xCover" type="button" data-toggle="modal">
                        Cancel</button>
                </div>
            </div>
            <div id="xdp" data-step="1" data-intro="You can upload or remove your profile picture by simply clicking on the image. You can also sync it with your Facebook profile picture."
                data-position='right'>
                <img id="imgProfileImage" runat="server" src="../Area/SocialMedia/UserImagePath/profile.jpg"
                    alt="" style="height: inherit; width: inherit;" />
                <button class="btn btn-small  XdpMneuactivate" type="button">
                    <img src="/Area/assets/img/icon-edit.png" alt="">
                    Edit Profile Picture</button>
                <div class="xbox XdpMneu">
                    <ul>
                        <li><a href="javascript:void(0);" title="" id="lnkUpload" onclick="document.getElementById('uploadprofile').click(); return false">
                            <img src="/Area/assets/img/icon-upload.png" alt="" />
                            Upload Photo</a></li>
                        <li id="removeProfilePict" runat="server"><a href="#xRemoveProfilePhoto" data-toggle="modal">
                            <img src="/Area/assets/img/icon-remove.png" alt="" />
                            Remove Photo</a></li>
                    </ul>
                </div>
            </div>
            <button class="btn btn-small  XcoverMneuactivate" type="button" data-placement="left"
                data-toggle="tooltip" data-original-title="Choose a unique image for the cover of your homepage">
                <img src="/Area/assets/img/icon-edit.png" alt="">
                Edit Cover Photo</button>
            <div class="xbox XdpMneu">
                <ul>
                    <li><a id="lnkUpload2" title="" href="javascript:void(0);" class="filep" onclick="document.getElementById('uploadcover').click(); return false;">
                        <img src="/Area/assets/img/icon-upload.png" alt="" />
                        Upload Photo</a></li>
                    <li class="repo"><a href="javascript:;" id="reposition">
                        <img src="/Area/assets/img/icon-move.png" alt="" />
                        Reposition Photo</a></li>
                    <li id="removeCoverPict" runat="server"><a href="#xRemoveCoverPhoto" data-toggle="modal">
                        <img src="/Area/assets/img/icon-remove.png" alt="" />
                        Remove Photo</a></li>
                </ul>
            </div>
            <div id="xcoverInner" data-step="0" data-intro="You can upload, reposition or remove your cover photo by clicking on the image. You can also sync it with your Facebook cover photo."
                data-position='bottom'>
                <img id="draggable" class="drag" runat="server" src="../Area/SocialMedia/UserImagePath/cover.jpg"
                    alt="" style="width: 100% !important; min-height: 472px !important;" />
                <img src="/Area/assets/img/drager.png" alt="dragger" id="dragger" />
            </div>
        </div>
        <nav id="xnav">
          <ul>
                <li><a href="/Area/Area.aspx" >Home</a></li>
            <li><a href="/Area/alert.aspx" data-step="3" data-intro="Alerts keep you notified about any recent activity and updates about your profile and application status." data-position='right'>Alerts<span id="spanAlert" runat="server"><asp:Label ID="lblalertcount" runat="server"></asp:Label></span> </a></li>
            <li><a href="/Area/viewprofile.aspx" data-step="4" data-intro="In this section you can view your profile summary. It also allows you to edit your profile details like personal, professional and academic details." data-position='right'>Profile</a></li>     
				
                <li><a id="ATnG" runat="server" href="javascript:;" data-step="5" data-intro="This section provides you with valuable tips that will help you enhance your professional skills for a successful career progression. " data-position='right'> Tips and Guides</a></li>
                            
          </ul>
        </nav>
        <nav id="xnavSc" style="display: none;">                
          <ul>
          	<li><a href="/Area/Area.aspx"> <asp:Image id="imgNavImageSmall" runat="server" ImageUrl="../Area/SocialMedia/UserImagePath/profile.jpg" width="32" height="32" alt="" /> <asp:Label ID="lblNavFullName" runat="server" ></asp:Label></a></li>
          <li><a href="/Area/Area.aspx">Home</a></li>
            <li><a href="/Area/alert.aspx">Alerts <span>12</span></a></li>
            <li><a href="profile.asp">Profiles</a></li>
                      <li><a href="javascript:;" data-toggle="tooltip" data-original-title="Available in Help Tips File" data-placement="bottom"> Tips and Guides</a></li>            
            </ul>
        </nav>
    </div>
</div>
<span class="name">
    <asp:HiddenField runat="server" ID="profileImagePath" />
    <asp:HiddenField runat="server" ID="coverImageTopPosition" />
    <asp:HiddenField runat="server" ID="coverImageleftPosition" />
</span>
<!-- Modal Edit Profile Individual-->
<div id="xEditProfile" class="modal hide fade theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true" role="button">
            x</button>
        <h3 id="myModalLabel">
            Complete your profile</h3>
    </div>
    <div class="modal-body">
        <div class="row-fluid">
        </div>
        <div class="row-fluid xEditFields">
            <div class="span6">
                <h3 class="bottom-fifteen">
                    Profile Information <a href="javascript:void(0);" class="EditPro xLeft">Edit</a></h3>
                <p>
                    Your Name
                    <asp:Label ID="lblName" runat="server"></asp:Label></p>
                <p>
                    Date of Birth
                    <asp:Label ID="lblDOB" runat="server"></asp:Label></p>
                <p>
                    Gender
                    <asp:Label ID="lblGender" runat="server"></asp:Label></p>
            </div>
            <div class="span6">
                <h3 class="bottom-fifteen">
                    Contact Information <a href="javascript:void(0);" class="EditPro xRight" onclick="FillPCountryCode();">
                        Edit</a></h3>
                <p>
                    Your Location
                    <asp:Label ID="lblLocation" runat="server"></asp:Label></p>
                <p>
                    Your Number
                    <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label></p>
                <p>
                    Your Email
                    <asp:Label ID="lblEmail" runat="server"></asp:Label></p>
            </div>
            <div class="xHiddenTable xbox">
                <div class="XbInner">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                First Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" Text="First Name*" runat="server" Width="90%" MaxLength="49"
                                    CssClass="jqtranformdone" onfocus="javascript: if(this.value == 'First Name*'){ this.value = ''; }"
                                    onblur="javascript: if(this.value==''){this.value='First Name*';}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Last Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" Text="Last Name*" runat="server" Width="90%" MaxLength="49"
                                    CssClass="jqtranformdone" onfocus="javascript: if(this.value == 'Last Name*'){ this.value = ''; }"
                                    onblur="javascript: if(this.value==''){this.value='Last Name*';}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Date of Birth
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 90%;">
                                    <asp:ListItem Value="0">Month</asp:ListItem>
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Marchy" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlDay" runat="server" Style="width: 22%;">
                                    <asp:ListItem Value="0">Day</asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYear" runat="server" Style="width: 40%;">
                                    <asp:ListItem Value="0">Year</asp:ListItem>
                                    <asp:ListItem Text="1981" Value="1981"></asp:ListItem>
                                    <asp:ListItem Text="1982" Value="1982"></asp:ListItem>
                                    <asp:ListItem Text="1983" Value="1983"></asp:ListItem>
                                    <asp:ListItem Text="1984" Value="1984"></asp:ListItem>
                                    <asp:ListItem Text="1985" Value="1985"></asp:ListItem>
                                    <asp:ListItem Text="1986" Value="1986"></asp:ListItem>
                                    <asp:ListItem Text="1987" Value="1987"></asp:ListItem>
                                    <asp:ListItem Text="1988" Value="1988"></asp:ListItem>
                                    <asp:ListItem Text="1989" Value="1989"></asp:ListItem>
                                    <asp:ListItem Text="1990" Value="1990"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Gender
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                    <asp:ListItem Text="Male" Value="Male" Selected="True" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="chunchunfooter">
                    <a href="javascript:;" data-dismiss="modal" aria-hidden="true" role="button" class="pull-right">
                        <img src="../Area/assets/img/btn-cancel.png" alt="" /></a> <a href="javascript:void(0);"
                            data-dismiss="modal" aria-hidden="true" role="button" class="pull-right">
                            <asp:LinkButton ID="lbtnProfileInformation" runat="server" OnClientClick="return IPersonalInfo();"
                                OnClick="lbtnProfileInformation_Click"><img src="../Area/assets/img/btn-save.png" alt="" /></asp:LinkButton>
                        </a>
                    <%--<asp:ImageButton ID="ProfileInformation" ImageUrl="/Area/assets/img/btn-save.png" 
              runat="server" alt="Save" onclick="ProfileInformation_Click" /></a>--%>
                </div>
            </div>
            <div class="xHiddenTable2 xbox">
                <div class="XbInner">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="40%">
                                Your Location
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPCountry" runat="server" onchange="FillPCountryCode();"
                                    Width="192%">
                                    <asp:ListItem Selected="True" Value="0">Country</asp:ListItem>
                                    <asp:ListItem Value="1-224">UNITED STATES</asp:ListItem>
                                    <asp:ListItem Value="93-3">AFGHANISTAN</asp:ListItem>
                                    <asp:ListItem Value="358-16">�LAND ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="355-6">ALBANIA</asp:ListItem>
                                    <asp:ListItem Value="213-61">ALGERIA</asp:ListItem>
                                    <asp:ListItem Value="168-12">AMERICAN SAMOA</asp:ListItem>
                                    <asp:ListItem Value="376-1">ANDORRA</asp:ListItem>
                                    <asp:ListItem Value="244-9">ANGOLA</asp:ListItem>
                                    <asp:ListItem Value="264-5">ANGUILLA</asp:ListItem>
                                    <asp:ListItem Value="167-10">ANTARCTICA</asp:ListItem>
                                    <asp:ListItem Value="268-4">ANTIGUA AND BARBUDA</asp:ListItem>
                                    <asp:ListItem Value="54-11">ARGENTINA</asp:ListItem>
                                    <asp:ListItem Value="374-7">ARMENIA</asp:ListItem>
                                    <asp:ListItem Value="297-15">ARUBA</asp:ListItem>
                                    <asp:ListItem Value="61-14">AUSTRALIA</asp:ListItem>
                                    <asp:ListItem Value="43-13">AUSTRIA</asp:ListItem>
                                    <asp:ListItem Value="994-17">AZERBAIJAN</asp:ListItem>
                                    <asp:ListItem Value="242-31">BAHAMAS</asp:ListItem>
                                    <asp:ListItem Value="973-24">BAHRAIN</asp:ListItem>
                                    <asp:ListItem Value="880-20">BANGLADESH</asp:ListItem>
                                    <asp:ListItem Value="246-19">BARBADOS</asp:ListItem>
                                    <asp:ListItem Value="375-35">BELARUS</asp:ListItem>
                                    <asp:ListItem Value="32-21">BELGIUM</asp:ListItem>
                                    <asp:ListItem Value="501-36">BELIZE</asp:ListItem>
                                    <asp:ListItem Value="229-26">BENIN</asp:ListItem>
                                    <asp:ListItem Value="441-27">BERMUDA</asp:ListItem>
                                    <asp:ListItem Value="975-32">BHUTAN</asp:ListItem>
                                    <asp:ListItem Value="591-29">BOLIVIA</asp:ListItem>
                                    <asp:ListItem Value="387-18">BOSNIA AND HERZEGOVINA</asp:ListItem>
                                    <asp:ListItem Value="267-34">BOTSWANA</asp:ListItem>
                                    <asp:ListItem Value="55-30">BRAZIL</asp:ListItem>
                                    <asp:ListItem Value="246-103">BRITISH INDIAN OCEAN TERRITORY</asp:ListItem>
                                    <asp:ListItem Value="673-28">BRUNEI DARUSSALAM</asp:ListItem>
                                    <asp:ListItem Value="359-23">BULGARIA</asp:ListItem>
                                    <asp:ListItem Value="226-22">BURKINA FASO</asp:ListItem>
                                    <asp:ListItem Value="257-25">BURUNDI</asp:ListItem>
                                    <asp:ListItem Value="855-113">CAMBODIA</asp:ListItem>
                                    <asp:ListItem Value="237-46">CAMEROON</asp:ListItem>
                                    <asp:ListItem Value="1-37">CANADA</asp:ListItem>
                                    <asp:ListItem Value="238-52">CAPE VERDE</asp:ListItem>
                                    <asp:ListItem Value="345-120">CAYMAN ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="236-40">CENTRAL AFRICAN REPUBLIC</asp:ListItem>
                                    <asp:ListItem Value="235-206">CHAD</asp:ListItem>
                                    <asp:ListItem Value="56-45">CHILE</asp:ListItem>
                                    <asp:ListItem Value="86-47">CHINA</asp:ListItem>
                                    <asp:ListItem Value="672-53">CHRISTMAS ISLAND</asp:ListItem>
                                    <asp:ListItem Value="672-38">COCOS (KEELING) ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="57-48">COLOMBIA</asp:ListItem>
                                    <asp:ListItem Value="269-115">COMOROS</asp:ListItem>
                                    <asp:ListItem Value="242-41">CONGO</asp:ListItem>
                                    <asp:ListItem Value="242-39">CONGO, THE DEMOCRATIC REPUBLIC OF THE</asp:ListItem>
                                    <asp:ListItem Value="682-44">COOK ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="506-49">COSTA RICA</asp:ListItem>
                                    <asp:ListItem Value="225-43">COTE D'IVOIRE</asp:ListItem>
                                    <asp:ListItem Value="385-96">CROATIA</asp:ListItem>
                                    <asp:ListItem Value="53-51">CUBA</asp:ListItem>
                                    <asp:ListItem Value="357-54">CYPRUS</asp:ListItem>
                                    <asp:ListItem Value="420-55">CZECH REPUBLIC</asp:ListItem>
                                    <asp:ListItem Value="45-58">DENMARK</asp:ListItem>
                                    <asp:ListItem Value="253-57">DJIBOUTI</asp:ListItem>
                                    <asp:ListItem Value="176-59">DOMINICA</asp:ListItem>
                                    <asp:ListItem Value="809-60">DOMINICAN REPUBLIC</asp:ListItem>
                                    <asp:ListItem Value="593-62">ECUADOR</asp:ListItem>
                                    <asp:ListItem Value="20-64">EGYPT</asp:ListItem>
                                    <asp:ListItem Value="503-202">EL SALVADOR</asp:ListItem>
                                    <asp:ListItem Value="240-86">EQUATORIAL GUINEA</asp:ListItem>
                                    <asp:ListItem Value="291-66">ERITREA</asp:ListItem>
                                    <asp:ListItem Value="372-63">ESTONIA</asp:ListItem>
                                    <asp:ListItem Value="251-68">ETHIOPIA</asp:ListItem>
                                    <asp:ListItem Value="500-71">FALKLAND ISLANDS (MALVINAS)</asp:ListItem>
                                    <asp:ListItem Value="298-73">FAROE ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="679-70">FIJI</asp:ListItem>
                                    <asp:ListItem Value="358-69">FINLAND</asp:ListItem>
                                    <asp:ListItem Value="33-74">FRANCE</asp:ListItem>
                                    <asp:ListItem Value="594-79">FRENCH GUIANA</asp:ListItem>
                                    <asp:ListItem Value="689-169">FRENCH POLYNESIA</asp:ListItem>
                                    <asp:ListItem Value="689-207">FRENCH SOUTHERN TERRITORIES</asp:ListItem>
                                    <asp:ListItem Value="241-75">GABON</asp:ListItem>
                                    <asp:ListItem Value="220-83">GAMBIA</asp:ListItem>
                                    <asp:ListItem Value="995-78">GEORGIA</asp:ListItem>
                                    <asp:ListItem Value="49-56">GERMANY</asp:ListItem>
                                    <asp:ListItem Value="233-80">GHANA</asp:ListItem>
                                    <asp:ListItem Value="350-81">GIBRALTAR</asp:ListItem>
                                    <asp:ListItem Value="30-87">GREECE</asp:ListItem>
                                    <asp:ListItem Value="299-82">GREENLAND</asp:ListItem>
                                    <asp:ListItem Value="473-77">GRENADA</asp:ListItem>
                                    <asp:ListItem Value="590-85">GUADELOUPE</asp:ListItem>
                                    <asp:ListItem Value="671-90">GUAM</asp:ListItem>
                                    <asp:ListItem Value="502-89">GUATEMALA</asp:ListItem>
                                    <asp:ListItem Value="224-84">GUINEA</asp:ListItem>
                                    <asp:ListItem Value="245-91">GUINEA-BISSAU</asp:ListItem>
                                    <asp:ListItem Value="592-92">GUYANA</asp:ListItem>
                                    <asp:ListItem Value="509-97">HAITI</asp:ListItem>
                                    <asp:ListItem Value="39-227">HOLY SEE (VATICAN CITY STATE)</asp:ListItem>
                                    <asp:ListItem Value="503-95">HONDURAS</asp:ListItem>
                                    <asp:ListItem Value="852-93">HONG KONG</asp:ListItem>
                                    <asp:ListItem Value="36-98">HUNGARY</asp:ListItem>
                                    <asp:ListItem Value="354-106">ICELAND</asp:ListItem>
                                    <asp:ListItem Value="91-102">INDIA</asp:ListItem>
                                    <asp:ListItem Value="62-99">INDONESIA</asp:ListItem>
                                    <asp:ListItem Value="98-105">IRAN, ISLAMIC REPUBLIC OF</asp:ListItem>
                                    <asp:ListItem Value="964-104">IRAQ</asp:ListItem>
                                    <asp:ListItem Value="353-100">IRELAND</asp:ListItem>
                                    <asp:ListItem Value="972-101">ISRAEL</asp:ListItem>
                                    <asp:ListItem Value="39-107">ITALY</asp:ListItem>
                                    <asp:ListItem Value="876-108">JAMAICA</asp:ListItem>
                                    <asp:ListItem Value="81-110">JAPAN</asp:ListItem>
                                    <asp:ListItem Value="962-109">JORDAN</asp:ListItem>
                                    <asp:ListItem Value="7-121">KAZAKHSTAN</asp:ListItem>
                                    <asp:ListItem Value="254-111">KENYA</asp:ListItem>
                                    <asp:ListItem Value="686-114">KIRIBATI</asp:ListItem>
                                    <asp:ListItem Value="82-117">KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF</asp:ListItem>
                                    <asp:ListItem Value="82-118">KOREA, REPUBLIC OF</asp:ListItem>
                                    <asp:ListItem Value="965-119">KUWAIT</asp:ListItem>
                                    <asp:ListItem Value="996-112">KYRGYZSTAN</asp:ListItem>
                                    <asp:ListItem Value="856-122">LAO PEOPLE'S DEMOCRATIC REPUBLIC</asp:ListItem>
                                    <asp:ListItem Value="371-131">LATVIA</asp:ListItem>
                                    <asp:ListItem Value="961-123">LEBANON</asp:ListItem>
                                    <asp:ListItem Value="266-128">LESOTHO</asp:ListItem>
                                    <asp:ListItem Value="231-127">LIBERIA</asp:ListItem>
                                    <asp:ListItem Value="218-132">LIBYAN ARAB JAMAHIRIYA</asp:ListItem>
                                    <asp:ListItem Value="423-125">LIECHTENSTEIN</asp:ListItem>
                                    <asp:ListItem Value="370-129">LITHUANIA</asp:ListItem>
                                    <asp:ListItem Value="352-130">LUXEMBOURG</asp:ListItem>
                                    <asp:ListItem Value="853-142">MACAO</asp:ListItem>
                                    <asp:ListItem Value="389-138">MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF</asp:ListItem>
                                    <asp:ListItem Value="261-136">MADAGASCAR</asp:ListItem>
                                    <asp:ListItem Value="265-150">MALAWI</asp:ListItem>
                                    <asp:ListItem Value="60-152">MALAYSIA</asp:ListItem>
                                    <asp:ListItem Value="960-149">MALDIVES</asp:ListItem>
                                    <asp:ListItem Value="223-139">MALI</asp:ListItem>
                                    <asp:ListItem Value="356-147">MALTA</asp:ListItem>
                                    <asp:ListItem Value="692-137">MARSHALL ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="596-144">MARTINIQUE</asp:ListItem>
                                    <asp:ListItem Value="222-145">MAURITANIA</asp:ListItem>
                                    <asp:ListItem Value="230-148">MAURITIUS</asp:ListItem>
                                    <asp:ListItem Value="269-237">MAYOTTE</asp:ListItem>
                                    <asp:ListItem Value="52-151">MEXICO</asp:ListItem>
                                    <asp:ListItem Value="691-72">MICRONESIA, FEDERATED STATES OF</asp:ListItem>
                                    <asp:ListItem Value="373-135">MOLDOVA, REPUBLIC OF</asp:ListItem>
                                    <asp:ListItem Value="377-134">MONACO</asp:ListItem>
                                    <asp:ListItem Value="976-141">MONGOLIA</asp:ListItem>
                                    <asp:ListItem Value="664-146">MONTSERRAT</asp:ListItem>
                                    <asp:ListItem Value="212-133">MOROCCO</asp:ListItem>
                                    <asp:ListItem Value="258-153">MOZAMBIQUE</asp:ListItem>
                                    <asp:ListItem Value="95-140">MYANMAR</asp:ListItem>
                                    <asp:ListItem Value="264-154">NAMIBIA</asp:ListItem>
                                    <asp:ListItem Value="674-163">NAURU</asp:ListItem>
                                    <asp:ListItem Value="977-162">NEPAL</asp:ListItem>
                                    <asp:ListItem Value="31-160">NETHERLANDS</asp:ListItem>
                                    <asp:ListItem Value="599-8">NETHERLANDS ANTILLES</asp:ListItem>
                                    <asp:ListItem Value="687-155">NEW CALEDONIA</asp:ListItem>
                                    <asp:ListItem Value="64-165">NEW ZEALAND</asp:ListItem>
                                    <asp:ListItem Value="505-159">NICARAGUA</asp:ListItem>
                                    <asp:ListItem Value="227-156">NIGER</asp:ListItem>
                                    <asp:ListItem Value="234-158">NIGERIA</asp:ListItem>
                                    <asp:ListItem Value="683-164">NIUE</asp:ListItem>
                                    <asp:ListItem Value="672-157">NORFOLK ISLAND</asp:ListItem>
                                    <asp:ListItem Value="167-143">NORTHERN MARIANA ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="47-161">NORWAY</asp:ListItem>
                                    <asp:ListItem Value="968-166">OMAN</asp:ListItem>
                                    <asp:ListItem Value="92-172">PAKISTAN</asp:ListItem>
                                    <asp:ListItem Value="680-179">PALAU</asp:ListItem>
                                    <asp:ListItem Value="970-177">PALESTINIAN TERRITORY, OCCUPIED</asp:ListItem>
                                    <asp:ListItem Value="507-167">PANAMA</asp:ListItem>
                                    <asp:ListItem Value="675-170">PAPUA NEW GUINEA</asp:ListItem>
                                    <asp:ListItem Value="595-180">PARAGUAY</asp:ListItem>
                                    <asp:ListItem Value="51-168">PERU</asp:ListItem>
                                    <asp:ListItem Value="63-171">PHILIPPINES</asp:ListItem>
                                    <asp:ListItem Value="672-175">PITCAIRN</asp:ListItem>
                                    <asp:ListItem Value="48-173">POLAND</asp:ListItem>
                                    <asp:ListItem Value="351-178">PORTUGAL</asp:ListItem>
                                    <asp:ListItem Value="787-176">PUERTO RICO</asp:ListItem>
                                    <asp:ListItem Value="974-181">QATAR</asp:ListItem>
                                    <asp:ListItem Value="262-182">REUNION</asp:ListItem>
                                    <asp:ListItem Value="40-183">ROMANIA</asp:ListItem>
                                    <asp:ListItem Value="7-184">RUSSIAN FEDERATION</asp:ListItem>
                                    <asp:ListItem Value="250-185">RWANDA</asp:ListItem>
                                    <asp:ListItem Value="290-192">SAINT HELENA</asp:ListItem>
                                    <asp:ListItem Value="186-116">SAINT KITTS AND NEVIS</asp:ListItem>
                                    <asp:ListItem Value="175-124">SAINT LUCIA</asp:ListItem>
                                    <asp:ListItem Value="508-174">SAINT PIERRE AND MIQUELON</asp:ListItem>
                                    <asp:ListItem Value="180-228">SAINT VINCENT AND THE GRENADINES</asp:ListItem>
                                    <asp:ListItem Value="885-235">SAMOA</asp:ListItem>
                                    <asp:ListItem Value="378-197">SAN MARINO</asp:ListItem>
                                    <asp:ListItem Value="239-201">SAO TOME AND PRINCIPE</asp:ListItem>
                                    <asp:ListItem Value="966-186">SAUDI ARABIA</asp:ListItem>
                                    <asp:ListItem Value="221-198">SENEGAL</asp:ListItem>
                                    <asp:ListItem Value="381-50">SERBIA AND MONTENEGRO</asp:ListItem>
                                    <asp:ListItem Value="248-188">SEYCHELLES</asp:ListItem>
                                    <asp:ListItem Value="232-196">SIERRA LEONE</asp:ListItem>
                                    <asp:ListItem Value="65-191">SINGAPORE</asp:ListItem>
                                    <asp:ListItem Value="421-195">SLOVAKIA</asp:ListItem>
                                    <asp:ListItem Value="386-193">SLOVENIA</asp:ListItem>
                                    <asp:ListItem Value="677-187">SOLOMON ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="252-199">SOMALIA</asp:ListItem>
                                    <asp:ListItem Value="27-238">SOUTH AFRICA</asp:ListItem>
                                    <asp:ListItem Value="34-67">SPAIN</asp:ListItem>
                                    <asp:ListItem Value="94-126">SRI LANKA</asp:ListItem>
                                    <asp:ListItem Value="249-189">SUDAN</asp:ListItem>
                                    <asp:ListItem Value="597-200">SURINAME</asp:ListItem>
                                    <asp:ListItem Value="47-194">SVALBARD AND JAN MAYEN</asp:ListItem>
                                    <asp:ListItem Value="268-204">SWAZILAND</asp:ListItem>
                                    <asp:ListItem Value="46-190">SWEDEN</asp:ListItem>
                                    <asp:ListItem Value="41-42">SWITZERLAND</asp:ListItem>
                                    <asp:ListItem Value="963-203">SYRIAN ARAB REPUBLIC</asp:ListItem>
                                    <asp:ListItem Value="886-219">TAIWAN, PROVINCE OF CHINA</asp:ListItem>
                                    <asp:ListItem Value="992-210">TAJIKISTAN</asp:ListItem>
                                    <asp:ListItem Value="255-220">TANZANIA, UNITED REPUBLIC OF</asp:ListItem>
                                    <asp:ListItem Value="66-209">THAILAND</asp:ListItem>
                                    <asp:ListItem Value="670-212">TIMOR-LESTE</asp:ListItem>
                                    <asp:ListItem Value="228-208">TOGO</asp:ListItem>
                                    <asp:ListItem Value="690-211">TOKELAU</asp:ListItem>
                                    <asp:ListItem Value="676-215">TONGA</asp:ListItem>
                                    <asp:ListItem Value="186-217">TRINIDAD AND TOBAGO</asp:ListItem>
                                    <asp:ListItem Value="216-214">TUNISIA</asp:ListItem>
                                    <asp:ListItem Value="90-216">TURKEY</asp:ListItem>
                                    <asp:ListItem Value="993-213">TURKMENISTAN</asp:ListItem>
                                    <asp:ListItem Value="164-205">TURKS AND CAICOS ISLANDS</asp:ListItem>
                                    <asp:ListItem Value="688-218">TUVALU</asp:ListItem>
                                    <asp:ListItem Value="256-222">UGANDA</asp:ListItem>
                                    <asp:ListItem Value="380-221">UKRAINE</asp:ListItem>
                                    <asp:ListItem Value="971-2">UNITED ARAB EMIRATES</asp:ListItem>
                                    <asp:ListItem Value="44-76">UNITED KINGDOM</asp:ListItem>
                                    <asp:ListItem Value="598-225">URUGUAY</asp:ListItem>
                                    <asp:ListItem Value="998-226">UZBEKISTAN</asp:ListItem>
                                    <asp:ListItem Value="678-233">VANUATU</asp:ListItem>
                                    <asp:ListItem Value="58-229">VENEZUELA</asp:ListItem>
                                    <asp:ListItem Value="84-232">VIETNAM</asp:ListItem>
                                    <asp:ListItem Value="128-230">VIRGIN ISLANDS, BRITISH</asp:ListItem>
                                    <asp:ListItem Value="134-231">VIRGIN ISLANDS, U.S.</asp:ListItem>
                                    <asp:ListItem Value="681-234">WALLIS AND FUTUNA</asp:ListItem>
                                    <asp:ListItem Value="212-65">WESTERN SAHARA</asp:ListItem>
                                    <asp:ListItem Value="967-236">YEMEN</asp:ListItem>
                                    <asp:ListItem Value="260-239">ZAMBIA</asp:ListItem>
                                    <asp:ListItem Value="263-240">ZIMBABWE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Your Number
                            </td>
                            <td>
                                <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="width:20%;" ChildrenAsTriggers="true">
                        <ContentTemplate>
        <asp:TextBox ID="txtPPhoneCode" runat="server" ReadOnly="true" style="width:100%;"></asp:TextBox>
        
        </ContentTemplate>
        
                        <Triggers>
                           <asp:AsyncPostBackTrigger ControlID="ddlPCountry" EventName="SelectedIndexChanged" />
                           
                        </Triggers>
          </asp:UpdatePanel> --%>
                                <asp:TextBox ID="txtPPhoneCode" runat="server" CssClass="jqtranformdone" ReadOnly="true"
                                    Style="width: 13%;"></asp:TextBox>
                                <asp:TextBox ID="txtPPhoneNumber" Text="Phone Number*" runat="server" CssClass="jqtranformdone"
                                    Style="width: 71%;" MaxLength="49" onfocus="javascript: if(this.value == 'Phone Number*'){ this.value = ''; }"
                                    onblur="javascript: if(this.value==''){this.value='Phone Number*';}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" CssClass="jqtranformdone" runat="server" ReadOnly="true"
                                    Width="92%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Alternate Email
                            </td>
                            <td valign="middle">
                                <asp:TextBox ID="txtAlternateEmail" CssClass="jqtranformdone" runat="server" Width="92%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="chunchunfooter">
                    <a href="javascript:;" data-dismiss="modal" aria-hidden="true" role="button" class="pull-right">
                        <img src="../Area/assets/img/btn-cancel.png" alt="" /></a> <a href="javascript:void(0);"
                            data-dismiss="modal" aria-hidden="true" role="button" class="pull-right" style="margin-right: 10px;">
                        </a>
                    <%--<asp:ImageButton ID="ContactInformation" ImageUrl="/Area/assets/img/btn-save.png" 
              runat="server" alt="Save" onclick="ContactInformation_Click" CausesValidation="false" /> --%>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End Modal Edit Profile Individual-->
<!-- Modal Edit Business  Profile -->
<div id="xEditProfileB" class="modal hide theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            x</button>
        <h3>
            Complete your profile</h3>
    </div>
    <div class="modal-body">
        <div class="row-fluid xEditFields ">
            <div class="span6 thenewheight">
                <h3 class="bottom-fifteen">
                    Company Information <a href="javascript:void(0);" class="EditPro xLeft">Edit</a></h3>
                <p>
                    Company Name<span><asp:Label ID="lblCompanyname" runat="server"></asp:Label></span></p>
                <p>
                    Company Website<span><asp:Label ID="lblCompanyWebsite" runat="server"></asp:Label></span></p>
                <p>
                    Industry <span>
                        <asp:Label ID="lblIndustry" runat="server"></asp:Label></span></p>
                <p>
                    Estimated Employees <span>
                        <asp:Label ID="lblEstimatedEmployees" runat="server"></asp:Label></span></p>
                <p>
                    Representative Name <span>
                        <asp:Label ID="lblRepresentativeName" runat="server"></asp:Label></span></p>
            </div>
            <div class="span6">
                <h3 class="bottom-fifteen">
                    Contact Information <a href="javascript:void(0);" class="EditPro xRight" onclick="FillCCountryCode();">
                        Edit</a></h3>
                <p>
                    Your Location <span>
                        <asp:Label ID="lblCLocation" runat="server"></asp:Label></span></p>
                <p>
                    Your Number <span>
                        <asp:Label ID="lblCphoneNumber" runat="server"></asp:Label></span></p>
                <p>
                    Your Email<span><asp:Label ID="lblCEmail" runat="server"></asp:Label></span></p>
            </div>
            <div class="xHiddenTable xbox">
                <div class="XbInner">
                    <form class="xStyledForm">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tbody>
                            <tr>
                                <td width="40%">
                                    Company Name
                                </td>
                                <td width="60%">
                                    <asp:TextBox ID="txtCompanyName" Width="90%" Text="Company Name *" CssClass="jqtranformdone"
                                        runat="server" MaxLength="49" onfocus="javascript: if(this.value == 'Company Name *'){ this.value = ''; }"
                                        onblur="javascript: if(this.value==''){this.value='Company Name *';}"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Company Website
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompanyWebsite" Text="Company Website *" Width="90%" CssClass="jqtranformdone"
                                        runat="server" MaxLength="49" onfocus="javascript: if(this.value == 'Company Website *'){ this.value = ''; }"
                                        onblur="javascript: if(this.value==''){this.value='Company Website *';}"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Industry
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIndustry" Text="Industry *" runat="server" CssClass="jqtranformdone"
                                        Width="90%" MaxLength="149" onfocus="javascript: if(this.value == 'Industry *'){ this.value = ''; }"
                                        onblur="javascript: if(this.value==''){this.value='Industry *';}"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Employees
                                </td>
                                <td valign="middle">
                                    <asp:DropDownList ID="ddlEstimatedEmployees" runat="server" Width="180%">
                                        <asp:ListItem Selected="True" Value="0">Employees</asp:ListItem>
                                        <asp:ListItem Text="100-200" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="300-500" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="600-700" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="800-1000" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="1000-5000" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6000-7000" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Representative Name
                                </td>
                                <td valign="middle">
                                    <asp:TextBox ID="txtRepresentativeName" Text="Representative Name *" Width="90%"
                                        CssClass="jqtranformdone" runat="server" MaxLength="49" onfocus="javascript: if(this.value == 'Representative Name *'){ this.value = ''; }"
                                        onblur="javascript: if(this.value==''){this.value='Representative Name *';}"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    </form>
                </div>
                <div class="chunchunfooter">
                    <a href="javascript:;" data-dismiss="modal" aria-hidden="true" role="button" class="pull-right">
                        <img src="../Area/assets/img/btn-cancel.png" alt=""></a> <a href="javascript:;" data-dismiss="modal"
                            aria-hidden="true" role="button" class="pull-right" style="margin-right: 10px;">
                            <%--<asp:ImageButton ID="SaveCompanyDetails" ImageUrl="/Area/assets/img/btn-save.png" 
              runat="server" alt="Save" onclick="SaveCompanyDetails_Click" />--%>
                        </a>
                </div>
            </div>
            <div class="xHiddenTable2 xbox">
                <div class="XbInner">
                    <div class="xStyledForm">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="40%">
                                    Your Location
                                </td>
                                <td width="60%">
                                    <asp:DropDownList ID="ddlCLocation" runat="server" onchange="FillCCountryCode();"
                                        Width="182%">
                                        <asp:ListItem Selected="True" Value="0">Country</asp:ListItem>
                                        <asp:ListItem Value="1-224">UNITED STATES</asp:ListItem>
                                        <asp:ListItem Value="93-3">AFGHANISTAN</asp:ListItem>
                                        <asp:ListItem Value="358-16">�LAND ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="355-6">ALBANIA</asp:ListItem>
                                        <asp:ListItem Value="213-61">ALGERIA</asp:ListItem>
                                        <asp:ListItem Value="168-12">AMERICAN SAMOA</asp:ListItem>
                                        <asp:ListItem Value="376-1">ANDORRA</asp:ListItem>
                                        <asp:ListItem Value="244-9">ANGOLA</asp:ListItem>
                                        <asp:ListItem Value="264-5">ANGUILLA</asp:ListItem>
                                        <asp:ListItem Value="167-10">ANTARCTICA</asp:ListItem>
                                        <asp:ListItem Value="268-4">ANTIGUA AND BARBUDA</asp:ListItem>
                                        <asp:ListItem Value="54-11">ARGENTINA</asp:ListItem>
                                        <asp:ListItem Value="374-7">ARMENIA</asp:ListItem>
                                        <asp:ListItem Value="297-15">ARUBA</asp:ListItem>
                                        <asp:ListItem Value="61-14">AUSTRALIA</asp:ListItem>
                                        <asp:ListItem Value="43-13">AUSTRIA</asp:ListItem>
                                        <asp:ListItem Value="994-17">AZERBAIJAN</asp:ListItem>
                                        <asp:ListItem Value="242-31">BAHAMAS</asp:ListItem>
                                        <asp:ListItem Value="973-24">BAHRAIN</asp:ListItem>
                                        <asp:ListItem Value="880-20">BANGLADESH</asp:ListItem>
                                        <asp:ListItem Value="246-19">BARBADOS</asp:ListItem>
                                        <asp:ListItem Value="375-35">BELARUS</asp:ListItem>
                                        <asp:ListItem Value="32-21">BELGIUM</asp:ListItem>
                                        <asp:ListItem Value="501-36">BELIZE</asp:ListItem>
                                        <asp:ListItem Value="229-26">BENIN</asp:ListItem>
                                        <asp:ListItem Value="441-27">BERMUDA</asp:ListItem>
                                        <asp:ListItem Value="975-32">BHUTAN</asp:ListItem>
                                        <asp:ListItem Value="591-29">BOLIVIA</asp:ListItem>
                                        <asp:ListItem Value="387-18">BOSNIA AND HERZEGOVINA</asp:ListItem>
                                        <asp:ListItem Value="267-34">BOTSWANA</asp:ListItem>
                                        <asp:ListItem Value="55-30">BRAZIL</asp:ListItem>
                                        <asp:ListItem Value="246-103">BRITISH INDIAN OCEAN TERRITORY</asp:ListItem>
                                        <asp:ListItem Value="673-28">BRUNEI DARUSSALAM</asp:ListItem>
                                        <asp:ListItem Value="359-23">BULGARIA</asp:ListItem>
                                        <asp:ListItem Value="226-22">BURKINA FASO</asp:ListItem>
                                        <asp:ListItem Value="257-25">BURUNDI</asp:ListItem>
                                        <asp:ListItem Value="855-113">CAMBODIA</asp:ListItem>
                                        <asp:ListItem Value="237-46">CAMEROON</asp:ListItem>
                                        <asp:ListItem Value="1-37">CANADA</asp:ListItem>
                                        <asp:ListItem Value="238-52">CAPE VERDE</asp:ListItem>
                                        <asp:ListItem Value="345-120">CAYMAN ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="236-40">CENTRAL AFRICAN REPUBLIC</asp:ListItem>
                                        <asp:ListItem Value="235-206">CHAD</asp:ListItem>
                                        <asp:ListItem Value="56-45">CHILE</asp:ListItem>
                                        <asp:ListItem Value="86-47">CHINA</asp:ListItem>
                                        <asp:ListItem Value="672-53">CHRISTMAS ISLAND</asp:ListItem>
                                        <asp:ListItem Value="672-38">COCOS (KEELING) ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="57-48">COLOMBIA</asp:ListItem>
                                        <asp:ListItem Value="269-115">COMOROS</asp:ListItem>
                                        <asp:ListItem Value="242-41">CONGO</asp:ListItem>
                                        <asp:ListItem Value="242-39">CONGO, THE DEMOCRATIC REPUBLIC OF THE</asp:ListItem>
                                        <asp:ListItem Value="682-44">COOK ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="506-49">COSTA RICA</asp:ListItem>
                                        <asp:ListItem Value="225-43">COTE D'IVOIRE</asp:ListItem>
                                        <asp:ListItem Value="385-96">CROATIA</asp:ListItem>
                                        <asp:ListItem Value="53-51">CUBA</asp:ListItem>
                                        <asp:ListItem Value="357-54">CYPRUS</asp:ListItem>
                                        <asp:ListItem Value="420-55">CZECH REPUBLIC</asp:ListItem>
                                        <asp:ListItem Value="45-58">DENMARK</asp:ListItem>
                                        <asp:ListItem Value="253-57">DJIBOUTI</asp:ListItem>
                                        <asp:ListItem Value="176-59">DOMINICA</asp:ListItem>
                                        <asp:ListItem Value="809-60">DOMINICAN REPUBLIC</asp:ListItem>
                                        <asp:ListItem Value="593-62">ECUADOR</asp:ListItem>
                                        <asp:ListItem Value="20-64">EGYPT</asp:ListItem>
                                        <asp:ListItem Value="503-202">EL SALVADOR</asp:ListItem>
                                        <asp:ListItem Value="240-86">EQUATORIAL GUINEA</asp:ListItem>
                                        <asp:ListItem Value="291-66">ERITREA</asp:ListItem>
                                        <asp:ListItem Value="372-63">ESTONIA</asp:ListItem>
                                        <asp:ListItem Value="251-68">ETHIOPIA</asp:ListItem>
                                        <asp:ListItem Value="500-71">FALKLAND ISLANDS (MALVINAS)</asp:ListItem>
                                        <asp:ListItem Value="298-73">FAROE ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="679-70">FIJI</asp:ListItem>
                                        <asp:ListItem Value="358-69">FINLAND</asp:ListItem>
                                        <asp:ListItem Value="33-74">FRANCE</asp:ListItem>
                                        <asp:ListItem Value="594-79">FRENCH GUIANA</asp:ListItem>
                                        <asp:ListItem Value="689-169">FRENCH POLYNESIA</asp:ListItem>
                                        <asp:ListItem Value="689-207">FRENCH SOUTHERN TERRITORIES</asp:ListItem>
                                        <asp:ListItem Value="241-75">GABON</asp:ListItem>
                                        <asp:ListItem Value="220-83">GAMBIA</asp:ListItem>
                                        <asp:ListItem Value="995-78">GEORGIA</asp:ListItem>
                                        <asp:ListItem Value="49-56">GERMANY</asp:ListItem>
                                        <asp:ListItem Value="233-80">GHANA</asp:ListItem>
                                        <asp:ListItem Value="350-81">GIBRALTAR</asp:ListItem>
                                        <asp:ListItem Value="30-87">GREECE</asp:ListItem>
                                        <asp:ListItem Value="299-82">GREENLAND</asp:ListItem>
                                        <asp:ListItem Value="473-77">GRENADA</asp:ListItem>
                                        <asp:ListItem Value="590-85">GUADELOUPE</asp:ListItem>
                                        <asp:ListItem Value="671-90">GUAM</asp:ListItem>
                                        <asp:ListItem Value="502-89">GUATEMALA</asp:ListItem>
                                        <asp:ListItem Value="224-84">GUINEA</asp:ListItem>
                                        <asp:ListItem Value="245-91">GUINEA-BISSAU</asp:ListItem>
                                        <asp:ListItem Value="592-92">GUYANA</asp:ListItem>
                                        <asp:ListItem Value="509-97">HAITI</asp:ListItem>
                                        <asp:ListItem Value="39-227">HOLY SEE (VATICAN CITY STATE)</asp:ListItem>
                                        <asp:ListItem Value="503-95">HONDURAS</asp:ListItem>
                                        <asp:ListItem Value="852-93">HONG KONG</asp:ListItem>
                                        <asp:ListItem Value="36-98">HUNGARY</asp:ListItem>
                                        <asp:ListItem Value="354-106">ICELAND</asp:ListItem>
                                        <asp:ListItem Value="91-102">INDIA</asp:ListItem>
                                        <asp:ListItem Value="62-99">INDONESIA</asp:ListItem>
                                        <asp:ListItem Value="98-105">IRAN, ISLAMIC REPUBLIC OF</asp:ListItem>
                                        <asp:ListItem Value="964-104">IRAQ</asp:ListItem>
                                        <asp:ListItem Value="353-100">IRELAND</asp:ListItem>
                                        <asp:ListItem Value="972-101">ISRAEL</asp:ListItem>
                                        <asp:ListItem Value="39-107">ITALY</asp:ListItem>
                                        <asp:ListItem Value="876-108">JAMAICA</asp:ListItem>
                                        <asp:ListItem Value="81-110">JAPAN</asp:ListItem>
                                        <asp:ListItem Value="962-109">JORDAN</asp:ListItem>
                                        <asp:ListItem Value="7-121">KAZAKHSTAN</asp:ListItem>
                                        <asp:ListItem Value="254-111">KENYA</asp:ListItem>
                                        <asp:ListItem Value="686-114">KIRIBATI</asp:ListItem>
                                        <asp:ListItem Value="82-117">KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF</asp:ListItem>
                                        <asp:ListItem Value="82-118">KOREA, REPUBLIC OF</asp:ListItem>
                                        <asp:ListItem Value="965-119">KUWAIT</asp:ListItem>
                                        <asp:ListItem Value="996-112">KYRGYZSTAN</asp:ListItem>
                                        <asp:ListItem Value="856-122">LAO PEOPLE'S DEMOCRATIC REPUBLIC</asp:ListItem>
                                        <asp:ListItem Value="371-131">LATVIA</asp:ListItem>
                                        <asp:ListItem Value="961-123">LEBANON</asp:ListItem>
                                        <asp:ListItem Value="266-128">LESOTHO</asp:ListItem>
                                        <asp:ListItem Value="231-127">LIBERIA</asp:ListItem>
                                        <asp:ListItem Value="218-132">LIBYAN ARAB JAMAHIRIYA</asp:ListItem>
                                        <asp:ListItem Value="423-125">LIECHTENSTEIN</asp:ListItem>
                                        <asp:ListItem Value="370-129">LITHUANIA</asp:ListItem>
                                        <asp:ListItem Value="352-130">LUXEMBOURG</asp:ListItem>
                                        <asp:ListItem Value="853-142">MACAO</asp:ListItem>
                                        <asp:ListItem Value="389-138">MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF</asp:ListItem>
                                        <asp:ListItem Value="261-136">MADAGASCAR</asp:ListItem>
                                        <asp:ListItem Value="265-150">MALAWI</asp:ListItem>
                                        <asp:ListItem Value="60-152">MALAYSIA</asp:ListItem>
                                        <asp:ListItem Value="960-149">MALDIVES</asp:ListItem>
                                        <asp:ListItem Value="223-139">MALI</asp:ListItem>
                                        <asp:ListItem Value="356-147">MALTA</asp:ListItem>
                                        <asp:ListItem Value="692-137">MARSHALL ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="596-144">MARTINIQUE</asp:ListItem>
                                        <asp:ListItem Value="222-145">MAURITANIA</asp:ListItem>
                                        <asp:ListItem Value="230-148">MAURITIUS</asp:ListItem>
                                        <asp:ListItem Value="269-237">MAYOTTE</asp:ListItem>
                                        <asp:ListItem Value="52-151">MEXICO</asp:ListItem>
                                        <asp:ListItem Value="691-72">MICRONESIA, FEDERATED STATES OF</asp:ListItem>
                                        <asp:ListItem Value="373-135">MOLDOVA, REPUBLIC OF</asp:ListItem>
                                        <asp:ListItem Value="377-134">MONACO</asp:ListItem>
                                        <asp:ListItem Value="976-141">MONGOLIA</asp:ListItem>
                                        <asp:ListItem Value="664-146">MONTSERRAT</asp:ListItem>
                                        <asp:ListItem Value="212-133">MOROCCO</asp:ListItem>
                                        <asp:ListItem Value="258-153">MOZAMBIQUE</asp:ListItem>
                                        <asp:ListItem Value="95-140">MYANMAR</asp:ListItem>
                                        <asp:ListItem Value="264-154">NAMIBIA</asp:ListItem>
                                        <asp:ListItem Value="674-163">NAURU</asp:ListItem>
                                        <asp:ListItem Value="977-162">NEPAL</asp:ListItem>
                                        <asp:ListItem Value="31-160">NETHERLANDS</asp:ListItem>
                                        <asp:ListItem Value="599-8">NETHERLANDS ANTILLES</asp:ListItem>
                                        <asp:ListItem Value="687-155">NEW CALEDONIA</asp:ListItem>
                                        <asp:ListItem Value="64-165">NEW ZEALAND</asp:ListItem>
                                        <asp:ListItem Value="505-159">NICARAGUA</asp:ListItem>
                                        <asp:ListItem Value="227-156">NIGER</asp:ListItem>
                                        <asp:ListItem Value="234-158">NIGERIA</asp:ListItem>
                                        <asp:ListItem Value="683-164">NIUE</asp:ListItem>
                                        <asp:ListItem Value="672-157">NORFOLK ISLAND</asp:ListItem>
                                        <asp:ListItem Value="167-143">NORTHERN MARIANA ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="47-161">NORWAY</asp:ListItem>
                                        <asp:ListItem Value="968-166">OMAN</asp:ListItem>
                                        <asp:ListItem Value="92-172">PAKISTAN</asp:ListItem>
                                        <asp:ListItem Value="680-179">PALAU</asp:ListItem>
                                        <asp:ListItem Value="970-177">PALESTINIAN TERRITORY, OCCUPIED</asp:ListItem>
                                        <asp:ListItem Value="507-167">PANAMA</asp:ListItem>
                                        <asp:ListItem Value="675-170">PAPUA NEW GUINEA</asp:ListItem>
                                        <asp:ListItem Value="595-180">PARAGUAY</asp:ListItem>
                                        <asp:ListItem Value="51-168">PERU</asp:ListItem>
                                        <asp:ListItem Value="63-171">PHILIPPINES</asp:ListItem>
                                        <asp:ListItem Value="672-175">PITCAIRN</asp:ListItem>
                                        <asp:ListItem Value="48-173">POLAND</asp:ListItem>
                                        <asp:ListItem Value="351-178">PORTUGAL</asp:ListItem>
                                        <asp:ListItem Value="787-176">PUERTO RICO</asp:ListItem>
                                        <asp:ListItem Value="974-181">QATAR</asp:ListItem>
                                        <asp:ListItem Value="262-182">REUNION</asp:ListItem>
                                        <asp:ListItem Value="40-183">ROMANIA</asp:ListItem>
                                        <asp:ListItem Value="7-184">RUSSIAN FEDERATION</asp:ListItem>
                                        <asp:ListItem Value="250-185">RWANDA</asp:ListItem>
                                        <asp:ListItem Value="290-192">SAINT HELENA</asp:ListItem>
                                        <asp:ListItem Value="186-116">SAINT KITTS AND NEVIS</asp:ListItem>
                                        <asp:ListItem Value="175-124">SAINT LUCIA</asp:ListItem>
                                        <asp:ListItem Value="508-174">SAINT PIERRE AND MIQUELON</asp:ListItem>
                                        <asp:ListItem Value="180-228">SAINT VINCENT AND THE GRENADINES</asp:ListItem>
                                        <asp:ListItem Value="885-235">SAMOA</asp:ListItem>
                                        <asp:ListItem Value="378-197">SAN MARINO</asp:ListItem>
                                        <asp:ListItem Value="239-201">SAO TOME AND PRINCIPE</asp:ListItem>
                                        <asp:ListItem Value="966-186">SAUDI ARABIA</asp:ListItem>
                                        <asp:ListItem Value="221-198">SENEGAL</asp:ListItem>
                                        <asp:ListItem Value="381-50">SERBIA AND MONTENEGRO</asp:ListItem>
                                        <asp:ListItem Value="248-188">SEYCHELLES</asp:ListItem>
                                        <asp:ListItem Value="232-196">SIERRA LEONE</asp:ListItem>
                                        <asp:ListItem Value="65-191">SINGAPORE</asp:ListItem>
                                        <asp:ListItem Value="421-195">SLOVAKIA</asp:ListItem>
                                        <asp:ListItem Value="386-193">SLOVENIA</asp:ListItem>
                                        <asp:ListItem Value="677-187">SOLOMON ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="252-199">SOMALIA</asp:ListItem>
                                        <asp:ListItem Value="27-238">SOUTH AFRICA</asp:ListItem>
                                        <asp:ListItem Value="34-67">SPAIN</asp:ListItem>
                                        <asp:ListItem Value="94-126">SRI LANKA</asp:ListItem>
                                        <asp:ListItem Value="249-189">SUDAN</asp:ListItem>
                                        <asp:ListItem Value="597-200">SURINAME</asp:ListItem>
                                        <asp:ListItem Value="47-194">SVALBARD AND JAN MAYEN</asp:ListItem>
                                        <asp:ListItem Value="268-204">SWAZILAND</asp:ListItem>
                                        <asp:ListItem Value="46-190">SWEDEN</asp:ListItem>
                                        <asp:ListItem Value="41-42">SWITZERLAND</asp:ListItem>
                                        <asp:ListItem Value="963-203">SYRIAN ARAB REPUBLIC</asp:ListItem>
                                        <asp:ListItem Value="886-219">TAIWAN, PROVINCE OF CHINA</asp:ListItem>
                                        <asp:ListItem Value="992-210">TAJIKISTAN</asp:ListItem>
                                        <asp:ListItem Value="255-220">TANZANIA, UNITED REPUBLIC OF</asp:ListItem>
                                        <asp:ListItem Value="66-209">THAILAND</asp:ListItem>
                                        <asp:ListItem Value="670-212">TIMOR-LESTE</asp:ListItem>
                                        <asp:ListItem Value="228-208">TOGO</asp:ListItem>
                                        <asp:ListItem Value="690-211">TOKELAU</asp:ListItem>
                                        <asp:ListItem Value="676-215">TONGA</asp:ListItem>
                                        <asp:ListItem Value="186-217">TRINIDAD AND TOBAGO</asp:ListItem>
                                        <asp:ListItem Value="216-214">TUNISIA</asp:ListItem>
                                        <asp:ListItem Value="90-216">TURKEY</asp:ListItem>
                                        <asp:ListItem Value="993-213">TURKMENISTAN</asp:ListItem>
                                        <asp:ListItem Value="164-205">TURKS AND CAICOS ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="688-218">TUVALU</asp:ListItem>
                                        <asp:ListItem Value="256-222">UGANDA</asp:ListItem>
                                        <asp:ListItem Value="380-221">UKRAINE</asp:ListItem>
                                        <asp:ListItem Value="971-2">UNITED ARAB EMIRATES</asp:ListItem>
                                        <asp:ListItem Value="44-76">UNITED KINGDOM</asp:ListItem>
                                        <asp:ListItem Value="598-225">URUGUAY</asp:ListItem>
                                        <asp:ListItem Value="998-226">UZBEKISTAN</asp:ListItem>
                                        <asp:ListItem Value="678-233">VANUATU</asp:ListItem>
                                        <asp:ListItem Value="58-229">VENEZUELA</asp:ListItem>
                                        <asp:ListItem Value="84-232">VIETNAM</asp:ListItem>
                                        <asp:ListItem Value="128-230">VIRGIN ISLANDS, BRITISH</asp:ListItem>
                                        <asp:ListItem Value="134-231">VIRGIN ISLANDS, U.S.</asp:ListItem>
                                        <asp:ListItem Value="681-234">WALLIS AND FUTUNA</asp:ListItem>
                                        <asp:ListItem Value="212-65">WESTERN SAHARA</asp:ListItem>
                                        <asp:ListItem Value="967-236">YEMEN</asp:ListItem>
                                        <asp:ListItem Value="260-239">ZAMBIA</asp:ListItem>
                                        <asp:ListItem Value="263-240">ZIMBABWE</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Your Number
                                </td>
                                <td>
                                    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" style="width:20%;">
                        <ContentTemplate>
        <asp:TextBox ID="txtCLPhoneCode" runat="server" ReadOnly="true" style="width:100%;"></asp:TextBox>
        
        </ContentTemplate>
                        <Triggers>
                           <asp:AsyncPostBackTrigger ControlID="ddlCLocation" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel> 

           <asp:TextBox ID="txtCLPhoneNumber" runat="server" style="width:65%;  margin-left: 67px; margin-top: -39px;"></asp:TextBox>                     --%>
                                    <asp:TextBox ID="txtCLPhoneCode" CssClass="jqtranformdone" runat="server" ReadOnly="true"
                                        Style="width: 13%;"></asp:TextBox>
                                    <asp:TextBox ID="txtCLPhoneNumber" CssClass="jqtranformdone" runat="server" Text="Phone Number*"
                                        Style="width: 70%;" MaxLength="20" onfocus="javascript: if(this.value == 'Phone Number*'){ this.value = ''; }"
                                        onblur="javascript: if(this.value==''){this.value='Phone Number*';}"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email Address
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCEmailAddress" CssClass="jqtranformdone" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Alternate Email
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCAlternateEmail" CssClass="jqtranformdone" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="chunchunfooter">
                    <a href="javascript:;" data-dismiss="modal" aria-hidden="true" role="button" class="pull-right">
                        <img src="../Area/assets/img/btn-cancel.png" alt="" /></a> <a href="javascript:void(0);"
                            class="pull-right" style="margin-right: 10px;">
                            <%--<asp:ImageButton ID="SaveCompanyContactDetails" ImageUrl="/Area/assets/img/btn-save.png" runat="server" alt="Save" onclick="SaveCompanyContactDetails_Click" />--%>
                        </a>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End Modal Business Profile-->
<!-- Change Password  -->
<%--<div id="myModal_ChangePassword" class="modal hide theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            �</button>
        <h3>
            Account Settings</h3>
    </div>
    <div class="modal-body">
        <h2 style="font-size: 16px; line-height: 100%; margin-top: 0; font-weight: bold;
            text-rendering: optimizelegibility;">
            Change Password</h2>
        <p>
            This password is used to log into your account area as well as acts as a key in
            case you forget your master password of your security applications.
        </p>
        <div align="center">
            <table width="70%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;
                border-spacing: 0; color: #666666; font: 11px 'LucidaGrande';">
                <tr>
                    <td>
                        Current Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="jqtranformdone codecurrentpassword" MaxLength="20">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        New Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="jqtranformdone codenewpassword" MaxLength="20" 
                            onkeyup='javascript:ValidatePasswordStrength();' onkeypress="javascript:ValidatePasswordStrength();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtRetypeNewPassword" runat="server" MaxLength="20" TextMode="Password" CssClass="jqtranformdone codeconfirmpassword"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <div class="row-fluid">
                            <div id="progressbar" class="progress progress-success span6">
                                <div id="progress" class="bar">
                                </div>
                            </div>
                            <div id="complexity" class="span6">
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblError" runat="server" CssClass="errormsg red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="modal-footer">
            <div class="row-fluid">
                <div class="span12">
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" ForeColor="White"
                        CssClass="xBook-button-normal button " ValidationGroup="changepassword" OnClientClick="return validateChangePassword();" />
                    <button class="xBook-button-back" data-toggle="modal" data-dismiss="modal">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>
</div>--%>
<div id="myModal_ChangePassword" class="modal hide theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="javascript:ClearPassword();">
            x</button>
        <h3>
            Account Settings</h3>
    </div>
    <div>
        <div align="center">
            <iframe id="iframeChangePwd" src="../changepassword.aspx" width="100%" height="332px"
                frameborder="0" scrolling="no"></iframe>
                
                    <button id="paswdCancel" data-dismiss="modal" data-toggle="modal" class="xBook-button-back"
                data-original-title="" title="" style="display: none">
                Cancel</button>
        </div>
    </div>
</div>
<!-- end Change Password  -->
<!-- Modal Remove Cover Photo -->
<div id="xRemoveCoverPhoto" class="modal hide theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            x</button>
        <h3>
            Remove Photo</h3>
    </div>
    <div class="modal-body">
        <div class="row-fluid">
            <div class="span12">
                <p>
                    Do you wish to remove your Cover photo permanently?</p>
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <div class="row-fluid">
            <div class="span6">
            </div>
            <div class="span6">
             <asp:Button ID="lnkRemoveCoverPhoto" Text="Remove Photo" OnClick="btnRemoveCoverPhoto_Click"
                    runat="server" CssClass="xBook-button-normal button " />    
                <button data-dismiss="modal" data-toggle="modal" class="xBook-button-back" data-original-title=""
                    title="">
                    Cancel</button>
            </div>
        </div>
    </div>
</div>
<!-- End Modal -->
<!-- Modal Remove Profile Photo -->
<div id="xRemoveProfilePhoto" class="modal hide theModals" tabindex="-1" role="dialog"
    aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
            x</button>
        <h3>
            Remove Photo</h3>
    </div>
    <div class="modal-body">
        <div class="row-fluid">
            <div class="span12">
                <p>
                    Do you wish to remove your Profile photo permanently?</p>
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <div class="row-fluid">
            <div class="span6">
            </div>
            <div class="span6">
                <asp:Button ID="lnkRemoveProfilePhoto" Text="Remove Photo" OnClick="btnRemoveProfilePhoto_Click"
                    runat="server" CssClass="xBook-button-normal button " />
                <button data-dismiss="modal" data-toggle="modal" class="xBook-button-back" data-original-title=""
                    title="">
                    Cancel</button>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdnValue" runat="server" />
<!-- End Modal -->
<!-- NeedHelp-->
    <div id="NeedHelp" class="modal hide theModals" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true" style="width:550px !important;">
        <div class="modal-header">
            <button type="button" class="close" onclick="javascript:ClearText();" data-dismiss="modal"
                aria-hidden="true">
                x</button>
            <h3>
                Need help?</h3>
        </div>
        <div class="modal-body">
            <div class="row-fluid">
               
                <div class="span12">
                    <div class="xbox-with-heading">                        
                        <div class="xbox-content">
                            <p>
                             Please send us your query, we’ll get back to you shortly.</p>
                            <asp:TextBox ID="txtPMsg" runat="server" TextMode="MultiLine" CssClass="txtarea codegetassistance "
                                MaxLength="3000" Width="461px" Height="72px" EnableViewState="true"></asp:TextBox>
                            <div  style="float:right;padding-bottom: 15px;padding-top: 9px;">
                         
                                <asp:Label ID="lblPMsgGetAssistance" Width="245px" runat="server" CssClass="errormsggetassistance red"></asp:Label>
                                  <asp:HiddenField ID="hfPCandidateCode2" runat="server" />
                                <a href="javascript:NeedHelp();" id="agetassistance" class="xBook-button-normal">
                                Submit</a>
                                
                            </div>
                          
                           
                           
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
    <!-- End NeedHelp -->
<!--#include virtual="~/AccountArea/accountarea.asp" -->
<style type="text/css">
    #uploadcover
    {
        display: none !important;
    }
</style>
<%--<script type="text/javascript">
    $(document).ready(function () {
        $('#lnkUpload2').click(function () {
            $('#uploadcover').trigger('click');
        });
    });
</script>--%>
<style type="text/css">
    #uploadprofile
    {
        display: none !important;
    }
</style>
<%--<script type="text/javascript">
    $(document).ready(function () {
        $('#lnkUpload').click(function () {
            $('#uploadprofile').trigger('click');
        });
    });
</script>--%>

<script type="text/javascript">

    /*Demo Work Start*/

    function ClearPassword() {

        window.frames['iframeChangePwd'].document.getElementById('txtCurrentPassword').value = '';
        window.frames['iframeChangePwd'].document.getElementById('txtNewPassword').value = '';
        window.frames['iframeChangePwd'].document.getElementById('txtRetypeNewPassword').value = '';

        window.frames['iframeChangePwd'].document.getElementById('txtCurrentPassword').className = 'jqtranformdone codecurrentpassword';
        window.frames['iframeChangePwd'].document.getElementById('txtNewPassword').className = 'jqtranformdone codenewpassword';
        window.frames['iframeChangePwd'].document.getElementById('txtRetypeNewPassword').className = 'jqtranformdone codeconfirmpassword';

        window.frames['iframeChangePwd'].document.getElementById('progressbar').style.display = 'none';
        window.frames['iframeChangePwd'].document.getElementById('complexity').style.display = 'none';

        window.frames['iframeChangePwd'].document.getElementById('lblError').style.display = 'none';

    }


    $(document).ready(function () {

        if ($('.drag').attr('src') == 'SocialMedia/UserImagePath/cover.jpg') {
            $('.repo').hide();
        }
        else {
            $('.repo').show();
        }

        if (getCookie("Demo") != null && getCookie("Demo") == '1') {
            $('#hdnValue').val('0');
        }
        else {
            $('#hdnValue').val('1');
        }

        $('.email').click(function (event) {
            var email = '<%=ConfigurationManager.AppSettings["ClientEmail"].ToString() %>';
            window.location.href = "mailto:" + email;

        });
    });

    function checkdemostatus() {

        if (getCookie("Demo") == null)
            createCookie("Demo", 1, 30);
    }

    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    function getCookie(NameOfCookie) {
        if (document.cookie.length > 0) {
            begin = document.cookie.indexOf(NameOfCookie + "=");
            if (begin != -1) // Note: != means "is not equal to"
            {
                begin += NameOfCookie.length + 1;
                end = document.cookie.indexOf(";", begin);
                if (end == -1) end = document.cookie.length;
                return unescape(document.cookie.substring(begin, end));
            }
        }
        return null;
    }

    $('.xclose').click(function (event) {
        event.stopPropagation();
        $(this).closest('div').slideUp();
        checkdemostatus();
    });


    /*Demo Work End*/

    function RefreshParent() {
        //window.parent.location.href = "../Area/Area.aspx#myModal_ChangePassword";
        window.parent.location.Reload();
    }

    function CheckPasswordStrength(isvalid, complex) {
        if (!isvalid) {
            $('#progress').css({
                'width': complex * 4 + '%'
            }).removeClass('progressbarValid').addClass('progressbarInvalid');
        } else {
            $('#progress').css({
                'width': complex * 4 + '%'
            }).removeClass('progressbarInvalid').addClass('progressbarValid');
        }

        if (complex == 0) {
            //$('#complexity').html('0' + '% Weak');
            $('#complexity').html('Weak');
        }

        if (complex * 4 >= 100) {
            //$('#complexity').html('100' + '% Strong');
            $('#complexity').html('Strong');
        }

        if (complex * 4 <= 34) {

            //$('#complexity').html(Math.round(complex * 4) + '% Weak');
            $('#complexity').html('Weak');
        }

        else if (complex * 4 <= 68) {
            //$('#complexity').html(Math.round(complex * 4) + '% Medium');
            $('#complexity').html('Medium');
            //  $('#complexity').html(50 + '% Medium');
        }

        else if (complex * 4 <= 90) {
            // $('#complexity').html(80 + '% Strong');
            //$('#complexity').html(Math.round(complex * 4) + '% Strong');
            $('#complexity').html('Strong');
        }

        else {
            if (Math.round(complex * 4) >= 100) {
                //$('#complexity').html('100' + '% Strong');
                $('#complexity').html('Strong');
            }
            else {
                // change string Strong to show very Strong :)
                //$('#complexity').html(Math.round(complex * 4) + '%  Strong');
                $('#complexity').html('Strong');
            }
        }
    }


    function ValidatePasswordStrength() {
        var score = 1; var isOK = false;
        var complexity = 0; var valid = false;

        $('#progressbar').attr("style", "display:''");
        $('#complexity').attr("style", "display:''");


        if ($('.codenewpassword').val().length == 0) {
            CheckPasswordStrength(false, 0);
            return;
        }

        if ($('.codenewpassword').val().length <= 6) {
            CheckPasswordStrength(false, 5);
            return;
        }
        //            if ($('.email').val().indexOf($('.codenewpassword').val()) >= 0) {
        //                CheckPasswordStrength(false, 5);
        //                return;
        //            }

        if ($('.codenewpassword').val().length >= 10) {
            score++;
            complexity = complexity + 6.25;
        }
        var numberRegex = new RegExp("[0-9]", "g");
        if (numberRegex.test($('.codenewpassword').val())) {
            score++;
            complexity = complexity + 6.25;
        }

        var alphaRegex = new RegExp("[a-zA-Z]+", "g");
        if (alphaRegex.test($('.codenewpassword').val())) {
            score++;
            complexity = complexity + 6.25;
        }

        var charRegex = /.[!,@,#,$,%,^,&,*,?,_,~,.,-,�,(,)]/;
        if (charRegex.test($('.codenewpassword').val())) {
            score++;
            complexity = complexity + 6.25;
        }

        CheckPasswordStrength(valid, complexity);
    }




    function validateChangePassword() {
        // debugger;
        var isName, isPass, isConfirmPass, isPassMatch = false;

        if ($('.codecurrentpassword').val() == "") {
            $('.codecurrentpassword').addClass('error');
        } else {
            $('.codecurrentpassword').removeClass('error');
            isName = true;
        }

        if ($('.codenewpassword').val() == "") {
            $('.codenewpassword').addClass('error');
        } else {
            $('.codenewpassword').removeClass('error');
            isPass = true;
        }
        if ($('.codeconfirmpassword').val() == "") {
            $('.codeconfirmpassword').addClass('error');
        } else {
            isConfirmPass = true;

            if ($('.codenewpassword').val() == $('.codeconfirmpassword').val()) {
                $('.codeconfirmpassword').removeClass('error');
                $('.codenewpassword').removeClass('error');
                isPassMatch = true;
            }
            else {
                $('.codenewpassword').addClass('error');
                $('.codeconfirmpassword').addClass('error');
                isPassMatch = false;
            }
        }

        if (isName && isPass && isConfirmPass) {
            if (isPassMatch) {
                if ($('.codecurrentpassword').val() != $('.codeconfirmpassword').val())
                    $(".errormsg").text("");
                else {
                    $(".errormsg").text("Old and New Passwords are same");
                    return false;
                }
            }
            else {
                $(".errormsg").text("Password does not match");
                return false;
            }
        }
        else {
            $(".errormsg").text("Please provide complete & valid information");
            return false;
        }
    }



    function isNumberKey(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode
        var isnumeric = false;
        if (charCode >= 48 && charCode <= 57)
            isnumeric = true;
        if (charCode == 46)
            isnumeric = true;
        if (charCode == 8)
            isnumeric = true;
        if (charCode == 110)
            isnumeric = true;
        if (charCode == 190)
            isnumeric = true;
        if (charCode >= 37 && charCode <= 40)
            isnumeric = true;
        if (charCode >= 96 && charCode <= 105)
            isnumeric = true;

        return isnumeric;

    }


    function NeedHelp() {
        var GetAssistanceCode = $('#<%=txtPMsg.ClientID %>').val().trim();
        var CandidateCode = $('#<%=hfPCandidateCode2.ClientID %>').attr('value');
        if (GetAssistanceCode == '') {
            $('.codegetassistance').addClass('error');

        }

        else {
            $('.codegetassistance').removeClass('error');

            $.ajax({
                url: 'getassistancehandler.ashx?gc=' + GetAssistanceCode + '&cc=' + CandidateCode,
                dataType: 'HTML',
                async: true,
                type: 'POST',
                success: function (data) {
                    if (data != null && $.trim(data) != '') {
                        //                            alert(data);
                        //                            if (data == "False")
                        //                                $(".errormsggetassistance").text("Invalid Code");

                        //window.location = "http://xwebsrv:60114/Area/Area.aspx";
                        var v1 = '<%=ConfigurationManager.AppSettings["DomainAddress"].ToString() %>'
                        window.location = v1 + "/Area/Area.aspx";
                    }
                }
            });
        }
    }


</script>

<style type="text/css">
    .error
    {
        /*background: #FFD9D9 !important;*/
        border: 1px solid #CC0000 !important;
    }
    .red
    {
        color: #CC0000 !important;
    }
</style>

