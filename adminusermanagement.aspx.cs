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
    public partial class adminusermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateUserStatus("active");
            GridView1.DataBind();
        }
        //show button
        protected void Button3_Click(object sender, EventArgs e)
        {
            getUserByID();
            GridView1.DataBind();
        }
        //pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateUserStatus("pending");
            GridView1.DataBind();
        }
        //inactive button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateUserStatus("inactive");
            GridView1.DataBind();
        }
        //delete button
        protected void Button1_Click(object sender, EventArgs e)
        {
            deleteUser();
            clearForm();
            GridView1.DataBind();
        }

        void getUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(6).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox5.Text = dr.GetValue(3).ToString();
                        TextBox8.Text = dr.GetValue(4).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('No user with this ID');</script>");
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert(" + x.Message + "');</script>");
            }
        }
        void updateUserStatus(string status)
        {
            if (checkIfUserExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update user_master_tbl set account_status='" + status + "' where member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('User status updated')</script>");
                }
                catch (Exception x)
                {
                    Response.Write("<script>alert(" + x.Message + "');</script>");
                }
            }
            else if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('User ID cannot be empty')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid member ID')</script>");
            }
        }
        void deleteUser()
        {
            if (checkIfUserExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("delete from user_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('User deleted succesfully');</script>");
                }
                catch (Exception x)
                {
                    Response.Write("<script>alert('" + x.Message + "');</script>");
                }
            }
            else if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('User ID cannot be empty')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid member ID')</script>");
            }  
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox8.Text = "";
        }
        bool checkIfUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
                return false;
            }
        }
    }
}