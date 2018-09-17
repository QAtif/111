using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

public partial class RecruitmentAdmin_CandidateDocuments_ManageDocuments : CustomBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindDocumentType();
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
    protected void rptDocumentType_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            try
            {
                Repeater rptDocument = (Repeater)e.Item.FindControl("rptDocument");
                HiddenField hdnDocumentTypeCode = (HiddenField)e.Item.FindControl("hdnDocumentTypeCode");
                HiddenField hdnProgramCode = (HiddenField)e.Item.FindControl("hdnProgramCode");
                HtmlAnchor aEdit = (HtmlAnchor)e.Item.FindControl("aEdit");
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("tr");
                HtmlAnchor aAdd = (HtmlAnchor)e.Item.FindControl("aAdd");

                aEdit.HRef = "AddEditDocumentType.aspx?dtc=" + hdnDocumentTypeCode.Value + "&pc=" + hdnProgramCode.Value.ToString();
                aAdd.HRef = "AddEditDocument.aspx?dtc=" + hdnDocumentTypeCode.Value;

                BindDocuments(rptDocument, hdnDocumentTypeCode.Value);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
        }
    }
    protected void rptDocument_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            try
            {
                HiddenField hfDocTypeCode = (HiddenField)e.Item.FindControl("hfDocTypeCode");
                HtmlAnchor aEdit = (HtmlAnchor)e.Item.FindControl("aEdit");
                HiddenField hdnDocumentCode = (HiddenField)e.Item.FindControl("hdnDocumentCode");

                aEdit.HRef = "AddEditDocument.aspx?dc=" + hdnDocumentCode.Value.ToString() + "&dtc=" + hfDocTypeCode.Value.ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
        }
    }
    protected void rptDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet objDS = new DataSet();
            if (e.CommandName == "Delete")
            {
                using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    c.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("XRec_DeactivateDocument", c))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@DocumentCode", Convert.ToInt32(e.CommandArgument.ToString()));
                            command.Parameters.AddWithValue("@UpdatedBy", UserCode);
                            command.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                            command.ExecuteNonQuery();
                            BindDocumentType();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
    protected void rptDocumentType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataSet objDS = new DataSet();
            if (e.CommandName == "Delete")
            {
                using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
                {
                    c.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("XRec_DeactivateDocumentType", c))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@DocumentTypeCode", Convert.ToInt32(e.CommandArgument.ToString()));
                            command.Parameters.AddWithValue("@UpdatedBy", UserCode);
                            command.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress.ToString());
                            command.ExecuteNonQuery();
                            BindDocumentType();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }
    public void BindDocumentType()
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XRec_SelectDocumentType", c))
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
                        rptDocumentType.DataSource = objDS;
                        rptDocumentType.DataBind();
                    }
                    else
                    {
                        rptDocumentType.DataSource = null;
                        rptDocumentType.DataBind();
                    }
                }
                else
                {
                    rptDocumentType.DataSource = null;
                    rptDocumentType.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
    }
    private void BindDocuments(Repeater PassedDocumentRpt, string DocumentType_Code)
    {
        DataSet objDS = new DataSet();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ToString()))
        {
            c.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("XRec_SelectAllDocumentOfType", c))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DocumentTypeCode", DocumentType_Code);
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        a.Fill(objDS);
                    }
                }
                if (objDS != null && objDS.Tables != null)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        PassedDocumentRpt.DataSource = objDS;
                        PassedDocumentRpt.DataBind();
                    }
                    else
                    {
                        PassedDocumentRpt.DataSource = null;
                        PassedDocumentRpt.DataBind();
                    }
                }
                else
                {
                    PassedDocumentRpt.DataSource = null;
                    PassedDocumentRpt.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError.Write(LogError.AppType.Candidate, ex.Message + " " + ex.StackTrace, ex, Session["CC"].ToString());
            }
        }
    }
}