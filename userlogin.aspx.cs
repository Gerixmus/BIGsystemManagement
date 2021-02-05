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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        //login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where member_id='"+TextBox1.Text.Trim()+"' AND password='"+TextBox2.Text.Trim()+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login succesfull');</script>");
                        Session["username"] = dr.GetValue(0);
                        Session["fullname"] = dr.GetValue(1);
                        Session["status"] = dr.GetValue(6);
                        Session["role"] = "user";                        
                    }
                    Response.Redirect("userprofile.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid user');</script>");
                }
            }
            catch(Exception x)
            {
                Response.Write("<script>alert(" + x.Message + "');</script>");
            }
            //Response.Write("<script>alert('Hello');</script>");
        }
    }
}