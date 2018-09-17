<%@ control language="C#" autoeventwireup="true" inherits="controls_navigation, App_Web_navigation.ascx.cc671b29" %>
<div class="span4">
    <aside class="XnewRule">
        <div class="xbox-with-heading" style="overflow:visible;">
          <h3>Fill Application Form</h3>
          <div class="xbox-content">
            <ul class="summary-list nav">
              <li id="liProf" runat="server"> <a id="AProf" href="experience.aspx"> <img src="/Area/assets/img/icons/professional.png" alt="">Professional Experience </a> </li>
              <li id="liEdu" runat="server"> <a  id="AEdu" href="education.aspx"> <img src="/Area/assets/img/icons/educational.png" alt="">Educational Qualification </a> </li>
              <li id="liDip" runat="server"> <a id="ADip" href="diploma.aspx"> <img src="/Area/assets/img/icons/diploma.png" alt="">Diploma </a> </li>
              <li id="liCert" runat="server"> <a id="ACert" href="certificate.aspx"> <img src="/Area/assets/img/icons/certification.png" alt="">Certification </a> </li>
               <li id="liSkill" runat="server"> <a id="ASkill" href="skillset.aspx"> <img src="/Area/assets/img/icons/skill-set.png" alt="">Skill Set </a> </li>
               <li id="liPort" runat="server"> <a id="APort" href="portfolio.aspx"> <img src="/Area/assets/img/icons/portfolio.png" alt="">Portfolio </a> </li>
              <li id="liPD" runat="server"> <a id="APD" href="personaldetails.aspx"> <img src="/Area/assets/img/icons/persoal-detail.png" alt="">Personal Details </a> </li>
              <li id="liRef" runat="server"> <a id="ARef" href="referral.aspx"> <img src="/Area/assets/img/icons/reference.png" alt="">Referral </a> </li>
              <li id="liDoc" runat="server"> <a id="ADoc" href="uploaddocuments.aspx"> <img src="/Area/assets/img/icons/docs.png" alt="">Upload Documents </a> </li>
               <li id="liFD" runat="server" style="display:none;"> <a id="AFD" href="familydetails.aspx"> <img src="/Area/assets/img/icons/docs.png" alt="">Family Details </a> </li> 
            </ul>
            <div class="xprogreeBarArea">
              <div class="row-fluid">
                <div class="span7">
                   <div  class="progress progress-success xProgress">
                       <div id="dvBar" class="bar" style="width:0%;" runat="server"></div>
                  </div>
                </div>
                <div class="span5" style="padding-top:7px;" ><span id="XproGWidth"><asp:Label ID="lblProgress" runat="server" /></span>% Complete </div>
              </div>
            </div>
          </div>
        </div>
      </aside>
</div>
