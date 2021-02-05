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
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sign up code
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Testing');</script>");
            if (ExistingUser())
            {
                Response.Write("<script>alert('This login is already in use');</script>");
            }
            else
            {
                Sign_Up();
                Response.Redirect("userlogin.aspx");
                Response.Write("<script>alert('Sign up succesfull');</script>");
            }

        }

        //check if user exists
        bool ExistingUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where member_id='"+TextBox5.Text.Trim()+"';", con);
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

        //sign up data
        void Sign_Up()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into user_master_tbl(member_id,full_name,date_of_birth,phone_nr,email_address,password,account_status) " +
                    "values(@member_id,@full_name,@date_of_birth,@phone_nr,@email_address,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_nr", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email_address", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign up succesfull');</script>");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
    }
}