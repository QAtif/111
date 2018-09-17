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
    public class SearchCategoryHandler : IHttpHandler
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
                {//Category
                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectCategoriesAutoComplete", connection);
                    sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    if (dt != null)
                        PrintData(dt,context);
                }
                else
                    if (ID == "2")
                    {//City
                        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectCityAutoComplete", connection);
                        sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                        if (dt != null)
                            PrintData(dt, context);
                    }
                    else
                        if (ID == "3")
                        {//Program
                            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectEducationLevelAutoComplete", connection);
                            sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                            adapter.Fill(dt);
                            if (dt != null)
                                PrintData(dt, context);
                        }
                        else
                            if (ID == "4")
                            {//Degree
                                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectDegreeAutoComplete", connection);
                                sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                adapter.Fill(dt);
                                if (dt != null)
                                    PrintData(dt, context);
                            }
                            else
                                if (ID == "5")
                                {//majors
                                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectMajorsAutoComplete", connection);
                                    sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                    adapter.Fill(dt);
                                    if (dt != null)
                                        PrintData(dt, context);
                                }
                                else
                                    if (ID == "6")
                                    {//University
                                        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectUniversityAutoComplete", connection);
                                        sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                        adapter.Fill(dt);
                                        if (dt != null)
                                            PrintData(dt, context);
                                    }
                                    else
                                        if (ID == "7")
                                        {//University
                                            SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectSkillsAutoComplete", connection);
                                            sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                            sqlCommand.CommandType = CommandType.StoredProcedure;
                                            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                            adapter.Fill(dt);
                                            if (dt != null)
                                                PrintData(dt, context);
                                        }
                                        else
                                            if (ID == "8")
                                            {//University
                                                SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectCompanyAutoComplete", connection);
                                                sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                                adapter.Fill(dt);
                                                if (dt != null)
                                                    PrintData(dt, context);
                                            }
                                            else
                                                if (ID == "9")
                                                {//University
                                                    SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectDesignationAutoComplete", connection);
                                                    sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                                                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                                    adapter.Fill(dt);
                                                    if (dt != null)
                                                        PrintData(dt, context);
                                                }
                                                else
                                                    if (ID == "10")
                                                    {//University
                                                        SqlCommand sqlCommand = new SqlCommand("dbo.XRec_SelectRefferalUrlnAutoComplete", connection);
                                                        sqlCommand.Parameters.Add("@Prefix", context.Request.Params["q"].ToString());
                                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                                                        adapter.Fill(dt);
                                                        if (dt != null)
                                                            PrintData(dt, context);
                                                    }
                                               
                
            }
            catch (Exception ex)
            {
                List<Item> collectionItem = new List<Item>();
                string JSONResult = GetJSONString(collectionItem, "");
                context.Response.Write(JSONResult);
            }

        }
        public void PrintData(DataTable dt, HttpContext context)
        {
            List<Item> collectionItem = new List<Item>();
            Item subCategory;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    subCategory = new Item();
                    subCategory.Id = dr["Id"].ToString();
                    subCategory.Name = dr["Name"].ToString();
                    //subCategory.SubCategoryName = dr["NAME"].ToString();
                    collectionItem.Add(subCategory);
                }
            }
          
                
            string JSONResult = GetJSONString(collectionItem, context.Request.Params["q"].ToString());           
            context.Response.Write(JSONResult);
        }

        string GetJSONString(List<Item> data, string SearchText)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Item dr in data)
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

public class Item
{
    public string Id;
    public string Name;
   // public string SubCategoryName;
}