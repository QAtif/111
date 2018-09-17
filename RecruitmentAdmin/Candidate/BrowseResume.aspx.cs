using System;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ErrorLog;

public partial class Candidate_BrowseResume : CustomBasePage
{
    #region Variables
    protected string uploadedFilePath = System.Configuration.ConfigurationManager.AppSettings["FileUploadDirectory"];
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
    SqlConnection Errlogconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["errLogConnection"].ToString());
    string DocumentFilename;
    string FilePath;
    string ImagePath;
    static int CanCode = 1;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string str = Candidate_BrowseResume.UploadFile(fuKeyword, uploadedFilePath + "/UploadedResumes/");
        if (str == "-1")
        {
            lblMsg.Text = "Kindly Select Valid File Format (Only .xls and .xlsx are Acceptable)";
        }
        else
        {
            lblMsg.Text = "";
            try
            {
                SqlCommand selectCommand = new SqlCommand("Update_ExcelResumePath", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.AddWithValue("@TempCandidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@ExcelResume_Path", str);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
                SaveData();
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
    }

    protected void lbtnImage_Click(object sender, EventArgs e)
    {
        try
        {
            Candidate_BrowseResume.ViewFile("SampleResume.xlsx", uploadedFilePath + "/SampleFiles/");
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.RecruitmentAdmin, ex.Message + " " + ex.StackTrace, ex, UserCode.ToString());
        }
    }

    public void SaveData()
    {
        int num1 = 0;
        if (!(fuKeyword.PostedFile.FileName != ""))
            return;
        if (fuKeyword.PostedFile.FileName.Length > 0)
        {
            string path = Server.MapPath("") + "\\ExcelFiles";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            HttpPostedFile postedFile = fuKeyword.PostedFile;
            DocumentFilename = Path.GetFileName(fuKeyword.PostedFile.FileName);
            FilePath = "\\ExcelFiles\\" + DocumentFilename;
            ImagePath = Server.MapPath("") + FilePath;
            postedFile.SaveAs(ImagePath);
        }
        DataTable dataTable1 = Common.Instance.ReadProfessionalExperience(Path.GetDirectoryName(ImagePath), Path.GetFileName(ImagePath), "'Professional Experience$'");
        if (dataTable1.Rows.Count != 0)
        {
            DateTime dateTime1 = DateTime.Now;
            DateTime dateTime2 = DateTime.Now;
            Decimal num2 = new Decimal(0);
            Decimal num3 = new Decimal(0);
            string str1 = dataTable1.Rows[2]["Value"].ToString();
            string str2 = dataTable1.Rows[3]["Value"].ToString();
            string str3 = dataTable1.Rows[4]["Value"].ToString();
            string str4 = dataTable1.Rows[5]["Value"].ToString();
            if (dataTable1.Rows[6]["Value"].ToString() != string.Empty)
                dateTime1 = Convert.ToDateTime(dataTable1.Rows[6]["Value"].ToString());
            if (dataTable1.Rows[7]["Value"].ToString() != string.Empty)
                dateTime2 = Convert.ToDateTime(dataTable1.Rows[7]["Value"].ToString());
            string str5 = dataTable1.Rows[8]["Value"].ToString();
            string str6 = dataTable1.Rows[9]["Value"].ToString();
            if (dataTable1.Rows[10]["Value"].ToString() != string.Empty)
                num2 = Convert.ToDecimal(dataTable1.Rows[10]["Value"].ToString());
            if (dataTable1.Rows[11]["Value"].ToString() != string.Empty)
                num3 = Convert.ToDecimal(dataTable1.Rows[11]["Value"].ToString());
            SqlCommand selectCommand1 = new SqlCommand("Insert_TempCandidateExperience", connection);
            selectCommand1.CommandType = CommandType.StoredProcedure;
            selectCommand1.CommandTimeout = 0;
            selectCommand1.Parameters.Clear();
            selectCommand1.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
            selectCommand1.Parameters.AddWithValue("@Industry", str1);
            selectCommand1.Parameters.AddWithValue("@Company", str2);
            selectCommand1.Parameters.AddWithValue("@Position_Title", str3);
            selectCommand1.Parameters.AddWithValue("@Location", str4);
            selectCommand1.Parameters.AddWithValue("@jobStart_Date", dateTime1);
            selectCommand1.Parameters.AddWithValue("@jobEnd_Date", dateTime2);
            selectCommand1.Parameters.AddWithValue("@Responsibilties_Included", str5);
            selectCommand1.Parameters.AddWithValue("@ReasonFor_Leaving", str6);
            selectCommand1.Parameters.AddWithValue("@Current_Salary", num2);
            selectCommand1.Parameters.AddWithValue("@Initial_Salary", num3);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(selectCommand1);
            DataSet dataSet1 = new DataSet();
            sqlDataAdapter1.Fill(dataSet1);
            if (dataSet1.Tables.Count == 0)
                return;
            if (dataSet1 != null && dataSet1.Tables[0].Rows.Count != 0)
                num1 = Convert.ToInt32(dataSet1.Tables[0].Rows[0]["CandidateExperienceCode"].ToString());
            string str7 = dataTable1.Rows[13]["Attribute"].ToString();
            string str8 = dataTable1.Rows[14]["Attribute"].ToString();
            string str9 = dataTable1.Rows[15]["Attribute"].ToString();
            string str10 = dataTable1.Rows[16]["Attribute"].ToString();
            string str11 = dataTable1.Rows[17]["Attribute"].ToString();
            if (str7 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 1);
                selectCommand2.Parameters.AddWithValue("@Benefit", str7);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str8 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 1);
                selectCommand2.Parameters.AddWithValue("@Benefit", str8);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str9 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 1);
                selectCommand2.Parameters.AddWithValue("@Benefit", str9);
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
                DataSet dataSet2 = new DataSet();
                sqlDataAdapter2.Fill(dataSet1);
            }
            if (str10 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 1);
                selectCommand2.Parameters.AddWithValue("@Benefit", str10);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str11 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 1);
                selectCommand2.Parameters.AddWithValue("@Benefit", str11);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            string str12 = dataTable1.Rows[20]["Attribute"].ToString();
            string str13 = dataTable1.Rows[21]["Attribute"].ToString();
            string str14 = dataTable1.Rows[22]["Attribute"].ToString();
            string str15 = dataTable1.Rows[23]["Attribute"].ToString();
            string str16 = dataTable1.Rows[24]["Attribute"].ToString();
            if (str12 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 2);
                selectCommand2.Parameters.AddWithValue("@Benefit", str12);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str13 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 2);
                selectCommand2.Parameters.AddWithValue("@Benefit", str13);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str14 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 2);
                selectCommand2.Parameters.AddWithValue("@Benefit", str14);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str15 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 2);
                selectCommand2.Parameters.AddWithValue("@Benefit", str15);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str16 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 2);
                selectCommand2.Parameters.AddWithValue("@Benefit", str16);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            string str17 = dataTable1.Rows[27]["Attribute"].ToString();
            string str18 = dataTable1.Rows[28]["Attribute"].ToString();
            string str19 = dataTable1.Rows[29]["Attribute"].ToString();
            string str20 = dataTable1.Rows[30]["Attribute"].ToString();
            string str21 = dataTable1.Rows[31]["Attribute"].ToString();
            if (str17 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 3);
                selectCommand2.Parameters.AddWithValue("@Benefit", str17);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str18 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 3);
                selectCommand2.Parameters.AddWithValue("@Benefit", str18);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str19 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 3);
                selectCommand2.Parameters.AddWithValue("@Benefit", str19);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str20 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 3);
                selectCommand2.Parameters.AddWithValue("@Benefit", str20);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str21 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 3);
                selectCommand2.Parameters.AddWithValue("@Benefit", str21);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            string str22 = dataTable1.Rows[34]["Attribute"].ToString();
            string str23 = dataTable1.Rows[35]["Attribute"].ToString();
            string str24 = dataTable1.Rows[36]["Attribute"].ToString();
            string str25 = dataTable1.Rows[37]["Attribute"].ToString();
            string str26 = dataTable1.Rows[38]["Attribute"].ToString();
            if (str22 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 4);
                selectCommand2.Parameters.AddWithValue("@Benefit", str22);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str23 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 4);
                selectCommand2.Parameters.AddWithValue("@Benefit", str23);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str24 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 4);
                selectCommand2.Parameters.AddWithValue("@Benefit", str24);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str25 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 4);
                selectCommand2.Parameters.AddWithValue("@Benefit", str25);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
            if (str26 != string.Empty)
            {
                SqlCommand selectCommand2 = new SqlCommand("Insert_TempCandidateBenefits", connection);
                selectCommand2.CommandType = CommandType.StoredProcedure;
                selectCommand2.CommandTimeout = 0;
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@CandidateExperience_Code", num1);
                selectCommand2.Parameters.AddWithValue("@Benefit_Type_Code", 4);
                selectCommand2.Parameters.AddWithValue("@Benefit", str26);
                new SqlDataAdapter(selectCommand2).Fill(new DataSet());
            }
        }
        string sheetName = "'Educational Qualification$'";
        DateTime dateTime3 = DateTime.Now;
        DateTime dateTime4 = DateTime.Now;
        DateTime dateTime5 = DateTime.Now;
        DateTime dateTime6 = DateTime.Now;
        DateTime dateTime7 = DateTime.Now;
        DateTime dateTime8 = DateTime.Now;
        DateTime dateTime9 = DateTime.Now;
        DateTime dateTime10 = DateTime.Now;
        DateTime dateTime11 = DateTime.Now;
        DateTime dateTime12 = DateTime.Now;
        DateTime dateTime13 = DateTime.Now;
        DateTime dateTime14 = DateTime.Now;
        DateTime dateTime15 = DateTime.Now;
        DateTime dateTime16 = DateTime.Now;
        DateTime dateTime17 = DateTime.Now;
        DateTime dateTime18 = DateTime.Now;
        DateTime dateTime19 = DateTime.Now;
        DateTime dateTime20 = DateTime.Now;
        DateTime dateTime21 = DateTime.Now;
        DateTime dateTime22 = DateTime.Now;
        DateTime dateTime23 = DateTime.Now;
        DateTime dateTime24 = DateTime.Now;
        DateTime dateTime25 = DateTime.Now;
        DateTime dateTime26 = DateTime.Now;
        DateTime dateTime27 = DateTime.Now;
        DateTime dateTime28 = DateTime.Now;
        DateTime dateTime29 = DateTime.Now;
        DateTime dateTime30 = DateTime.Now;
        DateTime dateTime31 = DateTime.Now;
        DateTime dateTime32 = DateTime.Now;
        DateTime dateTime33 = DateTime.Now;
        DateTime dateTime34 = DateTime.Now;
        DateTime dateTime35 = DateTime.Now;
        DateTime dateTime36 = DateTime.Now;
        DateTime dateTime37 = DateTime.Now;
        DateTime dateTime38 = DateTime.Now;
        DateTime dateTime39 = DateTime.Now;
        DateTime dateTime40 = DateTime.Now;
        DateTime dateTime41 = DateTime.Now;
        DateTime dateTime42 = DateTime.Now;
        DateTime dateTime43 = DateTime.Now;
        DateTime dateTime44 = DateTime.Now;
        DateTime dateTime45 = DateTime.Now;
        DateTime dateTime46 = DateTime.Now;
        DateTime dateTime47 = DateTime.Now;
        DateTime dateTime48 = DateTime.Now;
        DateTime dateTime49 = DateTime.Now;
        DateTime dateTime50 = DateTime.Now;
        DateTime dateTime51 = DateTime.Now;
        DateTime dateTime52 = DateTime.Now;
        DataTable dataTable2 = Common.Instance.ReadEducationalQualification(Path.GetDirectoryName(ImagePath), Path.GetFileName(ImagePath), sheetName);
        if (dataTable2.Rows.Count != 0)
        {
            string str1 = dataTable2.Rows[3]["Value"].ToString();
            string str2 = dataTable2.Rows[4]["Value"].ToString();
            string str3 = dataTable2.Rows[5]["Value"].ToString();
            if (dataTable2.Rows[6]["Value"].ToString() != string.Empty)
                dateTime3 = Convert.ToDateTime(dataTable2.Rows[6]["Value"].ToString());
            if (dataTable2.Rows[7]["Value"].ToString() != string.Empty)
                dateTime4 = Convert.ToDateTime(dataTable2.Rows[7]["Value"].ToString());
            dataTable2.Rows[8]["Value"].ToString();
            string str4 = dataTable2.Rows[9]["Value"].ToString();
            string str5 = dataTable2.Rows[10]["Value"].ToString();
            string str6 = dataTable2.Rows[11]["Value"].ToString();
            string str7 = dataTable2.Rows[14]["Value"].ToString();
            string str8 = dataTable2.Rows[15]["Value"].ToString();
            string str9 = dataTable2.Rows[16]["Value"].ToString();
            if (dataTable2.Rows[17]["Value"].ToString() != string.Empty)
                dateTime5 = Convert.ToDateTime(dataTable2.Rows[17]["Value"].ToString());
            if (dataTable2.Rows[18]["Value"].ToString() != string.Empty)
                dateTime6 = Convert.ToDateTime(dataTable2.Rows[18]["Value"].ToString());
            dataTable2.Rows[19]["Value"].ToString();
            string str10 = dataTable2.Rows[20]["Value"].ToString();
            string str11 = dataTable2.Rows[21]["Value"].ToString();
            string str12 = dataTable2.Rows[22]["Value"].ToString();
            string str13 = dataTable2.Rows[25]["Value"].ToString();
            string str14 = dataTable2.Rows[26]["Value"].ToString();
            string str15 = dataTable2.Rows[27]["Value"].ToString();
            if (dataTable2.Rows[28]["Value"].ToString() != string.Empty)
                dateTime7 = Convert.ToDateTime(dataTable2.Rows[28]["Value"].ToString());
            if (dataTable2.Rows[29]["Value"].ToString() != string.Empty)
                dateTime8 = Convert.ToDateTime(dataTable2.Rows[29]["Value"].ToString());
            dataTable2.Rows[30]["Value"].ToString();
            string str16 = dataTable2.Rows[31]["Value"].ToString();
            string str17 = dataTable2.Rows[32]["Value"].ToString();
            string str18 = dataTable2.Rows[33]["Value"].ToString();
            string str19 = dataTable2.Rows[36]["Value"].ToString();
            string str20 = dataTable2.Rows[37]["Value"].ToString();
            dataTable2.Rows[38]["Value"].ToString();
            if (dataTable2.Rows[39]["Value"].ToString() != string.Empty)
                dateTime9 = Convert.ToDateTime(dataTable2.Rows[39]["Value"].ToString());
            if (dataTable2.Rows[40]["Value"].ToString() != string.Empty)
                dateTime10 = Convert.ToDateTime(dataTable2.Rows[40]["Value"].ToString());
            dataTable2.Rows[41]["Value"].ToString();
            string str21 = dataTable2.Rows[42]["Value"].ToString();
            string str22 = dataTable2.Rows[43]["Value"].ToString();
            string str23 = dataTable2.Rows[44]["Value"].ToString();
            string str24 = dataTable2.Rows[47]["Value"].ToString();
            string str25 = dataTable2.Rows[48]["Value"].ToString();
            string str26 = dataTable2.Rows[49]["Value"].ToString();
            if (dataTable2.Rows[50]["Value"].ToString() != string.Empty)
                dateTime11 = Convert.ToDateTime(dataTable2.Rows[50]["Value"].ToString());
            if (dataTable2.Rows[51]["Value"].ToString() != string.Empty)
                dateTime12 = Convert.ToDateTime(dataTable2.Rows[51]["Value"].ToString());
            dataTable2.Rows[52]["Value"].ToString();
            string str27 = dataTable2.Rows[53]["Value"].ToString();
            string str28 = dataTable2.Rows[54]["Value"].ToString();
            string str29 = dataTable2.Rows[55]["Value"].ToString();
            if (str1 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str1);
                selectCommand.Parameters.AddWithValue("@Degree", str2);
                selectCommand.Parameters.AddWithValue("@Program_Code", 1);
                selectCommand.Parameters.AddWithValue("@Major", str3);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime3);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime4);
                selectCommand.Parameters.AddWithValue("@Grade", str4);
                selectCommand.Parameters.AddWithValue("@Position", str5);
                selectCommand.Parameters.AddWithValue("@Activities", str6);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str7 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str7);
                selectCommand.Parameters.AddWithValue("@Degree", str8);
                selectCommand.Parameters.AddWithValue("@Program_Code", 1);
                selectCommand.Parameters.AddWithValue("@Major", str9);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime5);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime6);
                selectCommand.Parameters.AddWithValue("@Grade", str10);
                selectCommand.Parameters.AddWithValue("@Position", str11);
                selectCommand.Parameters.AddWithValue("@Activities", str12);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str13 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str13);
                selectCommand.Parameters.AddWithValue("@Degree", str14);
                selectCommand.Parameters.AddWithValue("@Program_Code", 1);
                selectCommand.Parameters.AddWithValue("@Major", str15);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime7);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime8);
                selectCommand.Parameters.AddWithValue("@Grade", str16);
                selectCommand.Parameters.AddWithValue("@Position", str17);
                selectCommand.Parameters.AddWithValue("@Activities", str18);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str19 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str19);
                selectCommand.Parameters.AddWithValue("@Degree", str20);
                selectCommand.Parameters.AddWithValue("@Program_Code", 1);
                selectCommand.Parameters.AddWithValue("@Major", str3);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime9);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime10);
                selectCommand.Parameters.AddWithValue("@Grade", str21);
                selectCommand.Parameters.AddWithValue("@Position", str22);
                selectCommand.Parameters.AddWithValue("@Activities", str23);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str24 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str24);
                selectCommand.Parameters.AddWithValue("@Degree", str25);
                selectCommand.Parameters.AddWithValue("@Program_Code", 1);
                selectCommand.Parameters.AddWithValue("@Major", str26);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime11);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime12);
                selectCommand.Parameters.AddWithValue("@Grade", str27);
                selectCommand.Parameters.AddWithValue("@Position", str28);
                selectCommand.Parameters.AddWithValue("@Activities", str29);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str30 = dataTable2.Rows[58]["Value"].ToString();
            string str31 = dataTable2.Rows[59]["Value"].ToString();
            string str32 = dataTable2.Rows[60]["Value"].ToString();
            if (dataTable2.Rows[61]["Value"].ToString() != string.Empty)
                dateTime13 = Convert.ToDateTime(dataTable2.Rows[61]["Value"].ToString());
            if (dataTable2.Rows[62]["Value"].ToString() != string.Empty)
                dateTime14 = Convert.ToDateTime(dataTable2.Rows[62]["Value"].ToString());
            dataTable2.Rows[63]["Value"].ToString();
            string str33 = dataTable2.Rows[64]["Value"].ToString();
            string str34 = dataTable2.Rows[65]["Value"].ToString();
            string str35 = dataTable2.Rows[66]["Value"].ToString();
            string str36 = dataTable2.Rows[69]["Value"].ToString();
            string str37 = dataTable2.Rows[70]["Value"].ToString();
            string str38 = dataTable2.Rows[71]["Value"].ToString();
            if (dataTable2.Rows[72]["Value"].ToString() != string.Empty)
                dateTime15 = Convert.ToDateTime(dataTable2.Rows[72]["Value"].ToString());
            if (dataTable2.Rows[73]["Value"].ToString() != string.Empty)
                dateTime16 = Convert.ToDateTime(dataTable2.Rows[73]["Value"].ToString());
            dataTable2.Rows[74]["Value"].ToString();
            string str39 = dataTable2.Rows[75]["Value"].ToString();
            string str40 = dataTable2.Rows[76]["Value"].ToString();
            string str41 = dataTable2.Rows[77]["Value"].ToString();
            string str42 = dataTable2.Rows[80]["Value"].ToString();
            string str43 = dataTable2.Rows[81]["Value"].ToString();
            string str44 = dataTable2.Rows[82]["Value"].ToString();
            if (dataTable2.Rows[83]["Value"].ToString() != string.Empty)
                dateTime17 = Convert.ToDateTime(dataTable2.Rows[83]["Value"].ToString());
            if (dataTable2.Rows[84]["Value"].ToString() != string.Empty)
                dateTime18 = Convert.ToDateTime(dataTable2.Rows[84]["Value"].ToString());
            dataTable2.Rows[85]["Value"].ToString();
            string str45 = dataTable2.Rows[86]["Value"].ToString();
            string str46 = dataTable2.Rows[87]["Value"].ToString();
            string str47 = dataTable2.Rows[88]["Value"].ToString();
            string str48 = dataTable2.Rows[91]["Value"].ToString();
            string str49 = dataTable2.Rows[92]["Value"].ToString();
            string str50 = dataTable2.Rows[93]["Value"].ToString();
            if (dataTable2.Rows[94]["Value"].ToString() != string.Empty)
                dateTime19 = Convert.ToDateTime(dataTable2.Rows[94]["Value"].ToString());
            if (dataTable2.Rows[95]["Value"].ToString() != string.Empty)
                dateTime20 = Convert.ToDateTime(dataTable2.Rows[95]["Value"].ToString());
            dataTable2.Rows[96]["Value"].ToString();
            string str51 = dataTable2.Rows[97]["Value"].ToString();
            string str52 = dataTable2.Rows[98]["Value"].ToString();
            string str53 = dataTable2.Rows[99]["Value"].ToString();
            string str54 = dataTable2.Rows[102]["Value"].ToString();
            string str55 = dataTable2.Rows[103]["Value"].ToString();
            string str56 = dataTable2.Rows[104]["Value"].ToString();
            if (dataTable2.Rows[105]["Value"].ToString() != string.Empty)
                dateTime21 = Convert.ToDateTime(dataTable2.Rows[105]["Value"].ToString());
            if (dataTable2.Rows[106]["Value"].ToString() != string.Empty)
                dateTime22 = Convert.ToDateTime(dataTable2.Rows[106]["Value"].ToString());
            dataTable2.Rows[107]["Value"].ToString();
            string str57 = dataTable2.Rows[108]["Value"].ToString();
            string str58 = dataTable2.Rows[109]["Value"].ToString();
            string str59 = dataTable2.Rows[110]["Value"].ToString();
            if (str30 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str30);
                selectCommand.Parameters.AddWithValue("@Degree", str31);
                selectCommand.Parameters.AddWithValue("@Program_Code", 2);
                selectCommand.Parameters.AddWithValue("@Major", str32);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime13);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime14);
                selectCommand.Parameters.AddWithValue("@Grade", str33);
                selectCommand.Parameters.AddWithValue("@Position", str34);
                selectCommand.Parameters.AddWithValue("@Activities", str35);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str36 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str36);
                selectCommand.Parameters.AddWithValue("@Degree", str37);
                selectCommand.Parameters.AddWithValue("@Program_Code", 2);
                selectCommand.Parameters.AddWithValue("@Major", str38);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime15);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime16);
                selectCommand.Parameters.AddWithValue("@Grade", str39);
                selectCommand.Parameters.AddWithValue("@Position", str40);
                selectCommand.Parameters.AddWithValue("@Activities", str41);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str42 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str42);
                selectCommand.Parameters.AddWithValue("@Degree", str43);
                selectCommand.Parameters.AddWithValue("@Program_Code", 2);
                selectCommand.Parameters.AddWithValue("@Major", str44);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime17);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime18);
                selectCommand.Parameters.AddWithValue("@Grade", str45);
                selectCommand.Parameters.AddWithValue("@Position", str46);
                selectCommand.Parameters.AddWithValue("@Activities", str47);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str48 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str48);
                selectCommand.Parameters.AddWithValue("@Degree", str49);
                selectCommand.Parameters.AddWithValue("@Program_Code", 2);
                selectCommand.Parameters.AddWithValue("@Major", str50);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime19);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime20);
                selectCommand.Parameters.AddWithValue("@Grade", str51);
                selectCommand.Parameters.AddWithValue("@Position", str52);
                selectCommand.Parameters.AddWithValue("@Activities", str53);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str54 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str54);
                selectCommand.Parameters.AddWithValue("@Degree", str55);
                selectCommand.Parameters.AddWithValue("@Program_Code", 2);
                selectCommand.Parameters.AddWithValue("@Major", str56);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime21);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime22);
                selectCommand.Parameters.AddWithValue("@Grade", str57);
                selectCommand.Parameters.AddWithValue("@Position", str58);
                selectCommand.Parameters.AddWithValue("@Activities", str59);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str60 = dataTable2.Rows[113]["Value"].ToString();
            string str61 = dataTable2.Rows[114]["Value"].ToString();
            string str62 = dataTable2.Rows[115]["Value"].ToString();
            if (dataTable2.Rows[116]["Value"].ToString() != string.Empty)
                dateTime23 = Convert.ToDateTime(dataTable2.Rows[116]["Value"].ToString());
            if (dataTable2.Rows[117]["Value"].ToString() != string.Empty)
                dateTime24 = Convert.ToDateTime(dataTable2.Rows[117]["Value"].ToString());
            dataTable2.Rows[118]["Value"].ToString();
            string str63 = dataTable2.Rows[119]["Value"].ToString();
            string str64 = dataTable2.Rows[120]["Value"].ToString();
            string str65 = dataTable2.Rows[121]["Value"].ToString();
            string str66 = dataTable2.Rows[124]["Value"].ToString();
            string str67 = dataTable2.Rows[125]["Value"].ToString();
            string str68 = dataTable2.Rows[126]["Value"].ToString();
            if (dataTable2.Rows[(int)sbyte.MaxValue]["Value"].ToString() != string.Empty)
                dateTime25 = Convert.ToDateTime(dataTable2.Rows[(int)sbyte.MaxValue]["Value"].ToString());
            if (dataTable2.Rows[128]["Value"].ToString() != string.Empty)
                dateTime26 = Convert.ToDateTime(dataTable2.Rows[128]["Value"].ToString());
            dataTable2.Rows[129]["Value"].ToString();
            string str69 = dataTable2.Rows[130]["Value"].ToString();
            string str70 = dataTable2.Rows[131]["Value"].ToString();
            string str71 = dataTable2.Rows[132]["Value"].ToString();
            string str72 = dataTable2.Rows[135]["Value"].ToString();
            string str73 = dataTable2.Rows[136]["Value"].ToString();
            string str74 = dataTable2.Rows[137]["Value"].ToString();
            if (dataTable2.Rows[138]["Value"].ToString() != string.Empty)
                dateTime27 = Convert.ToDateTime(dataTable2.Rows[138]["Value"].ToString());
            if (dataTable2.Rows[139]["Value"].ToString() != string.Empty)
                dateTime28 = Convert.ToDateTime(dataTable2.Rows[139]["Value"].ToString());
            dataTable2.Rows[140]["Value"].ToString();
            string str75 = dataTable2.Rows[141]["Value"].ToString();
            string str76 = dataTable2.Rows[142]["Value"].ToString();
            string str77 = dataTable2.Rows[143]["Value"].ToString();
            string str78 = dataTable2.Rows[146]["Value"].ToString();
            string str79 = dataTable2.Rows[147]["Value"].ToString();
            string str80 = dataTable2.Rows[148]["Value"].ToString();
            if (dataTable2.Rows[149]["Value"].ToString() != string.Empty)
                dateTime29 = Convert.ToDateTime(dataTable2.Rows[149]["Value"].ToString());
            if (dataTable2.Rows[150]["Value"].ToString() != string.Empty)
                dateTime30 = Convert.ToDateTime(dataTable2.Rows[150]["Value"].ToString());
            dataTable2.Rows[151]["Value"].ToString();
            string str81 = dataTable2.Rows[152]["Value"].ToString();
            string str82 = dataTable2.Rows[153]["Value"].ToString();
            string str83 = dataTable2.Rows[154]["Value"].ToString();
            string str84 = dataTable2.Rows[157]["Value"].ToString();
            string str85 = dataTable2.Rows[158]["Value"].ToString();
            string str86 = dataTable2.Rows[159]["Value"].ToString();
            if (dataTable2.Rows[160]["Value"].ToString() != string.Empty)
                dateTime31 = Convert.ToDateTime(dataTable2.Rows[160]["Value"].ToString());
            if (dataTable2.Rows[161]["Value"].ToString() != string.Empty)
                dateTime32 = Convert.ToDateTime(dataTable2.Rows[161]["Value"].ToString());
            dataTable2.Rows[162]["Value"].ToString();
            string str87 = dataTable2.Rows[163]["Value"].ToString();
            string str88 = dataTable2.Rows[164]["Value"].ToString();
            string str89 = dataTable2.Rows[165]["Value"].ToString();
            if (str60 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str60);
                selectCommand.Parameters.AddWithValue("@Degree", str61);
                selectCommand.Parameters.AddWithValue("@Program_Code", 3);
                selectCommand.Parameters.AddWithValue("@Major", str62);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime23);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime24);
                selectCommand.Parameters.AddWithValue("@Grade", str63);
                selectCommand.Parameters.AddWithValue("@Position", str64);
                selectCommand.Parameters.AddWithValue("@Activities", str65);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str66 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str66);
                selectCommand.Parameters.AddWithValue("@Degree", str67);
                selectCommand.Parameters.AddWithValue("@Program_Code", 3);
                selectCommand.Parameters.AddWithValue("@Major", str68);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime25);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime26);
                selectCommand.Parameters.AddWithValue("@Grade", str69);
                selectCommand.Parameters.AddWithValue("@Position", str70);
                selectCommand.Parameters.AddWithValue("@Activities", str71);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str72 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str72);
                selectCommand.Parameters.AddWithValue("@Degree", str73);
                selectCommand.Parameters.AddWithValue("@Program_Code", 3);
                selectCommand.Parameters.AddWithValue("@Major", str74);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime27);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime28);
                selectCommand.Parameters.AddWithValue("@Grade", str75);
                selectCommand.Parameters.AddWithValue("@Position", str76);
                selectCommand.Parameters.AddWithValue("@Activities", str77);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str78 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str78);
                selectCommand.Parameters.AddWithValue("@Degree", str79);
                selectCommand.Parameters.AddWithValue("@Program_Code", 3);
                selectCommand.Parameters.AddWithValue("@Major", str80);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime29);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime30);
                selectCommand.Parameters.AddWithValue("@Grade", str81);
                selectCommand.Parameters.AddWithValue("@Position", str82);
                selectCommand.Parameters.AddWithValue("@Activities", str83);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str84 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str84);
                selectCommand.Parameters.AddWithValue("@Degree", str85);
                selectCommand.Parameters.AddWithValue("@Program_Code", 3);
                selectCommand.Parameters.AddWithValue("@Major", str86);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime31);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime32);
                selectCommand.Parameters.AddWithValue("@Grade", str87);
                selectCommand.Parameters.AddWithValue("@Position", str88);
                selectCommand.Parameters.AddWithValue("@Activities", str89);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str90 = dataTable2.Rows[168]["Value"].ToString();
            string str91 = dataTable2.Rows[169]["Value"].ToString();
            string str92 = dataTable2.Rows[170]["Value"].ToString();
            if (dataTable2.Rows[171]["Value"].ToString() != string.Empty)
                dateTime33 = Convert.ToDateTime(dataTable2.Rows[171]["Value"].ToString());
            if (dataTable2.Rows[172]["Value"].ToString() != string.Empty)
                dateTime34 = Convert.ToDateTime(dataTable2.Rows[172]["Value"].ToString());
            dataTable2.Rows[173]["Value"].ToString();
            string str93 = dataTable2.Rows[174]["Value"].ToString();
            string str94 = dataTable2.Rows[175]["Value"].ToString();
            string str95 = dataTable2.Rows[176]["Value"].ToString();
            string str96 = dataTable2.Rows[179]["Value"].ToString();
            string str97 = dataTable2.Rows[180]["Value"].ToString();
            string str98 = dataTable2.Rows[181]["Value"].ToString();
            if (dataTable2.Rows[182]["Value"].ToString() != string.Empty)
                dateTime35 = Convert.ToDateTime(dataTable2.Rows[182]["Value"].ToString());
            if (dataTable2.Rows[183]["Value"].ToString() != string.Empty)
                dateTime36 = Convert.ToDateTime(dataTable2.Rows[183]["Value"].ToString());
            dataTable2.Rows[184]["Value"].ToString();
            string str99 = dataTable2.Rows[185]["Value"].ToString();
            string str100 = dataTable2.Rows[186]["Value"].ToString();
            string str101 = dataTable2.Rows[187]["Value"].ToString();
            string str102 = dataTable2.Rows[190]["Value"].ToString();
            string str103 = dataTable2.Rows[191]["Value"].ToString();
            string str104 = dataTable2.Rows[192]["Value"].ToString();
            if (dataTable2.Rows[193]["Value"].ToString() != string.Empty)
                dateTime37 = Convert.ToDateTime(dataTable2.Rows[193]["Value"].ToString());
            if (dataTable2.Rows[194]["Value"].ToString() != string.Empty)
                dateTime38 = Convert.ToDateTime(dataTable2.Rows[194]["Value"].ToString());
            dataTable2.Rows[195]["Value"].ToString();
            string str105 = dataTable2.Rows[196]["Value"].ToString();
            string str106 = dataTable2.Rows[197]["Value"].ToString();
            string str107 = dataTable2.Rows[198]["Value"].ToString();
            string str108 = dataTable2.Rows[201]["Value"].ToString();
            string str109 = dataTable2.Rows[202]["Value"].ToString();
            string str110 = dataTable2.Rows[203]["Value"].ToString();
            if (dataTable2.Rows[204]["Value"].ToString() != string.Empty)
                dateTime39 = Convert.ToDateTime(dataTable2.Rows[204]["Value"].ToString());
            if (dataTable2.Rows[205]["Value"].ToString() != string.Empty)
                dateTime40 = Convert.ToDateTime(dataTable2.Rows[205]["Value"].ToString());
            dataTable2.Rows[206]["Value"].ToString();
            string str111 = dataTable2.Rows[207]["Value"].ToString();
            string str112 = dataTable2.Rows[208]["Value"].ToString();
            string str113 = dataTable2.Rows[209]["Value"].ToString();
            string str114 = dataTable2.Rows[212]["Value"].ToString();
            string str115 = dataTable2.Rows[213]["Value"].ToString();
            string str116 = dataTable2.Rows[214]["Value"].ToString();
            if (dataTable2.Rows[215]["Value"].ToString() != string.Empty)
                dateTime41 = Convert.ToDateTime(dataTable2.Rows[215]["Value"].ToString());
            if (dataTable2.Rows[216]["Value"].ToString() != string.Empty)
                dateTime42 = Convert.ToDateTime(dataTable2.Rows[216]["Value"].ToString());
            dataTable2.Rows[217]["Value"].ToString();
            string str117 = dataTable2.Rows[218]["Value"].ToString();
            string str118 = dataTable2.Rows[219]["Value"].ToString();
            string str119 = dataTable2.Rows[220]["Value"].ToString();
            if (str90 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str90);
                selectCommand.Parameters.AddWithValue("@Degree", str91);
                selectCommand.Parameters.AddWithValue("@Program_Code", 4);
                selectCommand.Parameters.AddWithValue("@Major", str92);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime33);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime34);
                selectCommand.Parameters.AddWithValue("@Grade", str93);
                selectCommand.Parameters.AddWithValue("@Position", str94);
                selectCommand.Parameters.AddWithValue("@Activities", str95);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str96 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str96);
                selectCommand.Parameters.AddWithValue("@Degree", str97);
                selectCommand.Parameters.AddWithValue("@Program_Code", 4);
                selectCommand.Parameters.AddWithValue("@Major", str98);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime35);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime36);
                selectCommand.Parameters.AddWithValue("@Grade", str99);
                selectCommand.Parameters.AddWithValue("@Position", str100);
                selectCommand.Parameters.AddWithValue("@Activities", str101);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str102 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str102);
                selectCommand.Parameters.AddWithValue("@Degree", str103);
                selectCommand.Parameters.AddWithValue("@Program_Code", 4);
                selectCommand.Parameters.AddWithValue("@Major", str104);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime37);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime38);
                selectCommand.Parameters.AddWithValue("@Grade", str105);
                selectCommand.Parameters.AddWithValue("@Position", str106);
                selectCommand.Parameters.AddWithValue("@Activities", str107);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str108 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str108);
                selectCommand.Parameters.AddWithValue("@Degree", str109);
                selectCommand.Parameters.AddWithValue("@Program_Code", 4);
                selectCommand.Parameters.AddWithValue("@Major", str110);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime39);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime40);
                selectCommand.Parameters.AddWithValue("@Grade", str111);
                selectCommand.Parameters.AddWithValue("@Position", str112);
                selectCommand.Parameters.AddWithValue("@Activities", str113);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str114 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str114);
                selectCommand.Parameters.AddWithValue("@Degree", str115);
                selectCommand.Parameters.AddWithValue("@Program_Code", 4);
                selectCommand.Parameters.AddWithValue("@Major", str116);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime41);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime42);
                selectCommand.Parameters.AddWithValue("@Grade", str117);
                selectCommand.Parameters.AddWithValue("@Position", str118);
                selectCommand.Parameters.AddWithValue("@Activities", str119);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str120 = dataTable2.Rows[223]["Value"].ToString();
            string str121 = dataTable2.Rows[224]["Value"].ToString();
            string str122 = dataTable2.Rows[225]["Value"].ToString();
            if (dataTable2.Rows[226]["Value"].ToString() != string.Empty)
                dateTime43 = Convert.ToDateTime(dataTable2.Rows[226]["Value"].ToString());
            if (dataTable2.Rows[227]["Value"].ToString() != string.Empty)
                dateTime44 = Convert.ToDateTime(dataTable2.Rows[227]["Value"].ToString());
            dataTable2.Rows[228]["Value"].ToString();
            string str123 = dataTable2.Rows[229]["Value"].ToString();
            string str124 = dataTable2.Rows[230]["Value"].ToString();
            string str125 = dataTable2.Rows[231]["Value"].ToString();
            string str126 = dataTable2.Rows[234]["Value"].ToString();
            string str127 = dataTable2.Rows[235]["Value"].ToString();
            string str128 = dataTable2.Rows[236]["Value"].ToString();
            if (dataTable2.Rows[237]["Value"].ToString() != string.Empty)
                dateTime45 = Convert.ToDateTime(dataTable2.Rows[237]["Value"].ToString());
            if (dataTable2.Rows[238]["Value"].ToString() != string.Empty)
                dateTime46 = Convert.ToDateTime(dataTable2.Rows[238]["Value"].ToString());
            dataTable2.Rows[239]["Value"].ToString();
            string str129 = dataTable2.Rows[240]["Value"].ToString();
            string str130 = dataTable2.Rows[241]["Value"].ToString();
            string str131 = dataTable2.Rows[242]["Value"].ToString();
            string str132 = dataTable2.Rows[245]["Value"].ToString();
            string str133 = dataTable2.Rows[246]["Value"].ToString();
            string str134 = dataTable2.Rows[247]["Value"].ToString();
            if (dataTable2.Rows[248]["Value"].ToString() != string.Empty)
                dateTime47 = Convert.ToDateTime(dataTable2.Rows[248]["Value"].ToString());
            if (dataTable2.Rows[249]["Value"].ToString() != string.Empty)
                dateTime48 = Convert.ToDateTime(dataTable2.Rows[249]["Value"].ToString());
            dataTable2.Rows[250]["Value"].ToString();
            string str135 = dataTable2.Rows[251]["Value"].ToString();
            string str136 = dataTable2.Rows[252]["Value"].ToString();
            string str137 = dataTable2.Rows[253]["Value"].ToString();
            string str138 = dataTable2.Rows[256]["Value"].ToString();
            string str139 = dataTable2.Rows[257]["Value"].ToString();
            string str140 = dataTable2.Rows[258]["Value"].ToString();
            if (dataTable2.Rows[259]["Value"].ToString() != string.Empty)
                dateTime49 = Convert.ToDateTime(dataTable2.Rows[259]["Value"].ToString());
            if (dataTable2.Rows[260]["Value"].ToString() != string.Empty)
                dateTime50 = Convert.ToDateTime(dataTable2.Rows[260]["Value"].ToString());
            dataTable2.Rows[261]["Value"].ToString();
            string str141 = dataTable2.Rows[262]["Value"].ToString();
            string str142 = dataTable2.Rows[263]["Value"].ToString();
            string str143 = dataTable2.Rows[264]["Value"].ToString();
            string str144 = dataTable2.Rows[267]["Value"].ToString();
            string str145 = dataTable2.Rows[268]["Value"].ToString();
            string str146 = dataTable2.Rows[269]["Value"].ToString();
            if (dataTable2.Rows[270]["Value"].ToString() != string.Empty)
                dateTime51 = Convert.ToDateTime(dataTable2.Rows[270]["Value"].ToString());
            if (dataTable2.Rows[271]["Value"].ToString() != string.Empty)
                dateTime52 = Convert.ToDateTime(dataTable2.Rows[271]["Value"].ToString());
            dataTable2.Rows[272]["Value"].ToString();
            string str147 = dataTable2.Rows[273]["Value"].ToString();
            string str148 = dataTable2.Rows[274]["Value"].ToString();
            string str149 = dataTable2.Rows[275]["Value"].ToString();
            if (str120 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str120);
                selectCommand.Parameters.AddWithValue("@Degree", str121);
                selectCommand.Parameters.AddWithValue("@Program_Code", 5);
                selectCommand.Parameters.AddWithValue("@Major", str122);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime43);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime44);
                selectCommand.Parameters.AddWithValue("@Grade", str123);
                selectCommand.Parameters.AddWithValue("@Position", str124);
                selectCommand.Parameters.AddWithValue("@Activities", str125);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str126 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str126);
                selectCommand.Parameters.AddWithValue("@Degree", str127);
                selectCommand.Parameters.AddWithValue("@Program_Code", 5);
                selectCommand.Parameters.AddWithValue("@Major", str128);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime45);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime46);
                selectCommand.Parameters.AddWithValue("@Grade", str129);
                selectCommand.Parameters.AddWithValue("@Position", str130);
                selectCommand.Parameters.AddWithValue("@Activities", str131);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str132 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str132);
                selectCommand.Parameters.AddWithValue("@Degree", str133);
                selectCommand.Parameters.AddWithValue("@Program_Code", 5);
                selectCommand.Parameters.AddWithValue("@Major", str134);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime47);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime48);
                selectCommand.Parameters.AddWithValue("@Grade", str135);
                selectCommand.Parameters.AddWithValue("@Position", str136);
                selectCommand.Parameters.AddWithValue("@Activities", str137);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str138 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str138);
                selectCommand.Parameters.AddWithValue("@Degree", str139);
                selectCommand.Parameters.AddWithValue("@Program_Code", 5);
                selectCommand.Parameters.AddWithValue("@Major", str140);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime49);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime50);
                selectCommand.Parameters.AddWithValue("@Grade", str141);
                selectCommand.Parameters.AddWithValue("@Position", str142);
                selectCommand.Parameters.AddWithValue("@Activities", str143);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            if (str144 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateQualification", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str144);
                selectCommand.Parameters.AddWithValue("@Degree", str145);
                selectCommand.Parameters.AddWithValue("@Program_Code", 5);
                selectCommand.Parameters.AddWithValue("@Major", str146);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime51);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime52);
                selectCommand.Parameters.AddWithValue("@Grade", str147);
                selectCommand.Parameters.AddWithValue("@Position", str148);
                selectCommand.Parameters.AddWithValue("@Activities", str149);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
        }
        DateTime dateTime53 = DateTime.Now;
        DateTime dateTime54 = DateTime.Now;
        Decimal num4 = new Decimal(0);
        Decimal num5 = new Decimal(0);
        DateTime dateTime55 = DateTime.Now;
        DateTime dateTime56 = DateTime.Now;
        Decimal num6 = new Decimal(0);
        Decimal num7 = new Decimal(0);
        DateTime dateTime57 = DateTime.Now;
        DateTime dateTime58 = DateTime.Now;
        Decimal num8 = new Decimal(0);
        Decimal num9 = new Decimal(0);
        DateTime dateTime59 = DateTime.Now;
        DateTime dateTime60 = DateTime.Now;
        Decimal num10 = new Decimal(0);
        Decimal num11 = new Decimal(0);
        DateTime dateTime61 = DateTime.Now;
        DateTime dateTime62 = DateTime.Now;
        Decimal num12 = new Decimal(0);
        Decimal num13 = new Decimal(0);
        DataTable dataTable3 = Common.Instance.ReadDiplomas(Path.GetDirectoryName(ImagePath), Path.GetFileName(ImagePath), "'Diploma$'");
        if (dataTable3.Rows.Count != 0)
        {
            string str1 = dataTable3.Rows[3]["Value"].ToString();
            string str2 = dataTable3.Rows[4]["Value"].ToString();
            string str3 = dataTable3.Rows[5]["Value"].ToString();
            string str4 = dataTable3.Rows[6]["Value"].ToString();
            if (dataTable3.Rows[7]["Value"].ToString() != string.Empty)
                num5 = Convert.ToDecimal(dataTable3.Rows[7]["Value"].ToString());
            if (dataTable3.Rows[8]["Value"].ToString() != string.Empty)
                dateTime53 = Convert.ToDateTime(dataTable3.Rows[8]["Value"].ToString());
            if (dataTable3.Rows[9]["Value"].ToString() != string.Empty)
                dateTime54 = Convert.ToDateTime(dataTable3.Rows[9]["Value"].ToString());
            if (dataTable3.Rows[10]["Value"].ToString() != string.Empty)
                num4 = Convert.ToDecimal(dataTable3.Rows[10]["Value"].ToString());
            string str5 = dataTable3.Rows[11]["Value"].ToString();
            string str6 = dataTable3.Rows[12]["Value"].ToString();
            string str7 = dataTable3.Rows[13]["Value"].ToString();
            if (str1 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str1);
                selectCommand.Parameters.AddWithValue("@Program_Code", 6);
                selectCommand.Parameters.AddWithValue("@Diploma", str2);
                selectCommand.Parameters.AddWithValue("@Field", str3);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str4);
                selectCommand.Parameters.AddWithValue("@Duration", num5);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime53);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime54);
                selectCommand.Parameters.AddWithValue("@Percentage", num4);
                selectCommand.Parameters.AddWithValue("@Grade", str5);
                selectCommand.Parameters.AddWithValue("@Position", str6);
                selectCommand.Parameters.AddWithValue("@Activities", str7);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str8 = dataTable3.Rows[16]["Value"].ToString();
            string str9 = dataTable3.Rows[17]["Value"].ToString();
            string str10 = dataTable3.Rows[18]["Value"].ToString();
            string str11 = dataTable3.Rows[19]["Value"].ToString();
            if (dataTable3.Rows[20]["Value"].ToString() != string.Empty)
                num7 = Convert.ToDecimal(dataTable3.Rows[20]["Value"].ToString());
            if (dataTable3.Rows[21]["Value"].ToString() != string.Empty)
                dateTime55 = Convert.ToDateTime(dataTable3.Rows[21]["Value"].ToString());
            if (dataTable3.Rows[22]["Value"].ToString() != string.Empty)
                dateTime56 = Convert.ToDateTime(dataTable3.Rows[22]["Value"].ToString());
            if (dataTable3.Rows[23]["Value"].ToString() != string.Empty)
                num6 = Convert.ToDecimal(dataTable3.Rows[23]["Value"].ToString());
            string str12 = dataTable3.Rows[24]["Value"].ToString();
            string str13 = dataTable3.Rows[25]["Value"].ToString();
            string str14 = dataTable3.Rows[26]["Value"].ToString();
            if (str8 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str8);
                selectCommand.Parameters.AddWithValue("@Program_Code", 6);
                selectCommand.Parameters.AddWithValue("@Diploma", str9);
                selectCommand.Parameters.AddWithValue("@Field", str10);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str11);
                selectCommand.Parameters.AddWithValue("@Duration", num7);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime55);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime56);
                selectCommand.Parameters.AddWithValue("@Percentage", num6);
                selectCommand.Parameters.AddWithValue("@Grade", str12);
                selectCommand.Parameters.AddWithValue("@Position", str13);
                selectCommand.Parameters.AddWithValue("@Activities", str14);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str15 = dataTable3.Rows[29]["Value"].ToString();
            string str16 = dataTable3.Rows[30]["Value"].ToString();
            string str17 = dataTable3.Rows[31]["Value"].ToString();
            string str18 = dataTable3.Rows[32]["Value"].ToString();
            if (dataTable3.Rows[33]["Value"].ToString() != string.Empty)
                num9 = Convert.ToDecimal(dataTable3.Rows[33]["Value"].ToString());
            if (dataTable3.Rows[34]["Value"].ToString() != string.Empty)
                dateTime57 = Convert.ToDateTime(dataTable3.Rows[34]["Value"].ToString());
            if (dataTable3.Rows[35]["Value"].ToString() != string.Empty)
                dateTime58 = Convert.ToDateTime(dataTable3.Rows[35]["Value"].ToString());
            if (dataTable3.Rows[36]["Value"].ToString() != string.Empty)
                num8 = Convert.ToDecimal(dataTable3.Rows[36]["Value"].ToString());
            string str19 = dataTable3.Rows[37]["Value"].ToString();
            string str20 = dataTable3.Rows[38]["Value"].ToString();
            string str21 = dataTable3.Rows[39]["Value"].ToString();
            if (str15 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str15);
                selectCommand.Parameters.AddWithValue("@Program_Code", 6);
                selectCommand.Parameters.AddWithValue("@Diploma", str16);
                selectCommand.Parameters.AddWithValue("@Field", str17);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str18);
                selectCommand.Parameters.AddWithValue("@Duration", num9);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime57);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime58);
                selectCommand.Parameters.AddWithValue("@Percentage", num8);
                selectCommand.Parameters.AddWithValue("@Grade", str19);
                selectCommand.Parameters.AddWithValue("@Position", str20);
                selectCommand.Parameters.AddWithValue("@Activities", str21);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str22 = dataTable3.Rows[42]["Value"].ToString();
            dataTable3.Rows[43]["Value"].ToString();
            string str23 = dataTable3.Rows[44]["Value"].ToString();
            string str24 = dataTable3.Rows[45]["Value"].ToString();
            if (dataTable3.Rows[46]["Value"].ToString() != string.Empty)
                num11 = Convert.ToDecimal(dataTable3.Rows[46]["Value"].ToString());
            if (dataTable3.Rows[47]["Value"].ToString() != string.Empty)
                dateTime59 = Convert.ToDateTime(dataTable3.Rows[47]["Value"].ToString());
            if (dataTable3.Rows[48]["Value"].ToString() != string.Empty)
                dateTime60 = Convert.ToDateTime(dataTable3.Rows[48]["Value"].ToString());
            if (dataTable3.Rows[49]["Value"].ToString() != string.Empty)
                num10 = Convert.ToDecimal(dataTable3.Rows[49]["Value"].ToString());
            string str25 = dataTable3.Rows[50]["Value"].ToString();
            string str26 = dataTable3.Rows[51]["Value"].ToString();
            string str27 = dataTable3.Rows[52]["Value"].ToString();
            if (str22 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str22);
                selectCommand.Parameters.AddWithValue("@Program_Code", 6);
                selectCommand.Parameters.AddWithValue("@Diploma", str2);
                selectCommand.Parameters.AddWithValue("@Field", str23);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str24);
                selectCommand.Parameters.AddWithValue("@Duration", num11);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime59);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime60);
                selectCommand.Parameters.AddWithValue("@Percentage", num10);
                selectCommand.Parameters.AddWithValue("@Grade", str25);
                selectCommand.Parameters.AddWithValue("@Position", str26);
                selectCommand.Parameters.AddWithValue("@Activities", str27);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str28 = dataTable3.Rows[55]["Value"].ToString();
            string str29 = dataTable3.Rows[56]["Value"].ToString();
            string str30 = dataTable3.Rows[57]["Value"].ToString();
            string str31 = dataTable3.Rows[58]["Value"].ToString();
            if (dataTable3.Rows[59]["Value"].ToString() != string.Empty)
                num13 = Convert.ToDecimal(dataTable3.Rows[59]["Value"].ToString());
            if (dataTable3.Rows[60]["Value"].ToString() != string.Empty)
                dateTime61 = Convert.ToDateTime(dataTable3.Rows[60]["Value"].ToString());
            if (dataTable3.Rows[61]["Value"].ToString() != string.Empty)
                dateTime62 = Convert.ToDateTime(dataTable3.Rows[61]["Value"].ToString());
            if (dataTable3.Rows[62]["Value"].ToString() != string.Empty)
                num12 = Convert.ToDecimal(dataTable3.Rows[62]["Value"].ToString());
            string str32 = dataTable3.Rows[63]["Value"].ToString();
            string str33 = dataTable3.Rows[64]["Value"].ToString();
            string str34 = dataTable3.Rows[65]["Value"].ToString();
            if (str28 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str28);
                selectCommand.Parameters.AddWithValue("@Program_Code", 6);
                selectCommand.Parameters.AddWithValue("@Diploma", str29);
                selectCommand.Parameters.AddWithValue("@Field", str30);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str31);
                selectCommand.Parameters.AddWithValue("@Duration", num13);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime61);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime62);
                selectCommand.Parameters.AddWithValue("@Percentage", num12);
                selectCommand.Parameters.AddWithValue("@Grade", str32);
                selectCommand.Parameters.AddWithValue("@Position", str33);
                selectCommand.Parameters.AddWithValue("@Activities", str34);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
        }
        DateTime dateTime63 = DateTime.Now;
        DateTime dateTime64 = DateTime.Now;
        Decimal num14 = new Decimal(0);
        Decimal num15 = new Decimal(0);
        DateTime dateTime65 = DateTime.Now;
        DateTime dateTime66 = DateTime.Now;
        Decimal num16 = new Decimal(0);
        Decimal num17 = new Decimal(0);
        DateTime dateTime67 = DateTime.Now;
        DateTime dateTime68 = DateTime.Now;
        Decimal num18 = new Decimal(0);
        Decimal num19 = new Decimal(0);
        DateTime dateTime69 = DateTime.Now;
        DateTime dateTime70 = DateTime.Now;
        Decimal num20 = new Decimal(0);
        Decimal num21 = new Decimal(0);
        DateTime dateTime71 = DateTime.Now;
        DateTime dateTime72 = DateTime.Now;
        Decimal num22 = new Decimal(0);
        Decimal num23 = new Decimal(0);
        DataTable dataTable4 = Common.Instance.ReadDiplomas(Path.GetDirectoryName(ImagePath), Path.GetFileName(ImagePath), "'Certificate$'");
        if (dataTable4.Rows.Count != 0)
        {
            string str1 = dataTable4.Rows[3]["Value"].ToString();
            string str2 = dataTable4.Rows[4]["Value"].ToString();
            string str3 = dataTable4.Rows[5]["Value"].ToString();
            string str4 = dataTable4.Rows[6]["Value"].ToString();
            if (dataTable4.Rows[7]["Value"].ToString() != string.Empty)
                num15 = Convert.ToDecimal(dataTable4.Rows[7]["Value"].ToString());
            if (dataTable4.Rows[8]["Value"].ToString() != string.Empty)
                dateTime63 = Convert.ToDateTime(dataTable4.Rows[8]["Value"].ToString());
            if (dataTable4.Rows[9]["Value"].ToString() != string.Empty)
                dateTime64 = Convert.ToDateTime(dataTable4.Rows[9]["Value"].ToString());
            if (dataTable4.Rows[10]["Value"].ToString() != string.Empty)
                num14 = Convert.ToDecimal(dataTable4.Rows[10]["Value"].ToString());
            string str5 = dataTable4.Rows[11]["Value"].ToString();
            string str6 = dataTable4.Rows[12]["Value"].ToString();
            string str7 = dataTable4.Rows[13]["Value"].ToString();
            if (str1 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str1);
                selectCommand.Parameters.AddWithValue("@Program_Code", 7);
                selectCommand.Parameters.AddWithValue("@Diploma", str2);
                selectCommand.Parameters.AddWithValue("@Field", str3);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str4);
                selectCommand.Parameters.AddWithValue("@Duration", num15);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime63);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime64);
                selectCommand.Parameters.AddWithValue("@Percentage", num14);
                selectCommand.Parameters.AddWithValue("@Grade", str5);
                selectCommand.Parameters.AddWithValue("@Position", str6);
                selectCommand.Parameters.AddWithValue("@Activities", str7);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str8 = dataTable4.Rows[16]["Value"].ToString();
            string str9 = dataTable4.Rows[17]["Value"].ToString();
            string str10 = dataTable4.Rows[18]["Value"].ToString();
            string str11 = dataTable4.Rows[19]["Value"].ToString();
            if (dataTable4.Rows[20]["Value"].ToString() != string.Empty)
                num17 = Convert.ToDecimal(dataTable4.Rows[20]["Value"].ToString());
            if (dataTable4.Rows[21]["Value"].ToString() != string.Empty)
                dateTime65 = Convert.ToDateTime(dataTable4.Rows[21]["Value"].ToString());
            if (dataTable4.Rows[22]["Value"].ToString() != string.Empty)
                dateTime66 = Convert.ToDateTime(dataTable4.Rows[22]["Value"].ToString());
            if (dataTable4.Rows[23]["Value"].ToString() != string.Empty)
                num16 = Convert.ToDecimal(dataTable4.Rows[23]["Value"].ToString());
            string str12 = dataTable4.Rows[24]["Value"].ToString();
            string str13 = dataTable4.Rows[25]["Value"].ToString();
            string str14 = dataTable4.Rows[26]["Value"].ToString();
            if (str8 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str8);
                selectCommand.Parameters.AddWithValue("@Program_Code", 7);
                selectCommand.Parameters.AddWithValue("@Diploma", str9);
                selectCommand.Parameters.AddWithValue("@Field", str10);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str11);
                selectCommand.Parameters.AddWithValue("@Duration", num17);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime65);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime66);
                selectCommand.Parameters.AddWithValue("@Percentage", num16);
                selectCommand.Parameters.AddWithValue("@Grade", str12);
                selectCommand.Parameters.AddWithValue("@Position", str13);
                selectCommand.Parameters.AddWithValue("@Activities", str14);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str15 = dataTable4.Rows[29]["Value"].ToString();
            string str16 = dataTable4.Rows[30]["Value"].ToString();
            string str17 = dataTable4.Rows[31]["Value"].ToString();
            string str18 = dataTable4.Rows[32]["Value"].ToString();
            if (dataTable4.Rows[33]["Value"].ToString() != string.Empty)
                num19 = Convert.ToDecimal(dataTable4.Rows[33]["Value"].ToString());
            if (dataTable4.Rows[34]["Value"].ToString() != string.Empty)
                dateTime67 = Convert.ToDateTime(dataTable4.Rows[34]["Value"].ToString());
            if (dataTable4.Rows[35]["Value"].ToString() != string.Empty)
                dateTime68 = Convert.ToDateTime(dataTable4.Rows[35]["Value"].ToString());
            if (dataTable4.Rows[36]["Value"].ToString() != string.Empty)
                num18 = Convert.ToDecimal(dataTable4.Rows[36]["Value"].ToString());
            string str19 = dataTable4.Rows[37]["Value"].ToString();
            string str20 = dataTable4.Rows[38]["Value"].ToString();
            string str21 = dataTable4.Rows[39]["Value"].ToString();
            if (str15 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str15);
                selectCommand.Parameters.AddWithValue("@Program_Code", 7);
                selectCommand.Parameters.AddWithValue("@Diploma", str16);
                selectCommand.Parameters.AddWithValue("@Field", str17);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str18);
                selectCommand.Parameters.AddWithValue("@Duration", num19);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime67);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime68);
                selectCommand.Parameters.AddWithValue("@Percentage", num18);
                selectCommand.Parameters.AddWithValue("@Grade", str19);
                selectCommand.Parameters.AddWithValue("@Position", str20);
                selectCommand.Parameters.AddWithValue("@Activities", str21);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str22 = dataTable4.Rows[42]["Value"].ToString();
            string str23 = dataTable4.Rows[43]["Value"].ToString();
            string str24 = dataTable4.Rows[44]["Value"].ToString();
            string str25 = dataTable4.Rows[45]["Value"].ToString();
            if (dataTable4.Rows[46]["Value"].ToString() != string.Empty)
                num21 = Convert.ToDecimal(dataTable4.Rows[46]["Value"].ToString());
            if (dataTable4.Rows[47]["Value"].ToString() != string.Empty)
                dateTime69 = Convert.ToDateTime(dataTable4.Rows[47]["Value"].ToString());
            if (dataTable4.Rows[48]["Value"].ToString() != string.Empty)
                dateTime70 = Convert.ToDateTime(dataTable4.Rows[48]["Value"].ToString());
            if (dataTable4.Rows[49]["Value"].ToString() != string.Empty)
                num20 = Convert.ToDecimal(dataTable4.Rows[49]["Value"].ToString());
            string str26 = dataTable4.Rows[50]["Value"].ToString();
            string str27 = dataTable4.Rows[51]["Value"].ToString();
            string str28 = dataTable4.Rows[52]["Value"].ToString();
            if (str22 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str22);
                selectCommand.Parameters.AddWithValue("@Program_Code", 7);
                selectCommand.Parameters.AddWithValue("@Diploma", str23);
                selectCommand.Parameters.AddWithValue("@Field", str24);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str25);
                selectCommand.Parameters.AddWithValue("@Duration", num21);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime69);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime70);
                selectCommand.Parameters.AddWithValue("@Percentage", num20);
                selectCommand.Parameters.AddWithValue("@Grade", str26);
                selectCommand.Parameters.AddWithValue("@Position", str27);
                selectCommand.Parameters.AddWithValue("@Activities", str28);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
            string str29 = dataTable4.Rows[55]["Value"].ToString();
            string str30 = dataTable4.Rows[56]["Value"].ToString();
            string str31 = dataTable4.Rows[57]["Value"].ToString();
            string str32 = dataTable4.Rows[58]["Value"].ToString();
            if (dataTable4.Rows[59]["Value"].ToString() != string.Empty)
                num23 = Convert.ToDecimal(dataTable4.Rows[59]["Value"].ToString());
            if (dataTable4.Rows[60]["Value"].ToString() != string.Empty)
                dateTime71 = Convert.ToDateTime(dataTable4.Rows[60]["Value"].ToString());
            if (dataTable4.Rows[61]["Value"].ToString() != string.Empty)
                dateTime72 = Convert.ToDateTime(dataTable4.Rows[61]["Value"].ToString());
            if (dataTable4.Rows[62]["Value"].ToString() != string.Empty)
                num22 = Convert.ToDecimal(dataTable4.Rows[62]["Value"].ToString());
            string str33 = dataTable4.Rows[63]["Value"].ToString();
            string str34 = dataTable4.Rows[64]["Value"].ToString();
            string str35 = dataTable4.Rows[65]["Value"].ToString();
            if (str29 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_DiplomaAndCertificate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Institute", str29);
                selectCommand.Parameters.AddWithValue("@Program_Code", 7);
                selectCommand.Parameters.AddWithValue("@Diploma", str30);
                selectCommand.Parameters.AddWithValue("@Field", str31);
                selectCommand.Parameters.AddWithValue("@Issuing_Body", str32);
                selectCommand.Parameters.AddWithValue("@Duration", num23);
                selectCommand.Parameters.AddWithValue("@Start_Date", dateTime71);
                selectCommand.Parameters.AddWithValue("@End_Date", dateTime72);
                selectCommand.Parameters.AddWithValue("@Percentage", num22);
                selectCommand.Parameters.AddWithValue("@Grade", str33);
                selectCommand.Parameters.AddWithValue("@Position", str34);
                selectCommand.Parameters.AddWithValue("@Activities", str35);
                new SqlDataAdapter(selectCommand).Fill(new DataSet());
            }
        }
        DataTable dataTable5 = Common.Instance.ReadSkills(Path.GetDirectoryName(ImagePath), Path.GetFileName(ImagePath), "'Skill Set$'");
        if (dataTable5.Rows.Count != 0)
        {
            string str1 = dataTable5.Rows[2]["Attribute"].ToString();
            string str2 = dataTable5.Rows[3]["Attribute"].ToString();
            string str3 = dataTable5.Rows[4]["Attribute"].ToString();
            string str4 = dataTable5.Rows[5]["Attribute"].ToString();
            string str5 = dataTable5.Rows[6]["Attribute"].ToString();
            string str6 = dataTable5.Rows[7]["Attribute"].ToString();
            string str7 = dataTable5.Rows[8]["Attribute"].ToString();
            string str8 = dataTable5.Rows[9]["Attribute"].ToString();
            string str9 = dataTable5.Rows[10]["Attribute"].ToString();
            string str10 = dataTable5.Rows[11]["Attribute"].ToString();
            if (str1 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str1);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str2 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str2);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str3 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str3);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str4 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str4);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str5 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str5);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str6 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str6);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str7 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str7);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str8 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str8);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str9 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str9);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str10 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Insert_TempCandidateSkills", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Skill", str10);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
        }
        DataTable dataTable6 = Common.Instance.ReadPersonalDetail(Path.GetDirectoryName(ImagePath), Path.GetFileName(ImagePath), "'Personal Details$'");
        if (dataTable6.Rows.Count != 0)
        {
            string str1 = dataTable6.Rows[2]["Value"].ToString();
            string str2 = dataTable6.Rows[3]["Value"].ToString();
            string str3 = dataTable6.Rows[4]["Value"].ToString();
            DateTime dateTime1 = Convert.ToDateTime(dataTable6.Rows[5]["Value"].ToString());
            string str4 = dataTable6.Rows[6]["Value"].ToString();
            string str5 = dataTable6.Rows[7]["Value"].ToString();
            string str6 = dataTable6.Rows[8]["Value"].ToString();
            string str7 = dataTable6.Rows[9]["Value"].ToString();
            string str8 = dataTable6.Rows[10]["Value"].ToString();
            string str9 = dataTable6.Rows[11]["Value"].ToString();
            if (str1 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Update_tempCandidate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Email_Address", str1);
                selectCommand.Parameters.AddWithValue("@MobilePhone_Number", str2);
                selectCommand.Parameters.AddWithValue("@HomePhone_Number", str3);
                selectCommand.Parameters.AddWithValue("@DateOf_Birth", dateTime1);
                selectCommand.Parameters.AddWithValue("@Gender", str4);
                selectCommand.Parameters.AddWithValue("@MaritalStatus", str5);
                selectCommand.Parameters.AddWithValue("@Religon", str6);
                selectCommand.Parameters.AddWithValue("@Nationality", str8);
                selectCommand.Parameters.AddWithValue("@NIC", str9);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (dataTable6.Rows[5]["Value"].ToString() != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("Update_tempCandidate", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Email_Address", str1);
                selectCommand.Parameters.AddWithValue("@MobilePhone_Number", str2);
                selectCommand.Parameters.AddWithValue("@HomePhone_Number", str3);
                selectCommand.Parameters.AddWithValue("@DateOf_Birth", dateTime1);
                selectCommand.Parameters.AddWithValue("@Gender", str4);
                selectCommand.Parameters.AddWithValue("@MaritalStatus", str5);
                selectCommand.Parameters.AddWithValue("@Religon", str6);
                selectCommand.Parameters.AddWithValue("@Nationality", str8);
                selectCommand.Parameters.AddWithValue("@NIC", str9);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            if (str7 != string.Empty)
            {
                SqlCommand selectCommand = new SqlCommand("insert_TempCandidateAddress", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandTimeout = 0;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@Candidate_Code", Candidate_BrowseResume.CanCode);
                selectCommand.Parameters.AddWithValue("@Address", str7);
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
        }
        lblMsg.Text = "Data saved successfully...";
    }

    public static string UploadFile(FileUpload uploadDoc, string shareFolderPath)
    {
        string str1 = string.Empty;
        string empty = string.Empty;
        if (uploadDoc.HasFile && uploadDoc.PostedFile.ContentLength != 0)
        {
            string str2 = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string lower = Path.GetExtension(uploadDoc.FileName).ToLower();
            if (!(lower == ".xls") && !(lower == ".xlsx"))
                return "-1";
            string FileName = Candidate_BrowseResume.CanCode.ToString() + "_" + Path.GetFileNameWithoutExtension(uploadDoc.FileName) + "_" + str2.ToString() + Path.GetExtension(uploadDoc.FileName);
            str1 = "/" + Candidate_BrowseResume.FileBrowse(uploadDoc, shareFolderPath, FileName);
        }
        return str1;
    }

    public static string FileBrowse(FileUpload Source, string FolderPath, string FileName)
    {
        Candidate_BrowseResume.CreateFolder(FolderPath);
        string str1 = FileName;
        string str2 = HttpContext.Current.Server.MapPath(FolderPath);
        if (str1 != "" && Source.PostedFile.ContentLength != 0)
        {
            string filename = str2 + "\\" + str1;
            Source.PostedFile.SaveAs(filename);
        }
        return str1;
    }

    public static void CreateFolder(string FolderPath)
    {
        string path = HttpContext.Current.Server.MapPath(FolderPath);
        if (new DirectoryInfo(path).Exists)
            return;
        Directory.CreateDirectory(path);
    }

    public static void ViewFile(string filename, string FolderPath)
    {
        FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(FolderPath + "/" + filename));
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
    #endregion


}