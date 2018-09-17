using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;


public partial class MapDegree : CustomBasePage, IRequiresSessionState
{
    SecureQueryString sQString = new SecureQueryString();
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            BindMappedDegree();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void rptInstitute_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
        HiddenField control = (HiddenField)e.Item.FindControl("hdRefNo");
        ((HtmlAnchor)e.Item.FindControl("a1")).HRef = "../../A2/candidate/CandidateProfile.aspx?" + SecureQueryString.QueryStringVar + "=" + sQString.encrypt("CID=" + control.Value);
    }

    private void BindUnMappedDegree()
    {
        DataTable table = AdminClass.GetUnmappedDegree(txtSearchKeyword.Text.Trim()).Tables[0];
        if (table.Rows.Count > 0)
        {
            rptInstitute.DataSource = table;
            rptInstitute.DataBind();
        }
        else
        {
            rptInstitute.DataSource = null;
            rptInstitute.DataBind();
        }
    }

    private void BindMappedDegree()
    {
        DataSet mappedDegree = AdminClass.GetMappedDegree();
        if (mappedDegree == null)
            return;
        if (mappedDegree.Tables.Count > 1)
        {
            client2View.DataSource = mappedDegree.Tables[0];
            client2View.DataBind();
        }
        if (mappedDegree.Tables.Count < 2)
            return;
        DDlProgram.DataSource = mappedDegree.Tables[1];
        DDlProgram.DataTextField = "Program_Name";
        DDlProgram.DataValueField = "Program_Code";
        DDlProgram.DataBind();
    }

    protected void BtnSearchFresh_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        int DegreeCode = int.Parse(client2View.SelectedValue);
        for (int index = 0; index <= rptInstitute.Items.Count - 1; ++index)
        {
            if (((HtmlControl)rptInstitute.Items[index].FindControl("trRecord")).Style["display"] == null && ((CheckBox)rptInstitute.Items[index].FindControl("chk")).Checked)
            {
                HiddenField control = (HiddenField)rptInstitute.Items[index].FindControl("hdfDegreeCode");
                str = str + "," + control.Value;
            }
        }
        string UnMappedDegreeCode = str.TrimStart(',');
        try
        {
            AdminClass.UpdateDegreeMapping(DegreeCode, UnMappedDegreeCode, Request.UserHostAddress);
            BindMappedDegree();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void imgInstitute_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            AdminClass.InsertDegreeMapping(txtDegree.Text, Request.UserHostAddress, UserCode, Convert.ToInt32(DDlProgram.SelectedValue));
            txtDegree.Text = string.Empty;
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Degree Entered Successfully!.');", true);
            BindMappedDegree();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void txtSearchKeyword_TextChanged(object sender, EventArgs e)
    {
        if (txtSearchKeyword.Text.Trim().Length < 3)
            return;
        BindUnMappedDegree();
    }
}