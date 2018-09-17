<%@ Page Title="" Language="C#" MasterPageFile="~/A2/Admin.master" AutoEventWireup="true"
    CodeFile="ViewRequisitions.aspx.cs" Inherits="Requisition_ViewRequisitions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="Server">
    <style>
        .padding10{padding-left: 10px;}
    </style>
    <title>Requisition List</title>
    <%--<script src="../A2/assets/js/QuicjSearch.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="background-color: White; padding: 15px 0px 5px 15px; margin: 5px 0px 5px 0px;">
        <h2>Requisition</h2>
    </div>
      <form class="searcharea">
    <div id="fresh-search" class="SearchBox adjustwidth">
      <div class="InsideSearchBox">
        <%--<div class="HeadingInside"> <span class="BasicInfoIcon"></span> <span class="IconTxt">Basic Information</span> <span class="borderHeader"></span> </div>--%>
        <!-- #HeadingInside -->
        
        <div class="basicSearchArea">
          <div class="BasicLeft">
            <div class="FieldWrapper">
              <div class="Lable">Domain</div>
              <!-- #Lable -->
               <div class="InputField jqtranformdone">
                 <asp:DropDownList ID="ddlDomain" runat="server" AutoPostBack="true" class="inputClass jqtranformdone" OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged">
                    </asp:DropDownList>
              </div>
              <!-- #InputField --> 
            </div>
            <!-- #FieldWrapper -->
            
           
            <!-- #FieldWrapper -->
            
            <div class="clearfix"></div>
           
            <!-- #FieldWrapper -->
            <div class="FieldWrapper">
              <div class="Lable"> Requisition Name </div>
              <!-- #Lable -->
              <div class="InputField">
                   <asp:TextBox ID="txtRequisitionName" runat="server" class="inputClass"></asp:TextBox>
              </div>
              <!-- #InputField --> 
            </div>
            <div class="clearfix"></div>
          </div>
          <!-- #BasicLeft -->
          
          <div class="SectionDiv"></div>
          <div class="BasicRight">
               <div class="clearfix"></div>
            <div class="FieldWrapper">
              <div class="Lable"> Sub-Domain </div>
              <!-- #Lable -->
              <div class="InputField jqtranformdone">
                 <asp:DropDownList ID="ddlSubDomain" runat="server" class="inputClass jqtranformdone" ></asp:DropDownList>
              </div>
              <!-- #InputField --> 
            </div>
          
            <!-- #FieldWrapper -->
            
            <div class="clearfix"></div>
            <div class="FieldWrapper">
              <div class="Lable"> City </div>
              <!-- #Lable -->
              <div class="InputField jqtranformdone">
              <asp:DropDownList ID="ddlCity" runat="server"  class="inputClass jqtranformdone"></asp:DropDownList>
              </div>
              <!-- #InputField --> 
            </div>
            <!-- #FieldWrapper -->
            
            
            <!-- #FieldWrapper --> 
            
          </div>
          <!-- #BasicRight -->
          
          <div class="SectionDiv second"></div>
          <div class="BasicRight last">
               <div class="FieldWrapper">
              <div class="Lable"> Category </div>
              <!-- #Lable -->
                <div class="InputField jqtranformdone">
                <asp:DropDownList ID="ddlCategory" runat="server" class="inputClass jqtranformdone"></asp:DropDownList>
                
                <!--<span class="CheckBox"></span><span class="Checktxt">Exactly match Email</span>--> 
              </div>
              <!-- #InputField --> 
            </div>
             <div class="clearfix"></div>
            <div class="FieldWrapper">
              <div class="Lable">  Category Specialist </div>
              <!-- #Lable -->
              <div class="InputField jqtranformdone">
                <asp:DropDownList ID="ddlCategorySpecialist" runat="server" class="inputClass jqtranformdone">
                    </asp:DropDownList>
              </div>
              <!-- #InputField --> 
            </div>
            <!-- #FieldWrapper -->
            
            <div class="clearfix"></div>

            <!-- #FieldWrapper -->
            
            <div class="clearfix"></div>
          </div>
          <!-- #BasicRight --> 
          
        </div>
        <!-- #basicSearchArea -->
        
        <div class="clearfix"></div>
    
      </div>
      <div class="clearfix"></div>
      <div class="BorderDiv"></div>
     
         <div class="ButtonsSave"> 
        <asp:LinkButton runat="server" ID="lnkSearch" CssClass="btn-ora nl" OnClick="lnkSearch_Click"
                            ValidationGroup="Check">
                        <img src="/assets/images/icons/search.png" width="12" height="13" alt="" align="absmiddle" />&nbsp;Search
                        </asp:LinkButton>
             </div>
      </div>

  </form>
    <div style="background-color: White; padding: 5px 0px 0px 0px;">
        <table width="80%" border="1" cellpadding="4" cellspacing="4" style="border: 1px solid #e5e5e5;">
            <asp:Repeater ID="rptRequisitionLists" runat="server" OnItemDataBound="rptRequisitionLists_ItemDataBound">
                <HeaderTemplate>
                    <tr style="font-weight: bolder; font-size: 13px; height: 30px; background-color: #ebebeb;">
                        <td align="center" style="width: 3%">S. No.
                        </td>
                        <td class="padding10" style="width: 11%">Requisition Name
                        </td>
                        <td class="padding10" style="width: 8%">Status
                        </td>
                        <td class="padding10" style="width: 10%">Raised By
                        </td>
                        <td class="padding10" style="width: 10%">Category Name
                        </td>
                        <td class="padding10" style="width: 8%">City
                        </td>
                        <td class="padding10" style="width: 12%">Domain
                        </td>
                        <td class="padding10" style="width: 8%">Sub Domain
                        </td>
                        <td align="center" style="width: 5%">Required
                        </td>
                        <td align="center" style="width: 5%">Shortlisted
                        </td>
                        <td class="padding10" style="width: 9%">Assigned To
                        </td>
                        <td class="padding10" style="width: 10%">Created Date
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="font-size: 12px; height: 30px;">
                        <td align="center">
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td class="padding10">
                            <%# Eval("Requisition_Name")%>
                        </td>

                        <td class="padding10"  width="8%">



                            <%# Eval("RequisitionStatus_Name")%>
                        </td>


                        <td class="padding10">
                            <%# Eval("Raised_By")%>
                        </td>

                        <td class="padding10">
                            <%# Eval("Category_Name")%>
                        </td>

                        <td class="padding10">
                            <%# Eval("City")%>
                        </td>

                        <td  class="padding10">
                            <%# Eval("Domain_Name")%>
                        </td>

                        <td class="padding10">
                            <%# Eval("SubDomain_Name")%>
                        </td>

                        <td align="center">
                            <%# Eval("Quantity")%>
                        </td>
                        <td align="center">
                            <%# Eval("ShortList_Count")%>
                        </td>
                        <td class="padding10">
                            <%# Eval("CategorySpecialistName")%>
                        </td>

                        <td class="padding10">
                            <%# Eval("createdDate")%>
                        </td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="4" align="center">
                    <asp:Label ID="lblMsg" runat="server" Text="No Records Found." ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
