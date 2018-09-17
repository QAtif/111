<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.master" AutoEventWireup="true"
    CodeFile="AddEditCategory.aspx.cs" Inherits="Category_AddEditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <title>Add Category</title>
    <script type="text/javascript">
        function CloseHighSlideWithParentRefresh() {
            //            if (parent != null) {
            //                fullQs = window.location.search.substring(1);
            //                mainURL = parent.window.location.href;
            //                var url = mainURL.split("?");
            //                if (url != null && url.length > 0)
            //                    mainURL = url[0];
            //                parent.window.location.href = mainURL; 
            // $('.fancybox-overlay-fixed').hide();

            //  + "?" + window.location.search.substring(1);
            //   parent.window.location.href = parent.window.location.href;
            //  }
            alert('Saved Successfully.');
            parent.jQuery.fancybox.close();



        }
    </script>
    <script type="text/javascript">
        function showhide(obj, tr, tr2, tr3) {

            if (obj.checked) {
                tr.style.display = '';
                tr2.style.display = '';
                tr3.style.display = '';
            }
            else {
                tr.style.display = 'none';
                 tr2.style.display = 'none';
                tr3.style.display = 'none';
            }
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div>
        <h4>
            <asp:Label runat="server" ID="lblHead" Text="Add Category"></asp:Label>
        </h4>
        <div id="container" class="contentarea">
            <asp:HiddenField ID="hdnCategoryCode" runat="server" Value="0" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList" ValidationGroup="valida" Width="500px" BorderWidth="1"
                BackColor="#ffff99" Font-Bold="false" BorderColor="Red" EnableClientScript="true"
                runat="server" />
            <br />
            <br />
            <table width="70%" border="1" cellspacing="0" cellpadding="0" class="simple">
                <tr class="simple">
                    <td>
                        Category Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryName" runat="server" Width="400px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req1" runat="server" Display="Dynamic" ControlToValidate="txtCategoryName"
                            Text="*" InitialValue="" ValidationGroup="valida" ErrorMessage="Category name can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Category Title
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryTitle" runat="server" Width="400px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                            ControlToValidate="txtCategoryTitle" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Category title can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                       Category User Type
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlCatUserType" runat="server" Width="400px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlCatUserType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Display="Dynamic" runat="server"
                            ControlToValidate="ddlCatUserType" InitialValue="0" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select category user type"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple" runat="server" id="JobRole">
                    <td>
                       Job Role
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlJobRole" runat="server" Width="400px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server"
                            ControlToValidate="ddlJobRole" InitialValue="-1" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select Job Role"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Domain
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDomain" runat="server" Width="400px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlDomain_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                            ControlToValidate="ddlDomain" InitialValue="0" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select domain"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select SubDomain
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubDomain" runat="server" Width="400px">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                            ControlToValidate="ddlSubDomain" InitialValue="0" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select subdomain"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select Profile
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProfile" runat="server" Width="400px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                            ControlToValidate="ddlProfile" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select profile"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select GradeFrom
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGradeFrom" runat="server" Width="400px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server"
                            ControlToValidate="ddlGradeFrom" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select grade from"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Select GradeTo
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGradeTo" runat="server" Width="400px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server"
                            ControlToValidate="ddlGradeTo" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select grade to"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr class="simple">
                    <td>
                        Select Position Type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPositionType" runat="server" Width="400px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server"
                            ControlToValidate="ddlPositionType" InitialValue="" Text="*" ValidationGroup="valida"
                            ErrorMessage="Please select position type"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Is Certified
                    </td>
                    <td>
                        <input id="chkcertified" type="checkbox" runat="server" />
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Is Test
                    </td>
                    <td>
                         <asp:CheckBox id="chkTest" type="checkbox" AutoPostBack="true" runat="server" OnCheckedChanged="chkTest_CheckedChanged"></asp:CheckBox>
                    </td>
                </tr>

                <tr id="trTestDuration" runat="server" class="simple">
                    <td>
                        Test Duration
                    </td>
                    <td>
                        <asp:TextBox ID="txtTestDuration" runat="server" Width="35px" MaxLength="4" onkeypress="return numbersonly(this, event)"></asp:TextBox>
                        &nbsp; Hours
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                            ControlToValidate="txtTestDuration" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Test duration can not be empty"></asp:RequiredFieldValidator>
                         
                    </td>
                </tr>
                <tr id="trTest" runat="server" class="simple">
                    <td>
                        Select Test
                    </td>
                    <td>
                        <asp:ListBox ID="lbTest" runat="server" SelectionMode="Multiple" Width="400px" Height="100px">
                        </asp:ListBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                            ControlToValidate="lbTest" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Please select test"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trSampleTest" runat="server" class="simple">
                    <td>
                        Sample Test
                    </td>
                    <td>
                        <asp:FileUpload ID="fuSampleTest" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only PDF file is allowed!"
                            ValidationExpression="^.+(.pdf|.PDF)$" ControlToValidate="fuSampleTest" Text="*" Display="Dynamic"
                            ValidationGroup="valida"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvfupic" runat="server" ControlToValidate="fuSampleTest" Display="Dynamic"
                            Text="*" ErrorMessage="Please Select File." ValidationGroup="valida"></asp:RequiredFieldValidator>
                            <div style="float:right"> <a id="aBrowsedFile" runat="server" target="_blank">View Uploaded Sample Test</a></div>
                    </td>
                </tr>
                
                <tr class="simple">
                    <td>
                        Interview Duration
                    </td>
                    <td>
                        <asp:TextBox ID="txtInterviewDuration" runat="server" Width="35px" MaxLength="4"
                            onkeypress="return numbersonly(this, event)"></asp:TextBox>
                        &nbsp; Hours
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                            ControlToValidate="txtInterviewDuration" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Interview duration can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Job Description
                    </td>
                    <td>
                        <asp:TextBox ID="txtJobDesc" runat="server" TextMode="MultiLine" Rows="10" Columns="5" style="resize:none"
                            Width="400px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                            ControlToValidate="txtJobDesc" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Job description can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Bonus Type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBonusType" runat="server" Width="400px">
                        </asp:DropDownList>
                    </td>
                </tr>
                 
                <tr class="simple">
                    <td>
                        Bonus Formula
                    </td>
                    <td>
                        <asp:TextBox ID="txtBonusFarmula" runat="server" Rows="10" Columns="5" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="simple" style="display:none">
                    <td>
                        Total Approve Count
                    </td>
                    <td>
                        <asp:TextBox ID="txtTPC" runat="server" Rows="10" Columns="5" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="simple" style="display:none">
                    <td>
                        Filled Positions
                    </td>
                    <td>
                        <asp:TextBox ID="txtFP" runat="server" Rows="10" Columns="5" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="simple" style="display:none">
                    <td>
                        Unfilled Position
                    </td>
                    <td>
                        <asp:TextBox ID="txtUP" runat="server" Rows="10" Columns="5" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="simple" style="display:none">
                    <td>
                        New Requisition
                    </td>
                    <td>
                        <asp:TextBox ID="txtNr" runat="server" Rows="10" Columns="5" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="simple">
                    <td>
                        Prefix
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrefix" runat="server" Rows="10" Columns="5" Width="100px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                            ControlToValidate="txtPrefix" Text="*" InitialValue="" ValidationGroup="valida"
                            ErrorMessage="Prefix can not be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                  <tr class="simple">
                    <td>
                        Company Maintained Motorbike
                    </td>
                    <td>
                        <input id="chkIsBike" type="checkbox" runat="server" />
                    </td>
                </tr>
                <tr class="simple">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Category" CssClass="btn-ora nl"
                            ValidationGroup="valida" OnClick="btnAdd_Click" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

