using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Question : XRecBase
{
    static DataView objDV = new DataView();
    PagedDataSource objPDS = new System.Web.UI.WebControls.PagedDataSource();
    static int PgSize;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PgSize = 30;
            ShowData();
        }
    }
    public void ShowData()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);
        string strSQL = string.Empty;

        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            
            SqlCommand sqlCommand = new SqlCommand("XREC_Select_QuestionOption ", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
           

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
           
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblMsg.Visible = false;
                    tblMsg.Visible = false;
                    UpdatePanel1.Visible = true;                    
                    //rptSection.DataSource = dt;
                    //rptSection.DataBind();
                    objDV = dt.DefaultView;
                    PageNo = 0;
                    trPagingControls.Attributes.Add("style", "display:block");
                    lblMsg.Visible = false;                    
                    rptSection.DataSource = ApplyPaging(objDV, PageNo);                    
                    rptSection.DataBind();                    
                }
                else
                {
                    UpdatePanel1.Visible = false;
                    rptSection.DataSource = null;
                    rptSection.DataBind();
                    lblMsg.Visible = true;
                    tblMsg.Visible = true;

                    lblMsg.Text = "No record(s) found";
                    
                }
            }

            else
            {
                lblMsg.Visible = true;
                tblMsg.Visible = true;

                lblMsg.Text = "No record(s) found";
                UpdatePanel1.Visible = false;
                rptSection.DataSource = null;
                rptSection.DataBind();
               
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, ex.StackTrace, ex, UserID.ToString());
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
    protected void rptSection_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
            Label lblSno = (Label)e.Item.FindControl("lblSno");
            lblSno.Text = Convert.ToString((e.Item.ItemIndex + 1));
            
            
            btnDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this Section?')");

            HiddenField hfQuestionCode = (HiddenField)e.Item.FindControl("hfQuestionCode");
            HtmlAnchor btnEdit = (HtmlAnchor)e.Item.FindControl("btnEdit");

            string RedirectingLink = "AddEditQuestion.aspx?" + "qid" + "=" + hfQuestionCode.Value;

            btnEdit.Attributes.Add("href", RedirectingLink);
        }
    }

    protected void rptSection_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentConnection"].ConnectionString);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("XRec_Delete_Question", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@QuestionCode", e.CommandArgument);
                sqlCommand.Parameters.AddWithValue("@UpdatedByUser", UserID);
                sqlCommand.Parameters.AddWithValue("@UpdationIP", Request.UserHostAddress);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                Response.Redirect(Request.Path + (Request.QueryString.Count > 0 ? "?" + Request.QueryString : string.Empty), false);
            }

            catch (Exception exp1)
            {
                //throw exp1;
                ErrorLog.LogError.Write(ErrorLog.LogError.AppType.RecruitmentModule, exp1.StackTrace, exp1, UserID.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
    #region Paging
    private int PageNo
    {
        get
        {
            if (ViewState["PageNo"] != null)
                return Convert.ToInt32(ViewState["PageNo"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNo"] = value;
        }
    }

    public PagedDataSource ApplyPaging(System.Data.DataView DV, int PageNo)
    {
        objPDS.DataSource = DV;
        objPDS.AllowPaging =
        true;
        //objPDS.PageSize = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["PgSize"]); 
        objPDS.PageSize = PgSize;
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
            else
                if (objPDS.CurrentPageIndex == (objPDS.PageCount - 1))
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
        {
            //trLegends.Attributes.Add("style", "display:none");
            trPagingControls.Attributes.Add("style", "display:none");
        }
        return objPDS;
    }
    // Takes to the first page 
    protected void lnkbtnFirstPage_Click(object sender, EventArgs e)
    {
        PageNo = 0;
        rptSection.DataSource = ApplyPaging(objDV, PageNo);
        rptSection.DataBind();
    }
    // Takes To The Previous Page 
    protected void lnkbtnPrevPage_Click(object sender, EventArgs e)
    {
        PageNo--;
        rptSection.DataSource = ApplyPaging(objDV, PageNo);
        rptSection.DataBind();
    }
    // takes to the next page 
    protected void lnkbtnNextPage_Click(object sender, EventArgs e)
    {
        PageNo++;
        rptSection.DataSource = ApplyPaging(objDV, PageNo);
        rptSection.DataBind();
    }
    // takes to the last page 
    protected void lnkbtnLastPage_Click(object sender, EventArgs e)
    {
        PageNo =
        Convert.ToInt32(ViewState["PageCount"]) - 1;
        rptSection.DataSource = ApplyPaging(objDV, PageNo);
        rptSection.DataBind();
    }
    #endregion
}