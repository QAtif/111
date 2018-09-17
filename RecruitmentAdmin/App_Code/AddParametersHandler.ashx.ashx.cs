using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
//using HelpDeskReporting.BusinessLogic;

namespace XRecruitmentAdmin.Website.Handlers
{
    /// <summary>
    /// Summary description for SearchCategoryHandler
    /// </summary>
    public class AddParametersHandler : IHttpHandler
    {
        #region ..:: Properties ::..

        #endregion
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string errorMessage = string.Empty;
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecruitmentAdminConn"].ConnectionString);
                DataTable dt = new DataTable();
                string ID = context.Request.QueryString["ID"];

                if (connection.State != ConnectionState.Open) connection.Open();
                if (ID == "1")
                {//Skill
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectFilteredSkillNew", connection);
                    sqlCommand.Parameters.Add("@SearchText", context.Request.Params["q"].ToString());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    if (dt != null)
                        PrintData(dt, context);
                }
                else
                    if (ID == "2")
                    {//Degree
                        SqlCommand sqlCommand = new SqlCommand("dbo.Xrec_SelectDegreeNew", connection);
                        sqlCommand.Parameters.Add("@SearchText", context.Request.Params["q"].ToString());
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                        if (dt != null)
                            PrintData(dt, context);
                    }
                    else
                        if (ID == "3")
                        {//Company
                            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectCompanynew", connection);
                            sqlCommand.Parameters.Add("@SearchText", context.Request.Params["q"].ToString());
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                            adapter.Fill(dt);
                            if (dt != null)
                                PrintData(dt, context);
                        }
                        else
                            if (ID == "4")
                            {//Majors
                                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectMajorForSearchNew", connection);
                                sqlCommand.Parameters.Add("@SearchText", context.Request.Params["q"].ToString());
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                adapter.Fill(dt);
                                if (dt != null)
                                    PrintData(dt, context);
                            }
                            else
                                if (ID == "5")
                                {//Institute
                                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectInstituteForSearchNew", connection);
                                    sqlCommand.Parameters.Add("@SearchText", context.Request.Params["q"].ToString());
                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                    adapter.Fill(dt);
                                    if (dt != null)
                                        PrintData(dt, context);
                                }
                //                else
                //                    if (ID == "6")
                //                    {//University
                //                        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectUniversityAutoComplete", connection);
                //                        sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                //                        sqlCommand.CommandType = CommandType.StoredProcedure;
                //                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                //                        adapter.Fill(dt);
                //                        if (dt != null)
                //                            PrintData(dt, context);
                //                    }
                //                    else
                //                        if (ID == "7")
                //                        {//University
                //                            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectSkillsAutoComplete", connection);
                //                            sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                //                            sqlCommand.CommandType = CommandType.StoredProcedure;
                //                            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                //                            adapter.Fill(dt);
                //                            if (dt != null)
                //                                PrintData(dt, context);
                //                        }
                //                        else
                //                            if (ID == "8")
                //                            {//University
                //                                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectCompanyAutoComplete", connection);
                //                                sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                //                                sqlCommand.CommandType = CommandType.StoredProcedure;
                //                                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                //                                adapter.Fill(dt);
                //                                if (dt != null)
                //                                    PrintData(dt, context);
                //                            }
                //                            else
                //                                if (ID == "9")
                //                                {//University
                //                                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectDesignationAutoComplete", connection);
                //                                    sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                //                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                //                                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                //                                    adapter.Fill(dt);
                //                                    if (dt != null)
                //                                        PrintData(dt, context);
                //                                }


            }
            catch (Exception ex)
            {
                List<Item1> collectionItem = new List<Item1>();
                string JSONResult = GetJSONString(collectionItem, "");
                context.Response.Write(JSONResult);
            }

        }
        public void PrintData(DataTable dt, HttpContext context)
        {
            List<Item1> collectionItem = new List<Item1>();
            Item1 subCategory;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    subCategory = new Item1();
                    subCategory.Id = dr["Id"].ToString();
                    subCategory.Name = dr["Name"].ToString();
                    //subCategory.SubCategoryName = dr["NAME"].ToString();
                    collectionItem.Add(subCategory);
                }
            }


            string JSONResult = GetJSONString(collectionItem, context.Request.Params["q"].ToString());
            context.Response.Write(JSONResult);
        }
        string GetJSONString(List<Item1> data, string SearchText)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Item1 dr in data)
            {

                if (sb.Length != 0)
                    sb.Append(",");
                sb.Append("{");
                sb.Append(string.Format("\"{0}\":\"{1}\"", "id", dr.Id));
                sb.Append(",");
                sb.Append(string.Format("\"{0}\":\"{1}\"", "name", dr.Name));
                sb.Append("}");
            }

            sb.Insert(0, "[");
            sb.Append("]");

            return sb.ToString();
        }
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }


}

public class Item1
{
    public string Id;
    public string Name;
    // public string SubCategoryName;
}