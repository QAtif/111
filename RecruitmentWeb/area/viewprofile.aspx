<%@ Page Title="" Language="C#" MasterPageFile="~/AreaMaster.master" AutoEventWireup="true"
    CodeFile="viewprofile.aspx.cs" Inherits="area_viewprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" runat="Server">

    <script type="text/javascript">
        $(document).ready(function() {
            $('ul.xfamilyUL li:gt(1)').hide();
            $('.xfamilyUL-a').click(function() {
                $('ul.xfamilyUL li:gt(0)').show();
                $(this).hide();
            });
        });

    </script>

    <script type="text/javascript">
        xPageELEM = 3;
    </script>

    <style type="text/css">
        .taglinks
        {
            display: block;
            background: #CDE2F6;
            border: 1px solid #BFDAF7;
            color: #036;
            font-size: 11px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 03px 6px 03px 5px;
            float: left;
            margin-right: 5px;
            margin-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" runat="Server">
    <div class="row-fluid">
        <section>
        <div class="xboxRight">
        <div class="xBoxHeader Xborder-bottom">
          <h2 class="xHeading-style2" style=" height: 20px; line-height: 30px;" >Profile </h2>
          <div class="xprogree-float"> <span class="xFloat-txt"><b>Profile Completion Status (<asp:Label ID="lblProgress" runat="server" Text="86%" />)</b></span>
            <div class="progress progress-success xProgress pull-right xProgress-margin"  style="width:142px; height:8px">               
                       <div id="dvBar" class="bar" style="width: 86%;height: 8px;" runat="server"></div>                  
            </div>
            <br />
            <br />
            <a href="../profile/redirector.aspx" class="complete-profile" runat="server" id="btncomplete" style="text-decoration: none; color:rgb(242, 246, 248);">Complete Profile</a> </div>
        </div>
        <div class="row-fluid">
          <div class="span6">
            <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside">
                  <h3>Experience</h3>
                    <a id="lnkExperience" runat="server" href="/Area/application/" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                    <asp:ListView ID="ListView1" runat="server" OnItemDataBound="Experience_ItemDataBound">
                <LayoutTemplate>
                    <ul class="experianceUL">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li id="liexperience" runat="server">
                    <img src='<%#Eval("LogoPath") %>' class="xClogo" alt="" width="50px" height="50px" onError="this.onerror=null;this.src='/Area/assets/img/nocompany.png';"/> <%#Eval("Name") %> <br /> 
                      <%#Eval("Position") %> <br /> <%#Eval("Duration") %> </li>                     
                        <asp:HiddenField ID="hfExperienceCode" runat="server" Value=' <%#Eval("CandidateExperience_Code") %>' />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>
                        Nothing here.</p>
                </EmptyDataTemplate>
            </asp:ListView>
             <asp:Label ID="lblExperience" runat="server"></asp:Label>
               
                  <a href="javascript:;"  id="lnkMoreExp"  style="display:none" runat="server" title="" class="xBoxAnchor experiance-a"><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" /> See complete information</a> </div>
              </div>
            </div>
            <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside">
                  <h3>Education</h3>
                  <a id="lnkEducation" runat="server" href="/Area/application/" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                 
                    <asp:ListView ID="lvEducation" runat="server" OnItemDataBound="Education_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="educationUL">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQualificationCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                            Visible="false"></asp:Label>
                        <li id="lieducation" runat="server">
                           <img src='<%#Eval("LogoPath") %>' class="xClogo" alt="" onError="this.onerror=null;this.src='/Area/assets/img/noeducation.png';"/> <%# DataBinder.Eval(Container.DataItem, "Institute")%> <br />
                            <%# DataBinder.Eval(Container.DataItem, "CandidateEducation")%> <br />  <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "EndDate")%>                         
                            <asp:Label ID="lblEducation" runat="server"></asp:Label>
                            <br />                           
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>
                            Nothing here.</p>
                    </EmptyDataTemplate>
                </asp:ListView>
                 <asp:Label ID="lbleducation" runat="server"></asp:Label>

                 
                  <a href=""  id="lnkMoreEdu"  style="display:none"  runat="server" title="" class="xBoxAnchor educatione-a"><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" /> See complete information</a> </div>
              </div>
            </div>
            <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside">
                    <h3>Diplomas</h3>
                  <a href="/Area/application/" id="lnkDiplomas" runat="server" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                                   <asp:ListView ID="lvDiploma" runat="server" OnItemDataBound="Diploma_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="diplomasUL">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQualificationCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                            Visible="false"></asp:Label>
                        <li id="lidiploma" runat="server">


                        <img src='<%#Eval("LogoPath") %>' class="xClogo" alt="" onError="this.onerror=null;this.src='/Area/assets/img/noeducation.png';"/><%# DataBinder.Eval(Container.DataItem, "Institute")%> <br />
                       <%# DataBinder.Eval(Container.DataItem, "Field")%> <br /> <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                           
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>
                            Nothing here.</p>
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:Label ID="lblDiploma" runat="server"></asp:Label>
                 
                  <a href=""  id="lnkMoreDip" runat="server" title="" style="display:none" class="xBoxAnchor diploma-a"><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" />See complete information</a> </div>
              </div>
            </div>
            <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside">
                  <h3>Certifications</h3>
                  <a id="lnkcertificate" runat="server" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>               

                     <asp:ListView ID="lvCertificate" runat="server" OnItemDataBound="Certificate_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="certificationUL">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQualificationCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CandidateQualificationCode")%>'
                            Visible="false"></asp:Label>
                        <li id="licertificate" runat="server">
                            <img src='<%#Eval("LogoPath") %>' class="xClogo" alt="" onError="this.onerror=null;this.src='/Area/assets/img/noeducation.png';"/> <%# DataBinder.Eval(Container.DataItem, "Institute")%><br /> 
                      <%# DataBinder.Eval(Container.DataItem, "Field")%> <br />  <%# DataBinder.Eval(Container.DataItem, "FromDate")%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "EndDate")%>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>
                            Nothing here.</p>
                    </EmptyDataTemplate>
                </asp:ListView>
                 <asp:Label ID="lblCertificate" runat="server"></asp:Label>
               
                  <a href="" id="lnkMoreCer"  style="display:none"  runat="server"  title="" class="xBoxAnchor certification-a"><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" /> See complete information</a> </div>
              </div>
            </div>
           
            <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside">
                    <h3>Portfolio</h3>
                  <a id="lnkPortfolio" runat="server" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                  <div class="Xinfo-ul">
                  
                      <asp:ListView ID="lvPortFolio" runat="server" OnItemDataBound="Portfolio_ItemDataBound">
                                <LayoutTemplate>
                                    <ul class="portfolioUL">
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </ul>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <li id="liportfolio" runat="server">
                                        <div class="xLiLeft"> <%# DataBinder.Eval(Container.DataItem, "URLTitle").ToString()%></div>
                        <div class="xLiRight"><a href='<%# "http://" + DataBinder.Eval(Container.DataItem, "URL").ToString() %>' title="" target="_blank"><%# DataBinder.Eval(Container.DataItem, "URL")%></a></div>                                     
                        </li>
                                      
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <p>
                                        Nothing here.</p>
                                </EmptyDataTemplate>
                            </asp:ListView>

                            <asp:Label ID="lblPortfolio" runat="server"></asp:Label>
                  </div>
                  
                  <a href=""  id="lnkMorePor" runat="server" title="" class="xBoxAnchor portfolio-a"  style="display:none" ><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" /> See complete information</a> </div>
              </div>
            </div>
            <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside" style="overflow:hidden">
                  <h3>Skill Set</h3>
                  <a id="lnkSkillSet" runat="server" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                
             <%-- <img src="/Area/assets/img/skill-set.jpg" alt="" />&nbsp;--%>
                                     <asp:Repeater ID="rptskill" runat="server" ClientIDMode="Static">
                                     <HeaderTemplate>
                                       <ul class="certificationUL">
                  <ui>
                                     </HeaderTemplate>
                                            <ItemTemplate>
                                            <span class="taglinks">
                                        
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Skill") %>'></asp:Label>    
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Skill_Code") %>' />
                                            </span>
                                               
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </ui></ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        
 <asp:Label ID="lblskillSet" runat="server"></asp:Label>
                 
                  <a href="" style="display:none" title="" class="xBoxAnchor skill-a"><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" /> See complete information</a> 
                  </div>
             </div>
             </div>
          </div>
          <!-- end left -->
          
          <div class="span6" style="margin:0px 0px; width:488px;">
            <div class="xBox-style">
              <div class="Xborder-after"  style="border-right:0px">
                <div class="xBox-padding-inside2">
              <h3>Personal Information</h3>
                  <a id="lnkPersonalInfo" runat="server" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                  <div  class="Xinfo-ul">
                    <ul>
                      <li>
                        <div class="xLiLeft">Gender</div>
                        <div class="xLiRight"><asp:Label runat="server" ID="lblgender"></asp:Label></div>
                      </li>
                      <li>
                        <div class="xLiLeft">Birthday</div>
                        <div class="xLiRight"><asp:Label runat="server" ID="lblDOB"></asp:Label></div>
                      </li>
                      <li>
                        <div class="xLiLeft">Marital Status</div>
                        <div class="xLiRight"><asp:Label runat="server" ID="lblMarried"></asp:Label></div>
                      </li>
                      <li>
                        <div class="xLiLeft">Nationality</div>
                        <div class="xLiRight"><asp:Label runat="server" ID="lblNationality"></asp:Label></div>
                      </li>
                      <li>
                        <div class="xLiLeft">CNIC</div>
                        <div class="xLiRight"><asp:Label runat="server" ID="lblCNIC"></asp:Label></div>
                      </li>
                      <li>
                        <div class="xLiLeft">Religion</div>
                        <div class="xLiRight"><asp:Label runat="server" ID="lblReligion"></asp:Label></div>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
            <div class="xBox-style">
              <div class="Xborder-after"  style="border-right:0px">
                <div class="xBox-padding-inside2">
              <h3>Contact Information</h3>
                  <a id="lnkContactInfo" runat="server" title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                  <ul>
                    <li>
                      <div class="xLiLeft">Mobile Number</div>
                      <div class="xLiRight"><asp:Label runat="server" ID="lblCellNo"></asp:Label><br /><asp:Repeater runat="server" ID="rtpCellNumbr"><ItemTemplate><%# Eval("Country")%> - <%# Eval("Mobile")%> <br /></ItemTemplate></asp:Repeater></div>
                    </li>
                    <li>
                      <div class="xLiLeft">Landline Number</div>
                      <div class="xLiRight"><asp:Label runat="server" ID="lblLandlineNo"></asp:Label></div>
                    </li>
                    <li>
                      <div class="xLiLeft">Email Address</div>
                      <div class="xLiRight"><asp:Label runat="server" ID="lblEmail"></asp:Label></div>
                    </li>
                    <li>
                      <div class="xLiLeft">Address</div>
                      <div class="xLiRight"><asp:Label runat="server" ID="lblAddress"></asp:Label></div>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
              <div class="xBox-style">
              <div class="Xborder-after">
                <div class="xBox-padding-inside">
                  <h3>Family Details</h3>
                    <a id="lnkFamilyDatail" runat="server" href="/Area/application/"  title="" style="float:right; margin:-26px 0 0 0;"><img src="/Area/assets/img/edit-icon.png" alt="" /></a>
                 
                    <asp:ListView ID="LvFamilyDetail" runat="server" OnItemDataBound="Family_ItemDataBound">
                <LayoutTemplate>
                    <ul class="xfamilyUL">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li id="liFamilyDetail" runat="server">
                    <img src='<%#Eval("LogoPath") %>' class="xClogo" alt="" width="50px" height="50px" onError="this.onerror=null;this.src='/Area/assets/img/nocompany.png';"/> <%#Eval("MemberRelation")%> <br /> 
                      <%#Eval("MemberName")%> <br /> <%#Eval("MemberDOB")%> </li>                     
                       <%-- <asp:HiddenField ID="hfExperienceCode" runat="server" Value=' <%#Eval("CandidateExperience_Code") %>' />--%>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>
                        Nothing here.</p>
                </EmptyDataTemplate>
            </asp:ListView>
             <asp:Label ID="lblFamilyDetailError" runat="server"></asp:Label>
               
                  <a href="javascript:;"  id="lnkMoreFamily"  class="xBoxAnchor xfamilyUL-a"  style="display:none" runat="server" title=""><img src="/Area/assets/img/bottom-arrow.png" alt="" style="padding:0 5px 0 0px" /> See complete information</a> </div>
              </div>
            </div>

            
             </div>
          <!-- end right --> 
          
        </div>
     
        </div>
         </section>
        <!-- End Section -->
    </div>
</asp:Content>
