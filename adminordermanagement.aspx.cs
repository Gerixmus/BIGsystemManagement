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
    public partial class adminordermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //show order id
        protected void Button4_Click(object sender, EventArgs e)
        {
            getOrderID();
        }
        //show service button
        protected void Button3_Click(object sender, EventArgs e)
        {
            getNames();
        }
        //create button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkIfServiceExists() && checkIfUserExists())
            {
                addNewOrder();
                clearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Wrong User or Service ID');</script>");
            }
        }
        //mark as received button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteOrder();
            clearForm();
            GridView1.DataBind();
        }
        void getOrderID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from order_manager_tbl where order_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["user_id"].ToString();
                    TextBox2.Text = dt.Rows[0]["service_id"].ToString();
                    TextBox3.Text = dt.Rows[0]["member_name"].ToString();
                    TextBox4.Text = dt.Rows[0]["activity_description"].ToString();
                    TextBox5.Text = dt.Rows[0]["start_date"].ToString();
                    TextBox6.Text = dt.Rows[0]["end_date"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong order id')</script>");
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
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
        bool checkIfServiceExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from service_master_tbl where service_id='" + TextBox2.Text.Trim() + "';", con);
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
        void getNames()
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
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong user id')</script>");
                }
                cmd = new SqlCommand("select * from service_master_tbl where service_id='" + TextBox2.Text.Trim() + "';", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox7.Text = dt.Rows[0]["type_of_service"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong service id')</script>");
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void addNewOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into order_manager_tbl(user_id,service_id,member_name,activity_description,start_date,end_date) " +
                    "values(@user_id,@service_id,@member_name,@activity_description,@start_date,@end_date)", con);
                cmd.Parameters.AddWithValue("@user_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@service_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@activity_description", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@start_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@end_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Order added succesfully');</script>");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void deleteOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from order_manager_tbl where order_id='" + TextBox8.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Service deleted succesfully');</script>");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void getServiceID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from service_master_tbl where service_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid service ID');</script>");
                }
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
                Response.Write("<script>alert('"+x.Message+"')</script>");
            }
        }
    }
}