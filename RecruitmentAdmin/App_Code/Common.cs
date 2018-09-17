// Decompiled with JetBrains decompiler
// Type: Common
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public class Common
{
  private static Common instance;

  public static Common Instance
  {
    get
    {
      if (Common.instance == null)
        Common.instance = new Common();
      return Common.instance;
    }
  }

  public string GetExcelSheetNames(string excelFileName, string sheetName)
  {
    OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFileName + ";Extended Properties=Excel 12.0;");
    oleDbConnection.Open();
    DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, (object[]) null);
    oleDbConnection.Close();
    if (oleDbSchemaTable == null)
      return (string) null;
    foreach (DataRow row in (InternalDataCollectionBase) oleDbSchemaTable.Rows)
    {
      if (row["TABLE_NAME"].ToString() == sheetName || "'" + row["TABLE_NAME"].ToString() + "'" == sheetName)
        return row["TABLE_NAME"].ToString();
    }
    return (string) null;
  }

  public DataTable ReadProfessionalExperience(string pathName, string fileName, string sheetName)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Attribute", typeof (string));
    dataTable.Columns.Add("Value", typeof (string));
    try
    {
      using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + "\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes\";"))
      {
        OleDbCommand oleDbCommand = new OleDbCommand("Select * from [" + this.GetExcelSheetNames(pathName + "\\" + fileName, sheetName) + "]", connection);
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
        DataRow row1 = dataTable.NewRow();
        row1["Attribute"] = (object) "";
        dataTable.Rows.Add(row1);
        while (oleDbDataReader.Read())
        {
          DataRow row2 = dataTable.NewRow();
          if (oleDbDataReader[0].ToString().Trim() != "")
            row2["Attribute"] = (object) oleDbDataReader[0].ToString();
          if (oleDbDataReader[1].ToString().Trim() != "")
            row2["Value"] = (object) oleDbDataReader[1].ToString();
          dataTable.Rows.Add(row2);
        }
        oleDbDataReader.Close();
        connection.Close();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return dataTable;
  }

  public DataTable ReadEducationalQualification(string pathName, string fileName, string sheetName)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Attribute", typeof (string));
    dataTable.Columns.Add("Value", typeof (string));
    try
    {
      using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + "\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes\";"))
      {
        OleDbCommand oleDbCommand = new OleDbCommand("Select * from [" + this.GetExcelSheetNames(pathName + "\\" + fileName, sheetName) + "]", connection);
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
        DataRow row1 = dataTable.NewRow();
        row1["Attribute"] = (object) "";
        dataTable.Rows.Add(row1);
        while (oleDbDataReader.Read())
        {
          DataRow row2 = dataTable.NewRow();
          if (oleDbDataReader[0].ToString().Trim() != "")
            row2["Attribute"] = (object) oleDbDataReader[0].ToString();
          if (oleDbDataReader[1].ToString().Trim() != "")
            row2["Value"] = (object) oleDbDataReader[1].ToString();
          dataTable.Rows.Add(row2);
        }
        oleDbDataReader.Close();
        connection.Close();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return dataTable;
  }

  public DataTable ReadDiplomas(string pathName, string fileName, string sheetName)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Attribute", typeof (string));
    dataTable.Columns.Add("Value", typeof (string));
    try
    {
      using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + "\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes\";"))
      {
        OleDbCommand oleDbCommand = new OleDbCommand("Select * from [" + this.GetExcelSheetNames(pathName + "\\" + fileName, sheetName) + "]", connection);
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
        DataRow row1 = dataTable.NewRow();
        row1["Attribute"] = (object) "";
        dataTable.Rows.Add(row1);
        while (oleDbDataReader.Read())
        {
          DataRow row2 = dataTable.NewRow();
          if (oleDbDataReader[0].ToString().Trim() != "")
            row2["Attribute"] = (object) oleDbDataReader[0].ToString();
          if (oleDbDataReader[1].ToString().Trim() != "")
            row2["Value"] = (object) oleDbDataReader[1].ToString();
          dataTable.Rows.Add(row2);
        }
        oleDbDataReader.Close();
        connection.Close();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return dataTable;
  }

  public DataTable ReadSkills(string pathName, string fileName, string sheetName)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Attribute", typeof (string));
    try
    {
      using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + "\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes\";"))
      {
        OleDbCommand oleDbCommand = new OleDbCommand("Select * from [" + this.GetExcelSheetNames(pathName + "\\" + fileName, sheetName) + "]", connection);
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
        DataRow row1 = dataTable.NewRow();
        row1["Attribute"] = (object) "";
        dataTable.Rows.Add(row1);
        while (oleDbDataReader.Read())
        {
          DataRow row2 = dataTable.NewRow();
          if (oleDbDataReader[0].ToString().Trim() != "")
            row2["Attribute"] = (object) oleDbDataReader[0].ToString();
          dataTable.Rows.Add(row2);
        }
        oleDbDataReader.Close();
        connection.Close();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return dataTable;
  }

  public DataTable ReadPersonalDetail(string pathName, string fileName, string sheetName)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Attribute", typeof (string));
    dataTable.Columns.Add("Value", typeof (string));
    try
    {
      using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + "\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes\";"))
      {
        OleDbCommand oleDbCommand = new OleDbCommand("Select * from [" + this.GetExcelSheetNames(pathName + "\\" + fileName, sheetName) + "]", connection);
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
        DataRow row1 = dataTable.NewRow();
        row1["Attribute"] = (object) "";
        dataTable.Rows.Add(row1);
        while (oleDbDataReader.Read())
        {
          DataRow row2 = dataTable.NewRow();
          if (oleDbDataReader[0].ToString().Trim() != "")
            row2["Attribute"] = (object) oleDbDataReader[0].ToString();
          if (oleDbDataReader[1].ToString().Trim() != "")
            row2["Value"] = (object) oleDbDataReader[1].ToString();
          dataTable.Rows.Add(row2);
        }
        oleDbDataReader.Close();
        connection.Close();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return dataTable;
  }

  public static DataSet FillDropDown(int UserCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileCriteriaByUser", new List<SqlParameter>()
    {
      new SqlParameter("@UserCode", (object) UserCode)
    }.ToArray());
  }

  public static DataSet GetProfileCriteria()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileCriteria", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetSubdomainByDomainCode(int DomainCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (DomainCode != 0)
      sqlParameterList.Add(new SqlParameter("@DomainCode", (object) DomainCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectSubDomain", sqlParameterList.ToArray());
  }

  public static DataSet GetDomainByUserCode(int UserCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectDomainByUser", new List<SqlParameter>()
    {
      new SqlParameter("@UserCode", (object) UserCode)
    }.ToArray());
  }

  public static DataSet GetProfile()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfile", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetHRGrade()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectGrade", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetTest()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectTest", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetBonusType()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectBonusType", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetPositionType()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Select_PositionType", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetParameter()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileOGData", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetParameterValuebyParameterCode(int ParameterCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileOGValueDataByCode", new List<SqlParameter>()
    {
      new SqlParameter("@Parameter_Code", (object) ParameterCode)
    }.ToArray());
  }

  public static DataSet GetAllProfile()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectAllProfile", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetJobRole()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Select_JobRole", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetDomainByStaffCode(int IsStaff)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (IsStaff != -1)
      sqlParameterList.Add(new SqlParameter("@IsStaff", (object) IsStaff));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_DomainByStaffCode", sqlParameterList.ToArray());
  }

  public static DataSet GetVenueDetailByVenueCode(int VenueCode, int RequiositionCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_OnlyVenueDetailsByVenueCode", new List<SqlParameter>()
    {
      new SqlParameter("@VenueCode", (object) VenueCode),
      new SqlParameter("@RequiositionCode", (object) RequiositionCode)
    }.ToArray());
  }

  public static DataSet GetCategoryByDomainCode(int DomainCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (DomainCode != -1 && DomainCode != 0)
      sqlParameterList.Add(new SqlParameter("@DomainCode", (object) DomainCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_CategoryByDomainCode", sqlParameterList.ToArray());
  }

  public static DataSet GetDepartment(int UserCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Select_Department", new List<SqlParameter>()
    {
      new SqlParameter("@UserCode", (object) UserCode)
    }.ToArray());
  }

  public static DataSet GetUser(int DepartmentCode, int UserCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (DepartmentCode != -1)
      sqlParameterList.Add(new SqlParameter("@DeptID", (object) DepartmentCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_select_UserByDepartment", sqlParameterList.ToArray());
  }

  public static DataSet GetCity()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_City", new List<SqlParameter>().ToArray());
  }
}
