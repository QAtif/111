using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;


public partial class A2_Candidate_EditCandidateID : CustomBasePage
{
    protected void btnEditCandidateID_Click(object sender, EventArgs e)
    {
        EditCandidateID();
    }

    protected void EditCandidateID()
    {
        DataSet dataSet = AdminClass.UpdateCandidateID(txtbxRefNum.Text, UserCode, Request.UserHostAddress.ToString());
        if (dataSet.Tables[0].Rows.Count <= 0)
            return;
        if (dataSet.Tables[0].Rows[0]["Result"].ToString() == "0")
        {
            lblCandidate.Text = "No Candidate Found";
        }
        else
        {
            lblCandidate.Text = "New Reference number is " + dataSet.Tables[0].Rows[0]["Result"].ToString();
            txtbxRefNum.Text = dataSet.Tables[0].Rows[0]["Result"].ToString();
        }
    }
}