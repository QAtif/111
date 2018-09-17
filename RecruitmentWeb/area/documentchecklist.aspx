<%@ Page Language="C#" AutoEventWireup="true" CodeFile="documentchecklist.aspx.cs"
    Inherits="area_documentchecklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="/Area/assets/css/xBook.css">
    <style type="text/css">
        body
        {
            background-color: #fff !important;
            font: normal 11px 'LucidaGrande';
            color: #666666;
        }
    </style>
    <style type="text/css">
        .error
        {
            /*background: #FFD9D9 !important;*/
            border: 1px solid #CC0000 !important;
        }
    </style>
    <link href="/Area/assets/css/bootstrap.min.css" type="text/css" />
</head>
<body>
<form id="form1" runat="server" class="xStyledForm jqtransformdone">

   
    <div class="modal-body nopad">
      <div class="row-fluid msgarea">
  	    <div class="span3"> 
    	    <ul class="darkcolor">
        	    <li>Candidate Name:</li>
                <li>Department:</li>
                <li>Designation:</li>
                <li>Job Category:</li>
            </ul>
        </div>
        <div class="span9" style="margin-left:0"> 
        <ul>
            <li><asp:Label ID="lblName" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblDept" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblDesg" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblCat" runat="server"></asp:Label></li>
         </ul>
        </div>
      </div>
 
      </div>
    
    <div class="modal-body nopad theScroll jsscrollerwidth" style="max-height:350px !important;">
      <div class="row-fluid">
        <div class="span12">
        <ul class="tabcontroller">
                <li><a title="" href="javascript:;" data-rel="tab1" class="active">Education Record</a></li>
                <li><a title="" href="javascript:;" data-rel="tab2">Personal Record</a></li>
                <li><a title="" href="javascript:;" data-rel="tab3">Professional Record</a></li>		
            </ul>
        <div class="tabs-content">
                <div class="tab1" style="display:block;">
                <asp:label ID="lblMsgOther" runat="server" Visible="false" Text="No record found"></asp:label>
                   <asp:Repeater ID="rptDocumentOther" runat="server" OnItemDataBound="rptDocumentOther_OnItemDataBound">
                        
                        <ItemTemplate>
                            <p>
                                <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                    Visible="false"></asp:Label>
                                <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                 <div class="tab2">
                 <asp:label ID="lblMsgPersonal" runat="server" Visible="false" Text="No record found"></asp:label>
                  <asp:Repeater ID="rptDocumentPersonal" runat="server" OnItemDataBound="rptDocumentPersonal_OnItemDataBound">
                        
                        <ItemTemplate>
                            <p>
                                <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                    Visible="false"></asp:Label>
                                <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                                <p>
                        </ItemTemplate>
                    </asp:Repeater>
                 </div>
                 <div class="tab3">
                 <asp:label ID="lblMsgExperience" runat="server" Visible="false" Text="No record found"></asp:label>
                 <asp:Repeater ID="rptDocumentExperience" runat="server" OnItemDataBound="rptDocumentExperience_OnItemDataBound">
                        
                        <ItemTemplate>
                            <p>
                                <asp:HiddenField ID="hdnCandDocCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CandidateCodument_Code")%>' />
                                <asp:Label ID="lblDocumentCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DocType_Name")%>'
                                    Visible="false"></asp:Label>
                                <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Document_Name")%>'></asp:Label>
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                 </div>
             </div>
        <div class="addpadd">  
           <ol class="addlisting">
            <li>Please bring all the original documents and photocopies.</li>
            <li>Please bring 1 Passport size photo of Self, Parents, Spouse and kids (if Applicable)</li>
            <li>Please note that the documents you submit should be in accordance with the information you submitted earlier.</li>
         </ol>
        
        <strong> Credential Verification Authorization</strong>
            <p>You will be required to sign an authorization form that will be authorizing Axact to authenticate and verify all your credentials from the past employers, educational institutes, your provided references and any other entity as they deemed appropriate.</p></div>

        </div>
      </div>
  </div>

</form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function Clickheretoprint() {
        window.print();
    }
</script>

