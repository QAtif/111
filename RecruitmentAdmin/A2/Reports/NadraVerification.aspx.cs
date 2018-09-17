using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Web.Services;
using System.IO;
using System.Web.SessionState;
using ASP;


public partial class NadraVerification : CustomBasePage, IRequiresSessionState
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    public string UpdatedBy, UpdatedIP;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UpdatedBy = UserCode.ToString();
            UpdatedIP = USERIP.ToString();
            if (IsPostBack)
                return;
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            if (connection.State != ConnectionState.Open)
                connection.Open();
            BindSearch();
            ShowHideActions();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    private void ShowHideActions()
    {
        IEnumerable<HtmlGenericControl> allControlsOfType = Page.GetAllControlsOfType<HtmlGenericControl>();
        foreach (DataRow row in (InternalDataCollectionBase)DTActions.Rows)
        {
            foreach (Control control in allControlsOfType)
            {
                if (control.ClientID == "divAction" + row["MenuLinkActionCode"].ToString())
                    control.Visible = true;
            }
        }
    }

    public void BindSearch()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateForNadraVerification", connection);
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
        if (!string.IsNullOrEmpty(txtref.Text))
            selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = txtref.Text;
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = postedFromDate.Value;
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = postedToDate.Value;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {
            rptCanddiate.DataSource = dataTable;
            rptCanddiate.DataBind();
            lblError.Style.Add("display", "none");
            ShowHideActions();
        }
        else
        {
            rptCanddiate.DataSource = null;
            rptCanddiate.DataBind();
            lblError.Style.Add("display", "");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            BindSearch();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public DataTable GetCandidateForCPLCVerifiction()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.Select_CandidateForNadraVerification", connection);
        if (!string.IsNullOrEmpty(txtName.Text))
            selectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
        if (!string.IsNullOrEmpty(txtref.Text))
            selectCommand.Parameters.Add("@ReferenceNo", SqlDbType.VarChar).Value = txtref.Text;
        if (!string.IsNullOrEmpty(postedFromDate.Value))
            selectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = postedFromDate.Value;
        if (!string.IsNullOrEmpty(postedToDate.Value))
            selectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = postedToDate.Value;
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }

    private void BindData()
    {
    }

    protected void rptNadraStatus_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("aUnMarkStaus");
            HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("aMarkStaus");
            control1.Attributes.Add("onclick", "InsertNadraVerificationComments(" + dataItem["CandDoc_Code"] + "," + dataItem["NadraStatus_Code"].ToString() + ",'" + control1.ClientID + "','" + control2.ClientID + "',0)");
            control2.Attributes.Add("onclick", "InsertNadraVerificationComments(" + dataItem["CandDoc_Code"] + "," + dataItem["NadraStatus_Code"].ToString() + ",'" + control2.ClientID + "','" + control1.ClientID + "',1)");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCanddiate_OnDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            if (dataItem["CandDoc_Code"].ToString() != "0")
            {
                SqlCommand selectCommand = new SqlCommand("dbo.select_NadraStatus", connection);
                selectCommand.Parameters.Add("@CandDoc_Code", SqlDbType.VarChar).Value = dataItem["CandDoc_Code"].ToString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                Repeater control1 = (Repeater)e.Item.FindControl("rptNadraStatus");
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    control1.DataSource = dataTable;
                    control1.DataBind();
                }
                HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("abrowseFile");
                HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
                LinkButton control4 = (LinkButton)e.Item.FindControl("lnkUploadPic");
                FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
                control2.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
                control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
                control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
                TextBox control6 = (TextBox)e.Item.FindControl("txtcomments");
                HtmlAnchor control7 = (HtmlAnchor)e.Item.FindControl("aSaveComment");
                HtmlImage control8 = (HtmlImage)e.Item.FindControl("imgDone");
                control7.Attributes.Add("onclick", "Update_APMVerificationComment(" + dataItem["CandDoc_Code"].ToString() + ",'" + control6.ClientID + "','" + control8.ClientID + "').click()");
            }
            Repeater control9 = (Repeater)e.Item.FindControl("rptFamily");
            HiddenField control10 = (HiddenField)e.Item.FindControl("HdnCandidateCode");
            SqlCommand selectCommand1 = new SqlCommand("dbo.Select_CandidateFamilyMemberForVerification", connection);
            selectCommand1.Parameters.Add("@Candidate_Code", SqlDbType.VarChar).Value = control10.Value;
            selectCommand1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
            if (dataTable1 != null && dataTable1.Rows.Count > 0)
            {
                control9.DataSource = dataTable1;
                control9.DataBind();
            }
            HtmlAnchor control11 = (HtmlAnchor)e.Item.FindControl("aBrowseNic");
            HtmlAnchor control12 = (HtmlAnchor)e.Item.FindControl("aEditbrowse");
            LinkButton control13 = (LinkButton)e.Item.FindControl("lnkSaveImg");
            FileUpload control14 = (FileUpload)e.Item.FindControl("funic");
            control11.Attributes.Add("onclick", "$('#" + control14.ClientID + "').click()");
            control12.Attributes.Add("onclick", "$('#" + control14.ClientID + "').click()");
            control14.Attributes.Add("onchange", "$('#" + control13.ClientID + "').show();");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptCanddiate_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "UploadNic")
            {
                FileUpload control = (FileUpload)e.Item.FindControl("Fu");
                if (control.HasFile)
                {
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "NadraNic/" + e.CommandArgument + "/";
                    if (control.HasFile)
                    {
                        GeneralMethods.FileBrowse(control, FolderPath, "NadraNic");
                        string str = FolderPath + "NadraNic" + Path.GetExtension(control.FileName);
                        connection.Open();
                        SqlCommand sqlCommand = new SqlCommand("dbo.update_NadraNicPath", connection);
                        sqlCommand.Parameters.AddWithValue("@CanDoc_Code", e.CommandArgument);
                        sqlCommand.Parameters.AddWithValue("@NadraNicPath", str);
                        sqlCommand.Parameters.AddWithValue("@updatedby", UserCode);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.ExecuteNonQuery();
                        Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>location.reload(true);</script>");
                    }
                }
            }
            if (!(e.CommandName == "Nic"))
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnCanDocCode");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCanCode1");
            FileUpload control3 = (FileUpload)e.Item.FindControl("funic");
            if (!control3.HasFile)
                return;
            string FolderPath1 = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "NadraNic/" + e.CommandArgument + "/";
            if (!control3.HasFile)
                return;
            GeneralMethods.FileBrowse(control3, FolderPath1, "Nic");
            string str1 = FolderPath1 + "Nic" + Path.GetExtension(control3.FileName);
            connection.Open();
            SqlCommand sqlCommand1 = new SqlCommand("dbo.Insert_update_Candidate_NicPath", connection);
            sqlCommand1.Parameters.AddWithValue("@CandDoc_Code", control1.Value);
            sqlCommand1.Parameters.AddWithValue("@CandidateCode", control2.Value);
            sqlCommand1.Parameters.AddWithValue("@DocumentPath", str1);
            sqlCommand1.Parameters.AddWithValue("@UpdatedBy", UserCode.ToString());
            sqlCommand1.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.ExecuteNonQuery();
            Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>location.reload(true);</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptFamily_OnItemCammand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "UploadNic")
            {
                FileUpload control = (FileUpload)e.Item.FindControl("Fu");
                if (control.HasFile)
                {
                    string FolderPath = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "NadraNic/" + e.CommandArgument + "/";
                    if (control.HasFile)
                    {
                        GeneralMethods.FileBrowse(control, FolderPath, "NadraNic");
                        string str = FolderPath + "NadraNic" + Path.GetExtension(control.FileName);
                        connection.Open();
                        SqlCommand sqlCommand = new SqlCommand("dbo.update_NadraNicPath", connection);
                        sqlCommand.Parameters.AddWithValue("@CanDoc_Code", e.CommandArgument);
                        sqlCommand.Parameters.AddWithValue("@NadraNicPath", str);
                        sqlCommand.Parameters.AddWithValue("@updatedby", UserCode);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.ExecuteNonQuery();
                        Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>location.reload(true);</script>");
                    }
                }
            }
            if (!(e.CommandName == "Nic"))
                return;
            HiddenField control1 = (HiddenField)e.Item.FindControl("hdnMemberCode");
            HiddenField control2 = (HiddenField)e.Item.FindControl("hdnCanCode");
            FileUpload control3 = (FileUpload)e.Item.FindControl("funic");
            if (!control3.HasFile)
                return;
            string FolderPath1 = ConfigurationManager.AppSettings["CandidateDocumentsPath"].ToString() + "NadraNic/" + e.CommandArgument + "/";
            if (!control3.HasFile)
                return;
            GeneralMethods.FileBrowse(control3, FolderPath1, "Nic");
            string str1 = FolderPath1 + "Nic" + Path.GetExtension(control3.FileName);
            connection.Open();
            SqlCommand sqlCommand1 = new SqlCommand("dbo.Insert_update_NicPath", connection);
            sqlCommand1.Parameters.AddWithValue("@MemberCode", control1.Value);
            sqlCommand1.Parameters.AddWithValue("@CandidateCode", control2.Value);
            sqlCommand1.Parameters.AddWithValue("@DocumentPath", str1);
            sqlCommand1.Parameters.AddWithValue("@UpdatedBy", UserCode.ToString());
            sqlCommand1.Parameters.AddWithValue("@UpdatedIp", USERIP);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.ExecuteNonQuery();
            Page.RegisterStartupScript("REFRESHpAGESCRIPT", "<script language=JavaScript>location.reload(true);</script>");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptFamily_OnitemDataBind(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            if (dataItem["CandDoc_Code"].ToString() != "0" && !string.IsNullOrEmpty(dataItem["CandDoc_Code"].ToString()))
            {
                Repeater control1 = (Repeater)e.Item.FindControl("rptNadraStatus");
                SqlCommand selectCommand = new SqlCommand("dbo.select_NadraStatus", connection);
                selectCommand.Parameters.Add("@CandDoc_Code", SqlDbType.VarChar).Value = dataItem["CandDoc_Code"].ToString();
                selectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    control1.DataSource = dataTable;
                    control1.DataBind();
                }
                HtmlAnchor control2 = (HtmlAnchor)e.Item.FindControl("abrowseFile");
                HtmlAnchor control3 = (HtmlAnchor)e.Item.FindControl("AimgEdit");
                LinkButton control4 = (LinkButton)e.Item.FindControl("lnkUploadPic");
                FileUpload control5 = (FileUpload)e.Item.FindControl("Fu");
                control2.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
                control3.Attributes.Add("onclick", "$('#" + control5.ClientID + "').click()");
                control5.Attributes.Add("onchange", "$('#" + control4.ClientID + "').show();");
                TextBox control6 = (TextBox)e.Item.FindControl("txtcomments");
                HtmlAnchor control7 = (HtmlAnchor)e.Item.FindControl("aSaveComment");
                HtmlImage control8 = (HtmlImage)e.Item.FindControl("imgDone");
                control7.Attributes.Add("onclick", "Update_APMVerificationComment(" + dataItem["CandDoc_Code"].ToString() + ",'" + control6.ClientID + "','" + control8.ClientID + "').click()");
            }
            HtmlAnchor control9 = (HtmlAnchor)e.Item.FindControl("aBrowseNic");
            HtmlAnchor control10 = (HtmlAnchor)e.Item.FindControl("aEditbrowse");
            LinkButton control11 = (LinkButton)e.Item.FindControl("lnkSaveImg");
            FileUpload control12 = (FileUpload)e.Item.FindControl("funic");
            control9.Attributes.Add("onclick", "$('#" + control12.ClientID + "').click()");
            control10.Attributes.Add("onclick", "$('#" + control12.ClientID + "').click()");
            control12.Attributes.Add("onchange", "$('#" + control11.ClientID + "').show();");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    [WebMethod]
    public static void InsertNadraVerificationComments(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 5)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Insert_NadraVerificationComments", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@NadraStatusCode", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@Updatedby", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedIP", strArray[3].ToString());
            sqlCommand.Parameters.AddWithValue("@IsActive", strArray[4].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            if (((IEnumerable<string>)strArray).Count<string>() >= 3)
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[2].ToString());
            else
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }

    [WebMethod]
    public static void Update_APMVerificationComment(string items)
    {
        string[] strArray = new string[0];
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
            strArray = items.Split('|');
            if (((IEnumerable<string>)strArray).Count<string>() < 4)
                return;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Update_APMVerificationComment", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CandDoc_Code", strArray[0].ToString());
            sqlCommand.Parameters.AddWithValue("@APMComments", strArray[1].ToString());
            sqlCommand.Parameters.AddWithValue("@Updatedby", strArray[2].ToString());
            sqlCommand.Parameters.AddWithValue("@UpdatedIP", strArray[3].ToString());
            sqlCommand.ExecuteScalar();
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }
        catch (Exception ex)
        {
            if (((IEnumerable<string>)strArray).Count<string>() >= 3)
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, strArray[2].ToString());
            else
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, "0");
        }
    }

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        DataTable forCplcVerifiction = GetCandidateForCPLCVerifiction();
        if (forCplcVerifiction.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(forCplcVerifiction, "@E:\\products\\Record.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=CPLCVerificationSheet.xls";
        Page.Response.ClearContent();
        Response.AddHeader("content-disposition", str1);
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            if (column.ColumnName != "IsExsist" && column.ColumnName != "CPLCStatus" && column.ColumnName != "Candidate_Code")
            {
                Response.Write(str2 + column.ColumnName);
                str2 = "\t";
            }
        }
        Response.Write("\n");
        foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
        {
            string str3 = "";
            for (int index = 0; index < table.Columns.Count; ++index)
            {
                if (table.Columns[index].ColumnName != "IsExsist" && table.Columns[index].ColumnName != "CPLCStatus" && table.Columns[index].ColumnName != "Candidate_Code")
                {
                    Response.Write(str3 + row[index].ToString());
                    str3 = "\t";
                }
            }
            Response.Write("\n");
        }
        Response.End();
    }

}