using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class area_viewprofile : CustomBaseClass
{
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    int displayCountEx = 0, displayCountEd = 0, displayCountpo = 0, displayCountde = 0, displayCountce = 0, displayCountFm=0;
    int DisplayLimit=1;
    protected void Page_Load(object sender, EventArgs e)
    {
        binddata();
        lnkExperience.HRef = DomainAddress + "profile/experience.aspx";
        lnkEducation.HRef = DomainAddress + "profile/education.aspx";
        lnkcertificate.HRef = DomainAddress + "profile/certificate.aspx";
        lnkDiplomas.HRef = DomainAddress + "profile/diploma.aspx";
        lnkSkillSet.HRef = DomainAddress + "profile/skillset.aspx";
        lnkPersonalInfo.HRef = DomainAddress + "profile/personaldetails.aspx";
        lnkContactInfo.HRef = DomainAddress + "profile/personaldetails.aspx";
        lnkPortfolio.HRef = DomainAddress + "profile/portfolio.aspx";
        lnkFamilyDatail.HRef = DomainAddress + "profile/familydetails.aspx";
    }

    private int GetProgressBarPencentage(int CanCode, int moduleCode)
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_GetPercentageBar", sqlCon);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@CandidateCode", CanCode);
        selectCommand.Parameters.AddWithValue("@ModuleCode", moduleCode);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        return int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
    }

    public void binddata()
    {
        try
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("Xrec_SelectCandidateDetails_View", connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@CandidateCode", Session["CC"].ToString());
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            if (dataSet != null && dataSet.Tables != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    lblExperience.Visible = false;
                    ListView1.DataSource = dataSet.Tables[0];
                    ListView1.DataBind();
                }
                else
                {
                    ListView1.DataSource = null;
                    lblExperience.Visible = true;
                    lblExperience.Text = "No record Found.";
                }
                if (dataSet.Tables[1].Rows.Count > 0)
                {
                    lbleducation.Visible = true;
                    lvEducation.Items.Clear();
                    lvEducation.DataSource = dataSet.Tables[1];
                    lvEducation.DataBind();
                }
                else
                {
                    lvEducation.Items.Clear();
                    lvEducation.DataSource = null;
                    lbleducation.Visible = true;
                    lbleducation.Text = "No record Found.";
                }
                if (dataSet.Tables[2].Rows.Count > 0)
                {
                    lblCertificate.Visible = false;
                    lvCertificate.Items.Clear();
                    lvCertificate.DataSource = dataSet.Tables[2];
                    lvCertificate.DataBind();
                }
                else
                {
                    lvCertificate.DataSource = null;
                    lblCertificate.Visible = true;
                    lblCertificate.Text = "No record Found.";
                }
                if (dataSet.Tables[3].Rows.Count > 0)
                {
                    lblDiploma.Visible = false;
                    lvDiploma.Items.Clear();
                    lvDiploma.DataSource = dataSet.Tables[3];
                    lvDiploma.DataBind();
                }
                else
                {
                    lvDiploma.Items.Clear();
                    lblDiploma.Visible = true;
                    lblDiploma.Text = "No record Found.";
                }
                if (dataSet.Tables[5].Rows.Count > 0)
                {
                    lblPortfolio.Visible = false;
                    lvPortFolio.DataSource = dataSet.Tables[5];
                    lvPortFolio.DataBind();
                }
                else
                {
                    lblPortfolio.Visible = true;
                    lblPortfolio.Text = "No record Found.";
                }
                if (dataSet.Tables[4].Rows.Count > 0)
                {
                    lblskillSet.Visible = false;
                    rptskill.DataSource = dataSet.Tables[4];
                    rptskill.DataBind();
                }
                else
                {
                    lblskillSet.Visible = true;
                    lblskillSet.Text = "No record Found.";
                }
                if (dataSet.Tables[9].Rows.Count > 0)
                {
                    lblFamilyDetailError.Visible = false;
                    LvFamilyDetail.DataSource = dataSet.Tables[9];
                    LvFamilyDetail.DataBind();
                }
                else
                {
                    lblFamilyDetailError.Visible = true;
                    lblFamilyDetailError.Text = "No record Found.";
                }
                if (dataSet.Tables[6].Rows.Count > 0)
                {
                    lblEmail.Text = dataSet.Tables[6].Rows[0]["Email"].ToString();
                    lblLandlineNo.Text = dataSet.Tables[6].Rows[0]["Home_Number"].ToString();
                    if (dataSet.Tables[6].Rows[0]["DateOfBirth"].ToString() != "")
                        lblDOB.Text = dataSet.Tables[6].Rows[0]["DateOfBirth"].ToString();
                    lblgender.Text = dataSet.Tables[6].Rows[0]["Gender"].ToString();
                    lblMarried.Text = dataSet.Tables[6].Rows[0]["MaritalStatus"].ToString();
                    lblReligion.Text = dataSet.Tables[6].Rows[0]["Religion"].ToString();
                    lblNationality.Text = dataSet.Tables[6].Rows[0]["Nationality"].ToString();
                    lblCNIC.Text = dataSet.Tables[6].Rows[0]["NIC"].ToString();
                    lblCellNo.Text = dataSet.Tables[6].Rows[0]["Phone"].ToString();
                }
                if (dataSet.Tables[8].Rows.Count > 0)
                    lblAddress.Text = dataSet.Tables[8].Rows[0]["HouseNumber"].ToString() + " " + dataSet.Tables[8].Rows[0]["Area"].ToString() + " " + dataSet.Tables[8].Rows[0]["Block"].ToString() + " " + dataSet.Tables[8].Rows[0]["Location_Code"].ToString();
                if (dataSet.Tables[7].Rows.Count > 0)
                {
                    rtpCellNumbr.DataSource = dataSet.Tables[7];
                    rtpCellNumbr.DataBind();
                }
            }
            else
                lvEducation.Items.Clear();
            int progressBarPencentage = GetProgressBarPencentage(CandidateCode, 2000);
            if (progressBarPencentage >= 100)
                btncomplete.Style.Add("display", "none");
            dvBar.Attributes.Add("style", "width:" + progressBarPencentage + "%");
            lblProgress.Text = progressBarPencentage.ToString() + "%";
        }
        catch
        {
        }
    }

    protected void Experience_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType != ListViewItemType.DataItem)
            return;
        if (displayCountEx > DisplayLimit)
        {
            ((HtmlControl)e.Item.FindControl("liexperience")).Attributes.CssStyle.Add("display", "none");
            lnkMoreExp.Attributes.CssStyle.Add("display", "");
        }
        ++displayCountEx;
    }

    protected void Family_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType != ListViewItemType.DataItem)
            return;
        if (displayCountFm > DisplayLimit)
        {
            ((HtmlControl)e.Item.FindControl("liFamilyDetail")).Attributes.CssStyle.Add("display", "none");
            lnkMoreFamily.Attributes.CssStyle.Add("display", "");
        }
        ++displayCountFm;
    }

    protected void Education_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType != ListViewItemType.DataItem)
            return;
        if (displayCountEd > DisplayLimit)
        {
            ((HtmlControl)e.Item.FindControl("lieducation")).Attributes.CssStyle.Add("display", "none");
            lnkMoreEdu.Attributes.CssStyle.Add("display", "");
        }
        ++displayCountEd;
    }

    protected void Portfolio_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType != ListViewItemType.DataItem)
            return;
        if (displayCountpo > DisplayLimit)
        {
            ((HtmlControl)e.Item.FindControl("liportfolio")).Attributes.CssStyle.Add("display", "none");
            lnkMorePor.Attributes.CssStyle.Add("display", "");
        }
        ++displayCountpo;
    }

    protected void Diploma_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType != ListViewItemType.DataItem)
            return;
        if (displayCountde > DisplayLimit)
        {
            ((HtmlControl)e.Item.FindControl("lidiploma")).Attributes.CssStyle.Add("display", "none");
            lnkMoreDip.Attributes.CssStyle.Add("display", "");
        }
        ++displayCountde;
    }

    protected void Certificate_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem listViewDataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType != ListViewItemType.DataItem)
            return;
        if (displayCountce > DisplayLimit)
        {
            ((HtmlControl)e.Item.FindControl("licertificate")).Attributes.CssStyle.Add("display", "none");
            lnkMoreCer.Attributes.CssStyle.Add("display", "");
        }
        ++displayCountce;
    }





}