using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIGsystemManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((string)Session["username"]))
                {
                    Response.Write("<script>alert('Session expired please login again')</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserData();
                    if (!Page.IsPostBack)
                    {
                        getUserPersonalData();
                    }
                }
            }      
            catch (Exception x)
            {
                Response.Write("<script>alert('Session expired please login again')</script>");
                Response.Redirect("userlogin.aspx");
            }
        }
        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((string)Session["username"]))
                {
                    Response.Write("<script>alert('Session expired please login again')</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    updateUser();
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('Session expired please login again')</script>");
                Response.Redirect("userlogin.aspx");
            }
        }
        void updateUser()
        {
            string password = "";
            if (String.IsNullOrEmpty(TextBox7.Text.Trim().ToString()))
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update user_master_tbl set phone_nr=@phone_nr, email_address=@email_address, account_status= @account_status where member_id='"+Session["username"].ToString().Trim()+"'", con);
                    cmd.Parameters.AddWithValue("@phone_nr", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email_address", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Update succesfull');</script>");
                        getUserData();
                        getUserPersonalData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error');</script>");
                    }
                }
                catch (Exception x)
                {
                    Response.Write("<script>alert('" + x.Message + "');</script>");
                }
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    password = TextBox7.Text.Trim();
                    SqlCommand cmd = new SqlCommand("update user_master_tbl set phone_nr=@phone_nr, email_address=@email_address, account_status=@account_status, password=@password where member_id='" + Session["username"].ToString().Trim() + "'", con);
                    cmd.Parameters.AddWithValue("@phone_nr", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email_address", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Update succesfull');</script>");
                        getUserData();
                        getUserPersonalData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error');</script>");
                    }
                }
                catch (Exception x)
                {
                    Response.Write("<script>alert('" + x.Message + "');</script>");
                }
            }
        }
        void getUserPersonalData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["date_of_birth"].ToString();
                TextBox3.Text = dt.Rows[0]["phone_nr"].ToString();
                TextBox4.Text = dt.Rows[0]["email_address"].ToString();
                TextBox5.Text = dt.Rows[0]["member_id"].ToString();
                Label1.Text = dt.Rows[0]["account_status"].ToString();
                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "btn btn-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "btn btn-warning");
                }
                else
                {
                    Label1.Attributes.Add("class", "btn btn-danger");
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void getUserData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from order_manager_tbl where user_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dts = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime dte = Convert.ToDateTime(e.Row.Cells[6].Text);
                    DateTime today = DateTime.Today;
                    if (today < dts)
                    {
                        e.Row.BackColor = System.Drawing.Color.GreenYellow;
                    }
                    else if (today >= dts)
                    {
                        if (today > dte)
                        {
                            e.Row.BackColor = System.Drawing.Color.Tomato;
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                        }
                    }

                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "')</script>");
            }
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}