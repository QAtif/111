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

public partial class RecruitmentAdmin_CandidateDocuments_AddEditDocument : CustomBasePage
{
    #region variables
    string DocumentCode = "0", DocumentTypeCode = "0";
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMsg.Visible = false;
            try
            {
                CheckQueryString();

                if (DocumentCode != "0" && DocumentTypeCode != "0")
                {
                    BindDocument();
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
            InsertDocument();
            Page.RegisterStartupScript("Close", "<script language=JavaScript> CloseHighSlideWithParentRefresh();</script>");

        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
    #endregion

    #region Methods
    private void BindDocument()
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XRec_SelectDocumentByDocumentCode", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DocumentCode", DocumentCode);
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        a.Fill(objDS);
                    }
                }
                if (objDS != null && objDS.Tables != null)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        txtDocument.Text = objDS.Tables[0].Rows[0]["Document_Name"].ToString();
                        btnAdd.Text = "Update Document";
                        lblHead.Text = "Edit Document";
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
        if (Request.QueryString["dc"] != null)
            DocumentCode = Request.QueryString["dc"].ToString();
        else
            DocumentCode = "0";
        if (Request.QueryString["dtc"] != null)
            DocumentTypeCode = Request.QueryString["dtc"].ToString();
        else
            DocumentTypeCode = "0";
    }
    private void InsertDocument()
    {
        CheckQueryString();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XREC_Insert_Update_Document", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DocumentCode", DocumentCode);
                    command.Parameters.AddWithValue("@DocumentTypeCode", DocumentTypeCode);
                    command.Parameters.AddWithValue("@UpdatedBy", UserCode.ToString());
                    command.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress.ToString());
                    command.Parameters.AddWithValue("@DocumentName", txtDocument.Text);
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