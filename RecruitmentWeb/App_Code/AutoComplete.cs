using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;

[ScriptService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[WebService(Namespace = "http://tempuri.org/")]
public class AutoComplete : WebService
{
    [WebMethod]
    public List<AutoComplete.TestIndustryData> FetchIndustryList(string prefixText)
    {
        List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
        using (SqlConnection sqlConnection = new SqlConnection())
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectIndustry";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectCompanyWithDetail";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredLocation";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
    public List<AutoComplete.TestIndustryData> FetchInstituteList(string prefixText)
    {
        List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
        using (SqlConnection sqlConnection = new SqlConnection())
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredInstitute";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
    public List<AutoComplete.TestIndustryData> FetchDegreeList(string prefixText)
    {
        List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
        using (SqlConnection sqlConnection = new SqlConnection())
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredDoctoratePrograms";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredMajor";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredMasterPrograms";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredBachelorPrograms";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredIntermediatePrograms";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredMatricPrograms";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredDiploma";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredPrograms";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)str2);
                sqlCommand.Parameters.AddWithValue("@Program_Code", (object)str1);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredCertificate";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectFilteredSkill";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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
    public List<AutoComplete.TestIndustryData> FetchJobTitle(string prefixText)
    {
        List<AutoComplete.TestIndustryData> source = new List<AutoComplete.TestIndustryData>();
        using (SqlConnection sqlConnection = new SqlConnection())
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "dbo.XRec_SelectJobTitle";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SearchText", (object)prefixText);
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

    public class TestIndustryData
    {
        public string Code { get; set; }

        public string Name { get; set; }
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
}