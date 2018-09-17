using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

public partial class Categorylist : System.Web.UI.Page
{
    #region Variables
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["BConnection"].ToString());
    string usercode;
    public string listFilter = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            listFilter = null;
            listFilter = BindName();
            if (!IsPostBack)
            {

                BindData();
            }
            if (Request.Cookies["user%5Fcode"] != null)
            {
                if (Request.Cookies["user%5Fcode"].Value != "")
                    usercode = Request.Cookies["user%5Fcode"].Value;
                else
                    usercode = "0";
            }

            else
                if (Request.Cookies["user_code"] != null)
                {
                    if (Request.Cookies["user_code"].Value != "")
                        usercode = Request.Cookies["user_code"].Value;
                    else
                        usercode = "0";
                }

            if (usercode == "283")
                lnkRefresh.Style.Add("display", "");
            else
                lnkRefresh.Style.Add("display", "none");
            //leftmenu.UserID = usercode;
            Setview(usercode);
            //else
            //{
            //    leftmenu.UserID = "0";
            //    Setview("1");
            //}
            //txtJDName.Text = usercode;
            aaddnew.Attributes.Add("onclick", "openMyModal('AddEditDeptJD.aspx'); return false;");
        }
        catch
        {

        }

    }
    public void OnChangeDept(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            c.Open();
            SqlCommand command = new SqlCommand("select_CatOnDept", c);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dept_code", ddlDept.SelectedValue);
            SqlDataAdapter a = new SqlDataAdapter(command);
            a.Fill(dt);
            c.Close();
            ddlCat.DataSource = dt;
            ddlCat.DataTextField = "cat_desc";
            ddlCat.DataValueField = "cat_code";
            ddlCat.DataBind();
            ddlCat.Items.Insert(0, new ListItem("-- Select Category --", "-1"));
        }
        catch
        {

        }

    }
    protected void rptjdlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlGenericControl DivUpload = (HtmlGenericControl)e.Item.FindControl("DivUpload");
                HtmlInputCheckBox chkCandidate = (HtmlInputCheckBox)e.Item.FindControl("chkCandidate");
                HiddenField hdnCatcode = (HiddenField)e.Item.FindControl("hdnCatcode");
                HiddenField hdnJdK = (HiddenField)e.Item.FindControl("hdnJdK");
                TextBox txtNewreq = (TextBox)e.Item.FindControl("txtNewreq");
                HiddenField hdnnewvalue = (HiddenField)e.Item.FindControl("hdnnewvalue");

                Image Imageupload = (Image)e.Item.FindControl("imgupload");
                Image Imageselect = (Image)e.Item.FindControl("Imageselect");
                FileUpload fuCandidateDocument = (FileUpload)e.Item.FindControl("fuCandidateDocument");
                LinkButton lnkUpload = (LinkButton)e.Item.FindControl("lnkUpload");
                Image imgClose = (Image)e.Item.FindControl("imgClose");
                Image imgDownload = (Image)e.Item.FindControl("imgDownload");
                HiddenField hdnFileUrl = (HiddenField)e.Item.FindControl("hdnFileUrl");
                LinkButton lnkDownload = (LinkButton)e.Item.FindControl("lnkDownload");
                LinkButton lnkDisapprove = (LinkButton)e.Item.FindControl("lnkDisapprove");
                if (hdnFileUrl.Value != "0")
                {
                    imgDownload.Style.Add("display", "");
                    DivUpload.Attributes.Add("onmouseout", "document.getElementById('" + imgClose.ClientID + "').style.display = 'none';");
                    DivUpload.Attributes.Add("onmouseover", "document.getElementById('" + imgClose.ClientID + "').style.display = '';");
                    //  imgClose.Style.Add("display", "");
                    Imageselect.Style.Add("display", "none");
                }
                else
                {
                    imgDownload.Style.Add("display", "none");
                    //  imgClose.Style.Add("display", "none");
                    Imageselect.Style.Add("display", "");
                }



                // lnkUpload.Attributes.Add("onmouseout", "document.getElementById('" + imgClose.ClientID + "').style.display = '';");
                // lnkUpload.Attributes.Add("onmouseover", "document.getElementById('" + imgClose.ClientID + "').style.display = 'none';");

                // chkCandidate.Attributes.Add("onclick", "SetEditable('" + txtNewreq.ClientID + "','" + chkCandidate.ClientID + "')");
                Imageselect.Attributes.Add("onclick", "javascript:clickSelect(" + fuCandidateDocument.ClientID + "," + Imageupload.ClientID + "," + imgClose.ClientID + "," + Imageselect.ClientID + ")");
                imgClose.Attributes.Add("onclick", "javascript:clickclose(" + imgDownload.ClientID + "," + Imageupload.ClientID + "," + imgClose.ClientID + "," + Imageselect.ClientID + ")");
                Imageupload.Attributes.Add("onclick", "javascript:clickupload(" + lnkUpload.ClientID + "," + imgDownload.ClientID + "," + Imageupload.ClientID + "," + imgClose.ClientID + "," + Imageselect.ClientID + ")");
                imgDownload.Attributes.Add("onclick", "javascript:clickDownload(" + lnkDownload.ClientID + ")");
                chkCandidate.Attributes.Add("onclick", "javascript:SetEditable(" + txtNewreq.ClientID + "," + chkCandidate.ClientID + ");");
                txtNewreq.Attributes.Add("onkeyup", "javascript:setvalue(" + txtNewreq.ClientID + "," + hdnnewvalue.ClientID + ");");
                txtNewreq.Attributes.Add("onkeydown", "javascript:return isNumberKey(event);");
                LinkButton lnkapprove = (LinkButton)e.Item.FindControl("lnkapprove");
                HtmlAnchor aeditjd = (HtmlAnchor)e.Item.FindControl("aeditjd");
                HtmlAnchor aUnfilled = (HtmlAnchor)e.Item.FindControl("aUnfilled");
                HiddenField hdnJdcode = (HiddenField)e.Item.FindControl("hdnJdcode");
                // HiddenField hdnunfilledcount = (HiddenField)e.Item.FindControl("hdnunfilledcount");
                string keywords = hdnJdK.Value.ToString().TrimEnd(',');
                HtmlAnchor aAxactSearch = (HtmlAnchor)e.Item.FindControl("aAxactSearch");
                HtmlAnchor aBolSearch = (HtmlAnchor)e.Item.FindControl("aBolSearch");

                if (hdnJdK.Value != "0")
                {
                    usercode = "0";
                    if (Request.Cookies["user%5Fcode"] != null)
                        if (Request.Cookies["user%5Fcode"].Value != "")
                            usercode = Request.Cookies["user%5Fcode"].Value;


                    //aUnfilled.Attributes.Add("href", "http://xwebsrv03:8080/report/Front/MasterSearch.asp?search=Y&jdcode=keyword=" + keywords);
                    //aUnfilled.Style.Add("color", "#0033CC");
                    //aUnfilled.Style.Add("text-decoration", "underline");
                   // string BolURl = "xwebsrv03:8080/report/Front/MasterSearch.asp?Search=Y&jdcode=" + hdnJdcode.Value + "&keyword=" + keywords;
                   // string url = BolURl.Replace("&", "~");
                    aBolSearch.Attributes.Add("href", "http://xwebsrv03:8080/report/Front/MasterSearch.asp?Search=Y&jdcode=" + hdnJdcode.Value + "&keyword=" + keywords);
                    // aBolSearch.Attributes.Add("onclick", "RedirectorBol");
                    aBolSearch.Style.Add("color", "#0033CC");
                    aBolSearch.Style.Add("text-decoration", "underline");

                   // string AxURl = "xwebsrv03:report/Front/MasterSearch.asp?Search=Y&jdcode=" + hdnJdcode.Value + "&keyword=" + keywords;
                   // string Axurl = BolURl.Replace("&", "~");
                    aAxactSearch.Attributes.Add("href", "http://xwebsrv03/report/Front/MasterSearch.asp?Search=Y&jdcode=" + hdnJdcode.Value + "&keyword=" + keywords);
                    aAxactSearch.Attributes.Add("onclick", "RedirectorAxt");
                    aAxactSearch.Style.Add("color", "#0033CC");
                    aAxactSearch.Style.Add("text-decoration", "underline");
                }
                else
                {
                    //aUnfilled.Style.Add("color", "#000000");
                    aAxactSearch.Style.Add("color", "#000000");
                    aBolSearch.Style.Add("color", "#000000");
                }

                aeditjd.Attributes.Add("onclick", "openMyModal('AddEditDeptJD.aspx?type=" + hdnJdcode.Value + "'); return false;");
                if (hdnnewvalue.Value == "0")
                {
                    lnkapprove.Style.Add("display", "none");
                    lnkDisapprove.Style.Add("display", "none");
                }

            }
        }
        catch { }

    }

    protected void rptjdlist_CommandArguments(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "approve")
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                string textBoxValue = ((HiddenField)lb.Parent.FindControl("hdnnewvalue")).Value;

                if (e.CommandArgument != null)
                    ApproveRequisition(e.CommandArgument.ToString(), textBoxValue);
                search();
            }
            if (e.CommandName == "Edit")
            {
                search();
            }
            if (e.CommandName == "Save")
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                HiddenField hdnJdcode = (HiddenField)lb.Parent.FindControl("hdnJdcode");
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)lb.Parent.FindControl("chkCandidate");
                HiddenField hdnnewvalue = (HiddenField)lb.Parent.FindControl("hdnnewvalue");

                if (ckb.Checked == true)
                {

                    UpdateDepJd(hdnnewvalue.Value, hdnJdcode.Value, "Update");

                }
                // LinkButton lb = (LinkButton)e.CommandSource;
                //FileUpload file = (FileUpload)lb.Parent.FindControl("fuCandidateDocument");
                //string filename = file.FileName;
                search();
            }
            if (e.CommandName == "upload")
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                FileUpload hdnJdcode = (FileUpload)lb.Parent.FindControl("fuCandidateDocument");
                string filename = hdnJdcode.FileName;
                string filePath = ConfigurationManager.AppSettings["DocumentsPath"].ToString();

                ConfigurationManager.AppSettings["DocumentsPath"].ToString();
                FileBrowse(hdnJdcode, filePath);
                Updatepic(filename, e.CommandArgument.ToString());




                search();
            }
            if (e.CommandName == "Download")
            {
                string filePath = ConfigurationManager.AppSettings["DocumentsPath"].ToString();
                FileResponse(e.CommandArgument.ToString(), filePath);

            }
            if (e.CommandName == "Disapprove")
            {
                DisApproveRequisition(e.CommandArgument.ToString());
                search();
            }
        }
        catch


        { }

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem rt in rptJDLIst.Items)
            {
                HiddenField hdnJdcode = (HiddenField)rt.FindControl("hdnJdcode");
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)rt.FindControl("chkCandidate");
                TextBox txtNewreq = (TextBox)rt.FindControl("txtNewreq");
                HiddenField hdnnewvalue = (HiddenField)rt.FindControl("hdnnewvalue");

                if (ckb.Checked == true)
                {
                    if (hdnnewvalue.Value != "0" && hdnnewvalue.Value != "")
                        ApproveRequisition(hdnJdcode.Value, hdnnewvalue.Value);

                }
            }
            search();
        }
        catch { }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem rt in rptJDLIst.Items)
            {
                HiddenField hdnJdcode = (HiddenField)rt.FindControl("hdnJdcode");
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)rt.FindControl("chkCandidate");
                TextBox txtNewreq = (TextBox)rt.FindControl("txtNewreq");
                HiddenField hdnnewvalue = (HiddenField)rt.FindControl("hdnnewvalue");

                if (ckb.Checked == true)
                {
                    UpdateDepJd(hdnnewvalue.Value, hdnJdcode.Value, "update");
                }
            }
            search();
        }
        catch { }
    }
    protected void btn_SearchClick(object sender, EventArgs e)
    {
        try
        {
            search();
        }
        catch { }
    }
    protected void lnkRefresh_OnClick(object sender, EventArgs e)
    {
        try
        {
            c.Open();
            SqlCommand command = new SqlCommand("UpdateallJD", c);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            c.Close();
            BindData();
        }
        catch { }
    }
    protected void btnDisapprove_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem rt in rptJDLIst.Items)
            {
                HiddenField hdnJdcode = (HiddenField)rt.FindControl("hdnJdcode");
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)rt.FindControl("chkCandidate");

                if (ckb.Checked == true)
                {

                    if (hdnJdcode.Value != "")
                        DisApproveRequisition(hdnJdcode.Value);

                }
            }
            search();
        }
        catch { }
    }

    #region methods
    private string BindName()
    {
        DataTable dt = null;
        c.Open();
        SqlCommand cmd = new SqlCommand("dbo.SelectJDs", c);
        // cmd.CommandText = "dbo.SelectJDs";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            dt = new DataTable();
            da.Fill(dt);
        }
        c.Close();


        StringBuilder output = new StringBuilder();
        output.Append("[");
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            output.Append("\"" + dt.Rows[i]["jd_name"].ToString() + "\"");

            if (i != (dt.Rows.Count - 1))
            {
                output.Append(",");
            }
        }
        output.Append("];");
        return output.ToString();
    }
    public static void CreateFolder(string FolderPath)
    {
        string path = string.Empty;
        if (IsValidPath(FolderPath))
            path = FolderPath;
        else
            path = HttpContext.Current.Server.MapPath(FolderPath);

        DirectoryInfo info = new DirectoryInfo(path);
        if (!info.Exists)
            Directory.CreateDirectory(path);
    }
    public static bool IsValidPath(string path)
    {
        Regex regex = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.]+)\\(?:[\w]+\\)*");
        return regex.IsMatch(path);
    }
    public static string FileBrowse(FileUpload Source, string FolderPath)
    {
        string str2;
        CreateFolder(FolderPath);
        //string extension = Source.FileName;
        string str = Source.FileName;
        if (IsValidPath(FolderPath))
            str2 = FolderPath;
        else
            str2 = HttpContext.Current.Server.MapPath(FolderPath);

        if ((str != "") && (Source.HasFile))
        {
            string filename = str2 + @"\" + str;
            Source.SaveAs(filename);
        }
        return str;
    }
    public static void FileResponse(string filename, string FolderPath)
    {
        string fileName = string.Empty;
        if (IsValidPath(FolderPath))
        {
            fileName = FolderPath + "/" + filename;
        }
        else
        {
            fileName = HttpContext.Current.Server.MapPath(FolderPath + "/" + filename);
        }
        FileInfo info = new FileInfo(fileName);
        if (info.Exists)
        {
            BinaryReader reader = new BinaryReader(info.OpenRead());
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            HttpContext.Current.Response.AddHeader("Content-Length", info.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            byte[] buffer = reader.ReadBytes((int)info.Length);
            reader.Close();
            HttpContext.Current.Response.BinaryWrite(buffer);
        }
    }
    public void Setview(string type)
    {
        if (type == "0")
        {
            tblmain.Style.Add("display", "none");
            tblNA.Style.Add("display", "");
            //Table14.Style.Add("display", "none");
            //trbuttons.Style.Add("display", "none");

        }
        else
        {
            tblmain.Style.Add("display", "");
            tblNA.Style.Add("display", "none");
            //Table14.Style.Add("display", "");
            //trbuttons.Style.Add("display", "");
        }

    }
    public void search()
    {
        try
        {
            string deptId = "";
            string catId = "";
            foreach (ListItem dept in cblDept.Items)
            {
                if (dept.Selected == true)
                    deptId += dept.Value + ",";
            }

            foreach (ListItem cat in cblCat.Items)
            {
                if (cat.Selected == true)
                    catId += cat.Value + ",";
            }
            deptId.TrimEnd(',');
            catId.TrimEnd(',');
            if (cbdept.Checked)
                deptId = "";
            if (cbdept.Checked)
                deptId = "";
            if (cbcat.Checked)
                catId = "";
            c.Open();
            DataSet ds1 = new DataSet();
            rptJDLIst.DataSource = null;
            rptJDLIst.DataBind();

            SqlCommand command = new SqlCommand("Select_JobDescription", c);
            if (!string.IsNullOrEmpty(txtJDName.Text))
                command.Parameters.AddWithValue("@Jd_Name", txtJDName.Text);
            if (deptId != "" && !cbdept.Checked)
                command.Parameters.AddWithValue("@dept_code", deptId);
            // if (catId != "" )
            command.Parameters.AddWithValue("@cat_code", catId);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter a1 = new SqlDataAdapter(command);
            a1.Fill(ds1);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                rptJDLIst.DataSource = ds1.Tables[0];
                rptJDLIst.DataBind();

                trFound.Visible = true;
                trnorecords.Visible = false;
            }
            else
            {
                trFound.Visible = false;
                trnorecords.Visible = true;

            }
            bindfooter(ds1.Tables[0]);
            c.Close();
        }
        catch { }

    }
    public void UpdateDepJd(string newrequest, string jd_code, string updatetype)
    {
        try
        {
            c.Open();
            DataSet ds1 = new DataSet();
            SqlCommand command = new SqlCommand("update_jobdept", c);
            command.Parameters.AddWithValue("@newRequest", newrequest);
            command.Parameters.AddWithValue("@jd_code", jd_code);
            command.Parameters.AddWithValue("@updatetype", updatetype);
            command.Parameters.AddWithValue("@userCode", usercode);
            command.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress.ToString());
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            c.Close();
        }
        catch
        { }
    }
    public void Updatepic(string fileUrl, string DeptCode)
    {
        try
        {
            c.Open();
            DataSet ds1 = new DataSet();
            SqlCommand command = new SqlCommand("update_DeptPic", c);
            command.Parameters.AddWithValue("@DeptCode", DeptCode);
            command.Parameters.AddWithValue("@FileUrl", fileUrl);

            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            c.Close();
        }
        catch
        { }
    }
    public void ApproveRequisition(string jd_code, string newReq)
    {
        try
        {
            c.Open();
            DataSet ds1 = new DataSet();
            SqlCommand command = new SqlCommand("Approve_requisition", c);
            command.Parameters.AddWithValue("@jd_Code", jd_code);
            command.Parameters.AddWithValue("@updatetype", "Approve");
            command.Parameters.AddWithValue("@New_requisition", newReq);
            command.Parameters.AddWithValue("@userCode", usercode);
            command.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress.ToString());
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            c.Close();
        }
        catch { }




    }
    public void DisApproveRequisition(string jd_code)
    {
        try
        {
            c.Open();
            DataSet ds1 = new DataSet();
            SqlCommand command = new SqlCommand("Disapprove_requisition", c);
            command.Parameters.AddWithValue("@jd_Code", jd_code);
            command.Parameters.AddWithValue("@updatetype", "DisApprove");
            //command.Parameters.AddWithValue("@New_requisition", newReq);
            command.Parameters.AddWithValue("@userCode", usercode);
            command.Parameters.AddWithValue("@UpdatedIp", Request.UserHostAddress.ToString());
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            c.Close();
        }
        catch { }




    }
    public void BindData()
    {
        try
        {
            DataSet ds = new DataSet();

            c.Open();
            SqlCommand command = new SqlCommand("BindData_JD", c);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter a = new SqlDataAdapter(command);
            a.Fill(ds);


            if (ds != null)
            {
                //cblCat.DataSource = ds.Tables[0];
                //cblCat.DataTextField = "cat_desc";
                //cblCat.DataValueField = "cat_code";
                //cblCat.DataBind();

                if (ds.Tables.Count >= 1)
                {
                    cblCat.DataSource = ds.Tables[0];
                    cblCat.DataTextField = "cat_desc";
                    cblCat.DataValueField = "cat_code";
                    cblCat.DataBind();
                    ddlCat.DataSource = ds.Tables[0];
                    ddlCat.DataTextField = "cat_desc";
                    ddlCat.DataValueField = "cat_code";
                    ddlCat.DataBind();
                    ddlCat.Items.Insert(0, new ListItem("-- Select Category --", "-1"));
                }
                if (ds.Tables.Count >= 2)
                {

                    cblDept.DataSource = ds.Tables[1];
                    cblDept.DataTextField = "cat_type_desc";
                    cblDept.DataValueField = "cat_type_code";
                    cblDept.DataBind();
                    ddlDept.DataSource = ds.Tables[1];
                    ddlDept.DataTextField = "cat_type_desc";
                    ddlDept.DataValueField = "cat_type_code";
                    ddlDept.DataBind();
                    ddlDept.Items.Insert(0, new ListItem("-- Select Department --", "-1"));
                }
            }


            DataSet ds1 = new DataSet();


            SqlCommand command1 = new SqlCommand("Select_JobDescription", c);
            command1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter a1 = new SqlDataAdapter(command1);
            a1.Fill(ds1);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                rptJDLIst.DataSource = ds1.Tables[0];
                rptJDLIst.DataBind();
                trFound.Visible = true;
                trnorecords.Visible = false;
            }
            else
            {
                trFound.Visible = false;
                trnorecords.Visible = true;

            }
            bindfooter(ds1.Tables[0]);

            c.Close();
        }
        catch { }

    }
    public void bindfooter(DataTable dt)
    {
        try
        {
            int tc = 0, fc = 0, ufc = 0, nrc = 0;
            foreach (DataRow dr in dt.Rows)
            {
                tc = tc + Convert.ToInt32(dr["totalcount"].ToString());
                fc = fc + Convert.ToInt32(dr["filledPos"].ToString());
                ufc = ufc + Convert.ToInt32(dr["unfilledcount"].ToString());
                nrc = nrc + Convert.ToInt32(dr["nr"].ToString());

            }
            lbltc.Text = tc.ToString();
            lblfc.Text = fc.ToString();
            lblufc.Text = ufc.ToString();
            lblnrc.Text = nrc.ToString();
        }
        catch { }

    }
    #endregion
}
