using ErrorLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class A2_Reports_BOLGradeWiseBenefits : CustomBasePage, IRequiresSessionState
{
    private SecureQueryString sQString = new SecureQueryString();
    private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
                return;
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    private void BindData()
    {
        SqlCommand selectCommand = new SqlCommand("dbo.XRec_BOLSelect_GetAllOfferLetterData", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        selectCommand.Parameters.AddWithValue("@Grade", txtGradeSearch.Text);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        if (dataTable.Rows.Count <= 0)
            return;
        gvDetails.DataSource = dataTable;
        gvDetails.DataBind();
    }

    protected void OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = sender as CheckBox;
        if (checkBox.ID == "chkAll")
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                    row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault<CheckBox>().Checked = checkBox.Checked;
            }
        }
        gvDetails.HeaderRow.FindControl("chkAll");
        foreach (GridViewRow row in gvDetails.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                TextBox control1 = (TextBox)row.FindControl("txtGrossSalry");
                TextBox control2 = (TextBox)row.FindControl("txtBasicSalary");
                TextBox control3 = (TextBox)row.FindControl("txtOtherAllownce");
                TextBox control4 = (TextBox)row.FindControl("txtPF");
                TextBox control5 = (TextBox)row.FindControl("txtEOBI");
                TextBox control6 = (TextBox)row.FindControl("txtAccidentalDeath");
                TextBox control7 = (TextBox)row.FindControl("txtNaturalDeath");
                TextBox control8 = (TextBox)row.FindControl("txtMedicalSelf");
                TextBox control9 = (TextBox)row.FindControl("txtMedicalParent");
                TextBox control10 = (TextBox)row.FindControl("txtMaternity");
                TextBox control11 = (TextBox)row.FindControl("txtMobileAllowance");
                TextBox control12 = (TextBox)row.FindControl("txtCarName");
                TextBox control13 = (TextBox)row.FindControl("txtFuelQuantity");
                TextBox control14 = (TextBox)row.FindControl("txtWaterAllownceQuantity");
                TextBox control15 = (TextBox)row.FindControl("txtCompensatoryAllowance");
                TextBox control16 = (TextBox)row.FindControl("txtPaidVacationsAllownace");
                TextBox control17 = (TextBox)row.FindControl("txtSalonSlot");
                TextBox control18 = (TextBox)row.FindControl("txtGeneratorLoan");
                TextBox control19 = (TextBox)row.FindControl("txtCarName2");
                TextBox control20 = (TextBox)row.FindControl("txtServantCount");
                TextBox control21 = (TextBox)row.FindControl("txtMonetizationServant");
                TextBox control22 = (TextBox)row.FindControl("txtMonetizationLeaves");
                TextBox control23 = (TextBox)row.FindControl("txtMonetizationCar1");
                TextBox control24 = (TextBox)row.FindControl("txtMonetizationMobile");
                TextBox control25 = (TextBox)row.FindControl("txtMonetizationCar2");
                TextBox control26 = (TextBox)row.FindControl("txtMonetizationHealthSelf");
                TextBox control27 = (TextBox)row.FindControl("txtMonetizationHealthParent");
                TextBox control28 = (TextBox)row.FindControl("txtMobileName");
                TextBox control29 = (TextBox)row.FindControl("txtFuelAllowance2");
                Label control30 = (Label)row.FindControl("lblGrossSalry");
                Label control31 = (Label)row.FindControl("lblBasicSalary");
                Label control32 = (Label)row.FindControl("lblOtherAllownce");
                Label control33 = (Label)row.FindControl("lblPF");
                Label control34 = (Label)row.FindControl("lblEOBI");
                Label control35 = (Label)row.FindControl("lblAccidentalDeath");
                Label control36 = (Label)row.FindControl("lblNaturalDeath");
                Label control37 = (Label)row.FindControl("lblMedicalSelf");
                Label control38 = (Label)row.FindControl("lblMedicalParent");
                Label control39 = (Label)row.FindControl("lblMaternity");
                Label control40 = (Label)row.FindControl("lblMobileAllowance");
                Label control41 = (Label)row.FindControl("lblCarName");
                Label control42 = (Label)row.FindControl("lblFuelQuantity");
                Label control43 = (Label)row.FindControl("lblWaterAllownceQuantity");
                Label control44 = (Label)row.FindControl("lblCompensatoryAllowance");
                Label control45 = (Label)row.FindControl("lblPaidVacationsAllownace");
                Label control46 = (Label)row.FindControl("lblSalonSlot");
                Label control47 = (Label)row.FindControl("lblGeneratorLoan");
                Label control48 = (Label)row.FindControl("lblCarName2");
                Label control49 = (Label)row.FindControl("lblServantCount");
                Label control50 = (Label)row.FindControl("lblMonetizationServant");
                Label control51 = (Label)row.FindControl("lblMonetizationLeaves");
                Label control52 = (Label)row.FindControl("lblMonetizationCar1");
                Label control53 = (Label)row.FindControl("lblMonetizationMobile");
                Label control54 = (Label)row.FindControl("lblMonetizationCar2");
                Label control55 = (Label)row.FindControl("lblMonetizationHealthSelf");
                Label control56 = (Label)row.FindControl("lblMonetizationHealthParent");
                Label control57 = (Label)row.FindControl("lblMobileName");
                Label control58 = (Label)row.FindControl("lblFuelAllowance2");
                control1.Visible = true;
                control2.Visible = true;
                control3.Visible = true;
                control4.Visible = true;
                control5.Visible = true;
                control6.Visible = true;
                control7.Visible = true;
                control8.Visible = true;
                control9.Visible = true;
                control10.Visible = true;
                control11.Visible = true;
                control12.Visible = true;
                control13.Visible = true;
                control14.Visible = true;
                control15.Visible = true;
                control16.Visible = true;
                control17.Visible = true;
                control18.Visible = true;
                control19.Visible = true;
                control20.Visible = true;
                control21.Visible = true;
                control22.Visible = true;
                control23.Visible = true;
                control24.Visible = true;
                control25.Visible = true;
                control26.Visible = true;
                control27.Visible = true;
                control28.Visible = true;
                control29.Visible = true;
                control30.Visible = false;
                control31.Visible = false;
                control32.Visible = false;
                control33.Visible = false;
                control34.Visible = false;
                control35.Visible = false;
                control36.Visible = false;
                control37.Visible = false;
                control38.Visible = false;
                control39.Visible = false;
                control40.Visible = false;
                control41.Visible = false;
                control42.Visible = false;
                control43.Visible = false;
                control44.Visible = false;
                control45.Visible = false;
                control46.Visible = false;
                control47.Visible = false;
                control48.Visible = false;
                control49.Visible = false;
                control50.Visible = false;
                control51.Visible = false;
                control52.Visible = false;
                control53.Visible = false;
                control54.Visible = false;
                control55.Visible = false;
                control56.Visible = false;
                control57.Visible = false;
                control58.Visible = false;
            }
        }
    }

    protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetails.EditIndex = e.NewEditIndex;
        BindData();
        ShowHideActions();
        GridViewRow row = gvDetails.Rows[e.NewEditIndex];
        TextBox control1 = (TextBox)row.FindControl("txtGrossSalry");
        TextBox control2 = (TextBox)row.FindControl("txtBasicSalary");
        TextBox control3 = (TextBox)row.FindControl("txtOtherAllownce");
        TextBox control4 = (TextBox)row.FindControl("txtPF");
        TextBox control5 = (TextBox)row.FindControl("txtEOBI");
        TextBox control6 = (TextBox)row.FindControl("txtAccidentalDeath");
        TextBox control7 = (TextBox)row.FindControl("txtNaturalDeath");
        TextBox control8 = (TextBox)row.FindControl("txtMedicalSelf");
        TextBox control9 = (TextBox)row.FindControl("txtMedicalParent");
        TextBox control10 = (TextBox)row.FindControl("txtMaternity");
        TextBox control11 = (TextBox)row.FindControl("txtMobileAllowance");
        TextBox control12 = (TextBox)row.FindControl("txtCarName");
        TextBox control13 = (TextBox)row.FindControl("txtFuelQuantity");
        TextBox control14 = (TextBox)row.FindControl("txtWaterAllownceQuantity");
        TextBox control15 = (TextBox)row.FindControl("txtCompensatoryAllowance");
        TextBox control16 = (TextBox)row.FindControl("txtPaidVacationsAllownace");
        TextBox control17 = (TextBox)row.FindControl("txtSalonSlot");
        TextBox control18 = (TextBox)row.FindControl("txtGeneratorLoan");
        TextBox control19 = (TextBox)row.FindControl("txtCarName2");
        TextBox control20 = (TextBox)row.FindControl("txtServantCount");
        TextBox control21 = (TextBox)row.FindControl("txtMonetizationServant");
        TextBox control22 = (TextBox)row.FindControl("txtMonetizationLeaves");
        TextBox control23 = (TextBox)row.FindControl("txtMonetizationCar1");
        TextBox control24 = (TextBox)row.FindControl("txtMonetizationMobile");
        TextBox control25 = (TextBox)row.FindControl("txtMonetizationCar2");
        TextBox control26 = (TextBox)row.FindControl("txtMonetizationHealthSelf");
        TextBox control27 = (TextBox)row.FindControl("txtMonetizationHealthParent");
        TextBox control28 = (TextBox)row.FindControl("txtMobileName");
        TextBox control29 = (TextBox)row.FindControl("txtFuelAllowance2");
        Label control30 = (Label)row.FindControl("lblGrossSalry");
        Label control31 = (Label)row.FindControl("lblBasicSalary");
        Label control32 = (Label)row.FindControl("lblOtherAllownce");
        Label control33 = (Label)row.FindControl("lblPF");
        Label control34 = (Label)row.FindControl("lblEOBI");
        Label control35 = (Label)row.FindControl("lblAccidentalDeath");
        Label control36 = (Label)row.FindControl("lblNaturalDeath");
        Label control37 = (Label)row.FindControl("lblMedicalSelf");
        Label control38 = (Label)row.FindControl("lblMedicalParent");
        Label control39 = (Label)row.FindControl("lblMaternity");
        Label control40 = (Label)row.FindControl("lblMobileAllowance");
        Label control41 = (Label)row.FindControl("lblCarName");
        Label control42 = (Label)row.FindControl("lblFuelQuantity");
        Label control43 = (Label)row.FindControl("lblWaterAllownceQuantity");
        Label control44 = (Label)row.FindControl("lblCompensatoryAllowance");
        Label control45 = (Label)row.FindControl("lblPaidVacationsAllownace");
        Label control46 = (Label)row.FindControl("lblSalonSlot");
        Label control47 = (Label)row.FindControl("lblGeneratorLoan");
        Label control48 = (Label)row.FindControl("lblCarName2");
        Label control49 = (Label)row.FindControl("lblServantCount");
        Label control50 = (Label)row.FindControl("lblMonetizationServant");
        Label control51 = (Label)row.FindControl("lblMonetizationLeaves");
        Label control52 = (Label)row.FindControl("lblMonetizationCar1");
        Label control53 = (Label)row.FindControl("lblMonetizationMobile");
        Label control54 = (Label)row.FindControl("lblMonetizationCar2");
        Label control55 = (Label)row.FindControl("lblMonetizationHealthSelf");
        Label control56 = (Label)row.FindControl("lblMonetizationHealthParent");
        Label control57 = (Label)row.FindControl("lblMobileName");
        Label control58 = (Label)row.FindControl("lblFuelAllowance2");
        control1.Visible = true;
        control2.Visible = true;
        control3.Visible = true;
        control4.Visible = true;
        control5.Visible = true;
        control6.Visible = true;
        control7.Visible = true;
        control8.Visible = true;
        control9.Visible = true;
        control10.Visible = true;
        control11.Visible = true;
        control12.Visible = true;
        control13.Visible = true;
        control14.Visible = true;
        control15.Visible = true;
        control16.Visible = true;
        control17.Visible = true;
        control18.Visible = true;
        control19.Visible = true;
        control20.Visible = true;
        control21.Visible = true;
        control22.Visible = true;
        control23.Visible = true;
        control24.Visible = true;
        control25.Visible = true;
        control26.Visible = true;
        control27.Visible = true;
        control28.Visible = true;
        control29.Visible = true;
        control30.Visible = false;
        control31.Visible = false;
        control32.Visible = false;
        control33.Visible = false;
        control34.Visible = false;
        control35.Visible = false;
        control36.Visible = false;
        control37.Visible = false;
        control38.Visible = false;
        control39.Visible = false;
        control40.Visible = false;
        control41.Visible = false;
        control42.Visible = false;
        control43.Visible = false;
        control44.Visible = false;
        control45.Visible = false;
        control46.Visible = false;
        control47.Visible = false;
        control48.Visible = false;
        control49.Visible = false;
        control50.Visible = false;
        control51.Visible = false;
        control52.Visible = false;
        control53.Visible = false;
        control54.Visible = false;
        control55.Visible = false;
        control56.Visible = false;
        control57.Visible = false;
        control58.Visible = false;
    }

    protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetails.EditIndex = -1;
        BindData();
        ShowHideActions();
    }

    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            TextBox control1 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtGrossSalry");
            TextBox control2 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtBasicSalary");
            TextBox control3 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtOtherAllownce");
            TextBox control4 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtPF");
            TextBox control5 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtEOBI");
            TextBox control6 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtAccidentalDeath");
            TextBox control7 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtNaturalDeath");
            TextBox control8 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMedicalSelf");
            TextBox control9 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMedicalParent");
            TextBox control10 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMaternity");
            TextBox control11 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMobileAllowance");
            TextBox control12 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtCarName");
            TextBox control13 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtFuelQuantity");
            TextBox control14 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtWaterAllownceQuantity");
            TextBox control15 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtCompensatoryAllowance");
            TextBox control16 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtPaidVacationsAllownace");
            TextBox control17 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtSalonSlot");
            TextBox control18 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtGeneratorLoan");
            TextBox control19 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtCarName2");
            TextBox control20 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtServantCount");
            TextBox control21 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationServant");
            TextBox control22 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationLeaves");
            TextBox control23 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationCar1");
            TextBox control24 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationMobile");
            TextBox control25 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationCar2");
            TextBox control26 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationHealthSelf");
            TextBox control27 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMonetizationHealthParent");
            TextBox control28 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMobileName");
            TextBox control29 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtFuelAllowance2");
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("dbo.Update_BOLOfferLetter_Data", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@OG_OfferletterDataLattest", gvDetails.DataKeys[e.RowIndex].Values[0].ToString());
            sqlCommand.Parameters.AddWithValue("@GrossSalry", control1.Text != string.Empty ? control1.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@BasicSalary", control2.Text != string.Empty ? control2.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@OtherAllownce", control3.Text != string.Empty ? control3.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@PF", control4.Text != string.Empty ? control4.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@EOBI", control5.Text != string.Empty ? control5.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@AccidentalDeath", control6.Text != string.Empty ? control6.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@NaturalDeath", control7.Text != string.Empty ? control7.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MedicalSelf", control8.Text != string.Empty ? control8.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MedicalParent", control9.Text != string.Empty ? control9.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@Maternity", control10.Text != string.Empty ? control10.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MobileAllowance", control11.Text != string.Empty ? control11.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@CarName", control12.Text != string.Empty ? control12.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@FuelQuantity", control13.Text != string.Empty ? control13.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@WaterAllownceQuantity", control14.Text != string.Empty ? control14.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@CompensatoryAllowance", control15.Text != string.Empty ? control15.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@PaidVacationsAllownace", control16.Text != string.Empty ? control16.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@SalonSlot", control17.Text != string.Empty ? control17.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@GeneratorLoan", control18.Text != string.Empty ? control18.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@CarName2", control19.Text != string.Empty ? control19.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@ServantCount", control20.Text != string.Empty ? control20.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationServant", control21.Text != string.Empty ? control21.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationLeaves", control22.Text != string.Empty ? control22.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationCar1", control23.Text != string.Empty ? control23.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationMobile", control24.Text != string.Empty ? control24.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationCar2", control25.Text != string.Empty ? control25.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationHealthSelf", control26.Text != string.Empty ? control26.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MonetizationHealthParent", control27.Text != string.Empty ? control27.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@MobileName", control28.Text != string.Empty ? control28.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@FuelAllowance2", control29.Text != string.Empty ? control29.Text : (string)null);
            sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
            sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
            sqlCommand.ExecuteNonQuery();
            gvDetails.EditIndex = -1;
            BindData();
            ShowHideActions();
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Updated Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    protected void imgGradeSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindData();
            ShowHideActions();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    protected void lnkapproveAll_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            foreach (GridViewRow row in gvDetails.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow && ((CheckBox)row.FindControl("chk")).Checked)
                {
                    TextBox control1 = (TextBox)row.FindControl("txtGrossSalry");
                    TextBox control2 = (TextBox)row.FindControl("txtBasicSalary");
                    TextBox control3 = (TextBox)row.FindControl("txtOtherAllownce");
                    TextBox control4 = (TextBox)row.FindControl("txtPF");
                    TextBox control5 = (TextBox)row.FindControl("txtEOBI");
                    TextBox control6 = (TextBox)row.FindControl("txtAccidentalDeath");
                    TextBox control7 = (TextBox)row.FindControl("txtNaturalDeath");
                    TextBox control8 = (TextBox)row.FindControl("txtMedicalSelf");
                    TextBox control9 = (TextBox)row.FindControl("txtMedicalParent");
                    TextBox control10 = (TextBox)row.FindControl("txtMaternity");
                    TextBox control11 = (TextBox)row.FindControl("txtMobileAllowance");
                    TextBox control12 = (TextBox)row.FindControl("txtCarName");
                    TextBox control13 = (TextBox)row.FindControl("txtFuelQuantity");
                    TextBox control14 = (TextBox)row.FindControl("txtWaterAllownceQuantity");
                    TextBox control15 = (TextBox)row.FindControl("txtCompensatoryAllowance");
                    TextBox control16 = (TextBox)row.FindControl("txtPaidVacationsAllownace");
                    TextBox control17 = (TextBox)row.FindControl("txtSalonSlot");
                    TextBox control18 = (TextBox)row.FindControl("txtGeneratorLoan");
                    TextBox control19 = (TextBox)row.FindControl("txtCarName2");
                    TextBox control20 = (TextBox)row.FindControl("txtServantCount");
                    TextBox control21 = (TextBox)row.FindControl("txtMonetizationServant");
                    TextBox control22 = (TextBox)row.FindControl("txtMonetizationLeaves");
                    TextBox control23 = (TextBox)row.FindControl("txtMonetizationCar1");
                    TextBox control24 = (TextBox)row.FindControl("txtMonetizationMobile");
                    TextBox control25 = (TextBox)row.FindControl("txtMonetizationCar2");
                    TextBox control26 = (TextBox)row.FindControl("txtMonetizationHealthSelf");
                    TextBox control27 = (TextBox)row.FindControl("txtMonetizationHealthParent");
                    TextBox control28 = (TextBox)row.FindControl("txtMobileName");
                    TextBox control29 = (TextBox)row.FindControl("txtFuelAllowance2");
                    SqlCommand sqlCommand = new SqlCommand("dbo.Update_BOLOfferLetter_Data", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@OG_OfferletterDataLattest", gvDetails.DataKeys[row.RowIndex].Values[0].ToString());
                    sqlCommand.Parameters.AddWithValue("@GrossSalry", control1.Text != string.Empty ? control1.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@BasicSalary", control2.Text != string.Empty ? control2.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@OtherAllownce", control3.Text != string.Empty ? control3.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@PF", control4.Text != string.Empty ? control4.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@EOBI", control5.Text != string.Empty ? control5.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@AccidentalDeath", control6.Text != string.Empty ? control6.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@NaturalDeath", control7.Text != string.Empty ? control7.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MedicalSelf", control8.Text != string.Empty ? control8.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MedicalParent", control9.Text != string.Empty ? control9.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@Maternity", control10.Text != string.Empty ? control10.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MobileAllowance", control11.Text != string.Empty ? control11.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@CarName", control12.Text != string.Empty ? control12.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@FuelQuantity", control13.Text != string.Empty ? control13.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@WaterAllownceQuantity", control14.Text != string.Empty ? control14.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@CompensatoryAllowance", control15.Text != string.Empty ? control15.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@PaidVacationsAllownace", control16.Text != string.Empty ? control16.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@SalonSlot", control17.Text != string.Empty ? control17.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@GeneratorLoan", control18.Text != string.Empty ? control18.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@CarName2", control19.Text != string.Empty ? control19.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@ServantCount", control20.Text != string.Empty ? control20.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationServant", control21.Text != string.Empty ? control21.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationLeaves", control22.Text != string.Empty ? control22.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationCar1", control23.Text != string.Empty ? control23.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationMobile", control24.Text != string.Empty ? control24.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationCar2", control25.Text != string.Empty ? control25.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationHealthSelf", control26.Text != string.Empty ? control26.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MonetizationHealthParent", control27.Text != string.Empty ? control27.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@MobileName", control28.Text != string.Empty ? control28.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@FuelAllowance2", control29.Text != string.Empty ? control29.Text : (string)null);
                    sqlCommand.Parameters.AddWithValue("@Updated_By", UserCode);
                    sqlCommand.Parameters.AddWithValue("@Updated_IP", USERIP);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            gvDetails.EditIndex = -1;
            BindData();
            ShowHideActions();
            ScriptManager.RegisterStartupScript((Page)this, GetType(), "exists", "alert('Updated Successfully!');", true);
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
        finally
        {
            connection.Close();
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

    public DataTable GetAxactBenefit()
    {
        DataTable dataTable = new DataTable();
        try
        {
            SqlCommand selectCommand = new SqlCommand("dbo.XREC_SelectGradewiseBenefits", connection);
            selectCommand.Parameters.Add("@Comapany_Code", SqlDbType.VarChar).Value = 2;
            selectCommand.CommandType = CommandType.StoredProcedure;
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            return dataTable;
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            return dataTable;
        }
    }

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        DataTable axactBenefit = GetAxactBenefit();
        if (axactBenefit.Rows.Count <= 0)
            return;
        ExportToSpreadsheet(axactBenefit, "@E:\\products\\AxactBenefitSheet.xlsx");
    }

    public void ExportToSpreadsheet(DataTable table, string FileNameWithPath)
    {
        if (table.Rows.Count <= 0)
            return;
        string str1 = "attachment; filename=Axact-Benefit-Sheet.xls";
        Page.Response.ClearContent();
        Response.AddHeader("content-disposition", str1);
        Response.ContentType = "application/vnd.ms-excel";
        string str2 = "";
        foreach (DataColumn column in (InternalDataCollectionBase)table.Columns)
        {
            if (column.ColumnName != "Candidate_Code" && column.ColumnName != "gl_id")
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
                if (table.Columns[index].ColumnName != "Candidate_Code" && table.Columns[index].ColumnName != "gl_id")
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