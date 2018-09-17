using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using XRecruitmentStatusLibrary;
using ErrorLog;
using System.Collections;

public partial class OfferApproval : CustomBasePage
{
    #region Variables
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString());
    public string usercode = "0";
    int UserTypeCode = 1;
    public static DataView objDV = new DataView();
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    public static int PgSize;
    int count = 0;
    #endregion

    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            OfferApproval.PgSize = 10;
            if (IsPostBack)
                return;
            postedFromDate.Attributes.Add("readonly", "readonly");
            postedFromDate.Value = DateTime.Now.AddMonths(-1).ToString("MMM dd, yyyy");
            postedToDate.Attributes.Add("readonly", "readonly");
            postedToDate.Value = DateTime.Now.ToString("MMM dd, yyyy");
            BindOGData();
            BindData();
            ShowHideActions();
        }
        catch
        {
        }
    }

    protected void rptjdlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
                return;
            ((Label)e.Item.FindControl("lblSno")).Text = (e.Item.ItemIndex + 1).ToString();
            HtmlInputCheckBox control1 = (HtmlInputCheckBox)e.Item.FindControl("chkCandidate");
            DataSet candidateOfferApproval = GetCandidateOfferApproval(int.Parse(((HiddenField)e.Item.FindControl("hdnCand_Cat_Code")).Value));
            if (candidateOfferApproval.Tables[0].Rows.Count <= 0 || candidateOfferApproval.Tables[0].Rows.Count <= 0)
                return;
            Literal control2 = (Literal)e.Item.FindControl("ltrHR");
            foreach (DataRow dataRow in candidateOfferApproval.Tables[0].Select("UserTypeCode=" + Convert.ToInt32(Constants.UserTypeCode.DomainOwner)))
            {
                if (int.Parse(hdnUserTypeCode.Value) == Convert.ToInt32(Constants.UserTypeCode.DomainOwner))
                    ((HtmlControl)e.Item.FindControl("divAction66")).Style["display"] = "none";
                control2.Text = int.Parse(dataRow["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) ? "Approved" : "Rejected";
            }
            Literal control3 = (Literal)e.Item.FindControl("ltrDO");
            foreach (DataRow dataRow in candidateOfferApproval.Tables[0].Select("UserTypeCode=" + Convert.ToInt32(Constants.UserTypeCode.DomainOwnerOtherDept)))
            {
                if (int.Parse(hdnUserTypeCode.Value) == Convert.ToInt32(Constants.UserTypeCode.DomainOwnerOtherDept))
                    ((HtmlControl)e.Item.FindControl("divAction67")).Style["display"] = "none";
                control3.Text = int.Parse(dataRow["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) ? "Approved" : "Rejected";
            }
            Literal control4 = (Literal)e.Item.FindControl("ltrOPD");
            foreach (DataRow dataRow in candidateOfferApproval.Tables[0].Select("UserTypeCode=" + Convert.ToInt32(Constants.UserTypeCode.OPD)))
            {
                if (int.Parse(hdnUserTypeCode.Value) == Convert.ToInt32(Constants.UserTypeCode.OPD))
                    ((HtmlControl)e.Item.FindControl("divAction68")).Style["display"] = "none";
                control4.Text = int.Parse(dataRow["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) ? "Approved" : "Rejected";
            }
            Literal control5 = (Literal)e.Item.FindControl("ltrAA");
            foreach (DataRow dataRow in candidateOfferApproval.Tables[0].Select("UserTypeCode=" + Convert.ToInt32(Constants.UserTypeCode.Audit)))
            {
                if (int.Parse(hdnUserTypeCode.Value) == Convert.ToInt32(Constants.UserTypeCode.Audit))
                    ((HtmlControl)e.Item.FindControl("divAction69")).Style["display"] = "none";
                control5.Text = int.Parse(dataRow["OfferApprovalStatus_Code"].ToString()) == Convert.ToInt32(Constants.OfferApprovalStatus.Approved) ? "Approved" : "Rejected";
            }
        }
        catch
        {
        }
    }

    private void UpdateOfferApprovalStatus(int Candidate_Code, int offerApprovalStatusCode, int userTypeCode)
    {
        SqlCommand sqlCommand = new SqlCommand("XRec_UpdateOfferApprovalStatus", c);
        sqlCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_Code);
        sqlCommand.Parameters.AddWithValue("@OfferApproval_Code", offerApprovalStatusCode);
        sqlCommand.Parameters.AddWithValue("@UserTypeCode", userTypeCode);
        sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
        sqlCommand.Parameters.AddWithValue("@Updated_IP", Request.UserHostAddress);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.ExecuteNonQuery();
    }

    protected void rptjdlist_CommandArguments(object sender, RepeaterCommandEventArgs e)
    {
        if (!(e.CommandName == "ApproveHR"))
        {
            if (!(e.CommandName == "DisapproveHR"))
                goto label_6;
        }
        try
        {
            c.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveHR" ? Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected), int.Parse(hdnUserTypeCode.Value));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_6:
        if (!(e.CommandName == "ApproveDO"))
        {
            if (!(e.CommandName == "DisapproveDO"))
                goto label_12;
        }
        try
        {
            c.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveDO" ? Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.DORejected), int.Parse(hdnUserTypeCode.Value));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_12:
        if (!(e.CommandName == "ApproveOPD"))
        {
            if (!(e.CommandName == "DisapproveOPD"))
                goto label_19;
        }
        try
        {
            c.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveOPD" ? Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected), int.Parse(hdnUserTypeCode.Value));
            if (e.CommandName == "ApproveOPD")
                StatusManagement.MarkLifeCycleStatus(c, Convert.ToInt32(e.CommandArgument.ToString()), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending, Request.UserHostAddress.ToString(), UserCode);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_19:
        if (!(e.CommandName == "ApproveAA"))
        {
            if (!(e.CommandName == "DisapproveAA"))
                goto label_25;
        }
        try
        {
            c.Open();
            UpdateOfferApprovalStatus(int.Parse(e.CommandArgument.ToString()), e.CommandName == "ApproveAA" ? Convert.ToInt32(Constants.OfferApprovalStatus.Approved) : Convert.ToInt32(Constants.OfferApprovalStatus.Rejected), int.Parse(hdnUserTypeCode.Value));
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_25:
        if (!(e.CommandName == "ApproveHRAll"))
        {
            if (!(e.CommandName == "DisapproveHRAll"))
                goto label_35;
        }
        try
        {
            c.Open();
            for (int index = 0; index <= rptJDLIst.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptJDLIst.Items[index].FindControl("hdnCand_Cat_Code");
                if (((HtmlInputCheckBox)rptJDLIst.Items[index].FindControl("chkCandidate")).Checked)
                    UpdateOfferApprovalStatus(int.Parse(control.Value), e.CommandName == "ApproveHRAll" ? Convert.ToInt32(Constants.OfferApprovalStatus.DOApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.HRPPDRejected), int.Parse(hdnUserTypeCode.Value));
            }
        }
        catch
        {
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_35:
        if (!(e.CommandName == "ApproveDOAll"))
        {
            if (!(e.CommandName == "DisapproveDOAll"))
                goto label_45;
        }
        try
        {
            c.Open();
            for (int index = 0; index <= rptJDLIst.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptJDLIst.Items[index].FindControl("hdnCand_Cat_Code");
                if (((HtmlInputCheckBox)rptJDLIst.Items[index].FindControl("chkCandidate")).Checked)
                    UpdateOfferApprovalStatus(int.Parse(control.Value), e.CommandName == "ApproveDOAll" ? Convert.ToInt32(Constants.OfferApprovalStatus.OPDApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.DORejected), int.Parse(hdnUserTypeCode.Value));
            }
        }
        catch
        {
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_45:
        if (!(e.CommandName == "ApproveOPDAll"))
        {
            if (!(e.CommandName == "DisapproveOPDAll"))
                goto label_56;
        }
        try
        {
            c.Open();
            for (int index = 0; index <= rptJDLIst.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptJDLIst.Items[index].FindControl("hdnCand_Cat_Code");
                if (((HtmlInputCheckBox)rptJDLIst.Items[index].FindControl("chkCandidate")).Checked)
                {
                    UpdateOfferApprovalStatus(int.Parse(control.Value), e.CommandName == "ApproveOPDAll" ? Convert.ToInt32(Constants.OfferApprovalStatus.AutidApprovalPending) : Convert.ToInt32(Constants.OfferApprovalStatus.OPDRejected), int.Parse(hdnUserTypeCode.Value));
                    if (e.CommandName == "ApproveOPDAll")
                        StatusManagement.MarkLifeCycleStatus(c, Convert.ToInt32(control.Value), Constants.ModuleCode.LifeCycleStatus, Constants.CandidateLifeCycleStatus.InterviewPassedOfferGenerationPending, Request.UserHostAddress.ToString(), UserCode);
                }
            }
        }
        catch
        {
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
        label_56:
        if (!(e.CommandName == "ApproveAAAll"))
        {
            if (!(e.CommandName == "DisapproveAAAll"))
                return;
        }
        try
        {
            c.Open();
            for (int index = 0; index <= rptJDLIst.Items.Count - 1; ++index)
            {
                HiddenField control = (HiddenField)rptJDLIst.Items[index].FindControl("hdnCand_Cat_Code");
                if (((HtmlInputCheckBox)rptJDLIst.Items[index].FindControl("chkCandidate")).Checked)
                    UpdateOfferApprovalStatus(int.Parse(control.Value), e.CommandName == "ApproveAAAll" ? Convert.ToInt32(Constants.OfferApprovalStatus.Approved) : Convert.ToInt32(Constants.OfferApprovalStatus.Rejected), int.Parse(hdnUserTypeCode.Value));
            }
        }
        catch
        {
        }
        finally
        {
            c.Close();
        }
        BindData();
        ShowHideActions();
    }

    protected void btn_SearchClick(object sender, EventArgs e)
    {
        try
        {
            BindData();
            ShowHideActions();
        }
        catch
        {
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

    private string BindName()
    {
        DataTable dataTable = (DataTable)null;
        c.Open();
        SqlCommand selectCommand = new SqlCommand("dbo.SelectJDs", c);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.ExecuteNonQuery();
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
        {
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
        }
        c.Close();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("[");
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
            stringBuilder.Append("\"" + dataTable.Rows[index]["jd_name"].ToString() + "\"");
            if (index != dataTable.Rows.Count - 1)
                stringBuilder.Append(",");
        }
        stringBuilder.Append("];");
        return stringBuilder.ToString();
    }

    public static void CreateFolder(string FolderPath)
    {
        string empty = string.Empty;
        string path = !OfferApproval.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    public static bool IsValidPath(string path)
    {
        return new Regex("^(?:[a-zA-Z]\\:|\\\\\\\\[\\w\\.]+\\\\[\\w.]+)\\\\(?:[\\w]+\\\\)*").IsMatch(path);
    }

    public static string FileBrowse(FileUpload Source, string FolderPath)
    {
        OfferApproval.CreateFolder(FolderPath);
        string fileName = Source.FileName;
        string str = !OfferApproval.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath) : FolderPath;
        if (fileName != "" && Source.HasFile)
        {
            string filename = str + "\\" + fileName;
            Source.SaveAs(filename);
        }
        return fileName;
    }

    public static void FileResponse(string filename, string FolderPath)
    {
        string empty = string.Empty;
        FileInfo fileInfo = new FileInfo(!OfferApproval.IsValidPath(FolderPath) ? HttpContext.Current.Server.MapPath(FolderPath + "/" + filename) : FolderPath + "/" + filename);
        if (!fileInfo.Exists)
            return;
        BinaryReader binaryReader = new BinaryReader((Stream)fileInfo.OpenRead());
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        byte[] buffer = binaryReader.ReadBytes((int)fileInfo.Length);
        binaryReader.Close();
        HttpContext.Current.Response.BinaryWrite(buffer);
    }

    public void search()
    {
        try
        {
            DataSet dataSet = new DataSet();
            SqlCommand selectCommand = new SqlCommand("Select_OfferForApproval", c);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                rptJDLIst.DataSource = dataSet.Tables[0];
                rptJDLIst.DataBind();
                trFound.Visible = true;
                trnorecords.Visible = false;
            }
            else
            {
                trFound.Visible = false;
                trnorecords.Visible = true;
            }
            c.Close();
        }
        catch
        {
        }
    }

    public DataSet GetCandidateOfferApproval(int candidateCode)
    {
        DataSet dataSet = new DataSet();
        SqlCommand selectCommand = new SqlCommand("Select_OfferApprovalStatusHistory", c);
        selectCommand.Parameters.AddWithValue("@CandidateCode", candidateCode);
        selectCommand.CommandType = CommandType.StoredProcedure;
        new SqlDataAdapter(selectCommand).Fill(dataSet);
        return dataSet;
    }

    public void BindOGData()
    {
        try
        {
            DataSet dataSet = new DataSet();
            c.Open();
            SqlCommand selectCommand = new SqlCommand("XRec_Select_Domain", c);
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            if (dataSet != null && dataSet.Tables[0].Rows.Count >= 0)
            {
                ddlDept.DataSource = dataSet.Tables[0];
                ddlDept.DataTextField = "Domain_Name";
                ddlDept.DataValueField = "Domain_Code";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, new ListItem("-- Select Department --", "-1"));
            }
            c.Close();
        }
        catch
        {
        }
    }

    public void BindData()
    {
        try
        {
            DataSet dataSet1 = new DataSet();
            SqlCommand selectCommand1 = new SqlCommand("XRec_SelectUserTypeByUser", c);
            selectCommand1.Parameters.AddWithValue("@UserCode", UserCode);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand1).Fill(dataSet1);
            if (dataSet1.Tables[0].Rows.Count > 0)
                hdnUserTypeCode.Value = dataSet1.Tables[0].Rows[0]["UserTypeCode"].ToString();
            SqlCommand selectCommand2 = new SqlCommand("XRec_SelectCandidateOfferDetail", c);
            selectCommand2.Parameters.AddWithValue("@DomainCode", ddlDept.SelectedValue);
            selectCommand2.Parameters.AddWithValue("@Email", txtEmail.Text);
            selectCommand2.Parameters.AddWithValue("@Name", txtName.Text);
            selectCommand2.Parameters.AddWithValue("@RefNo", txtRefNo.Text);
            selectCommand2.Parameters.AddWithValue("@FromDate", postedFromDate.Value);
            selectCommand2.Parameters.AddWithValue("@ToDate", postedToDate.Value);
            DataSet dataSet2 = new DataSet();
            selectCommand2.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand2).Fill(dataSet2);
            if (dataSet2 != null && dataSet2.Tables[0].Rows.Count > 0)
            {
                trFound.Visible = true;
                trnorecords.Visible = false;
                OfferApproval.objDV = dataSet2.Tables[0].DefaultView;
                PageNo = 0;
                trPagingControls.Attributes.Add("style", "display:block");
                rptJDLIst.DataSource = ApplyPaging(OfferApproval.objDV, PageNo);
                rptJDLIst.DataBind();
                hdCount.Value = rptJDLIst.Items.Count.ToString();
            }
            else
            {
                rptJDLIst.DataSource = null;
                rptJDLIst.DataBind();
                trFound.Visible = false;
                trnorecords.Visible = true;
            }
            c.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public PagedDataSource ApplyPaging(DataView DV, int PageNo)
    {
        objPDS.DataSource = (IEnumerable)DV;
        objPDS.AllowPaging = true;
        objPDS.PageSize = OfferApproval.PgSize;
        objPDS.CurrentPageIndex = PageNo;
        ViewState["PageCount"] = objPDS.PageCount.ToString();
        if (objPDS.PageCount > 1)
        {
            trPagingControls.Attributes.Add("style", "display:block");
            lblPageIndex.Visible = true;
            lblPageIndex.Font.Bold = true;
            lblPageIndex.Text = "Page : " + (objPDS.CurrentPageIndex + 1).ToString() + " of " + objPDS.PageCount.ToString();
            if (objPDS.CurrentPageIndex == 0)
            {
                lnkbtnFirstPage.Visible = false;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = false;
            }
            else if (objPDS.CurrentPageIndex == objPDS.PageCount - 1)
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = false;
                lnkbtnNextPage.Visible = false;
                lnkbtnPrevPage.Visible = true;
            }
            else
            {
                lnkbtnFirstPage.Visible = true;
                lnkbtnLastPage.Visible = true;
                lnkbtnNextPage.Visible = true;
                lnkbtnPrevPage.Visible = true;
            }
        }
        else
            trPagingControls.Attributes.Add("style", "display:none");
        return objPDS;
    }

    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptJDLIst.DataSource = ApplyPaging(OfferApproval.objDV, PageNo);
        rptJDLIst.DataBind();
    }

    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        --PageNo;
        rptJDLIst.DataSource = ApplyPaging(OfferApproval.objDV, PageNo);
        rptJDLIst.DataBind();
    }

    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        ++PageNo;
        rptJDLIst.DataSource = ApplyPaging(OfferApproval.objDV, PageNo);
        rptJDLIst.DataBind();
    }

    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo = Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptJDLIst.DataSource = ApplyPaging(OfferApproval.objDV, PageNo);
        rptJDLIst.DataBind();
    }


}