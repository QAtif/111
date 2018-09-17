using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;
using ErrorLog;

public partial class changepassword : Page//CustomBaseClass
{
    #region Page Variables

    int CandidateCode = 0;
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string DomainAddress = ConfigurationManager.AppSettings["DomainAddress"].ToString();
    DataSet ds = new DataSet();
    SecureQueryString oSecureString = null;
    StringCollection parameters = new StringCollection();

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CC"] != null)
            CandidateCode = Convert.ToInt32(Session["CC"]);
        else
            ScriptManager.RegisterStartupScript((Page)this, GetType(), Guid.NewGuid().ToString(), "RefreshParent()", true);
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;
            DataSet dataSet1 = new DataSet();
            DataSet dataSet2 = ChangeCandidatePassword();
            if (dataSet2 == null || dataSet2.Tables == null || dataSet2.Tables[0].Rows.Count <= 0)
                return;
            if (dataSet2.Tables[0].Rows[0]["Result"].ToString() != "0")
                lblError.Text = dataSet2.Tables[0].Rows[0]["Msg"].ToString();
            else
                lblError.Text = dataSet2.Tables[0].Rows[0]["Msg"].ToString();
        }
        catch (Exception ex)
        {
            LogError.Write(LogError.AppType.Candidate, "btnChangePassword_Click", ex, CandidateCode.ToString());
        }
    }
    #endregion

    #region Page Methods

    public DataSet ChangeCandidatePassword()
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            try
            {
                using (SqlCommand selectCommand = new SqlCommand("XRec_UpdateCandidatePassword", connection))
                {
                    oSecureString = new SecureQueryString();
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(new SqlParameter("@Currentpassword", oSecureString.encrypt(txtCurrentPassword.Text.Trim())));
                    selectCommand.Parameters.Add(new SqlParameter("@NewPassword", oSecureString.encrypt(txtNewPassword.Text.Trim())));
                    selectCommand.Parameters.Add(new SqlParameter("@CandidateCode", CandidateCode.ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@UpdatedBy", CandidateCode.ToString()));
                    selectCommand.Parameters.Add(new SqlParameter("@UpdationIP ", Request.UserHostAddress.ToString()));
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                        sqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(LogError.AppType.Candidate, "ChangeCandidatePassword", ex, CandidateCode.ToString());
            }
        }
        return dataSet;
    }

    #endregion
}