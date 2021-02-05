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
    public partial class adminservicemanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfServiceExists())
            {
                Response.Write("<script>alert('Service with this id already exists');</script>");
            }
            else
            {
                addNewService();
                clearForm();
                GridView1.DataBind();
            }            
        }
        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfServiceExists())
            {
                updateService();
                clearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No service with this id');</script>");
            }
        }
        //delete button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfServiceExists())
            {
                deleteService();
                clearForm();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No service with this id');</script>");
            }
        }
        //show button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getServiceID();
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
        void deleteService()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from service_master_tbl where service_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Service deleted succesfully');</script>");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void updateService()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update service_master_tbl set type_of_service=@type_of_service,description=@description where service_id='"+TextBox1.Text.Trim()+"'", con);
                cmd.Parameters.AddWithValue("@type_of_service", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Service updated succesfully');</script>");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
            }
        }
        void addNewService()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into service_master_tbl(service_id,type_of_service,description) " +
                    "values(@service_id,@type_of_service,@description)", con);
                cmd.Parameters.AddWithValue("@service_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@type_of_service", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Service added succesfully');</script>");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.Message + "');</script>");
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
                SqlCommand cmd = new SqlCommand("select * from service_master_tbl where service_id='" + TextBox1.Text.Trim() + "';", con);
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
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
        }
    }
}