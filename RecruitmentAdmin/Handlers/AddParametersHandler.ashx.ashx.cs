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
        public int categoryID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CategoryID"].ToString()); }
        }
        #endregion


        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string errorMessage = string.Empty;
                string connectionString = ConfigurationManager.ConnectionStrings["helpdeskConnection"].ConnectionString.ToString();


                List<SubCategory> collectionItem = new List<SubCategory>();
                SubCategory subCategory;

              //  BusinessLogicLayer bal = new BusinessLogicLayer(connectionString);

                DataTable dtSubCategory = new DataTable();// bal.GetSubCategoryDefinition(context.Request.Params["q"].ToString(), categoryID, out errorMessage);

                if (errorMessage != "")
                {
                    // Print Error
                }
                else
                {
                    if (dtSubCategory != null && dtSubCategory.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSubCategory.Rows)
                        {
                            subCategory = new SubCategory();
                            subCategory.SubCategoryID = dr["SUBCATEGORYID"].ToString();
                            subCategory.CategoryID = dr["CATEGORYID"].ToString();
                            subCategory.SubCategoryName = dr["NAME"].ToString();
                            collectionItem.Add(subCategory);
                        }
                    }
                }

                string JSONResult = GetJSONString(collectionItem, context.Request.Params["q"].ToString());


                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                context.Response.Write(JSONResult);
            }
            catch (Exception ex)
            {
                List<SubCategory> collectionItem = new List<SubCategory>();
                string JSONResult = GetJSONString(collectionItem, "");
                context.Response.Write(JSONResult);
            }

        }

        string GetJSONString(List<SubCategory> data, string SearchText)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SubCategory dr in data)
            {

                if (sb.Length != 0)
                    sb.Append(",");
                sb.Append("{");
                sb.Append(string.Format("\"{0}\":\"{1}\"", "id", dr.SubCategoryID));
                sb.Append(",");
                sb.Append(string.Format("\"{0}\":\"{1}\"", "CategoryID", dr.CategoryID));
                sb.Append(",");
                sb.Append(string.Format("\"{0}\":\"{1}\"", "name", dr.SubCategoryName));
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

public class SubCategory
{
    public string SubCategoryID;
    public string CategoryID;
    public string SubCategoryName;
}