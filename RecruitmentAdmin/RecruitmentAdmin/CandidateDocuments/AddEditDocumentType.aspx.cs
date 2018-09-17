using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections;
using ErrorLog;

public partial class RecruitmentAdmin_CandidateDocuments_AddEditDocumentType : CustomBasePage
{
    #region variables
    string ProgramCode = "0", DocumentTypeCode = "0";
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMsg.Visible = false;
            try
            {
                BindDll();
                CheckQueryString();

                if (DocumentTypeCode != "0")
                {
                    BindDocumentTypes();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
        }
    }    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            InsertDocumentType();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");

        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
    #endregion

    #region Methods
    private void BindDll()
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XRec_SelectAllProgram", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        a.Fill(objDS);
                    }
                }
                if (objDS != null && objDS.Tables != null)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        ddlPrograms.DataSource = objDS;
                        ddlPrograms.DataTextField = "Program_Name";
                        ddlPrograms.DataValueField = "Program_Code";
                        ddlPrograms.DataBind();
                        ddlPrograms.Items.Insert(0,new System.Web.UI.WebControls.ListItem("N/A", "0"));
                        ddlPrograms.SelectedIndex = 0;
                    }                    
                }                
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
    }
    private void BindDocumentTypes()
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XRec_SelectDocumentTypeByDocumentTypeCode", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DocumentTypeCode", DocumentTypeCode);
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        a.Fill(objDS);
                    }
                }
                if (objDS != null && objDS.Tables != null)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        txtDocumentTypeName.Text = objDS.Tables[0].Rows[0]["DocumentTypeName"].ToString();
                        ddlPrograms.SelectedValue = objDS.Tables[0].Rows[0]["ProgramCode"].ToString();
                        btnAdd.Text = "Update DocumentType";
                        lblHead.Text = "Edit DocumentType";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
        }
    }
    private void CheckQueryString()
    {
        if (Request.QueryString["dtc"] != null)
            DocumentTypeCode = Request.QueryString["dtc"].ToString();
        else
            DocumentTypeCode = "0";
        if (Request.QueryString["pc"] != null)
            ProgramCode = Request.QueryString["pc"].ToString();
        else
            DocumentTypeCode = "0";
    }
    private void InsertDocumentType()
    {
        CheckQueryString();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XREC_Insert_Update_DocumentType", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DocumentTypeCode", DocumentTypeCode);
                    command.Parameters.AddWithValue("@UpdatedBy", UserCode.ToString());
                    command.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress.ToString());
                    command.Parameters.AddWithValue("@DocumentTypeName", txtDocumentTypeName.Text);
                    command.Parameters.AddWithValue("@ProgramCode", ddlPrograms.SelectedValue.ToString());
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
    }
    #endregion
}