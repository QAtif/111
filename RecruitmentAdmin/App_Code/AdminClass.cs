// Decompiled with JetBrains decompiler
// Type: AdminClass
// Assembly: App_Code, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CCFCF570-EAC0-4D2F-8EF3-866C275AB6B3
// Assembly location: C:\Users\atifhussain\Desktop\Dlls\Axact Recruitment\App_Code.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class AdminClass
{
  public static bool DeleteCategory(string CategoryCode, int UpdatedBy, string UpdatedIP)
  {
    return Convert.ToInt32(SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_DeleteCategory", new List<SqlParameter>()
    {
      new SqlParameter("@Category_Code", (object) CategoryCode),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray())) > 0;
  }

  public static DataSet GetRequisitionDetail(string CategoryName, int DomainCode, int SubDomainCode, int ProfileCode, int UserCode, int UserCategory, int JobRole)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (!string.IsNullOrEmpty(CategoryName))
      sqlParameterList.Add(new SqlParameter("@CategoryName", (object) CategoryName));
    if (DomainCode != 0)
      sqlParameterList.Add(new SqlParameter("@DomainCode", (object) DomainCode));
    if (SubDomainCode != 0)
      sqlParameterList.Add(new SqlParameter("@SubDomainCode", (object) SubDomainCode));
    if (ProfileCode != 0)
      sqlParameterList.Add(new SqlParameter("@ProfileCode", (object) ProfileCode));
    if (UserCategory != 0)
      sqlParameterList.Add(new SqlParameter("@CategoryUserTypeCode", (object) UserCategory));
    if (JobRole != 0)
      sqlParameterList.Add(new SqlParameter("@JobRoleCode", (object) JobRole));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectAllCategoryByUser", sqlParameterList.ToArray());
  }

  public static DataSet GetCategoryByCategoryCode(int CategoryCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCategoryByCode", new List<SqlParameter>()
    {
      new SqlParameter("@CategoryCode", (object) CategoryCode)
    }.ToArray());
  }

  public static string UpdateInsertCategory(string CategoryName, int SubDomainCode, int ProfileCode, string CategoryTitle, int FromGrade, int ToGrade, string JobDescription, int BonusType, int Bonuschart, string BonusFarmula, string TAC, string FP, string UFP, string NR, string prefix, bool IsTest, bool IsStudent, bool IsBike, int PositionType, string TestDuration, string TestCodeCSV, string InterviewDuration, string USERIP, int UserCode, int CategoryCode, int CateUserType, int JobRoleCode, string SampleTestPath)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CategoryName", (object) CategoryName));
    sqlParameterList.Add(new SqlParameter("@SubDomainCode", (object) SubDomainCode));
    sqlParameterList.Add(new SqlParameter("@ProfileCode", (object) ProfileCode));
    sqlParameterList.Add(new SqlParameter("@CategoryTitle", (object) CategoryTitle));
    sqlParameterList.Add(new SqlParameter("@FromGrade", (object) FromGrade));
    sqlParameterList.Add(new SqlParameter("@ToGrade", (object) ToGrade));
    sqlParameterList.Add(new SqlParameter("@JobDescription", (object) JobDescription));
    sqlParameterList.Add(new SqlParameter("@BonusType", (object) BonusType));
    if (Bonuschart == 0)
      sqlParameterList.Add(new SqlParameter("@Bonuschart", (object) false));
    else
      sqlParameterList.Add(new SqlParameter("@Bonuschart", (object) true));
    sqlParameterList.Add(new SqlParameter("@BonusFarmula", (object) BonusFarmula));
    sqlParameterList.Add(new SqlParameter("@TAC", (object) TAC));
    sqlParameterList.Add(new SqlParameter("@FP", (object) FP));
    sqlParameterList.Add(new SqlParameter("@UFP", (object) UFP));
    sqlParameterList.Add(new SqlParameter("@NR", (object) NR));
    sqlParameterList.Add(new SqlParameter("@prefix", (object) prefix));
    sqlParameterList.Add(new SqlParameter("@Is_Test", (object) IsTest));
    sqlParameterList.Add(new SqlParameter("@IsStudent", (object) IsStudent));
    sqlParameterList.Add(new SqlParameter("@IsBike", (object) IsBike));
    sqlParameterList.Add(new SqlParameter("@PositionType", (object) PositionType));
    if (IsTest)
    {
      if (TestDuration == "")
        TestDuration = "0";
      sqlParameterList.Add(new SqlParameter("@TestDuration", (object) TestDuration));
      sqlParameterList.Add(new SqlParameter("@SampleTestPath", (object) SampleTestPath));
      sqlParameterList.Add(new SqlParameter("@TestCodeCSV", (object) TestCodeCSV));
    }
    sqlParameterList.Add(new SqlParameter("@InterviewDuration", (object) InterviewDuration));
    sqlParameterList.Add(new SqlParameter("@UpdationIP", (object) USERIP));
    sqlParameterList.Add(new SqlParameter("@UpdatedByUser", (object) UserCode));
    sqlParameterList.Add(new SqlParameter("@CategoryCode", (object) CategoryCode));
    if (CateUserType != 0)
      sqlParameterList.Add(new SqlParameter("@CateUserType", (object) CateUserType));
    if (JobRoleCode != -1 && CateUserType == 5)
      sqlParameterList.Add(new SqlParameter("@JobRoleCode", (object) JobRoleCode));
    return Convert.ToString(SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Insert_Update_Category", sqlParameterList.ToArray()));
  }

  public static DataSet UpdateCandidateID(string CandidateID, int UpdatedBy, string UpdatedIP)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_CandidateID", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateID", (object) CandidateID),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UserIp", (object) UpdatedIP)
    }.ToArray());
  }

  public static bool DeleteProfile(string Profile_Code, int UpdatedBy, string UpdatedIP)
  {
    return Convert.ToInt32(SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_DeleteProfile", new List<SqlParameter>()
    {
      new SqlParameter("@Profile_Code", (object) Profile_Code),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray())) > 0;
  }

  public static bool DeleteProfileParameter(int ProfileParameter_Code, int UpdatedBy, string UpdatedIP)
  {
    return Convert.ToInt32(SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_DeleteProfileParameter", new List<SqlParameter>()
    {
      new SqlParameter("@ProfileParameter_Code", (object) ProfileParameter_Code),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray())) > 0;
  }

  public static string InsertProfile(string ProfileName, string ProfileDesc, string UpdatedIP, int UpdatedByUser, int ProfileCode, string Prefix)
  {
    return SqlHelper.ExecuteScalar(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Insert_Update_Profile", new List<SqlParameter>()
    {
      new SqlParameter("@ProfileName", (object) ProfileName),
      new SqlParameter("@ProfileDesc", (object) ProfileDesc),
      new SqlParameter("@UpdationIP", (object) UpdatedIP),
      new SqlParameter("@UpdatedByUser", (object) UpdatedByUser),
      new SqlParameter("@ProfileCode", (object) ProfileCode),
      new SqlParameter("@Prefix", (object) Prefix)
    }.ToArray()).ToString();
  }

  public static string InsertProfileParameter(int ProfileCode, int ParameterCode, int ParameterValueCode, bool IsMandatory, int UpdatedBy, string UpdatedIP)
  {
    return SqlHelper.ExecuteScalar(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_InsertProfileParameter", new List<SqlParameter>()
    {
      new SqlParameter("@Profile_Code", (object) ProfileCode),
      new SqlParameter("@Parameter_Code", (object) ParameterCode),
      new SqlParameter("@ParameterValue_Code", (object) ParameterValueCode),
      new SqlParameter("@Is_Mandatory", (object) IsMandatory),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray()).ToString();
  }

  public static string InsertProfileParameterScore(int ProfileCode, int UpdatedBy, string UpdatedIP)
  {
    return SqlHelper.ExecuteScalar(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_InsertProfileParameterScore", new List<SqlParameter>()
    {
      new SqlParameter("@Profile_Code", (object) ProfileCode),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray()).ToString();
  }

  public static DataSet GetProfileParameterByCode(int ProfileCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileParameterByCode", new List<SqlParameter>()
    {
      new SqlParameter("@Profile_Code", (object) ProfileCode)
    }.ToArray());
  }

  public static DataSet GetProfileByCode(int ProfileCode)
  {
    DataSet dataSet = (DataSet) null;
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@ProfileCode", (object) ProfileCode));
    try
    {
      return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileByCode", sqlParameterList.ToArray());
    }
    catch (Exception ex)
    {
    }
    return dataSet;
  }

  public static DataSet GetProfileCandidateDetail(int ProfileCode, int RequisitionCode, int Status, int CandidateCode, int UserCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (ProfileCode != 0)
      sqlParameterList.Add(new SqlParameter("@Profile_Code", (object) ProfileCode));
    if (RequisitionCode != 0)
      sqlParameterList.Add(new SqlParameter("@Requisition_Code", (object) RequisitionCode));
    if (Status != 0)
      sqlParameterList.Add(new SqlParameter("@Type", (object) Status));
    sqlParameterList.Add(new SqlParameter("@Candidate_Code", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectProfileCandidateDetail", sqlParameterList.ToArray());
  }

  public static DataSet GetUnmappedCandidate(string CandidateName, string CandidateEmail, string CandidateNIC, string CandidatePhone, int CityCode, string SkillCSV)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (!string.IsNullOrEmpty(CandidateName))
      sqlParameterList.Add(new SqlParameter("@CandidateName", (object) CandidateName));
    if (!string.IsNullOrEmpty(CandidateEmail))
      sqlParameterList.Add(new SqlParameter("@CandidateEmail", (object) CandidateEmail));
    if (!string.IsNullOrEmpty(CandidateNIC))
      sqlParameterList.Add(new SqlParameter("@CandidateNIC", (object) CandidateNIC));
    if (!string.IsNullOrEmpty(CandidatePhone))
      sqlParameterList.Add(new SqlParameter("@CandidatePhone", (object) CandidatePhone));
    if (CityCode != 0)
      sqlParameterList.Add(new SqlParameter("@CityCode", (object) CityCode));
    if (SkillCSV != string.Empty)
      sqlParameterList.Add(new SqlParameter("@KeywordCodeCSV", (object) SkillCSV));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectNonMappedCandidate", sqlParameterList.ToArray());
  }

  public static DataSet GetProfilePriority()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_SelectProfileWithPriority", new List<SqlParameter>().ToArray());
  }

  public static void UpdateProfilePriority(int ProfileCode, int priority)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_ProfilePriority", new List<SqlParameter>()
    {
      new SqlParameter("@ProfileCode", (object) ProfileCode),
      new SqlParameter("@priority", (object) priority)
    }.ToArray());
  }

  public static void UpdateRequisitionPriority(int RequisitionCode, string priority, string UpdationIP, int UpdatedBy)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Update_RequisitionPriority", new List<SqlParameter>()
    {
      new SqlParameter("@RequisitionCode", (object) RequisitionCode),
      new SqlParameter("@priority", (object) priority),
      new SqlParameter("@UpdationIP", (object) UpdationIP),
      new SqlParameter("@UpdatedByUser", (object) UpdatedBy)
    }.ToArray());
  }

  public static void InsertUserOfferComments(int CandidateCode, int UserCode, string Comments, int LifeCycleStatus, int GradeCode, int UpdatedBy, string UpdatedIP)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    sqlParameterList.Add(new SqlParameter("@Comments", (object) Comments));
    sqlParameterList.Add(new SqlParameter("@LifeCycleStatus", (object) LifeCycleStatus));
    if (GradeCode != -1)
      sqlParameterList.Add(new SqlParameter("@GradeCode", (object) GradeCode));
    sqlParameterList.Add(new SqlParameter("@Updated_By", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@UpdatedIP", (object) UpdatedIP));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Insert_CandidateInterview", sqlParameterList.ToArray());
  }

  public static void UpdateCandidateAvailedSlots(int CandidateCode)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_CandidateSlotIsAvailed", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static void InsertUserInterviewCommentOfferApproval(int CandidateCode, int UserCode, Decimal DemandedSalary, string BankStatementStatus, int Profile, int TeamCode, int BUCode, int UpdatedBy, string UpdatedIP)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    sqlParameterList.Add(new SqlParameter("@Demanded_Salary", (object) DemandedSalary));
    sqlParameterList.Add(new SqlParameter("@BankStatement_Status", (object) BankStatementStatus));
    sqlParameterList.Add(new SqlParameter("@Profile", (object) Profile));
    if (TeamCode != -1)
      sqlParameterList.Add(new SqlParameter("@TeamCode", (object) TeamCode));
    if (BUCode != -1)
      sqlParameterList.Add(new SqlParameter("@BUCode", (object) BUCode));
    sqlParameterList.Add(new SqlParameter("@Updated_By", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@Updated_IP", (object) UpdatedIP));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Insert_CandidateInterviewOfferDetail", sqlParameterList.ToArray());
  }

  public static void InsertUserCommunicationComment(int CandidateCode, int UserCode, string Comments, int LifeCycleStatus, string CommentType, int UpdatedBy, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Insert_UserCommunicationComments", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@UserCode", (object) UserCode),
      new SqlParameter("@Comments", (object) Comments),
      new SqlParameter("@LifeCycleStatus", (object) LifeCycleStatus),
      new SqlParameter("@CommentType", (object) CommentType),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertUserInterviewComment(int CandidateCode, int UserCode, string Comments, int LifeCycleStatus, bool IsPassOrFail, int GradeCode, int DesignationCode, int UpdatedBy, string UpdatedIP)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    sqlParameterList.Add(new SqlParameter("@Comments", (object) Comments));
    sqlParameterList.Add(new SqlParameter("@LifeCycleStatus", (object) LifeCycleStatus));
    sqlParameterList.Add(new SqlParameter("@IsPassOrFail", (object) IsPassOrFail));
    if (GradeCode != -1)
      sqlParameterList.Add(new SqlParameter("@GradeCode", (object) GradeCode));
    if (DesignationCode != -1)
      sqlParameterList.Add(new SqlParameter("@DesignationCode", (object) DesignationCode));
    sqlParameterList.Add(new SqlParameter("@Updated_By", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@Updated_IP", (object) UpdatedIP));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Insert_CandidateInterview", sqlParameterList.ToArray());
  }

  public static DataSet UpdateCandidateLockBitNew(int CandidateCode, int UpdatedBy, string UpdatedIP)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_UpdateSelectedCandidateLockBitNew", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdationIP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertCandidateOfferAudioPath(int CandidateCode, string AudioPath, int UpdatedBy, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_InsertCandidateOfferAudioPath", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@AudioPath", (object) AudioPath),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdatedIP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertUserOfferDeliveredComment(int CandidateCode, int UserCode, string Comments, int LifeCycleStatus, int GradeCode, int UpdatedBy, string UpdatedIP)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    sqlParameterList.Add(new SqlParameter("@Comments", (object) Comments));
    sqlParameterList.Add(new SqlParameter("@LifeCycleStatus", (object) LifeCycleStatus));
    if (GradeCode != -1)
      sqlParameterList.Add(new SqlParameter("@GradeCode", (object) GradeCode));
    sqlParameterList.Add(new SqlParameter("@Updated_By", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@Updated_IP", (object) UpdatedIP));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Insert_CandidateInterview", sqlParameterList.ToArray());
  }

  public static void InsertExpectedDateOFJoining(int CandidateCode, DateTime JoiningDate, int RACode, int GLCode, int TentativeShiftCode, int TeamLeaderCode, int UpdatedBy, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Insert_CandidateDateOfJoining", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@JoiningDate", (object) JoiningDate),
      new SqlParameter("@RACode", (object) RACode),
      new SqlParameter("@GLCode", (object) GLCode),
      new SqlParameter("@TentativeShift_Code", (object) TentativeShiftCode),
      new SqlParameter("@TeamLeaderCode", (object) TeamLeaderCode),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdatedIP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertDocumentToGeneratePDF(int CandidateCode, string CandidateDocumentName, int OfficialLetterCode, string OfferLeagueType)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@CandidateDocumentName", (object) CandidateDocumentName));
    sqlParameterList.Add(new SqlParameter("@OfficialLetter_Code", (object) OfficialLetterCode));
    if (!string.IsNullOrEmpty(OfferLeagueType))
      sqlParameterList.Add(new SqlParameter("@OfferLeagueType", (object) OfferLeagueType));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Insert_CandidateOfficialDocumentForMarkingPDF", sqlParameterList.ToArray());
  }

  public static void UpdateCandidateDesignation(int CandidateCode, int DesignationCode, int GradeCode, int UpdatedBy, string UpdatedIp)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_CandidateDesignations", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@DesignationCode", (object) DesignationCode),
      new SqlParameter("@GradeCode", (object) GradeCode),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdatedIp", (object) UpdatedIp)
    }.ToArray());
  }

  public static void UpdateCandidateJoiningDate(int CandidateCode, DateTime JoiningDate, int UpdatedBy, string UpdatedIp)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_CandidateJoiningDate", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@JoiningDate", (object) JoiningDate),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdatedIp", (object) UpdatedIp)
    }.ToArray());
  }

  public static void UpateCandidateStatusManual(int CandidateCode, int StatusCode, string Comments, int UpdatedBy, string UpdatedIp)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Update_CandidateStatusManual", new List<SqlParameter>()
    {
      new SqlParameter("@Candidate_Code", (object) CandidateCode),
      new SqlParameter("@StatusCode", (object) StatusCode),
      new SqlParameter("@Comments", (object) Comments),
      new SqlParameter("@UpdatedByUser", (object) UpdatedBy),
      new SqlParameter("@UpdationIP", (object) UpdatedIp)
    }.ToArray());
  }

  public static void CreatePortalGenerationReq(int ShiftCode, int CityCode, string CandidateID, int UpdatedBy, string UpdatedIp, int JobRoleCode, string CityName, int TeamLeaderCode, int AssignedUserCode)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_CreatePortalGenerationRequest", new List<SqlParameter>()
    {
      new SqlParameter("@shift_code", (object) ShiftCode),
      new SqlParameter("@city_Code", (object) CityCode),
      new SqlParameter("@Candidate_ID", (object) CandidateID),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updation_IP", (object) UpdatedIp),
      new SqlParameter("@JobRole_Code", (object) JobRoleCode),
      new SqlParameter("@City_Name", (object) CityName),
      new SqlParameter("@TeamLeaderCode", (object) TeamLeaderCode),
      new SqlParameter("@AssignedUser_Code", (object) AssignedUserCode)
    }.ToArray());
  }

  public static void UpdateDocumentDigitalization(int CandidateCode, int DocumentCode, string CandDocCode, string DocumentPath, string CandidateDocumentName, int UpdatedBy, string UpdatedIp)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@Candidate_Code", (object) CandidateCode));
    sqlParameterList.Add(new SqlParameter("@Document_Code", (object) DocumentCode));
    if (CandDocCode != "0" && CandDocCode != "")
      sqlParameterList.Add(new SqlParameter("@CandDoc_Code", (object) CandDocCode));
    sqlParameterList.Add(new SqlParameter("@DocumentPath", (object) DocumentPath));
    sqlParameterList.Add(new SqlParameter("@CandidateDocumentName", (object) CandidateDocumentName));
    sqlParameterList.Add(new SqlParameter("@UpdatedBy", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@UpdatedIp", (object) UpdatedIp));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "insert_Update_CandidateDocumentDigitalization", sqlParameterList.ToArray());
  }

  public static void InsertRegenerateOfficialLetter(int CandidateCode, int OfficialLetterCode, int UpdatedBy, string UpdatedIp)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Insert_ReGenerateOfficialLetter", new List<SqlParameter>()
    {
      new SqlParameter("@Candidate_Code", (object) CandidateCode),
      new SqlParameter("@OfficialLetter_Code", (object) OfficialLetterCode),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdationIP", (object) UpdatedIp)
    }.ToArray());
  }

  public static void UpdateCandidateInitialPicStatus(int CandidateCode, string Path, int InitialPicStatus)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_CandidateInitialPictatus", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@Path", (object) Path),
      new SqlParameter("@InitialPicStatus", (object) InitialPicStatus)
    }.ToArray());
  }

  public static void UpdatePrimaryInformation(int CandidateCode, string Email, string Contact, int UpdatedBy, string UpdatedIP)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    if (!string.IsNullOrEmpty(Email))
      sqlParameterList.Add(new SqlParameter("@Email", (object) Email));
    if (!string.IsNullOrEmpty(Contact))
      sqlParameterList.Add(new SqlParameter("@Contact", (object) Contact));
    sqlParameterList.Add(new SqlParameter("@UpdatedBy", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@UpdatedIP", (object) UpdatedIP));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_UpdatePrimaryInformation", sqlParameterList.ToArray());
  }

  public static DataSet GetCandidateOptionForPortal()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_SelectCandidateOptionsForPortal", new List<SqlParameter>().ToArray());
  }

  public static DataSet GetCandidateHistory(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Select_Candidatehistory", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetCandidateDetail(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCandidateDetailNew", new List<SqlParameter>()
    {
      new SqlParameter("@Candidate_Code", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet SelectIDByRefNo(int RefNo)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "xrec_Select_etIDByRefNo", new List<SqlParameter>()
    {
      new SqlParameter("@RefNo", (object) RefNo)
    }.ToArray());
  }

  public static string UpdateDocumentStatus(int CandidateCode, int DocumentStatusCode, int DaysCount, string StatusComment, bool IsSupportiveDocument, bool IsOriginalSeen, bool IsObjection, string ObjectionComment, bool IsMedicalPass, int UpdatedBy, string UpdatedIP)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandDoc_Code", (object) CandidateCode));
    if (DocumentStatusCode == 0)
      sqlParameterList.Add(new SqlParameter("@DocumentStatus_Code", (object) DocumentStatusCode));
    else if (DocumentStatusCode != 0)
    {
      sqlParameterList.Add(new SqlParameter("@DocumentStatus_Code", (object) DocumentStatusCode));
      sqlParameterList.Add(new SqlParameter("@Days_Count", (object) DaysCount));
      sqlParameterList.Add(new SqlParameter("@Status_Comments", (object) StatusComment));
      sqlParameterList.Add(new SqlParameter("@Is_SupportiveDocument", (object) IsSupportiveDocument));
    }
    sqlParameterList.Add(new SqlParameter("@Is_OriginalSeen", (object) IsOriginalSeen));
    sqlParameterList.Add(new SqlParameter("@Is_Objection", (object) IsObjection));
    if (IsObjection)
      sqlParameterList.Add(new SqlParameter("@Objection_Comments", (object) ObjectionComment));
    sqlParameterList.Add(new SqlParameter("@Is_MedicalPass", (object) IsMedicalPass));
    sqlParameterList.Add(new SqlParameter("@Updated_By", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@Updated_IP", (object) UpdatedIP));
    return SqlHelper.ExecuteScalar(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_UpdateDocumentStatus", sqlParameterList.ToArray()).ToString();
  }

  public static DataSet GetCandidateDocumentOtBeUploaded(int CandidateCode, int ReferenceCode, int ProgramCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCandidateDocumentstoBeUploaded", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode),
      new SqlParameter("@ReferenceCode", (object) ReferenceCode),
      new SqlParameter("@ProgramCode", (object) ProgramCode)
    }.ToArray());
  }

  public static DataSet GetCandidateDocument(int CandidateCode, int? ProgramCode, int DocumentTypeCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CandidateCode", (object) CandidateCode));
    int? nullable = ProgramCode;
    if ((nullable.GetValueOrDefault() != -1 ? 1 : (!nullable.HasValue ? 1 : 0)) != 0)
      sqlParameterList.Add(new SqlParameter("@ProgramCode", (object) ProgramCode));
    sqlParameterList.Add(new SqlParameter("@DocumentTypeCode", (object) DocumentTypeCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCandidateDocument", sqlParameterList.ToArray());
  }

  public static DataSet GetDocumentType(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectDocumentTypes", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetCandidateAllDocument(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCandidateAllDocument", new List<SqlParameter>()
    {
      new SqlParameter("@Candidate_Code", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet SelectCandidateAndProfileByCPMCode(string CPMCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Select_CandidateAndProfileByCPMCode", new List<SqlParameter>()
    {
      new SqlParameter("@CPMCode", (object) CPMCode)
    }.ToArray());
  }

  public static DataSet GetEmployee(int DepartmentCode, string SloteDate, int StartTime, int EndTime)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Select_OGEmployees", new List<SqlParameter>()
    {
      new SqlParameter("@DepartmentCode", (object) DepartmentCode),
      new SqlParameter("@SloteDate", (object) SloteDate),
      new SqlParameter("@StartTime", (object) StartTime),
      new SqlParameter("@EndTime", (object) EndTime)
    }.ToArray());
  }

  public static DataSet GetAvailableSlotByTestDateRange(int VenueCode, string SlotDate, string SlotEndDate, int TestDuration, string StartTimeM)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@VenueCode", (object) VenueCode));
    sqlParameterList.Add(new SqlParameter("@SlotDate", (object) SlotDate));
    sqlParameterList.Add(new SqlParameter("@SlotEndDate", (object) SlotEndDate));
    sqlParameterList.Add(new SqlParameter("@TestDuration", (object) TestDuration));
    if (!string.IsNullOrEmpty(StartTimeM))
      sqlParameterList.Add(new SqlParameter("@StartTimeM", (object) StartTimeM));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_AvailableSLotsByDateRangeTest", sqlParameterList.ToArray());
  }

  public static DataSet GetVenueByScheduleMedium(int statusCode, int mediumtype)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_VenueBySchduleMediumType", new List<SqlParameter>()
    {
      new SqlParameter("@statusCode", (object) statusCode),
      new SqlParameter("@mediumtype", (object) mediumtype)
    }.ToArray());
  }

  public static void ReserveCandidateInterviewSlot(int CandidateId, string CandidateSlotId, string StartTime, string Endtime, int StatusCode, int UpdatedBy, string UpdatedIp, string EmployeeCode, DateTime SlotDate, int SlotStatusCode, int RequisitionCode, int VenueCode, string SeatNumber)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Reserve_CadidateSlotInterview", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateId", (object) CandidateId),
      new SqlParameter("@CandidateSlotId", (object) CandidateSlotId),
      new SqlParameter("@StartTime", (object) StartTime),
      new SqlParameter("@Endtime", (object) Endtime),
      new SqlParameter("@StatusCode", (object) StatusCode),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdatedIp", (object) UpdatedIp),
      new SqlParameter("@EmployeeCode", (object) EmployeeCode),
      new SqlParameter("@SlotDate", (object) SlotDate),
      new SqlParameter("@SlotStatusCode", (object) SlotStatusCode),
      new SqlParameter("@RequisitionCode", (object) RequisitionCode),
      new SqlParameter("@VenueCode", (object) VenueCode),
      new SqlParameter("@SeatNumber", (object) SeatNumber)
    }.ToArray());
  }

  public static void ReserveCandidateTestSlot(int CandidateId, string CandidateSlotId, string StartTime, string Endtime, int StatusCode, int UpdatedBy, string UpdatedIp, string EmployeeCode, DateTime SlotDate, int SlotStatusCode, int RequisitionCode, int VenueCode, string SeatNumber)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Reserve_CadidateSlotTest", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateId", (object) CandidateId),
      new SqlParameter("@CandidateSlotId", (object) CandidateSlotId),
      new SqlParameter("@StartTime", (object) StartTime),
      new SqlParameter("@Endtime", (object) Endtime),
      new SqlParameter("@StatusCode", (object) StatusCode),
      new SqlParameter("@UpdatedBy", (object) UpdatedBy),
      new SqlParameter("@UpdatedIp", (object) UpdatedIp),
      new SqlParameter("@EmployeeCode", (object) EmployeeCode),
      new SqlParameter("@SlotDate", (object) SlotDate),
      new SqlParameter("@SlotStatusCode", (object) SlotStatusCode),
      new SqlParameter("@RequisitionCode", (object) RequisitionCode),
      new SqlParameter("@VenueCode", (object) VenueCode),
      new SqlParameter("@SeatNumber", (object) SeatNumber)
    }.ToArray());
  }

  public static void InsertOfferApprovalStatusHistoryComment(int CandidateCode, string Comments, int UpdatedBy, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_OfferApprovalStatusHistoryComments", new List<SqlParameter>()
    {
      new SqlParameter("@Candidate_Code", (object) CandidateCode),
      new SqlParameter("@Comments", (object) Comments),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void UpdateOfferApprovalStatus(int CandidateCode, int OfferApprovalCode, int UserTypeCode, int UpdatedBy, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_UpdateOfferApprovalStatus", new List<SqlParameter>()
    {
      new SqlParameter("@Candidate_Code", (object) CandidateCode),
      new SqlParameter("@OfferApproval_Code", (object) OfferApprovalCode),
      new SqlParameter("@UserTypeCode", (object) UserTypeCode),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static DataSet GetUserTypeByUser(int UserCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectUserTypeByUser", new List<SqlParameter>()
    {
      new SqlParameter("@UserCode", (object) UserCode)
    }.ToArray());
  }

  public static DataSet OfferApprovalGetDepartment(int UserCode, int OfferApprovalStatusCode, int IsSupportStaff)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "OfferApprovalGetDepartment_New", new List<SqlParameter>()
    {
      new SqlParameter("@UserCode", (object) UserCode),
      new SqlParameter("@OfferApprovalStatus_Code", (object) OfferApprovalStatusCode),
      new SqlParameter("@Is_SupportStaff", (object) IsSupportStaff)
    }.ToArray());
  }

  public static DataSet GetCandidateEducationDetailForOfferApprovalDetail(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCandidateEducationDetailsForOfferApprovalDeatils", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetCandidateExperienceForOfferApprovalDetail(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_SelectCandidateExperienxeListForOfferApprovalDeatils", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetCandidateEducationForOfferApproval(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectCandidateEducationDetailsForOfferApproval", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetCandidateExperienceForOfferApproval(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_SelectCandidateExperienxeListForOfferApproval", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetCandidateFamilyForOfferApproval(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_SelectCandidateFamilyDetailsForOfferApproval", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetOfferApprovalStatusHistory(int CandidateCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Select_OfferApprovalStatusHistory", new List<SqlParameter>()
    {
      new SqlParameter("@CandidateCode", (object) CandidateCode)
    }.ToArray());
  }

  public static DataSet GetDepartmentWiseCandidateForOfferApproval(int DomainCode, int OfferApprovalStatusCode)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "OfferApprovalGetDepartmentWiseCandidate", new List<SqlParameter>()
    {
      new SqlParameter("@DomainCode", (object) DomainCode),
      new SqlParameter("@OfferApprovalStatus_Code", (object) OfferApprovalStatusCode)
    }.ToArray());
  }

  public static DataSet GetCompanyNotMapped(string Company)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_CompanyNotMapped", new List<SqlParameter>()
    {
      new SqlParameter("@Company", (object) Company)
    }.ToArray());
  }

  public static DataSet GetCompanyMapped()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_CompanyMapped", new List<SqlParameter>().ToArray());
  }

  public static void UpdateCompanyMapping(int CompanyCode, string UnMappedCompanyCode, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Update_CompanyMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Company_Code", (object) CompanyCode),
      new SqlParameter("@UnMappedCompany_Code", (object) UnMappedCompanyCode),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertCompanyMapping(string CompanyName, string LogoPath, string UpdatedIP, int UpdatedBy)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_CompanyMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Company_Name", (object) CompanyName),
      new SqlParameter("@LogoPath", (object) LogoPath),
      new SqlParameter("@Updated_IP", (object) UpdatedIP),
      new SqlParameter("@Updated_By", (object) UpdatedBy)
    }.ToArray());
  }

  public static DataSet GetInstituteNotMapped(string InstitueName)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_InstituteNotMapped", new List<SqlParameter>()
    {
      new SqlParameter("@Institute", (object) InstitueName)
    }.ToArray());
  }

  public static DataSet GetMappedInstitute()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_InstituteMapped", new List<SqlParameter>().ToArray());
  }

  public static void UpdateInstituteMapping(int InstituteCode, string UnMappedInstituteCode, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Update_InstituteMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Institute_Code", (object) InstituteCode),
      new SqlParameter("@UnMappedInstitute_Code", (object) UnMappedInstituteCode),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertInstituteMapping(string InstituteName, string LogoPath, string UpdatedIP, int UpdatedBy)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_InstituteMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Institute_Name", (object) InstituteName),
      new SqlParameter("@LogoPath", (object) LogoPath),
      new SqlParameter("@Updated_IP", (object) UpdatedIP),
      new SqlParameter("@Updated_By", (object) UpdatedBy)
    }.ToArray());
  }

  public static DataSet GetUnmappedSkills(string SkillName)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_SkillsNotMapped", new List<SqlParameter>()
    {
      new SqlParameter("@SkillName", (object) SkillName)
    }.ToArray());
  }

  public static DataSet GetMappedSkills()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_SkillMapped", new List<SqlParameter>().ToArray());
  }

  public static void UpdateSkillMapping(int SkillCode, string UnMappedSkillCode, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Update_SkillMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Skill_Code", (object) SkillCode),
      new SqlParameter("@UnMappedSkill_Code", (object) UnMappedSkillCode),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertSkillMapping(string Skill, string UpdatedIP, int UpdatedBy)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_SkillMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Skill", (object) Skill),
      new SqlParameter("@Updated_IP", (object) UpdatedIP),
      new SqlParameter("@Updated_By", (object) UpdatedBy)
    }.ToArray());
  }

  public static DataSet GetUnmappedMajors(string MajorName)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_MajorNotMapped", new List<SqlParameter>()
    {
      new SqlParameter("@MajorName", (object) MajorName)
    }.ToArray());
  }

  public static DataSet GetMappedMajors()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_MajorMapped", new List<SqlParameter>().ToArray());
  }

  public static void UpdateMajorsMapping(int MajorCode, string UnMappedMajorCode, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Update_MajorMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Major_Code", (object) MajorCode),
      new SqlParameter("@UnMappedMajor_Code", (object) UnMappedMajorCode),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertMajorsMapping(string Major, string UpdatedIP, int UpdatedBy)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_MajorMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Major", (object) Major),
      new SqlParameter("@Updated_IP", (object) UpdatedIP),
      new SqlParameter("@Updated_By", (object) UpdatedBy)
    }.ToArray());
  }

  public static DataSet GetUnmappedDesignation(string Designation)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_JobtitleNotMapped", new List<SqlParameter>()
    {
      new SqlParameter("@Designation", (object) Designation)
    }.ToArray());
  }

  public static DataSet GetMappedDesignation()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_JobtitleMapped", new List<SqlParameter>().ToArray());
  }

  public static void UpdateDesignationMapping(int JobTitleCode, string UnMappedJobTitleCode, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Update_MajorMapping", new List<SqlParameter>()
    {
      new SqlParameter("@JobTitle_Code", (object) JobTitleCode),
      new SqlParameter("@UnMappedJobTitle_Code", (object) UnMappedJobTitleCode),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertDesignationMapping(string JobTitle, string UpdatedIP, int UpdatedBy)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_MajorMapping", new List<SqlParameter>()
    {
      new SqlParameter("@JobTitle", (object) JobTitle),
      new SqlParameter("@Updated_IP", (object) UpdatedIP),
      new SqlParameter("@Updated_By", (object) UpdatedBy)
    }.ToArray());
  }

  public static DataSet GetUnmappedDegree(string Degree)
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_DegreeNotMapped", new List<SqlParameter>()
    {
      new SqlParameter("@Degree", (object) Degree)
    }.ToArray());
  }

  public static DataSet GetMappedDegree()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_DegreeMapped", new List<SqlParameter>().ToArray());
  }

  public static void UpdateDegreeMapping(int DegreeCode, string UnMappedDegreeCode, string UpdatedIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Update_DegreeMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Degree_Code", (object) DegreeCode),
      new SqlParameter("@UnMappedDegree_Code", (object) UnMappedDegreeCode),
      new SqlParameter("@Updated_IP", (object) UpdatedIP)
    }.ToArray());
  }

  public static void InsertDegreeMapping(string Degree, string UpdatedIP, int UpdatedBy, int ProgramCode)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Insert_degreeMapping", new List<SqlParameter>()
    {
      new SqlParameter("@Degree", (object) Degree),
      new SqlParameter("@Updated_IP", (object) UpdatedIP),
      new SqlParameter("@Updated_By", (object) UpdatedBy),
      new SqlParameter("@ProgramCode", (object) ProgramCode)
    }.ToArray());
  }

  public static DataSet GetUserReferralDetail(int DepatmentID, string userID, string UserName, int UserCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (DepatmentID != -1)
      sqlParameterList.Add(new SqlParameter("@DepatmentID", (object) DepatmentID));
    if (!string.IsNullOrEmpty(userID))
      sqlParameterList.Add(new SqlParameter("@userID", (object) userID));
    if (!string.IsNullOrEmpty(UserName))
      sqlParameterList.Add(new SqlParameter("@UserName", (object) UserName));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Select_UserReferralURl", sqlParameterList.ToArray());
  }

  public static DataSet GetReferralCandidates(string CandidateName, string ReferenceNo, string ReferredBy, DateTime DateFrom, DateTime DateTo, int DeptID, int CityCode, int UserCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (!string.IsNullOrEmpty(CandidateName))
      sqlParameterList.Add(new SqlParameter("@CandidateName", (object) CandidateName));
    if (!string.IsNullOrEmpty(ReferenceNo))
      sqlParameterList.Add(new SqlParameter("@ReferenceNo", (object) ReferenceNo));
    if (ReferredBy != "-1")
      sqlParameterList.Add(new SqlParameter("@ReferredBy", (object) ReferredBy));
    sqlParameterList.Add(new SqlParameter("@DateFrom", (object) DateFrom));
    sqlParameterList.Add(new SqlParameter("@DateTo", (object) DateTo));
    if (DeptID != -1)
      sqlParameterList.Add(new SqlParameter("@DeptID", (object) DeptID));
    if (CityCode != -1)
      sqlParameterList.Add(new SqlParameter("@CityCode", (object) CityCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_ReferredCandidates", sqlParameterList.ToArray());
  }

  public static DataSet GetUserID()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRex_Select_User", new List<SqlParameter>().ToArray());
  }

  public static void UpdateReferralURL(int UserID, string ReferralURL)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "Xrec_Update_ReferralURL", new List<SqlParameter>()
    {
      new SqlParameter("@UserID", (object) UserID),
      new SqlParameter("@ReferralURL", (object) ReferralURL)
    }.ToArray());
  }

  public static DataSet CategoryListByUserCode(int DomainCode, int CategoryCode, int UserCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (CategoryCode != -1)
      sqlParameterList.Add(new SqlParameter("@CategoryCode", (object) CategoryCode));
    if (DomainCode != -1)
      sqlParameterList.Add(new SqlParameter("@DomainCode", (object) DomainCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectAllCategoryListByUserGroup", sqlParameterList.ToArray());
  }

  public static DataSet GetCategoriesOnDepartment(int DomainCode, int CategoryCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (CategoryCode != -1)
      sqlParameterList.Add(new SqlParameter("@CategoryCode", (object) CategoryCode));
    if (DomainCode != -1)
      sqlParameterList.Add(new SqlParameter("@DomainCode", (object) DomainCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectAllCategoriesOnDepartment", sqlParameterList.ToArray());
  }

  public static DataSet GetCategorySpecialist()
  {
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_Select_CategorySpecialist", new List<SqlParameter>().ToArray());
  }

  public static void UpdateRequisitionStatus(int CategoryCode, int RequisitionCode, int UserCode, string UserTypeCode, int RequisitionStatusCode, int UpdatedBy, string UpdatedIP, string CategorySpecialist)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    sqlParameterList.Add(new SqlParameter("@CategoryCode", (object) CategoryCode));
    sqlParameterList.Add(new SqlParameter("@RequisitionCode", (object) RequisitionCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    sqlParameterList.Add(new SqlParameter("@UserTypeCode", (object) UserTypeCode));
    sqlParameterList.Add(new SqlParameter("@RequisitionStatusCode", (object) RequisitionStatusCode));
    sqlParameterList.Add(new SqlParameter("@Updated_By", (object) UpdatedBy));
    sqlParameterList.Add(new SqlParameter("@Updated_IP", (object) UpdatedIP));
    if (CategorySpecialist != "-1")
      sqlParameterList.Add(new SqlParameter("@CategorySpecialist", (object) CategorySpecialist));
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "UPdate_RequisitonStatusWise", sqlParameterList.ToArray());
  }

  public static void InsertRequisition(int CategoryCode, int City, int NoOfCandidate, int UpdatedByUser, string UpdationIP)
  {
    SqlHelper.ExecuteNonQuery(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Insert_Requisition", new List<SqlParameter>()
    {
      new SqlParameter("@CategoryCode", (object) CategoryCode),
      new SqlParameter("@City", (object) City),
      new SqlParameter("@NoOfCandidate", (object) NoOfCandidate),
      new SqlParameter("@UpdatedByUser", (object) UpdatedByUser),
      new SqlParameter("@UpdationIP", (object) UpdationIP)
    }.ToArray());
  }

  public static string UpdateRequisitionStatus(string RequisitionName, int RequisitionCode, int UpdatedBy, string UpdatedIP)
  {
    return SqlHelper.ExecuteScalar(AppSettings.ConnectionString, CommandType.StoredProcedure, "XREC_Insert_Update_RequisitionStatus", new List<SqlParameter>()
    {
      new SqlParameter("@RequisitionName", (object) RequisitionName),
      new SqlParameter("@RequisitionCode", (object) RequisitionCode),
      new SqlParameter("@UpdatedByUser", (object) UpdatedBy),
      new SqlParameter("@UpdationIP", (object) UpdatedIP)
    }.ToArray()).ToString();
  }

  public static DataSet GetAllRequisition(string RequisitionName, int DomainCode, int SubDomainCode, int CategoryCode, int CityCode, int UserCode, int CategorySpecialistCode)
  {
    List<SqlParameter> sqlParameterList = new List<SqlParameter>();
    if (!string.IsNullOrEmpty(RequisitionName))
      sqlParameterList.Add(new SqlParameter("@RequisitionName", (object) RequisitionName));
    if (DomainCode != 0)
      sqlParameterList.Add(new SqlParameter("@DomainCode", (object) DomainCode));
    if (SubDomainCode != 0)
      sqlParameterList.Add(new SqlParameter("@SubDomainCode", (object) SubDomainCode));
    if (CategoryCode != 0)
      sqlParameterList.Add(new SqlParameter("@CategoryCode", (object) CategoryCode));
    if (CityCode != 0)
      sqlParameterList.Add(new SqlParameter("@CityCode", (object) CityCode));
    if (CategorySpecialistCode != -1)
      sqlParameterList.Add(new SqlParameter("@CategorySpecialistCode", (object) CategorySpecialistCode));
    sqlParameterList.Add(new SqlParameter("@UserCode", (object) UserCode));
    return SqlHelper.ExecuteDataset(AppSettings.ConnectionString, CommandType.StoredProcedure, "XRec_SelectAllRequisition", sqlParameterList.ToArray());
  }
}
