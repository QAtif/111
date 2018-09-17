
using ErrorLog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Drawing;

public partial class LinkMgmt_AssignLinksRight : CustomBasePage, IRequiresSessionState
{
    #region Varaibles
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    #endregion

    #region Paging Variables
    static DataView objDV = new DataView();
    static int PageSize;
    static string SortDirection = "DESC";
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            LinkMgmt_AssignLinksRight.PageSize = 25;
            connection.Open();
            BindUserType();
            BindDepartment();
            GetUserLink(ref connection);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    private void BindUserType()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectUserType", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            ddluserType.DataSource = dataSet;
            ddluserType.DataTextField = "UserType";
            ddluserType.DataValueField = "UserType_Code";
            ddluserType.DataBind();
        }
        ddluserType.Items.Insert(0, new ListItem("----Select UserType----", ""));
    }

    protected void ddl_Department_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetDepartmentUser();
            tr2.Visible = false;
            tr1.Visible = false;
            tr3.Visible = false;
            trRoleLinks.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (!(e.CommandName == "BindUser"))
                return;
            string UserID = e.CommandArgument.ToString();
            hdfUserID.Value = UserID;
            BindUserDetails(ddl_Department.SelectedValue, UserID);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptRole_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            CheckBox control = (CheckBox)e.Item.FindControl("rbRole");
            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "RetVal")) != 1)
                return;
            control.Checked = true;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnMenuLinkID");
            CheckBox control2 = (CheckBox)e.Item.FindControl("rbLinkCat");
            HtmlTableRow control3 = (HtmlTableRow)e.Item.FindControl("trView1");
            HtmlTableRow control4 = (HtmlTableRow)e.Item.FindControl("trView2");
            CheckBoxList control5 = (CheckBoxList)e.Item.FindControl("chblLinks");
            control2.Attributes.Add("onclick", "toggleSelection(this,'" + control5.ClientID + "');");
            control5.Attributes.Add("onclick", "ParentsCheck('" + control2.ClientID + "','" + control5.ClientID + "');");
            SqlCommand selectCommand = new SqlCommand("XRec_SelectChildMenuLinkByUser", connection);
            selectCommand.Parameters.AddWithValue("@ParentCode", control1.Value);
            selectCommand.Parameters.AddWithValue("@UserCode", hdfUserID.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                control3.Visible = true;
                control4.Visible = true;
                control5.DataSource = dataSet;
                control5.DataTextField = "MenuLinkName";
                control5.DataValueField = "MenuLinkID";
                control5.DataBind();
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                {
                    foreach (ListItem listItem in control5.Items)
                    {
                        if (listItem.Value == row["MenuLinkID"].ToString())
                        {
                            if (row["IsMark"].ToString() == "1")
                            {
                                control2.Checked = true;
                                listItem.Selected = true;
                            }
                            else
                                listItem.Selected = false;
                        }
                    }
                }
            }
            else
            {
                control3.Visible = false;
                control4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnMenuLinkID");
            CheckBox control2 = (CheckBox)e.Item.FindControl("rbLink");
            CheckBox control3 = (CheckBox)e.Item.Parent.Parent.FindControl("rbLinkCat");
            SqlCommand selectCommand = new SqlCommand("XRec_SelectMenuLinkRights", connection);
            selectCommand.Parameters.AddWithValue("@MenuLinkID", control1.Value);
            selectCommand.Parameters.AddWithValue("@UserID", hdfUserID.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count <= 0 || !(dataSet.Tables[0].Rows[0]["RetVal"].ToString() == "1"))
                return;
            control2.Checked = true;
            control3.Checked = true;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem in rptCategory.Items)
            {
                CheckBoxList control1 = (CheckBoxList)repeaterItem.FindControl("chblLinks");
                CheckBox control2 = (CheckBox)repeaterItem.FindControl("rbLinkCat");
                HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnMenuLinkID");
                if (control2.Checked && control1 != null)
                {
                    foreach (ListItem listItem in control1.Items)
                    {
                        if (listItem.Selected)
                            InserMenuLinkUserAssociation(hdfUserID.Value, listItem.Value);
                    }
                }
            }
            foreach (RepeaterItem repeaterItem in rptCategory.Items)
            {
                CheckBoxList control1 = (CheckBoxList)repeaterItem.FindControl("chblLinks");
                CheckBox control2 = (CheckBox)repeaterItem.FindControl("rbLinkCat");
                HiddenField control3 = (HiddenField)repeaterItem.FindControl("hdnMenuLinkID");
                if (!control2.Checked)
                    removeMenuLinkParentUserAssociation(hdfUserID.Value, control3.Value);
                else if (control1 != null)
                {
                    foreach (ListItem listItem in control1.Items)
                    {
                        if (!listItem.Selected)
                            removeMenuLinkUserAssociation(hdfUserID.Value, listItem.Value);
                    }
                }
            }
            foreach (ListItem listItem in chblistDomain.Items)
            {
                if (listItem.Selected)
                    InsertUserDomain(hdfUserID.Value, listItem.Value);
            }
            foreach (ListItem listItem in chblistDomain.Items)
            {
                if (!listItem.Selected)
                    removeDomainUserAssociation(hdfUserID.Value, listItem.Value);
            }
            UpdateUserType(hdfUserID.Value, ddluserType.SelectedValue);
            lblMsg.Text = "Successfully Updated!!";
            lblMsg.Visible = true;
            lblMsg.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (rbtnUser.Checked)
            {
                GetDepartmentUser();
                tr2.Visible = false;
                tr1.Visible = false;
                tr3.Visible = false;
                trUser2.Visible = true;
                trRole2.Visible = false;
                lblMsg.Visible = false;
            }
            else
            {
                if (!rbtnUserType.Checked)
                    return;
                hfd_UserTypeID.Value = ddlTeamUserType.SelectedValue;
                GetRole();
                trUser2.Visible = false;
                trRole2.Visible = true;
                trRoleLinks.Visible = true;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptRoleLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnMenuLinkID");
            CheckBox control2 = (CheckBox)e.Item.FindControl("rbLinkCat");
            HtmlTableRow control3 = (HtmlTableRow)e.Item.FindControl("trView1");
            HtmlTableRow control4 = (HtmlTableRow)e.Item.FindControl("trView2");
            CheckBoxList control5 = (CheckBoxList)e.Item.FindControl("chblChildLink");
            control2.Attributes.Add("onclick", "toggleSelection(this,'" + control5.ClientID + "');");
            SqlCommand selectCommand = new SqlCommand("XRec_SelectUserTypeMenuLink", connection);
            selectCommand.Parameters.AddWithValue("@ParentCode", control1.Value);
            selectCommand.Parameters.AddWithValue("@UserTypeID", hfd_UserTypeID.Value);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                control3.Visible = true;
                control4.Visible = true;
                control5.DataSource = dataSet;
                control5.DataTextField = "MenuLinkName";
                control5.DataValueField = "MenuLinkID";
                control5.DataBind();
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                {
                    foreach (ListItem listItem in control5.Items)
                    {
                        if (listItem.Value == row["MenuLinkID"].ToString())
                        {
                            if (row["RetVal"].ToString() == "1")
                            {
                                control2.Checked = true;
                                listItem.Selected = true;
                            }
                            else
                                listItem.Selected = false;
                        }
                    }
                }
            }
            else
            {
                control3.Visible = false;
                control4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rptRoleChildLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem)
        {
            if (e.Item.ItemType != ListItemType.Item)
                return;
        }
        try
        {
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnMenuLinkID");
            CheckBox control2 = (CheckBox)e.Item.FindControl("rbLink");
            CheckBox control3 = (CheckBox)e.Item.Parent.Parent.FindControl("rbLinkCat");
            if (!(DataBinder.Eval(e.Item.DataItem, "RetVal").ToString() == "1"))
                return;
            control2.Checked = true;
            control3.Checked = true;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    private void GetDepartmentUser()
    {
        try
        {
            SqlCommand selectCommand = new SqlCommand("XRec_UserDetails", connection);
            selectCommand.Parameters.AddWithValue("@user_name", txt_UserName.Text.Replace("'", "''"));
            selectCommand.Parameters.AddWithValue("@dept_code", ddl_Department.SelectedValue);
            selectCommand.Parameters.AddWithValue("@user_code", -1);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptUser.DataSource = dataSet;
                rptUser.DataBind();
            }
            else
            {
                rptUser.DataSource = null;
                rptUser.DataBind();
                lblUserName.Text = "";
                lblDepartment.Text = "";
                lblJobTitle.Text = "";
                imgUser.Src = "/assets/images/Face10.jpg";
                tr2.Visible = false;
                tr1.Visible = false;
                tr3.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rbtnUserType_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Visible = false;
            if (!rbtnUserType.Checked)
                return;
            trDept.Visible = false;
            truser.Visible = false;
            trRole.Visible = true;
            tr2.Visible = false;
            tr1.Visible = false;
            tr3.Visible = false;
            trUser2.Visible = false;
            trRole2.Visible = true;
            trRoleLinks.Visible = false;
            rptUser.DataSource = null;
            rptUser.DataBind();
            rptUser.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void rbtnUser_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Visible = false;
            if (!rbtnUser.Checked)
                return;
            trDept.Visible = true;
            truser.Visible = true;
            trRole.Visible = false;
            rptUser.Visible = true;
            tr2.Visible = false;
            tr1.Visible = false;
            tr3.Visible = false;
            trUser2.Visible = true;
            trRole2.Visible = false;
            trRoleLinks.Visible = false;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void btnSaveRole_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (RepeaterItem repeaterItem in rptRoleLink.Items)
            {
                CheckBox control1 = (CheckBox)repeaterItem.FindControl("rbLinkCat");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnMenuLinkID");
                CheckBoxList control3 = (CheckBoxList)repeaterItem.FindControl("chblChildLink");
                if (control1.Checked && control3 != null)
                {
                    foreach (ListItem listItem in control3.Items)
                    {
                        if (listItem.Selected)
                            InserMenuLinkRoleAssociation(hfd_UserTypeID.Value, listItem.Value);
                    }
                }
            }
            foreach (RepeaterItem repeaterItem in rptRoleLink.Items)
            {
                CheckBox control1 = (CheckBox)repeaterItem.FindControl("rbLinkCat");
                HiddenField control2 = (HiddenField)repeaterItem.FindControl("hdnMenuLinkID");
                CheckBoxList control3 = (CheckBoxList)repeaterItem.FindControl("chblChildLink");
                if (!control1.Checked)
                    removeMenuLinkParentRoleAssociation(hfd_UserTypeID.Value, control2.Value);
                else if (control3 != null)
                {
                    foreach (ListItem listItem in control3.Items)
                    {
                        if (!listItem.Selected)
                            removeMenuLinkRoleAssociation(hfd_UserTypeID.Value, listItem.Value);
                    }
                }
            }
            lblMsg.Text = "Successfully Updated!!";
            lblMsg.Visible = true;
            lblMsg.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }

    protected void BindDepartment()
    {
        SqlCommand selectCommand1 = new SqlCommand("XRec_SelectDepartment", connection);
        selectCommand1.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
        DataSet dataSet1 = new DataSet();
        sqlDataAdapter1.Fill(dataSet1);
        if (dataSet1.Tables[0].Rows.Count > 0)
        {
            ddl_Department.DataSource = dataSet1;
            ddl_Department.DataTextField = "dept_name";
            ddl_Department.DataValueField = "dept_code";
            ddl_Department.DataBind();
        }
        ddl_Department.Items.Insert(0, new ListItem("----Select Department----", "-1"));
        SqlCommand selectCommand2 = new SqlCommand("XRec_SelectAllUserType", connection);
        selectCommand2.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
        DataSet dataSet2 = new DataSet();
        sqlDataAdapter2.Fill(dataSet2);
        if (dataSet2.Tables[0].Rows.Count > 0)
        {
            ddlTeamUserType.DataSource = dataSet2;
            ddlTeamUserType.DataTextField = "UserType";
            ddlTeamUserType.DataValueField = "UserType_Code";
            ddlTeamUserType.DataBind();
        }
        ddlTeamUserType.Items.Insert(0, new ListItem("----Select UserType----", "-1"));
    }

    public void GetUserLink(ref SqlConnection connection)
    {
    }

    protected void BindUserDetails(string DeptID, string UserID)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_UserDetails", connection);
        selectCommand.Parameters.AddWithValue("@user_name", "");
        selectCommand.Parameters.AddWithValue("@dept_code", ddl_Department.SelectedValue);
        selectCommand.Parameters.AddWithValue("@user_code", UserID);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        hfd_UserID.Value = UserID;
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            lblUserName.Text = dataSet.Tables[0].Rows[0]["fullname"].ToString();
            lblDepartment.Text = dataSet.Tables[0].Rows[0]["deptname"].ToString();
            lblJobTitle.Text = dataSet.Tables[0].Rows[0]["JobTitle"].ToString();
            if (dataSet.Tables[0].Rows[0]["UserTypeCode"].ToString() == "0")
                ddluserType.SelectedValue = "";
            else
                ddluserType.SelectedValue = dataSet.Tables[0].Rows[0]["UserTypeCode"].ToString();
            if (dataSet.Tables[0].Rows[0]["cand_cat_code"].ToString() != "")
                imgUser.Attributes.Add("src", "http://myaxactweb:200/images/members/user/" + dataSet.Tables[0].Rows[0]["cand_cat_code"].ToString() + ".jpg");
            tr2.Visible = true;
            tr1.Visible = true;
            tr3.Visible = true;
            lblMsg.Visible = false;
        }
        BindDomain();
        BindUserWork();
    }

    private void BindDomain()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllDomainByUser", connection);
        selectCommand.Parameters.AddWithValue("@UserCode", hdfUserID.Value);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        chblistDomain.DataSource = dataSet;
        chblistDomain.DataTextField = "Domain_Name";
        chblistDomain.DataValueField = "Domain_Code";
        chblistDomain.DataBind();
        foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
        {
            foreach (ListItem listItem in chblistDomain.Items)
            {
                if (listItem.Value == row["Domain_Code"].ToString())
                    listItem.Selected = row["IsMark"].ToString() == "1";
            }
        }
    }

    private void BindLinks(Repeater rpt)
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectParentMenuLink", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        rpt.DataSource = dataSet;
        rpt.DataBind();
    }

    private void BindUserWork()
    {
        BindLinks(rptCategory);
    }

    private void InserMenuLinkRoleAssociation(string UserTypeID, string MenuLinkID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_InsertLinkUserTypeRights", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkID);
        sqlCommand.Parameters.AddWithValue("@UserTypeID", UserTypeID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void InserMenuLinkUserAssociation(string UserID, string MenuLinkID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_InsertLinkUserRights", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkID);
        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@LinkType", 1);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void UpdateUserType(string UserID, string UserTypeCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_UpdateUserType", connection);
        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", UserTypeCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void InsertUserDomain(string UserID, string DomainCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_InsertDomainUserRights", connection);
        sqlCommand.Parameters.AddWithValue("@DomainID", DomainCode);
        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
        sqlCommand.Parameters.AddWithValue("@TeamUserTypeCode", 1);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void removeMenuLinkUserAssociation(string UserID, string MenuLinkID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkUserRights", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkID);
        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@LinkType", 1);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void removeMenuLinkRoleAssociation(string UserTypeID, string MenuLinkID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkUserTypeRights", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkID);
        sqlCommand.Parameters.AddWithValue("@UserTypeID", UserTypeID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void removeDomainUserAssociation(string UserTypeID, string DomainID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteDomainUserRights", connection);
        sqlCommand.Parameters.AddWithValue("@DomainID", DomainID);
        sqlCommand.Parameters.AddWithValue("@UserID", UserTypeID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void removeMenuLinkParentUserAssociation(string UserID, string MenuLinkID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkUserRightsByParent", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkID);
        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.Parameters.AddWithValue("@LinkType", 1);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void removeMenuLinkParentRoleAssociation(string UserTypeID, string MenuLinkID)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_DeleteLinkUserTypeRightsByParent", connection);
        sqlCommand.Parameters.AddWithValue("@MenuLinkID", MenuLinkID);
        sqlCommand.Parameters.AddWithValue("@UserTypeID", UserTypeID);
        sqlCommand.Parameters.AddWithValue("@UpdatedBy", UserCode);
        sqlCommand.Parameters.AddWithValue("@UpdatedIP", Request.UserHostAddress.ToString());
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Convert.ToString(sqlCommand.ExecuteScalar());
    }

    private void GetRole()
    {
        SqlCommand selectCommand = new SqlCommand("XRec_SelectAllUserType", connection);
        selectCommand.Parameters.AddWithValue("@UserTypeCode", ddlTeamUserType.SelectedValue);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            lblUserTypeName.Text = dataSet.Tables[0].Rows[0]["UserType"].ToString();
            imgUser.Src = "/assets/images/Face10.jpg";
            tr2.Visible = false;
            tr1.Visible = false;
            tr3.Visible = false;
        }
        BindLinks(rptRoleLink);
    }
    #endregion


}