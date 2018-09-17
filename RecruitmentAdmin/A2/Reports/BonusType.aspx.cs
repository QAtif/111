using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ErrorLog;
using System.Configuration;

using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using XRecruitmentStatusLibrary;

public partial class Candidate_BonusType : CustomBasePage
{
    #region variable
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string QueryStringVar = string.Empty;
    SecureQueryString secQueryString = new SecureQueryString();
    static DataView objDV = new DataView();
    static int PageSize;
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            GetCandidateResume(ref connection);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void GetCandidateResume(ref SqlConnection connection)
    {
        SqlCommand selectCommand = new SqlCommand("XREC_Select_BonusType", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            rptResume.Visible = true;
            lblMsg.Visible = false;
            rptResume.DataSource = dataSet.Tables[0];
            rptResume.DataBind();
        }
        else
        {
            rptResume.DataSource = null;
            rptResume.DataBind();
            rptResume.Visible = false;
            lblMsg.Visible = true;
        }
    }

    protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
            return;
        ((Label)e.Item.FindControl("lblSno")).Text = Convert.ToString(e.Item.ItemIndex + 1);
        HtmlAnchor control1 = (HtmlAnchor)e.Item.FindControl("aIsChart");
        Label control2 = (Label)e.Item.FindControl("lblIsChart");
        if (DataBinder.Eval(e.Item.DataItem, "is_bonusChart").ToString() == "True")
        {
            control2.Text = "View Chart";
            control1.HRef = "BonusChart.aspx?btc=" + DataBinder.Eval(e.Item.DataItem, "BonusTypeCode").ToString();
            control1.Target = "_blank";
        }
        else
        {
            control2.Text = "-";
            control1.HRef = "javascript:;";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetCandidateResume(ref connection);
    }
}