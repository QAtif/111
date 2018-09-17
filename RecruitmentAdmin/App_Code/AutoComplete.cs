// Decompiled with JetBrains decompiler
// Type: AutoComplete
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll


using AjaxControlToolkit;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;

[ScriptService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
public class AutoComplete : System.Web.Services.WebService
{
  [WebMethod]
  public List<CandidateData> FetchUnMappedCandidate(string prefixText)
  {
    List<CandidateData> source = new List<CandidateData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectUnMappedCandidateByFilter";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new CandidateData()
            {
              CandidateCode = sqlDataReader["Candidate_Code"].ToString(),
              CandidateFullName = sqlDataReader["Full_Name"].ToString(),
              CandidateEmailAddress = sqlDataReader["Email_Address"].ToString(),
              CandidatePhoneNumber = sqlDataReader["Phone_Number"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<CandidateData>();
  }

  [WebMethod]
  public List<CandidateData> FetchMappedCandidate(string prefixText)
  {
    List<CandidateData> source = new List<CandidateData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectMappedCandidateByFilter";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new CandidateData()
            {
              CandidateCode = sqlDataReader["Candidate_Code"].ToString(),
              CandidateFullName = sqlDataReader["Full_Name"].ToString(),
              CandidateEmailAddress = sqlDataReader["Email_Address"].ToString(),
              CandidatePhoneNumber = sqlDataReader["Phone_Number"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<CandidateData>();
  }

  [WebMethod]
  public List<SkillData> FetchSkill(string prefixText)
  {
    List<SkillData> source = new List<SkillData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectSkills";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new SkillData()
            {
              SkillCode = sqlDataReader["Skill_Code"].ToString(),
              SkillName = sqlDataReader["Skill"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<SkillData>();
  }

  [WebMethod]
  public List<string> FetchSkillList(string prefixText)
  {
    List<string> stringList1 = new List<string>();
    DataSet dataSet = new DataSet();
    using (SqlConnection connection = new SqlConnection())
    {
      connection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand selectCommand = new SqlCommand("XRec_SelectSkills", connection))
      {
        selectCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        selectCommand.CommandType = CommandType.StoredProcedure;
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
          sqlDataAdapter.Fill(dataSet);
      }
    }
    List<string> stringList2 = new List<string>();
    for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
    {
      string autoCompleteItem = AutoCompleteExtender.CreateAutoCompleteItem(dataSet.Tables[0].Rows[index]["Skill"].ToString(), dataSet.Tables[0].Rows[index]["Skill_Code"].ToString());
      stringList2.Add(autoCompleteItem);
    }
    return stringList2;
  }

  [WebMethod]
  public List<IndustryData> FetchIndustry(string prefixText)
  {
    List<IndustryData> source = new List<IndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectIndustry";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new IndustryData()
            {
              IndustryCode = sqlDataReader["IndustryCode"].ToString(),
              IndustryName = sqlDataReader["IndustryName"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<IndustryData>();
  }

  [WebMethod]
  public List<CompanyData> FetchCompany(string prefixText)
  {
    List<CompanyData> source = new List<CompanyData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectCompany";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new CompanyData()
            {
              CompanyCode = sqlDataReader["CompanyCode"].ToString(),
              CompanyName = sqlDataReader["CompanyName"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<CompanyData>();
  }

  [WebMethod]
  public List<BenefitData> FetchBenefits(string prefixText)
  {
    List<BenefitData> source = new List<BenefitData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectBenefitForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new BenefitData()
            {
              BenefitCode = sqlDataReader["Benefit_Code"].ToString(),
              BenifitName = sqlDataReader["Benefits"].ToString(),
              BenifitType = sqlDataReader["Benefit_Type"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<BenefitData>();
  }

  [WebMethod]
  public List<DegreeData> FetchDegree(string prefixText)
  {
    List<DegreeData> source = new List<DegreeData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectDegreeForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new DegreeData()
            {
              DegreeCode = sqlDataReader["Degree_Code"].ToString(),
              DegreeName = sqlDataReader["Degree"].ToString(),
              ProgramName = sqlDataReader["Program_Name"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<DegreeData>();
  }

  [WebMethod]
  public List<MajorData> FetchMajor(string prefixText)
  {
    List<MajorData> source = new List<MajorData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectMajorForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new MajorData()
            {
              MajorCode = sqlDataReader["Major_Code"].ToString(),
              MajorName = sqlDataReader["Major_Name"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<MajorData>();
  }

  [WebMethod]
  public List<InstituteData> FetchInstitute(string prefixText)
  {
    List<InstituteData> source = new List<InstituteData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectInstituteForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new InstituteData()
            {
              InstituteCode = sqlDataReader["Institute_Code"].ToString(),
              InstituteName = sqlDataReader["Institute"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<InstituteData>();
  }

  [WebMethod]
  public List<DomainData> FetchDomain(string prefixText)
  {
    List<DomainData> source = new List<DomainData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectDomainForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new DomainData()
            {
              DomainCode = sqlDataReader["Domain_Code"].ToString(),
              DomainName = sqlDataReader["Domain_Name"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<DomainData>();
  }

  [WebMethod]
  public List<SubDomainData> FetchSubDomain(string prefixText)
  {
    List<SubDomainData> source = new List<SubDomainData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "XRec_SelectSubDomainForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new SubDomainData()
            {
              SubDomainCode = sqlDataReader["SubDomain_Code"].ToString(),
              SubDomainName = sqlDataReader["SubDomain_Name"].ToString(),
              DomainName = sqlDataReader["Domain_Name"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<SubDomainData>();
  }

  [WebMethod]
  public List<string> FetchCompanyLive(string prefixText)
  {
    List<string> stringList1 = new List<string>();
    DataSet dataSet = new DataSet();
    using (SqlConnection connection = new SqlConnection())
    {
      connection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentLiveConn"].ConnectionString;
      using (SqlCommand selectCommand = new SqlCommand("Xweb_Select_Company", connection))
      {
        selectCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        selectCommand.CommandType = CommandType.StoredProcedure;
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
          sqlDataAdapter.Fill(dataSet);
      }
    }
    List<string> stringList2 = new List<string>();
    for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
    {
      string autoCompleteItem = AutoCompleteExtender.CreateAutoCompleteItem(dataSet.Tables[0].Rows[index]["Company_Name"].ToString(), dataSet.Tables[0].Rows[index]["Company_Name"].ToString());
      stringList2.Add(autoCompleteItem);
    }
    return stringList2;
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchIndustryList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectIndustry";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["IndustryCode"].ToString(),
              Name = sqlDataReader["IndustryName"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestCompanyData> FetchCompanyList(string prefixText)
  {
    List<AutoComplete.TestCompanyData> source = new List<AutoComplete.TestCompanyData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectCompanyWithDetail";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestCompanyData()
            {
              Code = sqlDataReader["CompanyCode"].ToString(),
              Name = sqlDataReader["CompanyName"].ToString(),
              Website = sqlDataReader["CompanyWebsite"].ToString(),
              Number = sqlDataReader["CompanyNumber"].ToString(),
              Email = sqlDataReader["CompanyEmail"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestCompanyData>();
  }

  [WebMethod]
  public List<AutoComplete.TestLocationData> FetchLocationList(string prefixText)
  {
    List<AutoComplete.TestLocationData> source = new List<AutoComplete.TestLocationData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredLocation";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestLocationData()
            {
              Code = sqlDataReader["LocationCode"].ToString(),
              Name = sqlDataReader["LocationName"].ToString(),
              type = sqlDataReader["Type"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestLocationData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchJobTitle(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectJobTitle";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["JobTitle_Code"].ToString(),
              Name = sqlDataReader["JobTitle"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchInstituteList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredInstitute";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["InstituteCode"].ToString(),
              Name = sqlDataReader["InstituteName"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchListProgramWise(string prefixText)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string[] strArray = prefixText.Split('%');
    string str1 = strArray[1];
    string str2 = strArray[0];
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredPrograms";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) str2);
        sqlCommand.Parameters.AddWithValue("@Program_Code", (object) str1);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.CategorySubDomain> FetchCategoryWithSubdomain(string prefixText)
  {
    List<AutoComplete.CategorySubDomain> source = new List<AutoComplete.CategorySubDomain>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredCategoryWithSubDomain";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.CategorySubDomain()
            {
              CategoryCode = sqlDataReader["Category_Code"].ToString(),
              SubDomainCode = sqlDataReader["SubDomain_Code"].ToString(),
              DomainCode = sqlDataReader["Domain_Code"].ToString(),
              CategoryName = sqlDataReader["CategoryName"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.CategorySubDomain>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchDegreeList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredDoctoratePrograms";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchFieldList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredMajor";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["MajorID"].ToString(),
              Name = sqlDataReader["Major"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchMasterList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredMasterPrograms";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchBachelorsList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredBachelorPrograms";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchInterList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredIntermediatePrograms";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchMatricList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredMatricPrograms";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchDiplomaList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredDiploma";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchCertificateList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredCertificate";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["DegreeID"].ToString(),
              Name = sqlDataReader["Degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchSkillSetList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectFilteredSkill";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["SkillID"].ToString(),
              Name = sqlDataReader["Skill"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchAllDegreeSetList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.Xrec_SelectDegree";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["degree_code"].ToString(),
              Name = sqlDataReader["degree"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  [WebMethod]
  public List<AutoComplete.TestIndustryData> FetchMajorSetList(string prefixText)
  {
    List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
    using (SqlConnection sqlConnection = new SqlConnection())
    {
      sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString;
      using (SqlCommand sqlCommand = new SqlCommand())
      {
        sqlCommand.CommandText = "dbo.XRec_SelectMajorForSearch";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@SearchText", (object) prefixText);
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        {
          while (sqlDataReader.Read())
            source.Add(new AutoComplete.TestIndustryData()
            {
              Code = sqlDataReader["Major_Code"].ToString(),
              Name = sqlDataReader["Major_Name"].ToString()
            });
        }
        sqlConnection.Close();
      }
    }
    return source.ToList<AutoComplete.TestIndustryData>();
  }

  public class TestCompanyData
  {
    public string Code { get; set; }

    public string Name { get; set; }

    public string Website { get; set; }

    public string Number { get; set; }

    public string Email { get; set; }
  }

  public class TestLocationData
  {
    public string Code { get; set; }

    public string Name { get; set; }

    public string type { get; set; }
  }

  public class CategorySubDomain
  {
    public string CategoryCode { get; set; }

    public string SubDomainCode { get; set; }

    public string DomainCode { get; set; }

    public string CategoryName { get; set; }

    public string type { get; set; }
  }

  public class TestIndustryData
  {
    public string Code { get; set; }

    public string Name { get; set; }
  }
}
